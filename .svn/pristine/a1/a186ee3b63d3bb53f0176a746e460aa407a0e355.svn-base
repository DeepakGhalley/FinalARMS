using CORE_BOL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CORE_DLL
{
    public interface IOccupation
    {
        IList<OccupationVM> GetAll();
        Task<OccupationVM> Details(int? id);
        int Save(OccupationVM obj);
        int Update(OccupationVM obj);
        Task Delete(int? id);
        Task DeleteConfirmed(int id);
        bool CheckExists(int id);
        bool DuplicateCheckOnSave(string occupation);
        bool DuplicateCheckOnUpdate(string Occupation, int Id);
    }
}
