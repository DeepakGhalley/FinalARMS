using CORE_BOL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CORE_DLL
{
    public interface IApplicantDetails
    {
        IList<ApplicantdetailModel> GetAll();
        Task<ApplicantdetailModel> Details(int? id);
        int Save(ApplicantdetailModel obj);
        int Update(ApplicantdetailModel obj);
        Task Delete(int? id);
        Task DeleteConfirmed(int id);
        bool CheckExists(int id);
        bool DuplicateCheckOnSave(string CID);
        bool DuplicateCheckOnUpdate(string CID, int Id);
    }
}
