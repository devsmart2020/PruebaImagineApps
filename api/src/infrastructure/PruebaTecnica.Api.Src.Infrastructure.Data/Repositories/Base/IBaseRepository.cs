using System.Linq.Expressions;

namespace PruebaTecnica.Api.Src.Infrastructure.Data.Repositories.Base;

public interface IBaseRepository
{
    Task<IEnumerable<TEntity>> Get<TEntity>(Expression<Func<TEntity, bool>> filter = null!, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null!, string includeProperties = "") where TEntity : class;
    Task<TEntity> GetByID<TEntity>(object id) where TEntity : class;
    Task<TEntity> Insert<TEntity>(TEntity entity) where TEntity : class;
    Task<bool> DeleteId<TEntity>(object id) where TEntity : class;
    Task<bool> Delete<TEntity>(TEntity entityToDelete) where TEntity : class;
    Task<TEntity> Update<TEntity>(TEntity entityToUpdate) where TEntity : class;
    Task<int> Save();
}

