using CORE_BOL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CORE_DLL
{
    public interface IBuildingType
    {
        IList<BuildingTypeModel> GetAll();
        Task<BuildingTypeModel> Details(int? id);
        int Save(BuildingTypeModel obj);
        int Update(BuildingTypeModel obj);
        Task Delete(int? id);
        Task DeleteConfirmed(int id);
        bool CheckExists(int id);
        bool DuplicateCheckOnSave(string BuildingType);
        bool DuplicateCheckOnUpdate(string BuildingType, int Id);
    }
}
