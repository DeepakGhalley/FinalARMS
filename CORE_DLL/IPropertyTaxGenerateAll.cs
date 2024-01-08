using CORE_BOL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CORE_DLL
{
    public interface IPropertyTaxGenerateAll
    {
        IEnumerable<GenerateAllDisplayModel> GetOwnershipDetailByTaxPayerId(int LandOwnershipId, int TaxYearId);
        IEnumerable<GenerateAllModel> GetOwnershipDetailByLandOwnershipId(string Ids, int TaxYearId);

        
        IList<LandOwneshipModel> GetLandOwnershipDetail(int TaxPayerId);
        IList<LandOwneshipModel> FetchTaxPayerByCID(string Cid, string Ttin, string PlotNo, string ThramNo);
        IList<LandOwneshipModel> FetchTaxPayerByPlotNo(string Cid, string Ttin, string PlotNo, string ThramNo);
        Task<IList<LandOwneshipModel>> GetLandTaxDetail(int LandOwnershipId);
        IList<BuildingTaxVM> GetBuildingTaxDetail(int LandOwnershipId);
        string CreateLandTax(List<GenerateAllPropertyTaxModel> json_dataj); 
        //long GenerateUnitTax(LedgerDemandVM obj);
        IList<LedgerDemandVM> GetGeneratedDemand(long DemandNoId);
        IList<LedgerDemandVM> CheckDuplicateTax(int OwnershipId, int CalendarYearId);
        IList<LedgerDemandVM> lasttaxpaid(int LandOwnershipId);

    }
}
