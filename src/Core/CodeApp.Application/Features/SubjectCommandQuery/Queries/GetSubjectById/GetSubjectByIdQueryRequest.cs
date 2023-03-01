using CodeApp.Application.Dtos.Subject;
using CodeApp.Application.Wrapper;
using MediatR;

namespace CodeApp.Application.Features.SubjectCommandQuery.Queries.GetSubjectById
{
    public class GetSubjectByIdQueryRequest : IRequest<BaseResponse<GetSubjectByIdDto>>
    {
        public Guid Id { get; set; }

        public GetSubjectByIdQueryRequest(Guid id)
        {
            Id = id;
        }
    }
}
