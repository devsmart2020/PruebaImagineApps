using PruebaTecnica.App.Core.DTOs.Common;
using PruebaTecnica.App.Core.ViewModels.Base;
using System.Threading.Tasks;

namespace PruebaTecnica.App.Core.ViewModels.Movies
{
    public sealed class WebVisorViewModel : BaseViewModel
    {
        #region Fields

        #endregion

        #region Ctor
        public WebVisorViewModel()
        {

        }
        #endregion

        #region Properties
        private string _webUrl;

        public string WebUrl
        {
            get => _webUrl;
            set => SetProperty(ref _webUrl, value);
        }

        #endregion


        #region Methods
        public override async Task OnInitializeAsync(object? parameters = null)
        {
            if (parameters is null || !(parameters is ParameterFilterDto<string> filter))
                return;

            WebUrl = filter.ParamString;
        }
        #endregion


        #region Commands

        #endregion

    }
}
