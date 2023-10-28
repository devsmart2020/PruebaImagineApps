using Microsoft.Extensions.DependencyInjection;
using PruebaTecnica.Api.Src.Core.Business.Implementation;
using PruebaTecnica.Api.Src.Core.Business.Interfaces;
using System.Reflection;

namespace PruebaTecnica.Api.Src.Core.Business.Dependences
{
    public static class DependencesBusiness
    {
        public static void RegisterBusiness(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddTransient<IMovieBusiness, MovieBusiness>();
        }
    }
}
