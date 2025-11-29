using AutoMapper;
using CodeApp.Application.Dtos.Admin;
using CodeApp.Application.Repositories.AppUserStepQuestion;
using CodeApp.Application.Wrapper;
using CodeApp.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CodeApp.Application.Features.UserCommandQuery.Queries.GetAllUsers
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQueryRequest, BaseResponse<List<AdminUserDto>>>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IAppUserStepQuestionReadRepository _appUserStepQuestionReadRepository;
        private readonly IMapper _mapper;

        public GetAllUsersQueryHandler(
            UserManager<AppUser> userManager,
            IAppUserStepQuestionReadRepository appUserStepQuestionReadRepository,
            IMapper mapper)
        {
            _userManager = userManager;
            _appUserStepQuestionReadRepository = appUserStepQuestionReadRepository;
            _mapper = mapper;
        }

        public async Task<BaseResponse<List<AdminUserDto>>> Handle(GetAllUsersQueryRequest request, CancellationToken cancellationToken)
        {
            var query = _userManager.Users
                .Include(u => u.Streak)
                .Include(u => u.Avatar)
                .AsQueryable();

            if (!string.IsNullOrEmpty(request.SearchTerm))
            {
                query = query.Where(u => u.FullName.Contains(request.SearchTerm) || 
                                       u.Email!.Contains(request.SearchTerm) ||
                                       u.UserName!.Contains(request.SearchTerm));
            }

            if (request.IsActive.HasValue)
            {
                query = query.Where(u => u.IsActive == request.IsActive.Value);
            }

            var totalUsers = await query.CountAsync(cancellationToken);
            var users = await query
                .Skip((request.Page - 1) * request.Size)
                .Take(request.Size)
                .ToListAsync(cancellationToken);

            var adminUserDtos = new List<AdminUserDto>();

            foreach (var user in users)
            {
                var roles = await _userManager.GetRolesAsync(user);
                
                var userStepQuestions = await _appUserStepQuestionReadRepository.GetAllAsync();
                var completedQuestions = userStepQuestions.Count(usq => usq.AppUserId == user.Id);

                var adminUserDto = new AdminUserDto
                {
                    Id = user.Id,
                    FullName = user.FullName,
                    Email = user.Email ?? "",
                    PhoneNumber = user.PhoneNumber,
                    TotalScore = user.Score,
                    CreatedDate = user.CreatedDate,
                    LastLoginDate = user.Streak?.LastActivityDate,
                    IsActive = user.IsActive,
                    Roles = roles.ToList(),
                    CompletedQuestions = completedQuestions,
                    AvatarName = user.Avatar?.ImageUrl,
                    Streak = user.Streak != null ? new UserStreakInfoDto
                    {
                        CurrentStreak = user.Streak.CurrentStreak,
                        LongestStreak = user.Streak.LongestStreak,
                        LastActivityDate = user.Streak.LastActivityDate,
                        StreakStartDate = user.Streak.StreakStartDate
                    } : null
                };

                adminUserDtos.Add(adminUserDto);
            }

            return new BaseResponse<List<AdminUserDto>>(
                $"Retrieved {adminUserDtos.Count} users successfully", 
                true, 
                adminUserDtos);
        }
    }
}