using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PageProfile.Popup
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NavigationDrawer : PopupPage
    {
        public NavigationDrawer()
        {
            InitializeComponent();
        }

        private void Navigation_Close_Btn_Clicked(object sender, EventArgs e)
        {
            PopupNavigation.Instance.PopAsync();
        }
    }
}