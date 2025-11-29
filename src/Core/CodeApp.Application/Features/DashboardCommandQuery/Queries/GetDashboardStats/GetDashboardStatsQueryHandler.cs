using AutoMapper;
using CodeApp.Application.Dtos.Admin;
using CodeApp.Application.Repositories;
using CodeApp.Application.Repositories.AppUserStepQuestion;
using CodeApp.Application.Wrapper;
using CodeApp.Domain.Entities.Identity;
using CodeApp.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CodeApp.Application.Features.DashboardCommandQuery.Queries.GetDashboardStats
{
    public class GetDashboardStatsQueryHandler : IRequestHandler<GetDashboardStatsQueryRequest, BaseResponse<DashboardStatsDto>>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IQuestionReadRepository _questionReadRepository;
        private readonly ILanguageReadRepository _languageReadRepository;
        private readonly IAnswerReadRepository _answerReadRepository;
        private readonly IAppUserStepQuestionReadRepository _appUserStepQuestionReadRepository;
        private readonly IMapper _mapper;

        public GetDashboardStatsQueryHandler(
            UserManager<AppUser> userManager,
            IQuestionReadRepository questionReadRepository,
            ILanguageReadRepository languageReadRepository,
            IAnswerReadRepository answerReadRepository,
            IAppUserStepQuestionReadRepository appUserStepQuestionReadRepository,
            IMapper mapper)
        {
            _userManager = userManager;
            _questionReadRepository = questionReadRepository;
            _languageReadRepository = languageReadRepository;
            _answerReadRepository = answerReadRepository;
            _appUserStepQuestionReadRepository = appUserStepQuestionReadRepository;
            _mapper = mapper;
        }

        public async Task<BaseResponse<DashboardStatsDto>> Handle(GetDashboardStatsQueryRequest request, CancellationToken cancellationToken)
        {
            var dashboardStats = new DashboardStatsDto();

            dashboardStats.TotalUsers = await _userManager.Users.CountAsync(cancellationToken);

            var sevenDaysAgo = DateTime.Now.AddDays(-7);
            dashboardStats.ActiveUsers = await _userManager.Users
                .Include(u => u.Streak)
                .Where(u => u.Streak != null && u.Streak.LastActivityDate >= sevenDaysAgo)
                .CountAsync(cancellationToken);

            var questions = await _questionReadRepository.GetAllAsync();
            dashboardStats.TotalQuestions = questions.Count;

            dashboardStats.PendingQuestions = questions.Count(q => q.Status == StatusType.Passive);

            var languages = await _languageReadRepository.GetAllAsync();
            dashboardStats.TotalLanguages = languages.Count;

            var answers = await _answerReadRepository.GetAllAsync();
            dashboardStats.TotalAnswers = answers.Count;

            var today = DateTime.Now.Date;
            var tomorrow = today.AddDays(1);
            
            dashboardStats.DailyStats = new DailyStatsDto
            {
                NewUsersToday = await _userManager.Users
                    .Where(u => u.CreatedDate >= today && u.CreatedDate < tomorrow)
                    .CountAsync(cancellationToken),
                ActiveUsersToday = await _userManager.Users
                    .Include(u => u.Streak)
                    .CountAsync(u => u.Streak != null && u.Streak.LastActivityDate != null && 
                               u.Streak.LastActivityDate.Value.Date == today, cancellationToken),
                Date = today
            };

            dashboardStats.LanguageStats = new List<LanguageStatsDto>();
            foreach (var language in languages.Take(5))
            {
                var languageQuestions = questions.Where(q => q.LanguageId == language.Id);
                var userStepQuestions = await _appUserStepQuestionReadRepository.GetAllAsync();
                var languageUserStepQuestions = userStepQuestions.Where(usq => usq.LanguageId == language.Id);

                dashboardStats.LanguageStats.Add(new LanguageStatsDto
                {
                    Id = language.Id,
                    Name = language.Name,
                    QuestionCount = languageQuestions.Count(),
                    UserCount = languageUserStepQuestions.Select(usq => usq.AppUserId).Distinct().Count(),
                    CompletedQuestions = languageUserStepQuestions.Count(),
                    AverageScore = languageUserStepQuestions.Any() ? languageUserStepQuestions.Average(usq => usq.Score) : 0
                });
            }

            var recentUsers = await _userManager.Users
                .Include(u => u.Streak)
                .OrderByDescending(u => u.Streak != null ? u.Streak.LastActivityDate : DateTime.MinValue)
                .Take(10)
                .ToListAsync(cancellationToken);

            dashboardStats.RecentUserActivities = recentUsers.Select(u => new UserActivityDto
            {
                UserId = u.Id,
                FullName = u.FullName,
                Email = u.Email ?? "",
                ActivityType = "Login",
                ActivityDescription = "User logged in",
                ActivityDate = u.Streak?.LastActivityDate ?? DateTime.MinValue,
                Score = u.Score
            }).ToList();

            return new BaseResponse<DashboardStatsDto>("Dashboard stats retrieved successfully", true, dashboardStats);
        }
    }
}