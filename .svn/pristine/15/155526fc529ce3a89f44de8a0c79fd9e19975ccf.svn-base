using CORE_BOL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CORE_DLL
{
    public interface ISecondaryAccountHead
    {
        IList<SecondaryAccountHeadModel> GetAll();
        Task<SecondaryAccountHeadModel> Details(int? id);
        int Save(SecondaryAccountHeadModel obj);
        int Update(SecondaryAccountHeadModel obj);
        Task Delete(int? id);
        Task DeleteConfirmed(int id);
        bool CheckExists(int id);
        bool DuplicateCheckOnSave(string SecondaryAccountHeadName);
        bool DuplicateCheckOnUpdate(string SecondaryAccountHeadName, int PrimaryAccountHeadId, int SecondaryAccountHeadId);
    }
}
