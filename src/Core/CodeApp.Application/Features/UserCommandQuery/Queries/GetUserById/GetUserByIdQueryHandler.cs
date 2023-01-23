using CodeApp.Application.Abstractions;
using CodeApp.Application.Dtos.User;
using CodeApp.Application.Features.UserCommandQuery.Queries.GetByUserId;
using CodeApp.Application.Wrapper;
using MediatR;

namespace CodeApp.Application.Features.UserCommandQuery.Queries.GetUserByIdId
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQueryRequest, BaseResponse<GetUserByIdDto>>
    {
        private readonly IUserService _userService;

        public GetUserByIdQueryHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<BaseResponse<GetUserByIdDto>> Handle(GetUserByIdQueryRequest request, CancellationToken cancellationToken)
        {
            if (request.UserId is null)
                throw new ArgumentNullException("User id is must not null!");

            var result = await _userService.GetUserById(request.UserId);

            return new BaseResponse<GetUserByIdDto>(result, true);
        }
    }
}
