using CORE_BOL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CORE_DLL
{
    public interface IBuildingDetail
    {
        IList<BuildingDetailModel> GetAll();
        Task<BuildingDetailModel> Details(int? id);
        Task<BuildingUnitDetailModel> UnitDetails(int? id);
        List<LandDetailModel> SearchLAndDetailsByPlotNo(string plotno);
        //List<BuildingDetailModel> RemoveBuildingDetail(int id);
        int Save(BuildingDetailModel obj);
        int SaveBuildingDetail(BuildingDetailModel obj);
        int SaveBuildingUnitDetail(BuildingUnitDetailModel obj);
        int UpdateBuildingDetail(BuildingDetailModel obj);
        int UpdateBuildingUnitDetail(BuildingUnitDetailModel obj);
        int SaveAddMore(BuildingDetailModel obj);
        Task Delete(int? id);
        Task DeleteConfirmed(int id);
        bool CheckExists(int id);
        bool Check(int id, int id2);
        bool CheckBuildingOwnership(int id);
        bool CheckOccupancy(int id, int id2);

        List<BuildingDetailModel> fetchBuildingDetail(int LandDetailId);
        List<BuildingUnitDetailModel> GetBuildingUnit(int BuildingDetailId, int TaxPayerId);
        List<BuildingDetailModel> GetBDetail(int BuildingDetailId);
        List<LandOwneshipModel> GetLandOwnershipDetails(string buildingno, string plotno);
        List<LandOwneshipModel> GetTaxPayerName(int TaxPayerId, int LandOwnershipId);
        List<TaxPayerProfileModel> GetTaxPayerDetails(string plotno, string cid);
        List<BuildingDetailModel> GetBuildingForUpdate(int BuildingDetailId);
        List<BuildingUnitDetailModel> GetBuildingUnitForUpdate(int BuildingUnitDetailId);


    }
}
