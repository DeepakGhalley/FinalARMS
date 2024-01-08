using CORE_BOL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CORE_DLL
{
    public interface IVacuumTankerService

    {
        IList<VacuumTankerServiceVM> GetAll();
        long Save(VacuumTankerServiceVM obj);
        IList<TaxPayerProfileModel> GetTaxpayer(string Cid, String Ttin);
        IList<LedgerDemandVM> PrintDemand(int id);
    }
}
