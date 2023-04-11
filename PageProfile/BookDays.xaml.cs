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
    public partial class BookDays : ContentPage
    {
        public BookDays()
        {
            InitializeComponent();
        }

        private void PrevProfilePage(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ParkingDetails());

        }

        private void PaymentMethod1(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PaymentMethod1());
        }

        private void BookForDaysPage(object sender, EventArgs e)
        {
            Navigation.PushAsync(new BookDays());
        }

        private void parkingDetails2(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ParkingDetails());
        }
    }
}