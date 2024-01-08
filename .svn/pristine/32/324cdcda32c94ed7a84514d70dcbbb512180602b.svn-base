using CORE_BOL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CORE_DLL
{
    public interface IBuildingColor
    {
        IList<BuildingColourModel> GetAll();
        Task<BuildingColourModel> Details(int? id);
        int Save(BuildingColourModel obj);
        int Update(BuildingColourModel obj);
        Task Delete(int? id);
        Task DeleteConfirmed(int id);
        bool CheckExists(int id);
        bool DuplicateCheckOnSave(string BuildingColourType);
        bool DuplicateCheckOnUpdate(string BuildingColourType, int BuildingColourId);
    }
}
