using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageProfile.BO
{
    public class BankingDetailsBO
    {
        public int BankingId { get; set; }
        public int LlId { get; set; }
        public string BankName { get; set; }
        public long AccountNumber { get; set; }
        public string AccountHolderName { get; set; }
        public string IFSCCode { get; set; }
        public long CardNumber { get; set; }
    }
}
