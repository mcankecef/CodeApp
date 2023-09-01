using CodeApp.Application.Dtos.Subject;
using CodeApp.Application.Wrapper;
using CodeApp.Domain.Enums;
using MediatR;

namespace CodeApp.Application.Features.SubjectCommandQuery.Commands.CreateSubject
{
    public class CreateSubjectCommandRequest : IRequest<BaseResponse<CreateSubjectDto>>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid LanguageId { get; set; }
        public StatusType Status { get; set; }
    }
}
