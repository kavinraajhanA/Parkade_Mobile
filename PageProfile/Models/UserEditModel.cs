using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace PageProfile.Models
{
    internal class UserEditModel:BaseViewModel
    {
        public ICommand EditPhotoBtnCmd { get; set; }
        public ICommand ChangeNameBtnCmd { get; set; }
        public ICommand ChangeEmailBtnCmd { get; set; }
        public ICommand ChangePhoneNoBtnCmd { get; set; }
        public ICommand ChangeDOBBtnCmd { get; set; }
        public ICommand ChangeAddressBtnCmd { get; set; }
        public ICommand ChangePasswordBtnCmd { get; set; }
    }
}
