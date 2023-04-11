using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace PageProfile.Models
{
    internal class ForgetPasswordModel:BaseViewModel
    {
        String _EnterPhoneNo;
        public String EnterPhoneNo
        {

            get { return _EnterPhoneNo; }
            set { SetProperty(ref _EnterPhoneNo, value); }


        }
        public ICommand VerifyBtnCmd { get; set; }

    }
}
