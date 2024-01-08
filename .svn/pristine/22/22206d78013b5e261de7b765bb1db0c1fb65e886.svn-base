using CORE_BOL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
namespace CORE_DLL
{
    public interface ITaxTypeClassification
    {
        IList<TaxTypeClassificationVM> GetAll();
        Task<TaxTypeClassificationVM> Details(int? id);
        int Save(TaxTypeClassificationVM obj);
        int Update(TaxTypeClassificationVM obj);
        Task Delete(int? id);
        Task DeleteConfirmed(int id);
        bool CheckExists(int id);
        bool DuplicateCheckOnSave(string TaxTypeClassification);
        bool DuplicateCheckOnUpdate(string TaxTypeClassification, int Id);
    }
}
