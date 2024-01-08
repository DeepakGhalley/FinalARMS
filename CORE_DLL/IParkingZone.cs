using CORE_BOL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CORE_DLL
{
    public interface IParkingZone
    {
        IList<ParkingZoneVM> GetAll();
        Task<ParkingZoneVM> Details(int? id);
        int Save(ParkingZoneVM obj);
        int Update(ParkingZoneVM obj);
        Task Delete(int? id);
        Task DeleteConfirmed(int id);
        bool CheckExists(int id);
    }
}
