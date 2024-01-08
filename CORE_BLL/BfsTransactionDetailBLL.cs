﻿using CORE_BOL;
using CORE_BOL.Entities;
using CORE_DLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;


namespace CORE_BLL
{
    public class BfsTransactionDetailBLL : IBfsTransactionDetails
    {
        readonly tt_dbContext ctx = new tt_dbContext();
        public List<BfsModel> SearchAll()
        {

            var DataBFSAC = (
                 from x in ctx.TblBfsTransactiondetails.Where(x => x.BfsMsgType == "AR")
                 join d in ctx.TblDemand on x.BfsTransactionDetailId equals d.BfsTransactionDetailId
                 join u in ctx.AspNetUsers on x.CreatedBy equals u.UserId
                 join t in ctx.MstTaxPayerProfile on d.TaxPayerId equals t.TaxPayerId
                             into t_temp
                 from t_value in t_temp.DefaultIfEmpty()

                 join w in ctx.TblWaterMeterReading on d.WaterMeterReadingId equals w.WaterMeterReadingId
                 into w_temp
                 from w_value in w_temp.DefaultIfEmpty()

                 join mw in ctx.MstWaterConnection on w_value.WaterConnectionId equals mw.WaterConnectionId
                 into mw_temp
                 from mw_value in mw_temp.DefaultIfEmpty()

                 where d.IsCancelled == false && d.IsPaymentMade == false 

                 select x.BfsOrderNo
                 ).ToList();
            var ACID = (from x in ctx.TblBfsTransactiondetails.Where(x => x.BfsMsgType == "AC" && x.BfsOrderNo != null && DataBFSAC.Contains(x.BfsOrderNo))
                        select x.BfsTransactionDetailId
                        ).ToList();
            var ledgerData = (from x in ctx.TblLedger.Where(x => x.BfsTransactionDetailId != null && ACID.Contains((long)x.BfsTransactionDetailId))
                              select x.BfsTransactionDetailId
                ).ToList();
            // var data = (from x in ctx.TblBfsTransactiondetails.Where(x=>x.BfsMsgType != "DR" && x.BfsOrderNo!=null && x.BfsOrderNo== DataBFSAC.FirstOrDefault())
            //var data = (from x in ctx.TblBfsTransactiondetails.Where(x => x.BfsMsgType != "DR" && x.BfsOrderNo != null && DataBFSAC.Contains(x.BfsOrderNo))
            var data = (from x in ctx.TblBfsTransactiondetails.Where(x => x.BfsMsgType == "AC" && x.BfsOrderNo != null && DataBFSAC.Contains(x.BfsOrderNo) && !ledgerData.Contains(x.BfsTransactionDetailId))
                            // join d in ctx.TblLedger on x.BfsTransactionDetailId equals d.BfsTransactionDetailId
                            //join td in ctx.TblTransactionDetail on d.TransactionId equals td.TransactionId
                            //join ty in ctx.MstTransactionType on td.TransactionTypeId equals ty.TransactionTypeId
                            // where d.IsCancelled==false && d.IsPaymentMade == false
                        select new BfsModel
                        {
                            BfsTransactionDetailId = x.BfsTransactionDetailId,
                            BfsMsgType = x.BfsMsgType,
                            BfsBenfId = x.BfsBenfId,
                            BfsOrderNo = x.BfsOrderNo,
                            BfsTxnAmount = x.BfsTxnAmount,
                            BfsTxnTime = x.BfsTxnTime,
                            BfsBfsTxnId = x.BfsBfsTxnId,
                            BfsRemitterAccNo = x.BfsRemitterAccNo,
                            BfsBankName = x.BfsBankName,
                            BfsDebitAuthCode = x.BfsDebitAuthCode,
                            CreatedOn = x.CreatedOn,
                            CreatedBy = x.CreatedBy,
                            TransactionType = ctx.MstTransactionType.Where(s => s.TransactionTypeId == (ctx.TblTransactionDetail.Where(t => t.TransactionId == (ctx.TblDemand.Where(v => v.BfsTransactionDetailId == x.BfsTransactionDetailId).FirstOrDefault().TransactionId)).FirstOrDefault().TransactionTypeId)).FirstOrDefault().TransactionType
                            // UserName = u.FirstName + ' ' + u.MiddleName + ' ' + u.LastName

                        });
            return data.ToList();
        }

