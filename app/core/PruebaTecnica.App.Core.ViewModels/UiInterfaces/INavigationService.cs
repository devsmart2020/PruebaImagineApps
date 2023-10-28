using PruebaTecnica.App.Core.ViewModels.Base;
using System.Threading.Tasks;

namespace PruebaTecnica.App.Core.ViewModels.UiInterfaces
{
    public interface INavigationService
    {
        Task NavigatePushAsync<TViewModel>(object? parameter = null) where TViewModel : BaseViewModel;
        Task NavigatePopAsync();
        Task NavigatePopRootAsync();
        Task NavigatePushModalAsync<TViewModel>(object? parameter = null) where TViewModel : BaseViewModel;
        Task NavigatePopModalAsync();
    }
}
