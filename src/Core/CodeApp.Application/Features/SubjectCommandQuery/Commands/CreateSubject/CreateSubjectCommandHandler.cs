using AutoMapper;
using CodeApp.Application.Dtos.Subject;
using CodeApp.Application.Repositories;
using CodeApp.Application.Wrapper;
using CodeApp.Domain.Entities;
using MediatR;

namespace CodeApp.Application.Features.SubjectCommandQuery.Commands.CreateSubject
{
    public class CreateSubjectCommandHandler : IRequestHandler<CreateSubjectCommandRequest, BaseResponse<CreateSubjectDto>>
    {
        private readonly ISubjectWriteRepository _subjectWriteRepository;
        private readonly IMapper _mapper;

        public CreateSubjectCommandHandler(ISubjectWriteRepository subjectWriteRepository, IMapper mapper)
        {
            _subjectWriteRepository = subjectWriteRepository;
            _mapper = mapper;
        }

        public async Task<BaseResponse<CreateSubjectDto>> Handle(CreateSubjectCommandRequest request, CancellationToken cancellationToken)
        {
            var subject = _mapper.Map<Subject>(request);

            await _subjectWriteRepository.CreateAsync(subject);

            var result = _mapper.Map<CreateSubjectDto>(subject);

            return new BaseResponse<CreateSubjectDto>("Created subject succesfully", true, result);
        }
    }
}
