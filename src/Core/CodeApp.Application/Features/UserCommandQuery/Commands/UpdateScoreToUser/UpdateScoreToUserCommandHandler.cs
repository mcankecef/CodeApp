using AutoMapper;
using CodeApp.Application.Abstractions;
using CodeApp.Application.Dtos;
using CodeApp.Application.Dtos.User;
using CodeApp.Application.Wrapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeApp.Application.Features.UserCommandQuery.Commands.AddScoreToUser
{
    public class UpdateScoreToUserCommandHandler : IRequestHandler<UpdateScoreToUserCommandRequest, BaseResponse<NoContentDto>>
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UpdateScoreToUserCommandHandler(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        public async Task<BaseResponse<NoContentDto>> Handle(UpdateScoreToUserCommandRequest request, CancellationToken cancellationToken)
        {
            if (request.UserId == null)
                throw new ArgumentNullException($"{request.UserId} is null!");

            var userScoreDto = _mapper.Map<UserScoreDto>(request);

            await _userService.AddScoreToUser(userScoreDto);

            return new BaseResponse<NoContentDto>();

        }
    }
}
