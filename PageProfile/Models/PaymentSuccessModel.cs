using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace PageProfile.Models
{
    internal class PaymentSuccessModel:BaseViewModel
    {
        public ICommand BackToHomeBtnCmd { get; set; }
    }
}
