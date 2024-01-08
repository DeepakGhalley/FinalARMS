using CORE_BOL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CORE_DLL
{
    public interface IDzongkhag
    {
        IList<DzongkhagModel> GetAll();
        Task<DzongkhagModel> Details(int? id);
        int SaveDzongkhag(DzongkhagModel obj);
        int UpdateDzongkhag(DzongkhagModel obj);
        Task Delete(int? id);
        Task DeleteConfirmed(int id);
        bool CheckExists(int id);
        bool DuplicateCheckOnSave(string DzongkhagName);
        bool DuplicateCheckOnUpdate(string DzongkhagName, int DzongkhagId);
    }
}
