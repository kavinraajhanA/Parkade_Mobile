using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace PageProfile.Models
{

    internal class ParkingDetailsModel:BaseViewModel
    {
        public ICommand BookHoursBtnCmd { get; set; }
        public ICommand BookDaysBtnCmd { get; set; }

    }
}
