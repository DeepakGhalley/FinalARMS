using CORE_BOL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CORE_DLL
{
    public interface IGewog
    {
        IList<GewogModel> GetAll();
        Task<GewogModel> Details(int? id);
        int SaveGewog(GewogModel obj);
        int UpdateGewog(GewogModel obj);
        Task Delete(int? id);
        Task DeleteConfirmed(int id);
        bool CheckExists(int id);
        bool DuplicateCheckOnSave(string GewogName);
        bool DuplicateCheckOnUpdate(string GewogName, int DzongkhagId, int GewogId);
    }
}
