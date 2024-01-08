using CORE_BOL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CORE_DLL
{
    public interface IStructureType
    {
        IList<StructureTypeModel> GetAll();
        Task<StructureTypeModel> Details(int? id);
        int Save(StructureTypeModel obj);
        int Update(StructureTypeModel obj);
        Task Delete(int? id);
        Task DeleteConfirmed(int id);
        bool CheckExists(int id);
        bool DuplicateCheckOnSave(string StructureType);
        bool DuplicateCheckOnUpdate(string StructureType, int StructureTypeId);
    }
}
