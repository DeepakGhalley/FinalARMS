using CORE_BOL;
using CORE_BOL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CORE_DLL
{
    public interface ILandLease
    {
        IList<LandLeaseModel> GetAll();
        Task<LandLeaseModel> Details(int? id);
        Task<LandLeasePeriodVM> GetDetails(int? id);
        Task<LandLeaseModel> GetTerminateDetails(int? id);
        int Save(LandLeaseModel obj);
        int SaveExtension(LandLeasePeriodVM obj);
        int Update(LandLeaseModel obj);
        int UpdateTermination(LandLeaseModel obj);
        List<LandLeaseModel> fetchLandOwnerShipDetails(string Cid, string Ttin, string plotno);
        List<LandLeaseModel> fetchTaxPayerAsync(string cid, string ttin);
        Task Delete(int? id);
        Task DeleteConfirmed(int id);

        bool CheckExists(int id);
        List<LandLeaseModel> fetchTaxPayer(string cid, string ttin);
        List<TaxPayerProfileModel> fetchTaxPayerDetail(string cid, string ttin);
        int SaveLandDetail(LandDetailModel obj);
        int SaveLandLease(LandDetailModel obj);
        int SaveLandPeriod(LandLeasePeriodVM obj);
        List<MstLandUseSubCategory> fetchLUSC(int id);
        List<LandLeaseModel> LandLeaseDetails(int id);
        IEnumerable<VendorDemandScheduleModel> GetVendorDemandSchedule(int Id, int yr, string StartDate, string EndDate);
        public IEnumerable<LongtermleaseVM> GetLongTermLandLease(int Id, string StartDate, string EndDate);
        long GenerateDemand(int landLeaseId, int pDays, int pMonth, int pYear, int ScheduleId, decimal Amount, int CreatedBy, int taxPayerId, int taxId, int totalDays, string IDate);
        List<LandLeaseModel> GetDemand(int DemandNoId);
        bool DuplicateCheckOnUpdate();
        IList<LandDetailModel> GetPlotNo(string plotNo);
        long Savelongterm(LandDetailModel obj);
        long SaveLandLeaselongterm(LandDetailModel obj);
        List<LandLeaseModel> Listall();
        List<LandLeaseModel> GetDemandlongterm(long TransactionId);
        public List<LandLeaseModel> Temporary();
        public List<LandLeaseModel> Shortterm();
        public List<LandLeaseModel> Longterm();
        List<LandLeaseModel> DisplayExistingLease(int TaxPayerId);
        List<LandLeaseModel> GetLeaseDetailsForUpdate(int LandLeaseId);
        int UpdateLandLease(LandLeaseModel obj);


        // bool DuplicateCheckOnSave(int LandLeaseId);
        //bool DuplicateCheckOnUpdate(int LandLeaseId, int BillingScheduleId, int LandDetailId, int TaxPayerId, int LeaseTypeId, int TaxPeriodId, int LeaseActivityTypeId);
    }
}
