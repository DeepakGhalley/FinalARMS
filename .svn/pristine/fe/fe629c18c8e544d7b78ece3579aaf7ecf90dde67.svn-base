using CORE_BOL;
using CORE_BOL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
namespace CORE_DLL
{
    public interface IStallDetail
    {
        IList<StallAllocationVM> GetAll();
        Task<StallAllocationVM> Details(int? id);
        Task<StallDetailVM> GetDetails(int? id);
        Task<StallDetailVM> GetPDetails(int? id);
        int Save(StallDetailVM obj);
        int Update(StallDetailVM obj);
        Task Delete(int? id);
        Task DeleteConfirmed(int id);
        bool CheckExists(int id);

       // bool DuplicateCheckOnSave(string StallNo);
        bool DuplicateCheckOnUpdate(int StallDetailId);
        List<TaxPayerProfileModel> GetTaxPayer(string cid, string ttin);
        int SaveStallAllocation(StallAllocationVM obj);
        List<StallDetailVM> GetStallDetails(int? id);
        List<StallAllocationVM> GetStallAllocationDetail(int? id);
        List<StallPeriodVM> GetRenewDetails(int? id);
        int SaveRenew(StallPeriodVM obj);
        int Terminate(StallAllocationVM obj);
        public int PUpdate(StallDetailVM obj);
        //IEnumerable<StallDetailDemandVM> GetVendorDemandSchedule(int Id, string StartDate, string EndDate);
        //List<StallDetailDemandVM> fetchStallDetails(int id);
        //List<StallDetailDemandVM> generateStallDetailDemand(int demandNoId);
        //List<StallDetailDemandVM> fetchStallDetailPeriod(int id);
        //long GenerateDemand(int StallDemandDetailId, int pMonth, int pYear, int ScheduleId, decimal Amount, int taxPayerId, int StallDetailId);

        List<TaxPayerProfileModel> GetTaxPayerProfile(string Cid, string Ttin);
        List<TaxPayerProfileModel> fetchStallRentDemandByCid(string cid, string ttin);
        List<StallDetailVM> fetchStallRentDetails(int id);
        IEnumerable<StallRentDemandScheduleModel> GetStallDemandScheduleMonthly(int Id, int yr, string StartDate, string EndDate);
        long GenerateDemand(int stallAllocationId, int pDays, int pMonth, int pYear, int ScheduleId, decimal Amount, int CreatedBy, int taxPayerId, int totalDays, int StallTypeId);
        List<StallDetailVM> generateStallRentDemand(int DemandNoId);
        List<StallDetailVM> GetUserName(int DemandNoId);
        List<StallDetailVM> GetRenewalStallDetail(int? id); //Stall Renewal
        List<StallAllocationVM> GetRenewalStallAllocation(int? id); //Stall Renewal
        List<StallAllocationVM> GetStartDateEndDate(int? id);
        IEnumerable<StallRentDemandScheduleModel> GetStallDemandScheduleYearly(int Id, string StartDate, string EndDate); //Demand For Yearly
        IEnumerable<StallRentDemandScheduleModel> GetStallDemandScheduleQuarterly(int Id, string StartDate, string EndDate); //Demand For Yearly
        //bool DuplicateCheckOnUpdate();





    }
}
