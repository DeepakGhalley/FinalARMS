﻿using CORE_BOL;
using System;
using CORE_BOL.Entities;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;

namespace CORE_DLL
{
    public interface ITranWaterConnection 
    {
        IList<TranWaterConnectionModel> GetAll();
        IList<SewerageConnectionVM> GetSewerage();
        IList<TranWaterConnectionModel> GetDisconnectRequests();
        IList<TranWaterConnectionModel> GetReconnectionRequests(bool id); //DashBoard
        List<TranWaterConnectionModel> GetReconnectionDetail(int? id); //DashBoard
        int ApproveReconnectionRequest(TranWaterConnectionModel obj);  //DashBoard
        int RejectReconnectionRequest(TranWaterConnectionModel obj);  //DashBoard
      //  int savewaterdisconnection(TranWaterConnectionModel obj);  //DashBoard
        int SaveSewerage(TranWaterConnectionModel obj);  //Sewerage Connection
        int UpdateRejectedRemarks(TranWaterConnectionModel obj);  //DashBoard
        IList<LedgerDemandVM> WaterDemandReceipt(long TransactionId); //DashBoard

        Task<TranWaterConnectionModel> Details(int? id);
        Task<TranWaterConnectionModel> DisconnectRequestsDetails(int? id);
        long Save(TranWaterConnectionModel obj);
        int SaveWaterDisconnection(TranWaterConnectionModel obj);
        int Update(TranWaterConnectionModel obj);
        Task Delete(int? id);
        Task DeleteConfirmed(int id);
        bool CheckExists(int id);
        bool DuplicateCheckOnSave(string ConsumerNo);
        bool DuplicateCheckOnSewerage(int SewerageConnectionId);
        bool DuplicateCheckOnUpdate(string ConsumerNo, int WaterConnectionId, int LandDetailId, int WaterMeterTypeId,  int WaterConnectionTypeId, int WaterLineTypeId, int ZoneId, int OwnerTypeId);
        List<GetLandOwnershipDetails> fetchLandOwnershipDetails(string cid, string ttin);
        List<TranWaterConnectionModel> GetTranWaterConnectionDetails(int id);
        List<TranWaterConnectionModel> fetchWaterConnection(string cid, string ttin);
        List<WaterConnectionModel> getWaterDisconnection(string cid, string ttin, string consumerno, string meterno);
        List<WaterConnectionModel> getWaterConnectionDetails(int? id);
        List<WaterConnectionModel> fetchWaterConnectionDetails(string watermeterno);
        int ApproveDisconnectionRequest(TranWaterConnectionModel obj);
        int RejectDisconnectionRequest(TranWaterConnectionModel obj);



        //for Meter Replacement
        List<TranWaterConnectionModel> fetchWaterConnectionMR(string cid, string ttin, string ConsumerNo, string MeterNo);
        List<WaterConnectionModel> GetWaterDetails(int? id);
        List<TranWaterConnectionModel> GetReadingDetails(int? id);
        List<TranWaterConnectionModel> getWaterConnectionDetailsMR(int? id);
        List<TranWaterConnectionModel> fetchPlotDetails(string plotno);
        int SaveWaterMeterReplacement(TranWaterConnectionModel obj);

        List<TranWaterConnectionModel> fetchWaterConnections(string cid, string ttin, string ConsumerNo, string MeterNo); //Meter Reconnection, Meter Shifting
        List<LandDetailModel> GetLandDetails(int? id); //Meter Reconnection
        List<TranWaterConnectionModel> GetDisconnectWaterDetails(int? id); //Water Reconnection
        List<TranWaterConnectionModel> WaterMerterReadingMReconnection(int? id); //Water Meter Reconnection
        int Savewaterreconnection(TranWaterConnectionModel obj); //Water Reconnection
        List<TranWaterConnectionModel> DisplayWaterReconnectionDetail(int? id); //Water Reconnection
        List<TranWaterConnectionModel> GetWaterMeterDetails(int id); //Meter Shifting
        int Savewatermetershifting(TranWaterConnectionModel obj); //Meter Shifting
        List<TranWaterConnectionModel> DisplayMeterShiftingDetail(int id); //Meter Shifting
        List<WaterconnectionDemandVM> PrintDemandWater(int TransactionId);
        List<WaterconnectionDemandVM> PrintDemandSewerage(int TransactionId);
        List<WaterconnectionDemandVM> checkpayment(int WaterConnectionId);
        List<TranWaterConnectionModel> fetchWaterReconnection(string cid, string ttin, string ConsumerNo, string MeterNo);
        List<TranWaterConnectionModel> Getwaterdetailstoupgadeanddowngrate(int id);
        long upgrade(TranWaterConnectionModel obj);
        List<WaterconnectionDemandVM> Printupgrade(int TransactionId);

        public int SaveWaterMeterReplacementwithourDemand(TranWaterConnectionModel obj);
    }
}
