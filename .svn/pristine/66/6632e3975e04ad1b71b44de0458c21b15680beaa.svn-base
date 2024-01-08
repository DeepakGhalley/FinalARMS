using CORE_BOL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CORE_DLL
{
    public interface IParkingFee
    {
        IList<ParkingFeeVM> GetAll();
        //IList<ParkingFeePeriodVM> GetParkingFeeDemand();
        Task<ParkingFeeVM> Details(int? id);
        List<TaxPayerProfileModel> fetchParkingFeeDemandByCid(string cid, string ttin);
        List<ParkingFeeVM> fetchParkingFeeDetails(int id);
        List<ParkingFeeVM> generateParkingFeeDemand(int DemandNoId);
        List<ParkingFeePeriodVM> fetchParkingFeePeriod(int id);
        int Save(ParkingFeeVM obj);
        int Update(ParkingFeeVM obj);
        int Terminate(ParkingFeeVM obj);
        int Extension(ParkingFeePeriodVM obj);
        Task Delete(int? id);
        Task DeleteConfirmed(int id);
        bool CheckExists(int id);
        IEnumerable<VendorDemandScheduleModel> GetVendorDemandSchedule(int Id, int yr, string StartDate, string EndDate);
        long GenerateDemand(int ParkingFeeDetailId, int pDays, int pMonth, int pYear, int ScheduleId, decimal Amount, int CreatedBy, int taxPayerId, int totalDays);
        bool DuplicateCheckOnUpdate();


    }
}
