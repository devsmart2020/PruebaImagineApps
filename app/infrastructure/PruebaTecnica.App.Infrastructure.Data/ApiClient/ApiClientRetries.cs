using RestSharp;
using System;
using System.Threading.Tasks;

namespace PruebaTecnica.App.Infrastructure.Data.ApiClient
{
    public class ApiClientRetries
    {
        // Método genérico para realizar una petición HTTP con reintentos
        public static async Task<RestResponse<TResponse>> SendRequestWithRetriesAsync<TResponse>(Func<RestClient, RestRequest> requestBuilder, string baseUrl, Method method, int maxRetries = 4, int baseDelayMilliseconds = 1000)
        {
            int retry = 0;
            int delayMilliseconds = baseDelayMilliseconds;

            while (retry < maxRetries)
            {
                try
                {
                    // Crea el cliente RestSharp y construye la solicitud
                    RestClient client = new RestClient(baseUrl);
                    RestRequest request = requestBuilder(client);
                    RestResponse<TResponse> response = new RestResponse<TResponse>(request);

                    // Ejecuta la petición HTTP
                    switch (method)
                    {
                        case Method.Get:
                            response = await client.ExecuteGetAsync<TResponse>(request);
                            break;
                        case Method.Post:
                            response = await client.ExecuteAsync<TResponse>(request);
                            break;
                        case Method.Put:
                            response = await client.ExecutePutAsync<TResponse>(request);
                            break;
                        case Method.Delete:
                            break;
                        default:
                            break;
                    }

                    // Verifica si la petición fue exitosa
                    if (response.StatusCode == System.Net.HttpStatusCode.OK && response.Content != null)
                    {
                        return response;
                    }
                    else if (retry < maxRetries - 1 && ShouldRetry(response))
                    {
                        retry++;
                        delayMilliseconds *= 2; // Aumenta el retraso exponencialmente con cada reintento
                        await Task.Delay(delayMilliseconds);
                    }
                    else
                    {
                        throw new Exception($"Falló el envío de la solicitud: {response.StatusCode}");
                    }
                }
                catch (Exception ex)
                {
                    if (retry < maxRetries - 1 && ShouldRetry(ex))
                    {
                        retry++;
                        delayMilliseconds *= 2; // Aumenta el retraso exponencialmente con cada reintentos
                        await Task.Delay(delayMilliseconds);
                    }
                    else
                    {
                        throw;
                    }
                }
            }

            // Si se alcanza el número máximo de reintentos, lanza una excepción
            throw new Exception($"Falló la solicitud después de {maxRetries} reintentos.");
        }

        // Método auxiliar para determinar si se debe realizar un reintentos basado en la respuesta HTTP
        private static bool ShouldRetry(RestResponse response)
        {
            // Verifica si se deben realizar reintentos basado en la respuesta HTTP     
            return response.ResponseStatus == ResponseStatus.TimedOut || response.ResponseStatus == ResponseStatus.Error;
        }

        // Método auxiliar para determinar si se debe realizar un reintentos basado en el tipo de excepción
        private static bool ShouldRetry(Exception ex)
        {
            // Verifica si se deben realizar reintentos basado en el tipo de excepción 
            return ex is TimeoutException || ex is OperationCanceledException;
        }
    }
}
