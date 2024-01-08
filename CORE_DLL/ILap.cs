using CORE_BOL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CORE_DLL
{
    public interface ILap
    {
        IList<LapModel> GetAll();
        Task<LapModel> Details(int? id);
        int SaveLap(LapModel obj);
        int UpdateLap(LapModel obj);
        Task Delete(int? id);
        Task DeleteConfirmed(int id);
        bool CheckExists(int id);
        bool DuplicateCheckOnSave(string LapName);
        bool DuplicateCheckOnUpdate(string LapName, int LapId);
    }
}
