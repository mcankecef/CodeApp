using AutoMapper;
using CodeApp.Application.Abstractions;
using CodeApp.Application.Dtos;
using CodeApp.Application.Dtos.User;
using CodeApp.Application.Wrapper;
using MediatR;

namespace CodeApp.Application.Features.UserCommandQuery.Commands.UpdateScore
{
    public class UpdateScoreCommandHandler : IRequestHandler<UpdateScoreCommandRequest, BaseResponse<NoContentDto>>
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UpdateScoreCommandHandler(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        public async Task<BaseResponse<NoContentDto>> Handle(UpdateScoreCommandRequest request, CancellationToken cancellationToken)
        {
            if (request.UserId == null)
                throw new ArgumentNullException($"{request.UserId} is null!");

            var userScoreDto = _mapper.Map<UserScoreDto>(request);

            await _userService.UpdateUserScore(userScoreDto);

            return new BaseResponse<NoContentDto>();

        }
    }
}
