using AutoMapper;
using CodeApp.Application.Dtos.Avatar;
using CodeApp.Application.Repositories;
using CodeApp.Application.Wrapper;
using MediatR;

namespace CodeApp.Application.Features.AvatarCommandQuery.Queries.GetAllAvatar
{
    public class GetAllAvatarQueryHandler : IRequestHandler<GetAllAvatarQueryRequest, BaseResponse<List<GetAllAvatarDto>>>
    {
        private readonly IAvatarReadRepository _avatarReadRepository;
        private readonly IMapper _mapper;

        public GetAllAvatarQueryHandler(IAvatarReadRepository avatarReadRepository, IMapper mapper)
        {
            _avatarReadRepository = avatarReadRepository;
            _mapper = mapper;
        }

        public async Task<BaseResponse<List<GetAllAvatarDto>>> Handle(GetAllAvatarQueryRequest request, CancellationToken cancellationToken)
        {
            var avatars = await _avatarReadRepository.GetAllAsync();

            var result = _mapper.Map<List<GetAllAvatarDto>>(avatars);

            return new BaseResponse<List<GetAllAvatarDto>>(result,true);
        }
    }
}
