using CORE_BOL;
using CORE_BOL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CORE_DLL
{
    public interface IMannualreceipt
    {
        IList<ManualReceiptVM> GetAll();
        Task<ManualReceiptVM> Details(int? id);
        int Save(ManualReceiptVM obj);
         int Update(ManualReceiptVM obj);
        Task Delete(int? id);
        Task DeleteConfirmed(int id);
        bool CheckExistsAsync(int id);
       

    }
}
