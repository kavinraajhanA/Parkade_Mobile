using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace PageProfile.Models
{
    internal class BookingConfirmationModel:BaseViewModel
    {
        public ICommand BackBtnCmd { get; set; }
        public ICommand ContinueBtnCmd { get; set; }
    }
}
