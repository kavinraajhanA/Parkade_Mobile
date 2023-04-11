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
    public partial class BookingConfirmation : ContentPage
    {
        public BookingConfirmation()
        {
            InitializeComponent();
        }

        private void BookConfirmContinue(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PaymentSuccessfull());
        }

        private void BookingConfirmBack(object sender, EventArgs e)
        {
            Navigation.PushAsync(new VehicleDetails());
        }
    }
}