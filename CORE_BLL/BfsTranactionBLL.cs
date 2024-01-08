using CORE_BOL;
using CORE_BOL.Entities;
using CORE_DLL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;


using System.Linq;
//using Microsoft.EntityFrameworkCore;
//using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Internal;
//using QRCoder;
//using System.Drawing;
//using System.IO;
//using System.Net.Http;
//using Newtonsoft.Json;
//using Newtonsoft.Json.Linq;
namespace CORE_BLL
{
    public class BfsTranactionBLL : IBfsTranaction
    {
        readonly tt_dbContext ctx = new tt_dbContext();
        //**********Payment Cancel****************
        public int SavePaymentCancel(BfsModel objBfs)
        {
          
            try
            {
                using TransactionScope s = new TransactionScope();
                int ipk;
                var entity = new TblBfsTransactiondetails
                {
                    BfsBfsTxnId = objBfs.BfsBfsTxnId,
                    BfsDebitAuthNo = objBfs.BfsDebitAuthNo,
                    BfsRemitterName = objBfs.BfsRemitterName,
                    BfsTxnCurrency = objBfs.BfsTxnCurrency,
                    BfsChecksum = objBfs.BfsChecksum,
                    BfsTxnTime = objBfs.BfsTxnTime,
                    BfsBenfId = objBfs.BfsBenfId,
                    BfsRemitterBankId = objBfs.BfsRemitterBankId,
                    BfsOrderNo = objBfs.BfsOrderNo,
                    BfsDebitAuthCode = objBfs.BfsDebitAuthCode,
                    BfsTxnAmount = objBfs.BfsTxnAmount,
                    BfsBenfTxnTime = objBfs.BfsBenfTxnTime,
                    BfsMsgType = objBfs.BfsMsgType,
                    BfsStatusState = objBfs.BfsStatusState,
                    CreatedBy = 192,
                    CreatedOn = DateTime.Now
                };
                ctx.TblBfsTransactiondetails.Add(entity);
                ctx.SaveChanges();
                s.Complete();
                s.Dispose();
                ipk = (int)entity.BfsTransactionDetailId;

                return ipk;
            }
            catch (Exception ex)
            {
                return 0;
            }

        }


        //**********Payment Failure****************
        public int SavePaymentFailure(BfsModel objBfs)
        {
            try
            {
                using TransactionScope s = new TransactionScope();
                int ipk;
                var entity = new TblBfsTransactiondetails
                {
                    BfsBfsTxnId = objBfs.BfsBfsTxnId,
                    BfsDebitAuthNo = objBfs.BfsDebitAuthNo,
                    BfsRemitterName = objBfs.BfsRemitterName,
                    BfsTxnCurrency = objBfs.BfsTxnCurrency,
                    BfsChecksum = objBfs.BfsChecksum,
                    BfsTxnTime = objBfs.BfsTxnTime,
                    BfsBenfId = objBfs.BfsBenfId,
                    BfsRemitterBankId = objBfs.BfsRemitterBankId,
                    BfsOrderNo = objBfs.BfsOrderNo,
                    BfsDebitAuthCode = objBfs.BfsDebitAuthCode,
                    BfsTxnAmount = objBfs.BfsTxnAmount,
                    BfsBenfTxnTime = objBfs.BfsBenfTxnTime,
                    BfsMsgType = objBfs.BfsMsgType,
                    BfsStatusState = objBfs.BfsStatusState,
                    CreatedBy = 192,
                    CreatedOn = DateTime.Now
                };
                ctx.TblBfsTransactiondetails.Add(entity);
                ctx.SaveChanges();
                s.Complete();
                s.Dispose();
                ipk = (int)entity.BfsTransactionDetailId;

                return ipk;
            }
            catch (Exception ex)
            {
                return 0;
            }

        }

        public static int GetMonthDifference(DateTime startDate, DateTime endDate)
        {
            int monthsApart = 12 * (startDate.Year - endDate.Year) + startDate.Month - endDate.Month;
            return Math.Abs(monthsApart);
        }


