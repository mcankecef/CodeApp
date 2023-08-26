using CodeApp.Application.Dtos;
using CodeApp.Application.Dtos.Language;
using CodeApp.Application.Wrapper;
using CodeApp.Domain.Enums;
using MediatR;

namespace CodeApp.Application.Features.LanguageCommandQuery.Commands.UpdateLanguage
{
    public class UpdateLanguageCommandRequest :IRequest<BaseResponse<NoContentDto>>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public StatusType Status { get; set; }
    }
}
