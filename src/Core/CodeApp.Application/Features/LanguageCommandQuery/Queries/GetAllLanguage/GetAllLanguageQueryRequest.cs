using CodeApp.Application.Dtos.Language;
using CodeApp.Application.Wrapper;
using MediatR;

namespace CodeApp.Application.Features.LanguageCommandQuery.Queries.GetAllLanguage
{
    public class GetAllLanguageQueryRequest : IRequest<BaseResponse<List<GetAllLanguageDto>>>
    {
    }
}
