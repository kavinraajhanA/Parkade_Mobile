using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace PageProfile.Models
{
    internal class UserLicenseDetailsModel:BaseViewModel
    {
        public ICommand UploadPhotoBtnCmd { get; set; }
        public ICommand UploadPhoto1BtnCmd { get; set; }
        public ICommand UpdateLicenseBtnCmd { get; set; }
    }
}
