using AutoMapper;
using CodeApp.Application.Dtos.Subject;
using CodeApp.Application.Repositories;
using CodeApp.Application.Wrapper;
using CodeApp.Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CodeApp.Application.Features.SubjectCommandQuery.Queries.GetAllSubject
{
    public class GetAllSubjectQueryHandler : IRequestHandler<GetAllSubjectQueryRequest, BaseResponse<List<GetAllSubjectDto>>>
    {
        private readonly ISubjectReadRepository _subjectReadRepository;
        private readonly IMapper _mapper;

        public GetAllSubjectQueryHandler(ISubjectReadRepository subjectReadRepository, IMapper mapper)
        {
            _subjectReadRepository = subjectReadRepository;
            _mapper = mapper;
        }

        public async Task<BaseResponse<List<GetAllSubjectDto>>> Handle(GetAllSubjectQueryRequest request, CancellationToken cancellationToken)
        {
            var subjects = await _subjectReadRepository
                .Queryable()
                .Include(s => s.Language)
                .Where(s => s.Status == StatusType.Active)
                .Where(s => s.LanguageId == request.LanguageId)
                .ToListAsync();

            var result = _mapper.Map<List<GetAllSubjectDto>>(subjects);

            return new BaseResponse<List<GetAllSubjectDto>>(result, true);
        }
    }
}
