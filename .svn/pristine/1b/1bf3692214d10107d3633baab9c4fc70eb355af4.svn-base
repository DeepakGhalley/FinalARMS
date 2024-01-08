using CORE_BOL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CORE_DLL
{
    public interface IOnlinePayment
    {
        //for Online Property Tax Payment
        List<LedgerDemandVM> GetDemandDetail(string id);
        IList<OnlinePropertyTaxPaymentVM> GetDemandWithSearch(string ttin,string cid);

        //for Online Water Bill Payment
        List<OnlineWaterBillPaymentVM> GetDemandDetailWaterBill(string id);
        List<OnlineWaterBillPaymentVM> GetDemandWithSearchWaterBill(string ConsumerNo);
      Task <IEnumerable<menuvm>> GetMenu();
    }
}
