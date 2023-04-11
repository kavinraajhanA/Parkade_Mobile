using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace PageProfile.Models
{
    internal class UserMembershipModel:BaseViewModel
    {
        public ICommand BackBtnCmd { get; set; }
        public ICommand SilverBtnCmd { get; set; }
        public ICommand BronzeBtnCmd { get; set; }
        public ICommand GoldBtnCmd { get; set; }
    }
}
