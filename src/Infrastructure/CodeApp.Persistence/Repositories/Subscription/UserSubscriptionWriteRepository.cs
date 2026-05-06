using CodeApp.Application.Repositories.Subscription;
using CodeApp.Domain.Entities.Subscription;
using CodeApp.Persistence.Contexts;

namespace CodeApp.Persistence.Repositories.Subscription;

public class UserSubscriptionWriteRepository : WriteRepository<UserSubscription>, IUserSubscriptionWriteRepository
{
    public UserSubscriptionWriteRepository(CodeAppDbContext context) : base(context)
    {
    }
}
