using AutoMapper;
using CodeApp.Application.Dtos.Question;
using CodeApp.Application.Features.QuestionCommandQuery.Queries.GetByIdQuestion;
using CodeApp.Application.Repositories;
using CodeApp.Application.Wrapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CodeApp.Application.Features.QuestionCommandQuery.Queries.GetQuestionById
{
    public class GetQuestionByIdQueryHandler : IRequestHandler<GetQuestionByIdQueryRequest, BaseResponse<GetQuestionByIdDto>>
    {
        private readonly IQuestionReadRepository _questionReadRepository;
        private readonly IMapper _mapper;

        public GetQuestionByIdQueryHandler(IQuestionReadRepository questionReadRepository, IMapper mapper)
        {
            _questionReadRepository = questionReadRepository;
            _mapper = mapper;
        }

        public async Task<BaseResponse<GetQuestionByIdDto>> Handle(GetQuestionByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var question = await _questionReadRepository
                .Queryable()
                .Include(q => q.Language)
                .Include(q => q.Answers)
                .FirstOrDefaultAsync(q => q.Id == request.Id);

            if (question is null)
                throw new ArgumentNullException(nameof(question));

            var resultModel = _mapper.Map<GetQuestionByIdDto>(question);

            return new BaseResponse<GetQuestionByIdDto>(resultModel, true);
        }

    }
}
