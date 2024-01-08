using CORE_BOL;
using CORE_BOL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CORE_DLL
{
    public interface ISlab
    {
        IList<SlabVM> GetAll();
        Task<SlabVM> Details(int? id);
        int Save(SlabVM obj);
        int Update(SlabVM obj);
        //List<MstTransactionTypeTaxMap> fetchTAX(int id);
        Task Delete(int? id);
        Task DeleteConfirmed(int id);
        bool CheckExists(int id);
    }
}
