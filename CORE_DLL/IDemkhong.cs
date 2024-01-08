using CORE_BOL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CORE_DLL
{
    public interface IDemkhong
    {
        IList<DemkhongModel> GetAll();
        Task<DemkhongModel> Details(int? id);
        int SaveDemkhong(DemkhongModel obj);
        int UpdateDemkhong(DemkhongModel obj);
        Task Delete(int? id);
        Task DeleteConfirmed(int id);
        bool CheckExists(int id);
        bool DuplicateCheckOnSave(string DemkhongName);
        bool DuplicateCheckOnUpdate(string DemkhongName, int DemkhongId);
    }
}
