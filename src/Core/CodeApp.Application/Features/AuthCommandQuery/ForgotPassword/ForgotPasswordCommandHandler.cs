using CodeApp.Application.Abstractions.Services;
using CodeApp.Application.Wrapper;
using CodeApp.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace CodeApp.Application.Features.AuthCommandQuery.ForgotPassword;

public class ForgotPasswordCommandHandler : IRequestHandler<ForgotPasswordCommandRequest, BaseResponse<bool>>
{
    private const string PasswordResetCodeProvider = "Default";
    private const string PasswordResetCodeName = "PasswordResetCode";
    private const string PasswordResetCodeCreatedAtName = "PasswordResetCodeCreatedAtUtc";

    private readonly UserManager<AppUser> _userManager;
    private readonly IEmailService _emailService;
    private readonly IConfiguration _configuration;

    public ForgotPasswordCommandHandler(
        UserManager<AppUser> userManager,
        IEmailService emailService,
        IConfiguration configuration)
    {
        _userManager = userManager;
        _emailService = emailService;
        _configuration = configuration;
    }

    public async Task<BaseResponse<bool>> Handle(ForgotPasswordCommandRequest request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByEmailAsync(request.Email);

        if (user is not null)
        {
            var code = Random.Shared.Next(100000, 999999).ToString();
            await _userManager.SetAuthenticationTokenAsync(user, PasswordResetCodeProvider, PasswordResetCodeName, code);
            await _userManager.SetAuthenticationTokenAsync(
                user,
                PasswordResetCodeProvider,
                PasswordResetCodeCreatedAtName,
                DateTime.UtcNow.ToString("O"));

            var language = (request.Language ?? "en").Trim().ToLowerInvariant();
            var lifetimeMinutes = GetCodeLifetimeMinutes();
            var (subject, body) = BuildResetEmail(language, code, lifetimeMinutes);

            await _emailService.SendEmailAsync(request.Email, subject, body);
        }

        return new BaseResponse<bool>(
            "If an account exists, a reset code has been sent.",
            true,
            true);
    }

    private int GetCodeLifetimeMinutes()
    {
        var lifetimeMinutesRaw = _configuration["PasswordReset:CodeLifetimeMinutes"];
        return int.TryParse(lifetimeMinutesRaw, out var parsedLifetime) ? parsedLifetime : 10;
    }

    private static (string Subject, string Body) BuildResetEmail(string language, string code, int lifetimeMinutes)
    {
        if (language.StartsWith("tr"))
        {
            return (
                "CodeApp Sifre Sifirlama Kodu",
                $"""
                 <p>Merhaba,</p>
                 <p>Sifre sifirlama kodunuz: <strong>{code}</strong></p>
                 <p>Bu kod {lifetimeMinutes} dakika boyunca gecerlidir.</p>
                 <p>Bu islemi siz yapmadiysaniz bu e-postayi dikkate almayabilirsiniz.</p>
                 """
            );
        }

        return (
            "CodeApp Password Reset Code",
            $"""
             <p>Hello,</p>
             <p>Your password reset code is: <strong>{code}</strong></p>
             <p>This code is valid for {lifetimeMinutes} minutes.</p>
             <p>If you did not request this, you can safely ignore this email.</p>
             """
        );
    }
}
