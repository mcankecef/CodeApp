using CodeApp.Application.Repositories;
using CodeApp.Domain.Entities;
using CodeApp.Persistence.Contexts;

namespace CodeApp.Persistence.Repositories
{
    public class AvatarReadRepository : ReadRepository<Avatar>, IAvatarReadRepository
    {
        public AvatarReadRepository(CodeAppDbContext context) : base(context)
        {
        }
    }
}
