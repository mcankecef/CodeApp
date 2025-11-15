using CodeApp.Application.Abstractions;
using CodeApp.Application.Dtos.Question;
using CodeApp.Application.Repositories;
using CodeApp.Application.Repositories.AppUserStepQuestion;
using CodeApp.Application.Repositories.StepQuestion;
using CodeApp.Application.Wrapper;
using CodeApp.Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CodeApp.Application.Features.QuestionCommandQuery.Commands.SubmitAnswers;

public class SubmitAnswersCommandHandler : IRequestHandler<SubmitAnswersCommandRequest, BaseResponse<SubmitAnswersResponseDto>>
{
    private readonly IQuestionReadRepository _questionReadRepository;
    private readonly IUserService _userService;
    private readonly IStepQuestionReadRepository _stepQuestionReadRepository;
    private readonly IAppUserStepQuestionReadRepository _appUserStepQuestionReadRepository;
    private readonly IAppUserStepQuestionWriteRepository _appUserStepQuestionWriteRepository;

    public SubmitAnswersCommandHandler(
        IQuestionReadRepository questionReadRepository,
        IStepQuestionReadRepository stepQuestionReadRepository,
        IAppUserStepQuestionReadRepository appUserStepQuestionReadRepository,
        IAppUserStepQuestionWriteRepository appUserStepQuestionWriteRepository,
        IUserService userService)
    {
        _questionReadRepository = questionReadRepository;
        _stepQuestionReadRepository = stepQuestionReadRepository;
        _appUserStepQuestionReadRepository = appUserStepQuestionReadRepository;
        _appUserStepQuestionWriteRepository = appUserStepQuestionWriteRepository;
        _userService = userService;
    }

    public async Task<BaseResponse<SubmitAnswersResponseDto>> Handle(SubmitAnswersCommandRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var userProgress = await _appUserStepQuestionReadRepository
                .Queryable()
                .Include(x => x.AppUser)
                .FirstOrDefaultAsync(x => x.AppUserId == request.AppUserId
                 && x.LanguageId == request.LanguageId, cancellationToken);
                 
            if (userProgress == null)
            {
                return new BaseResponse<SubmitAnswersResponseDto>("User progress not found.", false, new SubmitAnswersResponseDto());
            }

            var currentStep = await _stepQuestionReadRepository.Queryable()
                .FirstOrDefaultAsync(x => x.Id == request.StepQuestionId, cancellationToken);

            if (currentStep == null)
                return new BaseResponse<SubmitAnswersResponseDto>("Step not found.", false, new SubmitAnswersResponseDto());

            if (currentStep.StepNumber > userProgress?.CurrentStepNumber)
                return new BaseResponse<SubmitAnswersResponseDto>("You do not have access to this step yet.", false, new SubmitAnswersResponseDto());

            var questions = await _questionReadRepository.Queryable()
                .Where(q => q.StepQuestionId == request.StepQuestionId)
                .ToListAsync(cancellationToken);

            if (!questions.Any())
                return new BaseResponse<SubmitAnswersResponseDto>("No questions found in this step.", false, new SubmitAnswersResponseDto());

            int totalScore = 0;
            int correctAnswers = 0;
            var totalQuestions = questions.Count;

            foreach (var userAnswer in request.Answers)
            {
                var question = questions.FirstOrDefault(q => q.Id == userAnswer.QuestionId);
                if (question != null)
                {
                    if (string.Equals(question.CorrectAnswer.Trim(), userAnswer.UserAnswer.Trim(), StringComparison.OrdinalIgnoreCase))
                    {
                        correctAnswers++;
                        totalScore += question.Level switch
                        {
                            QuestionLevel.Beginner => 10,
                            QuestionLevel.Intermediate => 15,
                            QuestionLevel.Advanced => 20,
                            _ => 10
                        };
                    }
                }
            }

            bool stepCompleted = correctAnswers == totalQuestions;

            if (stepCompleted)
            {
                int newStepNumber = userProgress!.CurrentStepNumber;
                userProgress!.Score += totalScore;

                await _userService.UpdateUserScore(new Dtos.User.UserScoreDto
                {
                    UserId = userProgress.AppUserId.ToString(),
                    Score = totalScore
                });

                var nextStep = await _stepQuestionReadRepository.Queryable()
                    .Where(x => x.LanguageId == request.LanguageId && x.StepNumber == currentStep.StepNumber + 1)
                    .FirstOrDefaultAsync(cancellationToken);

                if (nextStep != null)
                {
                    newStepNumber = currentStep.StepNumber + 1;
                    userProgress.CurrentStepNumber = newStepNumber;
                    userProgress.StepQuestionId = nextStep.Id;
                }

                _appUserStepQuestionWriteRepository.Update(userProgress);

                var response = new SubmitAnswersResponseDto
                {
                    TotalScore = totalScore,
                    CorrectAnswers = correctAnswers,
                    TotalQuestions = totalQuestions,
                    StepCompleted = stepCompleted,
                    NewStepNumber = newStepNumber
                };

                return new BaseResponse<SubmitAnswersResponseDto>($"Step {currentStep.StepNumber} completed.", true, response);
            }

            return new BaseResponse<SubmitAnswersResponseDto>($"Step {currentStep.StepNumber} not completed. Try again.", false, new SubmitAnswersResponseDto
            {
                TotalScore = userProgress!.AppUser.Score,
                CorrectAnswers = correctAnswers,
                TotalQuestions = totalQuestions,
                StepCompleted = stepCompleted,
                NewStepNumber = userProgress!.CurrentStepNumber
            });

        }
        catch (Exception exception)
        {
            return new BaseResponse<SubmitAnswersResponseDto>($"An error occurred: {exception.Message}", false, new SubmitAnswersResponseDto());
        }
    }
}