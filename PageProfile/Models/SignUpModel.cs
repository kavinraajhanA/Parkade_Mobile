using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace PageProfile.Models
{
    internal class SignUpModel : BaseViewModel
    {
        String _Name;
        String _Email;
        String _MobileNumber;
        String _DOB;
        String _Pssword;
        String _ConfirmPassword;
        String _Address;
        String _LicensePhoto;
        String _ValidTillDate;
        public ICommand CreateAccountBtnCmd { get; set; }
        public ICommand SignInBtnCmd { get; set; }
        public string Name
        {
            get { return _Name; }
            set { SetProperty(ref _Name, value); }

        }
        public string Email
        {
            get { return _Email; }
            set { SetProperty(ref _Email, value); }

        }
        public string MobileNumber
        {
            get { return _MobileNumber; }
            set { SetProperty(ref _MobileNumber, value); }

        }
        public string DOB
        {
            get { return _DOB; }
            set { SetProperty(ref _DOB, value); }

        }
        public string Password
        {
            get { return _Pssword; }
            set { SetProperty(ref _Pssword, value); }

        }

        public string ConfirmPassword
        {
            get { return _ConfirmPassword; }
            set { SetProperty(ref _ConfirmPassword, value); }

        }
        public string Address
        {
            get{ return _Address; }
            set{ SetProperty(ref _Address, value); }
            }
public string LicensePhoto
        {
    get{ return _LicensePhoto; }
    set{ SetProperty(ref _LicensePhoto, value); }
}
public string ValidTillDate
        {
    get{ return _ValidTillDate; }
    set{ SetProperty(ref _ValidTillDate, value); }
}
    }
}
