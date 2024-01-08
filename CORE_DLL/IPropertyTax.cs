﻿using CORE_BOL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CORE_DLL
{
    public interface IPropertyTax
    {
        IList<LandOwneshipModel> GetLandOwnershipDetail(int TaxPayerId);
        IList<LandOwneshipModel> FetchTaxPayerByCID(string Cid, string Ttin, string PlotNo, string ThramNo);
        Task<IList<LandOwneshipModel>> GetLandTaxDetail(int LandOwnershipId);
        IList<BuildingTaxVM> GetBuildingTaxDetail(int LandOwnershipId, int TaxYearId);
        long CreateLandTax(LedgerDemandVM obj); 
        long GenerateUnitTax(LedgerDemandVM obj);
        IList<LedgerDemandVM> GetGeneratedDemand(long DemandNoId);
        IList<LedgerDemandVM> CheckDuplicateTax(int TaxPayerId, int LandDetailId, int CalendarYearId);
        IList<LedgerDemandVM> lasttaxpaid(int LandOwnershipId);
        IList<LedgerDemandVM> CheckStructureAvailable(int LandOwnershipId);
    }
}
