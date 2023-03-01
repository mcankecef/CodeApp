using CodeApp.Application.Dtos.Subject;
using CodeApp.Application.Wrapper;
using MediatR;

namespace CodeApp.Application.Features.SubjectCommandQuery.Queries.GetAllSubject
{
    public class GetAllSubjectQueryRequest : IRequest<BaseResponse<List<GetAllSubjectDto>>>
    {

    }
}
