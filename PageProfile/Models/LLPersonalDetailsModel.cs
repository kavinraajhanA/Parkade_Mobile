using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace PageProfile.Models
{

    internal class LLPersonalDetailsModel:BaseViewModel
    {
        public ICommand EditBtnCmd { get; set; }
        public ICommand BackBtnCmd { get; set; }
    }
}
