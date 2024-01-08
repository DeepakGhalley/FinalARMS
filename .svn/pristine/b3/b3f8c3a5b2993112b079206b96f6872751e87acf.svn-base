using CORE_BOL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CORE_DLL
{
    public interface IMeasurmentUnit
    {
        IList<MeasurementUnitModel> GetAll();
        Task<MeasurementUnitModel> Details(int? id);
        int SaveMeasurmentUnit(MeasurementUnitModel obj);
        int UpdateMeasurmentUnit(MeasurementUnitModel obj);
        Task Delete(int? id);
        Task DeleteConfirmed(int id);
        bool CheckExists(int id);
        //bool DuplicateCheckOnSave(string Symbol);
        //bool DuplicateCheckOnUpdate(string Symbol, int Id);
    }
}
