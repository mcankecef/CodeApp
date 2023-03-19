using AutoMapper;
using CodeApp.Application.Dtos.Avatar;
using CodeApp.Application.Repositories;
using CodeApp.Application.Wrapper;
using CodeApp.Domain.Entities;
using MediatR;

namespace CodeApp.Application.Features.AvatarCommandQuery.Commands.CreateAvatar
{
    public class CreateAvatarCommandHandler : IRequestHandler<CreateAvatarCommandRequest, BaseResponse<CreateAvatarDto>>
    {
        private readonly IAvatarWriteRepository _avatarWriteRepository;
        private readonly IMapper _mapper;

        public CreateAvatarCommandHandler(IAvatarWriteRepository avatarWriteRepository, IMapper mapper)
        {
            _avatarWriteRepository = avatarWriteRepository;
            _mapper = mapper;
        }

        public async Task<BaseResponse<CreateAvatarDto>> Handle(CreateAvatarCommandRequest request, CancellationToken cancellationToken)
        {
            var avatar = _mapper.Map<Avatar>(request);

            await _avatarWriteRepository.CreateAsync(avatar);

            var result = _mapper.Map<CreateAvatarDto>(avatar);

            return new BaseResponse<CreateAvatarDto>(result,true);
        }
    }
}
