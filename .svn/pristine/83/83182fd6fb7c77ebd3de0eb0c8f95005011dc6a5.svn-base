using CORE_BOL;
using CORE_BOL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CORE_DLL
{
    public interface IOpeningBalance
    {
        IList<OpeningBalaceVM> GetAll();
        Task<OpeningBalaceVM> Details(int? id);
        int Save(OpeningBalaceVM obj);
         int Update(OpeningBalaceVM obj);
        Task Delete(int? id);
        Task DeleteConfirmed(int id);
        bool CheckExistsAsync(int id);
      


    }
}
