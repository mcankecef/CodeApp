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
        private readonly ILanguageWriteRepository _languageWriteRepository;
        private readonly IMapper _mapper;

        public UpdateLanguageCommandHandler(ILanguageWriteRepository languageWriteRepository, IMapper mapper)
        {
            _languageWriteRepository = languageWriteRepository;
            _mapper = mapper;
        }

        public async Task<BaseResponse<NoContentDto>> Handle(UpdateLanguageCommandRequest request, CancellationToken cancellationToken)
        {
            var language = _mapper.Map<Language>(request);

            _languageWriteRepository.Update(language);

            return new BaseResponse<NoContentDto>("Updated language succesfully", true);

        }
    }
}
