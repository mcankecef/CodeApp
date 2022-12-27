using AutoMapper;
using CodeApp.Application.Dtos.User;
using CodeApp.Application.Features.UserCommandQuery.Commands.CreateUser;
using CodeApp.Domain.Entities.Identity;

namespace CodeApp.Application.Mapping
{
    public class UserMapping : Profile
    {
        public UserMapping()
        {
            CreateMap<AppUser, CreateUserDto>().ReverseMap();
        }
    }
}
