using CORE_BOL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CORE_DLL
{
    public interface ILandUseCategory
    {
        IList<LandUseCategoryModel> GetAll();
        Task<LandUseCategoryModel> Details(int? id);
        int Save(LandUseCategoryModel obj);
        int Update(LandUseCategoryModel obj);
        Task Delete(int? id);
        Task DeleteConfirmed(int id);
        bool CheckExists(int id);
        bool DuplicateCheckOnSave(string TaxName);
        bool DuplicateCheckOnUpdate(string TaxName, int Id);
    }
}
