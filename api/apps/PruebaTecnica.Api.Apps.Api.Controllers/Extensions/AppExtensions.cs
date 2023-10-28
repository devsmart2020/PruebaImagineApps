using Microsoft.AspNetCore.Builder;
using PruebaTecnica.Api.Apps.Api.Controllers.Middleware;

namespace PruebaTecnica.Api.Apps.Api.Controllers.Extensions
{
    public static class AppExtensions
    {
        public static void UserErrorHandlingMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ErrorHandlerMiddleware>();
        }
    }
}
