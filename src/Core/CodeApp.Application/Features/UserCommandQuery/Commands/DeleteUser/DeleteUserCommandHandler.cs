using CodeApp.Application.Abstractions;
using CodeApp.Application.Dtos;
using CodeApp.Application.Wrapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeApp.Application.Features.UserCommandQuery.Commands.DeleteUser
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommandRequest, BaseResponse<NoContentDto>>
    {
        private readonly IUserService _userService;

        public DeleteUserCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<BaseResponse<NoContentDto>> Handle(DeleteUserCommandRequest request, CancellationToken cancellationToken)
        {
            if(request.UserId== null)
                throw new ArgumentNullException($"{request.UserId} is must not null");

            await _userService.DeleteUser(request.UserId);

            return new BaseResponse<NoContentDto>();


        }
    }
}
