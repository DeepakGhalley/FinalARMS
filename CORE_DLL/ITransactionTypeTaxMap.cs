using CORE_BOL;
using CORE_BOL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace CORE_DLL
{
    public interface ITransactionTypeTaxMap
    {
        IList<TransactionTypeTaxMapVM> GetAll();
        Task<TransactionTypeTaxMapVM> Details(int? id);
        int Save(TransactionTypeTaxMapVM obj);
        int Update(TransactionTypeTaxMapVM obj);
        Task Delete(int? id);
        Task DeleteConfirmed(int id);
        bool CheckExists(int id);
        //List<MstTaxMaster> PopulateTaxByTransactionType(int id);
    }
}
