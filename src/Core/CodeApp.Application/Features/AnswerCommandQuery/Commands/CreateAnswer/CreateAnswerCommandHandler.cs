using AutoMapper;
using CodeApp.Application.Dtos.Answer;
using CodeApp.Application.Repositories;
using CodeApp.Application.Wrapper;
using CodeApp.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CodeApp.Application.Features.AnswerCommandQuery.Commands.CreateAnswer
{
    public class CreateAnswerCommandHandler : IRequestHandler<CreateAnswerCommandRequest, BaseResponse<CreateAnswerDto>>
    {
        private readonly IAnswerWriteRepository _answerWriteRepository;
        private readonly IQuestionReadRepository _questionReadRepository;

        public CreateAnswerCommandHandler(IAnswerWriteRepository answerWriteRepository, IQuestionReadRepository questionReadRepository)
        {
            _answerWriteRepository = answerWriteRepository;
            _questionReadRepository = questionReadRepository;
        }

        public async Task<BaseResponse<CreateAnswerDto>> Handle(CreateAnswerCommandRequest request, CancellationToken cancellationToken)
        {
            var question = await _questionReadRepository
                .Queryable()
                .Where(x => x.Id == request.QuestionId)
                .AnyAsync();

            if (question is false)
                throw new ArgumentNullException($"{nameof(question)} is not found!");

            var answers = new List<Answer>();

            foreach (var ans in request.AnswerName)
            {
                answers.Add(new Answer { QuestionId = request.QuestionId, AnswerName = ans });
            }

            await _answerWriteRepository.CreateRangeAsync(answers);

            var dto = new CreateAnswerDto
            {
                AnswerName = answers.Select(x => x.AnswerName).ToList(),
                QuestionId = request.QuestionId
            };

            return new BaseResponse<CreateAnswerDto>("Answer created succesfully", true, dto);
        }
    }
}
