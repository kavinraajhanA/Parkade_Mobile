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
    public partial class ForgotPWordVer : ContentPage
    {
        public ForgotPWordVer()
        {
            InitializeComponent();
        }

        private async void Verify(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(numentry.Text))
                {
                  await  DisplayAlert("Error", "mobile number is missing", "ok");
                    
                }
                else if (numentry.Text.Length != 10)
                {
                  await  DisplayAlert("Error", " Invalid mobile number format", "ok");
                }
                else
                {
                    UserProfileBO userProfileBO = new UserProfileBO();
                    userProfileBO.UserID = 1;
                    userProfileBO.UserPassword = numentry.Text;

                    try
                    {
                        HttpClient client;
                        client = new HttpClient();
                        client.MaxResponseContentBufferSize = 256000;
                        var jsonString = JsonConvert.SerializeObject(userProfileBO);
                        var signupEmailData = new StringContent(jsonString, Encoding.UTF8, "application/json");
                        HttpResponseMessage response = await client.PostAsync(App.APIURL + "UserProfile/SavePass", signupEmailData);
                        var APIResponse = await response.Content.ReadAsStringAsync();
                        if (response.IsSuccessStatusCode)
                        {
                            if (APIResponse != null)
                            {
                                var currentUser = JsonConvert.DeserializeObject<int>(APIResponse);
                                if (currentUser != 0)
                                {
                                    await Application.Current.MainPage.DisplayAlert("Success", "User Registered successfully!", "Okay");
                                }
                                else
                                {
                                    await Application.Current.MainPage.DisplayAlert("Failed", "User Registration getting failed!", "Okay");
                                }
                            }
                            else
                            {
                                await Application.Current.MainPage.DisplayAlert("Failed", "User Registration getting Failed!", "Okay");
                            }
                        }
                        else
                        {
                            await Application.Current.MainPage.DisplayAlert("Failed", "Profile Update getting Failed!", "Okay");
                        }
                        await Navigation.PushAsync(new LogInPage());
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }
                   await Navigation.PushAsync(new Verify());

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
           
        }
    }
}