using CodeApp.Application.Dtos.Subject;
using CodeApp.Application.Wrapper;
using MediatR;

namespace CodeApp.Application.Features.SubjectCommandQuery.Queries.GetAllSubject
{
    public class GetAllSubjectQueryRequest : IRequest<BaseResponse<List<GetAllSubjectDto>>>
    {
        public Guid LanguageId { get; set; }

        public GetAllSubjectQueryRequest(Guid languageId)
        {
            LanguageId = languageId;
        }
    }
}
