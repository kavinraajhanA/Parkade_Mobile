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
    public partial class LLPersonalDetails : ContentPage
    {
        LocalDatabase LLlocalDatabase = new LocalDatabase();
        public LLPersonalDetails()
        {
            InitializeComponent();
            var currLLUser = LLlocalDatabase.LLGetUserProfile();
            lLname.Text = currLLUser.LLName;
            lLemail.Text = currLLUser.LLEmail;
            lLPhone.Text = currLLUser.LLPhone.ToString();
            lLDOB.Text = currLLUser.LLDOB.ToString();
            lLadd.Text = currLLUser.LLAddress;
        }

        private void editDetails(object sender, EventArgs e)
        {
            Navigation.PushAsync(new LLEditPage());
        }

        private void PrevProfilePage(object sender, EventArgs e)
        {
            Navigation.PushAsync(new LLProfille());
        }
    }
}