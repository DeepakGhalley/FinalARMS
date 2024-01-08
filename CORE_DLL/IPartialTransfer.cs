using CORE_BOL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CORE_DLL
{
    public interface IPartialTransfer
    {
        IList<PartialTransferModel> GetAll();
        Task<PartialTransferModel> Details(int? id);
        int SaveActivityType(PartialTransferModel obj);
        int UpdateActivityType(PartialTransferModel obj);
        Task Delete(int? id);
        Task DeleteConfirmed(int id);
        bool CheckExists(int id);
        long SaveDemand(DemandVM obj);
        List<BuildingDetailVM> GetBuildingDetails(int? id);
        List<BuildingUnitDetailsVM> GetBuildingUnitDetails(int id);


    }
}
