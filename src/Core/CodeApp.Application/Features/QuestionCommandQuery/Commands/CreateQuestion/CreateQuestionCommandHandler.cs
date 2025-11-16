using CodeApp.Application.Dtos.Question;
using CodeApp.Application.Repositories;
using CodeApp.Application.Repositories.StepQuestion;
using CodeApp.Application.Wrapper;
using CodeApp.Domain.Entities;
using CodeApp.Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CodeApp.Application.Features.QuestionCommandQuery.Commands.CreateQuestion;

public class
    CreateQuestionCommandHandler : IRequestHandler<CreateQuestionCommandRequest, BaseResponse<CreateQuestionDto>>
{
    private readonly IAnswerWriteRepository _answerWriteRepository;
    private readonly IQuestionReadRepository _questionReadRepository;
    private readonly IQuestionWriteRepository _questionWriteRepository;
    private readonly IStepQuestionReadRepository _stepQuestionReadRepository;
    private readonly IStepQuestionWriteRepository _stepQuestionWriteRepository;

    public CreateQuestionCommandHandler(
        IQuestionWriteRepository questionWriteRepository,
        IQuestionReadRepository questionReadRepository,
        IAnswerWriteRepository answerWriteRepository,
        IStepQuestionReadRepository stepQuestionReadRepository,
        IStepQuestionWriteRepository stepQuestionWriteRepository)
    {
        _questionWriteRepository = questionWriteRepository;
        _questionReadRepository = questionReadRepository;
        _answerWriteRepository = answerWriteRepository;
        _stepQuestionReadRepository = stepQuestionReadRepository;
        _stepQuestionWriteRepository = stepQuestionWriteRepository;
    }

    public async Task<BaseResponse<CreateQuestionDto>> Handle(CreateQuestionCommandRequest request,
        CancellationToken cancellationToken)
    {
        var stepQuestion = await _stepQuestionReadRepository
            .Queryable()
            .FirstOrDefaultAsync(x => x.Id == request.StepQuestion.Id, cancellationToken);

        if (stepQuestion is null)
        {
            stepQuestion = new StepQuestion
            {
                Id = request.StepQuestion.Id != Guid.Empty ? request.StepQuestion.Id : Guid.NewGuid(),
                Title = request.StepQuestion.Title,
                StepNumber = request.StepQuestion.StepNumber,
                LanguageId = request.LanguageId,
                Status = StatusType.Active
            };

            await _stepQuestionWriteRepository.CreateAsync(stepQuestion);
        }

        var createdQuestion = new Question
        {
            Description = request.Description,
            CorrectAnswer = request.CorrectAnswer,
            LanguageId = request.LanguageId,
            Level = request.Level,
            Name = request.Name,
            Score = request.Score,
            StepQuestionId = stepQuestion.Id,
            Status = StatusType.Active
        };

        await _questionWriteRepository.CreateAsync(createdQuestion);

        var exists = await _questionReadRepository
            .Queryable()
            .AnyAsync(x => x.Id == createdQuestion.Id, cancellationToken);

        if (!exists)
            throw new ArgumentNullException($"{nameof(createdQuestion)} could not be found after creation!");

        var answers = request?.Answers?.Select(answer => new Answer
        {
            QuestionId = createdQuestion.Id,
            AnswerName = answer
        }).ToList();

        if (answers != null)
        {
            await _answerWriteRepository.CreateRangeAsync(answers);

            var response = new CreateQuestionDto
            {
                Id = createdQuestion.Id,
                Description = createdQuestion.Description,
                CorrectAnswer = createdQuestion.CorrectAnswer,
                LanguageId = createdQuestion.LanguageId,
                Level = createdQuestion.Level,
                Name = createdQuestion.Name,
                Score = createdQuestion.Score,
                StepQuestionId = createdQuestion.StepQuestionId,
                Answers = answers.Select(a => a.AnswerName).ToList()
            };

            return new BaseResponse<CreateQuestionDto>(
                "Created question and answers successfully.",
                true,
                response
            );
        }

        return new BaseResponse<CreateQuestionDto>(isSuccess:false);
    }

}