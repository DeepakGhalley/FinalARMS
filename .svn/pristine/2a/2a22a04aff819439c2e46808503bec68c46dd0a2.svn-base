using CORE_BOL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CORE_DLL
{
    public interface IInspectionType
    {
        IList<InspectionTypeMode> GetAll();
        Task<InspectionTypeMode> Details(int? id);
        int Save(InspectionTypeMode obj);
        int Update(InspectionTypeMode obj);
        Task Delete(int? id);
        Task DeleteConfirmed(int id);
        bool CheckExists(int id);
        bool DuplicateCheckOnSave(string InspectionType);
        bool DuplicateCheckOnUpdate(string InspectionType, int InspectionTypeId);
    }
}
