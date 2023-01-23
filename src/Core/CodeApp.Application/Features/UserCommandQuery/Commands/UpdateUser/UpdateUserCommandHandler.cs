using AutoMapper;
using CodeApp.Application.Abstractions;
using CodeApp.Application.Dtos;
using CodeApp.Application.Dtos.User;
using CodeApp.Application.Wrapper;
using MediatR;

namespace CodeApp.Application.Features.UserCommandQuery.Commands.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommandRequest, BaseResponse<NoContentDto>>
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UpdateUserCommandHandler(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        public async Task<BaseResponse<NoContentDto>> Handle(UpdateUserCommandRequest request, CancellationToken cancellationToken)
        {
            var updateUserDto = _mapper.Map<UpdateUserDto>(request);    

            await _userService.UpdateUser(updateUserDto);

            return new BaseResponse<NoContentDto>();
        }
    }
}
