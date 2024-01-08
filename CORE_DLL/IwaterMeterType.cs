using CORE_BOL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CORE_DLL
{
    public interface IwaterMeterType { 
        IList<WaterMeterTypesModel> GetAll();
        //Task<IEnumerable<TblMstUser>> Details(int? id);
        Task<WaterMeterTypesModel> Details(int? id);
        int Save(WaterMeterTypesModel obj);
        int Update(WaterMeterTypesModel obj);
        Task Delete(int? id);
        Task DeleteConfirmed(int id);
        bool CheckExists(int id);
        bool DuplicateCheckOnSave(string WaterMeterType);
        bool DuplicateCheckOnUpdate(string WaterMeterType, int WaterMeterTypeId);
    }
}
