using CORE_BOL;
using CORE_BOL.Entities;
using CORE_DLL;
using Microsoft.AspNetCore.Http;
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
    public class PaymentAmountModificationBLL : IPaymentAmountModification
    {
        readonly tt_dbContext ctx = new tt_dbContext();

        public List<PaymentAmountModification> GetDemandDetails(string DemandNo)
        {
            var data = (from x in ctx.TblDemandNo.Where(x => x.DemandNo == DemandNo)
                        join d in ctx.TblDemand on x.DemandNoId equals d.DemandNoId
                        join t in ctx.MstTaxPayerProfile on d.TaxPayerId equals t.TaxPayerId
                        join tx in ctx.MstTaxMaster on d.TaxId equals tx.TaxId
                        where d.IsPaymentMade == false
                        select new PaymentAmountModification
                        {
                            DemandNoId = (int)x.DemandNoId,
                            DemandId = (int)d.DemandId,
                            TotalDemandAmount = d.TotalAmount,
                            PreviousDemandAmount = d.DemandAmount,
                            DemandNo = x.DemandNo,
                            TaxName = tx.TaxName,
                            DSL = x.Sl,
                            TaxPayerName = t.FirstName + " " + ((t.MiddleName == null || t.MiddleName.Trim() == string.Empty) ? string.Empty : (t.MiddleName + " ")) + ((t.LastName == null || t.LastName.Trim() == string.Empty) ? string.Empty : (t.LastName + " ")),

                        });
            return data.ToList();
        }

        public List<PaymentAmountModification> GetReceiptDetails(string ReceiptNo)
        {
            var data = (from x in ctx.TblReceipt.Where(x => x.ReceiptNo == ReceiptNo)
                        join l in ctx.TblLedger on x.ReceiptId equals l.ReceiptId
                        join pl in ctx.TblPaymentLeger on l.ReceiptId equals pl.ReceiptId
                        join pm in ctx.EnumPaymentMode on pl.PaymentModeId equals pm.PaymentModeId
                        join t in ctx.MstTaxPayerProfile on l.TaxPayerId equals t.TaxPayerId
                        join tx in ctx.MstTaxMaster on l.TaxId equals tx.TaxId
                        join d in ctx.TblDemand on l.DemandId equals d.DemandId
                        where d.IsPaymentMade == true

                        select new PaymentAmountModification
                        {
                            ReceiptId = (int)x.ReceiptId,
                            ReceiptNo = x.ReceiptNo,
                            RSL = x.Sl,
                            TotalPaymentAmount = l.TotalAmount,
                            TaxName = tx.TaxName,
                            TaxPayerName = t.FirstName + " " + ((t.MiddleName == null || t.MiddleName.Trim() == string.Empty) ? string.Empty : (t.MiddleName + " ")) + ((t.LastName == null || t.LastName.Trim() == string.Empty) ? string.Empty : (t.LastName + " ")),
                            PaymentMode = pm.PaymentMode,
                            LedgerId = (int)l.LedgerId,
                            PaymentLedgerId = (int)pl.PaymentLedgerId,
                            DemandId = (int)d.DemandId
                            

                        });
            return data.ToList();
        }

        public int SaveDemand(PaymentAmountModification obj)
        {
            try
            {
                using TransactionScope s = new TransactionScope();
                int ipk;
                int[] trntypeIds = { 34, 35, 36, 37, 38, 39, 40, 41, 13 };
                var Demand = ctx.TblDemand.Where(w => w.DemandId == obj.DemandId);
                var TransactionId = Demand.FirstOrDefault().TransactionId;
                var TransactionDetail = ctx.TblTransactionDetail.Where(w => w.TransactionId == TransactionId);
                var TransactionType = TransactionDetail.FirstOrDefault().TransactionTypeId;



                if (trntypeIds.Contains(TransactionType))
                {
                    var Fee = ctx.TrnLandFeeDetail.Where(w => w.TransactionId == TransactionId);
                    var LandFeeId = Fee.FirstOrDefault().LandFeeDetailId;

                    var update = ctx.TrnLandFeeDetail.Where(u => u.LandFeeDetailId == LandFeeId);
                    if (update.Any())
                    {
                        update.FirstOrDefault().Amount = Convert.ToString(obj.TotalDemandAmount);
                        ctx.SaveChanges();
                    }
                }

                var entity = new TblDemandLedgerPaymentUpdate
                {

                    DemandId = obj.DemandId,
                    FileName = obj.DemandUpload,
                    OldAmount = obj.PreviousDemandAmount,
                    NewAmount = obj.TotalDemandAmount,
                    CreatedBy = obj.CreatedBy,
                    CreatedOn = Convert.ToDateTime(obj.CreatedOn),
                };
                
                ctx.TblDemandLedgerPaymentUpdate.Add(entity);
                ctx.SaveChanges();

                var Data = ctx.TblDemand.FirstOrDefault(u => u.DemandId == obj.DemandId);
                Data.TotalAmount = obj.TotalDemandAmount; Data.DemandAmount = obj.TotalDemandAmount;
                ctx.SaveChanges();
                s.Complete();
                s.Dispose();
                ipk = (int)entity.PaymentUpdateId;
                return ipk;

            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public List<PaymentAmountModification> GetPaymentModeDetails(int ReceiptId)
        {
            var data = (from x in ctx.TblPaymentLeger.Where(x => x.ReceiptId == ReceiptId)
                        join pm in ctx.EnumPaymentMode on x.PaymentModeId equals pm.PaymentModeId
                        join r in ctx.TblReceipt on x.ReceiptId equals r.ReceiptId
                       //join l in ctx.TblLedger on x.ReceiptId equals l.ReceiptId
                        //join d in ctx.TblDemand on l.DemandId equals d.DemandId

                        select new PaymentAmountModification
                        {
                            PaymentLedgerId = (int)x.PaymentLedgerId,
                            PaymentMode = pm.PaymentMode,
                            PaymentModeDate = (DateTime)x.PaymentModeDate,
                            PreviousPaymentAmount = x.Amount,
                            PaymentModeNo = x.PaymentModeNo,
                            RSL = r.Sl
                            //LedgerId = (int)l.LedgerId,
                            //DemandId = (int)d.DemandId

                        });
            return data.ToList();
        }

        public int SavePayment(PaymentAmountModification obj)
        {
            try
            {
                using TransactionScope s = new TransactionScope();
                int ipk;
                
                    int[] trntypeIds = { 34, 35, 36, 37, 38, 39, 40, 41, 13 };
                var Demand = ctx.TblDemand.Where(w => w.DemandId == obj.DemandId);
                var TransactionId = Demand.FirstOrDefault().TransactionId;
                var TransactionDetail = ctx.TblTransactionDetail.Where(w => w.TransactionId == TransactionId);
                var TransactionType = TransactionDetail.FirstOrDefault().TransactionTypeId;



                if (trntypeIds.Contains(TransactionType))
                {
                    var Fee = ctx.TrnLandFeeDetail.Where(w => w.TransactionId == TransactionId);
                    var LandFeeId = Fee.FirstOrDefault().LandFeeDetailId;

                    var update = ctx.TrnLandFeeDetail.Where(u => u.LandFeeDetailId == LandFeeId);
                    if (update.Any())
                    {
                        update.FirstOrDefault().Amount = Convert.ToString(obj.TotalPaymentAmount);
                        ctx.SaveChanges();
                    }
                }
                    var entity = new TblDemandLedgerPaymentUpdate
                    {

                        DemandId = obj.DemandId,
                        FileName = obj.PaymentUpload,
                        OldAmount = obj.PreviousPaymentAmount,
                        NewAmount = obj.TotalPaymentAmount,
                        PaymentLedgerId = obj.PaymentLedgerId,
                        LedgerId = obj.LedgerId,
                        CreatedBy = obj.CreatedBy,
                        CreatedOn = Convert.ToDateTime(obj.CreatedOn),
                    };
                    
                    ctx.TblDemandLedgerPaymentUpdate.Add(entity);
                    ctx.SaveChanges();

                    var Data = ctx.TblDemand.FirstOrDefault(u => u.DemandId == obj.DemandId);
                    Data.TotalAmount = obj.TotalPaymentAmount; Data.DemandAmount = obj.TotalPaymentAmount;
                    ctx.SaveChanges();

                    var Data1 = ctx.TblLedger.FirstOrDefault(u => u.LedgerId == obj.LedgerId);
                    Data1.TotalAmount = obj.TotalPaymentAmount;
                    ctx.SaveChanges();

                s.Complete();
                s.Dispose();
                ipk = (int)entity.PaymentUpdateId;
                return ipk;

            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public int SavePaymentModeAmount(PaymentAmountModification obj)
        {
            try
            {
                using TransactionScope s = new TransactionScope();
                int ipk;

                var entity = new TblDemandLedgerPaymentUpdate
                {
                    PaymentLedgerId = obj.PaymentLedgerId,
                    OldAmount = obj.PreviousPaymentModeAmount,
                    NewAmount = obj.TotalPaymentModeAmount,
                    FileName = obj.PaymentUpload,
                    CreatedBy = obj.CreatedBy,
                    CreatedOn = Convert.ToDateTime(obj.CreatedOn),
                };
                ctx.TblDemandLedgerPaymentUpdate.Add(entity);
                ctx.SaveChanges();

                var Data = ctx.TblPaymentLeger.FirstOrDefault(u => u.PaymentLedgerId == obj.PaymentLedgerId);
                Data.Amount = obj.TotalPaymentModeAmount; 
                ctx.SaveChanges();

                s.Complete();
                s.Dispose();
                ipk = (int)entity.PaymentUpdateId;
                return ipk;

            }
            catch (Exception ex)
            {
                return 0;
            }
        }
    }
}
