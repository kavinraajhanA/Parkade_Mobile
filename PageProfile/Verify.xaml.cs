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
    public partial class Verify : ContentPage
    {
        int timerValue = 15;
        int progressValue = 100;
        public Verify()
        {
            InitializeComponent();
            OTP1.Focus();
            Device.StartTimer(new TimeSpan(0, 0, 1), () =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    if(timerValue==0)
                    {
                        resendCode.IsVisible = true;
                        TimerLabel.IsVisible = false;
                        return;
                    }
                    OTPProgress.Progress = progressValue;
                    TimerLabel.Text=timerValue.ToString()+" secs";
                    timerValue--;
                    progressValue -= 10;
                });
                return true;
            });
        }

        private void verify1(object sender, EventArgs e)
        {
            Navigation.PushAsync(new newPass());
        }

        private void OTP1_TextChanged(object sender, TextChangedEventArgs e)
        {
            OTP2.Focus();
        }

        private void OTP2_TextChanged(object sender, TextChangedEventArgs e)
        {
            OTP3.Focus();
        }

        private void OTP3_TextChanged(object sender, TextChangedEventArgs e)
        {
            OTP4.Focus();
        }

        private void OTP4_TextChanged(object sender, TextChangedEventArgs e)
        {
            OTP5.Focus();
        }

        private void OTP5_TextChanged(object sender, TextChangedEventArgs e)
        {
            OTP6.Focus();
        }

        private void OTP6_TextChanged(object sender, TextChangedEventArgs e)
        {
            OTP6.Unfocus();
        }
    }
}