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
    public partial class PaymentSuccessfull : ContentPage
    {
        int timerValue = 15;
        int progressValue = 100;
        public PaymentSuccessfull()
        {
            InitializeComponent();
            Device.StartTimer(new TimeSpan(0, 0, 1), () =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    if (timerValue == 0)
                    {
                       
                        TimerLabel.IsVisible = false;
                        return;
                    }
                    OTPProgress.Progress = progressValue;
                    TimerLabel.Text = timerValue.ToString() + " secs";
                    timerValue--;
                    progressValue -= 10;
                });
                return true;
            });
        }

        private void BackToHome(object sender, EventArgs e)
        {
            Navigation.PushAsync(new HomePage());
        }
    }
}