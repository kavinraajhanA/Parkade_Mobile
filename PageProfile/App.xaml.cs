using PageProfile.Popup;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PageProfile
{
    public partial class App : Application
    {
        public static string APIURL = "http://192.168.1.2/Parkade_API/api/";
        LocalDatabase db=new LocalDatabase();
        public App ()
        {
            InitializeComponent();
            var userData = db.GetUserProfile();
            if(userData == null)
            {
                MainPage = new NavigationPage(new logo());
            }
            else
            {
                MainPage = new NavigationPage(new VehicleDetails());
            }
        }

        protected override void OnStart ()
        {
        }

        protected override void OnSleep ()
        {
        }

        protected override void OnResume ()
        {
        }
    }
}
