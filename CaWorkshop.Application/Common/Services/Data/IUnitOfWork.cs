using CaWorkshop.Domain.Common;

namespace CaWorkshop.Application.Common.Services.Data;

public interface IUnitOfWork
{
    IRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity;
    
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}