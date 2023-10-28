using PruebaTecnica.App.Core.DTOs.Transport;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PruebaTecnica.App.Core.Application.Services.Interfaces
{
    public interface IMovieService
    {
        Task<IEnumerable<MovieDto>> GetAllMovies();
    }
}
