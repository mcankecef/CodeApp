using AutoMapper;
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
        private readonly IQuestionRepository _questionRepository;
        private readonly IAnswerRepository _answerRepository;

        public CreateQuestionCommandHandler(IQuestionRepository questionRepository, IAnswerRepository answerRepository)
        {
            _questionRepository = questionRepository;
            _answerRepository = answerRepository;
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

            await _questionRepository.CreateAsync(createdQuestion);

            var question = await _questionRepository
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

            await _answerRepository.CreateRange(answers);

            var response = new CreateQuestionDto
            {
                Description = request.Description,
                CorrectAnswer = request.CorrectAnswer,
                LanguageId = request.LanguageId,
                Level = request.Level,
                Name = request.Name,
                Score = request.Score,
                Answers = answers.Select(a=>a.AnswerName).ToList(),
            };

            return new BaseResponse<CreateQuestionDto>("Created question and answer succesfully", true, response);
        }
    }
}
