using CORE_BOL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CORE_DLL
{
    public interface ITertiaryAccountHead
    {
        IList<TertiaryAccountHeadModel> GetAll();
        Task<TertiaryAccountHeadModel> Details(int? id);
        int Save(TertiaryAccountHeadModel obj);
        int Update(TertiaryAccountHeadModel obj);
        Task Delete(int? id);
        Task DeleteConfirmed(int id);
        bool CheckExists(int id);
        bool DuplicateCheckOnSave(string TertiaryAccountHeadName);
        bool DuplicateCheckOnUpdate(string TertiaryAccountHeadName, int TertiaryAccountHeadId, int SecondaryAccountHeadId);
    }
}
