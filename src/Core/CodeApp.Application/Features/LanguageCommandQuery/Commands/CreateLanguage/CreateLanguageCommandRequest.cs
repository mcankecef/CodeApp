using CodeApp.Application.Dtos.Language;
using CodeApp.Application.Wrapper;
using MediatR;

namespace CodeApp.Application.Features.LanguageCommandQuery.Commands.CreateLanguage
{
    public class CreateLanguageCommandRequest : IRequest<BaseResponse<CreateLanguageDto>>
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
