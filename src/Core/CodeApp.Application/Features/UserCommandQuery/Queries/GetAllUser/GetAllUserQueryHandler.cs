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

namespace CodeApp.Application.Features.UserCommandQuery.Queries.GetAllUser
{
    public class GetAllUserQueryHandler : IRequestHandler<GetAllUserQueryRequest, BaseResponse<List<GetAllUserDto>>>
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public GetAllUserQueryHandler(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        public async Task<BaseResponse<List<GetAllUserDto>>> Handle(GetAllUserQueryRequest request, CancellationToken cancellationToken)
        {
            var users = await _userService.GetAllUser();

            var response = _mapper.Map<List<GetAllUserDto>>(users);

            return new BaseResponse<List<GetAllUserDto>>(response, true);
        }

    }
}
