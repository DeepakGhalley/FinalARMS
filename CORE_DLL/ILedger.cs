using CORE_BOL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CORE_DLL
{
   public interface ILedger
    {
        IList<LedgerDemandVM> GetAllDemands(int id); 
       Task<IList<LedgerDemandVM>> GetDemandWithSearch(string DemandNo, string ConsumerNo);
        IList<LedgerDemandVM> GetDemandWithSearch1(string DemandNo, string Ttin);
        IList<LedgerDemandVM> GetpDemandWithSearch(string DemandNo, string Ttin);
        IList<LedgerDemandVM> GetmDemandWithSearch(string DemandNo, string Cid);
         IList<LedgerDemandVM> GetWaterConnectionDemand(string DemandNo, string G2cNo, string Ttin);
        IList<LedgerDemandVM> GetDemandDetail(string id);
        IList<LedgerDemandVM> CheckDuplicatePayment(string id);

        DemandCountModel GetDemandCount();
        long CreateLedger(LedgerDemandVM obj);
        long CreatePaymentLedger(LedgerPaymentLedgerModel obj);
        IList<LedgerDemandVM> PrintPaymentreceipt(int id);
        IList<LedgerDemandVM> PrintNewWaterPaymentreceipt(long RecepitId);
        List<LedgerDemandVM> printmetershifting(long RecepitId);
        IList<LedgerDemandVM> PrintWaterPaymentreceipt(int id);
        IList<LedgerDemandVM> fetchledgerdata(long RecepitId);
        List<LedgerDemandVM> fetchWatershifting(long RecepitId);
        IList<TranWaterConnectionModel> fetchWaterDetails(string ConsumerNo, int Year,int TransactionTypeId);
        IList<MiscellaneousRecordModel> fetchMiscellaneousdata(string Cid);
        IList<LedgerDemandVM> PrintDemand(long RecepitId);
        IList<LandOwneshipModel> FetchlanddetailsByCID(string Cid, string Ttin, string Year);
     
        IList<LedgerDemandVM> Printreceiptforpropertytax(int RecepitId);
        IList<LedgerDemandVM> fetchHouseDetailByCid(string cid, string ttin, int Year);
        IList<LedgerDemandVM> fetchStallDetailByCid(string cid, string ttin, int Year);
        IList<LedgerDemandVM> fetchLandLeaseDetailByCid(string cid, string ttin, int Year);
        IList<LedgerDemandVM> fetchParkingDetailByCid(string cid, string ttin, int Year);
        IList<LedgerDemandVM> GetLandTransactionFee(string DemandNo, string Ttin, string Cid);
        IList<LedgerDemandVM> fetchECDetail(string Name, string Cid);
        IList<LedgerDemandVM> fetchVendorRecepit(long ReceiptId);
        IList<LedgerDemandVM> fetchECRecepit(long ReceiptId);
        IList<LedgerDemandVM> PrintMiscellauenousreceipt(int id);
        IList<LedgerDemandVM> PrintHousereceipt(int id);
        IList<LedgerDemandVM> Printstallreceipt(int id);
        IList<LedgerDemandVM> PrintLandLeasereceipt(int id);
        IList<LedgerDemandVM> PrintParkingFeereceipt(int id);
        IList<LedgerDemandVM> PrintPaymentModes(int ReceiptId);
        IList<LedgerDemandVM> LandTransactionFeeRecepit(long RecepitId);
        IList<LedgerDemandVM> PrintDuplicatePaymentModes(long TransactionId);
        IList<LedgerDemandVM> fetchreceiptuser(int RecepitId);
        IList<LedgerDemandVM> fetchDreceiptuser(long TransactionId);

    Task< decimal> GetWaterConnectionId(string DemandNo, string ConsumerNo);

        List<LedgerDemandVM> fetchLandTransactions(string Ttin, string Cid);
        List<LedgerDemandVM> landtransactionRecepit(long ReceiptId);
        List<LedgerDemandVM> creatorlandtransactions(long TransactionId);
        List<LedgerDemandVM> SewerageConnectionRecepit(long RecepitId);
        List<LedgerDemandVM> UnScheduledParkingRecordrecepit(long RecepitId);
        List<LedgerDemandVM> GetUnScheduledParkingRecord(string DemandNo, string Cid);
        List<LedgerDemandVM> ConstructionApprovalApplicationFeeDetailRecepit(long RecepitId);
        List<LedgerDemandVM> FetchConstructionApprovalApplicationFeeDetail(string DemandNo, string Ttin, string Cid);
        List<LedgerDemandVM> ConstructionApprovalRecepit(long RecepitId);
        List<LedgerDemandVM> FetchConstructionApproval(string DemandNo, string Ttin, string Cid);
        IList<OnlinePaymentCheckModel> FetOnlinePaymentStatus(string DemandNoIds);
        public IList<LedgerDemandVM> PrintNames(int id);
        List<LedgerDemandVM> GetvacuumtankerDemandWithSearch(string DemandNo, string Name);
        IList<LedgerDemandVM> PrintDemand(int id);
        IList<LedgerDemandVM> PrintEC(long RecepitId);
        IList<LedgerDemandVM> fetchwatertax(long RecepitId);
        IList<LedgerDemandVM> Watercharges(long RecepitId);
        List<VacuumTankerServiceVM> fetchVacuumtanker(string RecepitNo, string Name);
        IList<LedgerDemandVM> GetECDemandWithSearch(string DemandNo, string Cid);
    }
}
