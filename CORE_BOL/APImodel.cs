using System;
using System.Collections.Generic;
using System.Text;

namespace CORE_BOL
{
   public class APImodel
    {
        public class ApiTransactionPostApproval
        {

            public string thromde { get; set; }
            public string thromdeVillage { get; set; }
            public string transactionType { get; set; }
            public string party { get; set; }
            public string thram { get; set; }
            public string ownershipType { get; set; }
            public string ownerCID { get; set; }
            public string ownerName { get; set; }
            public string plotID { get; set; }
            public string area { get; set; }
            //     public string transactionArea { get; set; }
            public string landValue { get; set; }
            public string buildingValue { get; set; }
            public string subdivisionFee { get; set; }
            public string demarcationFee { get; set; }
            public string lagthramFee { get; set; }
            public string totalPayable { get; set; }


            public class ApiTransactionPostApprovals
            {
                public List<ApiTransactionPostApproval> LandTransactionDetail { get; set; }
            }

            public class RootApiTransactionPostApprovals
            {
                public ApiTransactionPostApproval LandTransactionDetails { get; set; }
            }

        }
        
        
        public class LandTransactionDetail
        {
            public string thromde { get; set; }
            public string thromdeVillage { get; set; }
            public string transactionType { get; set; }
            public string party { get; set; }
            public string thram { get; set; }
            public string ownershipType { get; set; }
            public string ownerCID { get; set; }
            public string ownerName { get; set; }
            public string plotID { get; set; }
            public string plotArea { get; set; }
            public string transactionArea { get; set; }
            public string landValue { get; set; }
            public string buildingValue { get; set; }
            public string subdivisionFee { get; set; }
            public string demarcationFee { get; set; }
            public string lagthramFee { get; set; }
            public string totalPayable { get; set; }
            public int TaxPayerId { get; set; }
            public int LandOwnershipId { get; set; }
            public class LandTransactionDetails
            {
                public List<LandTransactionDetail> LandTransactionDetail { get; set; }
            }

            public class RootLandTransactionDetails
            {
                public LandTransactionDetails LandTransactionDetails { get; set; }
            }
        }

        public class LandPostTransactionDetail
        {
            public string thromde { get; set; }
            public string thromdeVillage { get; set; }
            public string transactionType { get; set; }
            public string party { get; set; }
            public string thram { get; set; }
            public string ownershipType { get; set; }
            public string ownerCID { get; set; }
            public string ownerName { get; set; }
            public string plotID { get; set; }
            public string plotArea { get; set; }
            public string transactionArea { get; set; }
            public string landValue { get; set; }
            public string buildingValue { get; set; }
            public string subdivisionFee { get; set; }
            public string demarcationFee { get; set; }
            public string lagthramFee { get; set; }
            public string totalPayable { get; set; }
            public class LandTransactionDetails
            {
                public List<LandTransactionDetail> LandTransactionDetail { get; set; }
            }

            public class RootLandTransactionDetails
            {
                public LandTransactionDetails LandTransactionDetails { get; set; }
            }
        }
        public class LandDetailByPlotNoEsakor
        {
            public string dzongkhagOrThromde { get; set; }
            public string gewogOrThromdeVillage { get; set; }
            public string thramNumber { get; set; }
            public string ownerName { get; set; }
            public string ownerCid { get; set; }
            public string ownershipType { get; set; }
            public string plotId { get; set; }
            public string plotNetArea { get; set; }
            public string landTypeOrPrecinct { get; set; }
            public string precinctCode { get; set; }
            public string landLocationFlag { get; set; }
            public string plotAreaUnit { get; set; }
            public string lapName { get; set; }
            public string demkhongName { get; set; }
            public class LandTransactionDetails
            {
                public List<LandTransactionDetail> LandTransactionDetail { get; set; }
            }

            public class RootLandTransactionDetails
            {
                public LandTransactionDetails LandTransactionDetails { get; set; }
            }
        }
        public class eSakorLandJointOwners
        {
            public string thramNumber { get; set; }
            public string jointOwnerName { get; set; }
            public string jointOwnerCID { get; set; }
            public string plotId { get; set; }
            public string plotNetArea { get; set; }
        
           
        }

        public class CitizenDetail
        {
            public string cid { get; set; }
            public object country { get; set; }
            public string dob { get; set; }
            public string fatherName { get; set; }
            public string firstIssuedDate { get; set; }
            public string firstName { get; set; }
            public string gender { get; set; }
            public string householdNo { get; set; }
            public string lastName { get; set; }
            public object middleName { get; set; }
            public string mobileNumber { get; set; }
            public string motherName { get; set; }
            public string occupation { get; set; }
            public string dzongkhagId { get; set; }
            public string dzongkhagName { get; set; }
            public string gewogId { get; set; }
            public string gewogName { get; set; }
            public string houseNo { get; set; }
            public string thramNo { get; set; }
            public string villageSerialNo { get; set; }
            public string villageName { get; set; }
            public object placeOfBirth { get; set; }
            public string firstDzoName { get; set; }
            public object middleDzoName { get; set; }
            public string lastDzoName { get; set; }
            public string religion { get; set; }
            public string qualification { get; set; }
        }

        public class CitizenDetailsResponse
        {
            public List<CitizenDetail> citizenDetail { get; set; }
        }

        public class Root
        {
            public CitizenDetailsResponse citizenDetailsResponse { get; set; }
        }


    }
}
