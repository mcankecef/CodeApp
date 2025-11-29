using AutoMapper;
using CodeApp.Application.Dtos.Question;
using CodeApp.Application.Features.QuestionCommandQuery.Commands.CreateQuestion;
using CodeApp.Domain.Entities;

namespace CodeApp.Application.Mapping
{
    public class QuestionMapping : Profile
    {
        public QuestionMapping()
        {
            CreateMap<Question,GetAllQuestionDto>().ReverseMap();

            CreateMap<Question,CreateQuestionDto>().ReverseMap();
            CreateMap<Question,CreateQuestionCommandRequest>().ReverseMap();
            CreateMap<CreateQuestionDto,CreateQuestionCommandRequest>().ReverseMap();

            CreateMap<Question,GetQuestionByIdDto>().ReverseMap();

        }
    }
}
