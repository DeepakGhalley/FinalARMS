using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CORE_BOL;
using CORE_BOL.Entities;

namespace CORE_DLL
{
    public interface IStructureCategory
    {
        IList<StructureCategoryModel> GetAll();
        int Save(StructureCategoryModel obj);
        Task<StructureCategoryModel> Details(int? id);
        int Update(StructureCategoryModel obj);

        Task Delete(int? id);
        Task DeleteConfirmed(int id);
        bool CheckExists(int id);
        bool DuplicateCheckOnSave(string StructureCategory);
        bool DuplicateCheckOnUpdate(string StructureCategory, int StructureCategoryId);
    }
}
