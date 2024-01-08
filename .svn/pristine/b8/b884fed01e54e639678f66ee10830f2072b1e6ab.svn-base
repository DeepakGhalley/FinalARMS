using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CORE_BOL;
using CORE_BOL.Entities;

namespace CORE_DLL
{
    public interface IBettermentCharges
    {
        List<LandDetailModel> GetTaxPayerDetails(string cid, string ttin, string plotno, string thramno);
        List<LandDetailModel> GetBuildingDetails(int? id);
        List<LandDetailModel> GetLandDetails(int? id);
        List<LandDetailModel> GetBuildingUnitDetails(int? id);
        int SaveLandPoolingRate(trnLandDetailVM obj);


    }
}
