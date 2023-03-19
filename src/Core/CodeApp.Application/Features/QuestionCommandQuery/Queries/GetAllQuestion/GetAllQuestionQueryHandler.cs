using AutoMapper;
using CodeApp.Application.Dtos.Question;
using CodeApp.Application.Repositories;
using CodeApp.Application.Wrapper;
using CodeApp.Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace CodeApp.Application.Features.QuestionCommandQuery.Queries.GetAllQuestion
{
    public class GetAllQuestionQueryHandler : IRequestHandler<GetAllQuestionQueryRequest, BaseResponse<List<GetAllQuestionDto>>>
    {
        private readonly IQuestionReadRepository _questionReadRepository;
        private readonly IMapper _mapper;

        public GetAllQuestionQueryHandler(IQuestionReadRepository questionReadRepository, IMapper mapper)
        {
            _questionReadRepository = questionReadRepository;
            _mapper = mapper;
        }

        public async Task<BaseResponse<List<GetAllQuestionDto>>> Handle(GetAllQuestionQueryRequest request, CancellationToken cancellationToken)
        {
            var questions = await _questionReadRepository.Queryable()
                .Include(q => q.Answers).Include(q => q.Language)
                .Where(q => q.Status == StatusType.Active)
                .Where(q => q.LanguageId == request.LanguageId)
                .Where(q => (int)q.Level == request.QuestionLevel)
                .OrderBy(q => Guid.NewGuid())
                .Take(10)
                .ToListAsync();

            var dto = _mapper.Map<List<GetAllQuestionDto>>(questions);

            return new BaseResponse<List<GetAllQuestionDto>>("", true, dto);
        }
    }
}
