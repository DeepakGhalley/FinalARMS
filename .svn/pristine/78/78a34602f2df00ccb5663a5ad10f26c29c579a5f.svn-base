using CORE_BOL;
using CORE_BOL.Entities;
using CORE_DLL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
namespace CORE_BLL
{
    public class OccupancyCertificateBLL : IOccupancyCertificate
    {
        readonly tt_dbContext ctx = new tt_dbContext();
       
     
        public List<OccupancyCertificateVM> FetchOccupanyCertificate(string Cid, string Ttin)
        {
            

            var data = (from x in ctx.TrnOccupancyCertificateApplication
                        join t in ctx.MstTaxPayerProfile on x.TaxPayerId equals t.TaxPayerId
                        join l in ctx.MstLandDetail on x.LandDetailId equals l.LandDetailId
                        join lsu in ctx.MstLandUseSubCategory on l.LandUseSubCategoryId equals lsu.LandUseSubCategoryId
                        join lu in ctx.MstLandUseCategory on lsu.LandUseCategoryId equals lu.LandUseCategoryId
                        join b in ctx.MstBuildingDetail on x.BuildingDetailId equals b.BuildingDetailId
                        join ct in ctx.MstConstructionType on b.ConstructionTypeId equals ct.ConstructionTypeId
                        
                        join bu in ctx.MstBuildingUnitDetail on x.BuildingDetailId equals bu.BuildingUnitDetailId
                         into bu_temp
                        from bu_value in bu_temp.DefaultIfEmpty()
                        join buc in ctx.MstBuildingUnitClass on bu_value.BuildingUnitClassId equals buc.BuildingUnitClassId
                          into buc_temp
                        from buc_value in buc_temp.DefaultIfEmpty()
                        join but in ctx.MstBuildingUnitUseType on bu_value.BuildingUnitUseTypeId equals but.BuildingUnitUseTypeId
                        into but_temp
                        from but_value in but_temp.DefaultIfEmpty()

                        join fn in ctx.MstFloorName on bu_value.FloorNameId equals fn.FloorNameId
                          into fn_temp
                        from fn_value in fn_temp.DefaultIfEmpty()
                        join o in ctx.TblLandOwnershipDetail on x.LandOwnershipId equals o.LandOwnershipId
                        where  Cid == t.Cid || Ttin == t.Ttin & x.ValidTillDate > DateTime.Now


                        //let tno = (ctx.TblLandOwnershipDetail.Where(lod => lod.TaxPayerId == t.TaxPayerId && lod.LandDetailId == l.LandDetailId)).Take(1).FirstOrDefault().ThramNo
                        //let op = (ctx.TblLandOwnershipDetail.Where(lod => lod.TaxPayerId == t.TaxPayerId && lod.LandDetailId == l.LandDetailId)).Take(1).FirstOrDefault().OwnershipPercentage
                        //let plr = (ctx.TblLandOwnershipDetail.Where(lod => lod.TaxPayerId == t.TaxPayerId && lod.LandDetailId == l.LandDetailId)).Take(1).FirstOrDefault().PLr
            select new OccupancyCertificateVM
                        {
                            
                            Ttin = t.Ttin,
                            Cid = t.Cid,
                            TaxPayerName = t.FirstName + " " + ((t.MiddleName == null || t.MiddleName.Trim() == string.Empty) ? string.Empty : (t.MiddleName + " ")) + ((t.LastName == null || t.LastName.Trim() == string.Empty) ? string.Empty : (t.LastName + " ")),
                            PlotNo = l.PlotNo,
                            ThramNo =l.ThramNo ,
                            LandUseSubCategory = lsu.LandUseSubCategory,
                            LandAcerage = Convert.ToString( l.LandAcerage),
                            LandUseCategory = lu.LandUseCategory,
                            OwnershipPercentage = o.OwnershipPercentage,
                            Plr = Convert.ToString(o.PLr),

                            BuildingNo = b.BuildingNo,
                            ConstructionType = ct.ConstructionType,
                            BuildupArea = Convert.ToString(b.BuildupArea),
                           

                            BuildingUnitUseType = but_value.BuildingUnitUseType,
                            BuildingUnitClassName = buc_value.BuildingUnitClassName,
                           FloorName = fn_value.FloorName,
                            
                            NumberOfFloors = Convert.ToString(bu_value.FloorNo),

                            OccupancyCertificateApplicationId = x.OccupancyCertificateApplicationId,
                            OcReferenceNo = x.OcReferenceNo,
                            isBuildingOc = x.IsBuildingOc,
                            ValidTillDate = x.ValidTillDate,
                            DateOfFinalInspection = x.DateOfFinalInspection,
                            YearOfConstruction = x.Yr,
                            Location = l.Location,

                           LandDetailId = l.LandDetailId,
                           TaxPayerId = t.TaxPayerId,
                           BuildingDetailId = b.BuildingDetailId,
                           BuildingUnitDetailId = bu_value.BuildingUnitDetailId

                        });
            return data.ToList();
        }

