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
    public partial class LLEditPage : ContentPage
    {
        string LLProfilePhotoPath = "";
        public string APIResponse { get; private set; }

        bool IsLLAddEntryVisible = false;

        public LLEditPage()
        {
            InitializeComponent();
        }

        private void PersonalDetailsPage(object sender, EventArgs e)
        {
            Navigation.PushAsync(new LLPersonalDetails());
        }

        private async void LLUpdateAPI(LLProfileBO lLProfileBO)
        {
            try
            {
                HttpClient client;
                client = new HttpClient();
                client.MaxResponseContentBufferSize = 256000;
                var jsonString = JsonConvert.SerializeObject(lLProfileBO);
                var signupEmailData = new StringContent(jsonString, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(App.APIURL + " LL/LLEdit", signupEmailData);
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
        }



        private void nameChange(object sender, EventArgs e)
        {
            if (IsLLAddEntryVisible)
            {
                LLNameLabel.IsVisible = false;
                LLNameEntry.IsVisible = true;
                LLNameEntry.Text = LLNameLabel.Text;
                LLNameCheckedIcon.IsVisible = true;
                LLNameChng.IsVisible = false;
                IsLLAddEntryVisible = false;
            }
            else
            {
                LLNameLabel.IsVisible = true;
                LLNameEntry.IsVisible = false;
                IsLLAddEntryVisible = true;
                LLNameCheckedIcon.IsVisible = false;
                LLNameChng.IsVisible = true;
                LLProfileBO lLProfileBO = new LLProfileBO();
                lLProfileBO.LLName = "";
                LLUpdateAPI(lLProfileBO);
            }
        }

        private void emailChange(object sender, EventArgs e)
        {
            if (IsLLAddEntryVisible)
            {
                LLEmailLabel.IsVisible = false;
                LLEmailEntry.IsVisible = true;
                LLEmailEntry.Text = LLEmailLabel.Text;
                LLEmailCheckedIcon.IsVisible = true;
                LLEmailChng.IsVisible = false;
                IsLLAddEntryVisible = false;
            }
            else
            {
                LLEmailLabel.IsVisible = true;
                LLEmailEntry.IsVisible = false;
                IsLLAddEntryVisible = true;
                LLNameCheckedIcon.IsVisible = false;
                LLEmailChng.IsVisible = true;
                LLProfileBO lLProfileBO = new LLProfileBO();
                lLProfileBO.LLEmail = "";
                LLUpdateAPI(lLProfileBO);
            }
        }

        private void phoneNoChange(object sender, EventArgs e)
        {
            if (IsLLAddEntryVisible)
            {
                LLPhoneLabel.IsVisible = false;
                LLPhoneEntry.IsVisible = true;
                LLPhoneEntry.Text = LLPhoneLabel.Text;
                LLPhoneCheckedIcon.IsVisible = true;
                LLPhoneChng.IsVisible = false;
                IsLLAddEntryVisible = false;
            }
            else
            {
                LLPhoneLabel.IsVisible = true;
                LLPhoneEntry.IsVisible = false;
                IsLLAddEntryVisible = true;
                LLPhoneCheckedIcon.IsVisible = false;
                LLPhoneChng.IsVisible = true;
                LLProfileBO lLProfileBO = new LLProfileBO();
                lLProfileBO.LLPhone = Convert.ToInt64(LLPhoneEntry.Text);
                LLUpdateAPI(lLProfileBO);
            }
        }

        private void dobChange(object sender, EventArgs e)
        {
            if (IsLLAddEntryVisible)
            {
                LLDOBLabel.IsVisible = false;
                LLDOBEntry.IsVisible = true;
                LLDOBEntry.Date = DateTime.Now;
                LLDOBCheckedIcon.IsVisible = true;
                LLDOBChng.IsVisible = false;
                IsLLAddEntryVisible = false;
            }
            else
            {
                LLDOBLabel.IsVisible = true;
                LLDOBEntry.IsVisible = false;
                IsLLAddEntryVisible = true;
                LLDOBCheckedIcon.IsVisible = false;
                LLDOBChng.IsVisible = true;
                LLProfileBO lLProfileBO = new LLProfileBO();
                lLProfileBO.LLDOB = LLDOBEntry.Date;
                LLUpdateAPI(lLProfileBO);
            }
        }

        private void addressChange(object sender, EventArgs e)
        {
            if (IsLLAddEntryVisible)
            {
                LLADDLabel.IsVisible = false;
                LLAddEntry.IsVisible = true;
                LLAddEntry.Text = LLEmailLabel.Text;
                LLAddCheckedIcon.IsVisible = true;
                LLAddChng.IsVisible = false;
                IsLLAddEntryVisible = false;
            }
            else
            {
                LLADDLabel.IsVisible = true;
                LLAddEntry.IsVisible = false;
                IsLLAddEntryVisible = true;
                LLAddChng.IsVisible = false;
                LLAddChng.IsVisible = true;
                LLProfileBO lLProfileBO = new LLProfileBO();
                lLProfileBO.LLAddress = "";
                LLUpdateAPI(lLProfileBO);
            }
        }

        private void pwordChange(object sender, EventArgs e)
        {
            if (IsLLAddEntryVisible)
            {
                LLPassLabel.IsVisible = false;
                LLPassEntry.IsVisible = true;
                LLPassEntry.Text = LLEmailLabel.Text;
                LLPassCheckedIcon.IsVisible = true;
                LLPassChng.IsVisible = false;
                IsLLAddEntryVisible = false;
            }
            else
            {
                LLPassLabel.IsVisible = true;
                LLPassEntry.IsVisible = false;
                IsLLAddEntryVisible = true;
                LLPassCheckedIcon.IsVisible = false;
                LLPassChng.IsVisible = true;
                LLProfileBO lLProfileBO = new LLProfileBO();
                lLProfileBO.LLPassword = "";
                LLUpdateAPI(lLProfileBO);
            }
        }

        private async void AddPic1(object sender, EventArgs e)
        {
            {
                await TakeLLProfilePhotoAsync();
            }

            async Task TakeLLProfilePhotoAsync()
            {
                try
                {
                    var photo = await MediaPicker.CapturePhotoAsync();
                    await LoadLLProfilePhotoAsync(photo);
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

            async Task LoadLLProfilePhotoAsync(FileResult photo)
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

                LLProfilePhotoPath = newFile;
            }
            LLProfileBO lLProfileBO = new LLProfileBO();
            lLProfileBO.LLProfileImage = LLProfilePhotoPath;
            LLUpdateAPI(lLProfileBO);
        }
    }
}