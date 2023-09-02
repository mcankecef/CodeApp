using AutoMapper;
using CodeApp.Application.Abstractions;
using CodeApp.Application.Dtos;
using CodeApp.Application.Dtos.User;
using CodeApp.Application.Exceptions;
using CodeApp.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CodeApp.Persistance.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        public UserService(UserManager<AppUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<UserScoreDto> UpdateUserScore(UserScoreDto userScoreDto)
        {
            var user = await _userManager.FindByIdAsync(userScoreDto.UserId);

            if (user == null)
                throw new ArgumentNullException($"User is not found!");

            user.Score += userScoreDto.Score;

            await _userManager.UpdateAsync(user);

            var response = _mapper.Map<UserScoreDto>(user);

            return response;
        }

        public async Task<List<GetAllUserDto>> GetAllUser()
        {
            var users = await _userManager.Users.ToListAsync();

            var dto = _mapper.Map<List<GetAllUserDto>>(users);

            return dto;
        }

        public async Task<int> GetUserScore(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user is null)
                throw new ArgumentNullException($"User is not found");

            var score = user.Score;

            return score;
        }

        public async Task<GetUserByIdDto> GetUserById(string userId)
        {
            var user = await _userManager.Users
                .Include(u => u.Avatar)
                .FirstOrDefaultAsync(u => u.Id == userId);

            if (user is null)
                throw new ArgumentNullException($"User is not found");

            var response = _mapper.Map<GetUserByIdDto>(user);
            response.ImageUrl = user.Avatar?.ImageUrl;

            return response;
        }

        public async Task<NoContentDto> UpdateUser(UpdateUserDto updateUserDto)
        {

            var user = await _userManager.FindByIdAsync(updateUserDto.UserId);

            var email = await _userManager.FindByEmailAsync(updateUserDto.Email);

            if (user is null)
                throw new ArgumentNullException($"User is not found");

            else if (email != null)
                if (email.Email != user.Email) throw new ArgumentException("Email already exists");

            user.Email = updateUserDto.Email ?? user.Email;
            user.FullName = updateUserDto.FullName ?? user.FullName;
            user.AvatarId = updateUserDto.AvatarId ?? user.AvatarId;
            user.UserName = updateUserDto.UserName ?? user.UserName;

                await _userManager.UpdateAsync(user);

            return new NoContentDto();
        }

        public async Task<NoContentDto> DeleteUser(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user is null)
                throw new ArgumentNullException($"User is not found");

            await _userManager.DeleteAsync(user);

            return new NoContentDto();
        }

        public async Task<string> UpdateUserAvatar(UpdateUserAvatarDto updateUserAvatarDto)
        {
            var user = await _userManager.Users
                .FirstOrDefaultAsync(u => u.Id == updateUserAvatarDto.UserId);

            if (user is null)
                throw new ArgumentNullException($"User is not found");

            user.AvatarId = updateUserAvatarDto.AvatarId;

            await _userManager.UpdateAsync(user);

            var imageUrl = await _userManager.Users
                .Include(u => u.Avatar)
                .Where(u => u.Id == updateUserAvatarDto.UserId)
                .Select(u => u.Avatar.ImageUrl)
                .FirstOrDefaultAsync();

            return imageUrl;
        }

        public async Task UpdateRefreshToken(AppUser user, string refreshToken, DateTime refreshTokenLifeTime)
        {

            if (user != null)
            {
                user.RefreshToken = refreshToken;
                user.RefreshTokenEndDate = refreshTokenLifeTime;

                await _userManager.UpdateAsync(user);
            }
            else
                throw new UserNotFoundException("User is not found!");
        }
    }
}
