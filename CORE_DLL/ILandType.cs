using CORE_BOL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CORE_DLL
{
    public interface ILandType
    {
        IList<LandTypeVM> GetAll();
        Task<LandTypeVM> Details(int? id);
        int Save(LandTypeVM obj);
        int Update(LandTypeVM obj);
        Task Delete(int? id);
        Task DeleteConfirmed(int id);
        bool CheckExists(int id);
        bool DuplicateCheckOnSave(string LandTypeName);
        bool DuplicateCheckOnUpdate(string LandTypeName, int Id);
    }
}
