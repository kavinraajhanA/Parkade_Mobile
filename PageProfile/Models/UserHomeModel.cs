using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace PageProfile.Models
{

    internal class UserHomeModel : BaseViewModel
    {
        string _Search;
        public ICommand UserProfileBtnCmd { get; set; }
        public ICommand AvailableSlotBtnCmd { get; set; }
        public ICommand MenuBtnCmd { get; set; }

        public ICommand FilterBtnCmd { get; set; }
        public string Search
        {
            get { return _Search; }
            set { SetProperty(ref _Search, value); }




        }

    }
}
