using CodeApp.Application.Dtos.Answer;
using CodeApp.Application.Repositories;
using CodeApp.Application.Wrapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CodeApp.Application.Features.AnswerCommandQuery.Queries.GetAllAnswer
{
    public class GetAllAnswerQueryHandler : IRequestHandler<GetAllAnswerQueryRequest, BaseResponse<GetAllAnswerDto>>
    {
        private readonly IAnswerReadRepository _answerReadRepository;

        public GetAllAnswerQueryHandler(IAnswerReadRepository answerReadRepository)
        {
            _answerReadRepository = answerReadRepository;
        }

        public async Task<BaseResponse<GetAllAnswerDto>> Handle(GetAllAnswerQueryRequest request, CancellationToken cancellationToken)
        {
            var answers = await _answerReadRepository
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
