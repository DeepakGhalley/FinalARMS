using CORE_BOL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CORE_DLL
{
    public interface IBuildingUnitClass
    {
        IList<BuildingUnitClassModel> GetAll();
        Task<BuildingUnitClassModel> Details(int? id);
        int Save(BuildingUnitClassModel obj);
        int Update(BuildingUnitClassModel obj);
        Task Delete(int? id);
        Task DeleteConfirmed(int id);
        bool CheckExists(int id);
        bool DuplicateCheckOnSave(string BuildingUnitClass);
        bool DuplicateCheckOnUpdate(string BuildingUnitClass, int Id);
    }
}
