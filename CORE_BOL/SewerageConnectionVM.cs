using System;
using System.Collections.Generic;
using System.Text;

namespace CORE_BOL
{
   public class SewerageConnectionVM
    {
        public int SewerageConnectionId { get; set; }
        public long TransactionId { get; set; }
        public decimal Amount { get; set; }
        public string G2CApplicationNo { get; set; }
        public string MobileNo { get; set; }
        public string ContactAddress { get; set; }
        public string PlotNo { get; set; }
        public string TTIN { get; set; }
        public int LandOwnershipId { get; set; }
    }
}