        //**********Payment Success****************
        public long SavePaymentSuccess(BfsModel objBfs)
        {
            try
            {
               long rpk;long bfspk;long PLpk;
                var entity = new TblBfsTransactiondetails
                {
                    BfsBfsTxnId = objBfs.BfsBfsTxnId,
                    BfsDebitAuthNo = objBfs.BfsDebitAuthNo,
                    BfsRemitterName = objBfs.BfsRemitterName,
                    BfsTxnCurrency = objBfs.BfsTxnCurrency,
                    BfsChecksum = objBfs.BfsChecksum,
                    BfsTxnTime = objBfs.BfsTxnTime,
                    BfsBenfId = objBfs.BfsBenfId,
                    BfsRemitterBankId = objBfs.BfsRemitterBankId,
                    BfsOrderNo = objBfs.BfsOrderNo,
                    BfsDebitAuthCode = objBfs.BfsDebitAuthCode,
                    BfsTxnAmount = objBfs.BfsTxnAmount,
                    BfsBenfTxnTime = objBfs.BfsBenfTxnTime,
                    BfsMsgType = objBfs.BfsMsgType,
                    BfsStatusState = objBfs.BfsStatusState,
                    //BfsVersion=objBfs.BfsVersion,
                    //BfsPaymentDesc=objBfs.BfsPaymentDesc,
                    //BfsRemitterEmail=objBfs.BfsRemitterEmail,
                    //BfsBenfBankCode=objBfs.BfsBenfBankCode,
                    //BfsBankId=objBfs.BfsBankId,
                    //BfsBankName=objBfs.BfsBankName,
                    //BfsRemitterAccNo=objBfs.BfsRemitterAccNo,
                    //BfsRemitterOtp=objBfs.BfsRemitterOtp,
                    //BfsResponseChecksum=objBfs.BfsResponseChecksum,
                    //BfsResponseCode=objBfs.BfsResponseCode,
                    //BfsResponseDesc=objBfs.BfsResponseDesc,

                   CreatedBy = 192,
                   CreatedOn=DateTime.Now
                };
                ctx.TblBfsTransactiondetails.Add(entity);
                ctx.SaveChanges();
                bfspk = entity.BfsTransactionDetailId;


                using (TransactionScope s = new TransactionScope())
                {

                    //SAVE LEDGER
                    var sBfsTransactionDetailId = ctx.TblBfsTransactiondetails.Where(l => l.BfsMsgType == "AR" && l.BfsOrderNo == objBfs.BfsOrderNo);
                        //.BfsTransactionDetailId;
                    var DemandList = ctx.TblDemand.Where(o => o.BfsTransactionDetailId == sBfsTransactionDetailId.FirstOrDefault().BfsTransactionDetailId).Select(s => s.DemandId);

                    var DemandData = ctx.TblDemand.Where(u => DemandList.Contains(u.DemandId));

                    //LEDGER INSERT
                    //int sq = ctx.TblReceipt.Where(p => p.ReceiptYear == DateTime.Now.Year).Max(p => p.Sl);
                    int sq = ctx.TblReceipt.Where(p => p.ReceiptYear == Convert.ToInt32(DateTime.Now.Year)).Select(p => p.Sl).Cast<int?>().Max() ?? 0;
                    //sq = sq + 1;

                    sq = sq + 1; var receiptno = "";
                    var entityR = new TblReceipt
                    {
                        ReceiptNo = ("TT/" + (DateTime.Now.Year) + "/" + sq),
                        Sl = sq,
                        ReceiptYear = DateTime.Now.Year,
                        CreatedBy = 192,
                        CreatedOn = DateTime.Now,
                    };
                    ctx.TblReceipt.Add(entityR);
                    ctx.SaveChanges();
                    rpk = entityR.ReceiptId; receiptno = entityR.ReceiptNo;

                    //LOOP START
                    //decimal tamt = 0; decimal pamt = 0;

                    foreach (var item in DemandData.ToList())
                    {
                        var dmd = ctx.TblDemand.Single(d => d.DemandId == item.DemandId);
                        var trn = ctx.TblTransactionDetail.Single(t => t.TransactionId == item.TransactionId);
                        var cy = ctx.MstCalendarYear.Single(t => t.CalendarYearId == item.CalendarYearId);
                        var tp = ctx.MstTaxPeriod.Where(t => t.TransactionTypeId == trn.TransactionTypeId && t.CalendarYearId == cy.CalendarYearId);

                        var entityL = new TblLedger
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
                            ReceiptId = rpk,
                            CreatedBy = 192,
                            CreatedOn = DateTime.Now,
                            PenaltyPeriod = trn.TransactionTypeId == 19 ? GetMonthDifference(dmd.BillingDate, DateTime.Today) :
                            0,
                            PenaltyAmount =
                        trn.TransactionTypeId == 19 ? ((tp.FirstOrDefault().PenaltyOrRate * dmd.TotalAmount) * GetMonthDifference(dmd.BillingDate, DateTime.Today) / (12 * 100)) :

                        0,
                            ApplicantId = item.ApplicantId,
                            EcRenewalId = item.EcRenewalId,
                            LandLeaseDemandDetailId = item.LandLeaseDemandDetailId,
                            ParkingDemandDetailId = item.ParkingDemandDetailId,
                            StallDemandDetailId = item.StallDemandDetailId,
                            HouseRentDemandDetailId = item.HouseRentDemandDetailId,
                            MiscellaneousRecordId = item.MiscellaneousRecordId,
                            BfsTransactionDetailId = bfspk,
                        };

                        ctx.TblLedger.Add(entityL);
                        ctx.SaveChanges();
                    }
                    //loop end

                    //CREATE PAYMENT LEDGER
                    // var PaymentModeId = 4;

                    //var TLamt = ctx.TblLedger.Where(x => ids.Contains(x.DemandId.ToString())).Sum(x => x.TotalAmount);
                    //var TPamt = ctx.TblLedger.Where(y => ids.Contains(y.DemandId.ToString())).Sum(y => y.PenaltyAmount);

                    var entityPL = new TblPaymentLeger
                    {
                        PaymentModeId = 4,
                        PaymentModeNo = objBfs.BfsBfsTxnId,
                        PaymentModeDate = DateTime.Now,
                        Amount = Convert.ToDecimal(objBfs.BfsTxnAmount),
                        //BankBranchId = BranchId,
                        ReceiptId = rpk,
                        BfsTransactionDetailId = bfspk,
                        CreatedBy = 192,
                        CreatedOn = DateTime.Now,
                    };
                    ctx.TblPaymentLeger.Add(entityPL);
                    ctx.SaveChanges();
                    PLpk = entityPL.PaymentLedgerId;
                    //LEDGER END

                    foreach (var item in DemandData)
                    {
                        var Data1 = ctx.TblDemand.Where(u => u.DemandId == item.DemandId);
                        Data1.FirstOrDefault().IsPaymentMade = true;
                        Data1.FirstOrDefault().PaymentDate = DateTime.Now;
                        ctx.SaveChanges();
                    }

                    s.Complete();
                    s.Dispose();
                    return PLpk;
                }
            }
            catch (Exception ex)
            {
                return 0;
            }

        }
        public long SaveBFS(BfsModel objBfs)
        {
            try
            {
                using TransactionScope s = new TransactionScope();
                long ipk;
                var entity = new TblBfsTransactiondetails
                {
                    BfsBfsTxnId = objBfs.BfsBfsTxnId,
                    BfsBenfBankCode=objBfs.BfsBenfBankCode,
                    BfsRemitterEmail=objBfs.BfsRemitterEmail,
                    BfsPaymentDesc=objBfs.BfsPaymentDesc,                    
                    BfsDebitAuthNo = objBfs.BfsDebitAuthNo,
                    BfsRemitterName = objBfs.BfsRemitterName,
                    BfsTxnCurrency = objBfs.BfsTxnCurrency,
                    BfsChecksum = objBfs.BfsChecksum,
                    BfsTxnTime = objBfs.BfsTxnTime,
                    BfsBenfId = objBfs.BfsBenfId,
                    BfsRemitterBankId = objBfs.BfsRemitterBankId,
                    BfsOrderNo = objBfs.BfsOrderNo,
                    BfsDebitAuthCode = objBfs.BfsDebitAuthCode,
                    BfsTxnAmount = objBfs.BfsTxnAmount,
                    BfsBenfTxnTime = objBfs.BfsBenfTxnTime,
                    BfsMsgType = objBfs.BfsMsgType,
                    BfsVersion = objBfs.BfsVersion,
                    BfsStatusState=objBfs.BfsStatusState,
                    CreatedBy = 192,
                    CreatedOn = DateTime.Now
                };
                ctx.TblBfsTransactiondetails.Add(entity);
                ctx.SaveChanges();
                ipk = entity.BfsTransactionDetailId;
                string[] ids = objBfs.DemandIds.Split(',');

                var dmd = ctx.TblDemand.Where(u => ids.Contains(u.DemandId.ToString()));
                if (dmd.Any())
                {
                    foreach (var item in dmd)
                    {
                        var Data1 = ctx.TblDemand.Where(u => u.DemandId == item.DemandId);

                        Data1.FirstOrDefault().BfsTransactionDetailId = ipk;

                        //ctx.Entry(Data).State = EntityState.Modified;
                        ctx.SaveChanges();
                    }
                }


               

                s.Complete();
                s.Dispose();
                return ipk;
            }
            catch (Exception ex)
            {
                return 0;
            }

        }


