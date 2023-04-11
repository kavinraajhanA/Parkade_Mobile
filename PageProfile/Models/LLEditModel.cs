using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace PageProfile.Models
{
    internal class LLEditModel:BaseViewModel
    {
        public ICommand BackBtnCmd { get; set; }
        public ICommand ChangePhotoSBtnCmd { get; set; }
        public ICommand ChangeNameBtnCmd { get; set; }
        public ICommand ChangeEmailBtnCmd { get; set; }
        public ICommand ChangePhoneBtnCmd { get; set; }
        public ICommand ChangeDobBtnCmd { get; set; }
        public ICommand ChangeAddressBtnCmd { get; set; }
        public ICommand ChangePasswordBtnCmd { get; set; }
    }
}
