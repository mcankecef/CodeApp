using AutoMapper;
using CodeApp.Application.Dtos.Language;
using CodeApp.Application.Features.LanguageCommandQuery.Commands.CreateLanguage;
using CodeApp.Domain.Entities;

namespace CodeApp.Application.Mapping
{
    public class LanguageMapping : Profile
    {
        public LanguageMapping()
        {
            CreateMap<Language, CreateLanguageDto>().ReverseMap();
            CreateMap<Language, CreateLanguageCommandRequest>().ReverseMap();
        }
    }
}
