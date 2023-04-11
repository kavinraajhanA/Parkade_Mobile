using Newtonsoft.Json;
using PageProfile.BO;
using PageProfile.Popup;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PageProfile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        List<HomeClass> menuList = new List<HomeClass>();
        public HomePage()
        {
            InitializeComponent();
            
            
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            GetAllLandDetails();
        }

        private async void GetAllLandDetails()
        {
            try
            {
                HttpClient client;
                client = new HttpClient();
                client.MaxResponseContentBufferSize = 256000;
                var response = await client.GetAsync(App.APIURL + "Slot/GetAllLandDetails?CityName=Salem");
                var APIResponse = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    if (APIResponse != null)
                    {
                        var currentUser = JsonConvert.DeserializeObject<List<LandDetailsBO>>(APIResponse);
                        if (currentUser.Count != 0)
                        {
                            CList.ItemsSource = currentUser;
                        }
                        else
                        {
                            //IsUsernameExist = false;
                        }
                    }
                    else
                    {
                        //IsUsernameExist = false;
                    }
                }
                //await Navigation.PushAsync(new LLHome());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void nextProfilePage(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MainPage());
        }

        private async void menu(object sender, EventArgs e)
        {
            NavigationDrawer navigationDrawer = new NavigationDrawer();
            await PopupNavigation.Instance.PushAsync(navigationDrawer);
        }

        private void ParkingDetails_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ParkingDetails());
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            //NavigationDrawer navigationDrawer = new NavigationDrawer();
            //await PopupNavigation.Instance.PushAsync(navigationDrawer);
        }
    }
}