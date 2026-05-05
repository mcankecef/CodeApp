using AutoMapper;
using CodeApp.Application.Dtos.StepQuestion;
using CodeApp.Domain.Entities;

namespace CodeApp.Application.Mapping;

public class StepQuestionMapping : Profile
{
    public StepQuestionMapping()
    {
        CreateMap<StepQuestion, StepQuestionDto>().ReverseMap();
    }
}
