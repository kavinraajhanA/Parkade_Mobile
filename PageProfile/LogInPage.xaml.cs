using Newtonsoft.Json;
using PageProfile.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PageProfile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LogInPage : ContentPage
    {
        LocalDatabase localDatabase=new LocalDatabase();
        public LogInPage()
        {
            InitializeComponent();
        }

        private async void LogIn(object sender, EventArgs e)
        {
            try
            {
                if(string.IsNullOrWhiteSpace(emailchecked.Text))
                {
                    await DisplayAlert("Error", "Email is missing", "ok");
                }
                else if (string.IsNullOrWhiteSpace(password.Text))
                {
                    await DisplayAlert("Error", "password is missing", "ok");
                }
                else
                {
                    HttpClient client;
                    client = new HttpClient();
                    client.MaxResponseContentBufferSize = 256000;

                    var response = await client.GetAsync(App.APIURL + "UserProfile/LogInUser?EmailID="+ emailchecked.Text+ "&Password="+ password.Text);
                    var APIResponse = await response.Content.ReadAsStringAsync();
                    if (response.IsSuccessStatusCode)
                    {
                        if (APIResponse != null)
                        {
                            var currentUser = JsonConvert.DeserializeObject<UserProfileBO>(APIResponse);
                            if (currentUser.UserID!=0)
                            {
                                //IsUsernameExist = true;
                                localDatabase.SaveUserProfile(currentUser); 
                            }
                            else
                            {
                                //IsUsernameExist = false;
                            }
                        }
                        else
                        {
                            //IsUsernameExist = false;
                        }
                    }
                    await Navigation.PushAsync(new HomePage());
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            

        }

        private void SignUp(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SignUp());
        }

        private void ForgetPword(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ForgotPWordVer());
        }

     
    }
}