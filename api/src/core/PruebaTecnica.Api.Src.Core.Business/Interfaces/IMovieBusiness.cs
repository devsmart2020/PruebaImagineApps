using PruebaTecnica.Api.Src.Core.Business.Wrappers;
using PruebaTecnica.Api.Src.Core.DTOs.Transport;

namespace PruebaTecnica.Api.Src.Core.Business.Interfaces
{
    public interface IMovieBusiness
    {
        Task<ResponseDto<IEnumerable<MovieDto>>> GetAllByFilter(MovieDto? filter = null);
        Task<ResponseDto<MovieDto>> GetById(object id);
        Task<ResponseDto<MovieDto>> Create(MovieDto entity);
        Task<ResponseDto<MovieDto>> Update(MovieDto entity);
        Task<ResponseDto<bool>> Delete(Guid id);
    }
}
