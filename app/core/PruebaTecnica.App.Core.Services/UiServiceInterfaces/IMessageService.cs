using System.Threading.Tasks;

namespace PruebaTecnica.App.Core.Application.UiServiceInterfaces
{
    public interface IMessageService
    {
        Task ViewMessage(string title, string message);
        Task<string> ViewMessageWithAction(string title, string message);
    }
}