        public List<OccupancyCertificateVM> FetchLanddetails(int OccupancyCertificateApplicationId)
        {

            var data = (from l in ctx.MstLandDetail

                        join lsu in ctx.MstLandUseSubCategory on l.LandUseSubCategoryId equals lsu.LandUseSubCategoryId
                        join lu in ctx.MstLandUseCategory on lsu.LandUseCategoryId equals lu.LandUseCategoryId
                        join la in ctx.MstLap on l.LapId equals la.LapId
                        join t in ctx.TrnOccupancyCertificateApplication on l.LandDetailId equals t.LandDetailId
                        where t.OccupancyCertificateApplicationId == OccupancyCertificateApplicationId
                        select new OccupancyCertificateVM
                        {

                            PlotNo = l.PlotNo,
                            ThramNo = l.ThramNo,
                            LandUseSubCategory = lsu.LandUseSubCategory,
                            LandAcerage = Convert.ToString(l.LandAcerage),
                            LandUseCategory = lu.LandUseCategory,
                            lapName = la.LapName



                        });
            return data.ToList();
        }

        public List<OccupancyCertificateVM> FetchTaxpayerdetails(int OccupancyCertificateApplicationId)
        {

            var data = (from t in ctx.MstTaxPayerProfile
                        join tn in ctx.TrnOccupancyCertificateApplication on t.TaxPayerId equals tn.TaxPayerId
                        join o in ctx.TblLandOwnershipDetail on tn.LandDetailId equals o.LandDetailId
                        join ot in ctx.EnumLandOwnershipType on o.LandOwnershipTypeId equals ot.LandOwnershipTypeId

                        where tn.OccupancyCertificateApplicationId == OccupancyCertificateApplicationId && t.IsActive == true

                        select new OccupancyCertificateVM
                        {

                            Ttin = t.Ttin,
                            Cid = t.Cid,
                            TaxPayerName = t.FirstName + " " + ((t.MiddleName == null || t.MiddleName.Trim() == string.Empty) ? string.Empty : (t.MiddleName + " ")) + ((t.LastName == null || t.LastName.Trim() == string.Empty) ? string.Empty : (t.LastName + " ")),

                            OwnershipPercentage = o.OwnershipPercentage,
                            Plr = Convert.ToString(o.PLr),
                            landOwnershipType = ot.LandOwnershipType
                        });
            return data.ToList();
        }


        public List<OccupancyCertificateVM> Fetchbuildingdetails(int OccupancyCertificateApplicationId)
        {

            var data = (from b in ctx.MstBuildingDetail
                       join tn in ctx.TrnOccupancyCertificateApplication on b.BuildingDetailId equals tn.BuildingDetailId
                        join ct in ctx.MstConstructionType on b.ConstructionTypeId equals ct.ConstructionTypeId

                        join bu in ctx.MstBuildingUnitDetail on b.BuildingDetailId equals bu.BuildingUnitDetailId
                         into bu_temp
                        from bu_value in bu_temp.DefaultIfEmpty()
                        join buc in ctx.MstBuildingUnitClass on bu_value.BuildingUnitClassId equals buc.BuildingUnitClassId
                          into buc_temp
                        from buc_value in buc_temp.DefaultIfEmpty()
                        join but in ctx.MstBuildingUnitUseType on bu_value.BuildingUnitUseTypeId equals but.BuildingUnitUseTypeId
                        into but_temp
                        from but_value in but_temp.DefaultIfEmpty()

                        join fn in ctx.MstFloorName on bu_value.FloorNameId equals fn.FloorNameId
                          into fn_temp
                        from fn_value in fn_temp.DefaultIfEmpty()
                 where tn.OccupancyCertificateApplicationId == OccupancyCertificateApplicationId


                        select new OccupancyCertificateVM
                        {

                            

                            BuildingNo = b.BuildingNo,
                            ConstructionType = ct.ConstructionType,
                            NumberOfFloors = Convert.ToString(b.NumberOfFloors),
                            BuildupArea = Convert.ToString(b.BuildupArea),
 });
            return data.ToList();
        }


        public List<OccupancyCertificateVM> FetchUnitdetails(int OccupancyCertificateApplicationId)
        {

            var data = (from x in ctx.MstBuildingUnitDetail
                        join t in ctx.MstBuildingUnitClass on x.BuildingUnitClassId equals t.BuildingUnitClassId
                        join l in ctx.MstBuildingUnitUseType on x.BuildingUnitUseTypeId equals l.BuildingUnitUseTypeId
                        join lsu in ctx.MstFloorName on x.FloorNameId equals lsu.FloorNameId
                        join tn in ctx.TrnOccupancyCertificateApplication on x.BuildingUnitDetailId equals tn.BuildingUnitDetailId
                        where tn.OccupancyCertificateApplicationId == OccupancyCertificateApplicationId
                        select new OccupancyCertificateVM
                        {

                           
                           


                            BuildingUnitUseType = l.BuildingUnitUseType,
                            BuildingUnitClassName = t.BuildingUnitClassName,
                            FloorName = lsu.FloorName,
                            FloorArea = x.FloorArea,
                            NoOfUnit = x.NoOfUnit
                            

                        });
            return data.ToList();
        }

    }
}

