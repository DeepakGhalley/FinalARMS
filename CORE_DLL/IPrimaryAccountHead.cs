using CORE_BOL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CORE_DLL
{
    public interface IPrimaryAccountHead
    {
        IList<PrimaryAccountHeadModel> GetAll();
        Task<PrimaryAccountHeadModel> Details(int? id);
        int Save(PrimaryAccountHeadModel obj);
        int Update(PrimaryAccountHeadModel obj); 
        Task Delete(int? id);
        Task DeleteConfirmed(int id);
        bool CheckExists(int id);
        bool DuplicateCheckOnSave(string PrimaryAccountHeadName);
        bool DuplicateCheckOnUpdate(string PrimaryAccountHeadName, int PrimaryAccoutHeadId);
    }
}
