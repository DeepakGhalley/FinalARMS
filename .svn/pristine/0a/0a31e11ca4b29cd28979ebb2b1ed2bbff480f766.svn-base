using CORE_BOL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CORE_DLL
{
   public interface IArea
    {
        IList<AreaModel> GetAll();
        Task<AreaModel> Details(int? id);
        int SaveArea(AreaModel obj);
        int UpdateArea(AreaModel obj);
        Task Delete(int? id);
        Task DeleteConfirmed(int id);
        bool CheckExists(int id);
        bool DuplicateCheckOnSave(string AreaName);
        bool DuplicateCheckOnUpdate(string AreaName, int AreaId);

    }
}
