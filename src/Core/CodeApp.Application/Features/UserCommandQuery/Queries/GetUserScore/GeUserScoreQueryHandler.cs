using AutoMapper;
using CodeApp.Application.Abstractions;
using CodeApp.Application.Dtos.User;
using CodeApp.Application.Wrapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeApp.Application.Features.UserCommandQuery.Queries.GetUserScore
{
    public class GetAllUserScoreQueryHandler : IRequestHandler<GetAllUserScoreQueryRequest, BaseResponse<int>>
    {
        private readonly IUserService _userService;

        public GetAllUserScoreQueryHandler(IUserService userService, IMapper mapper)
        {
            _userService = userService;
        }

        public async Task<BaseResponse<int>> Handle(GetAllUserScoreQueryRequest request, CancellationToken cancellationToken)
        {
            var userScore = await _userService.GetUserScore(request.UserId);

            return new BaseResponse<int>(userScore, true);
        }
    }
}
