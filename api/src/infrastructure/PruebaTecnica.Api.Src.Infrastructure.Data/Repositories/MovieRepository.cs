using PruebaTecnica.Api.Src.Core.Domain.Entities;
using PruebaTecnica.Api.Src.Core.Domain.RepositoryInterfaces;
using PruebaTecnica.Api.Src.Infrastructure.Data.Repositories.Base;
using System.Linq.Expressions;

namespace PruebaTecnica.Api.Src.Infrastructure.Data.Repositories
{
    public sealed class MovieRepository : IMovieRepository
    {
        #region Fields
        private readonly IBaseRepository _repository;
        #endregion

        #region Ctor
        public MovieRepository(IBaseRepository repository)
        {
            _repository = repository;
        }
        #endregion

        #region Methods
        public async Task<MovieEntity> CreateMovie(MovieEntity movie)
        {
            return await _repository.Insert(movie);
        }

        public async Task<bool> DeleteMovie(Guid id)
        {
            return await _repository.DeleteId<MovieEntity>(id);
        }

        public async Task<MovieEntity> GetByIdMovie(Guid id)
        {
            return await _repository.GetByID<MovieEntity>(id);
        }

        public async Task<IEnumerable<MovieEntity>> GetMoviesByFilter(Expression<Func<MovieEntity, bool>>? filter = null,
            Func<IQueryable<MovieEntity>, IOrderedQueryable<MovieEntity>>? orderBy = null, string includeProperties = "")
        {

            return await _repository.Get(filter, orderBy, includeProperties);
        }

        public async Task<MovieEntity> UpdateMovie(MovieEntity movie)
        {

            return await _repository.Update(movie);
        }
        #endregion
    }
}
