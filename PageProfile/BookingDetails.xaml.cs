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
    public partial class BookingDetails : ContentPage
    {
        public BookingDetails()
        {
            InitializeComponent();
        }

        private void PrevProfilePage(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MainPage());
        }
    }
}