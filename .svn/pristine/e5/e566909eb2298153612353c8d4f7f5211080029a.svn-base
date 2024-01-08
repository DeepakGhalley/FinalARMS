using CORE_BOL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CORE_DLL
{
    public interface ITechnicalAttribute
    {
        IList<TechnicalAttributeModel> GetAll();
        Task<TechnicalAttributeModel> Details(int? id);
        int Save(TechnicalAttributeModel obj);
        int Update(TechnicalAttributeModel obj);
        Task Delete(int? id);
        Task DeleteConfirmed(int id);
        bool CheckExists(int id);
        bool DuplicateCheckOnSave(string TechnicalAttribute);
        bool DuplicateCheckOnUpdate(string TechnicalAttribute, int Id, int TertiaryAccountHeadId);
    }
}
