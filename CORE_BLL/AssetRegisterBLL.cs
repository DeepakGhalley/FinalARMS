using CORE_BOL;
using CORE_BOL.Entities;
using CORE_DLL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace CORE_BLL
{
    public class AssetRegisterBLL : IAssetRegister
    {
        readonly tt_dbContext ctx = new tt_dbContext();

        public bool CheckExists(int id)
        {
            return ctx.MstAsset.Any(e => e.AssetId == id);
        }

        public Task Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteConfirmed(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<AssetRegisterVM> Details(int? id)
        {
            var data = (from a in ctx.MstAsset.Where(aa => aa.AssetId == id)
                        join y in ctx.MstTertiaryAccountHead on a.TertiaryAccountHeadId equals y.TertiaryAccountHeadId
                        join f in ctx.MstSecondaryAccountHead on y.SecondaryAccountHeadId equals f.SecondaryAccountHeadId
                        join u in ctx.MstPrimaryAccountHead on f.PrimaryAccountHeadId equals u.PrimaryAccountHeadId
                        join z in ctx.MstSection on a.SectionId equals z.SectionId
                        join di in ctx.MstDivision on z.DivisionId equals di.DivisionId
                        join i in ctx.MstAssetStatus on a.AssetStatusId equals i.AssetStatusId
                        join b in ctx.MstAssetFunction on a.AssetFunctionId equals b.AssetFunctionId
                        join c in ctx.MstSuppliers on a.SupplierId equals c.SupplierId
                        join d in ctx.MstLap on a.LapId equals d.LapId
                        join e in ctx.MstDemkhong on a.DemkhongId equals e.DemkhongId
                        join ar in ctx.MstArea on a.AreaId equals ar.AreaId
                        join  zo in ctx.MstZone on a.ZoneId equals zo.ZoneId
                        join ur in ctx.MstUser on a.GoodReceiveBy equals ur.UserId
                        select new AssetRegisterVM
                        {
                            Assetnumber = (u.PrimaryAccountHeadSymbol + f.SecondaryaccountHeadSymbol + y.TertiaryAccountHeadSymbol + "/TT/" + di.DivisionCode + "/" + z.SectionCode + "/" + b.AssetFunctionDescription + "/" + ar.AreaCode + "/" + zo.ZoneCode + "/" + a.AssetCode),

                            AssetId = a.AssetId,
                            TertiaryAccountHeadId = a.TertiaryAccountHeadId,
                            TertiaryAccountHeadNames = y.TertiaryAccountHeadName,
                            SectionId = a.SectionId,
                            DivisionId = z.DivisionId,
                            SecondaryAccountHeadId = f.SecondaryAccountHeadId,
                            PrimaryAccountHeadId = u.PrimaryAccountHeadId,
                            SectionNames = z.SectionName,
                            AssetStatusId = a.AssetStatusId,
                            AssetStatusNames = i.AssetStatus,
                            AssetFunctionId = a.AssetFunctionId,
                            AssetFunctionNames = b.AssetFunctionName,
                            SupplierId = a.SupplierId,
                            SupplierNames = c.SupplierName,
                            LapId = a.LapId,
                            LapNames = d.LapName,
                            DemkhongId = a.DemkhongId,
                            DemkhongNames = e.DemkhongName,
                            AssetCode = a.AssetCode,
                            AssetName = a.AssetName,
                            ResponsiblePerson = a.ResponsiblePerson,
                            IsActive = a.IsActive,
                            IsApproved = a.IsApproved,
                            Remarks = a.Remarks,
                            GisCode = a.GisCode,
                            GoodReceiveDate = a.GoodReceiveDate,
                            GoodReceiveBy = a.GoodReceiveBy,
                            CreatedBy = a.CreatedBy,
                            CreatedOn = a.CreatedOn,
                            ModifiedBy = a.ModifiedBy,
                            ModifiedOn = a.ModifiedOn,
                            AreaId = a.AreaId,
                            ZoneId = (int)a.ZoneId


                        });

            return await data.FirstOrDefaultAsync();
        }

        public bool DuplicateCheckOnSave(string AssetCode)
        {
            return ctx.MstAsset.Any(e => e.AssetCode == AssetCode);
        }

        public bool DuplicateCheckOnUpdate(string AssetCode, int TertiaryAccountHeadId, int SectionId, int AssetStatusId, int AssetFunctionId, int Id)
        {
            return ctx.MstAsset.Any(e => e.AssetCode == AssetCode && e.TertiaryAccountHeadId == TertiaryAccountHeadId && e.SectionId  == SectionId && e.AssetStatusId == AssetStatusId && e.AssetFunctionId == AssetFunctionId  && e.AssetId != Id);
        }

        public List<MstSection> fetchSEC(int id)
        {
            var data = (from a in ctx.MstSection.Where(x => x.DivisionId == id)

                        select new MstSection
                        {
                            SectionId = a.SectionId,
                            SectionName = a.SectionName

                        });


            return data.ToList();
        }

        public List<MstSecondaryAccountHead> fetchSED(int id)
        {
            var data = (from a in ctx.MstSecondaryAccountHead.Where(x => x.PrimaryAccountHeadId == id)

                        select new MstSecondaryAccountHead
                        {
                            SecondaryAccountHeadId = a.SecondaryAccountHeadId,
                            SecondaryAccountHeadName = a.SecondaryAccountHeadName

                        });


            return data.ToList();
        }

        public List<MstTertiaryAccountHead> fetchTER(int id)
        {
            var data = (from a in ctx.MstTertiaryAccountHead.Where(x => x.SecondaryAccountHeadId == id)

                        select new MstTertiaryAccountHead
                        {
                            TertiaryAccountHeadId = a.TertiaryAccountHeadId,
                            TertiaryAccountHeadName = a.TertiaryAccountHeadName

                        });


            return data.ToList();
        }
        //public List<MstZone> FetchZone(int zid)
        //{
        //    var data = (from a in ctx.MstZone.Where(x => x.ZoneId == zid)

        //                select new MstZone
        //                {
        //                    ZoneId = a.ZoneId,
        //                    ZoneName = a.ZoneName

        //                });


        //    return data.ToList();
        //}
        //public List<MstArea> FetchArea(int aid)
        //{
        //    var data = (from a in ctx.MstArea.Where(x => x.AreaId == aid)

        //                select new MstArea
        //                {
        //                    AreaId = a.AreaId,
        //                    AreaName = a.AreaName

        //                });


        //    return data.ToList();
        //}

        public List<UsersModel> Fetchuser(int uid)
        {
            var data = (from a in ctx.AspNetUsers.Where(x => 1 == 1)

                        select new UsersModel
                        {
                            UserId = a.UserId,
                            UserName = a.FirstName + " " + ((a.MiddleName == null || a.MiddleName.Trim() == string.Empty) ? string.Empty : (a.MiddleName + " ")) + ((a.LastName == null || a.LastName.Trim() == string.Empty) ? string.Empty : (a.LastName + " ")),

                        });


            return data.ToList();
        }

        public IList<AssetRegisterVM> GetAll(int SecondaryAccountHeadId)
        {
           
            var data = (from x in ctx.MstAsset
                        
                        join aas in ctx.MstAssetStatus on x.AssetStatusId equals aas.AssetStatusId
                        join c in ctx.MstSuppliers on x.SupplierId equals c.SupplierId
                        join dd in ctx.MstLap on x.LapId equals dd.LapId
                        join e in ctx.MstDemkhong on x.DemkhongId equals e.DemkhongId
                        join t in ctx.MstTertiaryAccountHead on x.TertiaryAccountHeadId equals t.TertiaryAccountHeadId
                        join s in ctx.MstSecondaryAccountHead on t.SecondaryAccountHeadId equals s.SecondaryAccountHeadId
                        join p in ctx.MstPrimaryAccountHead on s.PrimaryAccountHeadId equals p.PrimaryAccountHeadId
                        join sec in ctx.MstSection on x.SectionId equals sec.SectionId
                        join d in ctx.MstDivision on sec.DivisionId equals d.DivisionId
                        join f in ctx.MstAssetFunction on x.AssetFunctionId equals f.AssetFunctionId
                        join a in ctx.MstArea on x.AreaId equals a.AreaId
                      where s.SecondaryAccountHeadId == SecondaryAccountHeadId
                        select new AssetRegisterVM
                        {
                            AssetId = x.AssetId,
                            TertiaryAccountHeadId = x.TertiaryAccountHeadId,
                            TertiaryAccountHeadNames = t.TertiaryAccountHeadName,
                            SectionId = x.SectionId,
                            SectionNames = sec.SectionName,
                            AssetStatusId = x.AssetStatusId,
                            AssetStatusNames = aas.AssetStatus,
                            AssetFunctionId = x.AssetFunctionId,
                            AssetFunctionNames = f.AssetFunctionName,
                            SupplierId = x.SupplierId,
                            SupplierNames = c.SupplierName,
                            LapId = x.LapId,
                            LapNames = dd.LapName,
                            DemkhongId = x.DemkhongId,
                            DemkhongNames = e.DemkhongName,
                            AssetCode = x.AssetCode,
                            AssetName = x.AssetName,
                            ResponsiblePerson = x.ResponsiblePerson,
                            IsActive = x.IsActive,
                            IsApproved = x.IsApproved,
                            Remarks = x.Remarks,
                            GisCode = x.GisCode,
                            GoodReceiveDate = x.GoodReceiveDate,
                            GoodReceiveBy = x.GoodReceiveBy,
                            CreatedBy = x.CreatedBy,
                            CreatedOn = x.CreatedOn,
                            ModifiedBy = x.ModifiedBy,
                            ModifiedOn = x.ModifiedOn,
                            Assetnumber = (p.PrimaryAccountHeadSymbol + s.SecondaryaccountHeadSymbol + t.TertiaryAccountHeadSymbol + "/TT/" + d.DivisionCode + "/" + sec.SectionCode + "/" + f.AssetFunctionDescription + "/" + a.AreaCode + "/" + x.AssetCode),

                        });
            return data.ToList();
        }

        public List<AssetRegisterVM> GetTechnical(int? id)
        {
           // var dataAsset = ( ctx.MstAsset.Where(x => x.AssetId == id));

            var data =  (from x in ctx.MstAssetAttribute
                        join a in ctx.MstParentAttribute  on x.ParentAttributeId equals a.ParentAttributeId
                        join b in ctx.MstTertiaryAccountHead on a.TertiaryAccountHeadId equals b.TertiaryAccountHeadId
                        where b.TertiaryAccountHeadId==id
                        //dataAsset.FirstOrDefault().TertiaryAccountHeadId
                        select new AssetRegisterVM
                        {
                            AssetAttributeId = x.AssetAttributeId,
                            AttributeName =(a.ParentAttribute+" :: " + x.AttributeName),
                            AttributeDescription = x.AttributeDescription,
                            ValueRequired = x.ValueRequired,
                            ParentAttributeId = x.ParentAttributeId,
                            TertiaryAccountHeadId = b.TertiaryAccountHeadId,
                            ParentAttribute = a.ParentAttribute,
                            ParentAttributeDescription = a.ParentAttributeDescription,
                            IsActive = x.IsActive,
                        });
            return  data.ToList();
        }

        public int Save(AssetRegisterVM obj)
        {
            try
            {

                var section = ctx.MstSection.Where(w => w.SectionId == obj.SectionId);
                var SectionCode = section.FirstOrDefault().SectionCode;
                var DivisionId = section.FirstOrDefault().DivisionId;

                var division = ctx.MstDivision.Where(w => w.DivisionId == DivisionId);
                var DivisionCode = division.FirstOrDefault().DivisionCode;

                var Tertiary = ctx.MstTertiaryAccountHead.Where(w => w.TertiaryAccountHeadId == obj.TertiaryAccountHeadId);
                var TertiaryAccountHeadSymbol = Tertiary.FirstOrDefault().TertiaryAccountHeadSymbol;
                var SecondaryAccountHeadId = Tertiary.FirstOrDefault().SecondaryAccountHeadId;

                var Secondary = ctx.MstSecondaryAccountHead.Where(w => w.SecondaryAccountHeadId == SecondaryAccountHeadId);
                var SecondaryaccountHeadSymbol = Secondary.FirstOrDefault().SecondaryaccountHeadSymbol;
                var PrimaryAccountHeadId = Secondary.FirstOrDefault().PrimaryAccountHeadId;

                var Primary = ctx.MstPrimaryAccountHead.Where(w => w.PrimaryAccountHeadId == PrimaryAccountHeadId);
                var PrimaryAccountHeadSymbol = Primary.FirstOrDefault().PrimaryAccountHeadSymbol;
               
               

               

                var AssetFunction = ctx.MstAssetFunction.Where(w => w.AssetFunctionId == obj.AssetFunctionId);
                var AssetFunctionDescription = AssetFunction.FirstOrDefault().AssetFunctionDescription;

                var Area = ctx.MstArea.Where(w => w.AreaId == obj.AreaId);
                var AreaCode = Area.FirstOrDefault().AreaCode;

                var Zone = ctx.MstZone.Where(w => w.ZoneId == obj.ZoneId);
                var ZoneCode = Zone.FirstOrDefault().ZoneCode;

                using TransactionScope s = new TransactionScope();
                int ipk;

                //var sq0 = ctx.MstAsset.Where(x => 1 == 1).FirstOrDefault().AssetCode.Max();
                //int sq = ctx.MstAsset.Select(x => x.AssetId).Cast<int?>().Max() ?? 0;
                // int sq = ctx.MstAsset.Where(x => x.TertiaryAccountHeadId == obj.TertiaryAccountHeadId).Select(x => x.AssetCode).OrderByDescending(x => x.AssetId);



                var AssetData = ctx.MstAsset.Where(y => y.TertiaryAccountHeadId == obj.TertiaryAccountHeadId).OrderByDescending(o => o.AssetId);
                //.Max(y=>y.AssetId);
                //int sq = ctx.TblReceipt.Where(p => p.ReceiptYear == Convert.ToInt32(DateTime.Now.Year)).Select(p => p.Sl).Cast<int?>().Max() ?? 0;
                int acsq = 0;
                if (!AssetData.Any())
                {
                    acsq = 0 + 1;
                }
                else
                {
                    acsq = Convert.ToInt32(AssetData.FirstOrDefault().AssetCode) + 1;
                }
                //  var acsq = AssetData.FirstOrDefault().AssetCode;
                //int sq = ctx.TblReceipt.Where(p => p.ReceiptYear == Convert.ToInt32(DateTime.Now.Year)).Select(p => p.Sl).Cast<int?>().Max() ?? 0;
                //sq = sq + 1;


                //if (AssetData == 0)
                //{
                //    acsq = 0 + 1;
                //}
                //else
                //{
                //    acsq = Convert.ToInt32(AssetData.FirstOrDefault().AssetCode) + 1;
                //}

                string code = "";

                if (Convert.ToString(acsq).Length == 1)
                {
                    code = string.Concat("00000", acsq);
                }
                else if (Convert.ToString(acsq).Length == 2)
                {
                    code = string.Concat("0000", acsq);
                }
                else if (Convert.ToString(acsq).Length == 3)
                {
                    code = string.Concat("000", acsq);
                }
                else if (Convert.ToString(acsq).Length == 4)
                {
                    code = string.Concat("00", acsq);
                }
                else if (Convert.ToString(acsq).Length == 5)
                {
                    code = string.Concat("0", acsq);
                }
                else if (Convert.ToString(acsq).Length == 6)
                {
                    code = string.Concat("", acsq);
                }

                var ResponsibleP = "";
                if (obj.ResponsiblePerson == null)
                {
                    ResponsibleP = "Fix Asset";
                }
                else
                {
                    ResponsibleP = obj.ResponsiblePerson;
                }
                    var entity = new MstAsset
                {
                    AssetId = obj.AssetId,
                    TertiaryAccountHeadId = obj.TertiaryAccountHeadId,
                    SectionId = obj.SectionId,
                    AssetStatusId = obj.AssetStatusId,
                    AssetFunctionId = obj.AssetFunctionId,
                    SupplierId = obj.SupplierId,
                    LapId = obj.LapId,
                    DemkhongId = obj.DemkhongId,
                    ZoneId = obj.ZoneId,
                    AssetCode = code,
                    AssetName = obj.AssetName,
                    ResponsiblePerson = ResponsibleP,
                    IsActive = obj.IsActive,
                   AreaId = obj.AreaId,
                    Remarks = obj.Remarks,
                    GisCode = (PrimaryAccountHeadSymbol + SecondaryaccountHeadSymbol + TertiaryAccountHeadSymbol + "/TT/" + DivisionCode + "/" + SectionCode + "/" + AssetFunctionDescription + "/" + AreaCode + "/" + ZoneCode + "/" + code),
                    GoodReceiveDate = obj.GoodReceiveDate,
                    GoodReceiveBy = obj.CreatedBy,
                    CreatedBy = obj.CreatedBy,
                    CreatedOn = Convert.ToDateTime(obj.CreatedOn),
                };
                ctx.MstAsset.Add(entity);
                ctx.SaveChanges();
                s.Complete();
                s.Dispose();
                ipk = entity.AssetId;

                return ipk;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public int SaveFinancial(FinancialInformationVM obj)
        {
            try
            {
                using TransactionScope s = new TransactionScope();
                int ipk;
                var entity = new TblFinancialInformation
                {
                    AssetId = obj.AssetId,
                    ProcurementOrderRefNo = obj.ProcurementOrderRefNo,
                    ProcurementOrderDate = obj.ProcurementOrderDate,
                    DateofProcurement = obj.DateofProcurement,
                    DateofCommissioning = obj.DateofCommissioning,
                    UsefulLife = obj.UsefulLife,
                    CostofProcurement = obj.CostofProcurement,
                    CreatedBy = obj.CreatedBy,
                    CreatedOn = Convert.ToDateTime(obj.CreatedOn),
                };
                ctx.TblFinancialInformation.Add(entity);
                ctx.SaveChanges();

                var update = ctx.MstAsset.Where(u => u.AssetId == obj.AssetId);
                if (update.Any())
                {
                    update.FirstOrDefault().AssetEntryStatusId = 2;
                    ctx.SaveChanges();
                }
                s.Complete();
                s.Dispose();
                ipk = entity.AssetId;

                return ipk;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }



        public int Update(AssetRegisterVM obj)
        {
            try
            {
                using (TransactionScope s = new TransactionScope())
                {
                    var Data = ctx.MstAsset.FirstOrDefault(u => u.AssetId == obj.AssetId);
                    Data.TertiaryAccountHeadId = obj.TertiaryAccountHeadId; 
                    Data.SectionId = obj.SectionId;
                    Data.AssetStatusId = obj.AssetStatusId; 
                    Data.AssetFunctionId = obj.AssetFunctionId; 
                    Data.SupplierId = obj.SupplierId;
                    Data.LapId = obj.LapId;
                    Data.DemkhongId = obj.DemkhongId;
                    Data.AssetCode = obj.AssetCode;
                    Data.AssetName = obj.AssetName;
                    Data.ResponsiblePerson = obj.ResponsiblePerson;
                    Data.IsActive = obj.IsActive;
                    Data.IsApproved = obj.IsApproved;
                    Data.Remarks = obj.Remarks;
                    Data.GisCode = obj.GisCode;
                    Data.GoodReceiveDate = obj.GoodReceiveDate;
                    Data.GoodReceiveBy = obj.GoodReceiveBy;
                    Data.ModifiedBy = obj.ModifiedBy; 
                    Data.ModifiedOn = obj.ModifiedOn;
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

        public List<TechicalInformationVM> CheckDuplicateInformation(int id)
        {
            var data = (from a in ctx.TblTechnicalInformation.Where(x => x.AssetId == id)

                        select new TechicalInformationVM
                        {
                            TechicalInformationId = a.TechicalInformationId,
                            AssetId = a.AssetId

                        });


            return data.ToList();
        }

        public int SaveTechnical(TechicalInformationVM obj)
        {
            try
            {
                using TransactionScope s = new TransactionScope();
                int ipk;
                var entity = new TblTechnicalInformation
                {
                    AssetId = obj.AssetId,
                    AssetAttributeId = obj.AssetAttributeId,
                    MeasurementUnitId = obj.MeasurementUnitId,
                    Value = obj.Value,                  
                    CreatedBy = obj.CreatedBy,
                    CreatedOn = obj.CreatedOn,
                };
                ctx.TblTechnicalInformation.Add(entity);
                ctx.SaveChanges();

                var update = ctx.MstAsset.Where(u => u.AssetId == obj.AssetId);
                if (update.Any())
                {
                    update.FirstOrDefault().AssetEntryStatusId = 3;
                    ctx.SaveChanges();
                }
                s.Complete();
                s.Dispose();
                ipk = entity.AssetId;

                return ipk;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public List<FinancialInformationVM> CheckDuplicateFinancial(int id)
        {
            var data = (from a in ctx.TblFinancialInformation.Where(x => x.AssetId == id)

                        select new FinancialInformationVM
                        {
                            FinancialInfoId = a.FinancialInfoId,
                            AssetId = a.AssetId

                        });


            return data.ToList();
        }

        public List<FinancialDetailVM> GetFinancialDetail(int? id)
        {
            var data = (from x in ctx.TblFinancialInformation .Where(x=>x.AssetId==id)
                        join a in ctx.MstAsset on x.AssetId equals a.AssetId
                        select new FinancialDetailVM
                        {
                            FinancialInfoId = x.FinancialInfoId,
                            AssetId = x.AssetId,
                            AssetName = a.AssetName,
                            DateofProcurement = x.DateofProcurement,
                            DateofCommissioning = x.DateofCommissioning,
                            UsefulLife = x.UsefulLife,
                            CostofProcurement = x.CostofProcurement,
                            ProcurementOrderRefNo = x.ProcurementOrderRefNo,
                            ProcurementOrderDate = x.ProcurementOrderDate,
                        });
            return data.ToList();
        }

        public List<TechicalInformationVM> GetTechnicalDetail(int? id)
        {
            var data = (from x in ctx.TblTechnicalInformation.Where(x=>x.AssetId==id)
                        join a in ctx.MstAsset on x.AssetId equals a.AssetId
                        join b in ctx.MstMeasurementUnit on x.MeasurementUnitId equals b.MeasurementUnitId
                        join c in ctx.MstAssetAttribute on x.AssetAttributeId equals c.AssetAttributeId
                        select new TechicalInformationVM
                        {
                            TechicalInformationId = x.TechicalInformationId,
                            AssetAttributeId = x.AssetAttributeId,
                            AttributeName = c.AttributeName,
                            AssetId = x.AssetId,
                            AssetName = a.AssetName,
                            MeasurementUnitId = x.MeasurementUnitId,
                            MeasurementUnitName = b.MeasurementUnit,
                            Value = x.Value,
                        });
            return data.ToList();
        }

        public int UpdateFinancial(FinancialInformationVM obj)
        {
            try
            {
                using (TransactionScope s = new TransactionScope())
                {
                    var Data = ctx.TblFinancialInformation.FirstOrDefault(u => u.AssetId == obj.AssetId);
                    Data.ProcurementOrderRefNo = obj.ProcurementOrderRefNo;
                    Data.ProcurementOrderDate = obj.ProcurementOrderDate;
                    Data.DateofProcurement = obj.DateofProcurement;
                    Data.DateofCommissioning = obj.DateofCommissioning;
                    Data.UsefulLife = obj.UsefulLife;
                    Data.CostofProcurement = obj.CostofProcurement;
                    Data.ModifiedBy = obj.ModifiedBy;
                    Data.ModifiedOn = obj.ModifiedOn;
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
        public List<AssetRegisterVM> GetAssetsNumber(int AssetId)
        {
             var data = (from x in ctx.MstAsset.Where(x => x.AssetId == AssetId)
                        join t in ctx.MstTertiaryAccountHead on x.TertiaryAccountHeadId equals t.TertiaryAccountHeadId
                        join s in ctx.MstSecondaryAccountHead on t.SecondaryAccountHeadId equals s.SecondaryAccountHeadId
                        join p in ctx.MstPrimaryAccountHead on s.PrimaryAccountHeadId equals p.PrimaryAccountHeadId
                        join sec in ctx.MstSection on x.SectionId equals sec.SectionId
                        join d in ctx.MstDivision on sec.DivisionId equals d.DivisionId
                        join f in ctx.MstAssetFunction on x.AssetFunctionId equals f.AssetFunctionId
                        join a in ctx.MstArea on x.AreaId equals a.AreaId
                        join z in ctx.MstZone on x.ZoneId equals z.ZoneId
                       

                         select new AssetRegisterVM
                        {
                            AssetCode = (p.PrimaryAccountHeadSymbol + s.SecondaryaccountHeadSymbol + t.TertiaryAccountHeadSymbol + "/TT/" + d.DivisionCode + "/" + sec.SectionCode + "/" + f.AssetFunctionDescription + "/" + a.AreaCode + "/" + z.ZoneCode + "/" + x.AssetCode ),

                        });
            return data.ToList();
        }

        public IEnumerable<AssetManagementVM> FetchAssetRegiser(int PrimaryHeadId)
        {
            try
            {
                var result = ctx.AssetManagement.FromSqlRaw($"FetchAssetRegiser {PrimaryHeadId}");

                return result.ToList();

            }
            catch (Exception ex)
            {
                return null;

            }
        }


    }
}
