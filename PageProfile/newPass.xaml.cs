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
    public partial class newPass : ContentPage
    {
        public newPass()
        {
            InitializeComponent();
        }

        private void next(object sender, EventArgs e)
        {

            try
            {
                if (string.IsNullOrWhiteSpace(newpasss.Text))
                {
                    DisplayAlert("Error", "Password is missing ", "ok");

                }
                else if (string.IsNullOrWhiteSpace(confpass.Text))
                {
                    DisplayAlert("Error", "Password is missing", "ok");

                }
                else if (!newpasss.Text.Equals(confpass.Text))
                {
                    DisplayAlert("Error", " Password miss match", "ok");
                }
                else
                {
                    Navigation.PushAsync(new versuccess());

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            
        }
    }
}