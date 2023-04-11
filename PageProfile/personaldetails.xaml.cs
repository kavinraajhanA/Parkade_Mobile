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
    public partial class personaldetails : ContentPage
    {
        LocalDatabase localDatabase = new LocalDatabase();
        public personaldetails()
        {
            InitializeComponent();
            var currUser = localDatabase.GetUserProfile();
            userName.Text = currUser.UserName;
            userEmail.Text = currUser.UserEmail;
            userDOB.Text = currUser.UserDOB.ToString();
            userPhoneNo.Text = currUser.UserPhone.ToString();
            userAddress.Text = currUser.UserAddress;
        }

        private void PrevProfilePage(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MainPage());
        }

        private void editDetails(object sender, EventArgs e)
        {
            Navigation.PushAsync(new EditPage());
        }
    }
}