using CORE_BOL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CORE_DLL
{
    public interface IMaterialType
    {
        IList<MaterialTypeModel> GetAll();
        Task<MaterialTypeModel> Details(int? id);
        int Save(MaterialTypeModel obj);
        int Update(MaterialTypeModel obj);
        Task Delete(int? id);
        Task DeleteConfirmed(int id);
        bool CheckExists(int id);
        bool DuplicateCheckOnSave(string MaterialType);
        bool DuplicateCheckOnUpdate(string MaterialType, int MaterialTypeId);
    }
}
