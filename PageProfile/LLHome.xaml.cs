using PageProfile.Popup;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PageProfile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LLHome : ContentPage
    {
        public LLHome()
        {
            InitializeComponent();
        }

        private async void menu(object sender, EventArgs e)
        {
            NavigationDrawer navigationDrawer = new NavigationDrawer();
            await PopupNavigation.Instance.PushAsync(navigationDrawer);
        }

        private void LLProfilePage(object sender, EventArgs e)
        {
            Navigation.PushAsync(new LLProfille());
        }

        private void LandInfo(object sender, EventArgs e)
        {
            Navigation.PushAsync(new LandInfo());
        }
    }
}