using Microsoft.EntityFrameworkCore;
using PruebaTecnica.Api.Src.Infrastructure.Data.EntityFramework.Context;
using System.Linq.Expressions;

namespace PruebaTecnica.Api.Src.Infrastructure.Data.Repositories.Base
{
    public sealed class BaseRepository : IBaseRepository
    {
        private readonly MoviesContext _context;

        public BaseRepository(MoviesContext context)
        {
            _context = context;
        }

        #region Methods
        public async Task<bool> DeleteId<TEntity>(object id) where TEntity : class
        {
            DbSet<TEntity> _dbSet = _context.Set<TEntity>();
            TEntity entityToDelete = await _dbSet.FindAsync(id) ?? throw new Exception("Registro no encontrado");
            return await Delete(entityToDelete);
        }

        public async Task<bool> Delete<TEntity>(TEntity entityToDelete) where TEntity : class
        {
            DbSet<TEntity> _dbSet = _context.Set<TEntity>();
            if (_context.Entry(entityToDelete).State == EntityState.Detached)
            {
                _dbSet.Attach(entityToDelete);
            }
            _dbSet.Remove(entityToDelete);
            return await Save() > 0;
        }

        public async Task<IEnumerable<TEntity>> Get<TEntity>(Expression<Func<TEntity, bool>> filter = null!, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null!, string includeProperties = "") where TEntity : class
        {
            DbSet<TEntity> _dbSet = _context.Set<TEntity>();

            IQueryable<TEntity> query = _dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return await orderBy(query).ToListAsync();
            }
            else
            {
                return await query.AsNoTracking().ToListAsync();
            }
        }

        public async Task<TEntity> GetByID<TEntity>(object id) where TEntity : class
        {
            DbSet<TEntity> _dbSet = _context.Set<TEntity>();
            return await _dbSet.FindAsync(id) ?? throw new Exception("null in context");
        }

        public async Task<TEntity> Insert<TEntity>(TEntity entity) where TEntity : class
        {
            DbSet<TEntity> _dbSet = _context.Set<TEntity>();
            await _dbSet.AddAsync(entity);
            await Save();
            return entity;
        }

        public async Task<int> Save()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task<TEntity> Update<TEntity>(TEntity entityToUpdate) where TEntity : class
        {
            DbSet<TEntity> _dbSet = _context.Set<TEntity>();
            _dbSet.Attach(entityToUpdate);
            _context.Entry(entityToUpdate).State = EntityState.Modified;
            await Save();
            return entityToUpdate;
        }
        #endregion

    }
}
