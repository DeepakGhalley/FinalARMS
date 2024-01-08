using CORE_BOL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CORE_DLL
{
    public interface IProcessLevel
    {
        IList<ProcessLevelModel> GetAll();
        Task<ProcessLevelModel> Details(int? id);
        int Save(ProcessLevelModel obj);
        int Update(ProcessLevelModel obj);
        Task Delete(int? id);
        Task DeleteConfirmed(int id);
        bool CheckExists(int id);
    }
}
