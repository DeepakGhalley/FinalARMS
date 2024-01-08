using CORE_BOL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CORE_DLL
{
    public interface IDetailTechnicalAttribute
    {
        IList<DetailTechnicalAttributeModel> GetAll();
        Task<DetailTechnicalAttributeModel> Details(int? id);
        int Save(DetailTechnicalAttributeModel obj);
        int Update(DetailTechnicalAttributeModel obj);
        Task Delete(int? id);
        Task DeleteConfirmed(int id);
        bool CheckExists(int id);
        bool DuplicateCheckOnSave(string DetailTechnicalAttribute);
        bool DuplicateCheckOnUpdate(string DetailTechnicalAttribute, int Id, int TechnicalAttributeId);
    }
}
