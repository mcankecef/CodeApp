using AutoMapper;
using CodeApp.Application.Dtos.User;
using CodeApp.Application.Exceptions;
using CodeApp.Application.Wrapper;
using CodeApp.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Reflection;

namespace CodeApp.Application.Features.UserCommandQuery.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, BaseResponse<CreateUserDto>>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        public CreateUserCommandHandler(UserManager<AppUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<BaseResponse<CreateUserDto>> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
        {
            if (request is null)
                throw new ArgumentNullException($"Model is not valid!");

            var appUser = new AppUser
            {
                UserName = request.FullName,
                Email = request.Email,
                FullName = request.FullName
            };
            var result = await _userManager.CreateAsync(appUser,request.Password);


            if (result.Succeeded)
            {
                var response = _mapper.Map<CreateUserDto>(appUser);

                return new BaseResponse<CreateUserDto>("User succesfully created", true, response);
            }

            string message = string.Empty;

            foreach (var error in result.Errors)
                message += $"{error.Description}";


            return new BaseResponse<CreateUserDto>(message, false);
        }
    }
}
