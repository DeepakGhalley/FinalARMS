using CORE_BOL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CORE_DLL
{
    public interface IWaterLineTypes
    {
        IList<WaterLineTypesModel> GetAll();
        //Task<IEnumerable<TblMstUser>> Details(int? id);
        Task<WaterLineTypesModel> Details(int? id);
        int Save(WaterLineTypesModel obj);
        int Update(WaterLineTypesModel obj);
        Task Delete(int? id);
        Task DeleteConfirmed(int id);
        bool CheckExists(int id);
        bool DuplicateCheckOnSave(string WaterLineType);
        bool DuplicateCheckOnUpdate(string WaterLineType, int WaterLineTypeId);
    }
}
