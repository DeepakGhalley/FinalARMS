using CORE_BOL;
using CORE_BOL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
namespace CORE_DLL
{
    public interface IHouseDetail
    {
        IList<HouseAllocationVM> GetAll();
        Task<HouseAllocationVM> Details(int? id);
        Task<HouseRentDetailVM> GetDetails(int? id);
        int Save(HouseRentDetailVM obj);
        int Update(HouseRentDetailVM obj);
        Task Delete(int? id);
        Task DeleteConfirmed(int id);
        bool CheckExists(int id);
        bool DuplicateCheckOnSave(string HouseNo);
        bool DuplicateCheckOnUpdate(string HouseNo, int HouseDetailId);
        List<TaxPayerProfileModel> GetTaxPayer(string cid, string ttin);
        int SaveHouseAllocation(HouseAllocationVM obj);
        List<HouseRentDetailVM> GetHouseDetails(int? id);
        List<HouseAllocationVM> GetHouseAllocationDetail(int? id);
        List<HousePeriodVM> GetRenewDetails(int? id);
        int Terminate(HouseAllocationVM obj);
        IEnumerable<HouseRentDemandScheduleModule> GetHouseRentDemandScheduleMonthly(int Id, int year,string StartDate, string EndDate);

        long GenerateDemand(int HouseAllocationId, int pDays, int pMonth, int pYear, int ScheduleId, decimal Amount, int CreatedBy, int taxPayerId, int totalDays);
        List<TaxPayerProfileModel> fetchHouseRentDemandByCid(string cid, string ttin);
        List<HouseAllocationVM> fetchHouseRentDetails(int id);
        List<HouseAllocationVM> generateHouseRentDemand(int DemandNoId);
        List<HousePeriodVM> fetchHouseRentPeriod(int id);
        List<HouseRentDetailVM> GetRenewalHouseRentDetail(int? id); //House Renewal
        List<HouseAllocationVM> GetRenewalHouseRentAllocation(int? id); //House Renewal
        int SaveRenew(HousePeriodVM obj); //House Renewal


    }
}
