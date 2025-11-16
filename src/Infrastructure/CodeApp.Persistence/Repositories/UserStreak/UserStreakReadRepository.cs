using CodeApp.Application.Repositories.UserStreak;
using CodeApp.Persistence.Contexts;

namespace CodeApp.Persistence.Repositories.UserStreak
{
    public class UserStreakReadRepository : ReadRepository<Domain.Entities.UserStreak>, IUserStreakReadRepository
    {
        public UserStreakReadRepository(CodeAppDbContext context) : base(context)
        {
        }
    }
}