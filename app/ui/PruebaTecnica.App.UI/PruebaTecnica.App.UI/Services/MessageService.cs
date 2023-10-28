using PruebaTecnica.App.Core.Application.UiServiceInterfaces;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PruebaTecnica.App.UI.Services
{
    public sealed class MessageService : IMessageService
    {
        #region Ctor
        public MessageService()
        {

        }
        #endregion

        #region Methods
        public async Task ViewMessage(string title, string message)
        {
            await Shell.Current.DisplayAlert(title, message, "OK");
        }

        public async Task<string> ViewMessageWithAction(string title, string message)
        {
            return await Shell.Current.DisplayActionSheet(title, "Accept", "Cancel", message);
        }
        #endregion
    }
}
