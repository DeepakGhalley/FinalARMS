using CORE_BOL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CORE_DLL
{
    public interface ITaxPeriod
    {
        IList<TaxPeriodVM> GetAll();
        Task<TaxPeriodVM> Details(int? id);
        int Save(TaxPeriodVM obj);
        int Update(TaxPeriodVM obj);
        Task Delete(int? id);
        Task DeleteConfirmed(int id);
        bool CheckExists(int id);
    }
}
