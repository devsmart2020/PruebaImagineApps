using PruebaTecnica.Api.Src.Core.Domain.Entities;
using System.Linq.Expressions;

namespace PruebaTecnica.Api.Src.Core.Domain.RepositoryInterfaces
{
    public interface IMovieRepository
    {
        Task<MovieEntity> CreateMovie(MovieEntity movie);
        Task<MovieEntity> UpdateMovie(MovieEntity movie);
        Task<MovieEntity> GetByIdMovie(Guid id);
        Task<IEnumerable<MovieEntity>> GetMoviesByFilter(Expression<Func<MovieEntity, bool>> filter = null!,
                                                         Func<IQueryable<MovieEntity>, IOrderedQueryable<MovieEntity>> orderBy = null!, string includeProperties = "");
        Task<bool> DeleteMovie(Guid id);

    }
}
