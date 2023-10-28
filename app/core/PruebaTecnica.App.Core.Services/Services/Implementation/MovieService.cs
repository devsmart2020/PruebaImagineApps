using PruebaTecnica.App.Core.Application.Services.Interfaces;
using PruebaTecnica.App.Core.Application.UiServiceInterfaces;
using PruebaTecnica.App.Core.DTOs.Common;
using PruebaTecnica.App.Core.DTOs.Transport;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaTecnica.App.Core.Application.Services.Implementation
{
    public sealed class MovieService : IMovieService
    {
        #region Fields
        private readonly IApiClient _apiClient;
        private readonly IMessageService _messageService;

        //private IMessageService _messageService = Ioc.Default.GetRequiredService<IMessageService>();
        #endregion

        #region Ctor
        public MovieService(IApiClient apiClient, IMessageService messageService)
        {
            _apiClient = apiClient;
            _messageService = messageService;
        }
        #endregion

        #region Methods
        public async Task<IEnumerable<MovieDto>> GetAllMovies()
        {
            _apiClient.BaseUrl = "https://pruebaimagineapps.azurewebsites.net/";
            ResponseDto<IEnumerable<MovieDto>> result = await _apiClient.Get<IEnumerable<MovieDto>>(RscApplication.PathMovieGetAll);
            if (result.Errors.Any())
                await _messageService.ViewMessage("Error", result.Errors.FirstOrDefault());

            if (!result.Data.Any())
                await _messageService.ViewMessage("Information", "No hay películas disponibles");


            return result.Data;
        }
        #endregion

    }
}
