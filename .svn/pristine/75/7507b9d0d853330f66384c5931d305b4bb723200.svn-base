using CORE_BOL;
using CORE_BOL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CORE_DLL
{
    public interface IECDetail
    {
        IList<ECDetailModel> GetAll();
        List<ECDetailModel> GetApplicantDetails(string CIDLicenceNo, string ApplicantName);
        List<ECDetailModel> GetECDetails(int ApplicantId);
        List<ECDetailModel> GetECStatus(int ECDetailId);
        List<ECDetailModel> GetECDetailView(int ECDetailId);
        List<ECDetailModel> GetECDetailsForUpdate(int ECDetailId);
        int SaveECDetail(ECDetailModel obj);
        int GenerateECDemand(ECDetailModel obj);
        int SaveApprovalStatus(ECDetailModel obj);
        int UpdateECDetail(ECDetailModel obj);
        int SaveProjectStatus(ECDetailModel obj);
        List<ECDetailModel> GetECDemand(int DemandNoId);
        List<ECDetailModel> GetUserName(int DemandNoId);


    }
}
