using AutoMapper;
using CodeApp.Application.Dtos;
using CodeApp.Application.Dtos.Language;
using CodeApp.Application.Repositories;
using CodeApp.Application.Wrapper;
using CodeApp.Domain.Entities;
using MediatR;

namespace CodeApp.Application.Features.LanguageCommandQuery.Commands.UpdateLanguage
{
    public class UpdateLanguageCommandHandler : IRequestHandler<UpdateLanguageCommandRequest, BaseResponse<NoContentDto>>
    {
        private readonly ILanguageRepository _languageRepository;
        private readonly IMapper _mapper;

        public UpdateLanguageCommandHandler(ILanguageRepository languageRepository, IMapper mapper)
        {
            _languageRepository = languageRepository;
            _mapper = mapper;
        }

        public async Task<BaseResponse<NoContentDto>> Handle(UpdateLanguageCommandRequest request, CancellationToken cancellationToken)
        {
            var language = _mapper.Map<Language>(request);           

            await _languageRepository.UpdateAsync(language);

            return new BaseResponse<NoContentDto>("Updated language succesfully", true);

        }
    }
}
