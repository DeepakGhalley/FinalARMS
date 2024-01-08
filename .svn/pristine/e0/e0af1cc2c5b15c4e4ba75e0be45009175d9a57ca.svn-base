using CORE_BOL;
using CORE_BOL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CORE_DLL
{
    public interface ILandDetail
    {
        IList<LandDetailModel> GetAll();
        Task<LandDetailModel> Details(int? id);
        List<LandOwneshipModel> GetLandOwneshipForUpdate(int LandOwnershipId);
        int Save(LandDetailModel obj);
        int Update(LandDetailModel obj);
        Task Delete(int? id);
        Task DeleteConfirmed(int id);
        bool CheckExists(int id);
        bool DuplicateCheckOnSave(string PlotNo, int LandDetailId);
        bool DuplicateCheckOnUpdate(int LandDetailId,string PlotNo);

        List<MstLandUseSubCategory> fetchLUSC(int id);
        int SaveLandOwnershipDetail(LandOwnershipDetailsVM obj);
        List<LandOwnershipDetailsVM> GetLandOwnershipDetail(int? id);
        List<BuildingOwnershipVM> GetBuildingOwnershipDetail(int? id);
        List<BuildingDetailVM> DisplayOtherBuildingDetail(int landOwnId);
        List<LandOwnershipDetailsVM> CheckDuplicateLandOwnership(int LandDetailId, int TaxPayerId);
        int CreateBuildingOwnership(BuildingOwnershipVM obj);
        int CreateBuildingUnit(BuildingUnitDetailModel obj);
        int UpdateLandOwnership(LandOwneshipModel obj);
        List<LandDetailModel> fetchLandDetailByPlotNo(string plotno);
        List<LandDetailModel> GetData1(string ttin);
        List<LandDetailModel> GetData2(string cid);
        List<BuildingUnitDetailModel> ViewBuildingUnit(string Ids);


    }
}
