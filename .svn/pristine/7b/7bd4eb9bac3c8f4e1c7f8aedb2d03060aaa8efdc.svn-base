using CORE_BOL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CORE_DLL
{
    public interface IBfsFailedOnlineTransactionDetails
    {
        List<LedgerDemandVM> Search(string search);
        IList<LedgerDemandVM> GetDemandDetail(string id, DateTime paymentdat);
        IList<LedgerDemandVM> CheckDuplicatePayment(string id);
        long CreateLedger(LedgerDemandVM obj);
        long CreatePaymentLedger(LedgerPaymentLedgerModel obj);


    }
}
