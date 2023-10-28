using Newtonsoft.Json;
using PruebaTecnica.App.Core.Application.UiServiceInterfaces;
using PruebaTecnica.App.Core.DTOs.Common;
using RestSharp;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PruebaTecnica.App.Infrastructure.Data.ApiClient
{
    public sealed class ApiClient : IApiClient
    {
        #region Fields
        private string? _baseUrl;
        private string? _bearerToken;
        private string? _apiKey;
        #endregion

        #region Ctor
        public ApiClient()
        {

        }
        #endregion

        #region Methods
        public async Task<ResponseDto<TReceive>> Get<TReceive>(string url, IDictionary<string, string>? parameters = null)
        {
            string urlCompleta = $"{_baseUrl}{url}";
            RestRequest request = new RestRequest(urlCompleta, Method.Get);
            if (parameters != null)
            {
                foreach (KeyValuePair<string, string> parameter in parameters)
                {
                    request.AddQueryParameter(parameter.Key, parameter.Value);
                }
            }
            request = AddBearerToken(request);
            request = AddApiKey(request);
            RestResponse<TReceive> response = await SendRequestWithRetries<TReceive>(request, urlCompleta, Method.Get);        
            return GetResponse(response);
        }

        public async Task<ResponseDto<TReceive>> Post<TSend, TReceive>(string url, TSend data)
        {
            string fullPath = $"{_baseUrl}{url}";
            RestRequest request = new RestRequest(fullPath, Method.Post);
            request.AddBody(System.Text.Json.JsonSerializer.Serialize(data), ContentType.Json);
            request = AddBearerToken(request);
            request = AddApiKey(request);
            RestResponse<TReceive> response = await SendRequestWithRetries<TReceive>(request, fullPath, Method.Post);
            return GetResponse(response);
        }

        public async Task<ResponseDto<TReceive>> Put<TSend, TReceive>(string url, TSend data)
        {
            string fullPath = $"{_baseUrl}{url}";
            RestRequest request = new RestRequest(fullPath, Method.Put);
            request.AddBody(System.Text.Json.JsonSerializer.Serialize(data), ContentType.Json);
            request = AddBearerToken(request);
            request = AddApiKey(request);
            RestResponse<TReceive> response = await SendRequestWithRetries<TReceive>(request, fullPath, Method.Put);

            return GetResponse(response);
        }
        #endregion

        #region Private Methods
        private static async Task<RestResponse<TResponse>> SendRequestWithRetries<TResponse>(RestRequest request, string baseUrl, Method method)
        {
            return await ApiClientRetries.SendRequestWithRetriesAsync<TResponse>((restClient) =>
            {
                return request;
            }, baseUrl, method, 4, 1000);
        }
        private RestRequest AddApiKey(RestRequest request)
        {
            if (!string.IsNullOrEmpty(_bearerToken))
            {
                request.AddHeader("Authorization", $"Bearer {_bearerToken}");
            }
            return request;
        }
        private RestRequest AddBearerToken(RestRequest request)
        {
            if (!string.IsNullOrEmpty(_apiKey))
            {
                request.AddHeader("ApiKey", _apiKey);
            }
            return request;
        }

        private static ResponseDto<TResponse> GetResponse<TResponse>(RestResponse<TResponse> response)
        {            
            if (response.StatusCode != System.Net.HttpStatusCode.OK && string.IsNullOrEmpty(response.Content))
                throw new System.Exception(response.ErrorMessage);

            if (string.IsNullOrEmpty(response.Content))
                throw new System.Exception(response.ErrorMessage);

            return JsonConvert.DeserializeObject<ResponseDto<TResponse>>(response.Content)!;  
        }
        #endregion

        #region Properties
        public string BaseUrl { set { _baseUrl = value; } }
        public string BearerToken { set { _bearerToken = value; } }
        public string ApiKey { set { _apiKey = value; } }
        #endregion

    }
}
