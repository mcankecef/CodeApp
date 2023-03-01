using AutoMapper;
using CodeApp.Application.Dtos.Subject;
using CodeApp.Application.Repositories;
using CodeApp.Application.Wrapper;
using MediatR;

namespace CodeApp.Application.Features.SubjectCommandQuery.Queries.GetSubjectById
{
    public class GetSubjectByIdQueryHandler : IRequestHandler<GetSubjectByIdQueryRequest, BaseResponse<GetSubjectByIdDto>>
    {
        private readonly ISubjectRepository _subjectRepository;
        private readonly IMapper _mapper;

        public GetSubjectByIdQueryHandler(ISubjectRepository subjectRepository, IMapper mapper)
        {
            _subjectRepository = subjectRepository;
            _mapper = mapper;
        }

        public async Task<BaseResponse<GetSubjectByIdDto>> Handle(GetSubjectByIdQueryRequest request, CancellationToken cancellationToken)
        {
            if(request.Id == Guid.Empty)
                throw new ArgumentNullException(nameof(request.Id));

            var subject = await _subjectRepository.GetByIdAsync(request.Id);

            var response = _mapper.Map<GetSubjectByIdDto>(subject);

            if (response == null)
                throw new ArgumentNullException(nameof(response));

            return new BaseResponse<GetSubjectByIdDto>(response,true);
        }
    }
}
