using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace PageProfile.Models
{
    internal class UserProfileModel : BaseViewModel
    {
        public ICommand BackBtnCmd { get; set; }
        public ICommand PersonalDetailsBtnCmd { get; set; }
        public ICommand BookingDetailsBtnCmd { get; set; }
        public ICommand LicenseDetailsBtnCmd { get; set; }
        public ICommand PrimeDetailsBtnCmd { get; set; }
        public ICommand LogOutBtnCmd { get; set; }
    }
}
