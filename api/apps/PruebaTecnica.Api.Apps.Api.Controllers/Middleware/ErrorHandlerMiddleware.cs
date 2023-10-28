using Microsoft.AspNetCore.Http;
using PruebaTecnica.Api.Src.Core.Business.Wrappers;
using System.Net;
using System.Text.Json;

namespace PruebaTecnica.Api.Apps.Api.Controllers.Middleware
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                HttpResponse response = context.Response;
                response.ContentType = "application/json";
                ResponseDto<string> responseModel = new()
                {
                    Succeed = false,
                    Message = error?.Message,
                    Errors = new List<string>()
                    {
                        $"Error: {(error.InnerException?.Message) ?? error?.Message}"
                    }
                };
                switch (error)
                {
                    case Src.Core.Business.Exceptions.ApiException e:
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        break;

                    case KeyNotFoundException e:
                        //Not Found Error
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        break;

                    default:
                        //Unhandled Error
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                }

                var result = JsonSerializer.Serialize(responseModel);
                await response.WriteAsync(result);
            }
        }
    }
}
