using CodeApp.Application.Dtos;
using CodeApp.Application.Repositories;
using CodeApp.Application.Wrapper;
using MediatR;

namespace CodeApp.Application.Features.LanguageCommandQuery.Commands.DeleteLanguage
{
    public class DeleteLanguageCommandHandler : IRequestHandler<DeleteLanguageCommandRequest, BaseResponse<NoContentDto>>
    {
        private readonly ILanguageWriteRepository _languageWriteRepository;
        private readonly ILanguageReadRepository _languageReadRepository;

        public DeleteLanguageCommandHandler(ILanguageWriteRepository languageWriteRepository, ILanguageReadRepository languageReadRepository)
        {
            _languageWriteRepository = languageWriteRepository;
            _languageReadRepository = languageReadRepository;
        }

        public async Task<BaseResponse<NoContentDto>> Handle(DeleteLanguageCommandRequest request, CancellationToken cancellationToken)
        {
            var deletedLanguage = await _languageReadRepository.GetByIdAsync(request.Id);

            if (deletedLanguage is null)
                throw new ArgumentNullException($"{nameof(deletedLanguage)} is not found");

            _languageWriteRepository.Remove(deletedLanguage);

            return new BaseResponse<NoContentDto>("Deleted language succesfully", true);
        }
    }
}
