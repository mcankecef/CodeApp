using CodeApp.Application.Wrapper;
using MediatR;

namespace CodeApp.Application.Features.AuthCommandQuery.ForgotPassword;

public class ForgotPasswordCommandRequest : IRequest<BaseResponse<bool>>
{
    public required string Email { get; set; }
    public string? Language { get; set; }
}
