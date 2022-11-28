using AutoMapper;
using CodeApp.Application.Dtos.Answer;
using CodeApp.Application.Features.AnswerCommandQuery.Queries;
using CodeApp.Domain.Entities;

namespace CodeApp.Application.Mapping
{
    public class AnswerMapping : Profile
    {
        public AnswerMapping()
        {
            //Create
            CreateMap<Answer, CreateAnswerDto>().ReverseMap();

            //Get
            CreateMap<Answer, GetAllAnswerDto>().ReverseMap();
            CreateMap<GetAllAnswerDto, GetAllAnswerDto>().ReverseMap();
            CreateMap<Answer, GetAllAnswerQueryRequest>().ReverseMap();
            CreateMap<Answer, AnswerDto>().ReverseMap();
        }
    }
}
