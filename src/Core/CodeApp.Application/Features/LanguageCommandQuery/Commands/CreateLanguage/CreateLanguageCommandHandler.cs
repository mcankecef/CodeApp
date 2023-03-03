using AutoMapper;
using CodeApp.Application.Dtos.Language;
using CodeApp.Application.Repositories;
using CodeApp.Application.Wrapper;
using CodeApp.Domain.Entities;
using MediatR;

namespace CodeApp.Application.Features.LanguageCommandQuery.Commands.CreateLanguage
{
    public class CreateLanguageCommandHandler : IRequestHandler<CreateLanguageCommandRequest, BaseResponse<CreateLanguageDto>>
    {
        private readonly ILanguageWriteRepository _languageWriteRepository;
        private readonly IMapper _mapper;

        public CreateLanguageCommandHandler(ILanguageWriteRepository languageWriteRepository, IMapper mapper)
        {
            _languageWriteRepository = languageWriteRepository;
            _mapper = mapper;
        }
        public async Task<BaseResponse<CreateLanguageDto>> Handle(CreateLanguageCommandRequest request, CancellationToken cancellationToken)
        {
            var createdLanguage = _mapper.Map<Language>(request);

            await _languageWriteRepository.CreateAsync(createdLanguage);

            var dto = _mapper.Map<CreateLanguageDto>(createdLanguage);

            return new BaseResponse<CreateLanguageDto>("Created language succesfully", true, dto);
        }
    }
}
