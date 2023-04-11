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
    public partial class ParkingDetails : ContentPage
    {
        public ParkingDetails()
        {
            InitializeComponent();
            List<ParkingDetailsClass> images = new List<ParkingDetailsClass>()
            {
               new ParkingDetailsClass(){Title="Image 1",Url="ParkingPic"},
               new ParkingDetailsClass(){Title="Image 1",Url="ParkingPic"},
               new ParkingDetailsClass(){Title="Image 1",Url="ParkingPic"}
               
            };
            Carousel.ItemsSource = images;
            List<caro> images1 = new List<caro>()
            {
               new caro(){Title="Image 1",Url="ParkingPic"},
               new caro(){Title="Image 1",Url="ParkingPic"},
               new caro(){Title="Image 1",Url="ParkingPic"}
              
            };
            Carousel.ItemsSource = images1;

        }


        private void HoursBook(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Bookhours());
        }

        private void DaysBook(object sender, EventArgs e)
        {
            Navigation.PushAsync(new BookDays());
        }

        private void LLhome(object sender, EventArgs e)
        {

            Navigation.PushAsync(new HomePage());
        }
    }
}