using AutoMapper;
using CodeApp.Application.Dtos.Answer;
using CodeApp.Domain.Entities;

namespace CodeApp.Application.Mapping
{
    public class AnswerMapping : Profile
    {
        public AnswerMapping()
        {
            //Create
            CreateMap<Answer, CreateAnswerDto>().ReverseMap();
        }
    }
}
