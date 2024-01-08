using CORE_BOL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CORE_DLL
{
    public interface IWaterConnectionTypes
    {
        IList<WaterConnectionTypesModel> GetAll();
        Task<WaterConnectionTypesModel> Details(int? id);
        int Save(WaterConnectionTypesModel obj);
        int Update(WaterConnectionTypesModel obj);
        Task Delete(int? id);
        Task DeleteConfirmed(int id);
        bool CheckExists(int id);
        bool DuplicateCheckOnSave(string WaterConnectionType);
        bool DuplicateCheckOnUpdate(string WaterConnectionType, int WaterConnectionTypeId);
    }

}
