using CodeApp.Application.Dtos;
using CodeApp.Application.Repositories;
using CodeApp.Application.Wrapper;
using CodeApp.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeApp.Application.Features.SubjectCommandQuery.Commands.DeleteSubject
{
    public class DeleteSubjectCommandHandler : IRequestHandler<DeleteSubjectCommandRequest, BaseResponse<NoContentDto>>
    {
        private readonly ISubjectReadRepository _subjectReadRepository;
        private readonly ISubjectWriteRepository _subjectWriteRepository;

        public DeleteSubjectCommandHandler(ISubjectReadRepository subjectReadRepository, ISubjectWriteRepository subjectWriteRepository)
        {
            _subjectReadRepository = subjectReadRepository;
            _subjectWriteRepository = subjectWriteRepository;
        }

        public async Task<BaseResponse<NoContentDto>> Handle(DeleteSubjectCommandRequest request, CancellationToken cancellationToken)
        {
            var subject = await _subjectReadRepository.GetByIdAsync(request.Id);

            if (subject == null)
                throw new ArgumentNullException("Subject not found!");

            subject.Status = StatusType.Deleted;

            _subjectWriteRepository.Update(subject);

            return new BaseResponse<NoContentDto>("Deleted subject succesfully",true);
        }
    }
}
