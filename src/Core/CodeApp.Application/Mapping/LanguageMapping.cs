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
            //Get
            CreateMap<Language, GetAllLanguageDto>().ReverseMap();
            
            //Create
            CreateMap<Language, CreateLanguageDto>().ReverseMap();
            CreateMap<Language, CreateLanguageCommandRequest>().ReverseMap();

            //Update
            CreateMap<Language, UpdateLanguageCommandRequest>().ReverseMap();
        }
    }
}
