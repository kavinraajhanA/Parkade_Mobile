﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PageProfile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PaymentMethod1 : ContentPage
    {
        public PaymentMethod1()
        {
            InitializeComponent();
        }

     

        private void bookDays1(object sender, EventArgs e)
        {
            Navigation.PushAsync(new BookDays());
        }

       

        private void bookHours1(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Bookhours());
        }

        private void VehicleDetails(object sender, EventArgs e)
        {
            Navigation.PushAsync(new VehicleDetails());
        }
    }
}