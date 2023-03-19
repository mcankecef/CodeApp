using CodeApp.Application.Repositories;
using CodeApp.Domain.Entities;
using CodeApp.Persistance.Contexts;

namespace CodeApp.Persistance.Repositories
{
    internal class AvatarWriteRepository : WriteRepository<Avatar>, IAvatarWriteRepository
    {
        public AvatarWriteRepository(CodeAppDbContext context) : base(context)
        {
        }
    }
}
