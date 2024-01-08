using CORE_BOL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CORE_DLL
{
    public interface IMaintenanceType
    {
        IList<MaintenanceTypeVM> GetAll();
        Task<MaintenanceTypeVM> Details(int? id);
        int Save(MaintenanceTypeVM obj);
        int Update(MaintenanceTypeVM obj);
        Task Delete(int? id);
        Task DeleteConfirmed(int id);
        bool CheckExists(int id);
        bool DuplicateCheckOnSave(string MaintenanceType);
        bool DuplicateCheckOnUpdate(string MaintenanceType, int Id);
    }
}
