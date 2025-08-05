using CodeApp.Application.Repositories;
using CodeApp.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CodeApp.Persistence.Repositories
{
    public class Repository<T> : IRepository<T> where T : class, new()
    {
        
    }
}
