using CORE_BOL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CORE_DLL
{
   public interface IBuildingUnitUseType
    {
        IList<BuildingUnitUseTypeModel> GetAll();
        Task<BuildingUnitUseTypeModel> Details(int? id);
        int Save(BuildingUnitUseTypeModel obj);
        int Update(BuildingUnitUseTypeModel obj);
        Task Delete(int? id);
        Task DeleteConfirmed(int id);
        bool CheckExists(int id);
        bool DuplicateCheckOnSave(string BuildingUnitUseType);
        bool DuplicateCheckOnUpdate(string BuildingUnitUseType, int BuildingUnitUseTypeId);
    }
}
