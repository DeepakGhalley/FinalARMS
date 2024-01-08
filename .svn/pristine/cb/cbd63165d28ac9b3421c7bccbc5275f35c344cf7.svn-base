using CORE_BOL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CORE_DLL
{
    public interface ITransactionType
    {
        IList<TransactionTypeVM> GetAll();
        Task<TransactionTypeVM> Details(int? id);
        int Save(TransactionTypeVM obj);
        int Update(TransactionTypeVM obj);
        Task Delete(int? id);
        Task DeleteConfirmed(int id);
        bool CheckExists(int id);
        bool DuplicateCheckOnSave(string TransactionType);
        bool DuplicateCheckOnUpdate(string TransactionType, int TransactionTypeId);
    }
}
