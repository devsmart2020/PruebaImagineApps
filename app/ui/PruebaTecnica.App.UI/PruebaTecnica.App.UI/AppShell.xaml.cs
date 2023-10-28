using PruebaTecnica.App.UI.Views;
using Xamarin.Forms;

namespace PruebaTecnica.App.UI
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(MoviesPage), typeof(MoviesPage));
        }

    }
}
