using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace PageProfile.Models
{
    internal class LLBankDetailsModel:BaseViewModel
    {
        String _BankName;
        String _AccountHolderName;
        String _CardNumber;
        String _AccountNumber;
        String _IFSCCode;
        public String BankName
        {

            get { return _BankName; }
            set { SetProperty(ref _BankName, value); }


        }
        
        public String AccountHolderName
        {

            get { return _AccountHolderName; }
    
            set { SetProperty(ref _AccountHolderName, value); }


        }
        public String CardNumber
        {

            get { return _CardNumber; }
            set { SetProperty(ref _CardNumber, value); }


        }
        public String AccountNumber
        {

            get { return _AccountNumber; }
            set { SetProperty(ref _AccountNumber, value); }


        }
        public String IFSCCode
        {

            get { return _IFSCCode; }
            set { SetProperty(ref _IFSCCode , value); }


        }
        public ICommand BackBtnCmd { get; set; }
        public ICommand SubmitBtnCmd { get; set; }
        public ICommand EditBankNameBtnCmd { get; set; }
        public ICommand EditAccountHolderNameBtnCmd { get; set; }
        public ICommand EditCardNumberBtnCmd { get; set; }
        public ICommand EditAccountNumberBtnCmd { get; set; }
        public ICommand EditIFSCCodeBtnCmd { get; set; }
    }
}
