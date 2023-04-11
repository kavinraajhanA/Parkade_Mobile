using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PageProfile
{
    public partial class MainPage : ContentPage
    {
        LocalDatabase db = new LocalDatabase();
        public MainPage()
        {
            InitializeComponent();
        }

        private void ImageButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new HomePage());
        }

        private void PersonalDetails_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new personaldetails());
        }

        private void BookingDetails_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new BookingDetails());
        }

        private void LicenseDetails_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new LicenseDetails());
        }

        private void PrimeDetails_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PrimeDetails()); 
        }

        private void LogOut(object sender, EventArgs e)
        {
            db.DeleteStudentDetails();
            Navigation.PushAsync(new LogInPage());
        }
    }
}
