using Microsoft.AspNetCore.Mvc;
using PruebaTecnica.Api.Apps.Api.Controllers.Base;
using PruebaTecnica.Api.Src.Core.Business.Interfaces;
using PruebaTecnica.Api.Src.Core.DTOs.Transport;

namespace PruebaTecnica.Api.Apps.Api.Controllers.Controllers
{
    public sealed class MoviesController : BaseApiController
    {
        private readonly IMovieBusiness _movieBusiness;

        public MoviesController(IMovieBusiness movieBusiness)
        {
            _movieBusiness = movieBusiness;
        }

        [HttpPost("CreateMovie")]
        public async Task<IActionResult> CreateMovie(MovieDto movie)
        {
            return Ok(await _movieBusiness.Create(movie));
        }

        [HttpGet("GetAllMovies")]
        public async Task<IActionResult> GetAllMovies()
        {
            return Ok(await _movieBusiness.GetAllByFilter());
        }
    }
}
