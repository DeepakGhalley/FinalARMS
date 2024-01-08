using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CORE_BOL;
using CORE_BOL.Entities;

namespace CORE_DLL
{
    public interface IDivision
    {
        IList<DivisionModel> GetAll();
        //Task<IEnumerable<TblMstUser>> Details(int? id);
        Task<DivisionModel> Details(int? id);
        int SaveDivision(DivisionModel obj);
        int UpdateDivision(DivisionModel obj);
        Task Delete(int? id);
        Task DeleteConfirmed(int id);
        bool CheckExists(int id);
        bool DuplicateCheckOnSave(string DivisionName);
        bool DuplicateCheckOnUpdate(string DivisionName, int Id);
    }
}
