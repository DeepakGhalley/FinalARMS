using CORE_BOL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CORE_DLL
{
  public  interface IFinancialYear
    {
        IList<FinancialYearVM> GetAll();

        int Save(FinancialYearVM obj);
        Task<FinancialYearVM> Details(int? id);

        int Update(FinancialYearVM obj);

        Task Delete(int? id);
        Task DeleteConfirmed(int id);
        bool CheckExists(int id);
        bool DuplicateCheckOnSave(string FinancialYear);
        bool DuplicateCheckOnUpdate(string FinancialYear, int Id);
    }
}
