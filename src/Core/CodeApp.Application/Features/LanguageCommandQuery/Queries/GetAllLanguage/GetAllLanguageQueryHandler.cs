using AutoMapper;
using CodeApp.Application.Dtos.Language;
using CodeApp.Application.Repositories;
using CodeApp.Application.Wrapper;
using MediatR;

namespace CodeApp.Application.Features.LanguageCommandQuery.Queries.GetAllLanguage
{
    public class GetAllLanguageQueryHandler : IRequestHandler<GetAllLanguageQueryRequest, BaseResponse<List<GetAllLanguageDto>>>
    {
        private readonly ILanguageRepository _languageRepository;
        private readonly IMapper _mapper;
        public GetAllLanguageQueryHandler(ILanguageRepository languageRepository, IMapper mapper)
        {
            _languageRepository = languageRepository;
            _mapper = mapper;
        }

        public async Task<BaseResponse<List<GetAllLanguageDto>>> Handle(GetAllLanguageQueryRequest request, CancellationToken cancellationToken)
        {
            var languages = await _languageRepository.GetAllAsync();
            
            var dto = _mapper.Map<List<GetAllLanguageDto>>(languages);

            return new BaseResponse<List<GetAllLanguageDto>>("",true,dto);
        }
    }
}
