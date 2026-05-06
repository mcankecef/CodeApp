using CodeApp.Application.Wrapper;
using CodeApp.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace CodeApp.Application.Features.AuthCommandQuery.ResetPassword;

public class ResetPasswordCommandHandler : IRequestHandler<ResetPasswordCommandRequest, BaseResponse<bool>>
{
    private const string PasswordResetCodeProvider = "Default";
    private const string PasswordResetCodeName = "PasswordResetCode";
    private const string PasswordResetCodeCreatedAtName = "PasswordResetCodeCreatedAtUtc";

    private readonly UserManager<AppUser> _userManager;
    private readonly IConfiguration _configuration;

    public ResetPasswordCommandHandler(UserManager<AppUser> userManager, IConfiguration configuration)
    {
        _userManager = userManager;
        _configuration = configuration;
    }

    public async Task<BaseResponse<bool>> Handle(ResetPasswordCommandRequest request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByEmailAsync(request.Email);
        if (user is null)
            return new BaseResponse<bool>("Invalid token or email.", false, false);

        var storedCode = await _userManager.GetAuthenticationTokenAsync(user, PasswordResetCodeProvider, PasswordResetCodeName);
        if (storedCode != request.Token)
            return new BaseResponse<bool>("Invalid token or email.", false, false);

        var createdAtRaw = await _userManager.GetAuthenticationTokenAsync(user, PasswordResetCodeProvider, PasswordResetCodeCreatedAtName);
        if (!DateTime.TryParse(createdAtRaw, out var createdAtUtc))
            return new BaseResponse<bool>("Invalid token or email.", false, false);

        var lifetimeMinutesRaw = _configuration["PasswordReset:CodeLifetimeMinutes"];
        var lifetimeMinutes = int.TryParse(lifetimeMinutesRaw, out var parsedLifetime) ? parsedLifetime : 10;
        if (DateTime.UtcNow > createdAtUtc.ToUniversalTime().AddMinutes(lifetimeMinutes))
            return new BaseResponse<bool>("Reset code has expired.", false, false);

        await _userManager.RemoveAuthenticationTokenAsync(user, PasswordResetCodeProvider, PasswordResetCodeName);
        await _userManager.RemoveAuthenticationTokenAsync(user, PasswordResetCodeProvider, PasswordResetCodeCreatedAtName);

        var resetToken = await _userManager.GeneratePasswordResetTokenAsync(user);
        var result = await _userManager.ResetPasswordAsync(user, resetToken, request.NewPassword);

        if (!result.Succeeded)
        {
            var message = result.Errors.FirstOrDefault()?.Description ?? "Password reset failed.";
            return new BaseResponse<bool>(message, false, false);
        }

        return new BaseResponse<bool>("Password reset successful.", true, true);
    }
}
