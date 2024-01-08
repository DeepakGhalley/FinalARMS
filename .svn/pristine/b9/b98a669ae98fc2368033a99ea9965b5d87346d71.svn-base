using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CORE_BOL;
using CORE_BOL.Entities;

namespace CORE_DLL
{
   public interface ISuppliers
    {
        IList<SuppliersVM> GetAll();
        int Save(SuppliersVM obj);
        Task<SuppliersVM> Details(int? id);
        int Update(SuppliersVM obj);

        Task Delete(int? id);
        Task DeleteConfirmed(int id);
        bool CheckExists(int id);
        bool DuplicateCheckOnSave(string LicenseNo);
        bool DuplicateCheckOnUpdate(string LicenseNo, int Id);
    }
}
