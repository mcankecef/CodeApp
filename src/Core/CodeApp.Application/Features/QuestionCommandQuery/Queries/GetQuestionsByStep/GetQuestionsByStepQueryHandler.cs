using CodeApp.Application.Dtos.Question;
using CodeApp.Application.Dtos.StepQuestion;
using CodeApp.Application.Repositories;
using CodeApp.Application.Repositories.AppUserStepQuestion;
using CodeApp.Application.Repositories.StepQuestion;
using CodeApp.Application.Wrapper;
using CodeApp.Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CodeApp.Application.Features.QuestionCommandQuery.Queries.GetQuestionsByStep;

public class GetQuestionsByStepQueryHandler : IRequestHandler<GetQuestionsByStepQueryRequest, BaseResponse<GetStepQuestionsResponseDto>>
{
    private readonly IAppUserStepQuestionReadRepository _appUserStepQuestionReadRepository;
    private readonly IStepQuestionReadRepository _stepQuestionReadRepository;
    private readonly IQuestionReadRepository _questionReadRepository;

    public GetQuestionsByStepQueryHandler(
        IAppUserStepQuestionReadRepository appUserStepQuestionReadRepository,
        IStepQuestionReadRepository stepQuestionReadRepository,
        IQuestionReadRepository questionReadRepository)
    {
        _appUserStepQuestionReadRepository = appUserStepQuestionReadRepository;
        _stepQuestionReadRepository = stepQuestionReadRepository;
        _questionReadRepository = questionReadRepository;
    }

    public async Task<BaseResponse<GetStepQuestionsResponseDto>> Handle(GetQuestionsByStepQueryRequest request,
        CancellationToken cancellationToken)
    {
        var userProgress = await _appUserStepQuestionReadRepository.Queryable()
            .FirstOrDefaultAsync(x => x.AppUserId == request.AppUserId 
                                    && x.LanguageId == request.LanguageId,
                cancellationToken);

        if (userProgress is null)
            throw new UnauthorizedAccessException("Kullanıcı ilerleme bilgisi bulunamadı.");

        var step = await _stepQuestionReadRepository.Queryable()
            .FirstOrDefaultAsync(x => x.Id == request.StepQuestionId, cancellationToken);

        if (step is null)
            throw new ArgumentException("Step bulunamadı.");

        if (step.StepNumber > userProgress.CurrentStepNumber)
            throw new UnauthorizedAccessException("This step is locked for the user.");

        var questions = await _questionReadRepository.Queryable()
            .Include(q => q.Answers)
            .Include(q => q.Language)
            .Where(q => q.StepQuestionId == step.Id)
            //.Where(q => q.Status == StatusType.Active)
            .ToListAsync(cancellationToken);

        var dto = new GetStepQuestionsResponseDto
        {
            StepId = step.Id,
            StepTitle = step.Title,
            StepNumber = step.StepNumber,
            Questions = questions.Select(q => new QuestionDto
            {
                Id = q.Id,
                Name = q.Name,
                Description = q.Description,
                Level = (int)q.Level,
                Score = q.Score,
                CorrectAnswer = q.CorrectAnswer,
                Answers = q.Answers.Select(a => a.AnswerName).ToList()
            }).ToList()
        };

        return new BaseResponse<GetStepQuestionsResponseDto>("Step questions retrieved successfully.", true, dto);
    }
}