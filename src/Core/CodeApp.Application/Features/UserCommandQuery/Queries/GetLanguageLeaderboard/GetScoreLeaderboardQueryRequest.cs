using CodeApp.Application.Dtos.User;
using CodeApp.Application.Wrapper;
using MediatR;

namespace CodeApp.Application.Features.UserCommandQuery.Queries.GetLanguageLeaderboard
{
    public class GetScoreLeaderboardQueryRequest : IRequest<BaseResponse<ScoreLeaderboardResponseDto>>
    {
        public Guid LanguageId { get; set; }
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 5;
        public string CurrentUserId { get; set; }

        public GetScoreLeaderboardQueryRequest(Guid languageId, int page, int pageSize, string currentUserId)
        {
            LanguageId = languageId;
            Page = page;
            PageSize = Math.Min(pageSize, 50);
            CurrentUserId = currentUserId;
        }
    }
}