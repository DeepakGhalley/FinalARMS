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
    public class PropertyTaxBLL : IPropertyTax
    {
        readonly tt_dbContext ctx = new tt_dbContext();
        private readonly ITokenService tokenService;
        string _GetLastPaymentDetailsURL = "";

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
                      join pt in ctx.EnumPropertyType on z.PropertyTypeId equals pt.PropertyTypeId
                      where z.PropertyTypeId==1 || z.PropertyTypeId == 3 && x.IsActive==true 
                      orderby x.LandDetailId
                      //where y.Cid==Cid && z.PlotNo== PlotNo
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
                          PropertyType = pt.PropertyType,
                          LandPoolingRate =z.LandPoolingRate,
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
            var data = (from a in ctx.MstTaxPayerProfile.Where(x => 1==1)
                        join b in ctx.EnumTitle on a.TitleId equals b.TitleId
                        join tt in ctx.EnumTaxPayerType on a.TaxPayerTypeId equals tt.TaxPayerTypeId
                        join c in ctx.TblLandOwnershipDetail on a.TaxPayerId equals c.TaxPayerId
                        join d in ctx.MstLandDetail on c.LandDetailId equals d.LandDetailId
                        where (d.PropertyTypeId==1 || d.PropertyTypeId == 3) && (d.PlotNo == PlotNo ||  c.ThramNo == ThramNo || a.Cid == Cid || a.Ttin == Ttin)
                        //var data = (from c in ctx.TblLandOwnershipDetail

                        //            join a in ctx.MstTaxPayerProfile on c.TaxPayerId equals a.TaxPayerId
                        //            join b in ctx.EnumTitle on a.TitleId equals b.TitleId

                        //            join tt in ctx.EnumTaxPayerType on a.TaxPayerTypeId equals tt.TaxPayerTypeId

                        //            join d in ctx.MstLandDetail on c.LandDetailId equals d.LandDetailId
                        //            where (string.IsNullOrEmpty(PlotNo) || d.PlotNo == PlotNo) && (string.IsNullOrEmpty(ThramNo) || c.ThramNo == ThramNo)

                        select new LandOwneshipModel
                        {
                            TaxPayerId=a.TaxPayerId,
                            Cid = a.Cid,
                            Ttin = a.Ttin,
                            TitleId = a.TitleId,
                            Title = b.Title,
                            FirstName = a.FirstName,
                            MiddleName = a.MiddleName,
                            LastName = a.LastName,
                            FullName=(a.FirstName+" "+ ((a.MiddleName == null || a.MiddleName.Trim() == string.Empty) ? string.Empty : (a.MiddleName + " ")) + ((a.LastName == null || a.LastName.Trim() == string.Empty) ? string.Empty : (a.LastName + " "))),
                            TaxPayerTypeId = a.TaxPayerTypeId,
                            TaxPayerType=tt.TaxPayerType,
                            MobileNo=a.MobileNo,
                            Email=a.Email                            
                        });
            return data.Distinct().ToList(); 
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
            if (LndUseSubCtgyID == 1)
            {
                itaxid = 2; itaxidUD = 9;
            }
            else if (LndUseSubCtgyID == 2)
            {
                itaxid = 2; itaxidUD = 9;
            }
            else if (LndUseSubCtgyID == 3)
            {
                itaxid = 2; itaxidUD = 9;
            }
            else if (LndUseSubCtgyID == 4)
            {
                itaxid = 2; itaxidUD = 9;
            }
            else if (LndUseSubCtgyID == 5)
            {
                itaxid = 2; itaxidUD = 9;
            }
            else if (LndUseSubCtgyID == 6)
            {
                itaxid = 2; itaxidUD = 9;
            }
            else if (LndUseSubCtgyID == 7)
            {
                itaxid = 2; itaxidUD = 9;
            }
            else if (LndUseSubCtgyID == 8)
            {
                itaxid = 2; itaxidUD = 9;
            }
            else if (LndUseSubCtgyID == 9)//
            {
                itaxid = 2; itaxidUD = 9;
            }
            else if (LndUseSubCtgyID == 10)
            {
                itaxid = 2; itaxidUD = 9;
            }
            else if (LndUseSubCtgyID == 11)
            {
                itaxid = 2; itaxidUD = 9;
            }
            //
            else if (LndUseSubCtgyID == 12)
            {
                itaxid = 1; itaxidUD = 8;
            }
            else if (LndUseSubCtgyID == 13)
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
                   using (var response = await httpClient.GetAsync("http://172.24.40.3:84/api/Service/GetLastPaymentDetail?" + "TPID=" + TaxPayerId + "&LandDetailsID=" + LandDetailId))
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
            var BData = (ctx.MstBuildingDetail.Where(x => x.LandDetailId == LandDetailId ));

            var StrAvailable =true;// landData.StructureAvailable;
             decimal UDTax =0;
            if (BData.Count()<=0)
            {
                StrAvailable = false;
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
                          RmsYear = RMSYear,
                          IsApportioned = (bool)z.IsApportioned
                      }

                       ).ToList();

            return data.ToList();


        }
        public IList<BuildingTaxVM> GetBuildingTaxDetail(int LandOwnershipId,int TaxYearId)
        {
            //****************************LAND TAX CALCULATION**************************
            var landOwnershipData = (ctx.TblLandOwnershipDetail.Where(x => x.LandDetailId == LandOwnershipId));
            var LandDetailId = landOwnershipData.FirstOrDefault().LandDetailId;
            var TaxPayerId = landOwnershipData.FirstOrDefault().TaxPayerId;
            var LandOwnerShipId = landOwnershipData.FirstOrDefault().LandOwnershipId;
            var OwnershipPercentage = landOwnershipData.FirstOrDefault().OwnershipPercentage;
            var LandOwnershipTypeId = landOwnershipData.FirstOrDefault().LandOwnershipTypeId;

            //var landData = (ctx.MstLandDetail.Where(x => x.LandDetailId == LandDetailId));
            var StrAvailable = false;
            var BData = (ctx.MstBuildingDetail.Where(x => x.LandDetailId == LandDetailId));
            if (BData.Any())
            {
                StrAvailable = true;
            }


            var Building = (ctx.MstBuildingDetail.Where(x => x.LandDetailId == LandDetailId));
            var Buildingclassid = Building.FirstOrDefault().BuildingClassId;


            //***************************BUILDING Tax START***************************************
            //var StrAvailable = BData.FirstOrDefault().StructureAvailable;
            // var data = (dynamic)null;
            //var sid = (ctx.MstSlab.Where(x => x.Define2 == Buildingclassid));
            //var slabid = sid.FirstOrDefault().SlabId;
            //var rates = (ctx.MstRate.Where(x => x.SlabId == slabid));
            //var rate = rates.FirstOrDefault().Rate;
            var rate = 0;
            if (Buildingclassid == 1)
            {
                rate = 4000;
            }
            else if (Buildingclassid == 2)
            {
                rate = 1000;
            }
            else if (Buildingclassid == 3)
            {
                rate = 200;
            }
            else if (Buildingclassid == 4)
            {
                rate = 100;
            }
            else if (Buildingclassid == 5)
            {
                rate = 2000;
            }
            else if (Buildingclassid == 6)
            {
                rate = 1000;
            }
            else if (Buildingclassid == 7)
            {
                rate = 5000;
            }
            else if (Buildingclassid == 8)
            {
                rate = 7000;
            }
            

            var date = TaxYearId;

            if (date == 2023)
            {
                if (Buildingclassid == 9 || Buildingclassid == 3 || Buildingclassid == 4)
                {
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
                                        BuildingClassId = x.BuildingClassId,
                                        UnitTaxId = Convert.ToInt32(UniTTaxId),
                                        GarbageTaxId = Convert.ToInt32(GarbageTaxId),
                                        StreetLightTaxId = Convert.ToInt32(StreetLightTaxId),
                                        UnitTaxRate = StrAvailable == true ? (y.IsRegularized == true ? (ctx.MstRate.Where(xy => xy.TaxId == Convert.ToInt32(UniTTaxId) && xy.SlabId == slbid).FirstOrDefault().Rate) : 0) : 0,
                                        UnitTax = StrAvailable == true ? (y.IsRegularized == true ? (ctx.MstRate.Where(xy => xy.TaxId == Convert.ToInt32(UniTTaxId) && xy.SlabId == slbid).FirstOrDefault().Rate) * y.NoOfUnit : y.BuildingUnitUseTypeId == 2 ? ((20000 + (20 * y.FloorArea))) : ((20000 + (5 * y.FloorArea)))) : 0,
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
                                                       y.BuildingUnitUseTypeId == 6 ? "58" :
                                                       y.BuildingUnitUseTypeId == 7 ? "93" :
                                                       "0"
                                                     )
                                    let GarbageTaxId =
                                     (
                                                        y.BuildingUnitUseTypeId == 1 ? "10" :
                                                         y.BuildingUnitUseTypeId == 2 ? "11" :
                                                         y.BuildingUnitUseTypeId == 3 ? "63" :
                                                         y.BuildingUnitUseTypeId == 4 ? "64" :
                                                         y.BuildingUnitUseTypeId == 5 ? "65" :
                                                         y.BuildingUnitUseTypeId == 6 ? "66" :
                                                         y.BuildingUnitUseTypeId == 7 ? "11" :
                                                         "0"
                                     )
                                    let StreetLightTaxId =
                                   (
                                    y.BuildingUnitUseTypeId == 1 ? "12" :
                                          y.BuildingUnitUseTypeId == 2 ? "13" :
                                          y.BuildingUnitUseTypeId == 3 ? "67" :
                                          y.BuildingUnitUseTypeId == 4 ? "68" :
                                          y.BuildingUnitUseTypeId == 5 ? "69" :
                                          y.BuildingUnitUseTypeId == 6 ? "70" :
                                          y.BuildingUnitUseTypeId == 7 ? "13" :

                                          "0"
                                   )
                                    let effectiveDate = ctx.MstSlab.Where(u => u.TaxId == Convert.ToInt32(UniTTaxId)).Max(u => u.EffectiveDate)
                                    let slbid = ctx.MstSlab.Where(xx => xx.TaxId == Convert.ToInt32(UniTTaxId) && xx.ConstructionTypeId == x.ConstructionTypeId && xx.BuildingUnitClassId == y.BuildingUnitClassId && xx.BuildingUnitUseTypeId == y.BuildingUnitUseTypeId && xx.EffectiveDate == effectiveDate).FirstOrDefault().SlabId
                                    let slabIdGarbage = ctx.MstSlab.Where(xx => xx.TaxId == Convert.ToInt32(GarbageTaxId) && xx.ConstructionTypeId == x.ConstructionTypeId && xx.BuildingUnitClassId == y.BuildingUnitClassId && xx.BuildingUnitUseTypeId == y.BuildingUnitUseTypeId && xx.EffectiveDate == effectiveDate).FirstOrDefault().SlabId
                                    let slabIdStreetLight = ctx.MstSlab.Where(xx => xx.TaxId == Convert.ToInt32(StreetLightTaxId) && xx.ConstructionTypeId == x.ConstructionTypeId && xx.BuildingUnitClassId == y.BuildingUnitClassId && xx.BuildingUnitUseTypeId == y.BuildingUnitUseTypeId && xx.EffectiveDate == effectiveDate).FirstOrDefault().SlabId
                                    //  where y.IsRegularized == true
                                    where y.TaxPayerId == TaxPayerId
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
                                        BuildingClassId = x.BuildingClassId,
                                        SlabIdGarbage = slabIdGarbage,
                                        SlabIdStreetLight = slabIdStreetLight,
                                        UnitTaxId = Convert.ToInt32(UniTTaxId),
                                        GarbageTaxId = Convert.ToInt32(GarbageTaxId),
                                        StreetLightTaxId = Convert.ToInt32(StreetLightTaxId),
                                        LandOwnerShipId = LandOwnerShipId,
                                        UnitTaxRate = StrAvailable == true ? (y.IsRegularized == true ? (ctx.MstRate.Where(xy => xy.TaxId == Convert.ToInt32(UniTTaxId) && xy.SlabId == slbid).FirstOrDefault().Rate) : 0) : 0,
                                        UnitTax = StrAvailable == true ? (y.IsRegularized == true ? (ctx.MstRate.Where(xy => xy.TaxId == Convert.ToInt32(UniTTaxId) && xy.SlabId == slbid).FirstOrDefault().Rate) * y.NoOfUnit : y.BuildingUnitUseTypeId == 2 ? ((20000 + (20 * y.FloorArea))) : ((20000 + (5 * y.FloorArea)))) : 0,
                                        GarbageTaxRate = StrAvailable == true ? (y.IsRegularized == true ? (ctx.MstRate.Where(xy => xy.TaxId == Convert.ToInt32(GarbageTaxId) && xy.SlabId == slabIdGarbage).FirstOrDefault().Rate) : 0) : 0,
                                        GarbageTax = StrAvailable == true ? (y.IsRegularized == true ? (ctx.MstRate.Where(xy => xy.TaxId == Convert.ToInt32(GarbageTaxId) && xy.SlabId == slabIdGarbage).FirstOrDefault().Rate) * y.NoOfUnit * 12 : 0) : 0,
                                        StreetLightTaxRate = StrAvailable == true ? (y.IsRegularized == true ? (ctx.MstRate.Where(xy => xy.TaxId == Convert.ToInt32(StreetLightTaxId) && xy.SlabId == slabIdStreetLight).FirstOrDefault().Rate) : 0) : 0,
                                        StreetLightTax = StrAvailable == true ? (y.IsRegularized == true ? (ctx.MstRate.Where(xy => xy.TaxId == Convert.ToInt32(StreetLightTaxId) && xy.SlabId == slabIdStreetLight).FirstOrDefault().Rate) * y.NoOfUnit * 12 : 0) : 0

                                    }).ToList();
                        return data.ToList();
                    }
                }
                else {
                    var countb = ctx.MstBuildingDetail.Where(xx => xx.LandDetailId == LandDetailId).Count();
                    var Garbagehalf = (rate * 6) * countb;

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
                            BuildingClassId = x.BuildingClassId,
                            FloorArea = y.FloorArea,
                                    EffectiveDate = effectiveDate,
                                    UnitOwnerTypeId = y.UnitOwnerTypeId,
                                    SlabId = slbid,
                                    Garbage = Garbagehalf,
                                    UnitTaxId = Convert.ToInt32(UniTTaxId),
                                    GarbageTaxId = Convert.ToInt32(GarbageTaxId),
                                    StreetLightTaxId = Convert.ToInt32(StreetLightTaxId),
                                    UnitTaxRate = StrAvailable == true ? (y.IsRegularized == true ? (ctx.MstRate.Where(xy => xy.TaxId == Convert.ToInt32(UniTTaxId) && xy.SlabId == slbid).FirstOrDefault().Rate) : 0) : 0,
                                    UnitTax = StrAvailable == true ? (y.IsRegularized == true ? (ctx.MstRate.Where(xy => xy.TaxId == Convert.ToInt32(UniTTaxId) && xy.SlabId == slbid).FirstOrDefault().Rate) * y.NoOfUnit : y.BuildingUnitUseTypeId == 2 ? ((20000 + (20 * y.FloorArea))) : ((20000 + (5 * y.FloorArea)))) : 0,
                                    GarbageTaxRate = StrAvailable == true ? (y.IsRegularized == true ? (ctx.MstRate.Where(xy => xy.TaxId == Convert.ToInt32(GarbageTaxId) && xy.SlabId == slabIdGarbage).FirstOrDefault().Rate) : 0) : 0,
                                    GarbageTax = StrAvailable == true ? ((y.IsRegularized == true ? (ctx.MstRate.Where(xy => xy.TaxId == Convert.ToInt32(GarbageTaxId) && xy.SlabId == slabIdGarbage).FirstOrDefault().Rate) * y.NoOfUnit : 0) * 6) : 0,
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
                                                   y.BuildingUnitUseTypeId == 6 ? "58" :
                                                   y.BuildingUnitUseTypeId == 7 ? "93" :
                                                   "0"
                                                 )
                                let GarbageTaxId =
                                 (
                                                    y.BuildingUnitUseTypeId == 1 ? "10" :
                                                     y.BuildingUnitUseTypeId == 2 ? "11" :
                                                     y.BuildingUnitUseTypeId == 3 ? "63" :
                                                     y.BuildingUnitUseTypeId == 4 ? "64" :
                                                     y.BuildingUnitUseTypeId == 5 ? "65" :
                                                     y.BuildingUnitUseTypeId == 6 ? "66" :
                                                     y.BuildingUnitUseTypeId == 7 ? "11" :
                                                     "0"
                                 )
                                let StreetLightTaxId =
                               (
                                y.BuildingUnitUseTypeId == 1 ? "12" :
                                      y.BuildingUnitUseTypeId == 2 ? "13" :
                                      y.BuildingUnitUseTypeId == 3 ? "67" :
                                      y.BuildingUnitUseTypeId == 4 ? "68" :
                                      y.BuildingUnitUseTypeId == 5 ? "69" :
                                      y.BuildingUnitUseTypeId == 6 ? "70" :
                                      y.BuildingUnitUseTypeId == 7 ? "13" :

                                      "0"
                               )
                                let effectiveDate = ctx.MstSlab.Where(u => u.TaxId == Convert.ToInt32(UniTTaxId)).Max(u => u.EffectiveDate)
                                let slbid = ctx.MstSlab.Where(xx => xx.TaxId == Convert.ToInt32(UniTTaxId) && xx.ConstructionTypeId == x.ConstructionTypeId && xx.BuildingUnitClassId == y.BuildingUnitClassId && xx.BuildingUnitUseTypeId == y.BuildingUnitUseTypeId && xx.EffectiveDate == effectiveDate).FirstOrDefault().SlabId
                                let slabIdGarbage = ctx.MstSlab.Where(xx => xx.TaxId == Convert.ToInt32(GarbageTaxId) && xx.ConstructionTypeId == x.ConstructionTypeId && xx.BuildingUnitClassId == y.BuildingUnitClassId && xx.BuildingUnitUseTypeId == y.BuildingUnitUseTypeId && xx.EffectiveDate == effectiveDate).FirstOrDefault().SlabId
                                let slabIdStreetLight = ctx.MstSlab.Where(xx => xx.TaxId == Convert.ToInt32(StreetLightTaxId) && xx.ConstructionTypeId == x.ConstructionTypeId && xx.BuildingUnitClassId == y.BuildingUnitClassId && xx.BuildingUnitUseTypeId == y.BuildingUnitUseTypeId && xx.EffectiveDate == effectiveDate).FirstOrDefault().SlabId
                                //  where y.IsRegularized == true
                                where y.TaxPayerId == TaxPayerId
                                orderby x.LandDetailId ascending, x.BuildingDetailId

                                select new BuildingTaxVM
                                {
                                    BuildingDetailId = x.BuildingDetailId,
                                    BuildingNo = x.BuildingNo,
                                    BuildupArea = x.BuildupArea,
                                    NumberOfFloors = x.NumberOfFloors,
                                    TaxPayerId = y.TaxPayerId,
                                    BuildingClassId = x.BuildingClassId,
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
                                    Garbage = Garbagehalf,
                                    SlabIdStreetLight = slabIdStreetLight,
                                    UnitTaxId = Convert.ToInt32(UniTTaxId),
                                    GarbageTaxId = Convert.ToInt32(GarbageTaxId),
                                    StreetLightTaxId = Convert.ToInt32(StreetLightTaxId),
                                    LandOwnerShipId = LandOwnerShipId,
                                    UnitTaxRate = StrAvailable == true ? (y.IsRegularized == true ? (ctx.MstRate.Where(xy => xy.TaxId == Convert.ToInt32(UniTTaxId) && xy.SlabId == slbid).FirstOrDefault().Rate) : 0) : 0,
                                    UnitTax = StrAvailable == true ? (y.IsRegularized == true ? (ctx.MstRate.Where(xy => xy.TaxId == Convert.ToInt32(UniTTaxId) && xy.SlabId == slbid).FirstOrDefault().Rate) * y.NoOfUnit : y.BuildingUnitUseTypeId == 2 ? ((20000 + (20 * y.FloorArea))) : ((20000 + (5 * y.FloorArea)))) : 0,
                                    GarbageTaxRate = StrAvailable == true ? (y.IsRegularized == true ? (ctx.MstRate.Where(xy => xy.TaxId == Convert.ToInt32(GarbageTaxId) && xy.SlabId == slabIdGarbage).FirstOrDefault().Rate) : 0) : 0,
                                    GarbageTax = StrAvailable == true ? (y.IsRegularized == true ? ((ctx.MstRate.Where(xy => xy.TaxId == Convert.ToInt32(GarbageTaxId) && xy.SlabId == slabIdGarbage).FirstOrDefault().Rate) * y.NoOfUnit * 6) : 0) : 0,
                                    StreetLightTaxRate = StrAvailable == true ? (y.IsRegularized == true ? (ctx.MstRate.Where(xy => xy.TaxId == Convert.ToInt32(StreetLightTaxId) && xy.SlabId == slabIdStreetLight).FirstOrDefault().Rate) : 0) : 0,
                                    StreetLightTax = StrAvailable == true ? (y.IsRegularized == true ? (ctx.MstRate.Where(xy => xy.TaxId == Convert.ToInt32(StreetLightTaxId) && xy.SlabId == slabIdStreetLight).FirstOrDefault().Rate) * y.NoOfUnit * 12 : 0) : 0

                                }).ToList();
                    return data.ToList();
                }

                }
            }
            else

            {
                if (Buildingclassid == 9)
                {
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
                                        BuildingClassId = x.BuildingClassId,
                                        FloorNo = y.FloorNo,
                                        FloorArea = y.FloorArea,
                                        EffectiveDate = effectiveDate,
                                        UnitOwnerTypeId = y.UnitOwnerTypeId,
                                        SlabId = slbid,
                                        UnitTaxId = Convert.ToInt32(UniTTaxId),
                                        GarbageTaxId = Convert.ToInt32(GarbageTaxId),
                                        StreetLightTaxId = Convert.ToInt32(StreetLightTaxId),
                                        UnitTaxRate = StrAvailable == true ? (y.IsRegularized == true ? (ctx.MstRate.Where(xy => xy.TaxId == Convert.ToInt32(UniTTaxId) && xy.SlabId == slbid).FirstOrDefault().Rate) : 0) : 0,
                                        UnitTax = StrAvailable == true ? (y.IsRegularized == true ? (ctx.MstRate.Where(xy => xy.TaxId == Convert.ToInt32(UniTTaxId) && xy.SlabId == slbid).FirstOrDefault().Rate) * y.NoOfUnit : y.BuildingUnitUseTypeId == 2 ? ((20000 + (20 * y.FloorArea))) : ((20000 + (5 * y.FloorArea)))) : 0,
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
                                                       y.BuildingUnitUseTypeId == 6 ? "58" :
                                                       y.BuildingUnitUseTypeId == 7 ? "93" :
                                                       "0"
                                                     )
                                    let GarbageTaxId =
                                     (
                                                        y.BuildingUnitUseTypeId == 1 ? "10" :
                                                         y.BuildingUnitUseTypeId == 2 ? "11" :
                                                         y.BuildingUnitUseTypeId == 3 ? "63" :
                                                         y.BuildingUnitUseTypeId == 4 ? "64" :
                                                         y.BuildingUnitUseTypeId == 5 ? "65" :
                                                         y.BuildingUnitUseTypeId == 6 ? "66" :
                                                         y.BuildingUnitUseTypeId == 7 ? "11" :
                                                         "0"
                                     )
                                    let StreetLightTaxId =
                                   (
                                    y.BuildingUnitUseTypeId == 1 ? "12" :
                                          y.BuildingUnitUseTypeId == 2 ? "13" :
                                          y.BuildingUnitUseTypeId == 3 ? "67" :
                                          y.BuildingUnitUseTypeId == 4 ? "68" :
                                          y.BuildingUnitUseTypeId == 5 ? "69" :
                                          y.BuildingUnitUseTypeId == 6 ? "70" :
                                          y.BuildingUnitUseTypeId == 7 ? "13" :

                                          "0"
                                   )
                                    let effectiveDate = ctx.MstSlab.Where(u => u.TaxId == Convert.ToInt32(UniTTaxId)).Max(u => u.EffectiveDate)
                                    let slbid = ctx.MstSlab.Where(xx => xx.TaxId == Convert.ToInt32(UniTTaxId) && xx.ConstructionTypeId == x.ConstructionTypeId && xx.BuildingUnitClassId == y.BuildingUnitClassId && xx.BuildingUnitUseTypeId == y.BuildingUnitUseTypeId && xx.EffectiveDate == effectiveDate).FirstOrDefault().SlabId
                                    let slabIdGarbage = ctx.MstSlab.Where(xx => xx.TaxId == Convert.ToInt32(GarbageTaxId) && xx.ConstructionTypeId == x.ConstructionTypeId && xx.BuildingUnitClassId == y.BuildingUnitClassId && xx.BuildingUnitUseTypeId == y.BuildingUnitUseTypeId && xx.EffectiveDate == effectiveDate).FirstOrDefault().SlabId
                                    let slabIdStreetLight = ctx.MstSlab.Where(xx => xx.TaxId == Convert.ToInt32(StreetLightTaxId) && xx.ConstructionTypeId == x.ConstructionTypeId && xx.BuildingUnitClassId == y.BuildingUnitClassId && xx.BuildingUnitUseTypeId == y.BuildingUnitUseTypeId && xx.EffectiveDate == effectiveDate).FirstOrDefault().SlabId
                                    //  where y.IsRegularized == true
                                    where y.TaxPayerId == TaxPayerId
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
                                        BuildingClassId = x.BuildingClassId,
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
                                        UnitTax = StrAvailable == true ? (y.IsRegularized == true ? (ctx.MstRate.Where(xy => xy.TaxId == Convert.ToInt32(UniTTaxId) && xy.SlabId == slbid).FirstOrDefault().Rate) * y.NoOfUnit : y.BuildingUnitUseTypeId == 2 ? ((20000 + (20 * y.FloorArea))) : ((20000 + (5 * y.FloorArea)))) : 0,
                                        GarbageTaxRate = StrAvailable == true ? (y.IsRegularized == true ? (ctx.MstRate.Where(xy => xy.TaxId == Convert.ToInt32(GarbageTaxId) && xy.SlabId == slabIdGarbage).FirstOrDefault().Rate) : 0) : 0,
                                        GarbageTax = StrAvailable == true ? (y.IsRegularized == true ? (ctx.MstRate.Where(xy => xy.TaxId == Convert.ToInt32(GarbageTaxId) && xy.SlabId == slabIdGarbage).FirstOrDefault().Rate) * y.NoOfUnit * 12 : 0) : 0,
                                        StreetLightTaxRate = StrAvailable == true ? (y.IsRegularized == true ? (ctx.MstRate.Where(xy => xy.TaxId == Convert.ToInt32(StreetLightTaxId) && xy.SlabId == slabIdStreetLight).FirstOrDefault().Rate) : 0) : 0,
                                        StreetLightTax = StrAvailable == true ? (y.IsRegularized == true ? (ctx.MstRate.Where(xy => xy.TaxId == Convert.ToInt32(StreetLightTaxId) && xy.SlabId == slabIdStreetLight).FirstOrDefault().Rate) * y.NoOfUnit * 12 : 0) : 0

                                    }).ToList();
                        return data.ToList();
                    }
                }
                else if (Buildingclassid == 3 || Buildingclassid == 4)
                {
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
                                        BuildingClassId = x.BuildingClassId,
                                        FloorNo = y.FloorNo,
                                        FloorArea = y.FloorArea,
                                        EffectiveDate = effectiveDate,
                                        UnitOwnerTypeId = y.UnitOwnerTypeId,
                                        SlabId = slbid,
                                        UnitTaxId = Convert.ToInt32(UniTTaxId),
                                        GarbageTaxId = Convert.ToInt32(GarbageTaxId),
                                        StreetLightTaxId = Convert.ToInt32(StreetLightTaxId),
                                        UnitTaxRate = StrAvailable == true ? (y.IsRegularized == true ? (ctx.MstRate.Where(xy => xy.TaxId == Convert.ToInt32(UniTTaxId) && xy.SlabId == slbid).FirstOrDefault().Rate) : 0) : 0,
                                        UnitTax = StrAvailable == true ? (y.IsRegularized == true ? (ctx.MstRate.Where(xy => xy.TaxId == Convert.ToInt32(UniTTaxId) && xy.SlabId == slbid).FirstOrDefault().Rate) * y.NoOfUnit : y.BuildingUnitUseTypeId == 2 ? ((20000 + (20 * y.FloorArea))) : ((20000 + (5 * y.FloorArea)))) : 0,
                                        GarbageTaxRate = StrAvailable == true ? (y.IsRegularized == true ? (ctx.MstRate.Where(xy => xy.TaxId == Convert.ToInt32(GarbageTaxId) && xy.SlabId == slabIdGarbage).FirstOrDefault().Rate) : 0) : 0,
                                        GarbageTax = StrAvailable == true ? (y.IsRegularized == true ? (rate) * y.NoOfUnit : 0) * 12 : 0,
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
                                                       y.BuildingUnitUseTypeId == 6 ? "58" :
                                                       y.BuildingUnitUseTypeId == 7 ? "93" :
                                                       "0"
                                                     )
                                    let GarbageTaxId =
                                     (
                                                        y.BuildingUnitUseTypeId == 1 ? "10" :
                                                         y.BuildingUnitUseTypeId == 2 ? "11" :
                                                         y.BuildingUnitUseTypeId == 3 ? "63" :
                                                         y.BuildingUnitUseTypeId == 4 ? "64" :
                                                         y.BuildingUnitUseTypeId == 5 ? "65" :
                                                         y.BuildingUnitUseTypeId == 6 ? "66" :
                                                         y.BuildingUnitUseTypeId == 7 ? "11" :
                                                         "0"
                                     )
                                    let StreetLightTaxId =
                                   (
                                    y.BuildingUnitUseTypeId == 1 ? "12" :
                                          y.BuildingUnitUseTypeId == 2 ? "13" :
                                          y.BuildingUnitUseTypeId == 3 ? "67" :
                                          y.BuildingUnitUseTypeId == 4 ? "68" :
                                          y.BuildingUnitUseTypeId == 5 ? "69" :
                                          y.BuildingUnitUseTypeId == 6 ? "70" :
                                          y.BuildingUnitUseTypeId == 7 ? "13" :

                                          "0"
                                   )
                                    let effectiveDate = ctx.MstSlab.Where(u => u.TaxId == Convert.ToInt32(UniTTaxId)).Max(u => u.EffectiveDate)
                                    let slbid = ctx.MstSlab.Where(xx => xx.TaxId == Convert.ToInt32(UniTTaxId) && xx.ConstructionTypeId == x.ConstructionTypeId && xx.BuildingUnitClassId == y.BuildingUnitClassId && xx.BuildingUnitUseTypeId == y.BuildingUnitUseTypeId && xx.EffectiveDate == effectiveDate).FirstOrDefault().SlabId
                                    let slabIdGarbage = ctx.MstSlab.Where(xx => xx.TaxId == Convert.ToInt32(GarbageTaxId) && xx.ConstructionTypeId == x.ConstructionTypeId && xx.BuildingUnitClassId == y.BuildingUnitClassId && xx.BuildingUnitUseTypeId == y.BuildingUnitUseTypeId && xx.EffectiveDate == effectiveDate).FirstOrDefault().SlabId
                                    let slabIdStreetLight = ctx.MstSlab.Where(xx => xx.TaxId == Convert.ToInt32(StreetLightTaxId) && xx.ConstructionTypeId == x.ConstructionTypeId && xx.BuildingUnitClassId == y.BuildingUnitClassId && xx.BuildingUnitUseTypeId == y.BuildingUnitUseTypeId && xx.EffectiveDate == effectiveDate).FirstOrDefault().SlabId
                                    //  where y.IsRegularized == true
                                    where y.TaxPayerId == TaxPayerId
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
                                        BuildingClassId = x.BuildingClassId,
                                        SlabIdGarbage = slabIdGarbage,
                                        SlabIdStreetLight = slabIdStreetLight,
                                        UnitTaxId = Convert.ToInt32(UniTTaxId),
                                        GarbageTaxId = Convert.ToInt32(GarbageTaxId),
                                        StreetLightTaxId = Convert.ToInt32(StreetLightTaxId),
                                        LandOwnerShipId = LandOwnerShipId,
                                        UnitTaxRate = StrAvailable == true ? (y.IsRegularized == true ? (ctx.MstRate.Where(xy => xy.TaxId == Convert.ToInt32(UniTTaxId) && xy.SlabId == slbid).FirstOrDefault().Rate) : 0) : 0,
                                        UnitTax = StrAvailable == true ? (y.IsRegularized == true ? (ctx.MstRate.Where(xy => xy.TaxId == Convert.ToInt32(UniTTaxId) && xy.SlabId == slbid).FirstOrDefault().Rate) * y.NoOfUnit : y.BuildingUnitUseTypeId == 2 ? ((20000 + (20 * y.FloorArea))) : ((20000 + (5 * y.FloorArea)))) : 0,
                                        GarbageTaxRate = StrAvailable == true ? (y.IsRegularized == true ? (ctx.MstRate.Where(xy => xy.TaxId == Convert.ToInt32(GarbageTaxId) && xy.SlabId == slabIdGarbage).FirstOrDefault().Rate) : 0) : 0,
                                        GarbageTax = StrAvailable == true ? (y.IsRegularized == true ? (rate) * y.NoOfUnit * 12 : 0) : 0,
                                        StreetLightTaxRate = StrAvailable == true ? (y.IsRegularized == true ? (ctx.MstRate.Where(xy => xy.TaxId == Convert.ToInt32(StreetLightTaxId) && xy.SlabId == slabIdStreetLight).FirstOrDefault().Rate) : 0) : 0,
                                        StreetLightTax = StrAvailable == true ? (y.IsRegularized == true ? (ctx.MstRate.Where(xy => xy.TaxId == Convert.ToInt32(StreetLightTaxId) && xy.SlabId == slabIdStreetLight).FirstOrDefault().Rate) * y.NoOfUnit * 12 : 0) : 0

                                    }).ToList();
                        return data.ToList();
                    }
                }
                else
                {
                    var countb = ctx.MstBuildingDetail.Where(xx => xx.LandDetailId == LandDetailId).Count();
                    var Garbagehalf = (rate * 12) * countb;
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
                                        BuildingClassId = x.BuildingClassId,
                                        UnitTaxId = Convert.ToInt32(UniTTaxId),
                                        GarbageTaxId = Convert.ToInt32(GarbageTaxId),
                                        StreetLightTaxId = Convert.ToInt32(StreetLightTaxId),
                                        UnitTaxRate = StrAvailable == true ? (y.IsRegularized == true ? (ctx.MstRate.Where(xy => xy.TaxId == Convert.ToInt32(UniTTaxId) && xy.SlabId == slbid).FirstOrDefault().Rate) : 0) : 0,
                                        UnitTax = StrAvailable == true ? (y.IsRegularized == true ? (ctx.MstRate.Where(xy => xy.TaxId == Convert.ToInt32(UniTTaxId) && xy.SlabId == slbid).FirstOrDefault().Rate) * y.NoOfUnit : y.BuildingUnitUseTypeId == 2 ? ((20000 + (20 * y.FloorArea))) : ((20000 + (5 * y.FloorArea)))) : 0,
                                        GarbageTaxRate = StrAvailable == true ? (y.IsRegularized == true ? (ctx.MstRate.Where(xy => xy.TaxId == Convert.ToInt32(GarbageTaxId) && xy.SlabId == slabIdGarbage).FirstOrDefault().Rate) : 0) : 0,
                                        GarbageTax = StrAvailable == true ? (y.IsRegularized == true ? Garbagehalf : 0) * 1 : 0,
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
                                                       y.BuildingUnitUseTypeId == 6 ? "58" :
                                                       y.BuildingUnitUseTypeId == 7 ? "93" :
                                                       "0"
                                                     )
                                    let GarbageTaxId =
                                     (
                                                        y.BuildingUnitUseTypeId == 1 ? "10" :
                                                         y.BuildingUnitUseTypeId == 2 ? "11" :
                                                         y.BuildingUnitUseTypeId == 3 ? "63" :
                                                         y.BuildingUnitUseTypeId == 4 ? "64" :
                                                         y.BuildingUnitUseTypeId == 5 ? "65" :
                                                         y.BuildingUnitUseTypeId == 6 ? "66" :
                                                         y.BuildingUnitUseTypeId == 7 ? "11" :
                                                         "0"
                                     )
                                    let StreetLightTaxId =
                                   (
                                    y.BuildingUnitUseTypeId == 1 ? "12" :
                                          y.BuildingUnitUseTypeId == 2 ? "13" :
                                          y.BuildingUnitUseTypeId == 3 ? "67" :
                                          y.BuildingUnitUseTypeId == 4 ? "68" :
                                          y.BuildingUnitUseTypeId == 5 ? "69" :
                                          y.BuildingUnitUseTypeId == 6 ? "70" :
                                          y.BuildingUnitUseTypeId == 7 ? "13" :

                                          "0"
                                   )
                                    let effectiveDate = ctx.MstSlab.Where(u => u.TaxId == Convert.ToInt32(UniTTaxId)).Max(u => u.EffectiveDate)
                                    let slbid = ctx.MstSlab.Where(xx => xx.TaxId == Convert.ToInt32(UniTTaxId) && xx.ConstructionTypeId == x.ConstructionTypeId && xx.BuildingUnitClassId == y.BuildingUnitClassId && xx.BuildingUnitUseTypeId == y.BuildingUnitUseTypeId && xx.EffectiveDate == effectiveDate).FirstOrDefault().SlabId
                                    let slabIdGarbage = ctx.MstSlab.Where(xx => xx.TaxId == Convert.ToInt32(GarbageTaxId) && xx.ConstructionTypeId == x.ConstructionTypeId && xx.BuildingUnitClassId == y.BuildingUnitClassId && xx.BuildingUnitUseTypeId == y.BuildingUnitUseTypeId && xx.EffectiveDate == effectiveDate).FirstOrDefault().SlabId
                                    let slabIdStreetLight = ctx.MstSlab.Where(xx => xx.TaxId == Convert.ToInt32(StreetLightTaxId) && xx.ConstructionTypeId == x.ConstructionTypeId && xx.BuildingUnitClassId == y.BuildingUnitClassId && xx.BuildingUnitUseTypeId == y.BuildingUnitUseTypeId && xx.EffectiveDate == effectiveDate).FirstOrDefault().SlabId
                                    //  where y.IsRegularized == true
                                    where y.TaxPayerId == TaxPayerId
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
                                        BuildingClassId = x.BuildingClassId,
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
                                        UnitTax = StrAvailable == true ? (y.IsRegularized == true ? (ctx.MstRate.Where(xy => xy.TaxId == Convert.ToInt32(UniTTaxId) && xy.SlabId == slbid).FirstOrDefault().Rate) * y.NoOfUnit : y.BuildingUnitUseTypeId == 2 ? ((20000 + (20 * y.FloorArea))) : ((20000 + (5 * y.FloorArea)))) : 0,
                                        GarbageTaxRate = StrAvailable == true ? (y.IsRegularized == true ? (ctx.MstRate.Where(xy => xy.TaxId == Convert.ToInt32(GarbageTaxId) && xy.SlabId == slabIdGarbage).FirstOrDefault().Rate) : 0) : 0,
                                        GarbageTax = StrAvailable == true ? (y.IsRegularized == true ? Garbagehalf : 0) : 0,
                                        StreetLightTaxRate = StrAvailable == true ? (y.IsRegularized == true ? (ctx.MstRate.Where(xy => xy.TaxId == Convert.ToInt32(StreetLightTaxId) && xy.SlabId == slabIdStreetLight).FirstOrDefault().Rate) : 0) : 0,
                                        StreetLightTax = StrAvailable == true ? (y.IsRegularized == true ? (ctx.MstRate.Where(xy => xy.TaxId == Convert.ToInt32(StreetLightTaxId) && xy.SlabId == slabIdStreetLight).FirstOrDefault().Rate) * y.NoOfUnit * 12 : 0) : 0

                                    }).ToList();
                        return data.ToList();
                    }
                }
            }
        }
        public long CreateLandTax(LedgerDemandVM obj)
        {
            try
            {
               
                using TransactionScope s = new TransactionScope();
                var fyr = ctx.MstFinancialYear.Where(x => x.StartDate <= DateTime.Today && x.EndDate >= DateTime.Today).Max(x => x.FinancialYearId);// make default check at startup
                var cyrData = ctx.MstCalendarYear.Where(x => x.CalendarYearId == obj.CalendarYearId);
                int cyr = Convert.ToInt32(cyrData.FirstOrDefault().CalendarYear);


                int sq = ctx.TblDemandNo.Where(p => p.DemandYear == Convert.ToInt32(DateTime.Now.Year)).Select(p => p.Sl).Cast<int?>().Max() ?? 0;

                sq = sq + 1;

                

                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        public long GenerateUnitTax(LedgerDemandVM obj)
        {
            try
            {
                var landOwnershipData = (ctx.TblLandOwnershipDetail.Where(x => x.LandOwnershipId == obj.LandOwnerShipId)); ;
                var LandDetailId = landOwnershipData.FirstOrDefault().LandDetailId;
                
                var Building = (ctx.MstBuildingDetail.Where(x => x.LandDetailId == LandDetailId));
                var Buildingclassid = Building.FirstOrDefault().BuildingClassId;
                

                    using TransactionScope s = new TransactionScope();
               

                    var fyr = ctx.MstFinancialYear.Where(x => x.StartDate <= DateTime.Today && x.EndDate >= DateTime.Today).Max(x => x.FinancialYearId);// make default check at startup
                    var cyrData = ctx.MstCalendarYear.Where(x => x.CalendarYearId == obj.CalendarYearId);
                    int cyr = Convert.ToInt32(cyrData.FirstOrDefault().CalendarYear);


                   
                    var TrnDetail = ctx.TblLandOwnershipDetail.Where(x => x.LandOwnershipId == obj.LandOwnerShipId).Take(1);


                  //GARBAGE
                    var entityG = new TblDemand
                    {
                        TransactionId = obj.TransactionId,
                        DemandNoId = obj.DemandNoId,
                        TaxId = obj.GarbageTaxId,
                        LandOwnershipId = obj.LandOwnerShipId,
                        FinancialYearId = fyr,
                        CalendarYearId = obj.CalendarYearId,
                        DemandAmount = obj.GarbageTax,
                        TotalAmount = obj.GarbageTax,
                        LandDetailId = TrnDetail.FirstOrDefault().LandDetailId,
                        TaxPayerId = TrnDetail.FirstOrDefault().TaxPayerId,
                        CreatedBy = obj.CreatedBy,
                        CreatedOn = obj.CreatedOn,
                        BillingDate = obj.CreatedOn
                    };
                    ctx.TblDemand.Add(entityG);
                    ctx.SaveChanges();
                    //garbage end
                    //SL
                    var entityS = new TblDemand
                    {
                        TransactionId = obj.TransactionId,
                        DemandNoId = obj.DemandNoId,
                        LandOwnershipId = obj.LandOwnerShipId,
                        TaxId = obj.StreetLightTaxId,
                        FinancialYearId = fyr,
                        CalendarYearId = obj.CalendarYearId,
                        DemandAmount = obj.StreetLightTax,
                        TotalAmount = obj.StreetLightTax,
                        LandDetailId = TrnDetail.FirstOrDefault().LandDetailId,
                        TaxPayerId = TrnDetail.FirstOrDefault().TaxPayerId,
                        CreatedBy = obj.CreatedBy,
                        CreatedOn = obj.CreatedOn,
                        BillingDate = obj.CreatedOn
                    };
                    ctx.TblDemand.Add(entityS);
                    ctx.SaveChanges();
                    long ipk = obj.DemandNoId;
                
                    s.Complete();
                    s.Dispose();


                    return ipk;
                
            }
            catch (Exception ex)
            {
                return 0;
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

        public IList<LedgerDemandVM> CheckDuplicateTax(int TaxPayerId, int LandDetailId, int CalendarYearId)
        {
            var data = (from a in ctx.TblDemand.Where(x =>x.TaxPayerId== TaxPayerId && x.LandDetailId== LandDetailId && x.CalendarYearId== CalendarYearId)
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


        public IList<LedgerDemandVM> lasttaxpaid(int LandOwnershipId)
        {
            var landownershipData = ctx.TblLandOwnershipDetail.Where(x => x.LandOwnershipId == LandOwnershipId);
            var LandDetailId = landownershipData.FirstOrDefault().LandDetailId;
            var TaxPayerId = landownershipData.FirstOrDefault().TaxPayerId;

            var data = (from a in ctx.TblDemand.Where(x => x.TaxPayerId == TaxPayerId && x.LandDetailId == LandDetailId)
                        join t in ctx.TblTransactionDetail  on a.TransactionId equals t.TransactionId
                        join y in ctx.MstCalendarYear on a.CalendarYearId equals y.CalendarYearId
                        where t.TransactionTypeId == 20
                        orderby a.CalendarYearId ascending
                        select new LedgerDemandVM
                        {DemandId=a.DemandId,Amount=a.TotalAmount,
                            CalendarYear = y.CalendarYear

                        });
            return data.Distinct().ToList();
        }

        public IList<LedgerDemandVM> CheckStructureAvailable(int LandOwnershipId)
        {


            var data = (from a in ctx.TblLandOwnershipDetail.Where(x => x.LandOwnershipId == LandOwnershipId)
                        join t in ctx.MstLandDetail on a.LandDetailId equals t.LandDetailId
                        join y in ctx.MstBuildingDetail on t.LandDetailId equals y.LandDetailId


                        select new LedgerDemandVM
                        {
                            CreatedOn = y.CreatedOn,
                            SA = (t.StructureAvailable == true ? "Yes" : "No")

                        }) ;
            return data.Distinct().ToList();
        }
    }
}
