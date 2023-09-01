using AutoMapper;
using CodeApp.Application.Dtos.Avatar;
using CodeApp.Application.Repositories;
using CodeApp.Application.Wrapper;
using CodeApp.Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

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
            var avatars = await _avatarReadRepository
                .Where(a => a.Status == StatusType.Active)
                .ToListAsync();

            var result = _mapper.Map<List<GetAllAvatarDto>>(avatars);

            return new BaseResponse<List<GetAllAvatarDto>>(result,true);
        }
    }
}
