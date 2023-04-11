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
    public partial class VehicleDetails : ContentPage
    {
        string VehiclePhotoPath = "";
        public VehicleDetails()
        {
            InitializeComponent();
        }

        private async void VehiclePhoto(object sender, EventArgs e)
        {

            {
                await TakeVehiclePhotoAsync();
            }

            async Task TakeVehiclePhotoAsync()
            {
                try
                {
                    var photo = await MediaPicker.CapturePhotoAsync();
                    await LoadVehiclePhotoAsync(photo);
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

            async Task LoadVehiclePhotoAsync(FileResult photo)
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

                VehiclePhotoPath = newFile;
            }
            VehicleDetailsBO vehicleDetailsBO = new VehicleDetailsBO();
            vehicleDetailsBO.Vehiclephoto = VehiclePhotoPath;
            VehicleUpdateAPI(vehicleDetailsBO);
        }
        private async void VehicleUpdateAPI(VehicleDetailsBO vehicleDetailsBO)
        {
            try
            {
                HttpClient client;
                client = new HttpClient();
                client.MaxResponseContentBufferSize = 256000;
                var jsonString = JsonConvert.SerializeObject(vehicleDetailsBO);
                var signupEmailData = new StringContent(jsonString, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(App.APIURL + "Slot/VehicleDetails", signupEmailData);
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
            await Navigation.PushAsync(new BookingConfirmation());
        }
        private void VehicleContinue(object sender, EventArgs e)

        {
            VehicleDetailsBO vehicleDetailsBO = new VehicleDetailsBO();
        
            vehicleDetailsBO.VehicleNumber = Vehicle_num.Text;
            vehicleDetailsBO.Vehiclephoto = VehiclePhotoPath;
            vehicleDetailsBO.BrandName = Brand_name.Text;
            vehicleDetailsBO.Model = Model_name.Text;
            vehicleDetailsBO.colour = Vehicle_Clr.Text;
            VehicleUpdateAPI(vehicleDetailsBO);


        }

        private void VehicleBack(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PaymentMethod());
        }
    }
}