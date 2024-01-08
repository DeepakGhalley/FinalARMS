﻿using CORE_BOL;
using System;
using CORE_BOL.Entities;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;

namespace CORE_DLL
{
    public interface IWaterConnection
    {
        IList<WaterConnectionModel> GetAll();
        Task<WaterConnectionModel> Details(int? id);
        public int MeterReplacement(WaterConnectionModel obj);
        int Save(WaterConnectionModel obj);
        int Update(WaterConnectionModel obj);
        int UpdateWaterConnection(WaterConnectionModel obj);
        Task Delete(int? id);
        Task DeleteConfirmed(int id);
        bool CheckExists(int id);
        bool DuplicateCheckOnSave(string ConsumerNo);
        //bool DuplicateCheckOnUpdate(string ConsumerNo, int WaterConnectionId, int LandDetailId, int WaterMeterTypeId,  int WaterConnectionTypeId, int WaterLineTypeId, int ZoneId, int OwnerTypeId);
        List<GetLandOwnershipDetails> fetchLandOwnershipDetails(string cid, string ttin, string name);
        List<WaterConnectionModel> GetWaterConnectionDetails(int id, int LandOwnershipId);
        List<WaterConnectionModel> GetWaterConnectionDetails(string consumerno,string Plotno);

        //for Update/edit page(plot no search)
        List<WaterConnectionModel> SearchDetails(string plotno);
        List<WaterConnectionModel> DisplayLandOwnership(int? id);
        List<WaterConnectionModel> SearchPlotNo(string PlotNo);
        int UpdateLandOwnership(WaterConnectionModel obj);
        List<WaterConnectionModel> GetWaterConnectionForUpdate(int WaterConnectionId);





    }
}