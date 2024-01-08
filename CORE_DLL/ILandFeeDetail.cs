using CORE_BOL;
using CORE_BOL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CORE_DLL
{
    public interface ILandFeeDetail
    {
        
        
        List<LedgerDemandVM> FetchlandOwnershipDetails(string Ttin, string Cid, string PlotNo, string ThramNo);
        List<LedgerDemandVM> PrintDemand(int TransactionId);
        List<LedgerDemandVM> PrintUser(int TransactionId);
        int Save(LandFeeDetailVM obj);
        List<LedgerDemandVM> FetchTaxDetails(long TaxPayerId);
        List<LedgerDemandVM> LandTransactionFeeRecepit(long TransactionId);
        List<LedgerDemandVM> fetchreceiptuser(long TransactionId);
       
    }
}
