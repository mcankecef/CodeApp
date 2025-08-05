using CodeApp.Application.Repositories;
using CodeApp.Domain.Entities;
using CodeApp.Persistence.Contexts;

namespace CodeApp.Persistence.Repositories
{
    internal class AvatarWriteRepository : WriteRepository<Avatar>, IAvatarWriteRepository
    {
        public AvatarWriteRepository(CodeAppDbContext context) : base(context)
        {
        }
    }
}
