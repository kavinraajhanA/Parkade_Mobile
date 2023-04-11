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
    public partial class LicenseDetails : ContentPage
    {
        string FrontPhotoPath = "";
        string BackPhotoPath = "";
        public LicenseDetails()
        {
            InitializeComponent();
        }

        private void PrevProfilePage(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MainPage());
        }

        private async void UploadFrontLic(object sender, EventArgs e)
        {
            await TakeFrontPhotoAsync();
        }

        async Task TakeFrontPhotoAsync()
        {
            try
            {
                var photo = await MediaPicker.CapturePhotoAsync();
                await LoadFrontPhotoAsync(photo);
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

        async Task LoadFrontPhotoAsync(FileResult photo)
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

            FrontPhotoPath = newFile;
        }

        private async void UploadBackLic(object sender, EventArgs e)
        {
            await BackPhotoAsync();
        }

        async Task BackPhotoAsync()
        {
            try
            {
                var photo = await MediaPicker.CapturePhotoAsync();
                await LoadBackPhotoAsync(photo);
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

        async Task LoadBackPhotoAsync(FileResult photo)
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

            FrontPhotoPath = newFile;
        }

        private async void LicenseUpdate(object sender, EventArgs e)
        {
            ProofDetailsBO proofDetailsBO = new ProofDetailsBO();
            proofDetailsBO.UserLicFrontImage = FrontPhotoPath;
            proofDetailsBO.UserLicBackImage = BackPhotoPath;
            proofDetailsBO.UserLicValidTillDate = LicDate.Date;


            try
            {
                HttpClient client;
                client = new HttpClient();
                client.MaxResponseContentBufferSize = 256000;
                var jsonString = JsonConvert.SerializeObject(proofDetailsBO);
                var signupEmailData = new StringContent(jsonString, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(App.APIURL + "UserProfile/LicUpdate", signupEmailData);
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
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            await Navigation.PushAsync(new BookingConfirmation());
        }
    }
}