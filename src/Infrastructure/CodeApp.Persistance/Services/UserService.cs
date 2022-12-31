using AutoMapper;
using CodeApp.Application.Abstractions;
using CodeApp.Application.Dtos.User;
using CodeApp.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public async Task<UserScoreDto> AddScoreToUser(UserScoreDto userScoreDto)
        {
            var user = await _userManager.FindByIdAsync(userScoreDto.UserId);

            if (user == null)
                throw new ArgumentNullException($"{userScoreDto.UserId} is not found!");

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
                throw new ArgumentNullException($"{userId} is null!");

            var score = user.Score;

            return score;
        }
    }
}
