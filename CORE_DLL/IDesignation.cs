using CORE_BOL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CORE_DLL
{
   public interface IDesignation
    {
        IList<DesignationModel> GetAll();
        Task<DesignationModel> Details(int? id);
        int SaveDesignation(DesignationModel obj);
        int UpdateDesignation(DesignationModel obj);
        Task Delete(int? id);
        Task DeleteConfirmed(int id);
        bool CheckExists(int id);
        bool DuplicateCheckOnSave(string DesignationName);
        bool DuplicateCheckOnUpdate(string DesignationName, int Id, int Section);
    }
}
