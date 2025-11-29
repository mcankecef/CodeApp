using AutoMapper;
using CodeApp.Application.Dtos.Avatar;
using CodeApp.Application.Features.AvatarCommandQuery.Commands.CreateAvatar;
using CodeApp.Domain.Entities;

namespace CodeApp.Application.Mapping
{
    public class AvatarMapping : Profile
    {
        public AvatarMapping()
        {
            CreateMap<Avatar, GetAllAvatarDto>();

            CreateMap<CreateAvatarCommandRequest, Avatar>();
            CreateMap<Avatar,CreateAvatarDto>();
        }
    }
}
