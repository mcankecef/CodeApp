using CodeApp.Application.Dtos;
using CodeApp.Application.Wrapper;
using MediatR;

namespace CodeApp.Application.Features.SubjectCommandQuery.Commands.DeleteSubject
{
    public class DeleteSubjectCommandRequest : IRequest<BaseResponse<NoContentDto>>
    {
        public Guid Id { get; set; }

        public DeleteSubjectCommandRequest(Guid id)
        {
            Id = id;
        }
    }
}
