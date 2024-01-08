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
    public class AssetTransfer : IAssetTransfer
    {
        readonly tt_dbContext ctx = new tt_dbContext();
        public List<SecondaryAccountHeadModel> fetchSecondaryHead(int id)
        {
            var data = (from a in ctx.MstSecondaryAccountHead.Where(x => x.PrimaryAccountHeadId == id)
                        select new SecondaryAccountHeadModel
                        {
                            SecondaryAccountHeadId = a.SecondaryAccountHeadId,
                            SecondaryAccountHeadName = a.SecondaryAccountHeadName
                        });
            return data.ToList();
        }

        public List<TertiaryAccountHeadModel> fetchTertiaryHead(int id)
        {
            var data = (from a in ctx.MstTertiaryAccountHead.Where(x => x.SecondaryAccountHeadId == id)
                        select new TertiaryAccountHeadModel
                        {
                            TertiaryAccountHeadId = a.TertiaryAccountHeadId,
                            TertiaryAccountHeadName = a.TertiaryAccountHeadName
                        });
            return data.ToList();
        }

        public List<SectionModel> fetchDivision(int id)
        {
            var data = (from a in ctx.MstSection.Where(x => x.DivisionId == id)
                        select new SectionModel
                        {
                            SectionId = a.SectionId,
                            SectionName = a.SectionName
                        });
            return data.ToList();
        }

        public List<AssetTransferVM> SearchAsset(int primaryhead, int secondaryhead, int tertiaryhead, int division, int section, string assetname, int assetstatus, int lap, int demkhong)
        {
            var data = from x in ctx.MstAsset.Where(x => (string.IsNullOrEmpty(assetname) || x.AssetName == assetname))
                       join a in ctx.MstTertiaryAccountHead on x.TertiaryAccountHeadId equals a.TertiaryAccountHeadId
                       join y in ctx.MstAssetStatus on x.AssetStatusId equals y.AssetStatusId
                       join s in ctx.MstSecondaryAccountHead on a.SecondaryAccountHeadId equals s.SecondaryAccountHeadId
                       join p in ctx.MstPrimaryAccountHead on s.PrimaryAccountHeadId equals p.PrimaryAccountHeadId
                       join sec in ctx.MstSection on x.SectionId equals sec.SectionId
                       join d in ctx.MstDivision on sec.DivisionId equals d.DivisionId
                       join c in ctx.MstAssetStatus on x.AssetStatusId equals c.AssetStatusId
                       join dem in ctx.MstDemkhong on x.DemkhongId equals dem.DemkhongId
                       join l in ctx.MstLap on x.LapId equals l.LapId
                       where (p.PrimaryAccountHeadId == primaryhead || s.SecondaryAccountHeadId == secondaryhead || a.TertiaryAccountHeadId == tertiaryhead ||
                              sec.SectionId == section || d.DivisionId == division || c.AssetStatusId == assetstatus ||
                              dem.DemkhongId == demkhong || l.LapId == lap
                       )
                       select new AssetTransferVM
                       {
                           AssetId = x.AssetId,
                           AssetCode = x.AssetCode,
                           AssetName = x.AssetName,
                           AssetStatus = y.AssetStatus,
                           TransferFromDivisionId = d.DivisionId,
                           TransferFromSectionId = sec.SectionId,
                       };
            return data.ToList();
        }

        public List<AssetTransferVM> GetAssetDetails(int id)
        {
            var data = (from x in ctx.MstAsset.Where(x => x.AssetId == id)
                        join t in ctx.MstTertiaryAccountHead on x.TertiaryAccountHeadId equals t.TertiaryAccountHeadId
                        join s in ctx.MstSecondaryAccountHead on t.SecondaryAccountHeadId equals s.SecondaryAccountHeadId
                        join p in ctx.MstPrimaryAccountHead on s.PrimaryAccountHeadId equals p.PrimaryAccountHeadId
                        join sec in ctx.MstSection on x.SectionId equals sec.SectionId
                        join d in ctx.MstDivision on sec.DivisionId equals d.DivisionId
                        join l in ctx.MstLap on x.LapId equals l.LapId
                        join dem in ctx.MstDemkhong on x.DemkhongId equals dem.DemkhongId
                        join af in ctx.MstAssetFunction on x.AssetFunctionId equals af.AssetFunctionId
                        join b in ctx.MstAssetStatus on x.AssetStatusId equals b.AssetStatusId
                        select new AssetTransferVM
                        {
                            //PrimaryAccountHead = p.PrimaryAccountHeadName,
                            //SecondaryAccountHead = s.SecondaryAccountHeadName,
                            //TertiaryAccountHead = t.TertiaryAccountHeadName,
                            Division = d.DivisionName,
                            Section = sec.SectionName,
                            Lap = l.LapName,
                            Demkhong = dem.DemkhongName,
                            AssetName = x.AssetName,
                            SectionId = x.SectionId,
                            DivisionId = d.DivisionId,
                            ResponsiblePersonFrom = x.ResponsiblePerson
                            //AssetFunction = af.AssetFunctionName,
                            //AssetStatus = b.AssetStatus,
                            //Remarks = x.Remarks,
                            //ResponsiblePerson = x.ResponsiblePerson

                        });
            return data.ToList();
        }

        public int SaveAssetTransfer(AssetTransferVM obj)
        {
            try
            {
                using TransactionScope s = new TransactionScope();
                int ipk;
                if(obj.AssetTransferTypeId == 1)
                {
                    var entity = new TblAssetTransfer
                    {
                        AssetId = obj.AssetId,
                        TransferFromDivisionId = obj.TransferFromDivisionId,
                        TransferFromSectionId = obj.TransferFromSectionId,
                        TransferToDivisionId = obj.TransferToDivisionId,
                        TransferToSectionId = obj.TransferToSectionId,
                        TransferDate = obj.TransferDate,
                        Remarks = obj.Remarks,
                        CreatedBy = obj.CreatedBy,
                        CreatedOn = Convert.ToDateTime(obj.CreatedOn),
                        AssetTransferTypeId = obj.AssetTransferTypeId
                    };
                    ctx.TblAssetTransfer.Add(entity);
                    ctx.SaveChanges();
                    var UpdateAsset = ctx.MstAsset.FirstOrDefault(u => u.AssetId == obj.AssetId);
                    UpdateAsset.SectionId = (int)obj.TransferToSectionId; UpdateAsset.ModifiedBy = obj.ModifiedBy;
                    UpdateAsset.ModifiedOn = obj.ModifiedOn;
                    ctx.SaveChanges();
                    ipk = entity.AssetTransferId;

                }
                else
                {
                    var entity = new TblAssetTransfer
                    {
                        AssetId = obj.AssetId,
                        TransferDate = obj.TransferDate,
                        Remarks = obj.Remarks,
                        CreatedBy = obj.CreatedBy,
                        CreatedOn = Convert.ToDateTime(obj.CreatedOn),
                        ResponsiblePersonTo = obj.ResponsiblePersonTo,
                        ResponsiblePersonFrom = obj.ResponsiblePersonFrom,
                        AssetTransferTypeId = obj.AssetTransferTypeId
                    };
                    ctx.TblAssetTransfer.Add(entity);
                    ctx.SaveChanges();
                    var UpdateAsset = ctx.MstAsset.FirstOrDefault(u => u.AssetId == obj.AssetId);
                    UpdateAsset.ResponsiblePerson = obj.ResponsiblePersonTo; UpdateAsset.ModifiedBy = obj.ModifiedBy;
                    UpdateAsset.ModifiedOn = obj.ModifiedOn;
                    ctx.SaveChanges();
                ipk = entity.AssetTransferId;
                }
                s.Complete();
                return ipk;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
    }
}
