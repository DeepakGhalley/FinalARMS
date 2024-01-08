using CORE_BOL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CORE_DLL
{
    public interface IBoundaryType
    {
        IList<BoundaryTypeModel> GetAll();
        Task<BoundaryTypeModel> Details(int? id);
        int Save(BoundaryTypeModel obj);
        int Update(BoundaryTypeModel obj);
        Task Delete(int? id);
        Task DeleteConfirmed(int id);
        bool CheckExists(int id);
        bool DuplicateCheckOnSave(string BoundaryType);
        bool DuplicateCheckOnUpdate(string BoundaryType, int BoundaryTypeId);
    }
}
