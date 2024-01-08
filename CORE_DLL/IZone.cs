using CORE_BOL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CORE_DLL
{
    public interface IZone
    {
        IList<ZoneModel> GetAll();
        Task<ZoneModel> Details(int? id);
        int SaveZone(ZoneModel obj);
        int UpdateZone(ZoneModel obj);
        Task Delete(int? id);
        Task DeleteConfirmed(int id);
        bool CheckExists(int id);
        bool DuplicateCheckOnSave(string ZoneName);
        bool DuplicateCheckOnUpdate(string ZoneName, int ZoneId);

    }
}
