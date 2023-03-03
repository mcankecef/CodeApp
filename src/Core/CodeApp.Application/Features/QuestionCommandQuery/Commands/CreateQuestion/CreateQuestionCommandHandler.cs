using CodeApp.Application.Dtos.Question;
using CodeApp.Application.Repositories;
using CodeApp.Application.Wrapper;
using CodeApp.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CodeApp.Application.Features.QuestionCommandQuery.Commands.CreateQuestion
{
    public class CreateQuestionCommandHandler : IRequestHandler<CreateQuestionCommandRequest, BaseResponse<CreateQuestionDto>>
    {
        private readonly IQuestionWriteRepository _questionWriteRepository;
        private readonly IQuestionReadRepository _questionReadRepository;
        private readonly IAnswerWriteRepository _answerWriteRepository;

        public CreateQuestionCommandHandler(IQuestionWriteRepository questionWriteRepository, IQuestionReadRepository questionReadRepository, IAnswerWriteRepository answerWriteRepository)
        {
            _questionWriteRepository = questionWriteRepository;
            _questionReadRepository = questionReadRepository;
            _answerWriteRepository = answerWriteRepository;
        }

        public async Task<BaseResponse<CreateQuestionDto>> Handle(CreateQuestionCommandRequest request, CancellationToken cancellationToken)
        {

            var createdQuestion = new Question
            {
                Description = request.Description,
                CorrectAnswer = request.CorrectAnswer,
                LanguageId = request.LanguageId,
                Level = request.Level,
                Name = request.Name,
                Score = request.Score,
            };

            await _questionWriteRepository.CreateAsync(createdQuestion);

            var question = await _questionReadRepository
                .Queryable()
                .Where(x => x.Id == createdQuestion.Id)
                .AnyAsync();

            if (question is false)
                throw new ArgumentNullException($"{nameof(question)} is not found!");

            var answers = new List<Answer>();

            foreach (var answer in request.Answers)
            {
                answers.Add(new Answer { QuestionId = createdQuestion.Id, AnswerName = answer });
            }

            await _answerWriteRepository.CreateRangeAsync(answers);

            var response = new CreateQuestionDto
            {
                Description = request.Description,
                CorrectAnswer = request.CorrectAnswer,
                LanguageId = request.LanguageId,
                Level = request.Level,
                Name = request.Name,
                Score = request.Score,
                Answers = answers.Select(a => a.AnswerName).ToList(),
            };

            return new BaseResponse<CreateQuestionDto>("Created question and answer succesfully", true, response);
        }
    }
}
