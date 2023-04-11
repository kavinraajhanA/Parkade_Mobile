using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace PageProfile.Models
{
    internal class LLLandDetailsModels:BaseViewModel
    {
        String _AvaliableSlots;
        String _LandSize;
        public String AvaliableSlots
        {

            get { return _AvaliableSlots; }
            set { SetProperty(ref _AvaliableSlots, value); }
           

        }
        public String LandSize
        {

            get { return _LandSize; }
            set { SetProperty(ref _LandSize, value); }


        }
        public ICommand BackBtnCmd { get; set; }
        public ICommand AddPhotoBtnCmd { get; set; }
        public ICommand AddPhoto1BtnCmd { get; set; }
        public ICommand SubmitBtnCmd { get; set; }
    }
}
