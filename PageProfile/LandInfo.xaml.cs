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
    public partial class LandInfo : ContentPage
    {
        string LandPhotoPath = "";
        string LandTaxPhotoPath = "";
        public string AnotherLandProofPhotoPath = "";
        //bool CCTV = false, Security = false, Alarm = false, FE = false, FullDay = false;
        public LandInfo()
        {
            InitializeComponent();
        }
        private async void LandUpdateAPI(LandDetailsBO landDetailsBO)
        {
            try
            {
                HttpClient client;
                client = new HttpClient();
                client.MaxResponseContentBufferSize = 256000;
                var jsonString = JsonConvert.SerializeObject(landDetailsBO);
                var signupEmailData = new StringContent(jsonString, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(App.APIURL + "LL/AddLandDetails", signupEmailData);
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
            await Navigation.PushAsync(new LandDetails());
        }

        private void LandDetails(object sender, EventArgs e)
        {
            LandDetailsBO landDetailsBO = new LandDetailsBO();
            landDetailsBO.LandCoverPhoto = LandPhotoPath;
            landDetailsBO.PriceForDays = Convert.ToInt32(pdayentry.Text);
            landDetailsBO.PriceForHours = Convert.ToInt32(phourentry.Text);
            landDetailsBO.AvailableSlots = Convert.ToInt32(slotentry.Text);
            landDetailsBO.CCTV = CCTV.IsChecked;
            landDetailsBO.Alarm = Alarm.IsChecked;
            landDetailsBO.Security = security.IsChecked;
            landDetailsBO.FireExtinguish = FireExtinguish.IsChecked;
            landDetailsBO.fullDay = fullDay.IsChecked;
            //landDetailsBO.Ratings = "";
            landDetailsBO.onemnth = Convert.ToInt32(onemnth.Text);
            landDetailsBO.threemnth = Convert.ToInt32(threemnth.Text);
            landDetailsBO.sixmnth = Convert.ToInt32(sixmnth.Text);
            LandUpdateAPI(landDetailsBO);


        }

        private void LLhome(object sender, EventArgs e)
        {
            Navigation.PushAsync(new LLHome());
        }

        private async void LandPic(object sender, EventArgs e)
        {
            {
                await TakeLandPhotoAsync();
            }

            async Task TakeLandPhotoAsync()
            {
                try
                {
                    var photo = await MediaPicker.CapturePhotoAsync();
                    await LoadLandPhotoAsync(photo);
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

            async Task LoadLandPhotoAsync(FileResult photo)
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
                LandPhotoPath = newFile;
            }
            LandDetailsBO landDetailsBO = new LandDetailsBO();
            landDetailsBO.LandCoverPhoto = LandPhotoPath;
            LandUpdateAPI(landDetailsBO);
        }

        private async void LandTaxUpdateAPI(ProofDetailsBO proofDetailsBO)
        {
            try
            {
                HttpClient client;
                client = new HttpClient();
                client.MaxResponseContentBufferSize = 256000;
                var jsonString = JsonConvert.SerializeObject(proofDetailsBO);
                var signupEmailData = new StringContent(jsonString, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(App.APIURL + "LL/LLProof", signupEmailData);
                var APIResponse = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    if (APIResponse != null)
                    {
                        var currentUser = JsonConvert.DeserializeObject<bool>(APIResponse);
                        if (currentUser)
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
        }






            private async void LandTaxPic(object sender, EventArgs e)
            {
                {
                    await TakeLandTaxPhotoAsync();
                }

                async Task TakeLandTaxPhotoAsync()
                {
                    try
                    {
                        var photo = await MediaPicker.CapturePhotoAsync();
                        await LoadLandTaxPhotoAsync(photo);
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

                async Task LoadLandTaxPhotoAsync(FileResult photo)
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
                    LandPhotoPath = newFile;
                }
                ProofDetailsBO proofDetailsBO = new ProofDetailsBO();
                proofDetailsBO.LLTaxProof = LandTaxPhotoPath;
                LandTaxUpdateAPI(proofDetailsBO);


            }

        private async void AnotherLandProofPic(object sender, EventArgs e)
        {
            {
                await TakeAnotherLandProofPhotoAsync();
            }

            async Task TakeAnotherLandProofPhotoAsync()
            {
                try
                {
                    var photo = await MediaPicker.CapturePhotoAsync();
                    await LoadAnotherLandProofPhotoAsync(photo);
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

            async Task LoadAnotherLandProofPhotoAsync(FileResult photo)
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
                AnotherLandProofPhotoPath = newFile;
            }
            ProofDetailsBO proofDetailsBO = new ProofDetailsBO();
            proofDetailsBO.LLTaxProof = AnotherLandProofPhotoPath;
            LandTaxUpdateAPI(proofDetailsBO);
        }
    }

   
    }
