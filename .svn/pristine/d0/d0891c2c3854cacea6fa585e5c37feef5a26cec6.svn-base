using CORE_DLL;
using System;
using System.Collections.Generic;
using CORE_BOL;
using CORE_BOL.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Transactions;
using QRCoder;
using System.Drawing;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Data;

namespace CORE_BLL
{
    public class PropertyTaxGenerateAllBLL : IPropertyTaxGenerateAll
    {
        readonly tt_dbContext ctx = new tt_dbContext();
        private readonly ITokenService tokenService;
        string _GetLastPaymentDetailsURL = "";


        public IList<LedgerDemandVM> lasttaxpaid(int LandOwnershipId)
        {
            var landownershipData = ctx.TblLandOwnershipDetail.Where(x => x.LandOwnershipId == LandOwnershipId);
            var LandDetailId = landownershipData.FirstOrDefault().LandDetailId;
            var TaxPayerId = landownershipData.FirstOrDefault().TaxPayerId;
            var data = (from a in ctx.TblDemand.Where(x => x.TaxPayerId == TaxPayerId && x.LandDetailId == LandDetailId)
                        join t in ctx.TblTransactionDetail on a.TransactionId equals t.TransactionId
                        join y in ctx.MstCalendarYear on a.CalendarYearId equals y.CalendarYearId
                        where t.TransactionTypeId == 20
                        orderby a.CalendarYearId ascending
                        select new LedgerDemandVM
                        {
                            DemandId = a.DemandId,
                            Amount = a.TotalAmount,
                            CalendarYear = y.CalendarYear

                        });
            return data.Distinct().ToList();
        }
        public IEnumerable<GenerateAllDisplayModel> GetOwnershipDetailByTaxPayerId(int LandOwnershipId, int TaxYearId)
        {
            try
            {
                var result = ctx.GetOwnershipDetailByTaxPayerId.FromSqlRaw($"[GetOwnershipDetailByTaxPayerId] {LandOwnershipId},{TaxYearId}");

                return result.ToList();

            }
            catch (Exception ex)
            {
                return null;

            }
        }
        public IEnumerable<GenerateAllModel> GetOwnershipDetailByLandOwnershipId(string Ids, int TaxYearId)
        {
            try
            {
                var result = ctx.GetOwnershipDetailByLandOwnershipId.FromSqlRaw($"[GetOwnershipDetailByLandOwnershipId] {Ids}, {TaxYearId}");

                return result.ToList();

            }
            catch (Exception ex)
            {
                return null;

            }
        }

        public IList<LandOwneshipModel> GetLandOwnershipDetail(int TaxPayerId)
        {

           var data = (
                      from x in ctx.TblLandOwnershipDetail.Where(x => x.TaxPayerId == TaxPayerId)
                      join xx in ctx.EnumLandOwnershipType on x.LandOwnershipTypeId equals xx.LandOwnershipTypeId
                      join y in ctx.MstTaxPayerProfile on x.TaxPayerId equals y.TaxPayerId
                      join y1 in ctx.EnumTaxPayerType on y.TaxPayerTypeId equals y1.TaxPayerTypeId
                      join y2 in ctx.EnumTitle on y.TitleId equals y2.TitleId
                      join z in ctx.MstLandDetail on x.LandDetailId equals z.LandDetailId
                      join zl in ctx.MstLap on z.LapId equals zl.LapId
                      join zd in ctx.MstDemkhong on z.DemkhongId equals zd.DemkhongId
                      join zs in ctx.MstStreetName on z.StreetNameId equals zs.StreetNameId
                      join zlt in ctx.MstLandType on z.LandTypeId equals zlt.LandTypeId
                      join zp in ctx.MstLandUseSubCategory on z.LandUseSubCategoryId equals zp.LandUseSubCategoryId
                      where z.PropertyTypeId==1
                      orderby x.LandDetailId
                      //let lpyr=(from a in ctx.TblDemand.Where(d => d.LandDetailId == x.LandDetailId)
                      //          join t in ctx.TblTransactionDetail on a.TransactionId equals t.TransactionId
                      //         // join y in ctx.MstCalendarYear on a.CalendarYearId equals y.CalendarYearId
                      //          where t.TransactionTypeId == 20
                      //          orderby a.CalendarYearId ascending) select new{  } 
                                select new LandOwneshipModel
                      {
                          LandOwnershipId=x.LandOwnershipId,
                          LandDetailId=x.LandDetailId,
                          ThramNo = x.ThramNo,
                          LandOwnershipTypeId = x.LandOwnershipTypeId,
                          LandOwnershipType = xx.LandOwnershipType,
                          OwnershipPercentage =(decimal) x.OwnershipPercentage,
                          PlotNo=z.PlotNo,
                          LandAcerage=z.LandAcerage,
                          Plr=x.PLr,
                          LandPoolingRate=z.LandPoolingRate,
                          PlotAddress=z.PlotAddress,Location=z.Location,
                          StructureAvailable=z.StructureAvailable,
                          LapName=zl.LapName,
                          DemkhongName = zd.DemkhongName,
                          StreetName=zs.StreetName,
                          LandTypeName=zlt.LandTypeName,
                          LandUseSubCategory=zp.LandUseSubCategory,
                          TaxPayerType=y1.TaxPayerType,
                          Ttin = y.Ttin,
                          Cid=y.Cid,
                          IsActive = x.IsActive,
                          FullName =  y.FirstName + " " + ((y.MiddleName == null || y.MiddleName.Trim() == string.Empty) ? string.Empty : (y.MiddleName + " ")) + ((y.LastName == null || y.LastName.Trim() == string.Empty) ? string.Empty : (y.LastName + " ")),
                       
                          // FullName = (y2.Title +" "+ y.FirstName +" "+y.MiddleName+" "+y.LastName)
                      }

                      ).ToList();

            return data.ToList();
            

        }
       
