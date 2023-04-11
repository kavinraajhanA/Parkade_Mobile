using Newtonsoft.Json;
using PageProfile.BO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PageProfile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignUp : ContentPage
    {
        string LicensePhotoPath = "";
        bool IsLandlord = false;
        public SignUp()
        {
            InitializeComponent();
        }

        private async void LogIn(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(NameEntry.Text))
                {
                    await DisplayAlert("Error", "Name is missing", "ok");
                }
                else if (string.IsNullOrWhiteSpace(EmailEntry.Text))
                {
                    await DisplayAlert("Error", "Email is missing", "ok");
                }
                else if (string.IsNullOrWhiteSpace(MobileEntry.Text))
                {
                    await DisplayAlert("Error", "mobile number is missing", "ok");
                }
                else if (string.IsNullOrWhiteSpace(PassEntry.Text))
                {
                    await DisplayAlert("Error", "password is missing", "ok");
                }
                else if (string.IsNullOrWhiteSpace(ConfirmpassEntry.Text))
                {
                    await DisplayAlert("Error", "confirm password is missing", "ok");
                }
                else if (string.IsNullOrWhiteSpace(LicPicEntry.Text))
                {
                    await DisplayAlert("Error", "license is missing", "ok");
                }
               // else if (string.IsNullOrWhiteSpace(TaxRecEntry.Text))
                //{
                  //  DisplayAlert("Error", "tax is missing", "ok");
                //}
                else
                {
                    if (!emailEntry.Text.Contains("@") && !EmailEntry.Text.Contains("."))
                    {
                        await DisplayAlert("Error", " Invalid email format", "ok");
                    }
                    else if (MobileEntry.Text.Length != 10)
                    {
                        await DisplayAlert("Error", " Invalid mobile number format", "ok");
                    }
                    else if (!PassEntry.Text.Equals(ConfirmpassEntry.Text))
                    {
                        await DisplayAlert("Error", " Password miss match", "ok");
                    }
                    else
                    {
                        //API CODE

                        UserProfileBO userProfileBO = new UserProfileBO();
                        userProfileBO.UserName = NameEntry.Text;
                        userProfileBO.UserEmail =EmailEntry.Text;
                        userProfileBO.UserPhone =Convert.ToInt64(MobileEntry.Text);
                        userProfileBO.UserDOB = DobEntry.Date;
                        userProfileBO.UserAddress =AddressEntry.Text;
                        userProfileBO.UserPassword =ConfirmpassEntry.Text;
                        userProfileBO.UserProfileImage = String.Empty;

                        HttpClient client;
                        client = new HttpClient();
                        client.MaxResponseContentBufferSize = 256000;
                        var jsonString = JsonConvert.SerializeObject(userProfileBO);
                        var signupEmailData = new StringContent(jsonString, Encoding.UTF8, "application/json");
                        HttpResponseMessage response = await client.PostAsync(App.APIURL + "UserProfile/RegisterUser", signupEmailData);
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
                    
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            
        }

        private void SignIn(object sender, EventArgs e)
        {

            Navigation.PushAsync(new LogInPage());
        }

        private void DocToggled(object sender, ToggledEventArgs e)
        {
            if(e.Value)
            {
                IsLandlord = true;
                LLDoc.IsVisible = true;
                UserDoc1.IsVisible = false;
                UserDoc2.IsVisible = false;
            }
            else
            {
                IsLandlord = false;
                LLDoc.IsVisible = false;
                UserDoc1.IsVisible = true;
                UserDoc2.IsVisible = true;
            }
        }

        private async void LicPicUser(object sender, EventArgs e)
        {
            {
                await TakeLicensePhotoAsync();
            }

            async Task TakeLicensePhotoAsync()
            {
                try
                {
                    var photo = await MediaPicker.CapturePhotoAsync();
                    await LoadLicensePhotoAsync(photo);
                    //Console.WriteLine($"CapturePhotoAsync COMPLETED: {PhotoPath}");
                }
                catch (FeatureNotSupportedException fnsEx)
                {
                    // Feature is not supported on the device
                }
                catch (PermissionException pEx)
                {
                    // Permissions not granted
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"CapturePhotoAsync THREW: {ex.Message}");
                }
            }

            async Task LoadLicensePhotoAsync(FileResult photo)
            {
                // canceled
                if (photo == null)
                {
                    //PhotoPath = null;
                    return;
                }
                // save the file into local storage
                var newFile = Path.Combine(FileSystem.CacheDirectory, photo.FileName);
                using (var stream = await photo.OpenReadAsync())
                using (var newStream = File.OpenWrite(newFile))
                    await stream.CopyToAsync(newStream);

                LicensePhotoPath = newFile;
            }
            ProofDetailsBO proofDetailsBO = new ProofDetailsBO();
            //proofDetailsBO.UserLicFrontImage;
        }
    }
}