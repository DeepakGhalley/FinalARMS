using CORE_BOL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CORE_DLL
{
    public interface ILandLeaseDemandDetail
    {
        IList<LandLeaseDemandDetailModel> GetAll();
        Task<LandLeaseDemandDetailModel> Details(int? id);
        int Save(LandLeaseDemandDetailModel obj);
        Task Delete(int? id);
        Task DeleteConfirmed(int id);
        bool CheckExists(int id);
        List<LandLeaseDemandDetailModel> fetchLandAndLeaseDetails(string Cid, string Ttin);

    }
}
