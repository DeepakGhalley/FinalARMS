﻿using CORE_BOL;
using CORE_BOL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CORE_DLL
{
    public interface IWaterMeterReading
    {
        IList<WaterMeterReadingModel> GetAll();
        Task<WaterMeterReadingModel> Details(int? id);
        int Save(WaterMeterReadingModel obj);
        int Update(WaterMeterReadingModel obj);
        Task Delete(int? id);
        Task DeleteConfirmed(int id);
        bool CheckExists(int id);
        public IList<TranWaterConnectionModel> fetchWaterDetails(string ConsumerNo, int Year, int sMonth,int eMonth);
        List<WaterMeterReadingModel> getWaterMeterReadingDetails(int zone,  DateTime ReadingDate); 
        List<WaterMeterReadingModel> CheckDuplicateReadings(int WaterConnectionId, DateTime ReadingDate); 
         List<WaterMeterReadingModel> fetchWaterConnectionByConsumerNo(string consumerNo, string waterMeterNo);
        List<WaterMeterReadingModel> fetchReadinfById(int id);
        List<WaterMeterReadingModel> GetWaterMeterPayment(int id);
        List<WaterMeterReadingModel> getReadingInfo(int id);
        long GenerateDemand(WaterMeterReadingModel obj);
        long SaveWaterMeterReading(WaterMeterReadingModel obj);
        List<WaterMeterReadingModel> GenerateZoneWiseBill(int zone, int year, int month);
        List<WaterMeterReadingModel> getBillingInfo(string consumerno, int year, int month);
        List<SlabVM> getSlabInfo(int id);
        List<WaterMeterReadingModel> getServiceChargesInfo(int id);
        List<WaterMeterReadingModel> getUtilityChargesInfo(int id, string consumerno,int CalendarYearId);
        List<WaterMeterReadingModel> getZoneWiseBillingInfo(int zone, int year/*, int month*/);
        List<WaterMeterReadingModel> getMeterReadingDetails(string consumerno, int year, int month);

        //for Water Bill Edit
        List<WaterMeterReadingModel> fetchWaterBillEdit(string ConsumerNo, int Year, int Month);
        List<WaterMeterReadingModel> checkPaymentStatusForWaterBillEdit(int TransactionId);
        int WaterBillEditupdate(WaterMeterReadingModel obj);
        List<WaterMeterReadingModel> GetWaterPaymentDetails(string ConsumerNo, int Year);
        List<WaterMeterReadingModel> GetWaterPaymentInfo(int TransactionId);
        List<WaterMeterReadingModel> FetchWaterPaymentInfo(int TransactionId);

        //bool DuplicateCheckOnSave(string ConsumerNo);
        //bool DuplicateCheckOnUpdate(string ConsumerNo, int WaterConnectionId, int LandDetailId, int WaterMeterTypeId, int WaterConnectionTypeId, int WaterLineTypeId, int ZoneId, int OwnerTypeId);

        //************* Check ConsumerNo Sequence *************
        List<WaterMeterReadingModel> SearchCnoSequence(int zone);


    }
}
