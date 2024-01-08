using CORE_BOL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CORE_DLL
{
    public interface IDepreciationType
    {
        IList<DepreciationTypeModel> GetAll();
        Task<DepreciationTypeModel> Details(int? id);
        int Save(DepreciationTypeModel obj);
        int Update(DepreciationTypeModel obj);
        Task Delete(int? id);
        Task DeleteConfirmed(int id);
        bool CheckExists(int id);
        bool DuplicateCheckOnSave(string type);
        bool DuplicateCheckOnUpdate(string type, int Id);
    }
}
