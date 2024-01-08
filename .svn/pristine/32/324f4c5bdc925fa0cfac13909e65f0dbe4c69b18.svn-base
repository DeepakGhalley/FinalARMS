using CORE_BOL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CORE_DLL
{
    public interface IFloorName
    {
        IList<FloorNameModel> GetAll();
        Task<FloorNameModel> Details(int? id);
        int SaveFloorName(FloorNameModel obj);
        int UpdateFloorName(FloorNameModel obj);
        Task Delete(int? id);
        Task DeleteConfirmed(int id);
        bool CheckExists(int id);
        bool DuplicateCheckOnSave(string FloorName);
        bool DuplicateCheckOnUpdate(string FloorName, int FloorNameId);

    }
}
