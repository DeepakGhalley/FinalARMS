using CORE_BOL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CORE_DLL
{
    public interface IPavaRate
    {
        IList<PavaRateModel> GetAll();
        //Task<IEnumerable<TblMstUser>> Details(int? id);
        Task<PavaRateModel> Details(int? id);
        int Save(PavaRateModel obj);
        int Update(PavaRateModel obj);
        Task Delete(int? id);
        Task DeleteConfirmed(int id);
        bool CheckExists(int id);
        bool DuplicateCheckOnSave(string PavaRate);
        bool DuplicateCheckOnUpdate(string PavaRate, int Id, int LandUseSubCategory);
    }
}
