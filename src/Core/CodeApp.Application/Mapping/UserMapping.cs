using AutoMapper;
using CodeApp.Application.Dtos.User;
using CodeApp.Application.Features.UserCommandQuery.Commands.AddScoreToUser;
using CodeApp.Domain.Entities.Identity;

namespace CodeApp.Application.Mapping
{
    public class UserMapping : Profile
    {
        public UserMapping()
        {
            CreateMap<AppUser, CreateUserDto>().ReverseMap();
            CreateMap<AppUser, GetAllUserDto>().ReverseMap();
            CreateMap<UpdateScoreToUserCommandRequest, UserScoreDto>().ReverseMap();
            CreateMap<AppUser, UserScoreDto>().ReverseMap();
        }
    }
}
