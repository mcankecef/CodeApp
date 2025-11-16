using CodeApp.Application.Repositories.UserStreak;
using CodeApp.Persistence.Contexts;

namespace CodeApp.Persistence.Repositories.UserStreak
{
    public class UserStreakWriteRepository : WriteRepository<Domain.Entities.UserStreak>, IUserStreakWriteRepository
    {
        public UserStreakWriteRepository(CodeAppDbContext context) : base(context)
        {
        }
    }
}