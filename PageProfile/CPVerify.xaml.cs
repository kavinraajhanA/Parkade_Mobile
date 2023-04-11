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
    public partial class CPVerify : ContentPage
    {
        public CPVerify()
        {
            InitializeComponent();
        }

        private void CPverify1(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CPVerSuccess());
        }
    }
}