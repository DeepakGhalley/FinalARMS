using CORE_BOL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CORE_DLL
{
    public interface IRate
    {
        IList<RateVM> GetAll();
        Task<RateVM> Details(int? id);
        int Save(RateVM obj);
        int Update(RateVM obj);
        Task Delete(int? id);
        Task DeleteConfirmed(int id);
        bool CheckExists(int id);
    }
}
