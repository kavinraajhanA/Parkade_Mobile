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
    public partial class LLBankDetails : ContentPage
    {
        public LLBankDetails()
        {
            InitializeComponent();
        }

        private void PrevProfilePage(object sender, EventArgs e)
        {
            Navigation.PushAsync(new LLProfille());
        }

        private async void Submit(object sender, EventArgs e)
        {
            BankingDetailsBO bankingDetailsBO = new BankingDetailsBO();
            bankingDetailsBO.AccountHolderName = Acc_Holder_Name.Text;
            bankingDetailsBO.BankName = Bank_Name.Text;
            bankingDetailsBO.AccountNumber = Convert.ToInt64(Acc_Num.Text);
            bankingDetailsBO.CardNumber = Convert.ToInt64(Card_Number.Text);
            bankingDetailsBO.IFSCCode = IFSC_Code.Text;

            HttpClient client;
            client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;
            var jsonString = JsonConvert.SerializeObject(bankingDetailsBO);
            var signupEmailData = new StringContent(jsonString, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync(App.APIURL + "LL/LLBankDetails", signupEmailData);
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

            await Navigation.PushAsync(new LLProfille());
        }
    }
}