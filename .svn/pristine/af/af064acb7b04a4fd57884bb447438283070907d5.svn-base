using CORE_BOL;
using CORE_BOL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
namespace CORE_DLL
{
    public interface IGenerateOccupancy
    {

        List<OccupancyCertificate> FetchLandOwnershipDetails(string Ttin, string Cid);
        List<BuildingDetailModel> FetchBuildingDetails(int LandDetailId, int TaxpayerId);
        List<BuildingUnitDetailModel> FetchBuildingUnitDetails(int BuildingDetailId, int TaxpayerId);
        List<OccupancyCertificate> GetBDDetails(int BuildingDetailId);
        List<OccupancyCertificate> CheckDuplicate(int BDId, int BTId);
        List<OccupancyCertificate> CheckDuplicateU(int BUId, int UTId);
        List<OccupancyCertificate> GetBUDDetails(int BuildingUnitDetailId);
        int SaveBuildingOC(OccupancyCertificate obj);
        int SaveBuildingUnitOC(OccupancyCertificate obj);



    }
}
