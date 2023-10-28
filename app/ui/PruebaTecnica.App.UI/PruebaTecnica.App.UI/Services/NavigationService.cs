using PruebaTecnica.App.Core.ViewModels.Base;
using PruebaTecnica.App.Core.ViewModels.Movies;
using PruebaTecnica.App.Core.ViewModels.UiInterfaces;
using PruebaTecnica.App.UI.Views;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PruebaTecnica.App.UI.Services
{
    public sealed class NavigationService : INavigationService
    {

        #region Fields

        private readonly Dictionary<Type, Type> _mappings;
        private readonly IServiceProvider _serviceProvider;
        #endregion

        #region Ctor
        public NavigationService(IServiceProvider serviceProvider)
        {
            _mappings = new Dictionary<Type, Type>();
            _serviceProvider = serviceProvider;
            CreateMap();
        }
        #endregion

        #region Methods
        public async Task NavigatePushAsync<TViewModel>(object parameter = null) where TViewModel : BaseViewModel
        {
            Page pageConfigured = await ConfigurePageVm<TViewModel>(parameter);
            await Shell.Current.Navigation.PushAsync(pageConfigured, true);
        }
        public async Task NavigatePushModalAsync<TViewModel>(object parameter = null) where TViewModel : BaseViewModel
        {
            Page pageConfigured = await ConfigurePageVm<TViewModel>(parameter);
            await Shell.Current.Navigation.PushModalAsync(pageConfigured, true);
        }
        public async Task NavigatePopModalAsync()
        {
            await Shell.Current.Navigation.PopModalAsync(true);
        }
        public async Task NavigatePopAsync()
        {
            await Shell.Current.Navigation.PopAsync(true);
        }

        public async Task NavigatePopRootAsync()
        {
            await Shell.Current.Navigation.PopToRootAsync(true);
        }

        private void CreateMap()
        {
            _mappings.Add(typeof(WebVisorViewModel), typeof(VisorWeb));
        }
        private async Task<Page> ConfigurePageVm<TViewModel>(object parameter = null) where TViewModel : BaseViewModel
        {
            Type viewModelType = typeof(TViewModel);
            if (!_mappings.ContainsKey(viewModelType))
            {
                throw new ArgumentException($"No mapping found for {viewModelType}");
            }
            Type pageType = _mappings[viewModelType];
            Page page = (Page)Activator.CreateInstance(pageType);
            BaseViewModel viewModel = _serviceProvider.GetService(viewModelType) as BaseViewModel;
            await viewModel.OnInitializeAsync(parameter);
            page.BindingContext = viewModel;
            return page;
        }
        #endregion
    }
}
