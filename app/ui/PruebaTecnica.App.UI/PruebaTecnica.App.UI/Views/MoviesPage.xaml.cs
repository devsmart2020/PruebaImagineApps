using PruebaTecnica.App.Core.ViewModels.Movies;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PruebaTecnica.App.UI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MoviesPage : ContentPage
    {
        private readonly MoviesViewModel _moviesVm;

        public MoviesPage()
        {
            InitializeComponent();
            _moviesVm = new MoviesViewModel();
            BindingContext = _moviesVm;
        }
    }
}