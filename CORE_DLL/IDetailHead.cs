using CORE_BOL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CORE_DLL
{
    public interface IDetailHead
    {
        IList<DetailHeadModel> GetAll();
        Task<DetailHeadModel> Details(int? id);
        int SaveDetailHead(DetailHeadModel obj);
        int UpdateDetailHead(DetailHeadModel obj);
        Task Delete(int? id);
        Task DeleteConfirmed(int id);
        bool CheckExists(int id);
        bool DuplicateCheckOnSave(string DetailHeadName);
        bool DuplicateCheckOnUpdate(string DetailHeadName, int DetailHeadId);
    }
}
