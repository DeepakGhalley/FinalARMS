using CORE_BOL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CORE_BOL
{
    public class BuildingOwnershipVM
    {
        public int BuildingOwnershipId { get; set; }
        public int NumberOfFloors { get; set; }
        public int? YearOfConstruction { get; set; }
        public int LandOwnershipId { get; set; }
        public  string ThramNo { get; set; }
        public int BuildingDetailId { get; set; }
        public decimal BuildupArea { get; set; }
        public string BuildingNo { get; set; }
        public string storyType { get; set; }
        public string name { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string Ids { get; set; }
        public string BUID { get; set; }

        public virtual MstBuildingDetail BuildingDetail { get; set; }
        public virtual TblLandOwnershipDetail LandOwnership { get; set; }
    }
}
