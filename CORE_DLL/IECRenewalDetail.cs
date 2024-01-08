using CORE_BOL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CORE_DLL
{
    public interface IECRenewalDetail
    {
        IList<ECRenewalDetailModel> GetAll();
        Task<ECRenewalDetailModel> Details(int? id);
        Task Delete(int? id);
        Task DeleteConfirmed(int id);
        List<ECDetailModel> fetchECRenewalByCid(string cid, string applicantname);
        List<ECDetailModel> GetECDetails(int ApplicantId);
        List<ECRenewalDetailModel> GetECRenewalDetails(int ECDetailId);
        int SaveECRenewal(ECRenewalDetailModel obj);
        List<ECDetailModel> GetECDemand(int DemandNoId);
        List<ECDetailModel> GetUserName(int DemandNoId);
        long GenerateECDemand(ECDetailModel obj);

    }
}
