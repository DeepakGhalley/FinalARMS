using CORE_BOL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CORE_DLL
{
    public interface IVillage
    {
        IList<VillageModel> GetAll();
        Task<VillageModel> Details(int? id);
        int SaveVillage(VillageModel obj);
        int UpdateVillage(VillageModel obj);
        Task Delete(int? id);
        Task DeleteConfirmed(int id);
        bool CheckExists(int id);
        bool DuplicateCheckOnSave(string VillageName);
        bool DuplicateCheckOnUpdate(string VillageName, int GewogId, int villageId);
    }
}
