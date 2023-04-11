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
    public partial class Bookhours : ContentPage
    {
        public Bookhours()
        {
            InitializeComponent();
        }

        private void PrevProfilePage(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ParkingDetails());
        }

        private void PaymentMethod(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PaymentMethod());
        }

        private void BookForHoursPage(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Bookhours());
        }

        private void parkingDetails(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ParkingDetails());
        }
    }
}