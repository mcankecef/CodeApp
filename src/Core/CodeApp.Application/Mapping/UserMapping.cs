using AutoMapper;
using CodeApp.Application.Dtos.User;
using CodeApp.Application.Features.UserCommandQuery.Commands.UpdateScore;
using CodeApp.Application.Features.UserCommandQuery.Commands.UpdateUser;
using CodeApp.Domain.Entities.Identity;

namespace CodeApp.Application.Mapping
{
    public class UserMapping : Profile
    {
        public UserMapping()
        {
            CreateMap<AppUser, CreateUserDto>().ReverseMap();
            CreateMap<AppUser, GetAllUserDto>().ReverseMap();
            CreateMap<UpdateScoreCommandRequest, UserScoreDto>().ReverseMap();
            CreateMap<AppUser, UserScoreDto>().ReverseMap();
            CreateMap<AppUser, GetUserByIdDto>().ReverseMap();
            CreateMap<UpdateUserCommandRequest, UpdateUserDto>().ReverseMap();
        }
    }
}
