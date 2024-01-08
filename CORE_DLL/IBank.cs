using CORE_BOL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CORE_DLL
{
    public interface IBank
    {
        IList<BankModel> GetAll();
        Task<BankModel> Details(int? id);
        int Save(BankModel obj);
        int Update(BankModel obj);
        Task Delete(int? id);
        Task DeleteConfirmed(int id);
        bool CheckExistsAsync(int id);
        bool DuplicateCheckOnSave(string BankName);
        bool DuplicateCheckOnUpdate(string BankName, int Id);

    }
}
