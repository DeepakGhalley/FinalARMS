using CORE_BOL;
using CORE_BOL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CORE_DLL
{
    public interface IBankBranch
    {
        IList<BankBranchModel> GetAll();
        Task<BankBranchModel> Details(int? id);
        int Save(BankBranchModel obj);
        int Update(BankBranchModel obj);
        Task Delete(int? id);
        Task DeleteConfirmed(int id);
        bool CheckExistsAsync(int id);
        bool DuplicateCheckOnSave(string BranchName);
        bool DuplicateCheckOnUpdate(string BranchName, int Id, int Bank);

    }
}
