using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace PageProfile.Models
{
    internal class LLProfileModel:BaseViewModel
    {
        public ICommand LLPersonalDetailsBtnCmd { get; set; }
        public ICommand LLBookingDetailsBtnCmd { get; set; }
        public ICommand LLLandDetailsBtnCmd { get; set; }
        public ICommand LLBankDetailsBtnCmd { get; set; }
        public ICommand LLLogoutBtnCmd { get; set; }
        public ICommand BackBtnCmd { get; set; }
    }
}
