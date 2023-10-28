using Microsoft.Extensions.DependencyInjection;
using PruebaTecnica.Api.Src.Core.Domain.RepositoryInterfaces;
using PruebaTecnica.Api.Src.Infrastructure.Data.EntityFramework.Context;
using PruebaTecnica.Api.Src.Infrastructure.Data.Repositories;
using PruebaTecnica.Api.Src.Infrastructure.Data.Repositories.Base;

namespace PruebaTecnica.Api.Src.Infrastructure.Data.Dependences
{
    public static class DependencesData
    {
        public static void RegisterData(this IServiceCollection services)
        {
            services.AddDbContext<MoviesContext>();
            services.AddScoped<IBaseRepository, BaseRepository>();
            services.AddTransient<IMovieRepository, MovieRepository>();
        }
    }
}
