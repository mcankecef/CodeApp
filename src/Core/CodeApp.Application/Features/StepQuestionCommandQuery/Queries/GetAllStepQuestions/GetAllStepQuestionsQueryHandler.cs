using CodeApp.Application.Dtos.StepQuestion;
using CodeApp.Application.Repositories.StepQuestion;
using CodeApp.Application.Wrapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CodeApp.Application.Features.StepQuestionCommandQuery.Queries.GetAllStepQuestions;

public class GetAllStepQuestionsQueryHandler : IRequestHandler<GetAllStepQuestionsQueryRequest, BaseResponse<List<StepQuestionDto>>>
{
    private readonly IStepQuestionReadRepository _stepQuestionReadRepository;

    public GetAllStepQuestionsQueryHandler(IStepQuestionReadRepository stepQuestionReadRepository)
    {
        _stepQuestionReadRepository = stepQuestionReadRepository;
    }

    public async Task<BaseResponse<List<StepQuestionDto>>> Handle(GetAllStepQuestionsQueryRequest request, CancellationToken cancellationToken)
    {
        var stepQuestions = await _stepQuestionReadRepository.Queryable()
            .Where(x => x.LanguageId == request.LanguageId)
            .OrderBy(x => x.StepNumber)
            .ToListAsync(cancellationToken);

        if (!stepQuestions.Any())
        {
            return new BaseResponse<List<StepQuestionDto>>("No step questions found for the specified language.", false);
        }

        var stepQuestionDtos = stepQuestions.Select(step => new StepQuestionDto
        {
            Id = step.Id,
            StepNumber = step.StepNumber,
            Title = step.Title,
            Description = step.Description,
            LanguageId = step.LanguageId,
            IsLocked = false,
            IsCurrentStep = false,
            IsCompleted = false
        }).ToList();

        return new BaseResponse<List<StepQuestionDto>>(stepQuestionDtos, true);
    }
}
