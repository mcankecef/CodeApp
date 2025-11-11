using CodeApp.Application.Dtos.StepQuestion;
using CodeApp.Application.Repositories.AppUserStepQuestion;
using CodeApp.Application.Repositories.StepQuestion;
using CodeApp.Application.Wrapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CodeApp.Application.Features.StepQuestionCommandQuery.Queries.GetStepQuestions;

public class GetStepQuestionsQueryHandler : IRequestHandler<GetStepQuestionsQueryRequest, BaseResponse<List<StepQuestionDto>>>
{
    private readonly IAppUserStepQuestionReadRepository _appUserStepQuestionReadRepository;
    private readonly IStepQuestionReadRepository _stepQuestionReadRepository;

    public GetStepQuestionsQueryHandler(
        IAppUserStepQuestionReadRepository appUserStepQuestionReadRepository,
        IStepQuestionReadRepository stepQuestionReadRepository)
    {
        _appUserStepQuestionReadRepository = appUserStepQuestionReadRepository;
        _stepQuestionReadRepository = stepQuestionReadRepository;
    }

    public async Task<BaseResponse<List<StepQuestionDto>>> Handle(GetStepQuestionsQueryRequest request, CancellationToken cancellationToken)
    {
        var userProgress = await _appUserStepQuestionReadRepository.Queryable()
            .FirstOrDefaultAsync(x => x.AppUserId == request.AppUserId && x.LanguageId == request.LanguageId, cancellationToken);

        var currentStep = userProgress?.CurrentStepNumber ?? 1;

        var steps = await _stepQuestionReadRepository.Queryable()
            .Where(x => x.LanguageId == request.LanguageId)
            .OrderBy(x => x.StepNumber)
            .ToListAsync(cancellationToken);

        var dtos = steps.Select(step => new StepQuestionDto
        {
            Id = step.Id,
            Title = step.Title,
            StepNumber = step.StepNumber,
            IsLocked = step.StepNumber > currentStep,
            IsCurrentStep = step.StepNumber == currentStep,
        }).ToList();

        return new BaseResponse<List<StepQuestionDto>>("", true, dtos);
    }
}