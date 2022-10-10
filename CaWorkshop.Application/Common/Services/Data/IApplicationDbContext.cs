using CaWorkshop.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CaWorkshop.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    public DbSet<TodoList> TodoLists { get; }
    
    public DbSet<TodoItem> TodoItems { get; }
    
    // Alternative to defining all sets here
    // DbSet<TEntity> Set<TEntity>() where TEntity : class;

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
