using CodeApp.Application.Repositories.Subscription;
using CodeApp.Domain.Entities.Subscription;
using CodeApp.Persistence.Contexts;

namespace CodeApp.Persistence.Repositories.Subscription;

public class UserSubscriptionReadRepository : ReadRepository<UserSubscription>, IUserSubscriptionReadRepository
{
    public UserSubscriptionReadRepository(CodeAppDbContext context) : base(context)
    {
    }
}
