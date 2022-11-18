using CodeApp.Application.Dtos;
using CodeApp.Application.Repositories;
using CodeApp.Application.Wrapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeApp.Application.Features.LanguageCommandQuery.Commands.DeleteLanguage
{
    public class DeleteLanguageCommandHandler : IRequestHandler<DeleteLanguageCommandRequest, BaseResponse<NoContentDto>>
    {
        private readonly ILanguageRepository _languageRepository;

        public DeleteLanguageCommandHandler(ILanguageRepository languageRepository)
        {
            _languageRepository = languageRepository;
        }

        public async Task<BaseResponse<NoContentDto>> Handle(DeleteLanguageCommandRequest request, CancellationToken cancellationToken)
        {
            var deletedLanguage = await _languageRepository.GetByIdAsync(request.Id);

            if (deletedLanguage is null)
                throw new ArgumentNullException($"{nameof(deletedLanguage)} is not found");

            await _languageRepository.RemoveAsync(deletedLanguage);

            return new BaseResponse<NoContentDto>("Deleted language succesfully", true);
        }
    }
}
