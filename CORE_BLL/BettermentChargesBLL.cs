using CORE_DLL;
using System;
using System.Collections.Generic;
using CORE_BOL;
using CORE_BOL.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Transactions;
namespace CORE_BLL
{
    public class BettermentChargesBLL : IBettermentCharges
    {
        readonly tt_dbContext ctx = new tt_dbContext();

        public List<LandDetailModel> GetTaxPayerDetails(string cid, string ttin, string plotno, string thramno)
        {
            var data = from x in ctx.MstTaxPayerProfile.Where(x => (string.IsNullOrEmpty(cid) || x.Cid == cid) && (string.IsNullOrEmpty(ttin) || x.Ttin == ttin))
                       join c in ctx.EnumTitle on x.TitleId equals c.TitleId
                       join a in ctx.TblLandOwnershipDetail on x.TaxPayerId equals a.TaxPayerId into aa
                       from b in aa.DefaultIfEmpty()
                       join y in ctx.MstLandDetail on b.LandDetailId equals y.LandDetailId into yy
                       from d in yy.DefaultIfEmpty()
                       where (string.IsNullOrEmpty(plotno) || d.PlotNo == plotno) && (string.IsNullOrEmpty(thramno) || b.ThramNo == thramno)

                       select new LandDetailModel
                        {
                            CID = x.Cid,
                            TTIN = x.Ttin,
                            Name = c.Title + "" + x.FirstName + " " + ((x.MiddleName == null || x.MiddleName.Trim() == string.Empty) ? string.Empty : (x.MiddleName + " ")) + ((x.LastName == null || x.LastName.Trim() == string.Empty) ? string.Empty : (x.LastName + " ")),
                            TaxPayerId = x.TaxPayerId,
                            MobileNo = x.MobileNo
                        };
            return data.ToList();
        }

        public List<LandDetailModel> GetLandDetails(int? id)
        {
            var data = (from x in ctx.TblLandOwnershipDetail.Where(x => x.TaxPayerId == id)
                        join a in ctx.MstLandDetail on x.LandDetailId equals a.LandDetailId
                        join y in ctx.MstLandUseSubCategory on a.LandUseSubCategoryId equals y.LandUseSubCategoryId
                        select new LandDetailModel
                        {

                            PlotNo = a.PlotNo,
                            ThramNo = x.ThramNo,
                            LandAcerage = a.LandAcerage,
                            Location = a.Location,
                            OwnershipPercentage =(decimal) x.OwnershipPercentage,
                            LandUseSubCategory = y.LandUseSubCategory,
                            StructureAvailable = a.StructureAvailable,
                            LandDetailId = a.LandDetailId
                        });
            return data.ToList();
        }
        public List<LandDetailModel> GetBuildingDetails(int? id)
        {
            var data = (from x in ctx.MstLandDetail.Where(x => x.LandDetailId == id )
                        join c in ctx.MstBuildingDetail on x.LandDetailId equals c.LandDetailId
                        join d in ctx.MstConstructionType on c.ConstructionTypeId equals d.ConstructionTypeId
                        select new LandDetailModel
                        {
                            BuildUpArea = c.BuildupArea,
                            NoOfFloors = c.NumberOfFloors,
                            ConstructionType = d.ConstructionType,
                            BuildingNo = c.BuildingNo,
                            LandDetailId = x.LandDetailId,
                        });
            return data.ToList();
        }

        public List<LandDetailModel> GetBuildingUnitDetails(int? id)
        {
            var data = (from x in ctx.MstLandDetail.Where(x => x.LandDetailId == id)
                        join c in ctx.MstBuildingUnitDetail on x.LandDetailId equals c.LandDetailId
                        join d in ctx.MstBuildingUnitUseType on c.BuildingUnitUseTypeId equals d.BuildingUnitUseTypeId
                        join a in ctx.TrnLandDetail on x.DemkhongId equals a.DemkhongId
                        select new LandDetailModel
                        {
                            BuildingType = d.BuildingUnitUseType,
                            NoOfUnits = (int)c.NoOfUnit,
                            FloorArea = c.FloorArea,
                            TrnLandDetailId = a.TrnFtlandDetailId,
                            LandPoolingRate = x.LandPoolingRate,

                        });
            return data.ToList();
        }
        public int SaveLandPoolingRate(trnLandDetailVM obj)
        {
            try
            {
                using (TransactionScope s = new TransactionScope())
                {
                    var Data = ctx.TrnLandDetail.FirstOrDefault(u => u.TrnFtlandDetailId == obj.TrnLandDetailId);
                    Data.LandPoolingRate = obj.LandPoolingRate;


                    ctx.SaveChanges();
                    s.Complete();
                    s.Dispose();
                    return 1;
                }

            }
            catch (Exception ex)
            {
                return 0;
            }

        }
    }
}
