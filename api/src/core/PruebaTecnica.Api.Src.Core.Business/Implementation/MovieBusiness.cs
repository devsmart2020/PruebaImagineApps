using AutoMapper;
using PruebaTecnica.Api.Src.Core.Business.Interfaces;
using PruebaTecnica.Api.Src.Core.Business.Wrappers;
using PruebaTecnica.Api.Src.Core.Domain.Entities;
using PruebaTecnica.Api.Src.Core.Domain.RepositoryInterfaces;
using PruebaTecnica.Api.Src.Core.DTOs.Transport;

namespace PruebaTecnica.Api.Src.Core.Business.Implementation
{
    public sealed class MovieBusiness : IMovieBusiness
    {
        #region Fields
        private readonly IMovieRepository _movieRepository;
        private readonly IMapper _mapper;
        #endregion

        #region Ctor
        public MovieBusiness(IMovieRepository movieRepository, IMapper mapper)
        {
            _movieRepository = movieRepository;
            _mapper = mapper;
        }
        #endregion

        #region Methods
        public async Task<ResponseDto<MovieDto>> Create(MovieDto entity)
        {
            ResponseDto<MovieDto> response = new ResponseDto<MovieDto>();
            response.Errors = new List<string>();

            if (entity is null)
                return CreateResponse<MovieDto>(null, new List<string> { "Invalid Entity Data." }, false, "Error creating Movie.");

            MovieEntity movie = _mapper.Map<MovieEntity>(entity);
            MovieEntity query = await _movieRepository.CreateMovie(movie);
            if (query is null)
                return CreateResponse<MovieDto>(null, new List<string> { "Movie not saved, please retry." }, false, "Movie not saved, please retry.");

            response.Data = _mapper.Map<MovieDto>(query);
            response.Succeed = true;
            return response;
        }

        public Task<ResponseDto<bool>> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseDto<IEnumerable<MovieDto>>> GetAllByFilter(MovieDto? filter = null)
        {
            IEnumerable<MovieDto> query = _mapper.Map<IEnumerable<MovieDto>>(await _movieRepository.GetMoviesByFilter());
            return CreateResponse(query, null, true, string.Empty);
        }

        public Task<ResponseDto<MovieDto>> GetById(object id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDto<MovieDto>> Update(MovieDto entity)
        {
            throw new NotImplementedException();
        }

        private static ResponseDto<T> CreateResponse<T>(T? data, List<string>? errorMessages, bool succed, string message)
        {
            List<string> errors = new();
            ResponseDto<T> response = new()
            {
                Data = data,
                Succeed = succed,
                Errors = errorMessages is null ? errors : errorMessages,
                Message = message
            };
            return response;
        }
        #endregion

    }
}
