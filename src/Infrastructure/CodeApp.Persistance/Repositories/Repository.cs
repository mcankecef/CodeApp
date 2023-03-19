using CodeApp.Application.Repositories;
using CodeApp.Persistance.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CodeApp.Persistance.Repositories
{
    public class Repository<T> : IRepository<T> where T : class, new()
    {
        
    }
}
