using CodeApp.Application.Repositories;
using CodeApp.Domain.Entities;
using CodeApp.Persistance.Contexts;

namespace CodeApp.Persistance.Repositories
{
    public class AvatarReadRepository : ReadRepository<Avatar>, IAvatarReadRepository
    {
        public AvatarReadRepository(CodeAppDbContext context) : base(context)
        {
        }
    }
}
