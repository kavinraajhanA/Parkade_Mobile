using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PageProfile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class logo : ContentPage
    {
        public logo()
        {
            InitializeComponent();
            LaunchHome();
        }

        private async void LaunchHome()
        {
            await Task.Delay(6000);
            await Navigation.PushAsync(new LogInPage());
        }
    }
}