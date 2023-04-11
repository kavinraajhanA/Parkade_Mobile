using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace PageProfile.Models
{
    internal class LogInModel:BaseViewModel
    {
        String _Username;
        String _Password;
        public ICommand LoginBtnCmd { get; set; }
        public String Username
        {
            get { return _Username; }
            set { SetProperty(ref _Username, value); }
       
       }
        public string Password
        {
            get { return _Password; }
            set { SetProperty(ref _Password, value); }
        }
    }
}
