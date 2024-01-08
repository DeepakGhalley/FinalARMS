﻿
using CORE_DLL;
using System;
using System.Collections.Generic;
using CORE_BOL;
using CORE_BOL.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Transactions;
using Microsoft.EntityFrameworkCore.Internal;
using QRCoder;
using System.Drawing;
using System.IO;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CORE_BLL
{
    public class LedgerBLL : ILedger
    {
        readonly tt_dbContext ctx = new tt_dbContext();

        public DemandCountModel GetDemandCount()
        {

            var data = (from x in ctx.TblDemand
                            //   .Where(x => x.DemandNoId == 18)
                            //.OrderBy(xx => xx.TransactionId)
                            //    //.GroupBy(xx=>xx.DemandNoId)
                            //join y in ctx.TblDemandNo on x.DemandNoId equals y.DemandNoId
                            //let cuc_sum = ctx.TblDemand.Where(y => y.DemandNoId == x.DemandNoId).Count()
                            //let cuc_sumd = ctx.TblDemand.Where(y => y.DemandNoId == x.DemandNoId).Sum(x => x.DemandAmount)
                            //let cuc_sume = ctx.TblDemand.Where(y => y.DemandNoId == x.DemandNoId).Sum(x => x.ExemptionAmount).GetValueOrDefault()

                            // join z in ctx.MstTaxMaster on x.TaxId equals z.TaxId
                            //var data1 = data.GroupBy(x => x.DemandNoId)

                        select new DemandCountModel
                        {
                            PropertyTax = x.TaxId,
                            //TransactionId = x.TransactionId,
                            //DemandNoId = x.DemandNoId,
                            //TaxId = x.TaxId,
                            //FinancialYearId = x.FinancialYearId,
                            //CalendarYearId = x.CalendarYearId,
                            Miscellaneous = (int)x.TaxPayerId,
                            //TotalAmount = x.cuc_sum,
                            Ec = x.TaxId,

                        });
            //                    data.GroupBy(l => l.PropertyTax, l => l.PropertyTax)
            //.Select(g => new {
            //    Date = g.Key,
            //    Count = g.Distinct().Count()
            //});

            return (DemandCountModel)data;
        }

        public IList<LedgerDemandVM> GetAllDemands(int id)
        {
            if(id == 20)
            {
                var data = (from x in ctx.TblDemand
                           .Where(x => x.IsPaymentMade == false && x.IsCancelled == false)
                           .OrderBy(xx => xx.TransactionId)
                           .OrderBy(xx => xx.TaxPayerId)
                            join y in ctx.TblDemandNo on x.DemandNoId equals y.DemandNoId
                            join z in ctx.TblTransactionDetail on x.TransactionId equals z.TransactionId
                            join a in ctx.MstTransactionType on z.TransactionTypeId equals a.TransactionTypeId
                            let cuc_sum = ctx.TblDemand.Where(y => y.DemandNoId == x.DemandNoId).Sum(x => x.TotalAmount)
                            let cuc_sumd = ctx.TblDemand.Where(y => y.DemandNoId == x.DemandNoId).Sum(x => x.DemandAmount)
                            let cuc_sume = ctx.TblDemand.Where(y => y.DemandNoId == x.DemandNoId).Sum(x => x.ExemptionAmount).GetValueOrDefault()
                            where a.TransactionTypeId == 1 || a.TransactionTypeId == 3 || a.TransactionTypeId == 16 || a.TransactionTypeId == 20

                            select new LedgerDemandVM
                            {
                                TotalAmount = cuc_sum,
                                DemandAmount = cuc_sumd,
                                ExemptionAmount = cuc_sume,
                                ExemptionLetter = x.ExemptionLetter,
                                DemandNo = y.DemandNo,
                                TransactionType = a.TransactionType
                            }).Distinct();
                return (IList<LedgerDemandVM>)data.ToList();
            }
            else if(id == 34)
            {
                var data = (from x in ctx.TblDemand
                                           .Where(x => x.IsPaymentMade == false && x.IsCancelled == false)
                                        .OrderBy(xx => xx.TransactionId)
                                        .OrderBy(xx => xx.TaxPayerId)
                            join y in ctx.TblDemandNo on x.DemandNoId equals y.DemandNoId
                            join z in ctx.TblTransactionDetail on x.TransactionId equals z.TransactionId
                            join a in ctx.MstTransactionType on z.TransactionTypeId equals a.TransactionTypeId
                            let cuc_sum = ctx.TblDemand.Where(y => y.DemandNoId == x.DemandNoId).Sum(x => x.TotalAmount)
                            let cuc_sumd = ctx.TblDemand.Where(y => y.DemandNoId == x.DemandNoId).Sum(x => x.DemandAmount)
                            let cuc_sume = ctx.TblDemand.Where(y => y.DemandNoId == x.DemandNoId).Sum(x => x.ExemptionAmount).GetValueOrDefault()
                            where a.TransactionTypeId == 33 || a.TransactionTypeId == 34 || a.TransactionTypeId == 37 || a.TransactionTypeId == 36
                            || a.TransactionTypeId == 41 || a.TransactionTypeId == 38 || a.TransactionTypeId == 39 || a.TransactionTypeId == 40
                            || a.TransactionTypeId == 35 


                            select new LedgerDemandVM
                            {
                                TotalAmount = cuc_sum,
                                DemandAmount = cuc_sumd,
                                ExemptionAmount = cuc_sume,
                                ExemptionLetter = x.ExemptionLetter,
                                DemandNo = y.DemandNo,
                                TransactionType = a.TransactionType
                            }).Distinct();
                return (IList<LedgerDemandVM>)data.ToList();
            }
            else if(id == 13)
            {
                var data = (from x in ctx.TblDemand
                                           .Where(x => x.IsPaymentMade == false && x.IsCancelled == false)
                                        .OrderBy(xx => xx.TransactionId)
                                        .OrderBy(xx => xx.TaxPayerId)
                            join y in ctx.TblDemandNo on x.DemandNoId equals y.DemandNoId
                            join z in ctx.TblTransactionDetail on x.TransactionId equals z.TransactionId
                            join a in ctx.MstTransactionType on z.TransactionTypeId equals a.TransactionTypeId
                            let cuc_sum = ctx.TblDemand.Where(y => y.DemandNoId == x.DemandNoId).Sum(x => x.TotalAmount)
                            let cuc_sumd = ctx.TblDemand.Where(y => y.DemandNoId == x.DemandNoId).Sum(x => x.DemandAmount)
                            let cuc_sume = ctx.TblDemand.Where(y => y.DemandNoId == x.DemandNoId).Sum(x => x.ExemptionAmount).GetValueOrDefault()
                            where a.TransactionTypeId == 13

                            select new LedgerDemandVM
                            {
                                TotalAmount = cuc_sum,
                                DemandAmount = cuc_sumd,
                                ExemptionAmount = cuc_sume,
                                ExemptionLetter = x.ExemptionLetter,
                                DemandNo = y.DemandNo,
                                TransactionType = a.TransactionType
                            }).Distinct();
                return (IList<LedgerDemandVM>)data.ToList();
            }
            else if(id == 31)
            {
                var data = (from x in ctx.TblDemand
                                           .Where(x => x.IsPaymentMade == false && x.IsCancelled == false)
                                        .OrderBy(xx => xx.TransactionId)
                                        .OrderBy(xx => xx.TaxPayerId)
                            join y in ctx.TblDemandNo on x.DemandNoId equals y.DemandNoId
                            join z in ctx.TblTransactionDetail on x.TransactionId equals z.TransactionId
                            join a in ctx.MstTransactionType on z.TransactionTypeId equals a.TransactionTypeId
                            let cuc_sum = ctx.TblDemand.Where(y => y.DemandNoId == x.DemandNoId).Sum(x => x.TotalAmount)
                            let cuc_sumd = ctx.TblDemand.Where(y => y.DemandNoId == x.DemandNoId).Sum(x => x.DemandAmount)
                            let cuc_sume = ctx.TblDemand.Where(y => y.DemandNoId == x.DemandNoId).Sum(x => x.ExemptionAmount).GetValueOrDefault()
                            where a.TransactionTypeId == 31

                            select new LedgerDemandVM
                            {
                                TotalAmount = cuc_sum,
                                DemandAmount = cuc_sumd,
                                ExemptionAmount = cuc_sume,
                                ExemptionLetter = x.ExemptionLetter,
                                DemandNo = y.DemandNo,
                                TransactionType = a.TransactionType
                            }).Distinct();
                return (IList<LedgerDemandVM>)data.ToList();
            }
            else if(id == 15)
            {
                var data = (from x in ctx.TblDemand
                                           .Where(x => x.IsPaymentMade == false && x.IsCancelled == false)
                                        .OrderBy(xx => xx.TransactionId)
                                        .OrderBy(xx => xx.TaxPayerId)
                            join y in ctx.TblDemandNo on x.DemandNoId equals y.DemandNoId
                            join z in ctx.TblTransactionDetail on x.TransactionId equals z.TransactionId
                            join a in ctx.MstTransactionType on z.TransactionTypeId equals a.TransactionTypeId
                            let cuc_sum = ctx.TblDemand.Where(y => y.DemandNoId == x.DemandNoId).Sum(x => x.TotalAmount)
                            let cuc_sumd = ctx.TblDemand.Where(y => y.DemandNoId == x.DemandNoId).Sum(x => x.DemandAmount)
                            let cuc_sume = ctx.TblDemand.Where(y => y.DemandNoId == x.DemandNoId).Sum(x => x.ExemptionAmount).GetValueOrDefault()
                            where a.TransactionTypeId == 12 || a.TransactionTypeId == 15 || a.TransactionTypeId == 17 || a.TransactionTypeId == 18

                            select new LedgerDemandVM
                            {
                                TotalAmount = cuc_sum,
                                DemandAmount = cuc_sumd,
                                ExemptionAmount = cuc_sume,
                                ExemptionLetter = x.ExemptionLetter,
                                DemandNo = y.DemandNo,
                                TransactionType = a.TransactionType
                            }).Distinct();
                return (IList<LedgerDemandVM>)data.ToList();
            }
            else if(id == 42){
                var data = (from x in ctx.TblDemand
                                           .Where(x => x.IsPaymentMade == false && x.IsCancelled == false)
                                        .OrderBy(xx => xx.TransactionId)
                                        .OrderBy(xx => xx.TaxPayerId)
                            join y in ctx.TblDemandNo on x.DemandNoId equals y.DemandNoId
                            join z in ctx.TblTransactionDetail on x.TransactionId equals z.TransactionId
                            join a in ctx.MstTransactionType on z.TransactionTypeId equals a.TransactionTypeId
                            let cuc_sum = ctx.TblDemand.Where(y => y.DemandNoId == x.DemandNoId).Sum(x => x.TotalAmount)
                            let cuc_sumd = ctx.TblDemand.Where(y => y.DemandNoId == x.DemandNoId).Sum(x => x.DemandAmount)
                            let cuc_sume = ctx.TblDemand.Where(y => y.DemandNoId == x.DemandNoId).Sum(x => x.ExemptionAmount).GetValueOrDefault()
                            where a.TransactionTypeId == 42

                            select new LedgerDemandVM
                            {
                                TotalAmount = cuc_sum,
                                DemandAmount = cuc_sumd,
                                ExemptionAmount = cuc_sume,
                                ExemptionLetter = x.ExemptionLetter,
                                DemandNo = y.DemandNo,
                                TransactionType = a.TransactionType
                            }).Distinct();
                return (IList<LedgerDemandVM>)data.ToList();
            }
            else if(id == 10)
            {
                var data = (from x in ctx.TblDemand
                                           .Where(x => x.IsPaymentMade == false && x.IsCancelled == false)
                                        .OrderBy(xx => xx.TransactionId)
                                        .OrderBy(xx => xx.TaxPayerId)
                            join y in ctx.TblDemandNo on x.DemandNoId equals y.DemandNoId
                            join z in ctx.TblTransactionDetail on x.TransactionId equals z.TransactionId
                            join a in ctx.MstTransactionType on z.TransactionTypeId equals a.TransactionTypeId
                            let cuc_sum = ctx.TblDemand.Where(y => y.DemandNoId == x.DemandNoId).Sum(x => x.TotalAmount)
                            let cuc_sumd = ctx.TblDemand.Where(y => y.DemandNoId == x.DemandNoId).Sum(x => x.DemandAmount)
                            let cuc_sume = ctx.TblDemand.Where(y => y.DemandNoId == x.DemandNoId).Sum(x => x.ExemptionAmount).GetValueOrDefault()
                            where a.TransactionTypeId == 10 || a.TransactionTypeId == 14 || a.TransactionTypeId == 23 || a.TransactionTypeId == 24 ||
                            a.TransactionTypeId == 25 || a.TransactionTypeId == 26 || a.TransactionTypeId == 27 || a.TransactionTypeId == 28 || 
                            a.TransactionTypeId == 29 || a.TransactionTypeId == 30 || a.TransactionTypeId == 32


                            select new LedgerDemandVM
                            {
                                TotalAmount = cuc_sum,
                                DemandAmount = cuc_sumd,
                                ExemptionAmount = cuc_sume,
                                ExemptionLetter = x.ExemptionLetter,
                                DemandNo = y.DemandNo,
                                TransactionType = a.TransactionType
                            }).Distinct();
                return (IList<LedgerDemandVM>)data.ToList();
            }
            else if(id == 19)
            {
                var data = (from x in ctx.TblDemand
                                          .Where(x => x.IsPaymentMade == false && x.IsCancelled == false)
                                       .OrderBy(xx => xx.TransactionId)
                                       .OrderBy(xx => xx.TaxPayerId)
                            join y in ctx.TblDemandNo on x.DemandNoId equals y.DemandNoId
                            join z in ctx.TblTransactionDetail on x.TransactionId equals z.TransactionId
                            join a in ctx.MstTransactionType on z.TransactionTypeId equals a.TransactionTypeId
                            let cuc_sum = ctx.TblDemand.Where(y => y.DemandNoId == x.DemandNoId).Sum(x => x.TotalAmount)
                            let cuc_sumd = ctx.TblDemand.Where(y => y.DemandNoId == x.DemandNoId).Sum(x => x.DemandAmount)
                            let cuc_sume = ctx.TblDemand.Where(y => y.DemandNoId == x.DemandNoId).Sum(x => x.ExemptionAmount).GetValueOrDefault()
                            where a.TransactionTypeId == 19 || a.TransactionTypeId == 43 

                            select new LedgerDemandVM
                            {
                                TotalAmount = cuc_sum,
                                DemandAmount = cuc_sumd,
                                ExemptionAmount = cuc_sume,
                                ExemptionLetter = x.ExemptionLetter,
                                DemandNo = y.DemandNo,
                                TransactionType = a.TransactionType
                            }).Distinct();
                return (IList<LedgerDemandVM>)data.ToList();
            }
            else if(id == 2)
            {
                var data = (from x in ctx.TblDemand
                                         .Where(x => x.IsPaymentMade == false && x.IsCancelled == false)
                                      .OrderBy(xx => xx.TransactionId)
                                      .OrderBy(xx => xx.TaxPayerId)
                            join y in ctx.TblDemandNo on x.DemandNoId equals y.DemandNoId
                            join z in ctx.TblTransactionDetail on x.TransactionId equals z.TransactionId
                            join a in ctx.MstTransactionType on z.TransactionTypeId equals a.TransactionTypeId
                            let cuc_sum = ctx.TblDemand.Where(y => y.DemandNoId == x.DemandNoId).Sum(x => x.TotalAmount)
                            let cuc_sumd = ctx.TblDemand.Where(y => y.DemandNoId == x.DemandNoId).Sum(x => x.DemandAmount)
                            let cuc_sume = ctx.TblDemand.Where(y => y.DemandNoId == x.DemandNoId).Sum(x => x.ExemptionAmount).GetValueOrDefault()
                            where a.TransactionTypeId == 2 || a.TransactionTypeId == 5 || a.TransactionTypeId == 6 || a.TransactionTypeId == 7 ||
                            a.TransactionTypeId == 8 || a.TransactionTypeId == 21 || a.TransactionTypeId == 22 



                            select new LedgerDemandVM
                            {
                                TotalAmount = cuc_sum,
                                DemandAmount = cuc_sumd,
                                ExemptionAmount = cuc_sume,
                                ExemptionLetter = x.ExemptionLetter,
                                DemandNo = y.DemandNo,
                                TransactionType = a.TransactionType
                            }).Distinct();
                return (IList<LedgerDemandVM>)data.ToList();
            }
            else if(id == 11)
            {
                var data = (from x in ctx.TblDemand
                                                        .Where(x => x.IsPaymentMade == false && x.IsCancelled == false)
                                                     .OrderBy(xx => xx.TransactionId)
                                                     .OrderBy(xx => xx.TaxPayerId)
                            join y in ctx.TblDemandNo on x.DemandNoId equals y.DemandNoId
                            join z in ctx.TblTransactionDetail on x.TransactionId equals z.TransactionId
                            join a in ctx.MstTransactionType on z.TransactionTypeId equals a.TransactionTypeId
                            let cuc_sum = ctx.TblDemand.Where(y => y.DemandNoId == x.DemandNoId).Sum(x => x.TotalAmount)
                            let cuc_sumd = ctx.TblDemand.Where(y => y.DemandNoId == x.DemandNoId).Sum(x => x.DemandAmount)
                            let cuc_sume = ctx.TblDemand.Where(y => y.DemandNoId == x.DemandNoId).Sum(x => x.ExemptionAmount).GetValueOrDefault()
                            where a.TransactionTypeId == 11 

                            select new LedgerDemandVM
                            {
                                TotalAmount = cuc_sum,
                                DemandAmount = cuc_sumd,
                                ExemptionAmount = cuc_sume,
                                ExemptionLetter = x.ExemptionLetter,
                                DemandNo = y.DemandNo,
                                TransactionType = a.TransactionType
                            }).Distinct();
                return (IList<LedgerDemandVM>)data.ToList();
            }
            else if (id == 54)
            {
                var data = (from x in ctx.TblDemand
                                         .Where(x => x.IsPaymentMade == false && x.IsCancelled == false)
                                      .OrderBy(xx => xx.TransactionId)
                                      .OrderBy(xx => xx.ApplicantId)
                            join y in ctx.TblDemandNo on x.DemandNoId equals y.DemandNoId
                            join z in ctx.TblTransactionDetail on x.TransactionId equals z.TransactionId
                            join a in ctx.MstTransactionType on z.TransactionTypeId equals a.TransactionTypeId
                            let cuc_sum = ctx.TblDemand.Where(y => y.DemandNoId == x.DemandNoId).Sum(x => x.TotalAmount)
                            let cuc_sumd = ctx.TblDemand.Where(y => y.DemandNoId == x.DemandNoId).Sum(x => x.DemandAmount)
                            let cuc_sume = ctx.TblDemand.Where(y => y.DemandNoId == x.DemandNoId).Sum(x => x.ExemptionAmount).GetValueOrDefault()
                            where a.TransactionTypeId == 9

                            select new LedgerDemandVM
                            {
                                TotalAmount = cuc_sum,
                                DemandAmount = cuc_sumd,
                                ExemptionAmount = cuc_sume,
                                ExemptionLetter = x.ExemptionLetter,
                                DemandNo = y.DemandNo,
                                TransactionType = a.TransactionType
                            }).Distinct();
                return (IList<LedgerDemandVM>)data.ToList();
            }
            else
            {
                var data = (from x in ctx.TblDemand
                            .Where(x => x.IsPaymentMade == false && x.IsCancelled == false)
                            .OrderBy(xx => xx.TransactionId)
                            .OrderBy(xx => xx.TaxPayerId)
                            join y in ctx.TblDemandNo on x.DemandNoId equals y.DemandNoId
                            join z in ctx.TblTransactionDetail on x.TransactionId equals z.TransactionId
                            join a in ctx.MstTransactionType on z.TransactionTypeId equals a.TransactionTypeId
                            let cuc_sum = ctx.TblDemand.Where(y => y.DemandNoId == x.DemandNoId).Sum(x => x.TotalAmount)
                            let cuc_sumd = ctx.TblDemand.Where(y => y.DemandNoId == x.DemandNoId).Sum(x => x.DemandAmount)
                            let cuc_sume = ctx.TblDemand.Where(y => y.DemandNoId == x.DemandNoId).Sum(x => x.ExemptionAmount).GetValueOrDefault()
                            where a.TransactionTypeId == 9 || a.TransactionTypeId == 32 

                            select new LedgerDemandVM
                            {
                                TotalAmount = cuc_sum,
                                DemandAmount = cuc_sumd,
                                ExemptionAmount = cuc_sume,
                                ExemptionLetter = x.ExemptionLetter,
                                DemandNo = y.DemandNo,
                                TransactionType = a.TransactionType
                            }).Distinct();
                return (IList<LedgerDemandVM>)data.ToList();
            }
        }
        public async Task<IList<LedgerDemandVM>> GetDemandWithSearch(string DemandNo, string ConsumerNo)
        {

            var bdata = ctx.MstWaterConnection.Where(x => x.IsActive == true && x.ConsumerNo == ConsumerNo);
            if (bdata.Any())
            {
                decimal rmsamt = 0;

                //var RMSYear = "";
                List<LedgerDemandVM> LandTransactionList = new List<LedgerDemandVM>();
                //List<LandTransactionDetail> TransferrorList = new List<LandTransactionDetail>();
                try
                {
                    //TransactionID = "14170920";
                    using (var httpClient = new HttpClient())
                    {
                        //httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", "812c2d79-36f4-3610-937c-6363d8e18b2d".ToString());
                        // using (var response = await httpClient.GetAsync("https://revenue.thimphucity.bt:84/api/Service/GetLastPaymentDetail?" + "TPID=" + TaxPayerId + "&LandDetailsID=" + LandDetailId))
                        using (var response = await httpClient.GetAsync("http://172.24.40.3:84/api/Service/GetLastPaymentDetailForWater?" + "WaterConnectionId=" + bdata.FirstOrDefault().WaterConnectionId))
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            // reservationList = JsonConvert.DeserializeObject<CitizenDetailr>(apiResponse);
                            //CitizenDetailsResponse datalist = JsonConvert.DeserializeObject<CitizenDetailsResponse>(apiResponse);
                            //var datalist1 = JsonConvert.DeserializeObject<List<CitizenDetailsResponse>>(apiResponse);
                            // Root citizenDetailsResponse = JsonConvert.DeserializeObject(apiResponse);

                            if (response.IsSuccessStatusCode)
                            {
                                var json = response.Content.ReadAsStringAsync().Result;
                                dynamic json_result = JsonConvert.DeserializeObject(json);
                                if (json_result = true)
                                {
                                    if (JObject.Parse(json).ToString() == "{}")
                                    {
                                        return LandTransactionList.ToList();
                                        //citizenList.Add(new CitizenDetail
                                        //{
                                        //    apistatus = "NoData"
                                        //}) ;
                                    }
                                    else
                                    {
                                        //var ds = JsonConvert.DeserializeObject<List<KeyValuePair<string>>;
                                        //var value = JsonConvert.DeserializeObject<List<KeyValuePair<string, object>>>(json).ToDictionary(x => x.Key, y => y.Value);
                                        var details = JObject.Parse(json);
                                        rmsamt = Convert.ToDecimal(details["amount"]);

                                        //LandTransactionList.Add(new LandOwneshipModel
                                        //    {

                                        //    });;

                                    }
                                }
                            }
                            if (Convert.ToInt32(response.StatusCode) == 400)
                            {
                                return LandTransactionList.ToList();
                            }
                        }

                    }
                }
                catch (Exception EX)
                {

                }
            }
            var WaterReading = (
              from x in ctx.MstWaterConnection.Where(x => x.ConsumerNo == ConsumerNo)
              join y in ctx.TblWaterMeterReading on x.WaterConnectionId equals y.WaterConnectionId
              select y.TransactionId).ToList();
            var Demand = (
                from x in ctx.TblDemandNo.Where(x => x.DemandNo == DemandNo)
                join y in ctx.TblDemand on x.DemandNoId equals y.DemandNoId
                select y.TransactionId).ToList();
            var data = (from x in ctx.TblDemand.Where(x => WaterReading.Contains(x.TransactionId) || Demand.Contains(x.TransactionId))
                            //.Where(x => x.DemandNoId == 18)
                            //.OrderBy(xx => xx.TransactionId)
                            //.OrderBy(xx => xx.TaxPayerId)
                        join y in ctx.TblDemandNo on x.DemandNoId equals y.DemandNoId //where y.DemandNo== DemandNo
                        where x.IsPaymentMade == false && x.IsCancelled == false
                        let cuc_sum = ctx.TblDemand.Where(y => y.DemandNoId == x.DemandNoId).Sum(x => x.TotalAmount)
                        let cuc_sumd = ctx.TblDemand.Where(y => y.DemandNoId == x.DemandNoId).Sum(x => x.DemandAmount)
                        let cuc_sume = ctx.TblDemand.Where(y => y.DemandNoId == x.DemandNoId).Sum(x => x.ExemptionAmount).GetValueOrDefault()

                        orderby x.TransactionId, x.TaxPayerId
                        select new LedgerDemandVM
                        {
                            TransactionId = x.TransactionId,
                            //TransactionId = x.TransactionId,
                            DemandNoId = x.DemandNoId,
                            TotalAmount = cuc_sum,
                            //TaxId = x.TaxId,
                            //FinancialYearId = x.FinancialYearId,
                            //CalendarYearId = x.CalendarYearId,
                            DemandAmount = cuc_sumd,
                            //TotalAmount = x.TotalAmount,
                            ExemptionAmount = cuc_sume,
                            ExemptionLetter = x.ExemptionLetter,
                            //CreatedBy = x.CreatedBy,
                            //CreatedOn = x.CreatedOn,
                            //ModifiedBy = x.ModifiedBy,
                            //ModifiedOn = x.ModifiedOn,
                            DemandNo = y.DemandNo,
                            // rmsamt = rmsamt,
                        }).Distinct().ToList();

            return data.ToList();
        }
        //**********************************************Land Transaction Fee  ********************************************************************
        public IList<LedgerDemandVM> GetLandTransactionFee(string DemandNo, string Ttin, string Cid)
        {
            var tid = "34,35,36,37,38,39,40,41";
          
            if (DemandNo != "" && DemandNo != null)
            {
                var Demand = (
                from x in ctx.TblDemandNo.Where(x => x.DemandNo == DemandNo)
                join y in ctx.TblDemand on x.DemandNoId equals y.DemandNoId
                join t in ctx.TblTransactionDetail on y.TransactionId equals t.TransactionId
                where tid.Contains(t.TransactionTypeId.ToString())
                select y.TransactionId).ToList();

                var data = (from x in ctx.TblDemand.Where(x => Demand.Contains(x.TransactionId))
                            //.Where(x => x.DemandNoId == 18)
                            .OrderBy(xx => xx.TransactionId)
                            .OrderBy(xx => xx.TaxPayerId)
                            join y in ctx.TblDemandNo on x.DemandNoId equals y.DemandNoId //where y.DemandNo== DemandNo
                            where x.IsPaymentMade == false && x.IsCancelled == false
                            let cuc_sum = ctx.TblDemand.Where(y => y.DemandNoId == x.DemandNoId).Sum(x => x.TotalAmount)
                            let cuc_sumd = ctx.TblDemand.Where(y => y.DemandNoId == x.DemandNoId).Sum(x => x.DemandAmount)
                            let cuc_sume = ctx.TblDemand.Where(y => y.DemandNoId == x.DemandNoId).Sum(x => x.ExemptionAmount).GetValueOrDefault()

                            select new LedgerDemandVM
                            {
                                TotalAmount = cuc_sum,
                                //TransactionId = x.TransactionId,
                                DemandNoId = x.DemandNoId,
                                //TaxId = x.TaxId,
                                //FinancialYearId = x.FinancialYearId,
                                //CalendarYearId = x.CalendarYearId,
                                DemandAmount = cuc_sumd,
                                //TotalAmount = x.TotalAmount,
                                ExemptionAmount = cuc_sume,
                                ExemptionLetter = x.ExemptionLetter,
                                //CreatedBy = x.CreatedBy,
                                //CreatedOn = x.CreatedOn,
                                //ModifiedBy = x.ModifiedBy,
                                //ModifiedOn = x.ModifiedOn,
                                DemandNo = y.DemandNo,
                                //TaxName = z.TaxName
                            }).Distinct();

                return (IList<LedgerDemandVM>)data.ToList();
            }
            else
            {
                var Vendor = (
                 from x in ctx.MstTaxPayerProfile.Where(x => x.Ttin == Ttin || x.Cid == Cid)
                 join y in ctx.TblDemand on x.TaxPayerId equals y.TaxPayerId
                 join t in ctx.TblTransactionDetail on y.TransactionId equals t.TransactionId
                 where tid.Contains(t.TransactionTypeId.ToString())
                 select y.TransactionId).ToList();

                var data = (from x in ctx.TblDemand.Where(x => Vendor.Contains(x.TransactionId))
                            //.Where(x => x.DemandNoId == 18)
                            .OrderBy(xx => xx.TransactionId)
                            .OrderBy(xx => xx.TaxPayerId)
                            join y in ctx.TblDemandNo on x.DemandNoId equals y.DemandNoId //where y.DemandNo== DemandNo
                            where x.IsPaymentMade == false && x.IsCancelled == false
                            let cuc_sum = ctx.TblDemand.Where(y => y.DemandNoId == x.DemandNoId).Sum(x => x.TotalAmount)
                            let cuc_sumd = ctx.TblDemand.Where(y => y.DemandNoId == x.DemandNoId).Sum(x => x.DemandAmount)
                            let cuc_sume = ctx.TblDemand.Where(y => y.DemandNoId == x.DemandNoId).Sum(x => x.ExemptionAmount).GetValueOrDefault()

                            select new LedgerDemandVM
                            {
                                TotalAmount = cuc_sum,
                                //TransactionId = x.TransactionId,
                                DemandNoId = x.DemandNoId,
                                //TaxId = x.TaxId,
                                //FinancialYearId = x.FinancialYearId,
                                //CalendarYearId = x.CalendarYearId,
                                DemandAmount = cuc_sumd,
                                //TotalAmount = x.TotalAmount,
                                ExemptionAmount = cuc_sume,
                                ExemptionLetter = x.ExemptionLetter,
                                //CreatedBy = x.CreatedBy,
                                //CreatedOn = x.CreatedOn,
                                //ModifiedBy = x.ModifiedBy,
                                //ModifiedOn = x.ModifiedOn,
                                DemandNo = y.DemandNo,
                                //TaxName = z.TaxName
                            }).Distinct();

                return (IList<LedgerDemandVM>)data.ToList();
            }
        }

        //**********************************************Construction Approval  ********************************************************************
        public List<LedgerDemandVM> FetchConstructionApproval(string DemandNo, string Ttin, string Cid)
        {
            var tid = "13";

           
            if (DemandNo != "" && DemandNo != null)
            {
                var Demand = (
                from x in ctx.TblDemandNo.Where(x => x.DemandNo == DemandNo)
                join y in ctx.TblDemand on x.DemandNoId equals y.DemandNoId
                join t in ctx.TblTransactionDetail on y.TransactionId equals t.TransactionId
                where tid.Contains(t.TransactionTypeId.ToString())
                select y.TransactionId).ToList();

                var data = (from x in ctx.TblDemand.Where(x =>  Demand.Contains(x.TransactionId))
                            //.Where(x => x.DemandNoId == 18)
                            .OrderBy(xx => xx.TransactionId)
                            .OrderBy(xx => xx.TaxPayerId)
                            join y in ctx.TblDemandNo on x.DemandNoId equals y.DemandNoId //where y.DemandNo== DemandNo
                            where x.IsPaymentMade == false && x.IsCancelled == false
                            let cuc_sum = ctx.TblDemand.Where(y => y.DemandNoId == x.DemandNoId).Sum(x => x.TotalAmount)
                            let cuc_sumd = ctx.TblDemand.Where(y => y.DemandNoId == x.DemandNoId).Sum(x => x.DemandAmount)
                            let cuc_sume = ctx.TblDemand.Where(y => y.DemandNoId == x.DemandNoId).Sum(x => x.ExemptionAmount).GetValueOrDefault()

                            select new LedgerDemandVM
                            {
                                TotalAmount = cuc_sum,
                                //TransactionId = x.TransactionId,
                                DemandNoId = x.DemandNoId,
                                //TaxId = x.TaxId,
                                //FinancialYearId = x.FinancialYearId,
                                //CalendarYearId = x.CalendarYearId,
                                DemandAmount = cuc_sumd,
                                //TotalAmount = x.TotalAmount,
                                ExemptionAmount = cuc_sume,
                                ExemptionLetter = x.ExemptionLetter,
                                //CreatedBy = x.CreatedBy,
                                //CreatedOn = x.CreatedOn,
                                //ModifiedBy = x.ModifiedBy,
                                //ModifiedOn = x.ModifiedOn,
                                DemandNo = y.DemandNo,
                                //TaxName = z.TaxName
                            }).Distinct();

                return (List<LedgerDemandVM>)data.ToList();
            }
            else
            {

                var Vendor = (
                  from x in ctx.MstTaxPayerProfile.Where(x => x.Ttin == Ttin || x.Cid == Cid)
                  join y in ctx.TblDemand on x.TaxPayerId equals y.TaxPayerId
                  join t in ctx.TblTransactionDetail on y.TransactionId equals t.TransactionId
                  where tid.Contains(t.TransactionTypeId.ToString())
                  select y.TransactionId).ToList();

                var data = (from x in ctx.TblDemand.Where(x => Vendor.Contains(x.TransactionId))
                            //.Where(x => x.DemandNoId == 18)
                            .OrderBy(xx => xx.TransactionId)
                            .OrderBy(xx => xx.TaxPayerId)
                            join y in ctx.TblDemandNo on x.DemandNoId equals y.DemandNoId //where y.DemandNo== DemandNo
                            where x.IsPaymentMade == false && x.IsCancelled == false
                            let cuc_sum = ctx.TblDemand.Where(y => y.DemandNoId == x.DemandNoId).Sum(x => x.TotalAmount)
                            let cuc_sumd = ctx.TblDemand.Where(y => y.DemandNoId == x.DemandNoId).Sum(x => x.DemandAmount)
                            let cuc_sume = ctx.TblDemand.Where(y => y.DemandNoId == x.DemandNoId).Sum(x => x.ExemptionAmount).GetValueOrDefault()

                            select new LedgerDemandVM
                            {
                                TotalAmount = cuc_sum,
                                //TransactionId = x.TransactionId,
                                DemandNoId = x.DemandNoId,
                                //TaxId = x.TaxId,
                                //FinancialYearId = x.FinancialYearId,
                                //CalendarYearId = x.CalendarYearId,
                                DemandAmount = cuc_sumd,
                                //TotalAmount = x.TotalAmount,
                                ExemptionAmount = cuc_sume,
                                ExemptionLetter = x.ExemptionLetter,
                                //CreatedBy = x.CreatedBy,
                                //CreatedOn = x.CreatedOn,
                                //ModifiedBy = x.ModifiedBy,
                                //ModifiedOn = x.ModifiedOn,
                                DemandNo = y.DemandNo,
                                //TaxName = z.TaxName
                            }).Distinct();

                return (List<LedgerDemandVM>)data.ToList();
            }
                }


        //**********************************************Construction Approval Application Fee Detail  ********************************************************************
        public List<LedgerDemandVM> FetchConstructionApprovalApplicationFeeDetail(string DemandNo, string Ttin, string Cid)
        {
            var tid = "31";
         
            if (DemandNo != "" && DemandNo != null)
            {
                var Demand = (
                from x in ctx.TblDemandNo.Where(x => x.DemandNo == DemandNo)
                join y in ctx.TblDemand on x.DemandNoId equals y.DemandNoId
                join t in ctx.TblTransactionDetail on y.TransactionId equals t.TransactionId
                where tid.Contains(t.TransactionTypeId.ToString())
                select y.TransactionId).ToList();

                var data = (from x in ctx.TblDemand.Where(x => Demand.Contains(x.TransactionId))
                            //.Where(x => x.DemandNoId == 18)
                            .OrderBy(xx => xx.TransactionId)
                            .OrderBy(xx => xx.TaxPayerId)
                            join y in ctx.TblDemandNo on x.DemandNoId equals y.DemandNoId //where y.DemandNo== DemandNo
                            where x.IsPaymentMade == false && x.IsCancelled == false
                            let cuc_sum = ctx.TblDemand.Where(y => y.DemandNoId == x.DemandNoId).Sum(x => x.TotalAmount)
                            let cuc_sumd = ctx.TblDemand.Where(y => y.DemandNoId == x.DemandNoId).Sum(x => x.DemandAmount)
                            let cuc_sume = ctx.TblDemand.Where(y => y.DemandNoId == x.DemandNoId).Sum(x => x.ExemptionAmount).GetValueOrDefault()

                            select new LedgerDemandVM
                            {
                                TotalAmount = cuc_sum,
                                //TransactionId = x.TransactionId,
                                DemandNoId = x.DemandNoId,
                                //TaxId = x.TaxId,
                                //FinancialYearId = x.FinancialYearId,
                                //CalendarYearId = x.CalendarYearId,
                                DemandAmount = cuc_sumd,
                                //TotalAmount = x.TotalAmount,
                                ExemptionAmount = cuc_sume,
                                ExemptionLetter = x.ExemptionLetter,
                                //CreatedBy = x.CreatedBy,
                                //CreatedOn = x.CreatedOn,
                                //ModifiedBy = x.ModifiedBy,
                                //ModifiedOn = x.ModifiedOn,
                                DemandNo = y.DemandNo,
                                //TaxName = z.TaxName
                            }).Distinct();

                return (List<LedgerDemandVM>)data.ToList();
            }
            else
            {
                var Vendor = (
                from x in ctx.MstTaxPayerProfile.Where(x => x.Ttin == Ttin || x.Cid == Cid)
                join y in ctx.TblDemand on x.TaxPayerId equals y.TaxPayerId
                join t in ctx.TblTransactionDetail on y.TransactionId equals t.TransactionId
                where tid.Contains(t.TransactionTypeId.ToString())
                select y.TransactionId).ToList();

                var data = (from x in ctx.TblDemand.Where(x => Vendor.Contains(x.TransactionId) )
                            //.Where(x => x.DemandNoId == 18)
                            .OrderBy(xx => xx.TransactionId)
                            .OrderBy(xx => xx.TaxPayerId)
                            join y in ctx.TblDemandNo on x.DemandNoId equals y.DemandNoId //where y.DemandNo== DemandNo
                            where x.IsPaymentMade == false && x.IsCancelled == false
                            let cuc_sum = ctx.TblDemand.Where(y => y.DemandNoId == x.DemandNoId).Sum(x => x.TotalAmount)
                            let cuc_sumd = ctx.TblDemand.Where(y => y.DemandNoId == x.DemandNoId).Sum(x => x.DemandAmount)
                            let cuc_sume = ctx.TblDemand.Where(y => y.DemandNoId == x.DemandNoId).Sum(x => x.ExemptionAmount).GetValueOrDefault()

                            select new LedgerDemandVM
                            {
                                TotalAmount = cuc_sum,
                                //TransactionId = x.TransactionId,
                                DemandNoId = x.DemandNoId,
                                //TaxId = x.TaxId,
                                //FinancialYearId = x.FinancialYearId,
                                //CalendarYearId = x.CalendarYearId,
                                DemandAmount = cuc_sumd,
                                //TotalAmount = x.TotalAmount,
                                ExemptionAmount = cuc_sume,
                                ExemptionLetter = x.ExemptionLetter,
                                //CreatedBy = x.CreatedBy,
                                //CreatedOn = x.CreatedOn,
                                //ModifiedBy = x.ModifiedBy,
                                //ModifiedOn = x.ModifiedOn,
                                DemandNo = y.DemandNo,
                                //TaxName = z.TaxName
                            }).Distinct();

                return (List<LedgerDemandVM>)data.ToList();
            }
        }

        //**********************************************   UnScheduledParkingRecord  ********************************************************************
        public List<LedgerDemandVM> GetUnScheduledParkingRecord(string DemandNo, string Cid)
        {
            var tid = "42";
          
            if (DemandNo != "" && DemandNo != null)
            {
                var Demand = (
                from x in ctx.TblDemandNo.Where(x => x.DemandNo == DemandNo)
                join y in ctx.TblDemand on x.DemandNoId equals y.DemandNoId
                join t in ctx.TblTransactionDetail on y.TransactionId equals t.TransactionId
                where tid.Contains(t.TransactionTypeId.ToString())
                select y.TransactionId).ToList();

                var data = (from x in ctx.TblDemand.Where(x =>Demand.Contains(x.TransactionId))
                            //.Where(x => x.DemandNoId == 18)
                            .OrderBy(xx => xx.TransactionId)
                            .OrderBy(xx => xx.TaxPayerId)
                            join y in ctx.TblDemandNo on x.DemandNoId equals y.DemandNoId //where y.DemandNo== DemandNo
                            where x.IsPaymentMade == false && x.IsCancelled == false
                            let cuc_sum = ctx.TblDemand.Where(y => y.DemandNoId == x.DemandNoId).Sum(x => x.TotalAmount)
                            let cuc_sumd = ctx.TblDemand.Where(y => y.DemandNoId == x.DemandNoId).Sum(x => x.DemandAmount)
                            let cuc_sume = ctx.TblDemand.Where(y => y.DemandNoId == x.DemandNoId).Sum(x => x.ExemptionAmount).GetValueOrDefault()

                            select new LedgerDemandVM
                            {
                                TotalAmount = cuc_sum,
                                //TransactionId = x.TransactionId,
                                DemandNoId = x.DemandNoId,
                                //TaxId = x.TaxId,
                                //FinancialYearId = x.FinancialYearId,
                                //CalendarYearId = x.CalendarYearId,
                                DemandAmount = cuc_sumd,
                                //TotalAmount = x.TotalAmount,
                                ExemptionAmount = cuc_sume,
                                ExemptionLetter = x.ExemptionLetter,
                                //CreatedBy = x.CreatedBy,
                                //CreatedOn = x.CreatedOn,
                                //ModifiedBy = x.ModifiedBy,
                                //ModifiedOn = x.ModifiedOn,
                                DemandNo = y.DemandNo,
                                //TaxName = z.TaxName
                            }).Distinct();

                return (List<LedgerDemandVM>)data.ToList();
                    }
            else
            {
                var Vendor = (
                 from x in ctx.TblUnScheduledParkingRecord.Where(x => x.Cid == Cid)

                 join t in ctx.TblTransactionDetail on x.TransactionId equals t.TransactionId
                 where tid.Contains(t.TransactionTypeId.ToString())
                 select x.TransactionId).ToList();

                var data = (from x in ctx.TblDemand.Where(x => Vendor.Contains(x.TransactionId))
                            //.Where(x => x.DemandNoId == 18)
                            .OrderBy(xx => xx.TransactionId)
                            .OrderBy(xx => xx.TaxPayerId)
                            join y in ctx.TblDemandNo on x.DemandNoId equals y.DemandNoId //where y.DemandNo== DemandNo
                            where x.IsPaymentMade == false && x.IsCancelled == false
                            let cuc_sum = ctx.TblDemand.Where(y => y.DemandNoId == x.DemandNoId).Sum(x => x.TotalAmount)
                            let cuc_sumd = ctx.TblDemand.Where(y => y.DemandNoId == x.DemandNoId).Sum(x => x.DemandAmount)
                            let cuc_sume = ctx.TblDemand.Where(y => y.DemandNoId == x.DemandNoId).Sum(x => x.ExemptionAmount).GetValueOrDefault()

                            select new LedgerDemandVM
                            {
                                TotalAmount = cuc_sum,
                                //TransactionId = x.TransactionId,
                                DemandNoId = x.DemandNoId,
                                //TaxId = x.TaxId,
                                //FinancialYearId = x.FinancialYearId,
                                //CalendarYearId = x.CalendarYearId,
                                DemandAmount = cuc_sumd,
                                //TotalAmount = x.TotalAmount,
                                ExemptionAmount = cuc_sume,
                                ExemptionLetter = x.ExemptionLetter,
                                //CreatedBy = x.CreatedBy,
                                //CreatedOn = x.CreatedOn,
                                //ModifiedBy = x.ModifiedBy,
                                //ModifiedOn = x.ModifiedOn,
                                DemandNo = y.DemandNo,
                                //TaxName = z.TaxName
                            }).Distinct();

                return (List<LedgerDemandVM>)data.ToList();
            }
        }

        //**********************************************Water connection ********************************************************************
        public IList<LedgerDemandVM> GetWaterConnectionDemand(string DemandNo, string G2cNo, string Ttin)
        {
            var tid = "2,5,6,7,8,22";
            
            
            
            if(DemandNo != "" && DemandNo != null)
            {
                var Demand = (
                from x in ctx.TblDemandNo.Where(x => x.DemandNo == DemandNo)
                join y in ctx.TblDemand on x.DemandNoId equals y.DemandNoId
                join t in ctx.TblTransactionDetail on y.TransactionId equals t.TransactionId
                where tid.Contains(t.TransactionTypeId.ToString())
                select y.TransactionId).ToList();

                var data = (from x in ctx.TblDemand.Where(x => Demand.Contains(x.TransactionId))
                            //.Where(x => x.DemandNoId == 18)
                            .OrderBy(xx => xx.TransactionId)
                            .OrderBy(xx => xx.TaxPayerId)
                            join y in ctx.TblDemandNo on x.DemandNoId equals y.DemandNoId //where y.DemandNo== DemandNo
                            where x.IsPaymentMade == false && x.IsCancelled == false
                            let cuc_sum = ctx.TblDemand.Where(y => y.DemandNoId == x.DemandNoId).Sum(x => x.TotalAmount)
                            let cuc_sumd = ctx.TblDemand.Where(y => y.DemandNoId == x.DemandNoId).Sum(x => x.DemandAmount)
                            let cuc_sume = ctx.TblDemand.Where(y => y.DemandNoId == x.DemandNoId).Sum(x => x.ExemptionAmount).GetValueOrDefault()

                            select new LedgerDemandVM
                            {
                                TotalAmount = cuc_sum,
                                //TransactionId = x.TransactionId,
                                DemandNoId = x.DemandNoId,
                                //TaxId = x.TaxId,
                                //FinancialYearId = x.FinancialYearId,
                                //CalendarYearId = x.CalendarYearId,
                                DemandAmount = cuc_sumd,
                                //TotalAmount = x.TotalAmount,
                                ExemptionAmount = cuc_sume,
                                ExemptionLetter = x.ExemptionLetter,
                                //CreatedBy = x.CreatedBy,
                                //CreatedOn = x.CreatedOn,
                                //ModifiedBy = x.ModifiedBy,
                                //ModifiedOn = x.ModifiedOn,
                                DemandNo = y.DemandNo,
                                //TaxName = z.TaxName
                            }).Distinct();

                return (IList<LedgerDemandVM>)data.ToList();

            }
            else
            {
                var Vendor = (
                  from x in ctx.MstTaxPayerProfile.Where(x => 1 == 1)
                  join y in ctx.TblDemand on x.TaxPayerId equals y.TaxPayerId
                  where x.Ttin == Ttin || y.G2cApplicationNo == G2cNo
                  join t in ctx.TblTransactionDetail on y.TransactionId equals t.TransactionId
                  where tid.Contains(t.TransactionTypeId.ToString())
                  select y.TransactionId).ToList();

                var data = (from x in ctx.TblDemand.Where(x => Vendor.Contains(x.TransactionId))
                            //.Where(x => x.DemandNoId == 18)
                            .OrderBy(xx => xx.TransactionId)
                            .OrderBy(xx => xx.TaxPayerId)
                            join y in ctx.TblDemandNo on x.DemandNoId equals y.DemandNoId //where y.DemandNo== DemandNo
                            where x.IsPaymentMade == false && x.IsCancelled == false
                            let cuc_sum = ctx.TblDemand.Where(y => y.DemandNoId == x.DemandNoId).Sum(x => x.TotalAmount)
                            let cuc_sumd = ctx.TblDemand.Where(y => y.DemandNoId == x.DemandNoId).Sum(x => x.DemandAmount)
                            let cuc_sume = ctx.TblDemand.Where(y => y.DemandNoId == x.DemandNoId).Sum(x => x.ExemptionAmount).GetValueOrDefault()

                            select new LedgerDemandVM
                            {
                                TotalAmount = cuc_sum,
                                //TransactionId = x.TransactionId,
                                DemandNoId = x.DemandNoId,
                                //TaxId = x.TaxId,
                                //FinancialYearId = x.FinancialYearId,
                                //CalendarYearId = x.CalendarYearId,
                                DemandAmount = cuc_sumd,
                                //TotalAmount = x.TotalAmount,
                                ExemptionAmount = cuc_sume,
                                ExemptionLetter = x.ExemptionLetter,
                                //CreatedBy = x.CreatedBy,
                                //CreatedOn = x.CreatedOn,
                                //ModifiedBy = x.ModifiedBy,
                                //ModifiedOn = x.ModifiedOn,
                                DemandNo = y.DemandNo,
                                //TaxName = z.TaxName
                            }).Distinct();

                return (IList<LedgerDemandVM>)data.ToList();
            }
            

           
        }

        //**********************************************Miscellaneous********************************************************************
        public IList<LedgerDemandVM> GetmDemandWithSearch(string DemandNo, string Cid)
        {
            var tid = "10,12,32";
           
            if (DemandNo != "" && DemandNo != null)
            {
                var Demand = (
                from x in ctx.TblDemandNo.Where(x => x.DemandNo == DemandNo)
                join y in ctx.TblDemand on x.DemandNoId equals y.DemandNoId
                join t in ctx.TblTransactionDetail on y.TransactionId equals t.TransactionId
                where tid.Contains(t.TransactionTypeId.ToString()) || t.TransactionTypeId > 49
                select y.TransactionId).ToList();

                var data = (from x in ctx.TblDemand.Where(x => Demand.Contains(x.TransactionId))
                            //.Where(x => x.DemandNoId == 18)
                            .OrderBy(xx => xx.TransactionId)
                            .OrderBy(xx => xx.TaxPayerId)
                            join y in ctx.TblDemandNo on x.DemandNoId equals y.DemandNoId //where y.DemandNo== DemandNo
                            where x.IsPaymentMade == false && x.IsCancelled == false
                            let cuc_sum = ctx.TblDemand.Where(y => y.DemandNoId == x.DemandNoId).Sum(x => x.TotalAmount)
                            let cuc_sumd = ctx.TblDemand.Where(y => y.DemandNoId == x.DemandNoId).Sum(x => x.DemandAmount)
                            let cuc_sume = ctx.TblDemand.Where(y => y.DemandNoId == x.DemandNoId).Sum(x => x.ExemptionAmount).GetValueOrDefault()

                            select new LedgerDemandVM
                            {
                                TotalAmount = cuc_sum,
                                //TransactionId = x.TransactionId,
                                DemandNoId = x.DemandNoId,
                                //TaxId = x.TaxId,
                                //FinancialYearId = x.FinancialYearId,
                                //CalendarYearId = x.CalendarYearId,
                                DemandAmount = cuc_sumd,
                                //TotalAmount = x.TotalAmount,
                                ExemptionAmount = cuc_sume,
                                ExemptionLetter = x.ExemptionLetter,
                                //CreatedBy = x.CreatedBy,
                                //CreatedOn = x.CreatedOn,
                                //ModifiedBy = x.ModifiedBy,
                                //ModifiedOn = x.ModifiedOn,
                                DemandNo = y.DemandNo,
                                //TaxName = z.TaxName
                            }).Distinct();

                return (IList<LedgerDemandVM>)data.ToList();
            }
            else
            {
                var Miscellaneous = (
                  from x in ctx.TblMiscellaneousRecord.Where(x => x.Cid == Cid)
                  select x.TransactionId).ToList();

                var data = (from x in ctx.TblDemand.Where(x => Miscellaneous.Contains(x.TransactionId))
                            //.Where(x => x.DemandNoId == 18)
                            .OrderBy(xx => xx.TransactionId)
                            .OrderBy(xx => xx.TaxPayerId)
                            join y in ctx.TblDemandNo on x.DemandNoId equals y.DemandNoId //where y.DemandNo== DemandNo
                            where x.IsPaymentMade == false && x.IsCancelled == false
                            let cuc_sum = ctx.TblDemand.Where(y => y.DemandNoId == x.DemandNoId).Sum(x => x.TotalAmount)
                            let cuc_sumd = ctx.TblDemand.Where(y => y.DemandNoId == x.DemandNoId).Sum(x => x.DemandAmount)
                            let cuc_sume = ctx.TblDemand.Where(y => y.DemandNoId == x.DemandNoId).Sum(x => x.ExemptionAmount).GetValueOrDefault()

                            select new LedgerDemandVM
                            {
                                TotalAmount = cuc_sum,
                                //TransactionId = x.TransactionId,
                                DemandNoId = x.DemandNoId,
                                //TaxId = x.TaxId,
                                //FinancialYearId = x.FinancialYearId,
                                //CalendarYearId = x.CalendarYearId,
                                DemandAmount = cuc_sumd,
                                //TotalAmount = x.TotalAmount,
                                ExemptionAmount = cuc_sume,
                                ExemptionLetter = x.ExemptionLetter,
                                //CreatedBy = x.CreatedBy,
                                //CreatedOn = x.CreatedOn,
                                //ModifiedBy = x.ModifiedBy,
                                //ModifiedOn = x.ModifiedOn,
                                DemandNo = y.DemandNo,
                                //TaxName = z.TaxName
                            }).Distinct();

                return (IList<LedgerDemandVM>)data.ToList();
            }
        }


        //**********************************************Vacuum tanker services********************************************************************
        public List<LedgerDemandVM> GetvacuumtankerDemandWithSearch(string DemandNo, string Name)
        {
            var tid = "11";

            if (DemandNo != "" && DemandNo != null)
            {
                var Demand = (
                from x in ctx.TblDemandNo.Where(x => x.DemandNo == DemandNo)
                join y in ctx.TblDemand on x.DemandNoId equals y.DemandNoId
                join t in ctx.TblTransactionDetail on y.TransactionId equals t.TransactionId
                where tid.Contains(t.TransactionTypeId.ToString())
                select y.TransactionId).ToList();

                var data = (from x in ctx.TblDemand.Where(x => Demand.Contains(x.TransactionId))
                            //.Where(x => x.DemandNoId == 18)
                            .OrderBy(xx => xx.TransactionId)
                            .OrderBy(xx => xx.TaxPayerId)
                            join y in ctx.TblDemandNo on x.DemandNoId equals y.DemandNoId //where y.DemandNo== DemandNo
                            where x.IsPaymentMade == false && x.IsCancelled == false
                            let cuc_sum = ctx.TblDemand.Where(y => y.DemandNoId == x.DemandNoId).Sum(x => x.TotalAmount)
                            let cuc_sumd = ctx.TblDemand.Where(y => y.DemandNoId == x.DemandNoId).Sum(x => x.DemandAmount)
                            let cuc_sume = ctx.TblDemand.Where(y => y.DemandNoId == x.DemandNoId).Sum(x => x.ExemptionAmount).GetValueOrDefault()

                            select new LedgerDemandVM
                            {
                                TotalAmount = cuc_sum,
                                //TransactionId = x.TransactionId,
                                DemandNoId = x.DemandNoId,
                                //TaxId = x.TaxId,
                                //FinancialYearId = x.FinancialYearId,
                                //CalendarYearId = x.CalendarYearId,
                                DemandAmount = cuc_sumd,
                                //TotalAmount = x.TotalAmount,
                                ExemptionAmount = cuc_sume,
                                ExemptionLetter = x.ExemptionLetter,
                                //CreatedBy = x.CreatedBy,
                                //CreatedOn = x.CreatedOn,
                                //ModifiedBy = x.ModifiedBy,
                                //ModifiedOn = x.ModifiedOn,
                                DemandNo = y.DemandNo,
                                //TaxName = z.TaxName
                            }).Distinct();

                return (List<LedgerDemandVM>)data.ToList();
            }
            else
            {
                var vacuumtanker = (
                  from x in ctx.TrnVacuumTankerService.Where(x => x.ContactName == Name)
                  select x.TransactionId).ToList();

                var data = (from x in ctx.TblDemand.Where(x => vacuumtanker.Contains(x.TransactionId))
                            //.Where(x => x.DemandNoId == 18)
                            .OrderBy(xx => xx.TransactionId)
                            .OrderBy(xx => xx.TaxPayerId)
                            join y in ctx.TblDemandNo on x.DemandNoId equals y.DemandNoId //where y.DemandNo== DemandNo
                            where x.IsPaymentMade == false && x.IsCancelled == false
                            let cuc_sum = ctx.TblDemand.Where(y => y.DemandNoId == x.DemandNoId).Sum(x => x.TotalAmount)
                            let cuc_sumd = ctx.TblDemand.Where(y => y.DemandNoId == x.DemandNoId).Sum(x => x.DemandAmount)
                            let cuc_sume = ctx.TblDemand.Where(y => y.DemandNoId == x.DemandNoId).Sum(x => x.ExemptionAmount).GetValueOrDefault()

                            select new LedgerDemandVM
                            {
                                TotalAmount = cuc_sum,
                                //TransactionId = x.TransactionId,
                                DemandNoId = x.DemandNoId,
                                //TaxId = x.TaxId,
                                //FinancialYearId = x.FinancialYearId,
                                //CalendarYearId = x.CalendarYearId,
                                DemandAmount = cuc_sumd,
                                //TotalAmount = x.TotalAmount,
                                ExemptionAmount = cuc_sume,
                                ExemptionLetter = x.ExemptionLetter,
                                //CreatedBy = x.CreatedBy,
                                //CreatedOn = x.CreatedOn,
                                //ModifiedBy = x.ModifiedBy,
                                //ModifiedOn = x.ModifiedOn,
                                DemandNo = y.DemandNo,
                                //TaxName = z.TaxName
                            }).Distinct();

                return (List<LedgerDemandVM>)data.ToList();
            }
        }

        //*******************************************************Vendor************************************************************
        public IList<LedgerDemandVM> GetDemandWithSearch1(string DemandNo, string Ttin)
        { var tid = "15,16,17,18";
           
            if (DemandNo != "" && DemandNo != null)
            {
                var Demand = (
                from x in ctx.TblDemandNo.Where(x => x.DemandNo == DemandNo)
                join y in ctx.TblDemand on x.DemandNoId equals y.DemandNoId
                join t in ctx.TblTransactionDetail on y.TransactionId equals t.TransactionId
                where tid.Contains(t.TransactionTypeId.ToString())
                select y.TransactionId).ToList();

                var data = (from x in ctx.TblDemand.Where(x => Demand.Contains(x.TransactionId))
                            //.Where(x => x.DemandNoId == 18)
                            .OrderBy(xx => xx.TransactionId)
                            .OrderBy(xx => xx.TaxPayerId)
                            join y in ctx.TblDemandNo on x.DemandNoId equals y.DemandNoId //where y.DemandNo== DemandNo
                            where x.IsPaymentMade == false && x.IsCancelled == false
                            let cuc_sum = ctx.TblDemand.Where(y => y.DemandNoId == x.DemandNoId).Sum(x => x.TotalAmount)
                            let cuc_sumd = ctx.TblDemand.Where(y => y.DemandNoId == x.DemandNoId).Sum(x => x.DemandAmount)
                            let cuc_sume = ctx.TblDemand.Where(y => y.DemandNoId == x.DemandNoId).Sum(x => x.ExemptionAmount).GetValueOrDefault()

                            select new LedgerDemandVM
                            {
                                TotalAmount = cuc_sum,
                                //TransactionId = x.TransactionId,
                                DemandNoId = x.DemandNoId,
                                //TaxId = x.TaxId,
                                //FinancialYearId = x.FinancialYearId,
                                //CalendarYearId = x.CalendarYearId,
                                DemandAmount = cuc_sumd,
                                //TotalAmount = x.TotalAmount,
                                ExemptionAmount = cuc_sume,
                                ExemptionLetter = x.ExemptionLetter,
                                //CreatedBy = x.CreatedBy,
                                //CreatedOn = x.CreatedOn,
                                //ModifiedBy = x.ModifiedBy,
                                //ModifiedOn = x.ModifiedOn,
                                DemandNo = y.DemandNo,
                                //TaxName = z.TaxName
                            }).Distinct();

                return (IList<LedgerDemandVM>)data.ToList();
            }
            else
            {
                var Vendor = (
                  from x in ctx.MstTaxPayerProfile.Where(x => x.Ttin == Ttin)
                  join y in ctx.TblDemand on x.TaxPayerId equals y.TaxPayerId
                  join t in ctx.TblTransactionDetail on y.TransactionId equals t.TransactionId
                  join l in ctx.TblLandLeaseDemandDetail on y.LandLeaseDemandDetailId equals l.LandLeaseDemandDetailId
                  into l_temp
                  from l_value in l_temp.DefaultIfEmpty()
                  join p in ctx.TblParkingFeeDemandDetail on y.ParkingDemandDetailId equals p.ParkingDemandDetailId
                  into p_temp
                  from p_value in p_temp.DefaultIfEmpty()
                  join h in ctx.TblHouseRentDemandDetail on y.HouseRentDemandDetailId equals h.HouseRentDemandDetailId
                  into h_temp
                  from h_value in h_temp.DefaultIfEmpty()
                  join s in ctx.TblStallDetailDemand on y.StallDemandDetailId equals s.StallDemandDetailId
                  into s_temp
                  from s_value in s_temp.DefaultIfEmpty()
                  where tid.Contains(t.TransactionTypeId.ToString())
                  select y.TransactionId).ToList();

                var data = (from x in ctx.TblDemand.Where(x => Vendor.Contains(x.TransactionId))
                            //.Where(x => x.DemandNoId == 18)
                            .OrderBy(xx => xx.TransactionId)
                            .OrderBy(xx => xx.TaxPayerId)
                            join y in ctx.TblDemandNo on x.DemandNoId equals y.DemandNoId //where y.DemandNo== DemandNo
                            where x.IsPaymentMade == false && x.IsCancelled == false
                            let cuc_sum = ctx.TblDemand.Where(y => y.DemandNoId == x.DemandNoId).Sum(x => x.TotalAmount)
                            let cuc_sumd = ctx.TblDemand.Where(y => y.DemandNoId == x.DemandNoId).Sum(x => x.DemandAmount)
                            let cuc_sume = ctx.TblDemand.Where(y => y.DemandNoId == x.DemandNoId).Sum(x => x.ExemptionAmount).GetValueOrDefault()

                            select new LedgerDemandVM
                            {
                                TotalAmount = cuc_sum,
                                //TransactionId = x.TransactionId,
                                DemandNoId = x.DemandNoId,
                                //TaxId = x.TaxId,
                                //FinancialYearId = x.FinancialYearId,
                                //CalendarYearId = x.CalendarYearId,
                                DemandAmount = cuc_sumd,
                                //TotalAmount = x.TotalAmount,
                                ExemptionAmount = cuc_sume,
                                ExemptionLetter = x.ExemptionLetter,
                                //CreatedBy = x.CreatedBy,
                                //CreatedOn = x.CreatedOn,
                                //ModifiedBy = x.ModifiedBy,
                                //ModifiedOn = x.ModifiedOn,
                                DemandNo = y.DemandNo,
                                //TaxName = z.TaxName
                            }).Distinct();

                return (IList<LedgerDemandVM>)data.ToList();
            }
        }

        public IList<LedgerDemandVM> GetpDemandWithSearch(string DemandNo, string Ttin)
        {
            var tid = "20";
           
            if (DemandNo != "" && DemandNo != null)
            {
                var Demand = (
                from x in ctx.TblDemandNo.Where(x => x.DemandNo == DemandNo)
                join y in ctx.TblDemand on x.DemandNoId equals y.DemandNoId
                join t in ctx.TblTransactionDetail on y.TransactionId equals t.TransactionId
                where tid.Contains(t.TransactionTypeId.ToString())
                select y.TransactionId).ToList();

                var data = (from x in ctx.TblDemand.Where(x => Demand.Contains(x.TransactionId))
                            //.Where(x => x.DemandNoId == 18)
                            .OrderBy(xx => xx.TransactionId)
                            .OrderBy(xx => xx.TaxPayerId)
                            join y in ctx.TblDemandNo on x.DemandNoId equals y.DemandNoId //where y.DemandNo== DemandNo
                            where x.IsPaymentMade == false && x.IsCancelled == false
                            let cuc_sum = ctx.TblDemand.Where(y => y.DemandNoId == x.DemandNoId).Sum(x => x.TotalAmount)
                            let cuc_sumd = ctx.TblDemand.Where(y => y.DemandNoId == x.DemandNoId).Sum(x => x.DemandAmount)
                            let cuc_sume = ctx.TblDemand.Where(y => y.DemandNoId == x.DemandNoId).Sum(x => x.ExemptionAmount).GetValueOrDefault()

                            select new LedgerDemandVM
                            {
                                TotalAmount = cuc_sum,
                                //TransactionId = x.TransactionId,
                                DemandNoId = x.DemandNoId,
                                //TaxId = x.TaxId,
                                //FinancialYearId = x.FinancialYearId,
                                //CalendarYearId = x.CalendarYearId,
                                DemandAmount = cuc_sumd,
                                //TotalAmount = x.TotalAmount,
                                ExemptionAmount = cuc_sume,
                                ExemptionLetter = x.ExemptionLetter,
                                //CreatedBy = x.CreatedBy,
                                //CreatedOn = x.CreatedOn,
                                //ModifiedBy = x.ModifiedBy,
                                //ModifiedOn = x.ModifiedOn,
                                DemandNo = y.DemandNo,
                                //TaxName = z.TaxName
                            }).Distinct();

                return (IList<LedgerDemandVM>)data.ToList();
            }
            else
            {
                var Vendor = (
                  from x in ctx.MstTaxPayerProfile.Where(x => x.Ttin == Ttin)
                  join y in ctx.TblDemand on x.TaxPayerId equals y.TaxPayerId
                  join t in ctx.TblTransactionDetail on y.TransactionId equals t.TransactionId
                  where tid.Contains(t.TransactionTypeId.ToString())
                  select y.TransactionId).ToList();

                var data = (from x in ctx.TblDemand.Where(x => Vendor.Contains(x.TransactionId))
                            //.Where(x => x.DemandNoId == 18)
                            .OrderBy(xx => xx.TransactionId)
                            .OrderBy(xx => xx.TaxPayerId)
                            join y in ctx.TblDemandNo on x.DemandNoId equals y.DemandNoId //where y.DemandNo== DemandNo
                            where x.IsPaymentMade == false && x.IsCancelled == false
                            let cuc_sum = ctx.TblDemand.Where(y => y.DemandNoId == x.DemandNoId).Sum(x => x.TotalAmount)
                            let cuc_sumd = ctx.TblDemand.Where(y => y.DemandNoId == x.DemandNoId).Sum(x => x.DemandAmount)
                            let cuc_sume = ctx.TblDemand.Where(y => y.DemandNoId == x.DemandNoId).Sum(x => x.ExemptionAmount).GetValueOrDefault()

                            select new LedgerDemandVM
                            {
                                TotalAmount = cuc_sum,
                                //TransactionId = x.TransactionId,
                                DemandNoId = x.DemandNoId,
                                //TaxId = x.TaxId,
                                //FinancialYearId = x.FinancialYearId,
                                //CalendarYearId = x.CalendarYearId,
                                DemandAmount = cuc_sumd,
                                //TotalAmount = x.TotalAmount,
                                ExemptionAmount = cuc_sume,
                                ExemptionLetter = x.ExemptionLetter,
                                //CreatedBy = x.CreatedBy,
                                //CreatedOn = x.CreatedOn,
                                //ModifiedBy = x.ModifiedBy,
                                //ModifiedOn = x.ModifiedOn,
                                DemandNo = y.DemandNo,
                                //TaxName = z.TaxName
                            }).Distinct();

                return (IList<LedgerDemandVM>)data.ToList();
            }
        }
        public static int GetMonthDifference(DateTime startDate, DateTime endDate)
        {
            int monthsApart = 12 * (startDate.Year - endDate.Year) + startDate.Month - endDate.Month;
            return Math.Abs(monthsApart);
        }
        public static int GetYearDifference(DateTime startDate, DateTime endDate)
        {
            int monthsApart = (  endDate.Year- startDate.Year);
            return Math.Abs(monthsApart);
        }


        public IList<LedgerDemandVM> CheckDuplicatePayment(string id)
        {
            ////Split the string to an array
           
            string[] ids = id.Split(',');

            var data = (from x in ctx.TblLedger.Where(x => ids.Contains(x.DemandId.ToString()))

                            //join y in ctx.TblDemandNo on x.DemandNoId equals y.DemandNoId
                            //join z in ctx.MstTaxMaster on x.TaxId equals z.TaxId

                            // orderby x.TransactionId ascending, x.TaxPayerId ascending, x.DemandNoId ascending

                        select new LedgerDemandVM
                        {
                            DemandId = x.DemandId,
                            //TransactionId = x.TransactionId,
                            //DemandNoId = x.DemandNoId,
                            //TaxId = x.TaxId,
                            //FinancialYearId = x.FinancialYearId,
                            //CalendarYearId = x.CalendarYearId,
                            //DemandAmount = x.DemandAmount,
                            //TotalAmount = x.TotalAmount,
                            //ExemptionAmount = x.ExemptionAmount,
                            //ExemptionLetter = x.ExemptionLetter,
                            //CreatedBy = x.CreatedBy,
                            //CreatedOn = x.CreatedOn,
                            //DemandNo = y.DemandNo,
                            //TaxName = z.TaxName
                        });

            return (IList<LedgerDemandVM>)data.ToList();
        }
        public IList<LedgerDemandVM> GetDemandDetail(string id)
        {
            //var dt = DateTime.Today.Day;
            //string idChecked = "1,2,3,4,5";
            ////Split the string to an array
            string[] ids = id.Split(',');
            //var blog = context.Blogs.Where(x => ids.Contains(x.Id.ToString()));
            // var trntypeIds = "15,16,17,18,19,20";
            int[] trntypeIds = { 15, 16, 17, 18, 19, 20};

            var data = (from x in ctx.TblDemand.Where(x =>x.IsCancelled==false && ids.Contains(x.DemandNoId.ToString()))
                            //.OrderBy(xx => xx.TransactionId)
                            //.OrderBy(xx => xx.TaxPayerId)

                        join y in ctx.TblDemandNo on x.DemandNoId equals y.DemandNoId
                        join z in ctx.MstTaxMaster on x.TaxId equals z.TaxId
                        join t in ctx.TblTransactionDetail on x.TransactionId equals t.TransactionId
                        join c in ctx.MstCalendarYear on x.CalendarYearId equals c.CalendarYearId
                         into c_temp
                        from c_value in c_temp.DefaultIfEmpty()
                        join p in ctx.MstTaxPeriod on new { t.TransactionTypeId, x.CalendarYearId } equals new {p.TransactionTypeId, p.CalendarYearId}
                        into p_temp
                        from p_value in p_temp.DefaultIfEmpty()
                        where trntypeIds.Contains(t.TransactionTypeId) ? x.CalendarYearId == p_value.CalendarYearId : 0 == 0 //     where x.MiscellaneousRecordId == null ?  x.CalendarYearId == p_value.CalendarYearId : 0 == 0

                        //join h in ctx.TblHouseRentDemandDetail on x.HouseRentDemandDetailId equals h.HouseRentDemandDetailId
                        // into h_temp
                        //from h_value in h_temp.DefaultIfEmpty()
                        //join hp in  ctx.TblHouseRentPeriod on h_value.HouseAllocationId equals hp.HouseAllocationId
                        //into hp_temp
                        //from hp_value in hp_temp.DefaultIfEmpty()

                        let TotalAmt = ctx.TblDemand.Where(x =>x.IsCancelled==false && ids.Contains(x.DemandNoId.ToString())).Sum(x => x.TotalAmount)
                        //let pdays = t.TransactionTypeId == 19 ? (DateTime.Today - x.BillingDate).Days :
                        //            t.TransactionTypeId == 20 ? (DateTime.Today - c_value.EndDate).Days
                        //            : ((DateTime.Today - x.BillingDate).Days)

                        //let pam = t.TransactionTypeId == 19 ? ((p_value.PenaltyOrRate * TotalAmt) * ((DateTime.Today.Month - x.BillingDate.Month)) / (100)) :
                        //             t.TransactionTypeId == 20 ? ((p_value.PenaltyOrRate * TotalAmt) * ((DateTime.Today - c_value.EndDate).Days) / (365 * 100)) :
                        //            t.TransactionTypeId == 21 ? ((p_value.PenaltyOrRate * TotalAmt) * ((DateTime.Today - x.BillingDate.AddMonths(1)).Days) / (365 * 100)) : 0

                        orderby x.TransactionId ascending, x.TaxPayerId ascending, x.DemandNoId ascending

                        select new LedgerDemandVM
                        {
                            MiscellaneousRecordId = x.MiscellaneousRecordId,
                            DemandId = x.DemandId,
                            TransactionId = x.TransactionId,
                            DemandNoId = x.DemandNoId,
                            TaxId = x.TaxId,
                            FinancialYearId = x.FinancialYearId,
                            CalendarYearId = x.CalendarYearId,
                            DemandAmount = x.DemandAmount,
                            TotalAmount = x.TotalAmount,
                            ExemptionAmount = x.ExemptionAmount,
                            ExemptionLetter = x.ExemptionLetter,
                            CreatedBy = x.CreatedBy,
                            CreatedOn = x.CreatedOn,
                            DemandNo = y.DemandNo,
                            TaxName = z.TaxName,
                            GrandTotalAmount = TotalAmt,
                            LandLeaseDemandDetailId = x.LandLeaseDemandDetailId,
                            TransactionTypeId = (ctx.TblTransactionDetail.Where(t => t.TransactionId == x.TransactionId).Max(m => m.TransactionTypeId)),
                           
                            tdays = (DateTime.Today - ctx.TblStallDetailDemand.Single(h => h.StallDemandDetailId == x.StallDemandDetailId).InstallmentDate).Days,
                            instmentdate = c_value.EndDate,//(ctx.TblStallDetailDemand.Single(h => h.StallDemandDetailId == x.StallDemandDetailId).InstallmentDate),
                           // md = GetMonthDifference(ctx.TblStallDetailDemand.Single(h => h.StallDemandDetailId == x.StallDemandDetailId).InstallmentDate, DateTime.Today),
                           md = ((DateTime.Today - c_value.EndDate).Days),//(c_value.EndDate - c_value.StartDate).Days,//(double)(((DateTime.Today - (ctx.TblLandLeaseDemandDetail.Single(l => l.LandLeaseDemandDetailId == x.LandLeaseDemandDetailId).InstallmentDate)).Days) * (p_value.PenaltyOrRate / 100) * x.TotalAmount),


                            Rate = p_value.PenaltyOrRate,
                            PenaltyDays = t.TransactionTypeId == 19 ? GetMonthDifference(x.BillingDate, DateTime.Today) :
                                         t.TransactionTypeId == 20 ? ((DateTime.Today - c_value.EndDate).Days) :

                                          //t.TransactionTypeId == 15 ? (DateTime.Today < ctx.TblHouseRentDemandDetail.Single(h => h.HouseRentDemandDetailId == x.HouseRentDemandDetailId).InstallmentDate) ? 0 :
                                          //(GetMonthDifference(ctx.TblHouseRentDemandDetail.Single(h => h.HouseRentDemandDetailId == x.HouseRentDemandDetailId).InstallmentDate, DateTime.Today) > 1) ? 
                                          //GetMonthDifference(ctx.TblHouseRentDemandDetail.Single(h => h.HouseRentDemandDetailId == x.HouseRentDemandDetailId).InstallmentDate, DateTime.Today) :
                                          //(GetMonthDifference(ctx.TblHouseRentDemandDetail.Single(h => h.HouseRentDemandDetailId == x.HouseRentDemandDetailId).InstallmentDate, DateTime.Today) < 1) ? 0 :
                                          //(DateTime.Today.Day > 10 && (GetMonthDifference(ctx.TblHouseRentDemandDetail.Single(h => h.HouseRentDemandDetailId == x.HouseRentDemandDetailId).InstallmentDate, DateTime.Today) == 1)) ?
                                          //GetMonthDifference(ctx.TblHouseRentDemandDetail.Single(h => h.HouseRentDemandDetailId == x.HouseRentDemandDetailId).InstallmentDate, DateTime.Today) : 0 :
                                       
                                         t.TransactionTypeId == 15 ? (DateTime.Today < ctx.TblHouseRentDemandDetail.Single(h => h.HouseRentDemandDetailId == x.HouseRentDemandDetailId).InstallmentDate) ? 0 :
                                        (GetMonthDifference(ctx.TblHouseRentDemandDetail.Single(h => h.HouseRentDemandDetailId == x.HouseRentDemandDetailId).InstallmentDate, DateTime.Today) > 1 && DateTime.Today.Day <= 10) ? (GetMonthDifference(ctx.TblHouseRentDemandDetail.Single(h => h.HouseRentDemandDetailId == x.HouseRentDemandDetailId).InstallmentDate, DateTime.Today) - 1) :
                                        (GetMonthDifference(ctx.TblHouseRentDemandDetail.Single(h => h.HouseRentDemandDetailId == x.HouseRentDemandDetailId).InstallmentDate, DateTime.Today) > 1 && DateTime.Today.Day > 10) ? GetMonthDifference(ctx.TblHouseRentDemandDetail.Single(h => h.HouseRentDemandDetailId == x.HouseRentDemandDetailId).InstallmentDate, DateTime.Today) :
                                        (GetMonthDifference(ctx.TblHouseRentDemandDetail.Single(h => h.HouseRentDemandDetailId == x.HouseRentDemandDetailId).InstallmentDate, DateTime.Today) < 1) ? 0 :
                                        (DateTime.Today.Day > 10 && (GetMonthDifference(ctx.TblHouseRentDemandDetail.Single(h => h.HouseRentDemandDetailId == x.HouseRentDemandDetailId).InstallmentDate, DateTime.Today) == 1)) ?
                                        GetMonthDifference(ctx.TblHouseRentDemandDetail.Single(h => h.HouseRentDemandDetailId == x.HouseRentDemandDetailId).InstallmentDate, DateTime.Today) : 0 :


                                        t.TransactionTypeId == 17 ? (DateTime.Today < ctx.TblStallDetailDemand.Single(h => h.StallDemandDetailId == x.StallDemandDetailId).InstallmentDate)  ? 0 :
                                        (GetMonthDifference(ctx.TblStallDetailDemand.Single(h => h.StallDemandDetailId == x.StallDemandDetailId).InstallmentDate, DateTime.Today) > 1 && DateTime.Today.Day <= 10) ? (GetMonthDifference(ctx.TblStallDetailDemand.Single(h => h.StallDemandDetailId == x.StallDemandDetailId).InstallmentDate, DateTime.Today) - 1) :
                                        (GetMonthDifference(ctx.TblStallDetailDemand.Single(h => h.StallDemandDetailId == x.StallDemandDetailId).InstallmentDate, DateTime.Today) > 1 && DateTime.Today.Day > 10) ? GetMonthDifference(ctx.TblStallDetailDemand.Single(h => h.StallDemandDetailId == x.StallDemandDetailId).InstallmentDate, DateTime.Today) :
                                        (GetMonthDifference(ctx.TblStallDetailDemand.Single(h => h.StallDemandDetailId == x.StallDemandDetailId).InstallmentDate, DateTime.Today) < 1) ? 0 :
                                        (DateTime.Today.Day > 10 && (GetMonthDifference(ctx.TblStallDetailDemand.Single(h => h.StallDemandDetailId == x.StallDemandDetailId).InstallmentDate, DateTime.Today)==1)) ? 
                                        GetMonthDifference(ctx.TblStallDetailDemand.Single(h => h.StallDemandDetailId == x.StallDemandDetailId).InstallmentDate, DateTime.Today) : 0 :
                                        
                                        
                                         t.TransactionTypeId == 18 ? ((DateTime.Today.AddMonths(-1) - (ctx.TblParkingFeeDemandDetail.Single(h => h.ParkingDemandDetailId == x.ParkingDemandDetailId).InstallmentDate)).Days) ://daily 24%

                                          //x.TaxId == 20 ? ((DateTime.Today.AddMonths(-1) - (ctx.TblLandLeaseDemandDetail.Single(h => h.LandLeaseDemandDetailId == x.LandLeaseDemandDetailId).InstallmentDate)).Days)  :
                                          // x.TaxId == 21 ? 0 :
                                             
                                         
                                         t.TransactionTypeId == 16 ? (Convert.ToDecimal((ctx.TblLandLease.Where(ll => ll.LandLeaseId == (ctx.TblLandLeaseDemandDetail.Single(l => l.LandLeaseDemandDetailId == x.LandLeaseDemandDetailId).LandLeaseId)).FirstOrDefault().BillingScheduleId))) == 3 ? ((DateTime.Today - (ctx.TblLandLeaseDemandDetail.Single(l => l.LandLeaseDemandDetailId == x.LandLeaseDemandDetailId).InstallmentDate)).Days) :
                                        //monthly
                                        (DateTime.Today < ctx.TblLandLeaseDemandDetail.Single(h => h.LandLeaseDemandDetailId == x.LandLeaseDemandDetailId).InstallmentDate) ? 0 :
                                        (GetMonthDifference(ctx.TblLandLeaseDemandDetail.Single(h => h.LandLeaseDemandDetailId == x.LandLeaseDemandDetailId).InstallmentDate, DateTime.Today) > 1 && DateTime.Today.Day <= 10) ? (GetMonthDifference(ctx.TblLandLeaseDemandDetail.Single(h => h.LandLeaseDemandDetailId == x.LandLeaseDemandDetailId).InstallmentDate, DateTime.Today) - 1) :
                                        (GetMonthDifference(ctx.TblLandLeaseDemandDetail.Single(h => h.LandLeaseDemandDetailId == x.LandLeaseDemandDetailId).InstallmentDate, DateTime.Today) > 1 && DateTime.Today.Day > 10) ? GetMonthDifference(ctx.TblLandLeaseDemandDetail.Single(h => h.LandLeaseDemandDetailId == x.LandLeaseDemandDetailId).InstallmentDate, DateTime.Today) :
                                        (GetMonthDifference(ctx.TblLandLeaseDemandDetail.Single(h => h.LandLeaseDemandDetailId == x.LandLeaseDemandDetailId).InstallmentDate, DateTime.Today) < 1) ? 0 :
                                        (DateTime.Today.Day > 10 && (GetMonthDifference(ctx.TblLandLeaseDemandDetail.Single(h => h.LandLeaseDemandDetailId == x.LandLeaseDemandDetailId).InstallmentDate, DateTime.Today) == 1)) ?
                                        GetMonthDifference(ctx.TblLandLeaseDemandDetail.Single(h => h.LandLeaseDemandDetailId == x.LandLeaseDemandDetailId).InstallmentDate, DateTime.Today) : 0 :
                                        0,
                             

                           TotalPenaltyAmount =
                                t.TransactionTypeId == 19 ? ((p_value.PenaltyOrRate * x.TotalAmount) * GetMonthDifference(x.BillingDate, DateTime.Today) / (12 * 100)) :
                                t.TransactionTypeId == 20 ? ((p_value.PenaltyOrRate /(100* (((c_value.EndDate - c_value.StartDate).Days) + 1)))*x.TotalAmount * (((DateTime.Today - c_value.EndDate).Days) < 0 ? 0 : ((DateTime.Today - c_value.EndDate).Days))) :

                                 // t.TransactionTypeId == 15 ? (((p_value.PenaltyOrRate * x.TotalAmount) / 100) *( (DateTime.Today< ctx.TblHouseRentDemandDetail.Single(h => h.HouseRentDemandDetailId == x.HouseRentDemandDetailId).InstallmentDate)? 0 : (DateTime.Today.Day > 10) ? GetMonthDifference(ctx.TblHouseRentDemandDetail.Single(h => h.HouseRentDemandDetailId == x.HouseRentDemandDetailId).InstallmentDate, DateTime.Today):0)) :
                                 //t.TransactionTypeId == 15 ? (((p_value.PenaltyOrRate * x.TotalAmount) / 100) *((DateTime.Today < ctx.TblHouseRentDemandDetail.Single(h => h.HouseRentDemandDetailId == x.HouseRentDemandDetailId).InstallmentDate) ? 0 :
                                 //          (GetMonthDifference(ctx.TblHouseRentDemandDetail.Single(h => h.HouseRentDemandDetailId == x.HouseRentDemandDetailId).InstallmentDate, DateTime.Today) > 1) ?
                                 //          GetMonthDifference(ctx.TblHouseRentDemandDetail.Single(h => h.HouseRentDemandDetailId == x.HouseRentDemandDetailId).InstallmentDate, DateTime.Today) :
                                 //          (GetMonthDifference(ctx.TblHouseRentDemandDetail.Single(h => h.HouseRentDemandDetailId == x.HouseRentDemandDetailId).InstallmentDate, DateTime.Today) < 1) ? 0 :
                                 //          (DateTime.Today.Day > 10 && (GetMonthDifference(ctx.TblHouseRentDemandDetail.Single(h => h.HouseRentDemandDetailId == x.HouseRentDemandDetailId).InstallmentDate, DateTime.Today) == 1)) ?
                                 //          GetMonthDifference(ctx.TblHouseRentDemandDetail.Single(h => h.HouseRentDemandDetailId == x.HouseRentDemandDetailId).InstallmentDate, DateTime.Today) : 0)) :

                                 t.TransactionTypeId == 15 ? (((p_value.PenaltyOrRate * x.TotalAmount) / 100) * ((DateTime.Today < ctx.TblHouseRentDemandDetail.Single(h => h.HouseRentDemandDetailId == x.HouseRentDemandDetailId).InstallmentDate) ? 0 :
                                        (GetMonthDifference(ctx.TblHouseRentDemandDetail.Single(h => h.HouseRentDemandDetailId == x.HouseRentDemandDetailId).InstallmentDate, DateTime.Today) > 1 && DateTime.Today.Day <= 10) ? (GetMonthDifference(ctx.TblHouseRentDemandDetail.Single(h => h.HouseRentDemandDetailId == x.HouseRentDemandDetailId).InstallmentDate, DateTime.Today) - 1) :
                                        (GetMonthDifference(ctx.TblHouseRentDemandDetail.Single(h => h.HouseRentDemandDetailId == x.HouseRentDemandDetailId).InstallmentDate, DateTime.Today) > 1 && DateTime.Today.Day > 10) ? GetMonthDifference(ctx.TblHouseRentDemandDetail.Single(h => h.HouseRentDemandDetailId == x.HouseRentDemandDetailId).InstallmentDate, DateTime.Today) :
                                        (GetMonthDifference(ctx.TblHouseRentDemandDetail.Single(h => h.HouseRentDemandDetailId == x.HouseRentDemandDetailId).InstallmentDate, DateTime.Today) < 1) ? 0 :
                                        (DateTime.Today.Day > 10 && (GetMonthDifference(ctx.TblHouseRentDemandDetail.Single(h => h.HouseRentDemandDetailId == x.HouseRentDemandDetailId).InstallmentDate, DateTime.Today) == 1)) ?
                                        GetMonthDifference(ctx.TblHouseRentDemandDetail.Single(h => h.HouseRentDemandDetailId == x.HouseRentDemandDetailId).InstallmentDate, DateTime.Today) : 0)) :


                                //  t.TransactionTypeId == 17 ? (((p_value.PenaltyOrRate * x.TotalAmount) / 100) *( (DateTime.Today< ctx.TblStallDetailDemand.Single(h => h.StallDemandDetailId == x.StallDemandDetailId).InstallmentDate)? 0 :DateTime.Today.Day>10?  GetMonthDifference(ctx.TblStallDetailDemand.Single(h => h.StallDemandDetailId == x.StallDemandDetailId).InstallmentDate, DateTime.Today):0)) :
                                t.TransactionTypeId == 17 ? (((p_value.PenaltyOrRate * x.TotalAmount) / 100) *((DateTime.Today < ctx.TblStallDetailDemand.Single(h => h.StallDemandDetailId == x.StallDemandDetailId).InstallmentDate) ? 0 :
                                        (GetMonthDifference(ctx.TblStallDetailDemand.Single(h => h.StallDemandDetailId == x.StallDemandDetailId).InstallmentDate, DateTime.Today) > 1 && DateTime.Today.Day <= 10) ? (GetMonthDifference(ctx.TblStallDetailDemand.Single(h => h.StallDemandDetailId == x.StallDemandDetailId).InstallmentDate, DateTime.Today) - 1) : 
                                        (GetMonthDifference(ctx.TblStallDetailDemand.Single(h => h.StallDemandDetailId == x.StallDemandDetailId).InstallmentDate, DateTime.Today) > 1 && DateTime.Today.Day > 10) ? GetMonthDifference(ctx.TblStallDetailDemand.Single(h => h.StallDemandDetailId == x.StallDemandDetailId).InstallmentDate, DateTime.Today) :
                                        (GetMonthDifference(ctx.TblStallDetailDemand.Single(h => h.StallDemandDetailId == x.StallDemandDetailId).InstallmentDate, DateTime.Today) < 1) ? 0 :
                                        (DateTime.Today.Day > 10 && (GetMonthDifference(ctx.TblStallDetailDemand.Single(h => h.StallDemandDetailId == x.StallDemandDetailId).InstallmentDate, DateTime.Today) == 1)) ?
                                        GetMonthDifference(ctx.TblStallDetailDemand.Single(h => h.StallDemandDetailId == x.StallDemandDetailId).InstallmentDate, DateTime.Today) : 0)) :
                             
                               
                                t.TransactionTypeId == 18 ? (((p_value.PenaltyOrRate * x.TotalAmount)/(100*365)) * ((DateTime.Today.AddMonths(-1)-(ctx.TblParkingFeeDemandDetail.Single(h => h.ParkingDemandDetailId == x.ParkingDemandDetailId).InstallmentDate) ).Days)) :
                            //x.TaxId == 20 ? (((p_value.PenaltyOrRate * x.TotalAmount) / (100 * 365)) * ((DateTime.Today.AddMonths(-1) - (ctx.TblLandLeaseDemandDetail.Single(h => h.LandLeaseDemandDetailId == x.LandLeaseDemandDetailId).InstallmentDate)).Days)) :
                            //x.TaxId == 21 ? Convert.ToDecimal((ctx.TblLandLease.Where(ll => ll.LandLeaseId == (ctx.TblLandLeaseDemandDetail.Single(l => l.LandLeaseDemandDetailId == x.LandLeaseDemandDetailId).LandLeaseId)).FirstOrDefault().Remarks)) :
                            //0
                            //yrly
                              t.TransactionTypeId == 16 ?
                            //yearly
                            (Convert.ToDecimal((ctx.TblLandLease.Where(ll => ll.LandLeaseId == (ctx.TblLandLeaseDemandDetail.Single(l => l.LandLeaseDemandDetailId == x.LandLeaseDemandDetailId).LandLeaseId)).FirstOrDefault().BillingScheduleId))) == 3 ? ((((DateTime.Today - (ctx.TblLandLeaseDemandDetail.Single(l => l.LandLeaseDemandDetailId == x.LandLeaseDemandDetailId).InstallmentDate)).Days) > 0 ? ((DateTime.Today - (ctx.TblLandLeaseDemandDetail.Single(l => l.LandLeaseDemandDetailId == x.LandLeaseDemandDetailId).InstallmentDate)).Days) : 0) * (p_value.PenaltyOrRate) * x.TotalAmount / (365 * 100)) :
                            //monthly
                            (((p_value.PenaltyOrRate * x.TotalAmount) / 100) * ((DateTime.Today < ctx.TblLandLeaseDemandDetail.Single(h => h.LandLeaseDemandDetailId == x.LandLeaseDemandDetailId).InstallmentDate) ? 0 :
                                        (GetMonthDifference(ctx.TblLandLeaseDemandDetail.Single(h => h.LandLeaseDemandDetailId == x.LandLeaseDemandDetailId).InstallmentDate, DateTime.Today) > 1 && DateTime.Today.Day <= 10) ? (GetMonthDifference(ctx.TblLandLeaseDemandDetail.Single(h => h.LandLeaseDemandDetailId == x.LandLeaseDemandDetailId).InstallmentDate, DateTime.Today) - 1) :
                                        (GetMonthDifference(ctx.TblLandLeaseDemandDetail.Single(h => h.LandLeaseDemandDetailId == x.LandLeaseDemandDetailId).InstallmentDate, DateTime.Today) > 1 && DateTime.Today.Day > 10) ? GetMonthDifference(ctx.TblLandLeaseDemandDetail.Single(h => h.LandLeaseDemandDetailId == x.LandLeaseDemandDetailId).InstallmentDate, DateTime.Today) :
                                        (GetMonthDifference(ctx.TblLandLeaseDemandDetail.Single(h => h.LandLeaseDemandDetailId == x.LandLeaseDemandDetailId).InstallmentDate, DateTime.Today) < 1) ? 0 :
                                        (DateTime.Today.Day > 10 && (GetMonthDifference(ctx.TblLandLeaseDemandDetail.Single(h => h.LandLeaseDemandDetailId == x.LandLeaseDemandDetailId).InstallmentDate, DateTime.Today) == 1)) ?
                                        GetMonthDifference(ctx.TblLandLeaseDemandDetail.Single(h => h.LandLeaseDemandDetailId == x.LandLeaseDemandDetailId).InstallmentDate, DateTime.Today) : 0)) :

                             //************************************** ENVIRONMENT CLERANCE ****************************************************************


                             t.TransactionTypeId == 9 ? ((DateTime.Today < ctx.TblEcrenewalDetail.Single(h => h.EcRenewalId == x.EcRenewalId).ValidUpTo) ? 0
                                           : GetMonthDifference(ctx.TblEcrenewalDetail.Single(h => h.EcRenewalId == x.EcRenewalId).ValidUpTo, DateTime.Today) > 1 && GetMonthDifference(ctx.TblEcrenewalDetail.Single(h => h.EcRenewalId == x.EcRenewalId).ValidUpTo, DateTime.Today) <= 6
                                           ? (5000 + TotalAmt + 5000)
                                           :
                                           GetMonthDifference(ctx.TblEcrenewalDetail.Single(h => h.EcRenewalId == x.EcRenewalId).ValidUpTo, DateTime.Today) > 6 && GetMonthDifference(ctx.TblEcrenewalDetail.Single(h => h.EcRenewalId == x.EcRenewalId).ValidUpTo, DateTime.Today) <= 12
                                           ? (5000 + TotalAmt + 10000)
                                           :
                                           GetMonthDifference(ctx.TblEcrenewalDetail.Single(h => h.EcRenewalId == x.EcRenewalId).ValidUpTo, DateTime.Today) > 12  
                                           ? (5000 + TotalAmt + 20000)
                                        : 0
                                        ) :



                            //t.TransactionTypeId == 16 ? (Convert.ToDecimal((ctx.TblLandLease.Where(ll => ll.LandLeaseId == (ctx.TblLandLeaseDemandDetail.Single(l => l.LandLeaseDemandDetailId == 18).LandLeaseId)).FirstOrDefault().BillingScheduleId))) == 3 ? (((DateTime.Today - (ctx.TblLandLeaseDemandDetail.Single(l => l.LandLeaseDemandDetailId == x.LandLeaseDemandDetailId).InstallmentDate)).Days) * (p_value.PenaltyOrRate) * x.TotalAmount /(365 * 100)):
                            ////monthly
                            //(((p_value.PenaltyOrRate * x.TotalAmount) / 100) * ((DateTime.Today < ctx.TblLandLeaseDemandDetail.Single(h => h.LandLeaseDemandDetailId == x.LandLeaseDemandDetailId).InstallmentDate) ? 0 :
                            //            (GetMonthDifference(ctx.TblLandLeaseDemandDetail.Single(h => h.LandLeaseDemandDetailId == x.LandLeaseDemandDetailId).InstallmentDate, DateTime.Today) > 1 && DateTime.Today.Day <= 10) ? (GetMonthDifference(ctx.TblLandLeaseDemandDetail.Single(h => h.LandLeaseDemandDetailId == x.LandLeaseDemandDetailId).InstallmentDate, DateTime.Today) - 1) :
                            //            (GetMonthDifference(ctx.TblLandLeaseDemandDetail.Single(h => h.LandLeaseDemandDetailId == x.LandLeaseDemandDetailId).InstallmentDate, DateTime.Today) > 1 && DateTime.Today.Day > 10) ? GetMonthDifference(ctx.TblLandLeaseDemandDetail.Single(h => h.LandLeaseDemandDetailId == x.LandLeaseDemandDetailId).InstallmentDate, DateTime.Today) :
                            //            (GetMonthDifference(ctx.TblLandLeaseDemandDetail.Single(h => h.LandLeaseDemandDetailId == x.LandLeaseDemandDetailId).InstallmentDate, DateTime.Today) < 1) ? 0 :
                            //            (DateTime.Today.Day > 10 && (GetMonthDifference(ctx.TblLandLeaseDemandDetail.Single(h => h.LandLeaseDemandDetailId == x.LandLeaseDemandDetailId).InstallmentDate, DateTime.Today) == 1)) ?
                            //            GetMonthDifference(ctx.TblLandLeaseDemandDetail.Single(h => h.LandLeaseDemandDetailId == x.LandLeaseDemandDetailId).InstallmentDate, DateTime.Today) : 0)) : 
                            t.TransactionTypeId == 18 ? (((p_value.PenaltyOrRate * x.TotalAmount) / 100) * ((GetMonthDifference(ctx.TblParkingFeeDemandDetail.Single(h => h.ParkingDemandDetailId == x.ParkingDemandDetailId).InstallmentDate, DateTime.Today.AddMonths(-1))))) : 0


                        }).Distinct();

            return (IList<LedgerDemandVM>)data.ToList();
        }
        //public static int GetMonthDifferenceHouseVendor(long StallDemandDetailId)
        //{
        //    DateTime startDate; DateTime endDate;
           
        //    var hrd = (ctx.TblHouseRentDemandDetail.Single(x=>x.HouseRentDemandDetailId==StallDemandDetailId));
        //    startDate =DateTime.Today;
        //    endDate = hrd.InstallmentDate;
        //    int monthsApart = 12 * (startDate.Year - endDate.Year) + startDate.Month - endDate.Month;
        //    return Math.Abs(monthsApart);
        //}

        public long CreateLedger(LedgerDemandVM obj)
        {
            try
            {
                using TransactionScope s = new TransactionScope();
                string[] ids = obj.Ids.Split(',');
                var demand = (ctx.TblDemand.Where(x => ids.Contains(x.DemandId.ToString())));
                long pk, lpk;

                int sq = ctx.TblReceipt.Where(p => p.ReceiptYear == Convert.ToInt32(DateTime.Now.Year)).Select(p => p.Sl).Cast<int?>().Max() ?? 0;
                sq = sq + 1;
                var entityR = new TblReceipt
                {
                    ReceiptNo = ("TT/" + (DateTime.Now.Year) + "/" + sq),
                    Sl = sq,
                    ReceiptYear = DateTime.Now.Year,
                    CreatedBy = obj.CreatedBy,
                    CreatedOn = DateTime.Now,
                };
                ctx.TblReceipt.Add(entityR);
                ctx.SaveChanges();
                pk = entityR.ReceiptId;
                //
                //var fyr = ctx.MstFinancialYear.Where(x => x.StartDate <= DateTime.Today && x.EndDate >= DateTime.Today).Max(x => x.FinancialYearId);// make default check at startup
                //int cyr = ctx.MstCalendarYear.Where(x => x.StartDate <= DateTime.Today && x.EndDate >= DateTime.Today).Max(xx => xx.CalendarYearId);// make default check at startup

                foreach (var item in demand.ToList())
                {
                    var dmd = ctx.TblDemand.Single(d =>d.IsCancelled == false && d.DemandId == item.DemandId);
                    var trn = ctx.TblTransactionDetail.Single(t => t.TransactionId == item.TransactionId);
                   
                    var cy = ctx.MstCalendarYear.Single(t => t.CalendarYearId == item.CalendarYearId);

                    var tp = ctx.MstTaxPeriod.Where(t => t.TransactionTypeId == trn.TransactionTypeId && t.CalendarYearId==cy.CalendarYearId);
                    // var wmrid = ctx.TblDemand.Single(t => t.TransactionId == item.TransactionId).WaterMeterReadingId;
                    var entity = new TblLedger
                    {
                        DemandId = item.DemandId,
                        TransactionId = item.TransactionId,
                        TaxId = item.TaxId,
                        FinancialYearId = item.FinancialYearId,
                        CalendarYearId = item.CalendarYearId,
                        LandDetailId = item.LandDetailId,
                        LandOwnershipId = item.LandOwnershipId,
                        TaxPayerId = item.TaxPayerId,
                        TotalAmount = item.TotalAmount,
                        PaymentDate = DateTime.Now,
                        ReceiptId = pk,
                        CreatedBy = obj.CreatedBy,
                        CreatedOn = DateTime.Now,

                        PenaltyPeriod = trn.TransactionTypeId == 19 ? GetMonthDifference(dmd.BillingDate, DateTime.Today) :
                                        trn.TransactionTypeId == 20 ? (((DateTime.Today - cy.EndDate).Days) < 0 ? 0 : ((DateTime.Today - cy.EndDate).Days)) :


                                         //trn.TransactionTypeId == 15 ? (DateTime.Today < ctx.TblHouseRentDemandDetail.Single(h => h.HouseRentDemandDetailId == dmd.HouseRentDemandDetailId).InstallmentDate) ? 0 :
                                         //(GetMonthDifference(ctx.TblHouseRentDemandDetail.Single(h => h.HouseRentDemandDetailId == dmd.HouseRentDemandDetailId).InstallmentDate, DateTime.Today) > 1) ?
                                         //GetMonthDifference(ctx.TblHouseRentDemandDetail.Single(h => h.HouseRentDemandDetailId == dmd.HouseRentDemandDetailId).InstallmentDate, DateTime.Today) :
                                         //(GetMonthDifference(ctx.TblHouseRentDemandDetail.Single(h => h.HouseRentDemandDetailId == dmd.HouseRentDemandDetailId).InstallmentDate, DateTime.Today) < 1) ? 0 :
                                         //(DateTime.Today.Day > 10 && (GetMonthDifference(ctx.TblHouseRentDemandDetail.Single(h => h.HouseRentDemandDetailId == dmd.HouseRentDemandDetailId).InstallmentDate, DateTime.Today) == 1)) ?
                                         //GetMonthDifference(ctx.TblHouseRentDemandDetail.Single(h => h.HouseRentDemandDetailId == dmd.HouseRentDemandDetailId).InstallmentDate, DateTime.Today) : 0 :
                                         trn.TransactionTypeId == 15 ? (DateTime.Today < ctx.TblHouseRentDemandDetail.Single(h => h.HouseRentDemandDetailId == dmd.HouseRentDemandDetailId).InstallmentDate) ? 0 :
                                        (GetMonthDifference(ctx.TblHouseRentDemandDetail.Single(h => h.HouseRentDemandDetailId == dmd.HouseRentDemandDetailId).InstallmentDate, DateTime.Today) > 1 && DateTime.Today.Day <= 10) ? (GetMonthDifference(ctx.TblHouseRentDemandDetail.Single(h => h.HouseRentDemandDetailId == dmd.HouseRentDemandDetailId).InstallmentDate, DateTime.Today) - 1) :
                                        (GetMonthDifference(ctx.TblHouseRentDemandDetail.Single(h => h.HouseRentDemandDetailId == dmd.HouseRentDemandDetailId).InstallmentDate, DateTime.Today) > 1 && DateTime.Today.Day > 10) ? GetMonthDifference(ctx.TblHouseRentDemandDetail.Single(h => h.HouseRentDemandDetailId == dmd.HouseRentDemandDetailId).InstallmentDate, DateTime.Today) :
                                        (GetMonthDifference(ctx.TblHouseRentDemandDetail.Single(h => h.HouseRentDemandDetailId == dmd.HouseRentDemandDetailId).InstallmentDate, DateTime.Today) < 1) ? 0 :
                                        (DateTime.Today.Day > 10 && (GetMonthDifference(ctx.TblHouseRentDemandDetail.Single(h => h.HouseRentDemandDetailId == dmd.HouseRentDemandDetailId).InstallmentDate, DateTime.Today) == 1)) ?
                                        GetMonthDifference(ctx.TblHouseRentDemandDetail.Single(h => h.HouseRentDemandDetailId == dmd.HouseRentDemandDetailId).InstallmentDate, DateTime.Today) : 0 :


                                        // trn.TransactionTypeId == 17 ? (DateTime.Today < ctx.TblStallDetailDemand.Single(h => h.StallDemandDetailId == dmd.StallDemandDetailId).InstallmentDate) ? 0 :
                                        //(GetMonthDifference(ctx.TblStallDetailDemand.Single(h => h.StallDemandDetailId == dmd.StallDemandDetailId).InstallmentDate, DateTime.Today) > 1) ? GetMonthDifference(ctx.TblStallDetailDemand.Single(h => h.StallDemandDetailId == dmd.StallDemandDetailId).InstallmentDate, DateTime.Today) :
                                        //(GetMonthDifference(ctx.TblStallDetailDemand.Single(h => h.StallDemandDetailId == dmd.StallDemandDetailId).InstallmentDate, DateTime.Today) < 1) ? 0 :
                                        //(DateTime.Today.Day > 10 && (GetMonthDifference(ctx.TblStallDetailDemand.Single(h => h.StallDemandDetailId == dmd.StallDemandDetailId).InstallmentDate, DateTime.Today) == 1)) ?
                                        //GetMonthDifference(ctx.TblStallDetailDemand.Single(h => h.StallDemandDetailId == dmd.StallDemandDetailId).InstallmentDate, DateTime.Today) : 0 :

                                        trn.TransactionTypeId == 17 ? (DateTime.Today < ctx.TblStallDetailDemand.Single(h => h.StallDemandDetailId == dmd.StallDemandDetailId).InstallmentDate) ? 0 :
                                        (GetMonthDifference(ctx.TblStallDetailDemand.Single(h => h.StallDemandDetailId == dmd.StallDemandDetailId).InstallmentDate, DateTime.Today) > 1 && DateTime.Today.Day <= 10) ? (GetMonthDifference(ctx.TblStallDetailDemand.Single(h => h.StallDemandDetailId == dmd.StallDemandDetailId).InstallmentDate, DateTime.Today) - 1) :
                                        (GetMonthDifference(ctx.TblStallDetailDemand.Single(h => h.StallDemandDetailId == dmd.StallDemandDetailId).InstallmentDate, DateTime.Today) > 1 && DateTime.Today.Day > 10) ? GetMonthDifference(ctx.TblStallDetailDemand.Single(h => h.StallDemandDetailId == dmd.StallDemandDetailId).InstallmentDate, DateTime.Today) :
                                        (GetMonthDifference(ctx.TblStallDetailDemand.Single(h => h.StallDemandDetailId == dmd.StallDemandDetailId).InstallmentDate, DateTime.Today) < 1) ? 0 :
                                        (DateTime.Today.Day > 10 && (GetMonthDifference(ctx.TblStallDetailDemand.Single(h => h.StallDemandDetailId == dmd.StallDemandDetailId).InstallmentDate, DateTime.Today) == 1)) ?
                                        GetMonthDifference(ctx.TblStallDetailDemand.Single(h => h.StallDemandDetailId == dmd.StallDemandDetailId).InstallmentDate, DateTime.Today) : 0 :

                                        //EC
                                        trn.TransactionTypeId == 9 ? ((DateTime.Today < ctx.TblEcrenewalDetail.Single(h => h.EcRenewalId == dmd.EcRenewalId).ValidUpTo) ? 0
                                           : GetMonthDifference(ctx.TblEcrenewalDetail.Single(h => h.EcRenewalId == dmd.EcRenewalId).ValidUpTo, DateTime.Today) > 1 && GetMonthDifference(ctx.TblEcrenewalDetail.Single(h => h.EcRenewalId == dmd.EcRenewalId).ValidUpTo, DateTime.Today) <= 6
                                           ? (5000 + ((20 / 100) * 5000) + 5000)
                                           :
                                           GetMonthDifference(ctx.TblEcrenewalDetail.Single(h => h.EcRenewalId == dmd.EcRenewalId).ValidUpTo, DateTime.Today) > 6 && GetMonthDifference(ctx.TblEcrenewalDetail.Single(h => h.EcRenewalId == dmd.EcRenewalId).ValidUpTo, DateTime.Today) <= 12
                                           ? (5000 + ((20 / 100) * 5000) + 10000)
                                           :
                                           GetMonthDifference(ctx.TblEcrenewalDetail.Single(h => h.EcRenewalId == dmd.EcRenewalId).ValidUpTo, DateTime.Today) > 12 
                                           ? (5000 + ((20 / 100) * 5000) + 20000)
                                        : 0
                                        ) : 



                                        trn.TransactionTypeId == 18 ? ((DateTime.Today.AddMonths(-1) - (ctx.TblParkingFeeDemandDetail.Single(h => h.ParkingDemandDetailId == dmd.ParkingDemandDetailId).InstallmentDate)).Days) :

                                        //item.TaxId == 20 ? ((DateTime.Today.AddMonths(-1) - (ctx.TblLandLeaseDemandDetail.Single(h => h.LandLeaseDemandDetailId == dmd.LandLeaseDemandDetailId).InstallmentDate)).Days) :
                                        //  item.TaxId == 21 ? 0 :
                                        //yearly
                                        trn.TransactionTypeId == 16 ? (Convert.ToDecimal((ctx.TblLandLease.Where(ll => ll.LandLeaseId == (ctx.TblLandLeaseDemandDetail.Single(l => l.LandLeaseDemandDetailId == dmd.LandLeaseDemandDetailId).LandLeaseId)).FirstOrDefault().BillingScheduleId))) == 3 ? (((DateTime.Today - (ctx.TblLandLeaseDemandDetail.Single(l => l.LandLeaseDemandDetailId == dmd.LandLeaseDemandDetailId).InstallmentDate)).Days) > 0  ? ((DateTime.Today - (ctx.TblLandLeaseDemandDetail.Single(l => l.LandLeaseDemandDetailId == dmd.LandLeaseDemandDetailId).InstallmentDate)).Days) : 0) :
                                        //monthly
                                        (DateTime.Today < ctx.TblLandLeaseDemandDetail.Single(h => h.LandLeaseDemandDetailId == dmd.LandLeaseDemandDetailId).InstallmentDate) ? 0 :
                                        (GetMonthDifference(ctx.TblLandLeaseDemandDetail.Single(h => h.LandLeaseDemandDetailId == dmd.LandLeaseDemandDetailId).InstallmentDate, DateTime.Today) > 1 && DateTime.Today.Day <= 10) ? (GetMonthDifference(ctx.TblLandLeaseDemandDetail.Single(h => h.LandLeaseDemandDetailId == dmd.LandLeaseDemandDetailId).InstallmentDate, DateTime.Today) - 1) :
                                        (GetMonthDifference(ctx.TblLandLeaseDemandDetail.Single(h => h.LandLeaseDemandDetailId == dmd.LandLeaseDemandDetailId).InstallmentDate, DateTime.Today) > 1 && DateTime.Today.Day > 10) ? GetMonthDifference(ctx.TblLandLeaseDemandDetail.Single(h => h.LandLeaseDemandDetailId == dmd.LandLeaseDemandDetailId).InstallmentDate, DateTime.Today) :
                                        (GetMonthDifference(ctx.TblLandLeaseDemandDetail.Single(h => h.LandLeaseDemandDetailId == dmd.LandLeaseDemandDetailId).InstallmentDate, DateTime.Today) < 1) ? 0 :
                                        (DateTime.Today.Day > 10 && (GetMonthDifference(ctx.TblLandLeaseDemandDetail.Single(h => h.LandLeaseDemandDetailId == dmd.LandLeaseDemandDetailId).InstallmentDate, DateTime.Today) == 1)) ?
                                        GetMonthDifference(ctx.TblLandLeaseDemandDetail.Single(h => h.LandLeaseDemandDetailId == dmd.LandLeaseDemandDetailId).InstallmentDate, DateTime.Today) : 0 :



                                            0,
                     

                         
  
                        PenaltyAmount = 
                        trn.TransactionTypeId == 19 ? ((tp.FirstOrDefault().PenaltyOrRate * dmd.TotalAmount) * GetMonthDifference(dmd.BillingDate, DateTime.Today) / (12 * 100)) :
                        trn.TransactionTypeId == 20 ? ((tp.FirstOrDefault().PenaltyOrRate/(100* (((cy.EndDate - cy.StartDate).Days) + 1))) * dmd.TotalAmount * ((((DateTime.Today - cy.EndDate).Days)) < 0 ? 0 : ((DateTime.Today - cy.EndDate).Days)) ) :
                       
                        trn.TransactionTypeId == 15 ? (((tp.FirstOrDefault().PenaltyOrRate * dmd.TotalAmount)/100) * ((DateTime.Today < ctx.TblHouseRentDemandDetail.Single(h => h.HouseRentDemandDetailId == dmd.HouseRentDemandDetailId).InstallmentDate) ? 0 :
                                        (GetMonthDifference(ctx.TblHouseRentDemandDetail.Single(h => h.HouseRentDemandDetailId == dmd.HouseRentDemandDetailId).InstallmentDate, DateTime.Today) > 1 && DateTime.Today.Day <= 10) ? (GetMonthDifference(ctx.TblHouseRentDemandDetail.Single(h => h.HouseRentDemandDetailId == dmd.HouseRentDemandDetailId).InstallmentDate, DateTime.Today) - 1) :
                                        (GetMonthDifference(ctx.TblHouseRentDemandDetail.Single(h => h.HouseRentDemandDetailId == dmd.HouseRentDemandDetailId).InstallmentDate, DateTime.Today) > 1 && DateTime.Today.Day > 10) ? GetMonthDifference(ctx.TblHouseRentDemandDetail.Single(h => h.HouseRentDemandDetailId == dmd.HouseRentDemandDetailId).InstallmentDate, DateTime.Today) :
                                        (GetMonthDifference(ctx.TblHouseRentDemandDetail.Single(h => h.HouseRentDemandDetailId == dmd.HouseRentDemandDetailId).InstallmentDate, DateTime.Today) < 1) ? 0 :
                                        (DateTime.Today.Day > 10 && (GetMonthDifference(ctx.TblHouseRentDemandDetail.Single(h => h.HouseRentDemandDetailId == dmd.HouseRentDemandDetailId).InstallmentDate, DateTime.Today) == 1)) ?
                                        GetMonthDifference(ctx.TblHouseRentDemandDetail.Single(h => h.HouseRentDemandDetailId == dmd.HouseRentDemandDetailId).InstallmentDate, DateTime.Today) : 0)): 
                       
                                        // trn.TransactionTypeId == 17 ? (((tp.FirstOrDefault().PenaltyOrRate * dmd.TotalAmount)/100) * ((DateTime.Today < ctx.TblStallDetailDemand.Single(h => h.StallDemandDetailId == dmd.StallDemandDetailId).InstallmentDate) ? 0 :  GetMonthDifference(ctx.TblStallDetailDemand.Single(h => h.StallDemandDetailId == dmd.StallDemandDetailId).InstallmentDate, DateTime.Today))): 
                        trn.TransactionTypeId == 17 ? (((tp.FirstOrDefault().PenaltyOrRate * dmd.TotalAmount)/100) * ((DateTime.Today < ctx.TblStallDetailDemand.Single(h => h.StallDemandDetailId == dmd.StallDemandDetailId).InstallmentDate) ? 0 :
                                        (GetMonthDifference(ctx.TblStallDetailDemand.Single(h => h.StallDemandDetailId == dmd.StallDemandDetailId).InstallmentDate, DateTime.Today) > 1 && DateTime.Today.Day <= 10) ? (GetMonthDifference(ctx.TblStallDetailDemand.Single(h => h.StallDemandDetailId == dmd.StallDemandDetailId).InstallmentDate, DateTime.Today) - 1) :
                                        (GetMonthDifference(ctx.TblStallDetailDemand.Single(h => h.StallDemandDetailId == dmd.StallDemandDetailId).InstallmentDate, DateTime.Today) > 1 && DateTime.Today.Day > 10) ? GetMonthDifference(ctx.TblStallDetailDemand.Single(h => h.StallDemandDetailId == dmd.StallDemandDetailId).InstallmentDate, DateTime.Today) :
                                        (GetMonthDifference(ctx.TblStallDetailDemand.Single(h => h.StallDemandDetailId == dmd.StallDemandDetailId).InstallmentDate, DateTime.Today) < 1) ? 0 :
                                        (DateTime.Today.Day >10 && (GetMonthDifference(ctx.TblStallDetailDemand.Single(h => h.StallDemandDetailId == dmd.StallDemandDetailId).InstallmentDate, DateTime.Today) == 1)) ?
                                        GetMonthDifference(ctx.TblStallDetailDemand.Single(h => h.StallDemandDetailId == dmd.StallDemandDetailId).InstallmentDate, DateTime.Today) : 0)) : 
                      
                            trn.TransactionTypeId == 18 ? (((tp.FirstOrDefault().PenaltyOrRate * dmd.TotalAmount)/(100*365)) * ((DateTime.Today.AddMonths(-1) - (ctx.TblParkingFeeDemandDetail.Single(h => h.ParkingDemandDetailId == dmd.ParkingDemandDetailId).InstallmentDate)).Days)):

                        //item.TaxId == 20 ? (((tp.FirstOrDefault().PenaltyOrRate * dmd.TotalAmount) / (100 * 365)) * ((DateTime.Today.AddMonths(-1) - (ctx.TblLandLeaseDemandDetail.Single(h => h.LandLeaseDemandDetailId == dmd.LandLeaseDemandDetailId).InstallmentDate)).Days)) :

                        //item.TaxId == 21 ? Convert.ToDecimal(( ctx.TblLandLease.Where(ll=>ll.LandLeaseId==(ctx.TblLandLeaseDemandDetail.Single(l=>l.LandLeaseDemandDetailId==dmd.LandLeaseDemandDetailId).LandLeaseId)).FirstOrDefault().Remarks)) :
                        //yrly
                            trn.TransactionTypeId == 16 ?
                            //yearly
                            (Convert.ToDecimal((ctx.TblLandLease.Where(ll => ll.LandLeaseId == (ctx.TblLandLeaseDemandDetail.Single(l => l.LandLeaseDemandDetailId == dmd.LandLeaseDemandDetailId).LandLeaseId)).FirstOrDefault().BillingScheduleId))) == 3 ? ((((DateTime.Today - (ctx.TblLandLeaseDemandDetail.Single(l => l.LandLeaseDemandDetailId == dmd.LandLeaseDemandDetailId).InstallmentDate)).Days) > 0 ? ((DateTime.Today - (ctx.TblLandLeaseDemandDetail.Single(l => l.LandLeaseDemandDetailId == dmd.LandLeaseDemandDetailId).InstallmentDate)).Days) : 0) * (tp.FirstOrDefault().PenaltyOrRate) * dmd.TotalAmount / (365 * 100)) :
                            //monthly
                            (((tp.FirstOrDefault().PenaltyOrRate * dmd.TotalAmount) / 100) * ((DateTime.Today < ctx.TblLandLeaseDemandDetail.Single(h => h.LandLeaseDemandDetailId == dmd.LandLeaseDemandDetailId).InstallmentDate) ? 0 :
                                        (GetMonthDifference(ctx.TblLandLeaseDemandDetail.Single(h => h.LandLeaseDemandDetailId == dmd.LandLeaseDemandDetailId).InstallmentDate, DateTime.Today) > 1 && DateTime.Today.Day <= 10) ? (GetMonthDifference(ctx.TblLandLeaseDemandDetail.Single(h => h.LandLeaseDemandDetailId == dmd.LandLeaseDemandDetailId).InstallmentDate, DateTime.Today) - 1) :
                                        (GetMonthDifference(ctx.TblLandLeaseDemandDetail.Single(h => h.LandLeaseDemandDetailId == dmd.LandLeaseDemandDetailId).InstallmentDate, DateTime.Today) > 1 && DateTime.Today.Day > 10) ? GetMonthDifference(ctx.TblLandLeaseDemandDetail.Single(h => h.LandLeaseDemandDetailId == dmd.LandLeaseDemandDetailId).InstallmentDate, DateTime.Today) :
                                        (GetMonthDifference(ctx.TblLandLeaseDemandDetail.Single(h => h.LandLeaseDemandDetailId == dmd.LandLeaseDemandDetailId).InstallmentDate, DateTime.Today) < 1) ? 0 :
                                        (DateTime.Today.Day > 10 && (GetMonthDifference(ctx.TblLandLeaseDemandDetail.Single(h => h.LandLeaseDemandDetailId == dmd.LandLeaseDemandDetailId).InstallmentDate, DateTime.Today) == 1)) ?
                                        GetMonthDifference(ctx.TblLandLeaseDemandDetail.Single(h => h.LandLeaseDemandDetailId == dmd.LandLeaseDemandDetailId).InstallmentDate, DateTime.Today) : 0)) :

                            trn.TransactionTypeId == 18 ? (((tp.FirstOrDefault().PenaltyOrRate * dmd.TotalAmount) / 100) * ((GetMonthDifference(ctx.TblParkingFeeDemandDetail.Single(h => h.ParkingDemandDetailId == dmd.ParkingDemandDetailId).InstallmentDate, DateTime.Today.AddMonths(-1))))) : 


                       0,
                        ApplicantId = item.ApplicantId,
                        EcRenewalId = item.EcRenewalId,
                        LandLeaseDemandDetailId = item.LandLeaseDemandDetailId,
                        ParkingDemandDetailId = item.ParkingDemandDetailId,
                        StallDemandDetailId = item.StallDemandDetailId,
                        HouseRentDemandDetailId = item.HouseRentDemandDetailId,
                        MiscellaneousRecordId = item.MiscellaneousRecordId,
                        WaterMeterReadingId=item.WaterMeterReadingId
                    };
                    ctx.TblLedger.Add(entity);
                    ctx.SaveChanges();
                    lpk = entity.LedgerId;
                    if (trn.TransactionTypeId == 20)
                    {
                        var lpy = ctx.TblLandOwnershipDetail.Single(x => x.LandOwnershipId == item.LandOwnershipId);                     
                        if (lpy.LastTaxPaidYear == null || lpy.LastTaxPaidYear < Convert.ToInt32(cy.CalendarYear))
                        {
                            var DataUpdateLastPaid = ctx.TblLandOwnershipDetail.FirstOrDefault(u => u.LandOwnershipId == item.LandOwnershipId);
                            DataUpdateLastPaid.LastTaxPaidYear = Convert.ToInt32(cy.CalendarYear);
                            ctx.SaveChanges();
                        }
                    }

                   
                }


                var Data = ctx.TblDemand.Where(u =>u.IsCancelled == false && ids.Contains(u.DemandId.ToString()));

                foreach (var item in Data)
                {
                    var Data1 = ctx.TblDemand.Where(u => u.DemandId==item.DemandId);

                    Data1.FirstOrDefault().IsPaymentMade = true;
                    Data1.FirstOrDefault().PaymentDate = DateTime.Now;
                    //ctx.Entry(Data).State = EntityState.Modified;
                    ctx.SaveChanges();
                }
                //using (var dbcontext = new MyModel())
                //{
                //    var matchedRecords = dbcontext.DummyTable.Where(e => e.code.Equals(entry.code) && e.isValid.Equals(true)).ToList();
                //    matchedRecords.ForEach(e => e.isValid = false);
                //    dbcontext.SaveChanges();
                //}

                var trnid = Data.FirstOrDefault().TransactionId;
                var trntypeid = ctx.TblTransactionDetail.Where(t=>t.TransactionId==trnid).FirstOrDefault().TransactionTypeId;
 //*************************************************New Water Connection*****************************************************************************************************
                if (trntypeid == 2)
                {
                    int wcid ;
                    var watertrnDetailData = ctx.TrnWaterConnection.Where(w=>w.TransactionId==trnid);
                    var landDetailId = watertrnDetailData.FirstOrDefault().LandDetailId;
                    var landownershipId = watertrnDetailData.FirstOrDefault().LandOwnershipId;
                    var WaterconnectionStatusId = watertrnDetailData.FirstOrDefault().WaterConnectionStatusId;
                    var OwnerTypeId = watertrnDetailData.FirstOrDefault().OwnerTypeId;
                    var ChangeTypeId = watertrnDetailData.FirstOrDefault().ChangeTypeId;
                    var MeterNo = watertrnDetailData.FirstOrDefault().WaterMeterNo;
                    var WaterMeterTypeId = watertrnDetailData.FirstOrDefault().WaterMeterTypeId;
                    var consNo = watertrnDetailData.FirstOrDefault().ConsumerNo;
                    var ConnectionDate = watertrnDetailData.FirstOrDefault().CreatedOn;
                    var SewerageConnection = watertrnDetailData.FirstOrDefault().SewerageConnection;
                    var WaterConnectionTypeId = watertrnDetailData.FirstOrDefault().WaterConnectionTypeId;
                    var StandardCosumption = watertrnDetailData.FirstOrDefault().StandardCosumption;
                    var CreatedBy = watertrnDetailData.FirstOrDefault().CreatedBy;
                    var CreatedOn = watertrnDetailData.FirstOrDefault().CreatedOn;
                    var BillingAddress = watertrnDetailData.FirstOrDefault().BillingAddress;
                    var ZoneId = watertrnDetailData.FirstOrDefault().ZoneId;
                    var FlatNo = watertrnDetailData.FirstOrDefault().FlatNo;
                    var InitialReading = watertrnDetailData.FirstOrDefault().InitialReading;
                    var OrganisationName = watertrnDetailData.FirstOrDefault().OrganisationName;
                    var IsActive = watertrnDetailData.FirstOrDefault().IsActive;
                    var IsPermanentConnection = watertrnDetailData.FirstOrDefault().IsPermanent;
                    var IsPermanentDisconnect = watertrnDetailData.FirstOrDefault().IsPermanentDisconnect;
                    var Remarks = watertrnDetailData.FirstOrDefault().Remarks;
                    var DisconnectDate = watertrnDetailData.FirstOrDefault().DisconnectDate;
                    var NoOfUnits = watertrnDetailData.FirstOrDefault().NoOfUnits;
                    var ReconnectionDate = watertrnDetailData.FirstOrDefault().ReconnectionDate;
                    var SewarageConnectionDate = watertrnDetailData.FirstOrDefault().SewarageConnectionDate;
                    var SewarageConnectedBy = watertrnDetailData.FirstOrDefault().SewarageConnectedBy;
                    var PrimaryMobileNo = watertrnDetailData.FirstOrDefault().PrimaryMobileNo;
                    var SecondaryMobileNo = watertrnDetailData.FirstOrDefault().SecondaryMobileNo;
                    var TransactionId = watertrnDetailData.FirstOrDefault().TransactionId;
                    var WaterLineTypeId = watertrnDetailData.FirstOrDefault().WaterLineTypeId;                  

                    var entitywc = new MstWaterConnection
                    {
                        LandDetailId = landDetailId,
                        LandOwnershipId = (int)landownershipId,
                        WaterConnectionStatusId = WaterconnectionStatusId,
                        OwnerTypeId = OwnerTypeId,
                        ChangeTypeId = ChangeTypeId,
                        WaterMeterNo = MeterNo,
                        WaterMeterTypeId = WaterMeterTypeId,
                        ConsumerNo = consNo,
                        ConnectionDate = ConnectionDate,
                        SewerageConnection = SewerageConnection,
                        WaterConnectionTypeId = WaterConnectionTypeId,
                        StandardConsumption = StandardCosumption,
                        CreatedBy = CreatedBy,
                        CreatedOn = DateTime.Now,
                        BillingAddress = BillingAddress,
                        ZoneId = ZoneId,
                        FlatNo = FlatNo,
                        InitialReading = InitialReading,
                        OrganisationName = OrganisationName,
                        IsActive = IsActive,
                        IsPermanentDisconnect = IsPermanentDisconnect,
                        IsPermanentConnection = IsPermanentConnection,
                        Remarks = Remarks,
                        DisconnectDate = DisconnectDate,
                        NoOfUnits = NoOfUnits,
                        ReconnectionDate = ReconnectionDate,
                        SewarageConnectionDate = SewarageConnectionDate,
                        SewarageConnectedBy = SewarageConnectedBy,
                        PrimaryMobileNo = PrimaryMobileNo,
                        SecondaryMobileNo = SecondaryMobileNo,
                        TransactionId = TransactionId,
                        SolidWaste = false,
                        WaterLineTypeId = WaterLineTypeId
                        
                    };
                        ctx.MstWaterConnection.Add(entitywc);
                        ctx.SaveChanges();
                    wcid = entitywc.WaterConnectionId;
                    var entitywmr = new TblWaterMeterReading
                    {
                        WaterConnectionId = wcid,
                        WaterConnectionStatusId = WaterconnectionStatusId,
                        WaterMeterTypeId = WaterMeterTypeId,
                        WaterConnectionTypeId = WaterConnectionTypeId,
                        StandardConsumption = (int?)StandardCosumption,
                        CreatedBy = CreatedBy,
                        CreatedOn = DateTime.Now,
                        BillingAddress = BillingAddress,
                        ZoneId = ZoneId,
                        FlatNo = FlatNo,
                        IsActive = IsActive,
                        Remarks = Remarks,
                        PrimaryMobileNo = PrimaryMobileNo,
                        SecondaryMobileNo = SecondaryMobileNo,
                        WaterLineTypeId = WaterLineTypeId,
                        IsDisconnected = false,
                        IsRead = false,
                        PreviousReading = 0,
                        PreviousReadingDate = DateTime.Now,
                        NoOfUnit = NoOfUnits,
                        Consumption = 0,
                        IsPermanentConnection = true,
                        Sewerage = true,
                        SolidWaste = false,
                        Reading = 0,
                        ReadingDate = DateTime.Now,
                        ReadBy = ZoneId,
                        CreateTransactionId = TransactionId
                        
                    };
                    ctx.TblWaterMeterReading.Add(entitywmr);
                    ctx.SaveChanges();
                }
//**************************************************Reconnection******************************************************************************************
                else if (trntypeid == 7)
                {                    
                    var watertrnDetailData = ctx.TrnWaterConnection.Where(w => w.TransactionId == trnid);
                    var landDetailId = watertrnDetailData.FirstOrDefault().LandDetailId;
                    var landownershipId = watertrnDetailData.FirstOrDefault().LandOwnershipId;
                    var WaterconnectionStatusId = watertrnDetailData.FirstOrDefault().WaterConnectionStatusId;
                    var OwnerTypeId = watertrnDetailData.FirstOrDefault().OwnerTypeId;
                    var ChangeTypeId = watertrnDetailData.FirstOrDefault().ChangeTypeId;
                    var MeterNo = watertrnDetailData.FirstOrDefault().WaterMeterNo;
                    var WaterMeterTypeId = watertrnDetailData.FirstOrDefault().WaterMeterTypeId;
                    var consNo = watertrnDetailData.FirstOrDefault().ConsumerNo;
                    var ConnectionDate = watertrnDetailData.FirstOrDefault().CreatedOn;
                    var SewerageConnection = watertrnDetailData.FirstOrDefault().SewerageConnection;
                    var WaterConnectionTypeId = watertrnDetailData.FirstOrDefault().WaterConnectionTypeId;
                    var StandardCosumption = watertrnDetailData.FirstOrDefault().StandardCosumption;
                    var CreatedBy = watertrnDetailData.FirstOrDefault().CreatedBy;
                    var CreatedOn = watertrnDetailData.FirstOrDefault().CreatedOn;
                    var BillingAddress = watertrnDetailData.FirstOrDefault().BillingAddress;
                    var ZoneId = watertrnDetailData.FirstOrDefault().ZoneId;
                    var FlatNo = watertrnDetailData.FirstOrDefault().FlatNo;
                    var InitialReading = watertrnDetailData.FirstOrDefault().InitialReading;
                    var OrganisationName = watertrnDetailData.FirstOrDefault().OrganisationName;
                    var IsActive = watertrnDetailData.FirstOrDefault().IsActive;
                    var IsPermanentDisconnect = watertrnDetailData.FirstOrDefault().IsPermanentDisconnect;
                    var IsPermanent = watertrnDetailData.FirstOrDefault().IsPermanent;
                    var Remarks = watertrnDetailData.FirstOrDefault().Remarks;
                    var DisconnectDate = watertrnDetailData.FirstOrDefault().DisconnectDate;
                    var NoOfUnits = watertrnDetailData.FirstOrDefault().NoOfUnits;
                    var ReconnectionDate = watertrnDetailData.FirstOrDefault().ReconnectionDate;
                    var SewarageConnectionDate = watertrnDetailData.FirstOrDefault().SewarageConnectionDate;
                    var SewarageConnectedBy = watertrnDetailData.FirstOrDefault().SewarageConnectedBy;
                    var PrimaryMobileNo = watertrnDetailData.FirstOrDefault().PrimaryMobileNo;
                    var SecondaryMobileNo = watertrnDetailData.FirstOrDefault().SecondaryMobileNo;
                    var TransactionId = watertrnDetailData.FirstOrDefault().TransactionId;
                    var WaterLineTypeId = watertrnDetailData.FirstOrDefault().WaterLineTypeId;
                    var OldWaterConnectionId = watertrnDetailData.FirstOrDefault().OldWaterConnectionId;
                    var PreviousReading = watertrnDetailData.FirstOrDefault().PreviousReading;

                    var wmr = ctx.TblWaterMeterReading.Where(w => w.WaterConnectionId == OldWaterConnectionId);
                    var reby = wmr.FirstOrDefault().ReadBy;

                    var ReconnectData = ctx.MstWaterConnection.Where(u => u.WaterConnectionId == OldWaterConnectionId);
                    
                        ReconnectData.FirstOrDefault().IsActive = true;
                        ReconnectData.FirstOrDefault().IsPermanentDisconnect = false;
                        ctx.SaveChanges();
                    var entitywmr = new TblWaterMeterReading
                    {
                        WaterConnectionId =(int) OldWaterConnectionId,
                        WaterConnectionStatusId = WaterconnectionStatusId,
                        WaterMeterTypeId = WaterMeterTypeId,
                        WaterConnectionTypeId = WaterConnectionTypeId,
                        StandardConsumption = StandardCosumption,
                        CreatedBy = CreatedBy,
                        CreatedOn = DateTime.Now,
                        BillingAddress = BillingAddress,
                        ZoneId = ZoneId,
                        FlatNo = FlatNo,
                        IsActive = true,
                        Remarks = Remarks,
                        PrimaryMobileNo = PrimaryMobileNo,
                        SecondaryMobileNo = SecondaryMobileNo,                       
                        WaterLineTypeId = WaterLineTypeId,
                        IsDisconnected = false,
                        IsRead = false,
                        PreviousReading =(int) PreviousReading,
                        PreviousReadingDate = DateTime.Now,
                        NoOfUnit = NoOfUnits,
                        Consumption = 0,
                        IsPermanentConnection = true,
                        Sewerage = true,
                        SolidWaste = false,
                        Reading = (int)PreviousReading,
                        ReadingDate = DateTime.Now,
                        ReadBy = reby,
                        CreateTransactionId = TransactionId,
                        TransactionId = TransactionId,

                    };
                    ctx.TblWaterMeterReading.Add(entitywmr);
                    ctx.SaveChanges();


                }


                ////***********************************************Meter Replacement ***************************************************************************
                if (trntypeid == 8)
                {
                    int wcid;
                    var watertrnDetailData = ctx.TrnWaterConnection.Where(w => w.TransactionId == trnid);
                    var landDetailId = watertrnDetailData.FirstOrDefault().LandDetailId;
                    var landownershipId = watertrnDetailData.FirstOrDefault().LandOwnershipId;
                    var WaterconnectionStatusId = watertrnDetailData.FirstOrDefault().WaterConnectionStatusId;
                    var OwnerTypeId = watertrnDetailData.FirstOrDefault().OwnerTypeId;
                    var ChangeTypeId = watertrnDetailData.FirstOrDefault().ChangeTypeId;
                    var MeterNo = watertrnDetailData.FirstOrDefault().WaterMeterNo;
                    var WaterMeterTypeId = watertrnDetailData.FirstOrDefault().WaterMeterTypeId;
                    var consNo = watertrnDetailData.FirstOrDefault().ConsumerNo;
                    var ConnectionDate = watertrnDetailData.FirstOrDefault().CreatedOn;
                    var SewerageConnection = watertrnDetailData.FirstOrDefault().SewerageConnection;
                    var WaterConnectionTypeId = watertrnDetailData.FirstOrDefault().WaterConnectionTypeId;
                    var StandardCosumption = watertrnDetailData.FirstOrDefault().StandardCosumption;
                    var CreatedBy = watertrnDetailData.FirstOrDefault().CreatedBy;
                    var CreatedOn = watertrnDetailData.FirstOrDefault().CreatedOn;
                    var BillingAddress = watertrnDetailData.FirstOrDefault().BillingAddress;
                    var ZoneId = watertrnDetailData.FirstOrDefault().ZoneId;
                    var FlatNo = watertrnDetailData.FirstOrDefault().FlatNo;
                    var InitialReading = watertrnDetailData.FirstOrDefault().InitialReading;
                    var OrganisationName = watertrnDetailData.FirstOrDefault().OrganisationName;
                    var IsActive = watertrnDetailData.FirstOrDefault().IsActive;
                    var IsPermanentDisconnect = watertrnDetailData.FirstOrDefault().IsPermanentDisconnect;
                    var Remarks = watertrnDetailData.FirstOrDefault().Remarks;
                    var DisconnectDate = watertrnDetailData.FirstOrDefault().DisconnectDate;
                    var NoOfUnits = watertrnDetailData.FirstOrDefault().NoOfUnits;
                    var ReconnectionDate = watertrnDetailData.FirstOrDefault().ReconnectionDate;
                    var SewarageConnectionDate = watertrnDetailData.FirstOrDefault().SewarageConnectionDate;
                    var SewarageConnectedBy = watertrnDetailData.FirstOrDefault().SewarageConnectedBy;
                    var PrimaryMobileNo = watertrnDetailData.FirstOrDefault().PrimaryMobileNo;
                    var SecondaryMobileNo = watertrnDetailData.FirstOrDefault().SecondaryMobileNo;
                    var TransactionId = watertrnDetailData.FirstOrDefault().TransactionId;
                    var WaterLineTypeId = watertrnDetailData.FirstOrDefault().WaterLineTypeId;
                    var PreviousReading = watertrnDetailData.FirstOrDefault().PreviousReading;
                    var CurrReadingDate = watertrnDetailData.FirstOrDefault().ReadingDate;
                    var PreviousReadingDate = watertrnDetailData.FirstOrDefault().PreviousReadingDate;
                    var OldWaterConnectionId = watertrnDetailData.FirstOrDefault().OldWaterConnectionId;
                  
                   
                    var entitywc = new MstWaterConnection
                    {
                        LandDetailId = landDetailId,
                        LandOwnershipId = (int)landownershipId,
                        WaterConnectionStatusId = WaterconnectionStatusId,
                        OwnerTypeId = OwnerTypeId,
                        ChangeTypeId = ChangeTypeId,
                        WaterMeterNo = MeterNo,
                        WaterMeterTypeId = WaterMeterTypeId,
                        ConsumerNo = consNo,
                        ConnectionDate = ConnectionDate,
                        SewerageConnection = SewerageConnection,
                        WaterConnectionTypeId = WaterConnectionTypeId,
                        StandardConsumption = StandardCosumption,
                        CreatedBy = CreatedBy,
                        CreatedOn = DateTime.Now,
                        BillingAddress = BillingAddress,
                        ZoneId = ZoneId,
                        FlatNo = FlatNo,
                        InitialReading = 0,// InitialReading,
                        OrganisationName = OrganisationName,
                        IsActive = IsActive,
                        IsPermanentDisconnect = IsPermanentDisconnect,
                        IsPermanentConnection = true,
                        Remarks = Remarks,
                        DisconnectDate = DisconnectDate,
                        NoOfUnits = NoOfUnits,
                        //ReconnectionDate = ReconnectionDate,
                        SewarageConnectionDate = SewarageConnectionDate,
                        SewarageConnectedBy = SewarageConnectedBy,
                        PrimaryMobileNo = PrimaryMobileNo,
                        SecondaryMobileNo = SecondaryMobileNo,
                        TransactionId = TransactionId,
                        SolidWaste = false,
                        WaterLineTypeId = WaterLineTypeId,
                        
                    };
                    ctx.MstWaterConnection.Add(entitywc);
                    ctx.SaveChanges();
                    wcid = entitywc.WaterConnectionId;
                    var entitywmr = new TblWaterMeterReading
                    {
                        WaterConnectionId = wcid,
                        WaterConnectionStatusId = WaterconnectionStatusId,
                        WaterMeterTypeId = WaterMeterTypeId,
                        WaterConnectionTypeId = WaterConnectionTypeId,
                        StandardConsumption = (int?)StandardCosumption,
                        CreatedBy = CreatedBy,
                        CreatedOn = DateTime.Now,
                        BillingAddress = BillingAddress,
                        ZoneId = ZoneId,
                        FlatNo = FlatNo,
                        IsActive = IsActive,
                        Remarks = Remarks,
                        PrimaryMobileNo = PrimaryMobileNo,
                        SecondaryMobileNo = SecondaryMobileNo,
                        WaterLineTypeId = WaterLineTypeId,
                        IsDisconnected = false,
                        IsRead = false,
                        PreviousReading = 0,
                        PreviousReadingDate = (DateTime)PreviousReadingDate,
                        NoOfUnit = NoOfUnits,
                        Consumption = 0,
                        IsPermanentConnection = true,
                        Sewerage = true,
                        SolidWaste = false,
                        Reading = 0,
                        ReadingDate = (DateTime)CurrReadingDate,
                        ReadBy = ZoneId,
                        CreateTransactionId = TransactionId,
                     

                    };
                    ctx.TblWaterMeterReading.Add(entitywmr);
                    ctx.SaveChanges();

                    var update = ctx.MstWaterConnection.Where(u => u.WaterConnectionId == OldWaterConnectionId);
                    if (update.Any())
                    {
                        update.FirstOrDefault().IsActive = false;
                        update.FirstOrDefault().IsPermanentDisconnect = true;
                        ctx.SaveChanges();
                    }

                    var entitymaxReadingId = ctx.TblWaterMeterReading.Where(u => u.WaterConnectionId == OldWaterConnectionId).Max(y => y.WaterMeterReadingId);

                    var entitywr = ctx.TblWaterMeterReading.Where(u => u.WaterMeterReadingId == entitymaxReadingId);
                    entitywr.FirstOrDefault().IsDisconnected = true;
                    entitywr.FirstOrDefault().IsActive = false;
                    entitywr.FirstOrDefault().IsRead = true;

                    ctx.SaveChanges();
                }
                var Delete = ctx.TrnWaterConnection.Where(u => u.TransactionId == trnid);
                if (Delete.Any())
                {
                    Delete.FirstOrDefault().WorkLevelId = 4;
                    ctx.SaveChanges();
                }
                //*******************************************************************shifting ***************************************************************************************************************
                //*******************************************************************disconnection ***************************************************************************************************************
                if (trntypeid == 21)
                {
                    var watertrnDetailData = ctx.TrnWaterConnection.Where(w => w.TransactionId == trnid);
                    var OldWaterConnectionId = watertrnDetailData.FirstOrDefault().OldWaterConnectionId;

                    var dwm = ctx.MstWaterConnection.Where(u => u.WaterConnectionId == OldWaterConnectionId);
                    if (dwm.Any())
                    {
                        dwm.FirstOrDefault().IsActive = false;
                        dwm.FirstOrDefault().IsPermanentDisconnect = true;
                        ctx.SaveChanges();
                    }

                    var entitymaxReadingId = ctx.TblWaterMeterReading.Where(u => u.WaterConnectionId == OldWaterConnectionId).Max(y => y.WaterMeterReadingId);


                    var entitywr = ctx.TblWaterMeterReading.Where(u => u.WaterMeterReadingId == entitymaxReadingId);
                    entitywr.FirstOrDefault().IsDisconnected = true;
                    entitywr.FirstOrDefault().IsActive = false;
                    entitywr.FirstOrDefault().IsRead = true;

                    ctx.SaveChanges();
                }
                //********************************************************************************upgrade/downgrade****************************************************************************************

                if (trntypeid == 43)
                {

                    int wcid;
                    var watertrnDetailData = ctx.TrnWaterConnection.Where(w => w.TransactionId == trnid);
                    var landDetailId = watertrnDetailData.FirstOrDefault().LandDetailId;
                    var landownershipId = watertrnDetailData.FirstOrDefault().LandOwnershipId;
                    var WaterconnectionStatusId = watertrnDetailData.FirstOrDefault().WaterConnectionStatusId;
                    var OwnerTypeId = watertrnDetailData.FirstOrDefault().OwnerTypeId;
                    var ChangeTypeId = watertrnDetailData.FirstOrDefault().ChangeTypeId;
                    var MeterNo = watertrnDetailData.FirstOrDefault().WaterMeterNo;
                    var WaterMeterTypeId = watertrnDetailData.FirstOrDefault().WaterMeterTypeId;
                    var consNo = watertrnDetailData.FirstOrDefault().ConsumerNo;
                    var ConnectionDate = watertrnDetailData.FirstOrDefault().CreatedOn;
                    var SewerageConnection = watertrnDetailData.FirstOrDefault().SewerageConnection;
                    var WaterConnectionTypeId = watertrnDetailData.FirstOrDefault().WaterConnectionTypeId;
                    var StandardCosumption = watertrnDetailData.FirstOrDefault().StandardCosumption;
                    var CreatedBy = watertrnDetailData.FirstOrDefault().CreatedBy;
                    var CreatedOn = watertrnDetailData.FirstOrDefault().CreatedOn;
                    var BillingAddress = watertrnDetailData.FirstOrDefault().BillingAddress;
                    var ZoneId = watertrnDetailData.FirstOrDefault().ZoneId;
                    var FlatNo = watertrnDetailData.FirstOrDefault().FlatNo;
                    var InitialReading = watertrnDetailData.FirstOrDefault().InitialReading;
                    var OrganisationName = watertrnDetailData.FirstOrDefault().OrganisationName;
                    var IsActive = watertrnDetailData.FirstOrDefault().IsActive;
                    var IsPermanent = watertrnDetailData.FirstOrDefault().IsPermanent;
                    var IsPermanentDisconnect = watertrnDetailData.FirstOrDefault().IsPermanentDisconnect;
                    var Remarks = watertrnDetailData.FirstOrDefault().Remarks;
                    var DisconnectDate = watertrnDetailData.FirstOrDefault().DisconnectDate;
                    var NoOfUnits = watertrnDetailData.FirstOrDefault().NoOfUnits;
                    var ReconnectionDate = watertrnDetailData.FirstOrDefault().ReconnectionDate;
                    var SewarageConnectionDate = watertrnDetailData.FirstOrDefault().SewarageConnectionDate;
                    var SewarageConnectedBy = watertrnDetailData.FirstOrDefault().SewarageConnectedBy;
                    var PrimaryMobileNo = watertrnDetailData.FirstOrDefault().PrimaryMobileNo;
                    var SecondaryMobileNo = watertrnDetailData.FirstOrDefault().SecondaryMobileNo;
                    var TransactionId = watertrnDetailData.FirstOrDefault().TransactionId;
                    var WaterLineTypeId = watertrnDetailData.FirstOrDefault().WaterLineTypeId;
                    var PreviousReading = watertrnDetailData.FirstOrDefault().PreviousReading;
                    var CurrReadingDate = watertrnDetailData.FirstOrDefault().ReadingDate;
                    var PreviousReadingDate = watertrnDetailData.FirstOrDefault().PreviousReadingDate;
                    var OldWaterConnectionId = watertrnDetailData.FirstOrDefault().OldWaterConnectionId;
                    var entitywc = new MstWaterConnection
                    {
                        LandDetailId = landDetailId,
                        LandOwnershipId = (int)landownershipId,
                        WaterConnectionStatusId = WaterconnectionStatusId,
                        OwnerTypeId = OwnerTypeId,
                        ChangeTypeId = ChangeTypeId,
                        WaterMeterNo = MeterNo,
                        WaterMeterTypeId = WaterMeterTypeId,
                        ConsumerNo = consNo,
                        ConnectionDate = ConnectionDate,
                        SewerageConnection = SewerageConnection,
                        WaterConnectionTypeId = WaterConnectionTypeId,
                        StandardConsumption = StandardCosumption,
                        CreatedBy = CreatedBy,
                        CreatedOn = DateTime.Now,
                        BillingAddress = BillingAddress,
                        ZoneId = ZoneId,
                        FlatNo = FlatNo,
                        InitialReading = InitialReading,
                        OrganisationName = OrganisationName,
                        IsActive = IsActive,
                        IsPermanentDisconnect = IsPermanentDisconnect,
                        Remarks = Remarks,
                        DisconnectDate = DisconnectDate,
                        NoOfUnits = NoOfUnits,
                        //ReconnectionDate = ReconnectionDate,
                        SewarageConnectionDate = SewarageConnectionDate,
                        SewarageConnectedBy = SewarageConnectedBy,
                        PrimaryMobileNo = PrimaryMobileNo,
                        SecondaryMobileNo = SecondaryMobileNo,
                        TransactionId = TransactionId,
                        SolidWaste = false,
                        WaterLineTypeId = WaterLineTypeId,
                        IsPermanentConnection= IsPermanent,
                    };
                    ctx.MstWaterConnection.Add(entitywc);
                    ctx.SaveChanges();
                    wcid = entitywc.WaterConnectionId;
                    var entitywmr = new TblWaterMeterReading
                    {
                        WaterConnectionId = wcid,
                        WaterConnectionStatusId = WaterconnectionStatusId,
                        WaterMeterTypeId = WaterMeterTypeId,
                        WaterConnectionTypeId = WaterConnectionTypeId,
                        StandardConsumption = (int?)StandardCosumption,
                        CreatedBy = CreatedBy,
                        CreatedOn = DateTime.Now,
                        BillingAddress = BillingAddress,
                        ZoneId = ZoneId,
                        FlatNo = FlatNo,
                        IsActive = IsActive,
                        Remarks = Remarks,
                        PrimaryMobileNo = PrimaryMobileNo,
                        SecondaryMobileNo = SecondaryMobileNo,
                        WaterLineTypeId = WaterLineTypeId,
                        IsDisconnected = false,
                        IsRead = false,
                        PreviousReading = (int)PreviousReading,
                        PreviousReadingDate = (DateTime)PreviousReadingDate,
                        NoOfUnit = NoOfUnits,
                        Consumption = 0,
                        IsPermanentConnection =(bool) IsPermanent,
                        Sewerage = true,
                        SolidWaste = false,
                        Reading = (int)InitialReading,
                        ReadingDate = (DateTime)CurrReadingDate,
                        ReadBy = ZoneId,
                        CreateTransactionId = TransactionId,

                    };
                    ctx.TblWaterMeterReading.Add(entitywmr);
                    ctx.SaveChanges();

                    var update = ctx.MstWaterConnection.Where(u => u.WaterConnectionId == OldWaterConnectionId && IsActive == true);
                    if (update.Any())
                    {
                        update.FirstOrDefault().IsActive = false;
                        update.FirstOrDefault().IsPermanentDisconnect = true;
                        ctx.SaveChanges();
                    }

                    var entitymaxReadingId = ctx.TblWaterMeterReading.Where(u => u.WaterConnectionId == OldWaterConnectionId && IsActive == true).Max(y => y.WaterMeterReadingId);

                    var entitywr = ctx.TblWaterMeterReading.Where(u => u.WaterMeterReadingId == entitymaxReadingId);
                    entitywr.FirstOrDefault().IsDisconnected = true;
                    entitywr.FirstOrDefault().IsActive = false;
                    ctx.SaveChanges();
                }
                var change = ctx.TrnWaterConnection.Where(u => u.TransactionId == trnid);
                if (change.Any())
                {
                    change.FirstOrDefault().WorkLevelId = 4;
                    ctx.SaveChanges();
                }






                //****************************************************UnScheduledParking*********************************************************************************
                if (trntypeid == 42)
                {
                    
                    var upri = ctx.TblUnScheduledParkingRecord.Where(w => w.TransactionId == trnid);
                    var UnScheduledParkingRecordId = upri.FirstOrDefault().UnScheduledParkingRecordId;
                    var update = ctx.TblLedger.Where(u => u.TransactionId == trnid);
                    if (update.Any())
                    {
                        update.FirstOrDefault().UnScheduledParkingRecordId = UnScheduledParkingRecordId;
                        ctx.SaveChanges();
                    }
                }

                //PENALTY CALCULATION
                //var entityP = new TblLedger
                //{
                //    DemandId =1,
                //    TransactionId = 1,//
                //    TaxId = item.TaxId,
                //    FinancialYearId = item.FinancialYearId,
                //    CalendarYearId = item.CalendarYearId,
                //    LandDetailId = item.LandDetailId,
                //    TaxPayerId = item.TaxPayerId,
                //    TotalAmount = item.TotalAmount,
                //    PaymentDate = DateTime.Now,
                //    ReceiptId = pk,
                //    CreatedBy = item.CreatedBy,
                //    CreatedOn = DateTime.Now,
                //    ApplicantId = item.ApplicantId,
                //    EcRenewalId = item.EcRenewalId,
                //    LandLeaseDemandDetailId = item.LandLeaseDemandDetailId,
                //    ParkingDemandDetailId = item.ParkingDemandDetailId,
                //    StallDemandDetailId = item.StallDemandDetailId,
                //    HouseRentDemandDetailId = item.HouseRentDemandDetailId,
                //    MiscellaneousRecordId = item.MiscellaneousRecordId,
                //};
                //ctx.TblLedger.Add(entityP);
                //ctx.SaveChanges();

                var w = ctx.TblTransactionDetail.Where(u => u.TransactionId == trnid);
                if (w.Any())
                {
                    w.FirstOrDefault().WorkLevelId = 4;
                    ctx.SaveChanges();
                }
                s.Complete();
                s.Dispose();

                return pk;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        public long CreatePaymentLedger(LedgerPaymentLedgerModel obj)
        {
            try
            {
                using TransactionScope s = new TransactionScope();
                //string[] ids = obj.Ids.Split(',');
                //var demand = (ctx.TblDemand.Where(x => ids.Contains(x.DemandId.ToString())));
                long pk;
                //foreach (var item in demand.ToList())
                //{
                var entity = new TblPaymentLeger
                {
                    PaymentModeId = obj.PaymentModeId,
                    PaymentModeNo = obj.PaymentModeNo,
                    PaymentModeDate = obj.PaymentModeDate,
                    Amount = obj.Amount,
                    BankBranchId = obj.BankBranchId,
                    ReceiptId = obj.ReceiptId,
                    CreatedBy = obj.CreatedBy,
                    CreatedOn = DateTime.Now,
                };
                ctx.TblPaymentLeger.Add(entity);
                ctx.SaveChanges();
                pk = entity.ReceiptId;

             //   ctx.SaveChanges();
                
                //}
                s.Complete();
                s.Dispose();

                return pk;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        //*************************** Print Paymen receipt***************************************
        public byte[] GenerateQr(string txtQRCode)
        {
            QRCodeGenerator _qrCode = new QRCodeGenerator();
            QRCodeData _qrCodeData = _qrCode.CreateQrCode(txtQRCode, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(_qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(20);
            return BitmapToBytesCode(qrCodeImage);
            // return View(BitmapToBytesCode(qrCodeImage));
        }
        //[NonAction]
        private static Byte[] BitmapToBytesCode(Bitmap image)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                image.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                return stream.ToArray();
            }
        }
        //***********************************************date for vendor********************************************************
        public IList<LedgerDemandVM> fetchreceiptuser(int ReceiptId)
        {
           var data = from x in ctx.TblLedger.Where(x => x.ReceiptId == ReceiptId)
                       
                       join au in ctx.AspNetUsers on x.CreatedBy equals au.UserId
                       select new LedgerDemandVM
                       {
                         Creatorname = au.FirstName + " " + ((au.MiddleName == null || au.MiddleName.Trim() == string.Empty) ? string.Empty : (au.MiddleName + " ")) + ((au.LastName == null || au.LastName.Trim() == string.Empty) ? string.Empty : (au.LastName + " ")),
                        }; ;
            return data.ToList();
        }

        //***********************************************payment mode****************************************

        public IList<LedgerDemandVM> PrintPaymentModes(int ReceiptId)
        {
            var data = (from x in ctx.TblPaymentLeger.Where(x => x.ReceiptId == ReceiptId)
                        join pm in ctx.EnumPaymentMode on x.PaymentModeId equals pm.PaymentModeId
                        into pm_temp
                        from pm_value in pm_temp.DefaultIfEmpty()
                        join bb in ctx.MstBankBranch on x.BankBranchId equals bb.BankBranchId
                        into bb_temp
                        from bb_value in bb_temp.DefaultIfEmpty()
                        join bfs in ctx.TblBfsTransactiondetails on x.BfsTransactionDetailId equals bfs.BfsTransactionDetailId
                        into bfs_temp
                        from bfs_value in bfs_temp.DefaultIfEmpty()
                        let netamt = ctx.TblLedger.Where(l => l.ReceiptId == ReceiptId).Sum(t => t.TotalAmount)
                        let pa = ctx.TblLedger.Where(l => l.ReceiptId == ReceiptId).Sum(t => t.PenaltyAmount)
                        let pd = ctx.TblLedger.Where(l => l.ReceiptId == ReceiptId).Max(t => t.PenaltyPeriod)
                        select new LedgerDemandVM
                        {
                            Paymentmode = pm_value.PaymentMode ?? "0",
                            PaymentModeNo = (x.PaymentModeNo == null? "0" : x.PaymentModeNo),
                            PaymentModeDate = (DateTime)x.PaymentModeDate,
                            ReceiptId = x.ReceiptId,
                            TotalAmount = netamt,
                            PenaltyAmount = pa,
                            PenaltyDays = pd,
                            Amount = x.Amount,
                            Bank =(bb_value.BranchName == null ? bfs_value.BfsBankName : bb_value.BranchName),
                            CreatedOn = x.CreatedOn,

                        });

            return data.ToList();
        }
        //***************************************** UnScheduledParkingRecord recepit*****************************************
        public List<LedgerDemandVM> UnScheduledParkingRecordrecepit(long RecepitId)
        {
            var rn = ctx.TblReceipt.Where(d => d.ReceiptId == RecepitId).Max(x => x.ReceiptNo);
            var data = (from x in ctx.TblLedger.Where(x => x.ReceiptId == RecepitId)
                        join z in ctx.MstTaxMaster on x.TaxId equals z.TaxId
                        
                        join tp in ctx.TblUnScheduledParkingRecord on x.TransactionId equals tp.TransactionId

                        let netamt = ctx.TblLedger.Where(l => l.ReceiptId == RecepitId).Sum(t => t.TotalAmount)
                        let pnetamt = ctx.TblLedger.Where(l => l.ReceiptId == RecepitId).Sum(t => t.PenaltyAmount)


                        let qr = GenerateQr(rn.ToString())
                        select new LedgerDemandVM
                        {
                            QrImage = qr,
                            Receipt = rn,
                            TotalAmount = netamt,
                            TotalPenaltyAmount = pnetamt,
                            Amount = x.TotalAmount,
                            CreatedOn = x.CreatedOn,
                            ReceiptId = x.ReceiptId,
                            FullName = tp.VendorName,
                            Address = tp.VendorAddress,
                            Cid = tp.Cid,
                            PenaltyAmount = x.PenaltyAmount,
                            PenaltyDays = x.PenaltyPeriod,
                            TaxName = z.TaxName,
                            FromDate =tp.FromDate,
                            ToDate = tp.ToDate

                         });

            return data.ToList();


        }
        //*****************************************Sewerage Connection recepit*****************************************
        public List<LedgerDemandVM> SewerageConnectionRecepit(long RecepitId)
        {
            var rn = ctx.TblReceipt.Where(d => d.ReceiptId == RecepitId).Max(x => x.ReceiptNo);
            var data = (from x in ctx.TblLedger.Where(x => x.ReceiptId == RecepitId)
                        join z in ctx.MstTaxMaster on x.TaxId equals z.TaxId
                        join t in ctx.TrnSewerageConnection on x.TransactionId equals t.TransactionId
                        join au in ctx.AspNetUsers on x.CreatedBy equals au.UserId
                        join tp in ctx.MstTaxPayerProfile on x.TaxPayerId equals tp.TaxPayerId

                        let netamt = ctx.TblLedger.Where(l => l.ReceiptId == RecepitId).Sum(t => t.TotalAmount)

                      
                        let qr = GenerateQr(rn.ToString())
                        select new LedgerDemandVM
                        {
                            QrImage = qr,

                            Receipt = rn,

                            TotalAmount = netamt,
                            Amount = x.TotalAmount,
                            CreatedOn = x.CreatedOn,
                            ReceiptId = x.ReceiptId,
                            TaxPayerId = tp.TaxPayerId,

                            FullName = tp.FirstName + " " + ((tp.MiddleName == null || tp.MiddleName.Trim() == string.Empty) ? string.Empty : (tp.MiddleName + " ")) + ((tp.LastName == null || tp.LastName.Trim() == string.Empty) ? string.Empty : (tp.LastName + " ")),
                            Caddress = tp.CAddress,
                            Cid = tp.Cid,
                            Ttin = tp.Ttin,
                           
                            PhoneNo = tp.MobileNo,
                            TaxName = z.TaxName

                          
                          


                        });

            return data.ToList();


        }


        //*****************************************Land Tranactions Fee recepit*****************************************
        public IList<LedgerDemandVM> LandTransactionFeeRecepit(long RecepitId)
        {
            var rn = ctx.TblReceipt.Where(d => d.ReceiptId == RecepitId).Max(x => x.ReceiptNo);
            var data = (from x in ctx.TblLedger.Where(x => x.ReceiptId == RecepitId)
                        join tx in ctx.MstTaxMaster on x.TaxId equals tx.TaxId
                        join t in ctx.TblTransactionDetail on x.TransactionId equals t.TransactionId
                        join ty in ctx.MstTransactionType on t.TransactionTypeId equals ty.TransactionTypeId
                        join tp in ctx.MstTaxPayerProfile on x.TaxPayerId equals tp.TaxPayerId
                        join tt in ctx.EnumTitle on tp.TitleId equals tt.TitleId
                        join l in ctx.MstLandDetail on x.LandDetailId equals l.LandDetailId
                       
                        let netamt = ctx.TblLedger.Where(l => l.ReceiptId == RecepitId).Sum(t => t.TotalAmount)
                        
                        let tno = (ctx.TblLandOwnershipDetail.Where(lod => lod.TaxPayerId == x.TaxPayerId && lod.LandDetailId == x.LandDetailId)).Take(1).FirstOrDefault().ThramNo
                        let qr = GenerateQr(rn.ToString())
                        select new LedgerDemandVM
                        {
                            QrImage = qr,

                            Receipt = rn,

                            TotalAmount = netamt,
                            Amount = x.TotalAmount,
                            CreatedOn = x.CreatedOn,
                            ReceiptId = x.ReceiptId,
                            TaxPayerId = tp.TaxPayerId,

                            FullName = tt.Title + "" + tp.FirstName + " " + ((tp.MiddleName == null || tp.MiddleName.Trim() == string.Empty) ? string.Empty : (tp.MiddleName + " ")) + ((tp.LastName == null || tp.LastName.Trim() == string.Empty) ? string.Empty : (tp.LastName + " ")),
                            Caddress = tp.CAddress,
                            Cid = tp.Cid,
                            Ttin = tp.Ttin,
                            PlotNo = l.PlotNo,
                            //ThramNo = l.ThramNo,
                            TaxName = tx.TaxName,

                            ThramNo = tno,
                            TransactionTypeId = t.TransactionTypeId
                            

                        });

            return data.ToList();


        }


        //*****************************************ConstructionApprovalApplicationFeeDetail recepit*****************************************
        public List<LedgerDemandVM> ConstructionApprovalApplicationFeeDetailRecepit(long RecepitId)
        {
            var rn = ctx.TblReceipt.Where(d => d.ReceiptId == RecepitId).Max(x => x.ReceiptNo);
            var data = (from x in ctx.TblLedger.Where(x => x.ReceiptId == RecepitId)
                        join tx in ctx.MstTaxMaster on x.TaxId equals tx.TaxId
                        join t in ctx.TblTransactionDetail on x.TransactionId equals t.TransactionId
                        join ty in ctx.MstTransactionType on t.TransactionTypeId equals ty.TransactionTypeId
                        join tp in ctx.MstTaxPayerProfile on x.TaxPayerId equals tp.TaxPayerId
                        join tt in ctx.EnumTitle on tp.TitleId equals tt.TitleId
                        join l in ctx.MstLandDetail on x.LandDetailId equals l.LandDetailId

                        let netamt = ctx.TblLedger.Where(l => l.ReceiptId == RecepitId).Sum(t => t.TotalAmount)

                        let tno = (ctx.TblLandOwnershipDetail.Where(lod => lod.TaxPayerId == x.TaxPayerId && lod.LandDetailId == x.LandDetailId)).Take(1).FirstOrDefault().ThramNo
                        let qr = GenerateQr(rn.ToString())
                        select new LedgerDemandVM
                        {
                            QrImage = qr,

                            Receipt = rn,

                            TotalAmount = netamt,
                            Amount = x.TotalAmount,
                            CreatedOn = x.CreatedOn,
                            ReceiptId = x.ReceiptId,
                            TaxPayerId = tp.TaxPayerId,

                            FullName = tt.Title + "" + tp.FirstName + " " + ((tp.MiddleName == null || tp.MiddleName.Trim() == string.Empty) ? string.Empty : (tp.MiddleName + " ")) + ((tp.LastName == null || tp.LastName.Trim() == string.Empty) ? string.Empty : (tp.LastName + " ")),
                            Caddress = tp.CAddress,
                            Cid = tp.Cid,
                            Ttin = tp.Ttin,
                            PlotNo = l.PlotNo,
                            //ThramNo = l.ThramNo,
                            TaxName = tx.TaxName,

                            ThramNo = tno,
                            TransactionTypeId = t.TransactionTypeId


                        });

            return data.ToList();


        }

        //*****************************************ConstructionApproval recepit*****************************************
        public List<LedgerDemandVM> ConstructionApprovalRecepit(long RecepitId)
        {
            var rn = ctx.TblReceipt.Where(d => d.ReceiptId == RecepitId).Max(x => x.ReceiptNo);
            var data = (from x in ctx.TblLedger.Where(x => x.ReceiptId == RecepitId)
                        join tx in ctx.MstTaxMaster on x.TaxId equals tx.TaxId
                        join t in ctx.TblTransactionDetail on x.TransactionId equals t.TransactionId
                        join ty in ctx.MstTransactionType on t.TransactionTypeId equals ty.TransactionTypeId
                        join tp in ctx.MstTaxPayerProfile on x.TaxPayerId equals tp.TaxPayerId
                        join tt in ctx.EnumTitle on tp.TitleId equals tt.TitleId
                        join l in ctx.MstLandDetail on x.LandDetailId equals l.LandDetailId

                        let netamt = ctx.TblLedger.Where(l => l.ReceiptId == RecepitId).Sum(t => t.TotalAmount)

                        let tno = (ctx.TblLandOwnershipDetail.Where(lod => lod.TaxPayerId == x.TaxPayerId && lod.LandDetailId == x.LandDetailId)).Take(1).FirstOrDefault().ThramNo
                        let qr = GenerateQr(rn.ToString())
                        select new LedgerDemandVM
                        {
                            QrImage = qr,

                            Receipt = rn,

                            TotalAmount = netamt,
                            Amount = x.TotalAmount,
                            CreatedOn = x.CreatedOn,
                            ReceiptId = x.ReceiptId,
                            TaxPayerId = tp.TaxPayerId,

                            FullName = tt.Title + "" + tp.FirstName + " " + ((tp.MiddleName == null || tp.MiddleName.Trim() == string.Empty) ? string.Empty : (tp.MiddleName + " ")) + ((tp.LastName == null || tp.LastName.Trim() == string.Empty) ? string.Empty : (tp.LastName + " ")),
                            Caddress = tp.CAddress,
                            Cid = tp.Cid,
                            Ttin = tp.Ttin,
                            PlotNo = l.PlotNo,
                            //ThramNo = l.ThramNo,
                            TaxName = tx.TaxName,

                            ThramNo = tno,
                            TransactionTypeId = t.TransactionTypeId


                        });

            return data.ToList();


        }
        //*****************************************meter shifting payment recepit*****************************************
        public List<LedgerDemandVM> printmetershifting(long RecepitId)
        {
            var rn = ctx.TblReceipt.Where(d => d.ReceiptId == RecepitId).Max(x => x.ReceiptNo);


            var data = (from x in ctx.TblLedger.Where(x => x.ReceiptId == RecepitId)
                        join tx in ctx.MstTaxMaster on x.TaxId equals tx.TaxId
                        join t in ctx.TblTransactionDetail on x.TransactionId equals t.TransactionId
                        join ty in ctx.MstTransactionType on t.TransactionTypeId equals ty.TransactionTypeId
                        join tp in ctx.MstTaxPayerProfile on x.TaxPayerId equals tp.TaxPayerId
                        // join l in ctx.MstLandDetail on x.LandDetailId equals l.LandDetailId
                        //join o in ctx.TblLandOwnershipDetail on l.LandDetailId equals o.LandDetailId
                        //join wc in ctx.MstWaterConnection on o.LandOwnershipId equals wc.LandOwnershipId
                        //join w in ctx.TblWaterMeterReading on wc.WaterConnectionId equals w.WaterConnectionId
                       // join w in ctx.MstWaterConnection on x.LandDetailId equals w.LandDetailId
                       // join wR in ctx.TblWaterMeterReading on w.WaterConnectionId equals wR.WaterConnectionId

                        let netamt = ctx.TblLedger.Where(l => l.ReceiptId == RecepitId).Sum(t => t.TotalAmount)

                        let consumerNo = (ctx.MstWaterConnection.Where(lod => lod.LandDetailId == x.LandDetailId && lod.IsActive == true)).Take(1).FirstOrDefault().ConsumerNo
                        let WaterMeterNo = (ctx.MstWaterConnection.Where(lod => lod.LandDetailId == x.LandDetailId && lod.IsActive == true)).Take(1).FirstOrDefault().WaterMeterNo
                         let BillingAddress = (ctx.MstWaterConnection.Where(lod => lod.LandDetailId == x.LandDetailId && lod.IsActive == true)).Take(1).FirstOrDefault().BillingAddress
                        // let mn = (ctx.MstWaterConnection.Where(lod => lod.LandOwnershipId == x.LandOwnershipId)).Take(1).FirstOrDefault().WaterMeterNo
                        //let ba = (ctx.TblWaterMeterReading.Where(lod => lod.WaterConnectionId == lod.WaterConnectionId)).Take(1).FirstOrDefault().BillingAddress
                        //let bm = (ctx.TblWaterMeterReading.Where(lod => lod.WaterConnectionId == lod.WaterConnectionId)).Take(1).FirstOrDefault().ReadingDate


                        let qr = GenerateQr(rn.ToString())
                        select new LedgerDemandVM
                        {
                            QrImage = qr,

                            Receipt = rn,

                            TotalAmount = netamt,
                            Amount = x.TotalAmount,
                            CreatedOn = x.CreatedOn,
                            //billmonth = (.ToString("MMM yyyy")),
                            ReceiptId = x.ReceiptId,


                            TaxPayerId = tp.TaxPayerId,

                            FullName = tp.FirstName + " " + ((tp.MiddleName == null || tp.MiddleName.Trim() == string.Empty) ? string.Empty : (tp.MiddleName + " ")) + ((tp.LastName == null || tp.LastName.Trim() == string.Empty) ? string.Empty : (tp.LastName + " ")),
                            Caddress = tp.CAddress,
                            Cid = tp.Cid,
                            Ttin = tp.Ttin,
                            //  PlotNo = l.PlotNo,
                            TaxName = tx.TaxName,

                            consumerNo = consumerNo,
                            WaterMeterNO = WaterMeterNo,
                            BillingAddress = BillingAddress,
                            TransactionTypeId = t.TransactionTypeId,


                        });

            return data.ToList();


        }

        //*****************************************New water payment recepit*****************************************
        public IList<LedgerDemandVM> PrintNewWaterPaymentreceipt(long RecepitId)
        {
            var rn = ctx.TblReceipt.Where(d => d.ReceiptId == RecepitId).Max(x => x.ReceiptNo);


            var data = (from x in ctx.TblLedger.Where(x => x.ReceiptId == RecepitId)
                        join tx in ctx.MstTaxMaster on x.TaxId equals tx.TaxId
                        join t in ctx.TblTransactionDetail on x.TransactionId equals t.TransactionId
                        join ty in ctx.MstTransactionType on t.TransactionTypeId equals ty.TransactionTypeId
                        join tp in ctx.MstTaxPayerProfile on x.TaxPayerId equals tp.TaxPayerId

                        join wc in ctx.TblWaterMeterReading on x.TransactionId equals wc.CreateTransactionId
                        join w in ctx.MstWaterConnection on wc.WaterConnectionId equals w.WaterConnectionId

                        let netamt = ctx.TblLedger.Where(l => l.ReceiptId == RecepitId).Sum(t => t.TotalAmount)

                         //let o = (ctx.TblLandOwnershipDetail.Where(lod => lod.TaxPayerId == x.TaxPayerId)).Take(1).FirstOrDefault().TaxPayerId
                        // let cn = (ctx.MstWaterConnection.Where(lod => lod.TransactionId == x.LandOwnershipId)).Take(1).FirstOrDefault().ConsumerNo
                        // let mn = (ctx.MstWaterConnection.Where(lod => lod.LandOwnershipId == x.LandOwnershipId)).Take(1).FirstOrDefault().WaterMeterNo
                         //let ba = (ctx.TblWaterMeterReading.Where(lod => lod.WaterConnectionId == lod.WaterConnectionId)).Take(1).FirstOrDefault().BillingAddress
                         //let bm = (ctx.TblWaterMeterReading.Where(lod => lod.WaterConnectionId == lod.WaterConnectionId)).Take(1).FirstOrDefault().ReadingDate
                        
                       
                         let qr = GenerateQr(rn.ToString())
                        select new LedgerDemandVM
                        {
                            QrImage = qr,

                            Receipt = rn,

                            TotalAmount = netamt,
                            Amount = x.TotalAmount,
                            CreatedOn = x.CreatedOn,
                            billmonth = (wc.ReadingDate.ToString("MMM yyyy")),
                            ReceiptId = x.ReceiptId,


                            TaxPayerId = tp.TaxPayerId,

                            FullName = tp.FirstName + " " + ((tp.MiddleName == null || tp.MiddleName.Trim() == string.Empty) ? string.Empty : (tp.MiddleName + " ")) + ((tp.LastName == null || tp.LastName.Trim() == string.Empty) ? string.Empty : (tp.LastName + " ")),
                            Caddress = tp.CAddress,
                            Cid = tp.Cid,
                            Ttin = tp.Ttin,
                          //  PlotNo = l.PlotNo,
                            TaxName = tx.TaxName,

                            consumerNo = w.ConsumerNo,
                            WaterMeterNO =w.WaterMeterNo,
                            BillingAddress = w.BillingAddress,
                            TransactionTypeId = t.TransactionTypeId,


                        });

            return data.ToList();


        }

        //*****************************************water payment recepit*****************************************
        public IList<LedgerDemandVM> PrintWaterPaymentreceipt(int id)
        {
            var rn = ctx.TblReceipt.Where(d => d.ReceiptId == id).Max(x => x.ReceiptNo);
            var data = (from x in ctx.TblLedger.Where(x => x.ReceiptId == id)
                        join tx in ctx.MstTaxMaster on x.TaxId equals tx.TaxId
                        join t in ctx.TblTransactionDetail on x.TransactionId equals t.TransactionId
                        join ty in ctx.MstTransactionType on t.TransactionTypeId equals ty.TransactionTypeId
                        join tp in ctx.MstTaxPayerProfile on x.TaxPayerId equals tp.TaxPayerId
                        join tt in ctx.EnumTitle on tp.TitleId equals tt.TitleId
                        join l in ctx.MstLandDetail on x.LandDetailId equals l.LandDetailId
                        join w in ctx.TblWaterMeterReading on t.TransactionId equals w.TransactionId
                        let netamt = ctx.TblLedger.Where(l => l.ReceiptId == id).Sum(t => t.TotalAmount)
                        let pnetamt = ctx.TblLedger.Where(l => l.ReceiptId == id).Sum(t => t.PenaltyAmount)
                       
                        let c = (ctx.MstWaterConnection.Where(c => c.WaterConnectionId == w.WaterConnectionId)).Take(1).FirstOrDefault().ConsumerNo
                        let m = (ctx.MstWaterConnection.Where(m => m.WaterConnectionId == w.WaterConnectionId)).Take(1).FirstOrDefault().WaterMeterNo
                        let qr = GenerateQr(rn.ToString())
                        select new LedgerDemandVM
                        {
                            QrImage = qr,
                            
                            Receipt = rn,

                            TotalAmount = netamt,
                            Amount = x.TotalAmount,
                            CreatedOn = x.PaymentDate,
                            billmonth = (w.ReadingDate.ToString("MMM yyyy")),
                            ReceiptId = x.ReceiptId,
                            //TaxPayerId = tp.TaxPayerId,

                            FullName = tt.Title + "" + tp.FirstName + " " + ((tp.MiddleName == null || tp.MiddleName.Trim() == string.Empty) ? string.Empty : (tp.MiddleName + " ")) + ((tp.LastName == null || tp.LastName.Trim() == string.Empty) ? string.Empty : (tp.LastName + " ")),
                            Caddress = tp.CAddress,
                            Cid = tp.Cid,
                            Ttin = tp.Ttin,
                            PlotNo = l.PlotNo,
                            //ThramNo = lo.ThramNo,
                            TaxName = tx.TaxName,

                            consumerNo = c,
                            WaterMeterNO = m,
                            BillingAddress = w.BillingAddress,
                            TransactionTypeId = t.TransactionTypeId,

                            PenaltyAmount = x.PenaltyAmount,
                           TotalPenaltyAmount = pnetamt,
                           PenaltyDays = x.PenaltyPeriod
                        });

            return data.ToList();


        }
        //     ******************************************************************** mulitple names********************************************************************************************************************************************
        public IList<LedgerDemandVM> PrintNames(int id)
        {
                        var data = (from x in ctx.TblLandOwnershipDetail.Where(x => x.LandDetailId == id)
                        join l in ctx.MstLandDetail on x.LandDetailId equals l.LandDetailId
                        join t in ctx.MstTaxPayerProfile on x.TaxPayerId equals t.TaxPayerId
                         where x.IsActive == true && l.IsApportioned == false


                        select new LedgerDemandVM
                        {
                           FirstName = t.FirstName,
                           Cid = t.Cid,
                           Ttin = t.Ttin,
                           PhoneNo = t.MobileNo
                        });

            return data.ToList();
     }
            //********************************Property Payment Receipt ****************************************************** 
            public IList<LedgerDemandVM> PrintPaymentreceipt(int id)
        {
            var rn = ctx.TblReceipt.Where(d => d.ReceiptId == id).Max(x => x.ReceiptNo);

            var data = (from x in ctx.ViewProertyTaxLedger.Where(x => x.ReceiptId == id).OrderBy(x=>x.TaxId).OrderBy(x => x.CalendarYear)

                        let tno = (ctx.TblLandOwnershipDetail.Where(lod => lod.TaxPayerId == x.TaxPayerId && lod.LandDetailId == x.LandDetailId)).Take(1).FirstOrDefault().ThramNo
                        let netamt = ctx.TblLedger.Where(l => l.ReceiptId == id).Sum(t => t.TotalAmount)
                        let netpenamt = ctx.TblLedger.Where(l => l.ReceiptId == id).Sum(t => t.PenaltyAmount)

                        let qr = GenerateQr(rn.ToString())
                        //orderby x.TaxId ascending,x.CalendarYear
                        select new LedgerDemandVM
                        {
                            QrImage = qr,
                            TotalAmount = netamt,
                            TotalPenaltyAmount = netpenamt,
                            GrandTotalAmount = (decimal) x.TotalAmount,
                            //Bank = bb_value.BranchName ?? "",
                            //Paymentmode = pm_value.PaymentMode ?? "",
                            Receipt = rn,
                            CreatedOn = Convert.ToDateTime(x.CreatedOn),
                            ReceiptId = x.ReceiptId,
                            TaxPayerId = x.TaxPayerId,
                            PhoneNo = x.MobileNo,
                            FullName = x.FullName,
                            Caddress = x.Caddress,
                            Cid = x.Cid,
                            Ttin = x.Ttin,
                            PlotNo = x.PlotNo,
                            ThramNo = tno,
                            CalendarYear = x.CalendarYear,
                            TaxName = x.TaxName,
                            PenaltyAmount =(decimal) x.PenaltyAmount,
                            PenaltyDays = x.PenaltyPeriod,
                            LandDetailId = x.LandDetailId,
                            IsApportioned = x.IsApportioned,
                            Address = x.Caddress


                        });

            return data.ToList();

            //var data = (from x in ctx.TblLedger.Where(x => x.ReceiptId == id)
            //                // join r in ctx.TblReceipt on x.ReceiptId equals r.ReceiptId
            //            //join pl in ctx.TblPaymentLeger on x.ReceiptId equals pl.ReceiptId
            //            //join pm in ctx.EnumPaymentMode on pl.PaymentModeId equals pm.PaymentModeId
            //            //into pm_temp
            //            //from pm_value in pm_temp.DefaultIfEmpty() //left join
            //            //join tr in ctx.TblTransactionDetail on x.TransactionId equals tr.TransactionId
            //            //join ty in ctx.MstTransactionType on tr.TransactionTypeId equals ty.TransactionTypeId
            //            //join bb in ctx.MstBankBranch on pl.BankBranchId equals bb.BankBranchId
            //            //into bb_temp from bb_value in bb_temp.DefaultIfEmpty()
            //            join tp in ctx.MstTaxPayerProfile on x.TaxPayerId equals tp.TaxPayerId
            //            join t in ctx.EnumTitle on tp.TitleId equals t.TitleId
            //            //join lo in ctx.TblLandOwnershipDetail on tp.TaxPayerId equals lo.TaxPayerId
            //            join l in ctx.MstLandDetail on x.LandDetailId equals l.LandDetailId
            //            join tx in ctx.MstTaxMaster on x.TaxId equals tx.TaxId
            //           join cy in ctx.MstCalendarYear on x.CalendarYearId equals cy.CalendarYearId
            //            let tno = (ctx.TblLandOwnershipDetail.Where(lod => lod.TaxPayerId == x.TaxPayerId && lod.LandDetailId == x.LandDetailId)).Take(1).FirstOrDefault().ThramNo
            //            let netamt = ctx.TblLedger.Where(l => l.ReceiptId == id).Sum(t => t.TotalAmount)
            //            let netpenamt = ctx.TblLedger.Where(l => l.ReceiptId == id).Sum(t => t.PenaltyAmount)

            //            let qr = GenerateQr(rn.ToString())
            //            select new LedgerDemandVM
            //            {
            //                QrImage = qr,
            //                TotalAmount = netamt,
            //                TotalPenaltyAmount = netpenamt,
            //                GrandTotalAmount = x.TotalAmount,
            //                //Bank = bb_value.BranchName ?? "",
            //                //Paymentmode = pm_value.PaymentMode ?? "",
            //                Receipt = rn,
            //                CreatedOn = x.CreatedOn,
            //                ReceiptId = x.ReceiptId,
            //                TaxPayerId = tp.TaxPayerId,
            //                PhoneNo = tp.MobileNo,
            //                FullName = t.Title + "" + tp.FirstName + " " + ((tp.MiddleName == null || tp.MiddleName.Trim() == string.Empty) ? string.Empty : (tp.MiddleName + " ")) + ((tp.LastName == null || tp.LastName.Trim() == string.Empty) ? string.Empty : (tp.LastName + " ")),
            //                Caddress = tp.CAddress,
            //                Cid = tp.Cid,
            //                Ttin = tp.Ttin,
            //                PlotNo = l.PlotNo,
            //                ThramNo = tno,
            //                CalendarYear = cy.CalendarYear,
            //                TaxName = tx.TaxName,
            //                PenaltyAmount = x.PenaltyAmount,
            //                PenaltyDays = x.PenaltyPeriod

            //            }) ;

            //return data.Distinct().ToList();


        }
        //@***********************************************************Miscellauenous Payment Recepit**********************************************************@
        public IList<LedgerDemandVM> PrintMiscellauenousreceipt(int id)
        {
            var rn = ctx.TblReceipt.Where(d => d.ReceiptId == id).Max(x => x.ReceiptNo);

            var data = (from x in ctx.TblLedger.Where(x => x.ReceiptId == id)
                        join pl in ctx.TblPaymentLeger on x.ReceiptId equals pl.ReceiptId
                        join pm in ctx.EnumPaymentMode on pl.PaymentModeId equals pm.PaymentModeId
                        into pm_temp
                        from pm_value in pm_temp.DefaultIfEmpty() //left join
                        join tr in ctx.TblTransactionDetail on x.TransactionId equals tr.TransactionId
                        //join ty in ctx.MstTransactionType on tr.TransactionTypeId equals ty.TransactionTypeId
                        join bb in ctx.MstBankBranch on pl.BankBranchId equals bb.BankBranchId
                        into bb_temp
                        from bb_value in bb_temp.DefaultIfEmpty()
                        join tx in ctx.MstTaxMaster on x.TaxId equals tx.TaxId
                        join m in ctx.TblMiscellaneousRecord on tr.TransactionId equals m.TransactionId
                        join s in ctx.MstSlab on m.SlabId equals s.SlabId
                        let qr = GenerateQr(rn.ToString())
                        select new LedgerDemandVM
                        {
                            QrImage = qr,
                            TotalAmount = x.TotalAmount,

                            GrandTotalAmount = pl.Amount,
                            Bank = bb_value.BranchName ?? "",
                            Paymentmode = pm_value.PaymentMode ?? "",
                            Receipt = rn,
                            CreatedOn = pl.CreatedOn,
                            ReceiptId = x.ReceiptId,

                            FullName = m.Name,
                            PhoneNo = m.MobileNo,
                            Caddress = m.Address,
                            Cid = m.Cid,
                            Slab = s.SlabName,

                            TaxName = tx.TaxName,
                            TransactionTypeId = tr.TransactionTypeId,
                            //TransactionType = ty.TransactionType
                        });

            return data.Distinct().ToList();


        }
        //@***********************************************************House Payment Recepit**********************************************************@
        public IList<LedgerDemandVM> PrintHousereceipt(int id)
        {
            var rn = ctx.TblReceipt.Where(d => d.ReceiptId == id).Max(x => x.ReceiptNo);

            var data = (from x in ctx.TblLedger.Where(x => x.ReceiptId == id)
                        
                        
                        join tr in ctx.TblTransactionDetail on x.TransactionId equals tr.TransactionId
                        
                        join tp in ctx.MstTaxPayerProfile on x.TaxPayerId equals tp.TaxPayerId
                        join t in ctx.EnumTitle on tp.TitleId equals t.TitleId
                        
                        join c in ctx.TblHouseRentDemandDetail on x.HouseRentDemandDetailId equals c.HouseRentDemandDetailId
                        join b in ctx.TblHouseAllocation on c.HouseAllocationId equals b.HouseAllocationId
                        join e in ctx.TblHouseDetail on b.HouseDetailId equals e.HouseDetailId
                        join f in ctx.EnumBillingSchedule on b.BillingScheduleId equals f.BillingScheduleId 
                        join en in ctx.EnumDemandGenerateSchedule on c.DemandGenerateScheduleId equals en.DemandGenerateScheduleId 
                        join tx in ctx.MstTaxMaster on x.TaxId equals tx.TaxId
                        let qr = GenerateQr(rn.ToString())
                        
                        let netamt = ctx.TblLedger.Where(l => l.ReceiptId == id).Sum(t => t.TotalAmount)
                        let netpenamt = ctx.TblLedger.Where(l => l.ReceiptId == id).Sum(t => t.PenaltyAmount)
                        select new LedgerDemandVM
                        {
                            QrImage = qr,
                           

                          
                            //Bank = bb_value.BranchName ?? "",
                            //Paymentmode = pm_value.PaymentMode ?? "",
                            Receipt = rn,
                            CreatedOn = x.CreatedOn,
                            ReceiptId = x.ReceiptId,
                            PhoneNo = tp.MobileNo,

                            FullName = t.Title + "" + tp.FirstName + " " + ((tp.MiddleName == null || tp.MiddleName.Trim() == string.Empty) ? string.Empty : (tp.MiddleName + " ")) + ((tp.LastName == null || tp.LastName.Trim() == string.Empty) ? string.Empty : (tp.LastName + " ")),
                            Caddress = tp.CAddress,
                            Cid = tp.Cid,
                            Ttin = tp.Ttin,
                            //PlotNo = l.PlotNo,
                            //ThramNo = tno,
                            TaxName = tx.TaxName,

                            Address = e.HouseAddress,
                            //InstallmentAmount = b.RentalAmount,
                            BillingSchedule = f.BillingSchedule,
                            HouseNo = e.HouseNo,
                            Amount = x.TotalAmount,
                            TotalAmount = netamt,
                            TotalPenaltyAmount = netpenamt,
                            PenaltyDays = x.PenaltyPeriod,
                            PenaltyAmount = x.PenaltyAmount,
                            Month = en.DemandGenerateSchedule
                            


                        });

            return data.Distinct().ToList();


        }
        //@***********************************************************Stall Payment Recepit**********************************************************@
        public IList<LedgerDemandVM> Printstallreceipt(int id)
        {
            var rn = ctx.TblReceipt.Where(d => d.ReceiptId == id).Max(x => x.ReceiptNo);

            var data = (from x in ctx.TblLedger.Where(x => x.ReceiptId == id)
                       
                        join tp in ctx.MstTaxPayerProfile on x.TaxPayerId equals tp.TaxPayerId
                        join t in ctx.EnumTitle on tp.TitleId equals t.TitleId
                      
                        join c in ctx.TblStallDetailDemand on x.StallDemandDetailId equals c.StallDemandDetailId
                        join b in ctx.TblStallAllocation on c.StallAllocationId equals b.StallAllocationId
                        join e in ctx.TblStallDetail on b.StallDetailId equals e.StallDetailId
                        join f in ctx.EnumBillingSchedule on b.BillingScheduleId equals f.BillingScheduleId

                        join en in ctx.EnumDemandGenerateSchedule on c.DemandGenerateScheduleId equals en.DemandGenerateScheduleId
                        
                        join tx in ctx.MstTaxMaster on x.TaxId equals tx.TaxId
                        let qr = GenerateQr(rn.ToString())
                        let netamt = ctx.TblLedger.Where(l => l.ReceiptId == id).Sum(t => t.TotalAmount)
                        let netpenamt = ctx.TblLedger.Where(l => l.ReceiptId == id).Sum(t => t.PenaltyAmount)
                        select new LedgerDemandVM
                        {
                            QrImage = qr,
                           
                            Receipt = rn,
                            CreatedOn = x.CreatedOn,
                            ReceiptId = x.ReceiptId,
                            TaxPayerId = tp.TaxPayerId,
                            PhoneNo = tp.MobileNo,
                            FullName = t.Title + "" + tp.FirstName + " " + ((tp.MiddleName == null || tp.MiddleName.Trim() == string.Empty) ? string.Empty : (tp.MiddleName + " ")) + ((tp.LastName == null || tp.LastName.Trim() == string.Empty) ? string.Empty : (tp.LastName + " ")),
                            Caddress = tp.CAddress,
                            Cid = tp.Cid,
                            Ttin = tp.Ttin,
                            
                            TaxName = tx.TaxName,

                            Address = e.StallName,
                            StallNo = e.StallNo,
                            //InstallmentAmount = b.RentalAmount,
                            BillingSchedule = f.BillingSchedule,
                             Amount = x.TotalAmount,
                            TotalAmount = netamt,
                            TotalPenaltyAmount = netpenamt,
                            PenaltyDays = x.PenaltyPeriod,
                            PenaltyAmount = x.PenaltyAmount,
                             Month = en.DemandGenerateSchedule

                        });

            return data.Distinct().ToList();


        }
//@***********************************************************LandLease Payment Recepit**********************************************************@
        public IList<LedgerDemandVM> PrintLandLeasereceipt(int id)
        {
            var rn = ctx.TblReceipt.Where(d => d.ReceiptId == id).Max(x => x.ReceiptNo);

            var data = (from x in ctx.TblLedger.Where(x => x.ReceiptId == id)
                       
                        join tp in ctx.MstTaxPayerProfile on x.TaxPayerId equals tp.TaxPayerId
                        join t in ctx.EnumTitle on tp.TitleId equals t.TitleId
                     
                        join e in ctx.TblLandLeaseDemandDetail on x.LandLeaseDemandDetailId equals e.LandLeaseDemandDetailId
                        join b in ctx.TblLandLease on e.LandLeaseId equals b.LandLeaseId
                        join c in ctx.EnumLeaseType on b.LeaseTypeId equals c.LeaseTypeId
                        join f in ctx.EnumBillingSchedule on b.BillingScheduleId equals f.BillingScheduleId
                        join tx in ctx.MstTaxMaster on x.TaxId equals tx.TaxId
                        join en in ctx.EnumDemandGenerateSchedule on e.DemandGenerateScheduleId equals en.DemandGenerateScheduleId
                        
                        let qr = GenerateQr(rn.ToString())
                        let netamt = ctx.TblLedger.Where(l => l.ReceiptId == id).Sum(t => t.TotalAmount)
                        let netpenamt = ctx.TblLedger.Where(l => l.ReceiptId == id).Sum(t => t.PenaltyAmount)
                        select new LedgerDemandVM
                        {
                            QrImage = qr,
                            Receipt = rn,
                            CreatedOn = x.CreatedOn,
                            ReceiptId = x.ReceiptId,
                            TaxPayerId = tp.TaxPayerId,
                            PhoneNo = tp.MobileNo,
                            FullName = t.Title + "" + tp.FirstName + " " + ((tp.MiddleName == null || tp.MiddleName.Trim() == string.Empty) ? string.Empty : (tp.MiddleName + " ")) + ((tp.LastName == null || tp.LastName.Trim() == string.Empty) ? string.Empty : (tp.LastName + " ")),
                            Caddress = c.LeaseType,
                            Cid = tp.Cid,
                            Ttin = tp.Ttin,
                           
                            TaxName = tx.TaxName,

                            Address = tp.CAddress,
                            //InstallmentAmount = b.LeaseAmount,
                            BillingSchedule = f.BillingSchedule,
                            BillingScheduleId = b.BillingScheduleId,
                            Amount = x.TotalAmount,
                            TotalAmount = netamt,
                            TotalPenaltyAmount = netpenamt,
                            PenaltyDays = x.PenaltyPeriod,
                            PenaltyAmount = x.PenaltyAmount,
                            Month = en.DemandGenerateSchedule + "" + e.DemandYear,
                            DemandYear = e.DemandYear


                        });

            return data.Distinct().ToList();


        }
        //@***********************************************************ParkingFee Payment Recepit**********************************************************@
        public IList<LedgerDemandVM> PrintParkingFeereceipt(int id)
        {
            var rn = ctx.TblReceipt.Where(d => d.ReceiptId == id).Max(x => x.ReceiptNo);

            var data = (from x in ctx.TblLedger.Where(x => x.ReceiptId == id)
                        
                        join tp in ctx.MstTaxPayerProfile on x.TaxPayerId equals tp.TaxPayerId
                        join t in ctx.EnumTitle on tp.TitleId equals t.TitleId
                       
                        join pd in ctx.TblParkingFeeDemandDetail on x.ParkingDemandDetailId equals pd.ParkingDemandDetailId
                        join p in ctx.TblParkingfeeDetail on pd.ParkingFeeDetailId equals p.ParkingFeeDetailId
                        join z in ctx.MstParkingZone on p.ParkingZoneId equals z.ParkingZoneId
                        join bs in ctx.EnumBillingSchedule on p.BillingScheduleId equals bs.BillingScheduleId
                        join en in ctx.EnumDemandGenerateSchedule on pd.DemandGenerateScheduleId equals en.DemandGenerateScheduleId
                      
                        join tx in ctx.MstTaxMaster on x.TaxId equals tx.TaxId
                        let qr = GenerateQr(rn.ToString())
                        let netamt = ctx.TblLedger.Where(l => l.ReceiptId == id).Sum(t => t.TotalAmount)
                        let netpenamt = ctx.TblLedger.Where(l => l.ReceiptId == id).Sum(t => t.PenaltyAmount)
                        select new LedgerDemandVM
                        {
                            QrImage = qr,
                            Receipt = rn,
                            CreatedOn = x.CreatedOn,
                            ReceiptId = x.ReceiptId,
                            TaxPayerId = tp.TaxPayerId,
                            PhoneNo = tp.MobileNo,
                            FullName = t.Title + "" + tp.FirstName + " " + ((tp.MiddleName == null || tp.MiddleName.Trim() == string.Empty) ? string.Empty : (tp.MiddleName + " ")) + ((tp.LastName == null || tp.LastName.Trim() == string.Empty) ? string.Empty : (tp.LastName + " ")),
                            Caddress = tp.CAddress,
                            Cid = tp.Cid,
                            Ttin = tp.Ttin,
                           
                            TaxName = tx.TaxName,

                            Address = z.ParkingzoneName,
                            //InstallmentAmount = p.InstallmentAmount,
                            BillingSchedule = bs.BillingSchedule,
                            Amount = x.TotalAmount,
                            TotalAmount = netamt,
                            TotalPenaltyAmount = netpenamt,
                            PenaltyDays = x.PenaltyPeriod,
                            PenaltyAmount = x.PenaltyAmount,
                             Month = en.DemandGenerateSchedule
                        });

            return data.Distinct().ToList();


        }
        //Duplicate Recepit Print


        //Water

        //Search water recepit by consumer no
        public IList<LedgerDemandVM> PrintDuplicatePaymentModes(long RecepitId)
        {
            var data = (from x in ctx.TblPaymentLeger.Where(x => x.ReceiptId == RecepitId)
                        join pm in ctx.EnumPaymentMode on x.PaymentModeId equals pm.PaymentModeId
                        into pm_temp
                        from pm_value in pm_temp.DefaultIfEmpty()
                        join bb in ctx.MstBankBranch on x.BankBranchId equals bb.BankBranchId
                        into bb_temp
                        from bb_value in bb_temp.DefaultIfEmpty()
                        join bfs in ctx.TblBfsTransactiondetails on x.BfsTransactionDetailId equals bfs.BfsTransactionDetailId
                        into bfs_temp
                        from bfs_value in bfs_temp.DefaultIfEmpty()
                        let netamt = ctx.TblLedger.Where(l => l.ReceiptId == RecepitId).Sum(t => t.TotalAmount)
                        let pa = ctx.TblLedger.Where(l => l.ReceiptId == RecepitId).Sum(t => t.PenaltyAmount)
                        let pd = ctx.TblLedger.Where(l => l.ReceiptId == RecepitId).Max(t => t.PenaltyPeriod)
                        select new LedgerDemandVM
                        {
                            Paymentmode = pm_value.PaymentMode ?? "0",
                            PaymentModeNo = (x.PaymentModeNo == null ? "0" : x.PaymentModeNo),
                            PaymentModeDate = (DateTime)x.PaymentModeDate,
                            ReceiptId = x.ReceiptId,
                            TotalAmount = netamt,
                            PenaltyAmount = pa,
                            PenaltyDays = pd,
                            Amount = x.Amount,
                            Bank = (bb_value.BranchName == null ? bfs_value.BfsBankName : bb_value.BranchName),
                            CreatedOn = x.CreatedOn,
                        });

            return data.ToList();
        }
        public IList<TranWaterConnectionModel> fetchWaterDetails(string ConsumerNo, int Year,int TransactionTypeId)
        {
            try
            {
                //var Demand = (
                //   from x in ctx.TblTransactionDetail.Where(x => x.TransactionTypeId == TransactionTypeId)
                //   join y in ctx.MstTransactionType on x.TransactionTypeId equals y.TransactionTypeId
                //   select x.TransactionId).ToList();

                var data = (from a in ctx.MstWaterConnection.Where(a => a.ConsumerNo == ConsumerNo)
                            join rd in ctx.TblWaterMeterReading on a.WaterConnectionId equals rd.WaterConnectionId
                            join t in ctx.TblTransactionDetail on rd.TransactionId equals t.TransactionId
                            join c in ctx.TblLedger on t.TransactionId equals c.TransactionId

                            join tx in ctx.MstTaxMaster on c.TaxId equals tx.TaxId

                            //  join b in ctx.TblLandOwnershipDetail on a.LandOwnershipId equals b.LandOwnershipId
                            // join t in ctx.MstTaxPayerProfile on b.TaxPayerId equals t.TaxPayerId
                            //  join tt in ctx.EnumTitle on t.TitleId equals tt.TitleId
                            //join tr in ctx.TblTransactionDetail on  b.TransactionId equals tr.TransactionId
                            //  join l in ctx.TblLedger on c.DemandId equals l.DemandId
                            //join r in ctx.TblReceipt on c.ReceiptId equals r.ReceiptId
                            where (c.PaymentDate.Year == Year 
                            //&& Demand.Contains(c.TransactionId)
                            )
                            orderby rd.ReadingDate.Year, rd.ReadingDate.Month

                            select new TranWaterConnectionModel
                            {
                                RecepitId = c.ReceiptId,
                                RMonth = rd.ReadingDate.Month,
                               
                                BillingAddress = a.BillingAddress,
                                // demandamount = c.TotalAmount,
                                Totalamount = c.TotalAmount,
                                //ThramNo = b.ThramNo,


                                //FirstName = tt.Title + "" + t.FirstName + " " + ((t.MiddleName == null || t.MiddleName.Trim() == string.Empty) ? string.Empty : (t.MiddleName + " ")) + ((t.LastName == null || t.LastName.Trim() == string.Empty) ? string.Empty : (t.LastName + " ")),

                                //CAddress = t.CAddress,
                                //PhoneNo = t.PhoneNo,
                                //Fax = t.Fax,
                                ConsumerNo = a.ConsumerNo,
                                WaterMeterNo = a.WaterMeterNo,
                                Year = rd.ReadingDate.Year,
                                billmonth = rd.ReadingDate.ToString("MMM yyyy"),

                                //RecepitId = c.ReceiptId





                            });
                return data.ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //*************************************************water tax*********************************************
        public IList<LedgerDemandVM> fetchwatertax(long RecepitId)
        {
            var rn = ctx.TblReceipt.Where(l => l.ReceiptId == RecepitId).Max(x => x.ReceiptNo);

            //var DataL =(from x in ctx.TblLedger.Where(l => l.ReceiptId == RecepitId)
            //             join d in ctx.TblDemand on  x.DemandId equals d.DemandId
            //            join w in ctx.TblWaterMeterReading on d.WaterMeterReadingId equals w.WaterMeterReadingId
            //            select new LedgerDemandVM
            //            {
            //                billmonth = w.ReadingDate.ToString("MMM yyyy"),
            //            }
            //    );
            //var iTransctionid = DataL.FirstOrDefault().TransactionId;
            //var tr = ctx.TblDemand.Where(d => d.TransactionId == iTransctionid).Max(x => x.WaterMeterReadingId);

            var data = (from a in ctx.TblLedger.Where(a => a.ReceiptId == RecepitId)
                            //  join w in ctx.MstWaterConnection on a.TransactionId equals w.TransactionId
                            //join dn in ctx.TblDemand on a.TransactionId equals dn.TransactionId 
                            // join d in ctx.TblDemandNo on dn.DemandNoId equals d.DemandNoId
                        join t in ctx.MstTaxMaster on a.TaxId equals t.TaxId
                        join r in ctx.TblReceipt on a.ReceiptId equals r.ReceiptId
                        join tp in ctx.MstTaxPayerProfile on a.TaxPayerId equals tp.TaxPayerId
                        join tt in ctx.EnumTitle on tp.TitleId equals tt.TitleId
                        join d in ctx.TblDemand on a.DemandId equals d.DemandId
                        
                        join w in ctx.TblWaterMeterReading on d.WaterMeterReadingId equals w.WaterMeterReadingId
                        join wc in ctx.MstWaterConnection on w.WaterConnectionId equals wc.WaterConnectionId
                        //join b in ctx.TblLandOwnershipDetail on tp.TaxPayerId equals b.TaxPayerId
                        //join la in ctx.MstLandDetail on b.LandDetailId equals la.LandDetailId
                        let netamt = ctx.TblLedger.Where(l => l.ReceiptId == RecepitId).Sum(t => t.TotalAmount)
                        let pamt = ctx.TblLedger.Where(l => l.ReceiptId == RecepitId).Sum(t => t.PenaltyAmount)

                        //let rd = (ctx.TblWaterMeterReading.Where(lod => lod.WaterMeterReadingId == tr)).Take(1).FirstOrDefault().ReadingDate
                        let qr = GenerateQr(rn.ToString())
                        select new LedgerDemandVM
                        {
                            QrImage = qr,
                            NetAmount = netamt,
                            // consumerNo = w.ConsumerNo,
                            //WaterMeterNO = w.WaterMeterNo,
                            //DemandNo = d.DemandNo,
                            Receipt = r.ReceiptNo,
                            TaxName = t.TaxName,

                            TotalAmount = a.TotalAmount,
                            CreatedOn = r.CreatedOn,
                            billmonth = w.ReadingDate.ToString("MMM yyyy"),

                            //ThramNo = b.ThramNo,


                            FirstName = tt.Title + "" + tp.FirstName + " " + ((tp.MiddleName == null || tp.MiddleName.Trim() == string.Empty) ? string.Empty : (tp.MiddleName + " ")) + ((tp.LastName == null || tp.LastName.Trim() == string.Empty) ? string.Empty : (tp.LastName + " ")),

                            Caddress = tp.CAddress,
                            PhoneNo = tp.PhoneNo,
                            PenaltyDays = a.PenaltyPeriod,
                            PenaltyAmount = a.PenaltyAmount,
                            TotalPenaltyAmount = pamt,
                            consumerNo = wc.ConsumerNo,
                            WaterMeterNO = wc.WaterMeterNo


                        });
            return data.ToList();
        }

        public IList<LedgerDemandVM> Watercharges(long RecepitId)
        {
            try
            {
                var rn = ctx.TblReceipt.Where(l => l.ReceiptId == RecepitId).Max(x => x.ReceiptNo);


                var data = (from a in ctx.TblLedger.Where(a => a.ReceiptId == RecepitId)
                            join t in ctx.MstTaxMaster on a.TaxId equals t.TaxId
                            join r in ctx.TblReceipt on a.ReceiptId equals r.ReceiptId
                            join tp in ctx.MstTaxPayerProfile on a.TaxPayerId equals tp.TaxPayerId
                            join tt in ctx.EnumTitle on tp.TitleId equals tt.TitleId
                            join d in ctx.TblDemand on a.DemandId equals d.DemandId
                            join w in ctx.TblWaterMeterReading on d.WaterMeterReadingId equals w.WaterMeterReadingId
                            let netamt = ctx.TblLedger.Where(l => l.ReceiptId == RecepitId).Sum(t => t.TotalAmount)
                            let pamt = ctx.TblLedger.Where(l => l.ReceiptId == RecepitId).Sum(t => t.PenaltyAmount)

                            //let rd = (ctx.TblWaterMeterReading.Where(lod => lod.WaterMeterReadingId == tr)).Take(1).FirstOrDefault().ReadingDate
                            let qr = GenerateQr(rn.ToString())

                            select new LedgerDemandVM
                            {
                                TransactionId = a.TransactionId,
                                QrImage = qr,
                                NetAmount = netamt,
                                Receipt = r.ReceiptNo,
                                TaxName = t.TaxName,
                                TotalAmount = a.TotalAmount,
                                CreatedOn = a.PaymentDate,
                                billmonth = (w.ReadingDate.ToString("MMM yyyy")),
                                //ThramNo = b.ThramNo,
                                FirstName = tt.Title + "" + tp.FirstName + " " + ((tp.MiddleName == null || tp.MiddleName.Trim() == string.Empty) ? string.Empty : (tp.MiddleName + " ")) + ((tp.LastName == null || tp.LastName.Trim() == string.Empty) ? string.Empty : (tp.LastName + " ")),
                                Caddress = tp.CAddress,
                                PhoneNo = tp.PhoneNo,
                                PenaltyDays = a.PenaltyPeriod,
                                PenaltyAmount = a.PenaltyAmount,
                                TotalPenaltyAmount = pamt
                            });
                return data.ToList();
            }
            catch(Exception ex)
            {
                return null;
            }
        }
        public IList<LedgerDemandVM> fetchledgerdata(long RecepitId)
        {
            var rn = ctx.TblReceipt.Where(l=>l.ReceiptId==RecepitId).Max(x => x.ReceiptNo);

            //var DataL =(from x in ctx.TblLedger.Where(l => l.ReceiptId == RecepitId)
            //             join d in ctx.TblDemand on  x.DemandId equals d.DemandId
            //            join w in ctx.TblWaterMeterReading on d.WaterMeterReadingId equals w.WaterMeterReadingId
            //            select new LedgerDemandVM
            //            {
            //                billmonth = w.ReadingDate.ToString("MMM yyyy"),
            //            }
            //    );
            //var iTransctionid = DataL.FirstOrDefault().TransactionId;
            //var tr = ctx.TblDemand.Where(d => d.TransactionId == iTransctionid).Max(x => x.WaterMeterReadingId);

            var data = (from a in ctx.TblLedger.Where(a => a.ReceiptId == RecepitId)
                        //  join w in ctx.MstWaterConnection on a.TransactionId equals w.TransactionId
                       //join dn in ctx.TblDemand on a.TransactionId equals dn.TransactionId 
                       // join d in ctx.TblDemandNo on dn.DemandNoId equals d.DemandNoId
                        join t in ctx.MstTaxMaster on a.TaxId equals t.TaxId
                        join r in ctx.TblReceipt on a.ReceiptId equals r.ReceiptId
                        join tp in ctx.MstTaxPayerProfile on a.TaxPayerId equals tp.TaxPayerId
                         join tt in ctx.EnumTitle on tp.TitleId equals tt.TitleId
                        join d in ctx.TblDemand on a.DemandId equals d.DemandId
                        join td in ctx.TblTransactionDetail on a.TransactionId equals td.TransactionId
                        join wc in ctx.MstWaterConnection on a.LandDetailId equals wc.LandDetailId
                        join w in ctx.TblWaterMeterReading on wc.WaterConnectionId equals w.WaterConnectionId

                        //join b in ctx.TblLandOwnershipDetail on tp.TaxPayerId equals b.TaxPayerId
                        //join la in ctx.MstLandDetail on b.LandDetailId equals la.LandDetailId
                        let netamt = ctx.TblLedger.Where(l => l.ReceiptId == RecepitId).Sum(t => t.TotalAmount)
                        let pamt = ctx.TblLedger.Where(l => l.ReceiptId == RecepitId).Sum(t => t.PenaltyAmount)
                       
                        //let rd = (ctx.TblWaterMeterReading.Where(lod => lod.WaterMeterReadingId == tr)).Take(1).FirstOrDefault().ReadingDate
                        let qr = GenerateQr(rn.ToString())
                        select new LedgerDemandVM
                        {
                            QrImage = qr,
                            NetAmount = netamt,
                            // consumerNo = w.ConsumerNo,
                            //WaterMeterNO = w.WaterMeterNo,
                            //DemandNo = d.DemandNo,
                            Receipt = r.ReceiptNo,
                            TaxName = t.TaxName,
                            
                            TotalAmount = a.TotalAmount,
                            CreatedOn = r.CreatedOn,
                            billmonth = w.ReadingDate.ToString("MMM yyyy"),

                            //ThramNo = b.ThramNo,


                            FirstName = tt.Title + "" + tp.FirstName + " " + ((tp.MiddleName == null || tp.MiddleName.Trim() == string.Empty) ? string.Empty : (tp.MiddleName + " ")) + ((tp.LastName == null || tp.LastName.Trim() == string.Empty) ? string.Empty : (tp.LastName + " ")),

                            Caddress = tp.CAddress,
                           PhoneNo = tp.PhoneNo,
                           PenaltyDays = a.PenaltyPeriod,
                           PenaltyAmount = a.PenaltyAmount,
                           TotalPenaltyAmount = pamt,
                           consumerNo = wc.ConsumerNo,
                           WaterMeterNO = wc.WaterMeterNo


                        }).Take(1);
            return data.ToList();
        }


        public List<LedgerDemandVM> fetchWatershifting(long RecepitId)
        {
            var rn = ctx.TblReceipt.Where(l => l.ReceiptId == RecepitId).Max(x => x.ReceiptNo);

            var data = (from a in ctx.TblLedger.Where(a => a.ReceiptId == RecepitId)
                      
                        join t in ctx.MstTaxMaster on a.TaxId equals t.TaxId
                        join r in ctx.TblReceipt on a.ReceiptId equals r.ReceiptId
                        join tp in ctx.MstTaxPayerProfile on a.TaxPayerId equals tp.TaxPayerId
                        join tt in ctx.EnumTitle on tp.TitleId equals tt.TitleId
                        join d in ctx.TblDemand on a.DemandId equals d.DemandId
                        join td in ctx.TblTransactionDetail on a.TransactionId equals td.TransactionId
                       
                       // join wc in ctx.MstWaterConnection on a.LandDetailId equals wc.LandDetailId
                        //join b in ctx.TblLandOwnershipDetail on tp.TaxPayerId equals b.TaxPayerId
                        //join la in ctx.MstLandDetail on b.LandDetailId equals la.LandDetailId
                        let netamt = ctx.TblLedger.Where(l => l.ReceiptId == RecepitId).Sum(t => t.TotalAmount)
                        let pamt = ctx.TblLedger.Where(l => l.ReceiptId == RecepitId).Sum(t => t.PenaltyAmount)
                        let consumerNo = (ctx.MstWaterConnection.Where(lod => lod.LandDetailId == a.LandDetailId && lod.IsActive == true)).Take(1).FirstOrDefault().ConsumerNo
                        let WaterMeterNo = (ctx.MstWaterConnection.Where(lod => lod.LandDetailId == a.LandDetailId && lod.IsActive == true)).Take(1).FirstOrDefault().WaterMeterNo
                        let BillingAddress = (ctx.MstWaterConnection.Where(lod => lod.LandDetailId == a.LandDetailId && lod.IsActive == true)).Take(1).FirstOrDefault().BillingAddress
                        //let rd = (ctx.TblWaterMeterReading.Where(lod => lod.WaterMeterReadingId == tr)).Take(1).FirstOrDefault().ReadingDate
                        let qr = GenerateQr(rn.ToString())
                        select new LedgerDemandVM
                        {
                            QrImage = qr,
                            NetAmount = netamt,
                           
                            Receipt = r.ReceiptNo,
                            TaxName = t.TaxName,

                            TotalAmount = a.TotalAmount,
                            CreatedOn = r.CreatedOn,
                        

                            FirstName = tt.Title + "" + tp.FirstName + " " + ((tp.MiddleName == null || tp.MiddleName.Trim() == string.Empty) ? string.Empty : (tp.MiddleName + " ")) + ((tp.LastName == null || tp.LastName.Trim() == string.Empty) ? string.Empty : (tp.LastName + " ")),

                            Caddress = tp.CAddress,
                            PhoneNo = tp.PhoneNo,
                            PenaltyDays = a.PenaltyPeriod,
                            PenaltyAmount = a.PenaltyAmount,
                            TotalPenaltyAmount = pamt,
                            consumerNo = consumerNo,
                            WaterMeterNO = WaterMeterNo


                        });
            return data.ToList();
        }

        //*******************************Miscellaneous*********************************
        public IList<MiscellaneousRecordModel> fetchMiscellaneousdata(string Cid)
        {

            var data = (from x in ctx.TblMiscellaneousRecord.Where(x => x.Cid == Cid)
                        join y in ctx.TblLedger on x.MiscellaneousRecordId equals y.MiscellaneousRecordId
                        join z in ctx.MstTaxMaster on x.TaxId equals z.TaxId
                        join a in ctx.MstSlab on x.SlabId equals a.SlabId
                        join b in ctx.MstRate on a.SlabId equals b.SlabId
                        select new MiscellaneousRecordModel
                        {
                            MiscellaneousRecordId = x.MiscellaneousRecordId,
                            RecepitId = y.ReceiptId,
                            TaxId = x.TaxId,
                            SlabId = x.SlabId,
                            Name = x.Name,
                            Address = x.Address,
                            Cid = x.Cid,
                            MobileNo = x.MobileNo,
                            Quantity = x.Quantity,
                            Amount = x.Amount,
                            PaymentStatus = x.PaymentStatus,


                            //Transaction = y.Transaction,
                            Tax = z.TaxName,
                            Slab = a.SlabName,
                            Rate = b.Rate
                        });
            return data.ToList();
        }

        public IList<LedgerDemandVM> PrintDemand(long RecepitId)
        {
            var rn = ctx.TblReceipt.Where(l => l.ReceiptId == RecepitId).Max(x => x.ReceiptNo);

            var data = (from a in ctx.TblLedger.Where(a => a.ReceiptId == RecepitId)
                            //  join w in ctx.MstWaterConnection on a.TransactionId equals w.TransactionId
                        join m in ctx.TblMiscellaneousRecord on a.TransactionId equals m.TransactionId
                        join s in ctx.MstSlab on m.SlabId equals s.SlabId
                        join ra in ctx.MstRate on s.SlabId  equals ra.SlabId 
                        into q_temp
                        from q_value in q_temp.DefaultIfEmpty()
                        join dn in ctx.TblDemand on a.TransactionId equals dn.TransactionId
                        join d in ctx.TblDemandNo on dn.DemandNoId equals d.DemandNoId

                        join t in ctx.MstTaxMaster on a.TaxId equals t.TaxId
                        join r in ctx.TblReceipt on a.ReceiptId equals r.ReceiptId
                        let netamt = ctx.TblLedger.Where(l => l.ReceiptId == RecepitId).Sum(t => t.TotalAmount)
                        let qr = GenerateQr(rn.ToString())
                        select new LedgerDemandVM
                        {
                            QrImage = qr,
                            NetAmount = netamt,
                            // consumerNo = w.ConsumerNo,
                            //WaterMeterNO = w.WaterMeterNo,
                            DemandNo = d.DemandNo,
                            Receipt = r.ReceiptNo,
                            TaxName = t.TaxName,
                            DemandAmount = dn.DemandAmount,
                            TotalAmount = dn.TotalAmount,
                            CreatedOn = r.CreatedOn,
                            
                            Slab = s.SlabName,
                            Rate = q_value.Rate,
                            Quantity = m.Quantity,
                            Amount = m.Amount,

                            UserName  = m.Name,
                           PhoneNo = m.MobileNo,
                           Address = m.Address,
                           Cid = m.Cid,



                        });
            return data.ToList();
        }


        //*******************************Property Tax*********************************

        public IList<LandOwneshipModel> FetchlanddetailsByCID(string Cid, string Ttin, string Year)
        {
            var data = (from a in ctx.MstTaxPayerProfile.Where(x => x.Cid == Cid || x.Ttin == Ttin)
                        join b in ctx.EnumTitle on a.TitleId equals b.TitleId
                        join td in ctx.TblDemand on a.TaxPayerId equals td.TaxPayerId
                        join t in ctx.TblTransactionDetail on td.TransactionId equals t.TransactionId
                        //join ty in ctx.MstTransactionType on t.TransactionTypeId equals ty.TransactionTypeId
                        join cl in ctx.MstCalendarYear on td.CalendarYearId equals cl.CalendarYearId
                        join tt in ctx.EnumTaxPayerType on a.TaxPayerTypeId equals tt.TaxPayerTypeId
                        join l in ctx.TblLedger on td.DemandId equals l.DemandId
                        join c in ctx.TblLandOwnershipDetail on l.LandOwnershipId equals c.LandOwnershipId
                        join lot in ctx.EnumLandOwnershipType on c.LandOwnershipTypeId equals lot.LandOwnershipTypeId
                        join d in ctx.MstLandDetail on c.LandDetailId equals d.LandDetailId
                        join lt in ctx.MstLandType on d.LandTypeId equals lt.LandTypeId
                        where (cl.CalendarYear == Year && t.TransactionTypeId == 20)
                        select new LandOwneshipModel
                        {
                            CalendarYearId= cl.CalendarYearId,
                            Cid = a.Cid,
                            Ttin = a.Ttin,
                            FullName = b.Title + "" + a.FirstName + " " + ((a.MiddleName == null || a.MiddleName.Trim() == string.Empty) ? string.Empty : (a.MiddleName + " ")) + ((a.LastName == null || a.LastName.Trim() == string.Empty) ? string.Empty : (a.LastName + " ")),
                          
                            TaxPayerType = tt.TaxPayerType,
                            MobileNo = a.MobileNo,
                            Email = a.Email,
                            CAddress = a.CAddress,
                            ThramNo = c.ThramNo,
                            PlotNo = d.PlotNo,
                            LandOwnershipType = lot.LandOwnershipType,
                            LandTypeName = lt.LandTypeName,
                            LandAcerage = d.LandAcerage,
                            ReceiptId = l.ReceiptId,
                            Plr = c.PLr,
                            LandDetailId = d.LandDetailId,
                            IsApportioned = (bool)d.IsApportioned



                        }).Distinct(); 
            return data.ToList();
        }


      

        public IList<LedgerDemandVM> Printreceiptforpropertytax(int RecepitId)
        {
            var rn = ctx.TblReceipt.Where(d => d.ReceiptId == RecepitId).Max(x => x.ReceiptNo);

            var data = (from x in ctx.ViewProertyTaxLedger.Where(x => x.ReceiptId == RecepitId).OrderBy(x => x.TaxId).OrderBy(x => x.CalendarYear)

                        let tno = (ctx.TblLandOwnershipDetail.Where(lod => lod.TaxPayerId == x.TaxPayerId && lod.LandDetailId == x.LandDetailId)).Take(1).FirstOrDefault().ThramNo
                        let netamt = ctx.TblLedger.Where(l => l.ReceiptId == RecepitId).Sum(t => t.TotalAmount)
                        let netpenamt = ctx.TblLedger.Where(l => l.ReceiptId == RecepitId).Sum(t => t.PenaltyAmount)

                        let qr = GenerateQr(rn.ToString())
                        //orderby x.TaxId ascending,x.CalendarYear
                        select new LedgerDemandVM
                        {
                            QrImage = qr,
                            TotalAmount = netamt,
                            TotalPenaltyAmount = netpenamt,
                            GrandTotalAmount = (decimal)x.TotalAmount,
                            //Bank = bb_value.BranchName ?? "",
                            //Paymentmode = pm_value.PaymentMode ?? "",
                            Receipt = rn,
                            CreatedOn = Convert.ToDateTime(x.CreatedOn),
                            ReceiptId = x.ReceiptId,
                            TaxPayerId = x.TaxPayerId,
                            PhoneNo = x.MobileNo,
                            FullName = x.FullName,
                            Caddress = x.Caddress,
                            Cid = x.Cid,
                            Ttin = x.Ttin,
                            PlotNo = x.PlotNo,
                            ThramNo = tno,
                            CalendarYear = x.CalendarYear,
                            TaxName = x.TaxName,
                            PenaltyAmount = (decimal)x.PenaltyAmount,
                            PenaltyDays = x.PenaltyPeriod

                        });
            return data.ToList();


        }



        //*******************************************vendor tax*********************
        //********************House******************************
        public IList<LedgerDemandVM> fetchHouseDetailByCid(string cid, string ttin,int Year)
        {
          
            var data = (from x in ctx.MstTaxPayerProfile.Where(x => x.Cid == cid || x.Ttin == ttin)
                        join a in ctx.EnumTitle on x.TitleId equals a.TitleId

                        join b in ctx.TblHouseAllocation on x.TaxPayerId equals b.TaxPayerId
                        join c in ctx.TblHouseRentDemandDetail on b.HouseAllocationId equals c.HouseAllocationId
                        join l in ctx.TblLedger on c.HouseRentDemandDetailId equals l.HouseRentDemandDetailId
                        join e in ctx.TblHouseDetail on b.HouseDetailId equals e.HouseDetailId
                        join f in ctx.EnumBillingSchedule on b.BillingScheduleId equals f.BillingScheduleId

                        join d in ctx.TblDemand on c.DemandNoId equals d.DemandNoId
                        join tds in ctx.TblTransactionDetail on d.TransactionId equals tds.TransactionId
                        join ty in ctx.MstTransactionType on tds.TransactionTypeId equals ty.TransactionTypeId
                        where d.IsPaymentMade == true && tds.TransactionTypeId == 15 && d.CreatedOn.Year == Year

                        select new LedgerDemandVM
                        {
                            TaxPayerId = x.TaxPayerId,
                            Ttin = x.Ttin,
                            Cid = x.Cid,
                            FullName = x.FirstName + " " + ((x.MiddleName == null || x.MiddleName.Trim() == string.Empty) ? string.Empty : (x.MiddleName + " ")) + ((x.LastName == null || x.LastName.Trim() == string.Empty) ? string.Empty : (x.LastName + " ")),
                            PhoneNo = x.MobileNo,
                            Title = a.Title,
                            Caddress = x.CAddress,
                            TransactionId = tds.TransactionId,
                            ReceiptId = l.ReceiptId,
                            TransactionType = ty.TransactionType,
                            Email = x.Email,

                            Address = e.HouseAddress,
                            InstallmentAmount = b.RentalAmount,
                            BillingSchedule = f.BillingSchedule,
                            billmonth = (c.InstallmentDate.ToString("MMM yyyy"))
                        });
            return data.ToList();
        }
        //***************************Stall*************************** 
        public IList<LedgerDemandVM> fetchStallDetailByCid(string cid, string ttin, int Year)
        {
                
            var data = (from x in ctx.MstTaxPayerProfile.Where(x => x.Cid == cid || x.Ttin == ttin)
             join a in ctx.EnumTitle on x.TitleId equals a.TitleId

             join b in ctx.TblStallAllocation on x.TaxPayerId equals b.TaxPayerId
             join c in ctx.TblStallDetailDemand on b.StallAllocationId equals c.StallAllocationId
             join l in ctx.TblLedger on c.StallDemandDetailId equals l.StallDemandDetailId
             join e in ctx.TblStallDetail on b.StallDetailId equals e.StallDetailId
             join f in ctx.EnumBillingSchedule on b.BillingScheduleId equals f.BillingScheduleId
            join w in ctx.EnumDemandGenerateSchedule on c.DemandGenerateScheduleId equals w.DemandGenerateScheduleId
            join d in ctx.TblDemand on c.DemandNoId equals d.DemandNoId
             join tds in ctx.TblTransactionDetail on d.TransactionId equals tds.TransactionId
             join ty in ctx.MstTransactionType on tds.TransactionTypeId equals ty.TransactionTypeId
             where d.IsPaymentMade == true && tds.TransactionTypeId == 17 && d.CreatedOn.Year == Year

             select new LedgerDemandVM
             {
                 TaxPayerId = x.TaxPayerId,
                 Ttin = x.Ttin,
                 Cid = x.Cid,
                 FullName = x.FirstName + " " + ((x.MiddleName == null || x.MiddleName.Trim() == string.Empty) ? string.Empty : (x.MiddleName + " ")) + ((x.LastName == null || x.LastName.Trim() == string.Empty) ? string.Empty : (x.LastName + " ")),
                 PhoneNo = x.MobileNo,
                 Title = a.Title,
                 Caddress = x.CAddress,
                 TransactionId = tds.TransactionId,
                 ReceiptId = l.ReceiptId,
                 TransactionType = ty.TransactionType,

                 Address = e.StallName,
                 InstallmentAmount = b.RentalAmount,
                 BillingSchedule = f.BillingSchedule,
                 Month = ((w.DemandGenerateSchedule == null || w.DemandGenerateSchedule.Trim() == string.Empty) ? string.Empty : (w.DemandGenerateSchedule + " " + c.DemandYear))
                        

             });
            return data.ToList();
        }

        //****************************************Land Lease*********************************************
        public IList<LedgerDemandVM> fetchLandLeaseDetailByCid(string cid, string ttin, int Year)
        {
            var data = (from x in ctx.MstTaxPayerProfile.Where(x => x.Cid == cid || x.Ttin == ttin)
                        join a in ctx.EnumTitle on x.TitleId equals a.TitleId

                        join b in ctx.TblLandLease on x.TaxPayerId equals b.TaxPayerId
                        join c in ctx.EnumLeaseType on b.LeaseTypeId equals c.LeaseTypeId
                        join e in ctx.TblLandLeaseDemandDetail on b.LandLeaseId equals e.LandLeaseId
                        join l in ctx.TblLedger on e.LandLeaseDemandDetailId equals l.LandLeaseDemandDetailId
                        join f in ctx.EnumBillingSchedule on b.BillingScheduleId equals f.BillingScheduleId

                        join d in ctx.TblDemand on e.DemandNoId equals d.DemandNoId
                        join tds in ctx.TblTransactionDetail on d.TransactionId equals tds.TransactionId
                        join ty in ctx.MstTransactionType on tds.TransactionTypeId equals ty.TransactionTypeId
                        where d.IsPaymentMade == true && tds.TransactionTypeId == 16 && d.CreatedOn.Year == Year

                        select new LedgerDemandVM
                        {
                            TaxPayerId = x.TaxPayerId,
                            Ttin = x.Ttin,
                            Cid = x.Cid,
                            FullName = x.FirstName + " " + ((x.MiddleName == null || x.MiddleName.Trim() == string.Empty) ? string.Empty : (x.MiddleName + " ")) + ((x.LastName == null || x.LastName.Trim() == string.Empty) ? string.Empty : (x.LastName + " ")),
                            PhoneNo = x.MobileNo,
                            Title = a.Title,
                            Caddress = x.CAddress,
                            TransactionId = tds.TransactionId,
                            ReceiptId = l.ReceiptId,
                            TransactionType = ty.TransactionType,

                            Address = c.LeaseType,
                            InstallmentAmount = b.LeaseAmount,
                            BillingSchedule = f.BillingSchedule

                        });
            return data.ToList();
        }
            //********************************************ParkingFee**********************************************
            public IList<LedgerDemandVM> fetchParkingDetailByCid(string cid, string ttin, int Year)
            {
                var data = (from x in ctx.MstTaxPayerProfile.Where(x => x.Cid == cid || x.Ttin == ttin)
                    join a in ctx.EnumTitle on x.TitleId equals a.TitleId
                    join p in ctx.TblParkingfeeDetail on x.TaxPayerId equals p.TaxPayerId
                    join pd in ctx.TblParkingFeeDemandDetail on p.ParkingFeeDetailId equals pd.ParkingFeeDetailId
                    join l in ctx.TblLedger on pd.ParkingDemandDetailId equals l.ParkingDemandDetailId
                    join z in ctx.MstParkingZone on p.ParkingZoneId equals z.ParkingZoneId
                    join bs in ctx.EnumBillingSchedule on p.BillingScheduleId equals bs.BillingScheduleId

                    join d in ctx.TblDemand on pd.DemandNoId equals d.DemandNoId
                    join tds in ctx.TblTransactionDetail on d.TransactionId equals tds.TransactionId
                    join ty in ctx.MstTransactionType on tds.TransactionTypeId equals ty.TransactionTypeId
                    where d.IsPaymentMade == true && tds.TransactionTypeId == 18 && d.CreatedOn.Year == Year

                            select new LedgerDemandVM
                    {
                        TaxPayerId = x.TaxPayerId,
                        Ttin = x.Ttin,
                        Cid = x.Cid,
                        FullName = x.FirstName + " " + ((x.MiddleName == null || x.MiddleName.Trim() == string.Empty) ? string.Empty : (x.MiddleName + " ")) + ((x.LastName == null || x.LastName.Trim() == string.Empty) ? string.Empty : (x.LastName + " ")),
                        PhoneNo = x.MobileNo,
                        Title = a.Title,
                        Caddress = x.CAddress,
                        TransactionId = tds.TransactionId,
                        ReceiptId = l.ReceiptId,
                        TransactionType = ty.TransactionType,
                        
                        Address = z.ParkingzoneName,
                        InstallmentAmount = p.InstallmentAmount,
                        BillingSchedule = bs.BillingSchedule

                    }) ;
            return data.ToList();
        }


        public IList<LedgerDemandVM> fetchVendorRecepit(long ReceiptId)
        {
            
            var rn = ctx.TblReceipt.Where(d => d.ReceiptId == ReceiptId).Max(x => x.ReceiptNo);

            var data = (from a in ctx.TblLedger.Where(a => a.ReceiptId == ReceiptId)
                            //  join w in ctx.MstWaterConnection on a.TransactionId equals w.TransactionId
                        join dn in ctx.TblDemand on a.TransactionId equals dn.TransactionId
                        join d in ctx.TblDemandNo on dn.DemandNoId equals d.DemandNoId
                        join t in ctx.MstTaxMaster on dn.TaxId equals t.TaxId
                        join r in ctx.TblReceipt on a.ReceiptId equals r.ReceiptId

                        join c in ctx.TblHouseRentDemandDetail on a.HouseRentDemandDetailId equals c.HouseRentDemandDetailId
                         into c_temp
                        from c_value in c_temp.DefaultIfEmpty()
                        join en in ctx.EnumDemandGenerateSchedule on c_value.DemandGenerateScheduleId equals en.DemandGenerateScheduleId
                         into en_temp
                        from en_value in en_temp.DefaultIfEmpty()

                        join q in ctx.TblStallDetailDemand on a.StallDemandDetailId equals q.StallDemandDetailId
                         into q_temp
                        from q_value in q_temp.DefaultIfEmpty()
                        join w in ctx.EnumDemandGenerateSchedule on q_value.DemandGenerateScheduleId equals w.DemandGenerateScheduleId
                         into w_temp
                        from w_value in w_temp.DefaultIfEmpty()

                        join o in ctx.TblLandLeaseDemandDetail on a.LandLeaseDemandDetailId equals o.LandLeaseDemandDetailId
                         into o_temp
                        from o_value in o_temp.DefaultIfEmpty()
                        join k in ctx.EnumDemandGenerateSchedule on o_value.DemandGenerateScheduleId equals k.DemandGenerateScheduleId
                         into k_temp
                        from k_value in k_temp.DefaultIfEmpty()

                        join g in ctx.TblParkingFeeDemandDetail on a.ParkingDemandDetailId equals g.ParkingDemandDetailId
                         into g_temp
                        from g_value in g_temp.DefaultIfEmpty()
                        join z in ctx.EnumDemandGenerateSchedule on g_value.DemandGenerateScheduleId equals z.DemandGenerateScheduleId
                         into z_temp
                        from z_value in z_temp.DefaultIfEmpty()
                            //join tp in ctx.MstTaxPayerProfile on a.TaxPayerId equals tp.TaxPayerId
                            //join tt in ctx.EnumTitle on tp.TitleId equals tt.TitleId
                            //join b in ctx.TblLandOwnershipDetail on tp.TaxPayerId equals b.TaxPayerId
                            //join la in ctx.MstLandDetail on b.LandDetailId equals la.LandDetailId
                        let netamt = ctx.TblLedger.Where(l => l.ReceiptId == ReceiptId).Sum(t => t.TotalAmount)
                        let ptamt = ctx.TblLedger.Where(l => l.ReceiptId == ReceiptId).Sum(t => t.PenaltyAmount)
                        let qr = GenerateQr(rn.ToString())
                        select new LedgerDemandVM
                        {
                            QrImage = qr,
                            NetAmount = netamt,
                            DemandNo = d.DemandNo,
                            Receipt = r.ReceiptNo,
                            TaxName = t.TaxName,
                            DemandAmount = dn.DemandAmount,
                            TotalAmount = dn.TotalAmount,
                            CreatedOn = r.CreatedOn,
                            BillingDate = dn.BillingDate,
                            TotalPenaltyAmount = ptamt,
                            PenaltyAmount = a.PenaltyAmount,
                            PenaltyDays = a.PenaltyPeriod,
                          Month = ((en_value.DemandGenerateSchedule == null || en_value.DemandGenerateSchedule.Trim() == string.Empty) ? string.Empty : (en_value.DemandGenerateSchedule + " "+ c_value.DemandYear)) 
                          + ((w_value.DemandGenerateSchedule == null || w_value.DemandGenerateSchedule.Trim() == string.Empty) ? string.Empty : (w_value.DemandGenerateSchedule + " "+ q_value.DemandYear)) 
                          + ((k_value.DemandGenerateSchedule == null || k_value.DemandGenerateSchedule.Trim() == string.Empty) ? string.Empty : (k_value.DemandGenerateSchedule + " "+ o_value.DemandYear))
                          + ((z_value.DemandGenerateSchedule == null || z_value.DemandGenerateSchedule.Trim() == string.Empty) ? string.Empty : (z_value.DemandGenerateSchedule + " "+ g_value.DemandYear))
                            // Month = en_value.BillingSchedule + w_value.BillingSchedule or k_value.BillingSchedule or z_value.BillingSchedule
                            //ThramNo = b.ThramNo,


                            //FirstName = tt.Title + "" + tp.FirstName + " " + ((tp.MiddleName == null || tp.MiddleName.Trim() == string.Empty) ? string.Empty : (tp.MiddleName + " ")) + ((tp.LastName == null || tp.LastName.Trim() == string.Empty) ? string.Empty : (tp.LastName + " "))
                            //Caddress = tp.CAddress,
                            //PhoneNo = tp.PhoneNo,



                        });
            return data.ToList();
        }
        //***********************************************date for vendor********************************************************
        public IList<LedgerDemandVM> fetchDreceiptuser(long ReceiptId)
        {
            var data = from x in ctx.TblLedger.Where(x => x.ReceiptId == ReceiptId)
                     
                       join au in ctx.AspNetUsers on x.CreatedBy equals au.UserId
                       select new LedgerDemandVM
                       {
                           Creatorname = au.FirstName + " " + ((au.MiddleName == null || au.MiddleName.Trim() == string.Empty) ? string.Empty : (au.MiddleName + " ")) + ((au.LastName == null || au.LastName.Trim() == string.Empty) ? string.Empty : (au.LastName + " ")),
                       }; 
            return data.ToList();
        }


        public async Task<decimal> GetWaterConnectionId(string DemandNo, string ConsumerNo)
        {
            var bdata = ctx.MstWaterConnection.Where(x => x.IsActive == true && x.ConsumerNo == ConsumerNo);
           
            decimal rmsamt = 0;          
            try
            {
                using (var httpClient = new HttpClient())
                {
                    //httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", "812c2d79-36f4-3610-937c-6363d8e18b2d".ToString());
                   //using (var response = await httpClient.GetAsync("https://revenue.thimphucity.bt:84/api/Service/GetLastPaymentDetailForWater?" + "WaterConnectionId=" + bdata.FirstOrDefault().WaterConnectionId))
                    using (var response = await httpClient.GetAsync("http://172.24.40.3:84/api/Service/GetLastPaymentDetailForWater?" + "WaterConnectionId=" + bdata.FirstOrDefault().WaterConnectionId))
                //    using (var response = await httpClient.GetAsync("https://172.30.16.3:84/api/Service/GetLastPaymentDetailForWater?waterconnectionid=11991"))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();                      
                        if (response.IsSuccessStatusCode)
                        {
                            var json = response.Content.ReadAsStringAsync().Result;
                            dynamic json_result = JsonConvert.DeserializeObject(json);
                            if (json_result = true)
                            {
                                if (JObject.Parse(json).ToString() == "{}")
                                {
                                    return rmsamt;                                   
                                }
                                else
                                {
                                    //var ds = JsonConvert.DeserializeObject<List<KeyValuePair<string>>;
                                    //var value = JsonConvert.DeserializeObject<List<KeyValuePair<string, object>>>(json).ToDictionary(x => x.Key, y => y.Value);
                                    var details = JObject.Parse(json);
                                    rmsamt = Convert.ToDecimal(details["amount"]);
                                    return rmsamt;

                                }
                            }
                        }
                        if (Convert.ToInt32(response.StatusCode) == 400)
                        {
                            return rmsamt;
                        }
                    }
                }
                return rmsamt;
            }
            catch (Exception EX)
            {
                return rmsamt;
            }
        }

//**************************************************************************Vacuum Tanker duplicate recepit print ******************************************************************************************
        public List<VacuumTankerServiceVM> fetchVacuumtanker(string RecepitNo, string Name)
        {
            var tyid = "11";
            var data = (from x in ctx.TblLedger

                        join r in ctx.TblReceipt on x.ReceiptId equals r.ReceiptId
                        join d in ctx.TblDemand on x.DemandId equals d.DemandId
                        join tds in ctx.TblTransactionDetail on d.TransactionId equals tds.TransactionId
                        join tys in ctx.MstTransactionType on tds.TransactionTypeId equals tys.TransactionTypeId
                        join v in ctx.TrnVacuumTankerService on x.TransactionId equals v.TransactionId
                        join b in ctx.TblLandOwnershipDetail on v.LandOwnershipId equals b.LandOwnershipId
                        join tp in ctx.MstTaxPayerProfile on b.TaxPayerId equals tp.TaxPayerId

                        where r.ReceiptNo == RecepitNo || v.ContactName == Name && d.IsPaymentMade == true && tyid.Contains(tds.TransactionTypeId.ToString())

                        select new VacuumTankerServiceVM
                        {
                            Name = tp.FirstName + " " + ((tp.MiddleName == null || tp.MiddleName.Trim() == string.Empty) ? string.Empty : (tp.MiddleName + " ")) + ((tp.LastName == null || tp.LastName.Trim() == string.Empty) ? string.Empty : (tp.LastName + " ")),
                            ContactName = v.ContactName,
                            NoOfTrips = v.NoOfTrips,
                            Amount = v.Amount,
                            MobileNo = v.MobileNo,
                            RecepitId = x.ReceiptId

                        });
            return data.ToList();
        }


        //**************************************************************************land  transaction Fee******************************************************************************************
        public List<LedgerDemandVM> fetchLandTransactions(string Ttin, string Cid)
        {
            var tyid = "13,31,34,35,36,37,38,39,40,41";
            var data = (from x in ctx.MstTaxPayerProfile.Where(x =>x.Ttin == Ttin || x.Cid == Cid)
                        
                        join d in ctx.TblDemand on x.TaxPayerId equals d.TaxPayerId
                        join tds in ctx.TblTransactionDetail on d.TransactionId equals tds.TransactionId
                        join ld in ctx.TblLedger on tds.TransactionId equals ld.TransactionId
                        join tx in ctx.MstTaxMaster on d.TaxId equals tx.TaxId
                       join l in ctx.MstLandDetail on d.LandDetailId equals l.LandDetailId
                       

                        where d.IsPaymentMade == true && tyid.Contains(tds.TransactionTypeId.ToString())

                        select new LedgerDemandVM
                        {
                            TaxPayerId = x.TaxPayerId,
                            Ttin = x.Ttin,
                            Cid = x.Cid,
                            FullName = x.FirstName + " " + ((x.MiddleName == null || x.MiddleName.Trim() == string.Empty) ? string.Empty : (x.MiddleName + " ")) + ((x.LastName == null || x.LastName.Trim() == string.Empty) ? string.Empty : (x.LastName + " ")),
                            PhoneNo = x.MobileNo,
                            ReceiptId = ld.ReceiptId,
                            Caddress = x.CAddress,
                            TransactionId = tds.TransactionId,
                            PlotNo = l.PlotNo,
                            TaxName = tx.TaxName
                     });
            return data.ToList();
        }


        public List<LedgerDemandVM> landtransactionRecepit(long ReceiptId)
        {
           
            var rn = ctx.TblReceipt.Where(d => d.ReceiptId == ReceiptId).Max(x => x.ReceiptNo);

            var data = (from a in ctx.TblLedger.Where(a => a.ReceiptId == ReceiptId)
                            //  join w in ctx.MstWaterConnection on a.TransactionId equals w.TransactionId
                     
                        join t in ctx.MstTaxMaster on a.TaxId equals t.TaxId
                        join r in ctx.TblReceipt on a.ReceiptId equals r.ReceiptId
                        join o in ctx.TblLandOwnershipDetail on a.LandOwnershipId  equals o.LandOwnershipId
                        //join tp in ctx.MstTaxPayerProfile on a.TaxPayerId equals tp.TaxPayerId
                        //join tt in ctx.EnumTitle on tp.TitleId equals tt.TitleId
                        //join b in ctx.TblLandOwnershipDetail on tp.TaxPayerId equals b.TaxPayerId
                        //join la in ctx.MstLandDetail on b.LandDetailId equals la.LandDetailId
                        let netamt = ctx.TblLedger.Where(l => l.ReceiptId == ReceiptId).Sum(t => t.TotalAmount)
                        let qr = GenerateQr(rn.ToString())
                        select new LedgerDemandVM
                        {
                            QrImage = qr,
                            NetAmount = netamt,
                            
                            Receipt = r.ReceiptNo,
                            TaxName = t.TaxName,
                          
                            TotalAmount = a.TotalAmount,
                            CreatedOn = r.CreatedOn,
                            BillingDate = a.CreatedOn,

                            ThramNo = o.ThramNo


                            //FirstName = tt.Title + "" + tp.FirstName + " " + ((tp.MiddleName == null || tp.MiddleName.Trim() == string.Empty) ? string.Empty : (tp.MiddleName + " ")) + ((tp.LastName == null || tp.LastName.Trim() == string.Empty) ? string.Empty : (tp.LastName + " "))
                            //Caddress = tp.CAddress,
                            //PhoneNo = tp.PhoneNo,



                        });
            return data.ToList();
        }

        public List<LedgerDemandVM> creatorlandtransactions(long ReceiptId)
        {
            var data = from x in ctx.TblLedger.Where(x => x.ReceiptId == ReceiptId)

                       join au in ctx.AspNetUsers on x.CreatedBy equals au.UserId
                       select new LedgerDemandVM
                       {
                           Creatorname = au.FirstName + " " + ((au.MiddleName == null || au.MiddleName.Trim() == string.Empty) ? string.Empty : (au.MiddleName + " ")) + ((au.LastName == null || au.LastName.Trim() == string.Empty) ? string.Empty : (au.LastName + " ")),
                       };
            return data.ToList();
        }



        ////**************************************************************************land  transaction Fee******************************************************************************************
        //public List<LedgerDemandVM> fetchLandTransactions(string Ttin, string Cid)
        //{
        //    var tyid = "42";
        //    var data = (from x in ctx.MstTaxPayerProfile.Where(x => x.Ttin == Ttin || x.Cid == Cid)

        //                join d in ctx.TblDemand on x.TaxPayerId equals d.TaxPayerId
        //                join tds in ctx.TblTransactionDetail on d.TransactionId equals tds.TransactionId
        //                join tx in ctx.MstTaxMaster on d.TaxId equals tx.TaxId
        //                join l in ctx.MstLandDetail on d.LandDetailId equals l.LandDetailId


        //                where d.IsPaymentMade == true && tyid.Contains(tds.TransactionTypeId.ToString())

        //                select new LedgerDemandVM
        //                {
        //                    TaxPayerId = x.TaxPayerId,
        //                    Ttin = x.Ttin,
        //                    Cid = x.Cid,
        //                    FullName = x.FirstName + " " + ((x.MiddleName == null || x.MiddleName.Trim() == string.Empty) ? string.Empty : (x.MiddleName + " ")) + ((x.LastName == null || x.LastName.Trim() == string.Empty) ? string.Empty : (x.LastName + " ")),
        //                    PhoneNo = x.MobileNo,

        //                    Caddress = x.CAddress,
        //                    TransactionId = tds.TransactionId,
        //                    PlotNo = l.PlotNo,
        //                    TaxName = tx.TaxName
        //                });
        //    return data.ToList();
        //}



        //**************************************************************************land  transaction Fee******************************************************************************************
        //public List<LedgerDemandVM> fetchLandTransactions(string Ttin, string Cid)
        //{
        //    var tyid = "13,31,34,35,36,37,38,39,40,41";
        //    var data = (from x in ctx.MstTaxPayerProfile.Where(x => x.Ttin == Ttin || x.Cid == Cid)

        //                join d in ctx.TblDemand on x.TaxPayerId equals d.TaxPayerId
        //                join tds in ctx.TblTransactionDetail on d.TransactionId equals tds.TransactionId
        //                join ld in ctx.TblLedger on tds.TransactionId equals ld.TransactionId
        //                join tx in ctx.MstTaxMaster on d.TaxId equals tx.TaxId
        //                join l in ctx.MstLandDetail on d.LandDetailId equals l.LandDetailId


        //                where d.IsPaymentMade == true && tyid.Contains(tds.TransactionTypeId.ToString())

        //                select new LedgerDemandVM
        //                {
        //                    TaxPayerId = x.TaxPayerId,
        //                    Ttin = x.Ttin,
        //                    Cid = x.Cid,
        //                    FullName = x.FirstName + " " + ((x.MiddleName == null || x.MiddleName.Trim() == string.Empty) ? string.Empty : (x.MiddleName + " ")) + ((x.LastName == null || x.LastName.Trim() == string.Empty) ? string.Empty : (x.LastName + " ")),
        //                    PhoneNo = x.MobileNo,
        //                    ReceiptId = ld.ReceiptId,
        //                    Caddress = x.CAddress,
        //                    TransactionId = tds.TransactionId,
        //                    PlotNo = l.PlotNo,
        //                    TaxName = tx.TaxName
        //                });
        //    return data.ToList();
        //}

        public IList<OnlinePaymentCheckModel> FetOnlinePaymentStatus(string DemandNoIds)
        {
            string[] ids = DemandNoIds.Split(',');
            var DataDemand = (
                 from x in ctx.TblDemand.Where(x => ids.Contains(x.DemandNoId.ToString()))
                 select x.BfsTransactionDetailId).ToList();

            var BFSAR = ctx.TblBfsTransactiondetails.Single(x => DataDemand.Contains(x.BfsTransactionDetailId));

            var DataBFSAC = (
                 from x in ctx.TblBfsTransactiondetails.Where(x => x.BfsDebitAuthCode == "00" && x.BfsOrderNo == BFSAR.BfsOrderNo)
                 select new OnlinePaymentCheckModel
                 {
                     BfsTransactionDetailId = (long)x.BfsTransactionDetailId,
                     BfsDebitAuthCode = x.BfsDebitAuthCode,
                 });
            return DataBFSAC.ToList();
        }

        public IList<LedgerDemandVM> PrintDemand(int id)
        {
            var dn = ctx.TblReceipt.Where(d => d.ReceiptId == id).Max(x => x.ReceiptNo);

            var data = (from x in ctx.TblLedger.Where(x => x.ReceiptId == id)

                        join z in ctx.MstTaxMaster on x.TaxId equals z.TaxId
                        join a in ctx.MstSlab on z.TaxId equals a.TaxId
                        join b in ctx.MstRate on a.SlabId equals b.SlabId

                        join t in ctx.TrnVacuumTankerService on x.TransactionId equals t.TransactionId
                        join au in ctx.AspNetUsers on x.CreatedBy equals au.UserId

                        let qr = GenerateQr(dn.ToString())

                        select new LedgerDemandVM
                        {
                            QrImage = qr,
                            CreatedOn = x.CreatedOn,
                            Receipt = dn,


                            TaxName = z.TaxName,
                            Rate = b.Rate,
                            NoOfTrips = t.NoOfTrips,
                            Amount = x.TotalAmount,

                            UserName = t.ContactName,
                            PhoneNo = t.MobileNo,
                            Address = t.ContactAddress,
                            Creatorname = au.FirstName + " " + ((au.MiddleName == null || au.MiddleName.Trim() == string.Empty) ? string.Empty : (au.MiddleName + " ")) + ((au.LastName == null || au.LastName.Trim() == string.Empty) ? string.Empty : (au.LastName + " ")),
                        });
            return data.ToList();
        }

        //**********************************************  ENVIRONMENTAL CLERANCE  ********************************************************************
        public IList<LedgerDemandVM> GetECDemandWithSearch(string DemandNo, string Cid)
        {
            var tid = "9";

            if (DemandNo != "" && DemandNo != null)
            {
                var Demand = (
                from x in ctx.TblDemandNo.Where(x => x.DemandNo == DemandNo)
                join y in ctx.TblDemand on x.DemandNoId equals y.DemandNoId
                join t in ctx.TblTransactionDetail on y.TransactionId equals t.TransactionId
                join ti in ctx.MstTaxMaster on y.TaxId equals ti.TaxId
                where tid.Contains(t.TransactionTypeId.ToString()) && ti.TaxId != 36
                select y.TransactionId).ToList();
                

                var data = (from x in ctx.TblDemand.Where(x => Demand.Contains(x.TransactionId))
                            .OrderBy(xx => xx.TransactionId)
                            .OrderBy(xx => xx.TaxPayerId)
                            join y in ctx.TblDemandNo on x.DemandNoId equals y.DemandNoId 
                            where x.IsPaymentMade == false && x.IsCancelled == false
                            let cuc_sum = ctx.TblDemand.Where(y => y.DemandNoId == x.DemandNoId).Sum(x => x.TotalAmount)
                            let cuc_sumd = ctx.TblDemand.Where(y => y.DemandNoId == x.DemandNoId).Sum(x => x.DemandAmount)
                            let cuc_sume = ctx.TblDemand.Where(y => y.DemandNoId == x.DemandNoId).Sum(x => x.ExemptionAmount).GetValueOrDefault()
                           

                            select new LedgerDemandVM
                            {
                                TotalAmount = cuc_sum,
                                DemandNoId = x.DemandNoId,
                                DemandAmount = cuc_sumd,
                                ExemptionAmount = cuc_sume,
                                ExemptionLetter = x.ExemptionLetter,
                                DemandNo = y.DemandNo,
                            }).Distinct();

                return (IList<LedgerDemandVM>)data.ToList();
            }
            else
            {
                var EC = (
                 from x in ctx.MstEcapplicantdetail.Where(x => x.Cid == Cid || x.LicenceNo == Cid)
                 join y in ctx.TblDemand on x.ApplicantId equals y.ApplicantId
                 join t in ctx.TblTransactionDetail on y.TransactionId equals t.TransactionId
                 where tid.Contains(t.TransactionTypeId.ToString())
                 select y.TransactionId).ToList();

                var data = (from x in ctx.TblDemand.Where(x => EC.Contains(x.TransactionId))
                            .OrderBy(xx => xx.TransactionId)
                            .OrderBy(xx => xx.TaxPayerId)
                            join y in ctx.TblDemandNo on x.DemandNoId equals y.DemandNoId
                            where x.IsPaymentMade == false && x.IsCancelled == false
                            let cuc_sum = ctx.TblDemand.Where(y => y.DemandNoId == x.DemandNoId).Sum(x => x.TotalAmount)
                            let cuc_sumd = ctx.TblDemand.Where(y => y.DemandNoId == x.DemandNoId).Sum(x => x.DemandAmount)
                            let cuc_sume = ctx.TblDemand.Where(y => y.DemandNoId == x.DemandNoId).Sum(x => x.ExemptionAmount).GetValueOrDefault()

                            select new LedgerDemandVM
                            {
                                TotalAmount = cuc_sum,
                                DemandNoId = x.DemandNoId,
                                DemandAmount = cuc_sumd,
                                ExemptionAmount = cuc_sume,
                                ExemptionLetter = x.ExemptionLetter,
                                DemandNo = y.DemandNo,
                            }).Distinct();

                return (IList<LedgerDemandVM>)data.ToList();
            }
        }

        //***************************************** ENVIRONMENTAL CLERANCE *****************************************
        public IList<LedgerDemandVM> PrintEC(long RecepitId)
        {
            var rn = ctx.TblReceipt.Where(d => d.ReceiptId == RecepitId).Max(x => x.ReceiptNo);
            var data = (from x in ctx.TblLedger.Where(x => x.ReceiptId == RecepitId)
                        join z in ctx.MstTaxMaster on x.TaxId equals z.TaxId
                        join e in ctx.TblEcrenewalDetail on x.EcRenewalId equals e.EcRenewalId
                        join t in ctx.TblEcdetail on e.EcDetailId equals t.EcDetailId
                        join a in ctx.MstEcapplicantdetail on x.ApplicantId equals a.ApplicantId
                        join y in ctx.MstEcactivityType on t.EcActivityTypeId equals y.EcActivityTypeId
                        let netamt = ctx.TblLedger.Where(l => l.ReceiptId == RecepitId).Sum(t => t.TotalAmount)

                        let qr = GenerateQr(rn.ToString())
                        select new LedgerDemandVM
                        {
                            QrImage = qr,
                            Receipt = rn,
                            TotalAmount = netamt,
                            Amount = x.TotalAmount,
                            CreatedOn = x.CreatedOn,
                            ReceiptId = x.ReceiptId,                           
                            TaxName = z.TaxName,
                            ApplicantName = a.ApplicantName,
                            Cid = a.Cid,
                            LicenseNo = a.LicenceNo,
                            PhoneNo = a.ContactNo,
                            Address = a.Address,
                            ActivityType = y.ActivityType,
                            PenaltyAmount = x.PenaltyAmount
                        });

            return data.ToList();


        }

        public IList<LedgerDemandVM> fetchECDetail(string Name, string Cid)
        {
            var data = (from x in ctx.MstEcapplicantdetail.Where(x => x.ApplicantName == Name || (x.Cid == Cid || x.LicenceNo == Cid))
                        join d in ctx.TblDemand on x.ApplicantId equals d.ApplicantId
                        join a in ctx.TblEcrenewalDetail on d.EcRenewalId equals a.EcRenewalId
                        join e in ctx.TblEcdetail on a.EcDetailId equals e.EcDetailId
                        join f in ctx.MstEcactivityType on e.EcActivityTypeId equals f.EcActivityTypeId
                        join t in ctx.MstTaxMaster on d.TaxId equals t.TaxId
                        join l in ctx.TblLedger on d.DemandId equals l.DemandId
                        where d.IsPaymentMade == true /*&& t.TaxId != 36*/

                        select new LedgerDemandVM
                        {
                            ApplicantName = x.ApplicantName,
                            Cid = x.Cid,
                            LicenseNo = x.LicenceNo,
                            PhoneNo = x.ContactNo,
                            TaxName = t.TaxName,
                            Amount = d.TotalAmount,
                            ReceiptId = l.ReceiptId,
                            ActivityType = f.ActivityType

                        });
            return data.ToList();
        }

        public IList<LedgerDemandVM> fetchECRecepit(long ReceiptId)
        {

            var rn = ctx.TblReceipt.Where(d => d.ReceiptId == ReceiptId).Max(x => x.ReceiptNo);

            var data = (from a in ctx.TblLedger.Where(a => a.ReceiptId == ReceiptId)
                        join dn in ctx.TblDemand on a.TransactionId equals dn.TransactionId
                        join d in ctx.TblDemandNo on dn.DemandNoId equals d.DemandNoId
                        join t in ctx.MstTaxMaster on dn.TaxId equals t.TaxId
                        join r in ctx.TblReceipt on a.ReceiptId equals r.ReceiptId
                        join e in ctx.MstEcapplicantdetail on dn.ApplicantId equals e.ApplicantId
                        join i in ctx.TblEcrenewalDetail on dn.EcRenewalId equals i.EcRenewalId
                        join s in ctx.TblEcdetail on i.EcDetailId equals s.EcDetailId
                        join k in ctx.MstEcactivityType on s.EcActivityTypeId equals k.EcActivityTypeId
                        let netamt = ctx.TblLedger.Where(l => l.ReceiptId == ReceiptId).Sum(t => t.TotalAmount)
                        let qr = GenerateQr(rn.ToString())
                        select new LedgerDemandVM
                        {
                            QrImage = qr,
                            NetAmount = netamt,
                            DemandNo = d.DemandNo,
                            Receipt = r.ReceiptNo,
                            TaxName = t.TaxName,
                            TotalAmount = dn.TotalAmount,
                            CreatedOn = r.CreatedOn,
                            ActivityType = k.ActivityType,
                            ApplicantName = e.ApplicantName,
                            Cid = e.Cid,
                            LicenseNo = e.LicenceNo,
                            Address = e.Address
                            
                        }).Distinct();
            return data.ToList();
        }
    }
}
