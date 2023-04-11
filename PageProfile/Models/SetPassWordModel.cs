using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace PageProfile.Models
{
    internal class SetPassWordModel:BaseViewModel
    {

      
        String _NewPassword;
        String _ConfirmPassword;
        public ICommand NextBtnCmd { get; set; }
        public String NewPassword
        {

            get { return _NewPassword; }
            set { SetProperty(ref _NewPassword, value); }


        }
        
        public String ConfirmPassword
        {

            get { return _ConfirmPassword; }
            set { SetProperty(ref _ConfirmPassword, value); }


        }
    }
}
