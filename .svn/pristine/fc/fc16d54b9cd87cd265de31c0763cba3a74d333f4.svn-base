using CORE_BOL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CORE_DLL
{
    public interface IConstructionType
    {
        IList<ConstructionTypeModel> GetAll();
        Task<ConstructionTypeModel> Details(int? id);
        int Save(ConstructionTypeModel obj);
        int Update(ConstructionTypeModel obj);
        Task Delete(int? id);
        Task DeleteConfirmed(int id);
        bool CheckExists(int id);
        bool DuplicateCheckOnSave(string ConstructionType);
        bool DuplicateCheckOnUpdate(string ConstructionType, int ConstructionTypeId);
    }
}
