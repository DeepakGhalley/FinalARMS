using CORE_BOL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CORE_DLL
{
    public interface IMajorHead
    {
        IList<MajorHeadModel> GetAll();
        Task<MajorHeadModel> Details(int? id);
        int SaveMajorHead(MajorHeadModel obj);
        int UpdateMajorHead(MajorHeadModel obj);
        Task Delete(int? id);
        Task DeleteConfirmed(int id);
        bool CheckExists(int id);
        bool DuplicateCheckOnSave(string MajorHeadName);
        bool DuplicateCheckOnUpdate(string MajorHeadName, int MajorHeadId);
    }
}
