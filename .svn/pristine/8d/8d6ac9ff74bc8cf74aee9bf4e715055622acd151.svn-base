using CORE_BOL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CORE_DLL
{
   public  interface IModificationReason
    {

        IList<ModificationReasonVM> GetAll();
        int Save(ModificationReasonVM obj);
        Task<ModificationReasonVM> Details(int? id);
        int Update(ModificationReasonVM obj);
        Task Delete(int? id);
        Task DeleteConfirmed(int id);
        bool CheckExists(int id);
        bool DuplicateCheckOnSave(string ModificationReason);
        bool DuplicateCheckOnUpdate(string ModificationReason, int Id);

    }
}
