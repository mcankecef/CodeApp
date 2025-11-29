using AutoMapper;
using CodeApp.Application.Dtos.Language;
using CodeApp.Application.Features.LanguageCommandQuery.Commands.CreateLanguage;
using CodeApp.Application.Features.LanguageCommandQuery.Commands.UpdateLanguage;
using CodeApp.Domain.Entities;

namespace CodeApp.Application.Mapping
{
    public class LanguageMapping : Profile
    {
        public LanguageMapping()
        {
            CreateMap<Language, GetAllLanguageDto>().ReverseMap();
            
            CreateMap<Language, CreateLanguageDto>().ReverseMap();
            CreateMap<Language, CreateLanguageCommandRequest>().ReverseMap();

            CreateMap<Language, UpdateLanguageCommandRequest>().ReverseMap();
        }
    }
}
