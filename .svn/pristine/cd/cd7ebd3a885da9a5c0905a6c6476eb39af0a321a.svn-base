using CORE_BOL;
using CORE_BOL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CORE_DLL
{
    public interface IBuildingUnitDetails
    {
        IList<BuildingUnitDetailModel> GetAll();
        Task<BuildingUnitDetailModel> Details(int? id);
        List<BuildingUnitDetailModel> SearchBuildingDetailsPlotNo(string plotno);
        List<BuildingUnitDetailModel> SearchByPlot(string Plotno);
        List<BuildingUnitDetailModel> SearchDetailsByCid(string cid, string ttin);
        List<BuildingUnitDetailModel> getExisitingBuildingUnitDetails(int id);
        List<BuildingUnitDetailModel> getUnMappedBuildingUnitDetails(int id);
        List<BuildingUnitDetailModel> GetBuildingUnitDetail(int id);
        long UpdateBuildingUnitDetails(BuildingUnitDetailModel obj);
        int Save(BuildingUnitDetailModel obj);
        int Update(BuildingUnitDetailModel obj);
        Task Delete(int? id);
        Task DeleteConfirmed(int id);
        bool CheckExists(int id);
    }
}
