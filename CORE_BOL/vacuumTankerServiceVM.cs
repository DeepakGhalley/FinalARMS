using CORE_BOL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CORE_BOL
{
    public class VacuumTankerServiceVM
    {
        public int VacuumTankerServiceId { get; set; }
        public long TransactionId { get; set; }
        public int? LandOwnershipId { get; set; }
       
        public int NoOfTrips { get; set; }
        public decimal Amount { get; set; }
        public string ContactName { get; set; }
        public string Name { get; set; }
        public string MobileNo { get; set; }
        public string EmailId { get; set; }
        public string ContactAddress { get; set; }
        public string G2cApplicationNo { get; set; }
        public int WorkLevelId { get; set; }
        public int CreatedBy { get; set; }
        public long RecepitId { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }

        

    }
}
