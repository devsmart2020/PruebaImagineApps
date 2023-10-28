using PruebaTecnica.App.Core.DTOs.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PruebaTecnica.App.Core.Application.UiServiceInterfaces
{
    public interface IApiClient
    {
        string BaseUrl { set; }
        string BearerToken { set; }
        string ApiKey { set; }

        Task<ResponseDto<TReceive>> Post<TSend, TReceive>(string url, TSend dato);
        Task<ResponseDto<TReceive>> Get<TReceive>(string url, IDictionary<string, string>? parameters = null);
        Task<ResponseDto<TReceive>> Put<TSend, TReceive>(string url, TSend dato);
    }
}
