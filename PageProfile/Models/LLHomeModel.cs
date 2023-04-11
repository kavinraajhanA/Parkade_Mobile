using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace PageProfile.Models
{
    internal class LLHomeModel:BaseViewModel
    {
        public ICommand LLProfileBtnCmd { get; set; }
        public ICommand AddLandDetailsBtnCmd { get; set; }
        public ICommand MenuBtnCmd { get; set; }

    }
}
