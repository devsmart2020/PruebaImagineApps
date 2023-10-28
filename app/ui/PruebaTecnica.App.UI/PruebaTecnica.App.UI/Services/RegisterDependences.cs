using CommunityToolkit.Mvvm.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using PruebaTecnica.App.Core.Application.Services.Implementation;
using PruebaTecnica.App.Core.Application.Services.Interfaces;
using PruebaTecnica.App.Core.Application.UiServiceInterfaces;
using PruebaTecnica.App.Core.ViewModels.Movies;
using PruebaTecnica.App.Core.ViewModels.UiInterfaces;
using PruebaTecnica.App.Infrastructure.Data.ApiClient;

namespace PruebaTecnica.App.UI.Services
{
    public static class RegisterDependences
    {

        public static void Register(this IServiceCollection services)
        {
            Ioc.Default.ConfigureServices(services
                .AddTransient<IApiClient, ApiClient>()
                .AddTransient<INavigationService, NavigationService>()
                .AddTransient<IMessageService, MessageService>()
                .AddTransient<IMovieService, MovieService>()
                .AddTransient<WebVisorViewModel>()
                .BuildServiceProvider());
        }


    }
}
