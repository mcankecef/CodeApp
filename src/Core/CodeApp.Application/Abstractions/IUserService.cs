using CodeApp.Application.Dtos.User;
using CodeApp.Domain.Entities.Identity;

namespace CodeApp.Application.Abstractions
{
    public interface IUserService
    {
        Task<List<GetAllUserDto>> GetAllUser();
        Task<UserScoreDto> AddScoreToUser(UserScoreDto userScoreDto);
        Task<int> GetUserScore(string userId);
    }
}
