using CORE_BOL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CORE_DLL
{
  public interface IStallLocation
    {
        IList<StallLocationVM> GetAll();
        Task<StallLocationVM> Details(int? id);
        int Save(StallLocationVM obj);
        int Update(StallLocationVM obj);
        Task Delete(int? id);
        Task DeleteConfirmed(int id);
        bool CheckExists(int id);
     
    }
}