        public IList<OnlinePaymentCheckModel> FetOnlinePaymentStatus(string DemandNoIds)
        {
            string[] ids = DemandNoIds.Split(',');
            var DataDemand = (
                 from x in ctx.TblDemand.Where(x =>x.BfsTransactionDetailId !=null && ids.Contains(x.DemandNoId.ToString()))
                  select x.BfsTransactionDetailId).ToList();
            if (DataDemand.Any())
            {
                var BFSAR = ctx.TblBfsTransactiondetails.Where(x => DataDemand.Contains(x.BfsTransactionDetailId));

                var DataBFSAC = (
                     from x in ctx.TblBfsTransactiondetails.Where(x => x.BfsDebitAuthCode == "00" && x.BfsOrderNo == BFSAR.FirstOrDefault().BfsOrderNo)
                     select new OnlinePaymentCheckModel
                     {
                         BfsTransactionDetailId = (long)x.BfsTransactionDetailId,
                         BfsDebitAuthCode = x.BfsDebitAuthCode,
                     });
                return DataBFSAC.ToList();
            }
            else {
               // List<OnlinePaymentCheckModel> newList;
                var DataBFSAC = (
                   from x in ctx.TblBfsTransactiondetails.Where(x => x.BfsDebitAuthCode == "tt" )
                   select new OnlinePaymentCheckModel
                   {
                       BfsTransactionDetailId = (long)x.BfsTransactionDetailId,
                       BfsDebitAuthCode = x.BfsDebitAuthCode,
                   });
                return DataBFSAC.ToList();
                //newList = null;
                //return newList;
            }
        }

    }
}