        public List<BfsModel> Search(string search)
        {
          
            var DataBFSAC = (
                 from x in ctx.TblBfsTransactiondetails.Where(x=>x.BfsMsgType=="AR")
                 join d in ctx.TblDemand on x.BfsTransactionDetailId equals d.BfsTransactionDetailId
                 join u in ctx.AspNetUsers on x.CreatedBy equals u.UserId
                 join t in ctx.MstTaxPayerProfile on d.TaxPayerId equals t.TaxPayerId
                             into t_temp
                 from t_value in t_temp.DefaultIfEmpty()

                 join w in ctx.TblWaterMeterReading on d.WaterMeterReadingId equals w.WaterMeterReadingId
                 into w_temp
                 from w_value in w_temp.DefaultIfEmpty()

                 join mw in ctx.MstWaterConnection on w_value.WaterConnectionId equals mw.WaterConnectionId
                 into mw_temp
                 from mw_value in mw_temp.DefaultIfEmpty()

                 where d.IsCancelled == false && d.IsPaymentMade == false && mw_value.ConsumerNo == search || t_value.Ttin == search || t_value.Cid == search

                 select x.BfsOrderNo
                 ).ToList();
            var ACID = (from x in ctx.TblBfsTransactiondetails.Where(x => x.BfsMsgType == "AC" && x.BfsOrderNo != null && DataBFSAC.Contains(x.BfsOrderNo))
                        select x.BfsTransactionDetailId
                        ).ToList();
            var ledgerData = (from x in ctx.TblLedger.Where(x=>x.BfsTransactionDetailId !=null && ACID.Contains((long)x.BfsTransactionDetailId))
                select  x.BfsTransactionDetailId
                ).ToList();
            // var data = (from x in ctx.TblBfsTransactiondetails.Where(x=>x.BfsMsgType != "DR" && x.BfsOrderNo!=null && x.BfsOrderNo== DataBFSAC.FirstOrDefault())
            //var data = (from x in ctx.TblBfsTransactiondetails.Where(x => x.BfsMsgType != "DR" && x.BfsOrderNo != null && DataBFSAC.Contains(x.BfsOrderNo))
            var data = (from x in ctx.TblBfsTransactiondetails.Where(x => x.BfsMsgType == "AC" && x.BfsOrderNo != null && DataBFSAC.Contains(x.BfsOrderNo)  && !ledgerData.Contains(x.BfsTransactionDetailId))
                       // join d in ctx.TblLedger on x.BfsTransactionDetailId equals d.BfsTransactionDetailId
                        //join td in ctx.TblTransactionDetail on d.TransactionId equals td.TransactionId
                        //join ty in ctx.MstTransactionType on td.TransactionTypeId equals ty.TransactionTypeId
                       // where d.IsCancelled==false && d.IsPaymentMade == false
                        select new BfsModel
                        {
                            BfsTransactionDetailId = x.BfsTransactionDetailId,
                            BfsMsgType = x.BfsMsgType,
                            BfsBenfId = x.BfsBenfId,
                            BfsOrderNo = x.BfsOrderNo,
                            BfsTxnAmount = x.BfsTxnAmount,
                            BfsTxnTime = x.BfsTxnTime,
                            BfsBfsTxnId = x.BfsBfsTxnId,
                            BfsRemitterAccNo = x.BfsRemitterAccNo,
                            BfsBankName = x.BfsBankName,
                            BfsDebitAuthCode = x.BfsDebitAuthCode,
                            CreatedOn = x.CreatedOn,
                            CreatedBy = x.CreatedBy,
                            TransactionType = ctx.MstTransactionType.Where(s=>s.TransactionTypeId==(ctx.TblTransactionDetail.Where(t=>t.TransactionId==(ctx.TblDemand.Where(v=>v.BfsTransactionDetailId==x.BfsTransactionDetailId).FirstOrDefault().TransactionId)).FirstOrDefault().TransactionTypeId)).FirstOrDefault().TransactionType
                            // UserName = u.FirstName + ' ' + u.MiddleName + ' ' + u.LastName

                        });
            return data.ToList();
        }



