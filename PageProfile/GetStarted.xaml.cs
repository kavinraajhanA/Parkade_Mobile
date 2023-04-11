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
    public partial class GetStarted : ContentPage
    {
        public GetStarted()
        {
            InitializeComponent();
            List<GetSrartedClass> images = new List<GetSrartedClass>()
            {
               new GetSrartedClass(){Title="WELCOME",ImageUrl="slide1",ButtonText="NEXT",Description="Lorem Ipsum",IsButtonVisible=false},
               new GetSrartedClass(){Title="IPSUM",ImageUrl="slide2",ButtonText="NEXT",Description="Lorem Ipsum",IsButtonVisible=false},
               new GetSrartedClass(){Title="LOREM",ImageUrl="slide3", ButtonText = "GET STARTED",Description="Lorem Ipsum",IsButtonVisible=true}

            };
            SlidersList.ItemsSource = images;          
        }

        private void logopage(object sender, EventArgs e)
        {
            Navigation.PushAsync(new logo());
        }
    }
}