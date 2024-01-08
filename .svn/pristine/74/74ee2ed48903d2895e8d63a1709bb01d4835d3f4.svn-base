using CORE_BOL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CORE_DLL
{
    public interface IActivityType
    {
        IList<ActivityTypeModel> GetAll();
        Task<ActivityTypeModel> Details(int? id);
        int SaveActivityType(ActivityTypeModel obj);
        int UpdateActivityType(ActivityTypeModel obj);
        Task Delete(int? id);
        Task DeleteConfirmed(int id);
        bool CheckExists(int id);
        bool DuplicateCheckOnSave(string ActivityType);
        bool DuplicateCheckOnUpdate(string ActivityType, int ActivityTypeId);

    }
}
