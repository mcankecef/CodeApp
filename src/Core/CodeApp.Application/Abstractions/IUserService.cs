using CodeApp.Application.Dtos;
using CodeApp.Application.Dtos.User;

namespace CodeApp.Application.Abstractions
{
    public interface IUserService
    {
        Task<List<GetAllUserDto>> GetAllUser();
        Task<UserScoreDto> UpdateUserScore(UserScoreDto userScoreDto);
        Task<int> GetUserScore(string userId);
        Task<GetUserByIdDto> GetUserById(string userId);
        Task<NoContentDto> UpdateUser(UpdateUserDto updateUserDto);
        Task<NoContentDto> DeleteUser(string userId);
        Task<string> UpdateUserAvatar(UpdateUserAvatarDto updateUserAvatarDto);

    }
}
