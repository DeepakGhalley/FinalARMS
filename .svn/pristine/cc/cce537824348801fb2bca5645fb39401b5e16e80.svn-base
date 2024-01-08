using CORE_BOL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CORE_DLL
{
    public interface IParkingSlot
    {
        IList<ParkingSlotModel> GetAll();
        Task<ParkingSlotModel> Details(int? id);
        int Save(ParkingSlotModel obj);
        int Update(ParkingSlotModel obj);
        Task Delete(int? id);
        Task DeleteConfirmed(int id);
        bool CheckExists(int id);
        bool DuplicateCheckOnSave(string ParkingslotName);
        bool DuplicateCheckOnUpdate(string ParkingslotName, int ParkingslotId);
    }
}
