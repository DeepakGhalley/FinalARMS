using CORE_BOL;
using CORE_BOL.Entities;
using CORE_DLL;
using Microsoft.AspNetCore.Http;
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
    public class ComplainDetailBLL : IComplainDetail
    {
        readonly tt_dbContext ctx = new tt_dbContext();

        public List<WaterConnectionModel> GetWaterConnection(string ConsumerNo)
        {
            var data = (from x in ctx.MstWaterConnection.Where(x => x.ConsumerNo == ConsumerNo)
                        join l in ctx.MstLandDetail on x.LandDetailId equals l.LandDetailId
                        join lo in ctx.TblLandOwnershipDetail on x.LandOwnershipId equals lo.LandOwnershipId
                        join t in ctx.MstTaxPayerProfile on lo.TaxPayerId equals t.TaxPayerId
                        join z in ctx.MstZone on x.ZoneId equals z.ZoneId
                        where x.IsActive == true
                        select new WaterConnectionModel
                        {
                            ConsumerNo = x.ConsumerNo,
                            PlotNo = l.PlotNo,
                            TaxPayerName = t.FirstName + " " + ((t.MiddleName == null || t.MiddleName.Trim() == string.Empty) ? string.Empty : (t.MiddleName + " ")) + ((t.LastName == null || t.LastName.Trim() == string.Empty) ? string.Empty : (t.LastName + " ")),
                            WaterMeterNo = x.WaterMeterNo,
                            ZoneName = z.ZoneName,
                            BillingAddress = x.BillingAddress,
                            WaterConnectionId = x.WaterConnectionId
                        });
            return data.ToList();
        }
        public int SaveComplainDetail(ComplainDetail obj)
        {
            try
            {
                using TransactionScope s = new TransactionScope();
                int ipk;
                var entity = new TblComplainDetail
                {
                    WaterConnectionId = obj.WaterConnectionId,
                    ComplainTypeId = obj.ComplainTypeId,
                    ComplainStatusId = obj.ComplainStatusId,
                    DeadLine = obj.DeadLine,
                    Instruction = obj.Instruction,                   
                    CreatedBy = obj.CreatedBy,
                    CreatedOn = Convert.ToDateTime(obj.CreatedOn)
                };
                ctx.TblComplainDetail.Add(entity);
                ctx.SaveChanges();
                s.Complete();
                s.Dispose();
                ipk = (int)entity.ComplainDetailId;

                return ipk;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<ComplainDetail> GetComplainDetail(int ComplainDetailId)
        {
            var data = (from x in ctx.TblComplainDetail.Where(x => x.ComplainDetailId == ComplainDetailId)
                        join l in ctx.EnumComplainStatus on x.ComplainStatusId equals l.ComplainStatusId
                        join lo in ctx.EnumComplainType on x.ComplainTypeId equals lo.ComplainTypeId
                        select new ComplainDetail
                        {
                            Instruction = x.Instruction,
                            ComplainStatus = l.ComplainStatus,
                            ComplainType = lo.ComplainType,
                            DeadLine = x.DeadLine,
                            ComplainStatusId = x.ComplainStatusId,
                            ComplainDetailId = (int)x.ComplainDetailId
                        }) ;
            return data.ToList();
        }
        public List<ComplainDetail> GetReviewComplainDetail(int WCID)
        {
            var data = (from x in ctx.TblComplainDetail.Where(x => x.WaterConnectionId == WCID)
                        join l in ctx.EnumComplainStatus on x.ComplainStatusId equals l.ComplainStatusId
                        join lo in ctx.EnumComplainType on x.ComplainTypeId equals lo.ComplainTypeId
                        select new ComplainDetail
                        {
                            Instruction = x.Instruction,
                            ComplainStatus = l.ComplainStatus,
                            ComplainType = lo.ComplainType,
                            DeadLine = x.DeadLine,
                            ComplainDetailId = (int)x.ComplainDetailId,
                            ComplainStatusId = x.ComplainStatusId
                        });
            return data.ToList();
        }
        public int SaveReviewComplainDetail(ComplainDetail obj)
        {
            try
            {
                using (TransactionScope s = new TransactionScope())
                {
                    var Data = ctx.TblComplainDetail.FirstOrDefault(u => u.ComplainDetailId == obj.ComplainDetailId);
                    Data.ComplainStatusId = obj.ComplainStatusId;
                    Data.ComplainReviewRemarks = obj.ComplainReviewRemarks;
                    Data.ComplainReviewedOn = obj.ComplainReviewedOn;
                    Data.ComplainReviewedBy = obj.ComplainReviewedBy;                  
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

        public int SaveApprovalComplainDetail(ComplainDetail obj)
        {
            try
            {
                using (TransactionScope s = new TransactionScope())
                {
                    var Data = ctx.TblComplainDetail.FirstOrDefault(u => u.ComplainDetailId == obj.ComplainDetailId);
                    Data.ComplainStatusId = obj.ComplainStatusId;
                    Data.ComplainApprovalRemarks = obj.ComplainApprovalRemarks;
                    Data.ComplainApprovedOn = obj.ComplainApprovedOn;
                    Data.ComplainApprovedBy = obj.ComplainApprovedBy;
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

        public int SaveRejectionComplainDetail(ComplainDetail obj)
        {
            try
            {
                using (TransactionScope s = new TransactionScope())
                {
                    var Data = ctx.TblComplainDetail.FirstOrDefault(u => u.ComplainDetailId == obj.ComplainDetailId);
                    Data.ComplainStatusId = obj.ComplainStatusId;
                    Data.ComplainRejectRemarks = obj.ComplainRejectRemarks;
                    Data.ComplainRejectedOn = obj.ComplainRejectedOn;
                    Data.ComplainRejectedBy = obj.ComplainRejectedBy;
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
