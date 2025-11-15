using CodeApp.Application.Dtos.StepQuestion;
using CodeApp.Application.Repositories.AppUserStepQuestion;
using CodeApp.Application.Repositories.StepQuestion;
using CodeApp.Application.Wrapper;
using CodeApp.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CodeApp.Application.Features.StepQuestionCommandQuery.Queries.GetStepQuestions;

public class GetStepQuestionsQueryHandler : IRequestHandler<GetStepQuestionsQueryRequest, BaseResponse<List<StepQuestionDto>>>
{
    private readonly IAppUserStepQuestionReadRepository _appUserStepQuestionReadRepository;
    private readonly IAppUserStepQuestionWriteRepository _appUserStepQuestionWriteRepository;
    private readonly IStepQuestionReadRepository _stepQuestionReadRepository;

    public GetStepQuestionsQueryHandler(
        IAppUserStepQuestionReadRepository appUserStepQuestionReadRepository,
        IAppUserStepQuestionWriteRepository appUserStepQuestionWriteRepository,
        IStepQuestionReadRepository stepQuestionReadRepository)
    {
        _appUserStepQuestionReadRepository = appUserStepQuestionReadRepository;
        _appUserStepQuestionWriteRepository = appUserStepQuestionWriteRepository;
        _stepQuestionReadRepository = stepQuestionReadRepository;
    }

    public async Task<BaseResponse<List<StepQuestionDto>>> Handle(GetStepQuestionsQueryRequest request, CancellationToken cancellationToken)
    {
        var userProgress = await _appUserStepQuestionReadRepository.Queryable()
            .FirstOrDefaultAsync(x => x.AppUserId == request.AppUserId && x.LanguageId == request.LanguageId, cancellationToken);

        if (userProgress == null)
        {
            var firstStep = await _stepQuestionReadRepository.Queryable()
                .Where(x => x.LanguageId == request.LanguageId)
                .OrderBy(x => x.StepNumber)
                .FirstOrDefaultAsync(cancellationToken);

            if (firstStep != null)
            {
                userProgress = new AppUserStepQuestion
                {
                    Id = Guid.NewGuid(),
                    AppUserId = request.AppUserId,
                    LanguageId = request.LanguageId,
                    StepQuestionId = firstStep.Id,
                    CurrentStepNumber = 1,
                    Score = 0
                };

                await _appUserStepQuestionWriteRepository.CreateAsync(userProgress);
            }
        }

        var steps = await _stepQuestionReadRepository.Queryable()
            .Where(x => x.LanguageId == request.LanguageId)
            .OrderBy(x => x.StepNumber)
            .ToListAsync(cancellationToken);

        var dtos = steps.Select(step => new StepQuestionDto
        {
            Id = step.Id,
            Title = step.Title,
            StepNumber = step.StepNumber,
            IsLocked = step.StepNumber > userProgress?.CurrentStepNumber,
            IsCurrentStep = step.StepNumber == userProgress?.CurrentStepNumber,
        }).ToList();

        return new BaseResponse<List<StepQuestionDto>>("", true, dtos);
    }
}