        public List<BfsModel> showDetails(int? id)
        {
            var data = (from x in ctx.TblBfsTransactiondetails.Where(x => x.BfsTransactionDetailId == id)

                        select new BfsModel
                        {
                            BfsTransactionDetailId = x.BfsTransactionDetailId,
                            BfsOrderNo = x.BfsOrderNo,
                            BfsTxnAmount = x.BfsTxnAmount,
                            BfsTxnTime = x.BfsTxnTime,
                            BfsBfsTxnId = x.BfsBfsTxnId,
                            BfsRemitterAccNo = x.BfsRemitterAccNo,
                            BfsBankName = x.BfsBankName,
                            PaymentDate = (DateTime)x.CreatedOn
                        });
            return data.ToList();
        }

        //for Checking BFS 
        public List<BfsModel> bfsCheck(int id)
        {
            var data = (from x in ctx.TblLedger.Where(x => x.BfsTransactionDetailId == id)

                        select new BfsModel
                        {

                            BfsTransactionDetailId = (long)x.BfsTransactionDetailId
                        });
            return data.ToList();
        }


        public static int GetMonthDifference(DateTime startDate, DateTime endDate)
        {
            int monthsApart = 12 * (startDate.Year - endDate.Year) + startDate.Month - endDate.Month;
            return Math.Abs(monthsApart);
        }
        public long SavePaymentSuccess(BfsModel objBfs)
        {
            try
            {
                long rpk = 0;

                using (TransactionScope s = new TransactionScope())
                {

                    //SAVE LEDGER
                    var sBfsTransactionDetailData = ctx.TblBfsTransactiondetails.Single(l =>  l.BfsTransactionDetailId == objBfs.BfsTransactionDetailId);
                    var bfSpk = sBfsTransactionDetailData.BfsTransactionDetailId;
                    var bfcCreatedOn = sBfsTransactionDetailData.CreatedOn;
                    var bfcOrderNo = sBfsTransactionDetailData.BfsOrderNo;
                    var bfsAmount = sBfsTransactionDetailData.BfsTxnAmount;
                    var bfsModeno = sBfsTransactionDetailData.BfsBfsTxnId;
                   

                    var sBfsARTransactionDetailData = ctx.TblBfsTransactiondetails.Single(l =>l.BfsMsgType=="AR" && l.BfsOrderNo == bfcOrderNo);
                    var bfsARpk = sBfsARTransactionDetailData.BfsTransactionDetailId;
                    var DemandList = ctx.TblDemand.Where(o => o.BfsTransactionDetailId == bfsARpk).Select(s => s.DemandId);

                    var DemandData = ctx.TblDemand.Where(u => DemandList.Contains(u.DemandId));

                    //LEDGER INSERT
                    // int sq = ctx.TblReceipt.Where(p => p.ReceiptYear == DateTime.Now.Year).Max(p => p.Sl);
                    int sq = ctx.TblReceipt.Where(p => p.ReceiptYear == Convert.ToInt32(DateTime.Now.Year)).Select(p => p.Sl).Cast<int?>().Max() ?? 0;
                    sq = sq + 1;
                    var receiptno = "";
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
                            PaymentDate =(DateTime) bfcCreatedOn,
                            ReceiptId = rpk,
                            CreatedBy = 192,
                            CreatedOn = DateTime.Now,
                         
                            PenaltyPeriod = trn.TransactionTypeId == 19 ? GetMonthDifference(dmd.BillingDate, (DateTime)bfcCreatedOn) :
                                        trn.TransactionTypeId == 20 ? ((((DateTime)bfcCreatedOn - cy.EndDate).Days) < 0 ? 0 : (((DateTime)bfcCreatedOn - cy.EndDate).Days)) :


                                     
                                         trn.TransactionTypeId == 15 ? ((DateTime)bfcCreatedOn < ctx.TblHouseRentDemandDetail.Single(h => h.HouseRentDemandDetailId == dmd.HouseRentDemandDetailId).InstallmentDate) ? 0 :
                                        (GetMonthDifference(ctx.TblHouseRentDemandDetail.Single(h => h.HouseRentDemandDetailId == dmd.HouseRentDemandDetailId).InstallmentDate, (DateTime)bfcCreatedOn) > 1 && ((DateTime)bfcCreatedOn).Day <= 10) ? (GetMonthDifference(ctx.TblHouseRentDemandDetail.Single(h => h.HouseRentDemandDetailId == dmd.HouseRentDemandDetailId).InstallmentDate, (DateTime)bfcCreatedOn) - 1) :
                                        (GetMonthDifference(ctx.TblHouseRentDemandDetail.Single(h => h.HouseRentDemandDetailId == dmd.HouseRentDemandDetailId).InstallmentDate, (DateTime)bfcCreatedOn) > 1 && ((DateTime)bfcCreatedOn).Day > 10) ? GetMonthDifference(ctx.TblHouseRentDemandDetail.Single(h => h.HouseRentDemandDetailId == dmd.HouseRentDemandDetailId).InstallmentDate, (DateTime)bfcCreatedOn) :
                                        (GetMonthDifference(ctx.TblHouseRentDemandDetail.Single(h => h.HouseRentDemandDetailId == dmd.HouseRentDemandDetailId).InstallmentDate, (DateTime)bfcCreatedOn) < 1) ? 0 :
                                        (((DateTime)bfcCreatedOn).Day > 10 && (GetMonthDifference(ctx.TblHouseRentDemandDetail.Single(h => h.HouseRentDemandDetailId == dmd.HouseRentDemandDetailId).InstallmentDate, (DateTime)bfcCreatedOn) == 1)) ?
                                        GetMonthDifference(ctx.TblHouseRentDemandDetail.Single(h => h.HouseRentDemandDetailId == dmd.HouseRentDemandDetailId).InstallmentDate, (DateTime)bfcCreatedOn) : 0 :



                                        trn.TransactionTypeId == 17 ? ((DateTime)bfcCreatedOn < ctx.TblStallDetailDemand.Single(h => h.StallDemandDetailId == dmd.StallDemandDetailId).InstallmentDate) ? 0 :
                                        (GetMonthDifference(ctx.TblStallDetailDemand.Single(h => h.StallDemandDetailId == dmd.StallDemandDetailId).InstallmentDate, (DateTime)bfcCreatedOn) > 1 && ((DateTime)bfcCreatedOn).Day <= 10) ? (GetMonthDifference(ctx.TblStallDetailDemand.Single(h => h.StallDemandDetailId == dmd.StallDemandDetailId).InstallmentDate, (DateTime)bfcCreatedOn) - 1) :
                                        (GetMonthDifference(ctx.TblStallDetailDemand.Single(h => h.StallDemandDetailId == dmd.StallDemandDetailId).InstallmentDate, (DateTime)bfcCreatedOn) > 1 && ((DateTime)bfcCreatedOn).Day > 10) ? GetMonthDifference(ctx.TblStallDetailDemand.Single(h => h.StallDemandDetailId == dmd.StallDemandDetailId).InstallmentDate, (DateTime)bfcCreatedOn) :
                                        (GetMonthDifference(ctx.TblStallDetailDemand.Single(h => h.StallDemandDetailId == dmd.StallDemandDetailId).InstallmentDate, (DateTime)bfcCreatedOn) < 1) ? 0 :
                                        (((DateTime)bfcCreatedOn).Day > 10 && (GetMonthDifference(ctx.TblStallDetailDemand.Single(h => h.StallDemandDetailId == dmd.StallDemandDetailId).InstallmentDate, (DateTime)bfcCreatedOn) == 1)) ?
                                        GetMonthDifference(ctx.TblStallDetailDemand.Single(h => h.StallDemandDetailId == dmd.StallDemandDetailId).InstallmentDate, (DateTime)bfcCreatedOn) : 0 :



                                        trn.TransactionTypeId == 18 ? ((((DateTime)bfcCreatedOn).AddMonths(-1) - (ctx.TblParkingFeeDemandDetail.Single(h => h.ParkingDemandDetailId == dmd.ParkingDemandDetailId).InstallmentDate)).Days) :
                                        item.TaxId == 20 ? ((((DateTime)bfcCreatedOn).AddMonths(-1) - (ctx.TblLandLeaseDemandDetail.Single(h => h.LandLeaseDemandDetailId == dmd.LandLeaseDemandDetailId).InstallmentDate)).Days) :
                                          item.TaxId == 21 ? 0 :
                                            0,




                            PenaltyAmount =
                        trn.TransactionTypeId == 19 ? ((tp.FirstOrDefault().PenaltyOrRate * dmd.TotalAmount) * GetMonthDifference(dmd.BillingDate, (DateTime)bfcCreatedOn) / (12 * 100)) :
                        trn.TransactionTypeId == 20 ? ((tp.FirstOrDefault().PenaltyOrRate * dmd.TotalAmount) * ((((DateTime)bfcCreatedOn - cy.EndDate).Days) < 0 ? 0 : (((DateTime)bfcCreatedOn - cy.EndDate).Days)) / (365 * 100)) :

                        trn.TransactionTypeId == 15 ? (((tp.FirstOrDefault().PenaltyOrRate * dmd.TotalAmount) / 100) * (((DateTime)bfcCreatedOn < ctx.TblHouseRentDemandDetail.Single(h => h.HouseRentDemandDetailId == dmd.HouseRentDemandDetailId).InstallmentDate) ? 0 :
                                        (GetMonthDifference(ctx.TblHouseRentDemandDetail.Single(h => h.HouseRentDemandDetailId == dmd.HouseRentDemandDetailId).InstallmentDate, (DateTime)bfcCreatedOn) > 1 && ((DateTime)bfcCreatedOn).Day <= 10) ? (GetMonthDifference(ctx.TblHouseRentDemandDetail.Single(h => h.HouseRentDemandDetailId == dmd.HouseRentDemandDetailId).InstallmentDate, (DateTime)bfcCreatedOn) - 1) :
                                        (GetMonthDifference(ctx.TblHouseRentDemandDetail.Single(h => h.HouseRentDemandDetailId == dmd.HouseRentDemandDetailId).InstallmentDate, (DateTime)bfcCreatedOn) > 1 && ((DateTime)bfcCreatedOn).Day > 10) ? GetMonthDifference(ctx.TblHouseRentDemandDetail.Single(h => h.HouseRentDemandDetailId == dmd.HouseRentDemandDetailId).InstallmentDate, (DateTime)bfcCreatedOn) :
                                        (GetMonthDifference(ctx.TblHouseRentDemandDetail.Single(h => h.HouseRentDemandDetailId == dmd.HouseRentDemandDetailId).InstallmentDate, (DateTime)bfcCreatedOn) < 1) ? 0 :
                                        (((DateTime)bfcCreatedOn).Day > 10 && (GetMonthDifference(ctx.TblHouseRentDemandDetail.Single(h => h.HouseRentDemandDetailId == dmd.HouseRentDemandDetailId).InstallmentDate, (DateTime)bfcCreatedOn) == 1)) ?
                                        GetMonthDifference(ctx.TblHouseRentDemandDetail.Single(h => h.HouseRentDemandDetailId == dmd.HouseRentDemandDetailId).InstallmentDate, (DateTime)bfcCreatedOn) : 0)) :

                        // trn.TransactionTypeId == 17 ? (((tp.FirstOrDefault().PenaltyOrRate * dmd.TotalAmount)/100) * ((DateTime.Today < ctx.TblStallDetailDemand.Single(h => h.StallDemandDetailId == dmd.StallDemandDetailId).InstallmentDate) ? 0 :  GetMonthDifference(ctx.TblStallDetailDemand.Single(h => h.StallDemandDetailId == dmd.StallDemandDetailId).InstallmentDate, DateTime.Today))): 
                        trn.TransactionTypeId == 17 ? (((tp.FirstOrDefault().PenaltyOrRate * dmd.TotalAmount) / 100) * ((DateTime.Today < ctx.TblStallDetailDemand.Single(h => h.StallDemandDetailId == dmd.StallDemandDetailId).InstallmentDate) ? 0 :
                                        (GetMonthDifference(ctx.TblStallDetailDemand.Single(h => h.StallDemandDetailId == dmd.StallDemandDetailId).InstallmentDate, (DateTime)bfcCreatedOn) > 1 && ((DateTime)bfcCreatedOn).Day <= 10) ? (GetMonthDifference(ctx.TblStallDetailDemand.Single(h => h.StallDemandDetailId == dmd.StallDemandDetailId).InstallmentDate, (DateTime)bfcCreatedOn) - 1) :
                                        (GetMonthDifference(ctx.TblStallDetailDemand.Single(h => h.StallDemandDetailId == dmd.StallDemandDetailId).InstallmentDate, (DateTime)bfcCreatedOn) > 1 && ((DateTime)bfcCreatedOn).Day > 10) ? GetMonthDifference(ctx.TblStallDetailDemand.Single(h => h.StallDemandDetailId == dmd.StallDemandDetailId).InstallmentDate, (DateTime)bfcCreatedOn) :
                                        (GetMonthDifference(ctx.TblStallDetailDemand.Single(h => h.StallDemandDetailId == dmd.StallDemandDetailId).InstallmentDate, (DateTime)bfcCreatedOn) < 1) ? 0 :
                                        (((DateTime)bfcCreatedOn).Day > 10 && (GetMonthDifference(ctx.TblStallDetailDemand.Single(h => h.StallDemandDetailId == dmd.StallDemandDetailId).InstallmentDate, (DateTime)bfcCreatedOn) == 1)) ?
                                        GetMonthDifference(ctx.TblStallDetailDemand.Single(h => h.StallDemandDetailId == dmd.StallDemandDetailId).InstallmentDate, (DateTime)bfcCreatedOn) : 0)) :

                            trn.TransactionTypeId == 18 ? (((tp.FirstOrDefault().PenaltyOrRate * dmd.TotalAmount) / (100 * 365)) * ((((DateTime)bfcCreatedOn).AddMonths(-1) - (ctx.TblParkingFeeDemandDetail.Single(h => h.ParkingDemandDetailId == dmd.ParkingDemandDetailId).InstallmentDate)).Days)) :

                      item.TaxId == 20 ? (((tp.FirstOrDefault().PenaltyOrRate * dmd.TotalAmount) / (100 * 365)) * ((((DateTime)bfcCreatedOn).AddMonths(-1) - (ctx.TblLandLeaseDemandDetail.Single(h => h.LandLeaseDemandDetailId == dmd.LandLeaseDemandDetailId).InstallmentDate)).Days)) :
                      item.TaxId == 21 ? Convert.ToDecimal((ctx.TblLandLease.Where(ll => ll.LandLeaseId == (ctx.TblLandLeaseDemandDetail.Single(l => l.LandLeaseDemandDetailId == dmd.LandLeaseDemandDetailId).LandLeaseId)).FirstOrDefault().Remarks)) :

                        0,
                            ApplicantId = item.ApplicantId,
                            EcRenewalId = item.EcRenewalId,
                            LandLeaseDemandDetailId = item.LandLeaseDemandDetailId,
                            ParkingDemandDetailId = item.ParkingDemandDetailId,
                            StallDemandDetailId = item.StallDemandDetailId,
                            HouseRentDemandDetailId = item.HouseRentDemandDetailId,
                            MiscellaneousRecordId = item.MiscellaneousRecordId,
                            BfsTransactionDetailId = bfSpk,
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
                        PaymentModeNo = bfsModeno,
                        PaymentModeDate = bfcCreatedOn,
                        Amount = (decimal)bfsAmount,
                        
                        //BankBranchId = BranchId,
                        ReceiptId = rpk,
                        BfsTransactionDetailId = bfSpk,
                        CreatedBy = 192,
                        CreatedOn = DateTime.Now,
                      
                };
                    ctx.TblPaymentLeger.Add(entityPL);
                    ctx.SaveChanges();
                   // rpk = entityPL.PaymentLedgerId;
                    //LEDGER END

                    foreach (var item in DemandData)
                    {
                        var Data1 = ctx.TblDemand.Where(u => u.DemandId == item.DemandId);
                        Data1.FirstOrDefault().IsPaymentMade = true;
                        Data1.FirstOrDefault().PaymentDate = bfcCreatedOn;
                        ctx.SaveChanges();
                    }

                    s.Complete();
                    s.Dispose();
                    return rpk;
                }
            }
            catch (Exception ex)
            {
                return 0;
            }
           


        }
    }
}
