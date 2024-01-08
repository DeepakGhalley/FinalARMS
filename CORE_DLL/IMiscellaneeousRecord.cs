﻿using CORE_BOL;
using CORE_BOL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CORE_DLL
{
    public interface IMiscellaneousRecord
    {

        List<MiscellaneousRecordModel> fetchdataByCid(string Cid, string Name, string fromdate, string todate);
        List<MiscellaneousRecordModel> PrintDemand(int id);
        List<MiscellaneousRecordModel> GetApplicantDetails(int id);
        List<MstTransactionTypeTaxMap> fetchPV(int id);
        List<MstTaxMaster> fetchPG(int id);
        List<MstSlab> fetchLUSC(int id);
        long SaveMiscellaneousRecord(MiscellaneousRecordModel obj);
        IList<MiscellaneousRecordModel> GetAll();
        Task<MiscellaneousRecordModel> Details(long? id);
      
        int Update(MiscellaneousRecordModel obj);
        Task Delete(int? id);
        Task DeleteConfirmed(int id);
        bool CheckExists(int id);
        public List<MiscellaneousRecordModel> mPrintDemand(int id);
        public List<MiscellaneousRecordModel> MReport(int TaxId, string fromdate, string todate);
        //bool DuplicateCheckOnSave(string InspectionType);
        //bool DuplicateCheckOnUpdate(string InspectionType, int InspectionTypeId);
    }
}
