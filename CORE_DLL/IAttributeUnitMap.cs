using CORE_BOL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CORE_DLL
{
    public interface IAttributeUnitMap
    {
        IList<AttributeUnitMapModel> GetAll();
        Task<AttributeUnitMapModel> Details(int? id);
        int Save(AttributeUnitMapModel obj);
        int Update(AttributeUnitMapModel obj);
        Task Delete(int? id);
        Task DeleteConfirmed(int id);
        bool CheckExists(int id);
        bool DuplicateCheckOnSave(string AttributeName);
        bool DuplicateCheckOnUpdate(string AttributeName, int Id, int DetailTechnicalAtrributId, int MeasurementUnitId);
    }
}
