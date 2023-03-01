using CodeApp.Application.Dtos.Subject;
using CodeApp.Application.Wrapper;
using MediatR;

namespace CodeApp.Application.Features.SubjectCommandQuery.Commands.CreateSubject
{
    public class CreateSubjectCommandRequest : IRequest<BaseResponse<CreateSubjectDto>>
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
