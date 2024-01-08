using CORE_BOL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CORE_DLL
{
    public interface IRole
    {
        IList<RoleVM> GetAll();
        Task<RoleVM> Details(int? id);
        int Save(RoleVM obj);
        int Update(RoleVM obj);
        Task Delete(int? id);
        Task DeleteConfirmed(int id);
        bool CheckExists(int id);
    }
}
