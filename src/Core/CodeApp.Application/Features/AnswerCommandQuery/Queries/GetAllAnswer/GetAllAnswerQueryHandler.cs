using AutoMapper;
using CodeApp.Application.Dtos.Answer;
using CodeApp.Application.Repositories;
using CodeApp.Application.Wrapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CodeApp.Application.Features.AnswerCommandQuery.Queries.GetAllAnswer
{
    public class GetAllAnswerQueryHandler : IRequestHandler<GetAllAnswerQueryRequest, BaseResponse<GetAllAnswerDto>>
    {
        private readonly IAnswerRepository _answerRepository;

        public GetAllAnswerQueryHandler(IAnswerRepository answerRepository)
        {
            _answerRepository = answerRepository;
        }

        public async Task<BaseResponse<GetAllAnswerDto>> Handle(GetAllAnswerQueryRequest request, CancellationToken cancellationToken)
        {

            var answers = await _answerRepository
                .Queryable()
                .Include(x => x.Question)
                .ToListAsync();

            var dto = new GetAllAnswerDto
            {
                Answer = answers.Select(x => x.AnswerName).ToList(),
                QuestionId = answers.Select(x => x.QuestionId).FirstOrDefault(),
                QuestionName = answers.Select(x => x.Question.Name).FirstOrDefault(),
                Id = answers.Select(x => x.Id).FirstOrDefault(),
            };

            return new BaseResponse<GetAllAnswerDto>("", true, dto);
        }
    }
}
