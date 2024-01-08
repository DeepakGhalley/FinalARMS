using CORE_BOL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CORE_DLL
{
    public interface ISection
    {
        IList<SectionModel> GetAll();
        Task<SectionModel> Details(int? id);
        int SaveSection(SectionModel obj);
        int UpdateSection(SectionModel obj);
        Task Delete(int? id);
        Task DeleteConfirmed(int id);
        bool CheckExists(int id);
        bool DuplicateCheckOnSave(string SectionName);
        bool DuplicateCheckOnUpdate(string SectionName, int Id, int Division);

    }
}
