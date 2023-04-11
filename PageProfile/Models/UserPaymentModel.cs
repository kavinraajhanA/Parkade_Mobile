using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace PageProfile.Models
{
    internal class UserPaymentModel:BaseViewModel
    {
        public ICommand BackBtnCmd { get; set; }
        public ICommand PayBtnCmd { get; set; }
    }
}
