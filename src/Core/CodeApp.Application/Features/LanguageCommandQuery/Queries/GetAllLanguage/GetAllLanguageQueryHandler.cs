using AutoMapper;
using CodeApp.Application.Dtos.Language;
using CodeApp.Application.Repositories;
using CodeApp.Application.Wrapper;
using CodeApp.Domain.Enums;
using MediatR;

namespace CodeApp.Application.Features.LanguageCommandQuery.Queries.GetAllLanguage
{
    public class GetAllLanguageQueryHandler : IRequestHandler<GetAllLanguageQueryRequest, BaseResponse<List<GetAllLanguageDto>>>
    {
        private readonly ILanguageReadRepository _languageReadRepository;
        private readonly IMapper _mapper;

        public GetAllLanguageQueryHandler(ILanguageReadRepository languageReadRepository, IMapper mapper)
        {
            _languageReadRepository = languageReadRepository;
            _mapper = mapper;
        }

        public async Task<BaseResponse<List<GetAllLanguageDto>>> Handle(GetAllLanguageQueryRequest request, CancellationToken cancellationToken)
        {
            var languages = await _languageReadRepository.GetAllByStatusAsync(StatusType.Active);

            var dto = _mapper.Map<List<GetAllLanguageDto>>(languages);

            return new BaseResponse<List<GetAllLanguageDto>>("", true, dto);
        }
    }
}
