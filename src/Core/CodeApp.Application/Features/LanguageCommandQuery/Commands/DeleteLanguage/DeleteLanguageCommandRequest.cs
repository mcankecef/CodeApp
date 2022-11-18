using CodeApp.Application.Dtos;
using CodeApp.Application.Wrapper;
using MediatR;

namespace CodeApp.Application.Features.LanguageCommandQuery.Commands.DeleteLanguage
{
    public class DeleteLanguageCommandRequest : IRequest<BaseResponse<NoContentDto>>
    {
        public Guid Id { get; set; }

        public DeleteLanguageCommandRequest(Guid id)
        {
            Id = id;
        }
    }
}
