using CORE_BOL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CORE_DLL
{
    public interface IMinorHead
    {
        IList<MinorHeadModel> GetAll();
        Task<MinorHeadModel> Details(int? id);
        int SaveMinorHead(MinorHeadModel obj);
        int UpdateMinorHead(MinorHeadModel obj);
        Task Delete(int? id);
        Task DeleteConfirmed(int id);
        bool CheckExists(int id);
        bool DuplicateCheckOnSave(string MinorHeadName);
        bool DuplicateCheckOnUpdate(string MinorHeadName, int MinorHeadId);
    }
}
