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
    public partial class EditPage : ContentPage
    {
        string ProfilePhotoPath = "";
        bool IsNameEntryVisible = true;
        public EditPage()
        {
            InitializeComponent();
        }

       

        private async void AddPic(object sender, EventArgs e)
        { 
        {
            await TakeProfilePhotoAsync();
        }

        async Task TakeProfilePhotoAsync()
        {
            try
            {
                var photo = await MediaPicker.CapturePhotoAsync();
                await LoadProfilePhotoAsync(photo);
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

        async Task LoadProfilePhotoAsync(FileResult photo)
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

            ProfilePhotoPath = newFile;
        }
        UserProfileBO userProfileBO = new UserProfileBO();
        userProfileBO.UserProfileImage = ProfilePhotoPath;
        userUpdateAPI(userProfileBO);
    }

        private async void userUpdateAPI(UserProfileBO userProfileBO)
        {
            try
            {
                HttpClient client;
                client = new HttpClient();
                client.MaxResponseContentBufferSize = 256000;
                var jsonString = JsonConvert.SerializeObject(userProfileBO);
                var signupEmailData = new StringContent(jsonString, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(App.APIURL + "UserProfile/UserEdit", signupEmailData);
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
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }


        private void PersonalDetailsPage(object sender, EventArgs e)
        {
            Navigation.PushAsync(new personaldetails());
        }

      

        private void emailChange(object sender, EventArgs e)
        {
            if (IsNameEntryVisible)
            {
                EmailLabel.IsVisible = false;
                EmailEntry.IsVisible = true;
                EmailEntry.Text = EmailLabel.Text;
                EmailCheckedIcon.IsVisible = true;
                EmailChng.IsVisible = false;
                IsNameEntryVisible = false;
            }
            else
            {
                EmailLabel.IsVisible = true;
                EmailEntry.IsVisible = false;
                IsNameEntryVisible = true;
                EmailCheckedIcon.IsVisible = false;
                EmailChng.IsVisible = true;
                UserProfileBO userProfileBO = new UserProfileBO();
                userProfileBO.UserEmail = "";
                userUpdateAPI(userProfileBO);
            }
           

        }

        private void phoneNoChange(object sender, EventArgs e)
        {
            if (IsNameEntryVisible)
            {
                PhoneLabel.IsVisible = false;
                PhoneEntry.IsVisible = true;
                PhoneEntry.Text = PhoneLabel.Text;
                PhoneCheckedIcon.IsVisible = true;
                PhoneChng.IsVisible = false;
                IsNameEntryVisible = false;
            }
            else
            {
                PhoneLabel.IsVisible = true;
                PhoneEntry.IsVisible = false;
                IsNameEntryVisible = true;
                PhoneCheckedIcon.IsVisible = false;
                PhoneChng.IsVisible = true;
                UserProfileBO userProfileBO = new UserProfileBO();
                userProfileBO.UserPhone = Convert.ToInt64(PhoneEntry.Text);
                userUpdateAPI(userProfileBO);
            }
        }

        private void dobChange(object sender, EventArgs e)
        {
            if (IsNameEntryVisible)
            {
                DOBLabel.IsVisible = false;
                DOBEntry.IsVisible = true;
                DOBEntry.Date = DateTime.UtcNow;
                DOBCheckedIcon.IsVisible = true;
                DOBChng.IsVisible = false;
                IsNameEntryVisible = false;
            }
            else
            {
                DOBLabel.IsVisible = true;
                DOBEntry.IsVisible = false;
                IsNameEntryVisible = true;
                DOBCheckedIcon.IsVisible = false;
                DOBChng.IsVisible = true;
                UserProfileBO userProfileBO = new UserProfileBO();
                userProfileBO.UserDOB =DOBEntry.Date;
                userUpdateAPI(userProfileBO);
            }
        }

        private  void addressChange(object sender, EventArgs e)
        {
             if (IsNameEntryVisible)
            {
                AddLabel.IsVisible = false;
                AddEntry.IsVisible = true;
                AddEntry.Text = AddLabel.Text;
                AddCheckedIcon.IsVisible = true;
                AddChng.IsVisible = false;
                IsNameEntryVisible = false;
            }
            else
            {
                AddLabel.IsVisible = true;
                AddEntry.IsVisible = false;
                IsNameEntryVisible = true;
                AddCheckedIcon.IsVisible = false;
                AddChng.IsVisible = true;
                UserProfileBO userProfileBO = new UserProfileBO();
                userProfileBO.UserAddress = "";
                 userUpdateAPI(userProfileBO);
            }
        }


            private  void pwordChange(object sender, EventArgs e)
        {
            if (IsNameEntryVisible)
            {
                PassLabel.IsVisible = false;
                PassEntry.IsVisible = true;
                PassEntry.Text = PassLabel.Text;
                PassCheckedIcon.IsVisible = true;
                PassChng.IsVisible = false;
                IsNameEntryVisible = false;
            }
            else
            {
                PassLabel.IsVisible = true;
                PassEntry.IsVisible = false;
                IsNameEntryVisible = true;
                PassCheckedIcon.IsVisible = false;
                PassChng.IsVisible = true;
                UserProfileBO userProfileBO = new UserProfileBO();
                userProfileBO.UserPassword = "";
                userUpdateAPI(userProfileBO);
            }

        }

        private void nameChange(object sender, EventArgs e)
        {
            if(IsNameEntryVisible)
            {
                NameLabel.IsVisible = false;
                NameEntry.IsVisible = true;
                NameEntry.Text = NameLabel.Text;
                NameCheckedIcon.IsVisible = true;
                nameChng.IsVisible = false;
                IsNameEntryVisible = false;
            }
            else
            {
                NameLabel.IsVisible = true;
                NameEntry.IsVisible = false;
                IsNameEntryVisible = true;
                NameCheckedIcon.IsVisible = false;
                nameChng.IsVisible = true;
                UserProfileBO userProfileBO = new UserProfileBO();
                userProfileBO.UserName = "";
                userUpdateAPI(userProfileBO);
            }
        }
    }      
}