       public IList<LandOwneshipModel> FetchTaxPayerByCID(string Cid, string Ttin, string PlotNo , string ThramNo)
        {

            var data = (from a in ctx.MstTaxPayerProfile.Where(x => x.Ttin == Ttin || x.Cid == Cid)
                        join b in ctx.EnumTitle on a.TitleId equals b.TitleId
                        join tt in ctx.EnumTaxPayerType on a.TaxPayerTypeId equals tt.TaxPayerTypeId
                        join c in ctx.TblLandOwnershipDetail on a.TaxPayerId equals c.TaxPayerId
                        //join d in ctx.MstLandDetail on c.LandDetailId equals d.LandDetailId
                        //where d.PropertyTypeId == 1 && (a.Cid == Cid || a.Ttin == Ttin)
                        let tno = (ctx.TblLandOwnershipDetail.Where(lod => lod.TaxPayerId == a.TaxPayerId)).Take(1).FirstOrDefault().LandOwnershipId


                        select new LandOwneshipModel
                        {
                            TaxPayerId = a.TaxPayerId,
                            Cid = a.Cid,
                            Ttin = a.Ttin,
                            TitleId = a.TitleId,
                            Title = b.Title,
                            FirstName = a.FirstName,
                            MiddleName = a.MiddleName,
                            LastName = a.LastName,
                            FullName = (a.FirstName + " " + ((a.MiddleName == null || a.MiddleName.Trim() == string.Empty) ? string.Empty : (a.MiddleName + " ")) + ((a.LastName == null || a.LastName.Trim() == string.Empty) ? string.Empty : (a.LastName + " "))),
                            TaxPayerTypeId = a.TaxPayerTypeId,
                            TaxPayerType = tt.TaxPayerType,
                            MobileNo = a.MobileNo,
                            Email = a.Email,
                            LandOwnershipId = tno,
                        
                        }).Distinct();

            return data.ToList();
        }

        public IList<LandOwneshipModel> FetchTaxPayerByPlotNo(string Cid, string Ttin, string PlotNo, string ThramNo)
        {

            var data = (from a in ctx.MstTaxPayerProfile
                        join b in ctx.EnumTitle on a.TitleId equals b.TitleId
                        join tt in ctx.EnumTaxPayerType on a.TaxPayerTypeId equals tt.TaxPayerTypeId
                        join c in ctx.TblLandOwnershipDetail on a.TaxPayerId equals c.TaxPayerId
                        join d in ctx.MstLandDetail on c.LandDetailId equals d.LandDetailId
                        where d.PropertyTypeId == 1 && (d.PlotNo == PlotNo || c.ThramNo == ThramNo)


                        select new LandOwneshipModel
                        {
                            TaxPayerId = a.TaxPayerId,
                            Cid = a.Cid,
                            Ttin = a.Ttin,
                            TitleId = a.TitleId,
                            Title = b.Title,
                            FirstName = a.FirstName,
                            MiddleName = a.MiddleName,
                            LastName = a.LastName,
                            FullName = (a.FirstName + " " + ((a.MiddleName == null || a.MiddleName.Trim() == string.Empty) ? string.Empty : (a.MiddleName + " ")) + ((a.LastName == null || a.LastName.Trim() == string.Empty) ? string.Empty : (a.LastName + " "))),
                            TaxPayerTypeId = a.TaxPayerTypeId,
                            TaxPayerType = tt.TaxPayerType,
                            MobileNo = a.MobileNo,
                            Email = a.Email,
                            LandOwnershipId = c.LandOwnershipId,

                        });

            return data.ToList();
        }


