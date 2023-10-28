using PruebaTecnica.App.Core.ViewModels.Movies;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PruebaTecnica.App.UI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VisorWeb : ContentPage
    {
        private readonly WebVisorViewModel _vieModel;
        public VisorWeb()
        {
            InitializeComponent();
            _vieModel = new WebVisorViewModel();
            BindingContext = _vieModel;
        }
    }
}