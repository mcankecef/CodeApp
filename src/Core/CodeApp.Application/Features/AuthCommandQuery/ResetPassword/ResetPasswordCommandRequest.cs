using CodeApp.Application.Wrapper;
using MediatR;

namespace CodeApp.Application.Features.AuthCommandQuery.ResetPassword;

public class ResetPasswordCommandRequest : IRequest<BaseResponse<bool>>
{
    public required string Email { get; set; }
    public required string Token { get; set; }
    public required string NewPassword { get; set; }
}
