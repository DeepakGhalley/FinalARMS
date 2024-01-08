using CORE_BOL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CORE_DLL
{
   public interface IDisposalType
    {
        IList<DisposalTypeModel> GetAll();
        Task<DisposalTypeModel> Details(int? id);
        int Save(DisposalTypeModel obj);
        int Update(DisposalTypeModel obj);
        Task Delete(int? id);
        Task DeleteConfirmed(int id);
        bool CheckExists(int id);
        bool DuplicateCheckOnSave(string disposal);
        bool DuplicateCheckOnUpdate(string disposal, int Id);
    }
}
