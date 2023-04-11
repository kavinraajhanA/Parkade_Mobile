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
    public partial class LandDetails : ContentPage
    {
        public LandDetails()
        {
            InitializeComponent();
            List<LLCarousel> LLcaroImage = new List<LLCarousel>()
            {
                new LLCarousel(){Title="Image 1",Url="ParkingPic" },
                new LLCarousel(){Title="Image 1",Url="ParkingPic" },
                new LLCarousel(){Title="Image 1",Url="ParkingPic" }
            };
            LLCarousel.ItemsSource = LLcaroImage;

        }

      
        private void LLprofile(object sender, EventArgs e)
        {
            Navigation.PushAsync(new LLProfille());
        }
    }
}