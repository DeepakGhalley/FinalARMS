using CORE_BOL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CORE_DLL
{
    public interface IStreetName
    {
        IList<StreetNameModel> GetAll();
        Task<StreetNameModel> Details(int? id);
        int Save(StreetNameModel obj);
        int Update(StreetNameModel obj);
        Task Delete(int? id);
        Task DeleteConfirmed(int id);
        bool CheckExists(int id);
        bool DuplicateCheckOnSave(string StreetName);
        bool DuplicateCheckOnUpdate(string StreetName, int StreetNameId);
    }
}
