using CORE_BOL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CORE_DLL
{
    public interface ITaxMaster
    {
        IList<TaxMasterVM> GetAll();
        Task<TaxMasterVM> Details(int? id);
        int Save(TaxMasterVM obj);
        int Update(TaxMasterVM obj);
        Task Delete(int? id);
        Task DeleteConfirmed(int id);
        bool CheckExists(int id);
        bool DuplicateCheckOnSave(string TaxName);
        bool DuplicateCheckOnUpdate(string TaxName, int DetailHeadId, int Id );
    }
}