        public async Task<IList<LandOwneshipModel>> GetLandTaxDetail(int LandOwnershipId)
        {
            //****************************LAND TAX CALCULATION**************************
            var landOwnershipData = (ctx.TblLandOwnershipDetail.Single(x => x.LandOwnershipId == LandOwnershipId));
            var LandDetailId = landOwnershipData.LandDetailId;
            var TaxPayerId = landOwnershipData.TaxPayerId;
            var OwnershipPercentage = landOwnershipData.OwnershipPercentage;
            var LandOwershipId = landOwnershipData.LandOwnershipId;
            var vThramNo = landOwnershipData.ThramNo;
            var dPLR = landOwnershipData.PLr;
            var landOwnershipTypeData = (ctx.EnumLandOwnershipType.Single(x => x.LandOwnershipTypeId == landOwnershipData.LandOwnershipTypeId));

            var LandOwnershipType = landOwnershipTypeData.LandOwnershipType;

            var landData = (ctx.MstLandDetail.Single(x => x.LandDetailId == LandDetailId));
            var LndUseSubCtgyID = landData.LandUseSubCategoryId;
            var LandAcerage = landData.LandAcerage;
            var LandPoolingRate = landData.LandPoolingRate;
            var LandTypeId = landData.LandTypeId;
            var itaxid = 0; var itaxidUD = 0;
            if (LndUseSubCtgyID == 1)//1
            {
                itaxid = 2; itaxidUD = 9;
            }
            else if (LndUseSubCtgyID == 2)//2
            {
                itaxid = 2; itaxidUD = 9;
            }
            else if (LndUseSubCtgyID == 3)//3
            {
                itaxid = 2; itaxidUD = 9;
            }
            else if (LndUseSubCtgyID == 4)//4
            {
                itaxid = 2; itaxidUD = 9;
            }
            else if (LndUseSubCtgyID == 5)//5
            {
                itaxid = 2; itaxidUD = 9;
            }
            else if (LndUseSubCtgyID == 6)//6
            {
                itaxid = 2; itaxidUD = 9;
            }
            else if (LndUseSubCtgyID == 7)//7
            {
                itaxid = 2; itaxidUD = 9;
            }
            else if (LndUseSubCtgyID == 8)//8
            {
                itaxid = 2; itaxidUD = 9;
            }
            else if (LndUseSubCtgyID == 9)//9
            {
                itaxid = 2; itaxidUD = 9;
            }
            else if (LndUseSubCtgyID == 10)//10
            {
                itaxid = 2; itaxidUD = 9;
            }
            else if (LndUseSubCtgyID == 11)//11
            {
                itaxid = 2; itaxidUD = 9;
            }
            //
            else if (LndUseSubCtgyID == 12)//12
            {
                itaxid = 1; itaxidUD = 8;
            }
            else if (LndUseSubCtgyID == 13)//13
            {
                itaxid = 1; itaxidUD = 8;
            }
            else if (LndUseSubCtgyID == 14)
            {
                itaxid = 1; itaxidUD = 8;
            }
            else if (LndUseSubCtgyID == 15)
            {
                itaxid = 1; itaxidUD = 8;
            }
            else if (LndUseSubCtgyID == 16)
            {
                itaxid = 1; itaxidUD = 8;
            }

            else if (LndUseSubCtgyID == 17)
            {
                itaxid = 51; itaxidUD = 73;
            }

            else if (LndUseSubCtgyID == 18)
            {
                itaxid = 1; itaxidUD = 8;
            }
            else if (LndUseSubCtgyID == 19)
            {
                itaxid = 1; itaxidUD = 8;
            }
            else if (LndUseSubCtgyID == 20)
            {
                itaxid = 1; itaxidUD = 8;
            }
            else if (LndUseSubCtgyID == 21)
            {
                itaxid = 1; itaxidUD = 8;
            }
            else if (LndUseSubCtgyID == 22)
            {
                itaxid = 1; itaxidUD = 8;
            }
            else if (LndUseSubCtgyID == 23)
            {
                itaxid = 2; itaxidUD = 9;
            }
            else if (LndUseSubCtgyID == 24)
            {
                itaxid = 1; itaxidUD = 8;
            }
            else if (LndUseSubCtgyID == 25)
            {
                itaxid = 1; itaxidUD = 8;
            }
            else if (LndUseSubCtgyID == 26)
            {
                itaxid = 1; itaxidUD = 8;
            }

            else if (LndUseSubCtgyID == 27)
            {
                itaxid = 1; itaxidUD = 8;
            }
            else if (LndUseSubCtgyID == 28)
            {
                itaxid = 1; itaxidUD = 8;
            }
            else if (LndUseSubCtgyID == 29)
            {
                itaxid = 1; itaxidUD = 8;
            }
            else if (LndUseSubCtgyID == 30)
            {
                itaxid = 1; itaxidUD = 8;
            }
            else 
            {
                itaxid = 0; itaxidUD = 0;
            }
            //// OLD RULE

            //if (LandTypeId == 1)
            //{
            //    itaxid = 1; itaxidUD = 8;
            //}
            //else if (LandTypeId == 2)
            //{
            //    itaxid = 2; itaxidUD = 9;
            //}
            //else if (LandTypeId == 3)
            //{
            //    itaxid = 3; itaxidUD = 71;
            //}
            //else if (LandTypeId == 4)
            //{
            //    itaxid = 50; itaxidUD = 72;
            //}
            //else if (LandTypeId == 5)
            //{
            //    itaxid = 51; itaxidUD = 73;
            //}


            // GENERATE TOKEN START
            //var token1 = await tokenService.GetToken();
            // GENERATE TOKEN END 
            //DATA PULL START
            var RMSYear = "";
            List<LandOwneshipModel> LandTransactionList = new List<LandOwneshipModel>();
            //List<LandTransactionDetail> TransferrorList = new List<LandTransactionDetail>();
            try
            {
                //TransactionID = "14170920";
                using (var httpClient = new HttpClient())
                {
                    //httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", "812c2d79-36f4-3610-937c-6363d8e18b2d".ToString());
                   // using (var response = await httpClient.GetAsync("https://revenue.thimphucity.bt:84/api/Service/GetLastPaymentDetail?" + "TPID=" + TaxPayerId + "&LandDetailsID=" + LandDetailId))
                   using (var response = await httpClient.GetAsync("http://202.144.146.163:84/api/Service/GetLastPaymentDetail?" + "TPID=" + TaxPayerId + "&LandDetailsID=" + LandDetailId))
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
                                     RMSYear = details["calenderYear"].ToString();

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
            //return LandTransactionList.ToList();

            var effectiveDate = ctx.MstSlab.Where(u => u.TaxId == Convert.ToInt32(itaxid) && u.LandUseSubCategoryId == LndUseSubCtgyID).Max(u => u.EffectiveDate);
            var SlabData = (ctx.MstSlab.Where(x => x.LandUseSubCategoryId == LndUseSubCtgyID && x.TaxId == itaxid && x.EffectiveDate== effectiveDate));// make tax id dynamic
            var slabid = SlabData.FirstOrDefault().SlabId;
            var RateData = (ctx.MstRate.Where(x => x.SlabId == slabid && x.TaxId == itaxid));// make tax id dynamic
            var Rate = RateData.FirstOrDefault().Rate;
            ////var MidWay = (LandAcerage * (100 - LandPoolingRate) * OwnershipPercentage);
            //var MidWay = (dPLR * (100 - LandPoolingRate) * OwnershipPercentage);
            //var LandTaxAmount1 = (Rate * MidWay / 10000);
            var LandTaxAmount = (Rate * dPLR );
            //****************************LAND TAX CALCULATION END**************************
            //***************************BUILDING Tax START***************************************
            var StrAvailable = landData.StructureAvailable;
             decimal UDTax =0;
            if (StrAvailable == false)
            {
                var effectiveDateUD = ctx.MstSlab.Where(u => u.TaxId == itaxidUD).Max(u => u.EffectiveDate);               
                var SlabDataUD = (ctx.MstSlab.Where(x => x.TaxId == itaxidUD && x.EffectiveDate == effectiveDateUD));// make tax id dynamic
                var slabidUD = SlabDataUD.FirstOrDefault().SlabId;
                var RateDataUD = (ctx.MstRate.Where(x => x.SlabId == slabidUD && x.TaxId == itaxidUD));// make tax id dynamic
                var RateUD = RateDataUD.FirstOrDefault().Rate;
                if (LndUseSubCtgyID == 21 || LndUseSubCtgyID == 26)
                {
                    UDTax = 0;
                }
                else
                {
                    UDTax = Convert.ToDecimal((RateUD * LandTaxAmount));
                }
            }
           

            //***************************BUILDING Tax START***************************************

            var data = (
                       from z in ctx.MstLandDetail.Where(x => x.LandDetailId == LandDetailId)
                    //   join xx in ctx.EnumLandOwnershipType on x.LandOwnershipTypeId equals xx.LandOwnershipTypeId
                      // join y in ctx.MstTaxPayerProfile on x.TaxPayerId equals y.TaxPayerId
                      // join y1 in ctx.EnumTaxPayerType on y.TaxPayerTypeId equals y1.TaxPayerTypeId
                      // join y2 in ctx.EnumTitle on y.TitleId equals y2.TitleId
                       //join z in ctx.MstLandDetail on x.LandDetailId equals z.LandDetailId
                       join zl in ctx.MstLap on z.LapId equals zl.LapId
                       join zd in ctx.MstDemkhong on z.DemkhongId equals zd.DemkhongId
                       join zs in ctx.MstStreetName on z.StreetNameId equals zs.StreetNameId
                       join zlt in ctx.MstLandType on z.LandTypeId equals zlt.LandTypeId
                       join zp in ctx.MstLandUseSubCategory on z.LandUseSubCategoryId equals zp.LandUseSubCategoryId
                       join zps in ctx.MstLandUseCategory on zp.LandUseCategoryId equals zps.LandUseCategoryId

                      //where y.Cid==Cid && z.PlotNo== PlotNo
                      select new LandOwneshipModel
                       {
                          //StructureAvailable = z.StructureAvailable,
                          ThramNo = vThramNo,
                          LandDetailId = z.LandDetailId,
                          LandTypeId = z.LandTypeId,
                          TaxPayerId = TaxPayerId,
                          LandUseCategory = zps.LandUseCategory,
                          PlotNo = z.PlotNo,
                           LandAcerage = z.LandAcerage,
                           LandPoolingRate = z.LandPoolingRate,
                           PlotAddress = z.PlotAddress,
                           Location = z.Location,
                           StructureAvailable = z.StructureAvailable,
                           LapName = zl.LapName,
                           DemkhongName = zd.DemkhongName,
                           StreetName = zs.StreetName,
                           LandTypeName = zlt.LandTypeName,
                           LandUseSubCategory = zp.LandUseSubCategory,
                           LandTaxAmount=LandTaxAmount,
                           UDTax = UDTax,
                          TaxidUD= itaxidUD,
                          Plr = dPLR,
                          LandOwnershipType= LandOwnershipType,
                          LandTaxRate = Rate,
                          LandOwnershipId = LandOwershipId,
                          RmsYear = RMSYear
                      }

                       ).ToList();

            return data.ToList();


        }
        public IList<BuildingTaxVM> GetBuildingTaxDetail(int LandOwnershipId)
        {
            //****************************LAND TAX CALCULATION**************************
            var landOwnershipData = (ctx.TblLandOwnershipDetail.Where(x => x.LandOwnershipId == LandOwnershipId));
            var LandDetailId = landOwnershipData.FirstOrDefault().LandDetailId;
            var TaxPayerId = landOwnershipData.FirstOrDefault().TaxPayerId;
            var LandOwnerShipId = landOwnershipData.FirstOrDefault().LandOwnershipId;
            var OwnershipPercentage = landOwnershipData.FirstOrDefault().OwnershipPercentage;
            var LandOwnershipTypeId = landOwnershipData.FirstOrDefault().LandOwnershipTypeId;

            var landData = (ctx.MstLandDetail.Where(x => x.LandDetailId == LandDetailId));
            //***************************BUILDING Tax START***************************************
            var StrAvailable = landData.FirstOrDefault().StructureAvailable;
           // var data = (dynamic)null;
            if (LandOwnershipTypeId == 5 || LandOwnershipTypeId == 1)
            {


                var data = (from x in ctx.MstBuildingDetail.Where(x => x.LandDetailId == LandDetailId)
                            join c in ctx.MstConstructionType on x.ConstructionTypeId equals c.ConstructionTypeId
                            join y in ctx.MstBuildingUnitDetail on x.BuildingDetailId equals y.BuildingDetailId
                            join u in ctx.MstBuildingUnitClass on y.BuildingUnitClassId equals u.BuildingUnitClassId
                            join ut in ctx.MstBuildingUnitUseType on y.BuildingUnitUseTypeId equals ut.BuildingUnitUseTypeId

                            let UniTTaxId =
                                             (
                                                y.BuildingUnitUseTypeId == 1 ? "4" :
                                                 y.BuildingUnitUseTypeId == 2 ? "5" :
                                                 y.BuildingUnitUseTypeId == 3 ? "6" :
                                                 y.BuildingUnitUseTypeId == 4 ? "7" :
                                                 y.BuildingUnitUseTypeId == 5 ? "55" :
                                                 y.BuildingUnitUseTypeId == 6 ? "58" : "0"
                                             )
                            let GarbageTaxId =
                             (
                                                y.BuildingUnitUseTypeId == 1 ? "10" :
                                                 y.BuildingUnitUseTypeId == 2 ? "11" :
                                                 y.BuildingUnitUseTypeId == 3 ? "63" :
                                                 y.BuildingUnitUseTypeId == 4 ? "64" :
                                                 y.BuildingUnitUseTypeId == 5 ? "65" :
                                                 y.BuildingUnitUseTypeId == 6 ? "66" : "0"
                             )
                            let StreetLightTaxId =
                           (
                            y.BuildingUnitUseTypeId == 1 ? "12" :
                                  y.BuildingUnitUseTypeId == 2 ? "13" :
                                  y.BuildingUnitUseTypeId == 3 ? "67" :
                                  y.BuildingUnitUseTypeId == 4 ? "68" :
                                  y.BuildingUnitUseTypeId == 5 ? "69" :
                                  y.BuildingUnitUseTypeId == 6 ? "70" : "0"
                           )
                            let effectiveDate = ctx.MstSlab.Where(u => u.TaxId == Convert.ToInt32(UniTTaxId)).Max(u => u.EffectiveDate)
                            let slbid = ctx.MstSlab.Where(xx => xx.TaxId == Convert.ToInt32(UniTTaxId) && xx.ConstructionTypeId == x.ConstructionTypeId && xx.BuildingUnitClassId == y.BuildingUnitClassId && xx.BuildingUnitUseTypeId == y.BuildingUnitUseTypeId && xx.EffectiveDate == effectiveDate).FirstOrDefault().SlabId
                            let slabIdGarbage = ctx.MstSlab.Where(xx => xx.TaxId == Convert.ToInt32(GarbageTaxId) && xx.ConstructionTypeId == x.ConstructionTypeId && xx.BuildingUnitClassId == y.BuildingUnitClassId && xx.BuildingUnitUseTypeId == y.BuildingUnitUseTypeId && xx.EffectiveDate == effectiveDate).FirstOrDefault().SlabId
                            let slabIdStreetLight = ctx.MstSlab.Where(xx => xx.TaxId == Convert.ToInt32(StreetLightTaxId) && xx.ConstructionTypeId == x.ConstructionTypeId && xx.BuildingUnitClassId == y.BuildingUnitClassId && xx.BuildingUnitUseTypeId == y.BuildingUnitUseTypeId && xx.EffectiveDate == effectiveDate).FirstOrDefault().SlabId

                            where y.TaxPayerId == TaxPayerId
                            orderby x.LandDetailId ascending, x.BuildingDetailId

                            select new BuildingTaxVM
                            {
                                BuildingDetailId = x.BuildingDetailId,
                                BuildingNo = x.BuildingNo,
                                BuildupArea = x.BuildupArea,
                                LandOwnerShipId = LandOwnerShipId,
                                NumberOfFloors = x.NumberOfFloors,
                                TaxPayerId = y.TaxPayerId,
                                NoOfUnit = y.NoOfUnit,
                                NoOfrooms = y.NoOfrooms,
                                ConstructionTypeId = x.ConstructionTypeId,
                                ConstructionType = c.ConstructionType,
                                BuildingUnitClassId = y.BuildingUnitClassId,
                                BuildingUnitClass = u.BuildingUnitClassName,
                                BuildingUnitUseTypeId = y.BuildingUnitUseTypeId,
                                BuildingUnitUseType = ut.BuildingUnitUseType,
                                FloorNameId = y.FloorNameId,
                                FloorNo = y.FloorNo,
                                FloorArea = y.FloorArea,
                                EffectiveDate = effectiveDate,
                                UnitOwnerTypeId = y.UnitOwnerTypeId,
                                SlabId = slbid,
                                UnitTaxId = Convert.ToInt32(UniTTaxId),
                                GarbageTaxId = Convert.ToInt32(GarbageTaxId),
                                StreetLightTaxId = Convert.ToInt32(StreetLightTaxId),
                                UnitTaxRate = StrAvailable == true ? (y.IsRegularized == true ? (ctx.MstRate.Where(xy => xy.TaxId == Convert.ToInt32(UniTTaxId) && xy.SlabId == slbid).FirstOrDefault().Rate)  : 0) : 0,
                                UnitTax = StrAvailable == true ? (y.IsRegularized == true ? (ctx.MstRate.Where(xy => xy.TaxId == Convert.ToInt32(UniTTaxId) && xy.SlabId == slbid).FirstOrDefault().Rate)* y.NoOfUnit : 0) : 0,
                                GarbageTaxRate = StrAvailable == true ? (y.IsRegularized == true ? (ctx.MstRate.Where(xy => xy.TaxId == Convert.ToInt32(GarbageTaxId) && xy.SlabId == slabIdGarbage).FirstOrDefault().Rate) : 0) : 0,
                                GarbageTax = StrAvailable == true ? (y.IsRegularized == true ? (ctx.MstRate.Where(xy => xy.TaxId == Convert.ToInt32(GarbageTaxId) && xy.SlabId == slabIdGarbage).FirstOrDefault().Rate) * y.NoOfUnit : 0) * 12 : 0,
                                StreetLightTaxRate = StrAvailable == true ? (y.IsRegularized == true ? (ctx.MstRate.Where(xy => xy.TaxId == Convert.ToInt32(StreetLightTaxId) && xy.SlabId == slabIdStreetLight).FirstOrDefault().Rate) : 0) : 0,
                                StreetLightTax = StrAvailable == true ? (y.IsRegularized == true ? (ctx.MstRate.Where(xy => xy.TaxId == Convert.ToInt32(StreetLightTaxId) && xy.SlabId == slabIdStreetLight).FirstOrDefault().Rate) * y.NoOfUnit * 12 : 0) : 0

                            }).ToList();
                return data.ToList();
            }
            else
            {
                var data = (from x in ctx.MstBuildingDetail.Where(x => x.LandDetailId == LandDetailId)
                            join c in ctx.MstConstructionType on x.ConstructionTypeId equals c.ConstructionTypeId
                            join y in ctx.MstBuildingUnitDetail on x.BuildingDetailId equals y.BuildingDetailId
                            join u in ctx.MstBuildingUnitClass on y.BuildingUnitClassId equals u.BuildingUnitClassId
                            join ut in ctx.MstBuildingUnitUseType on y.BuildingUnitUseTypeId equals ut.BuildingUnitUseTypeId
                            where y.TaxPayerId != 100024
                            let UniTTaxId =
                                             (
                                               y.BuildingUnitUseTypeId == 1 ? "4" :
                                               y.BuildingUnitUseTypeId == 2 ? "5" :
                                               y.BuildingUnitUseTypeId == 3 ? "6" :
                                               y.BuildingUnitUseTypeId == 4 ? "7" :
                                               y.BuildingUnitUseTypeId == 5 ? "55" :
                                               y.BuildingUnitUseTypeId == 6 ? "58" : "0"
                                             )
                            let GarbageTaxId =
                             (
                                                y.BuildingUnitUseTypeId == 1 ? "10" :
                                                 y.BuildingUnitUseTypeId == 2 ? "11" :
                                                 y.BuildingUnitUseTypeId == 3 ? "63" :
                                                 y.BuildingUnitUseTypeId == 4 ? "64" :
                                                 y.BuildingUnitUseTypeId == 5 ? "65" :
                                                 y.BuildingUnitUseTypeId == 6 ? "66" : "0"
                             )
                            let StreetLightTaxId =
                           (
                            y.BuildingUnitUseTypeId == 1 ? "12" :
                                  y.BuildingUnitUseTypeId == 2 ? "12" :
                                  y.BuildingUnitUseTypeId == 3 ? "12" :
                                  y.BuildingUnitUseTypeId == 4 ? "12" :
                                  y.BuildingUnitUseTypeId == 5 ? "12" :
                                  y.BuildingUnitUseTypeId == 6 ? "12" : "0"
                           )
                            let effectiveDate = ctx.MstSlab.Where(u => u.TaxId == Convert.ToInt32(UniTTaxId)).Max(u => u.EffectiveDate)
                            let slbid = ctx.MstSlab.Where(xx => xx.TaxId == Convert.ToInt32(UniTTaxId) && xx.ConstructionTypeId == x.ConstructionTypeId && xx.BuildingUnitClassId == y.BuildingUnitClassId && xx.BuildingUnitUseTypeId == y.BuildingUnitUseTypeId && xx.EffectiveDate == effectiveDate).FirstOrDefault().SlabId
                            let slabIdGarbage = ctx.MstSlab.Where(xx => xx.TaxId == Convert.ToInt32(GarbageTaxId) && xx.ConstructionTypeId == x.ConstructionTypeId && xx.BuildingUnitClassId == y.BuildingUnitClassId && xx.BuildingUnitUseTypeId == y.BuildingUnitUseTypeId && xx.EffectiveDate == effectiveDate).FirstOrDefault().SlabId
                            let slabIdStreetLight = ctx.MstSlab.Where(xx => xx.TaxId == Convert.ToInt32(StreetLightTaxId) && xx.ConstructionTypeId == x.ConstructionTypeId && xx.BuildingUnitClassId == y.BuildingUnitClassId && xx.BuildingUnitUseTypeId == y.BuildingUnitUseTypeId && xx.EffectiveDate == effectiveDate).FirstOrDefault().SlabId
                            //  where y.IsRegularized == true
                            orderby x.LandDetailId ascending, x.BuildingDetailId

                            select new BuildingTaxVM
                            {
                                BuildingDetailId = x.BuildingDetailId,
                                BuildingNo = x.BuildingNo,
                                BuildupArea = x.BuildupArea,
                                NumberOfFloors = x.NumberOfFloors,
                                TaxPayerId = y.TaxPayerId,
                                NoOfUnit = y.NoOfUnit,
                                NoOfrooms = y.NoOfrooms,
                                ConstructionTypeId = x.ConstructionTypeId,
                                ConstructionType = c.ConstructionType,
                                BuildingUnitClassId = y.BuildingUnitClassId,
                                BuildingUnitClass = u.BuildingUnitClassName,
                                BuildingUnitUseTypeId = y.BuildingUnitUseTypeId,
                                BuildingUnitUseType = ut.BuildingUnitUseType,
                                FloorNameId = y.FloorNameId,
                                FloorNo = y.FloorNo,
                                FloorArea = y.FloorArea,
                                EffectiveDate = effectiveDate,
                                UnitOwnerTypeId = y.UnitOwnerTypeId,
                                SlabId = slbid,
                                SlabIdGarbage = slabIdGarbage,
                                SlabIdStreetLight = slabIdStreetLight,
                                UnitTaxId = Convert.ToInt32(UniTTaxId),
                                GarbageTaxId = Convert.ToInt32(GarbageTaxId),
                                StreetLightTaxId = Convert.ToInt32(StreetLightTaxId),
                                LandOwnerShipId = LandOwnerShipId,
                                UnitTaxRate = StrAvailable == true ? (y.IsRegularized == true ? (ctx.MstRate.Where(xy => xy.TaxId == Convert.ToInt32(UniTTaxId) && xy.SlabId == slbid).FirstOrDefault().Rate) : 0) : 0,
                                UnitTax = StrAvailable == true ? (y.IsRegularized == true ? (ctx.MstRate.Where(xy => xy.TaxId == Convert.ToInt32(UniTTaxId) && xy.SlabId == slbid).FirstOrDefault().Rate) * y.NoOfUnit : 0) : 0,
                                GarbageTaxRate = StrAvailable == true ? (y.IsRegularized == true ? (ctx.MstRate.Where(xy => xy.TaxId == Convert.ToInt32(GarbageTaxId) && xy.SlabId == slabIdGarbage).FirstOrDefault().Rate) : 0) : 0,
                                GarbageTax = StrAvailable == true ? (y.IsRegularized == true ? (ctx.MstRate.Where(xy => xy.TaxId == Convert.ToInt32(GarbageTaxId) && xy.SlabId == slabIdGarbage).FirstOrDefault().Rate) * y.NoOfUnit * 12 : 0) : 0,
                                StreetLightTaxRate = StrAvailable == true ? (y.IsRegularized == true ? (ctx.MstRate.Where(xy => xy.TaxId == Convert.ToInt32(StreetLightTaxId) && xy.SlabId == slabIdStreetLight).FirstOrDefault().Rate) : 0) : 0,
                                StreetLightTax = StrAvailable == true ? (y.IsRegularized == true ? (ctx.MstRate.Where(xy => xy.TaxId == Convert.ToInt32(StreetLightTaxId) && xy.SlabId == slabIdStreetLight).FirstOrDefault().Rate) * y.NoOfUnit * 12 : 0) : 0

                            }).ToList();
                return data.ToList();
        }
    }
        public string CreateLandTax(List<GenerateAllPropertyTaxModel> json_data)
        {
            
            try
            {
                using TransactionScope s = new TransactionScope();
                var fyr = ctx.MstFinancialYear.Where(x => x.StartDate <= DateTime.Today && x.EndDate >= DateTime.Today).Max(x => x.FinancialYearId);// make default check at startup
                int cyr = ctx.MstCalendarYear.Where(x => x.StartDate <= DateTime.Today && x.EndDate >= DateTime.Today).Max(xx => xx.CalendarYearId);// make default check at startup


                foreach (var items in json_data)
                {

                    var dataCheck = ctx.TblDemand.Where(x => x.CalendarYearId == items.CalendarYearId && x.TaxPayerId == items.TaxPayerId && x.LandOwnershipId == items.LandOwnershipId && x.LandDetailId == json_data.FirstOrDefault().LandDetailId);
                    if (dataCheck.Any())
                    {
                        return "Tax already generated for Plot " + items.PlotNo + " for the year" + items.CalendarYear;
                    }
                }

                    int? sq = ctx.TblDemandNo.Where(x => x.DemandYear == Convert.ToInt32(DateTime.Now.Year)).Max(x => x.Sl);
                    sq = sq == null ? 0 : ctx.TblDemandNo.Where(x => x.DemandYear == Convert.ToInt32(DateTime.Now.Year)).Max(x => x.Sl);
                    sq = sq + 1;
                    var LandTaxData = json_data.AsQueryable().Where(d=>d.PType == 1 ).OrderBy(o=> o.LandDetailId).ToList();

                foreach (var itemL in LandTaxData)
                    {
                    long transactionId; decimal TotalLandWiseAmount = 0;
                    TotalLandWiseAmount += itemL.LandTaxAmount +itemL.UDTaxAmount;

                                    var entityTRn = new TblTransactionDetail
                                    {
                                        TransactionTypeId = 20,
                                        WorkLevelId = 3,
                                        TransactionValue = 0,
                                        CreatedBy = itemL.CreatedBy,
                                        CreatedOn = DateTime.Now,
                                        TaxPayerId = itemL.TaxPayerId
                                    };
                                    ctx.TblTransactionDetail.Add(entityTRn);
                                    ctx.SaveChanges();
                                    transactionId = entityTRn.TransactionId;

                                    long dnid;
                                    var entityDN = new TblDemandNo
                                    {
                                        DemandNo = ("TTDN/" + (DateTime.Now.Year) + "/" + sq),
                                        Sl = (int)sq,
                                        DemandYear = DateTime.Now.Year,
                                        CreatedBy = itemL.CreatedBy,
                                        CreatedOn = DateTime.Now,
                                    };
                                    ctx.TblDemandNo.Add(entityDN);
                                    ctx.SaveChanges();
                                    dnid = entityDN.DemandNoId;
                                    var entity = new TblDemand
                                    {
                                        TransactionId = transactionId,
                                        DemandNoId = dnid,
                                        TaxId = itemL.LandTaxId,
                                        FinancialYearId = Convert.ToInt32(fyr),
                                        CalendarYearId = itemL.CalendarYearId,
                                        DemandAmount = itemL.LandTaxAmount,
                                        TotalAmount = itemL.LandTaxAmount,
                                        LandDetailId = itemL.LandDetailId,
                                        LandOwnershipId = itemL.LandOwnershipId,
                                        TaxPayerId = itemL.TaxPayerId,
                                        CreatedBy = itemL.CreatedBy,
                                        CreatedOn = DateTime.Now,
                                        BillingDate = DateTime.Now,
                                    };
                                    ctx.TblDemand.Add(entity);
                                    ctx.SaveChanges();
                    if(itemL.UDTaxApplicable == "Yes")
                    {

                        var entityUd = new TblDemand
                        {
                            TransactionId = transactionId,
                            DemandNoId = dnid,
                            TaxId = itemL.UDTaxId,
                            FinancialYearId = Convert.ToInt32(fyr),
                            CalendarYearId = itemL.CalendarYearId,
                            DemandAmount = itemL.UDTaxAmount,
                            TotalAmount = itemL.UDTaxAmount,
                            LandDetailId = itemL.LandDetailId,
                            LandOwnershipId = itemL.LandOwnershipId,
                            TaxPayerId = itemL.TaxPayerId,
                            CreatedBy = itemL.CreatedBy,
                            CreatedOn = DateTime.Now,
                            BillingDate = DateTime.Now,
                        };
                        ctx.TblDemand.Add(entity);
                        ctx.SaveChanges();

                      
                    }

                    var UnitTaxData = json_data.AsQueryable().Where(d => d.PType == 2 && d.LandDetailId==itemL.LandDetailId).OrderBy(o => o.LandDetailId).ToList();
                    foreach (var itemU in UnitTaxData)
                        {
                        TotalLandWiseAmount += itemU.UTHAmount+itemU.GarbageAmount+itemU.StreetLightAmount;
                        var entityU = new TblDemand
                            {
                                TransactionId = transactionId,
                                DemandNoId = dnid,
                                TaxId = itemU.UnitTaxId,
                                FinancialYearId = Convert.ToInt32(fyr),
                                CalendarYearId = itemU.CalendarYearId,
                                DemandAmount = itemU.UTHAmount,
                                TotalAmount = itemU.UTHAmount,
                                LandDetailId = itemU.LandDetailId,
                                LandOwnershipId = itemU.LandOwnershipId,
                                TaxPayerId = itemU.TaxPayerId,
                                CreatedBy = itemU.CreatedBy,
                                CreatedOn = DateTime.Now,
                                BillingDate = DateTime.Now,
                            };
                            ctx.TblDemand.Add(entityU);
                            ctx.SaveChanges();

                        var entityG = new TblDemand
                        {
                            TransactionId = transactionId,
                            DemandNoId = dnid,
                            TaxId = itemU.GarbageTaxId,
                            FinancialYearId = Convert.ToInt32(fyr),
                            CalendarYearId = itemU.CalendarYearId,
                            DemandAmount = itemU.GarbageAmount,
                            TotalAmount = itemU.GarbageAmount,
                            LandDetailId = itemU.LandDetailId,
                            LandOwnershipId = itemU.LandOwnershipId,
                            TaxPayerId = itemU.TaxPayerId,
                            CreatedBy = itemU.CreatedBy,
                            CreatedOn = DateTime.Now,
                            BillingDate = DateTime.Now,
                        };
                        ctx.TblDemand.Add(entityG);
                        ctx.SaveChanges();

                        var entityS = new TblDemand
                        {
                            TransactionId = transactionId,
                            DemandNoId = dnid,
                            TaxId = itemU.StreetLightTaxId,
                            FinancialYearId = Convert.ToInt32(fyr),
                            CalendarYearId = itemU.CalendarYearId,
                            DemandAmount = itemU.StreetLightAmount,
                            TotalAmount = itemU.StreetLightAmount,
                            LandDetailId = itemU.LandDetailId,
                            LandOwnershipId = itemU.LandOwnershipId,
                            TaxPayerId = itemU.TaxPayerId,
                            CreatedBy = itemU.CreatedBy,
                            CreatedOn = DateTime.Now,
                            BillingDate = DateTime.Now,
                        };
                        ctx.TblDemand.Add(entityS);
                        ctx.SaveChanges();
                    }
                    var Data = ctx.TblTransactionDetail.FirstOrDefault(u => u.TransactionId == transactionId);
                    Data.TransactionValue = TotalLandWiseAmount;                 
                    ctx.SaveChanges();
                }
                                                    
                s.Complete();
                s.Dispose();

                return "Tax Successfully generated for selected year";
            }
            catch (Exception ex) {
                return ex.ToString();
            }
        }
        
        //***************************BUILDING Tax end***************************************
        public byte[] GenerateQr(string txtQRCode)
        {
            QRCodeGenerator _qrCode = new QRCodeGenerator();
            QRCodeData _qrCodeData = _qrCode.CreateQrCode(txtQRCode, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(_qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(20);
            return  BitmapToBytesCode(qrCodeImage);
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
        public IList<LedgerDemandVM> GetGeneratedDemand(long DemandNoId)
        {
            try
            {
                var dataTaxPeriod = ctx.MstTaxPeriod.Where(x => x.TransactionTypeId == 20);
                var PenaltyPercentage = dataTaxPeriod.FirstOrDefault().PenaltyOrRate;
                var DataDemand = ctx.TblDemand.Where(x => x.DemandNoId == DemandNoId);
                var CalenderYrId = DataDemand.FirstOrDefault().CalendarYearId;
                var DataCalendarYear = ctx.MstCalendarYear.Where(x => x.CalendarYearId == CalenderYrId);
                var CalYrEndDate = DataCalendarYear.FirstOrDefault().EndDate;
                var datediff = (DateTime.Now - CalYrEndDate).Days;
                if (datediff < 0)
                {
                    datediff = 0;
                }
                //h20
                var WdataTaxPeriod = ctx.MstTaxPeriod.Where(x => x.TransactionTypeId == 19);
                var WPenaltyPercentage = dataTaxPeriod.FirstOrDefault().PenaltyOrRate;
                var WDataDemand = ctx.TblDemand.Where(x => x.DemandNoId == DemandNoId);
                var WCalenderYrId = DataDemand.FirstOrDefault().CalendarYearId;
                var WDataCalendarYear = ctx.MstCalendarYear.Where(x => x.CalendarYearId == CalenderYrId);
                var WCalYrEndDate = DataCalendarYear.FirstOrDefault().EndDate;
                //var Wdatediff = (DateTime.Now - CalYrEndDate).Days;
                //if (datediff < 0)
                //{
                //    Wdatediff = 0;
                //}

                var dn = ctx.TblDemandNo.Where(d => d.DemandNoId == DemandNoId).Max(x => x.DemandNo);

                var data = (
                           from x in ctx.TblDemand.Where(x => x.TotalAmount != 0 && x.DemandNoId == DemandNoId)
                           join xx in ctx.TblDemandNo on x.DemandNoId equals xx.DemandNoId
                           join y in ctx.MstTaxMaster on x.TaxId equals y.TaxId
                           join z in ctx.TblTransactionDetail on x.TransactionId equals z.TransactionId
                           join z1 in ctx.MstTransactionType on z.TransactionTypeId equals z1.TransactionTypeId
                           join t in ctx.MstTaxPayerProfile on x.TaxPayerId equals t.TaxPayerId
                           //join et in ctx.EnumTitle on t.TitleId equals et.TitleId
                           join u in ctx.AspNetUsers on x.CreatedBy equals u.UserId
                           join c in ctx.MstCalendarYear on x.CalendarYearId equals c.CalendarYearId
                           //join zlt in ctx.MstLandType on z.LandTypeId equals zlt.LandTypeId
                           //join zp in ctx.MstLandUseSubCategory on z.LandUseSubCategoryId equals zp.LandUseSubCategoryId
                           let pno = ctx.MstLandDetail.Where(p => p.LandDetailId == x.LandDetailId).Max(p1 => p1.PlotNo)
                           let thno = ctx.TblLandOwnershipDetail.Where(o => o.LandDetailId == x.LandDetailId && o.TaxPayerId == x.TaxPayerId).Max(o1 => o1.ThramNo)
                           let Total = ctx.TblDemand.Where(d => d.DemandNoId == DemandNoId).Sum(dn => dn.TotalAmount)
                           let qr = GenerateQr(dn.ToString())
                           // let penalty = (Convert.ToDecimal(PenaltyPercentage) * (Total) * Convert.ToInt32(datediff) / 365)
                           select new LedgerDemandVM
                           {
                               CalendarYear = c.CalendarYear,
                               UserName = (u.FirstName + " " + ((u.MiddleName == null || u.MiddleName.Trim() == string.Empty) ? string.Empty : (u.MiddleName + " ")) + ((u.LastName == null || u.LastName.Trim() == string.Empty) ? string.Empty : (u.LastName + " "))),//(u.FirstName + "" + u.MiddleName + "" + u.LastName),
                               Caddress = t.CAddress,
                               Cid = t.Cid,
                               Ttin = t.Ttin,
                               PlotNo = pno,
                               ThramNo = thno,
                               TaxId = x.TaxId,
                               DemandAmount = x.DemandAmount,
                               TotalAmount = x.TotalAmount,
                               DemandNo = xx.DemandNo,
                               CreatedOn = x.CreatedOn,
                               TransactionType = z1.TransactionType,
                               TaxName = y.TaxName,
                               TotalAmountDemand = Total,
                               QrImage = qr,
                               FullName = (t.FirstName + " " + ((t.MiddleName == null || t.MiddleName.Trim() == string.Empty) ? string.Empty : (t.MiddleName + " ")) + ((t.LastName == null || t.LastName.Trim() == string.Empty) ? string.Empty : (t.LastName + " "))),

                               //  FullName = (et.Title + " " + t.FirstName + " " + t.MiddleName + " " + t.LastName),
                               PenaltyAmount = 0//penalty
                           }

                           ).ToList();
           

            return data.ToList();

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public IList<LedgerDemandVM> CheckDuplicateTax(int OwnershipId, int CalendarYearId)
        {
            var data = (from a in ctx.TblDemand.Where(x =>x.LandOwnershipId == OwnershipId && x.CalendarYearId == CalendarYearId)
                        join b in ctx.TblTransactionDetail on a.TransactionId equals b.TransactionId
                        where b.TransactionTypeId==20
                        select new LedgerDemandVM
                        {
                            DemandNoId=a.DemandNoId,
                            TransactionTypeId=b.TransactionTypeId,
                            TaxPayerId = a.TaxPayerId,
                            LandDetailId = a.LandDetailId,
                            CalendarYearId = a.CalendarYearId,
                            TotalAmount = a.TotalAmount,
                           
                        });
            return data.Distinct().ToList();
        }

      
    }
}
