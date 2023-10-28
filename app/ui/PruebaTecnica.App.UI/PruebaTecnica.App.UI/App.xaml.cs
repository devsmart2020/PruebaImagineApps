using Microsoft.Extensions.DependencyInjection;
using PruebaTecnica.App.UI.Converters;
using PruebaTecnica.App.UI.Services;
using Xamarin.Forms;

namespace PruebaTecnica.App.UI
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();
            ServiceCollection services = new ServiceCollection();
            RegisterDependences.Register(services);           
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
