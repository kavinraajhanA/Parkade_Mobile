using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace PageProfile.Models
{
    internal class UserVehicleModel:BaseViewModel
    {
        String _VechicleNumber;
        String _BrandName;
        String _TypeModel;
        String _Colour;
        public String VechicleNumber
        {
            
            get { return _VechicleNumber; }
            set { SetProperty(ref _VechicleNumber, value); }

        }
        public String BrandName
        { 
            
            get { return _BrandName; }
            set { SetProperty(ref _BrandName, value); }

        }
        public String TypeModel
        { 

            get { return _TypeModel; }
            set { SetProperty(ref _TypeModel, value); }

        }
        public String Colour
        {

            get { return _Colour; }
            set { SetProperty(ref _Colour, value); }

        }
        public ICommand BackBtnCmd { get; set; }
        public ICommand ContinueBtnCmd { get; set; }
        public ICommand ChangeVehiclePhotoBtnCmd { get; set; }
    }
}
