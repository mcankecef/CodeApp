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
    public class DeleteUserCommandRequest : IRequest<BaseResponse<NoContentDto>>
    {
        public string UserId { get; set; }

        public DeleteUserCommandRequest(string userId)
        {
            UserId = userId;
        }
    }
}
