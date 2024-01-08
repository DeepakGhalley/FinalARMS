using CORE_BOL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CORE_DLL
{
    public interface IRoofingType
    {
        IList<RoofingTypemodel> GetAll();
        Task<RoofingTypemodel> Details(int? id);
        int Save(RoofingTypemodel obj);
        int Update(RoofingTypemodel obj);
        Task Delete(int? id);
        Task DeleteConfirmed(int id);
        bool CheckExists(int id);
        bool DuplicateCheckOnSave(string RoofingType);
        bool DuplicateCheckOnUpdate(string RoofingType, int RoofingTypeId);
    }
}
