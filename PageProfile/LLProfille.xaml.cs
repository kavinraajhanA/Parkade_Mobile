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
    public partial class LLProfille : ContentPage
    {
        public LLProfille()
        {
            InitializeComponent();
        }

        private void LLPersonalDetails_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new LLPersonalDetails());
        }

        private void LLBookingDetails_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new LLBookingDetails());
        }

        private void LLLogOut(object sender, EventArgs e)
        {
            Navigation.PushAsync(new LogInPage());
        }

        private void LLLandDetails_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new LLLandDetails());
        }

        private void LLBankDetails_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new LLBankDetails());

        }


        private void LLhome(object sender, EventArgs e)
        {
            Navigation.PushAsync(new LLHome());
        }
    }
}