using CORE_BOL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CORE_DLL
{
    public interface ILandUseSubCategory
    {
        IList<LandUseSubCategoryModel> GetAll();
        Task<LandUseSubCategoryModel> Details(int? id);
        int Save(LandUseSubCategoryModel obj);
        int Update(LandUseSubCategoryModel obj);
        Task Delete(int? id);
        Task DeleteConfirmed(int id);
        bool CheckExists(int id);
        bool DuplicateCheckOnSave(string LandUseSubCategory);
        bool DuplicateCheckOnUpdate(string LandUseSubCategory, int Id);
    }
}
