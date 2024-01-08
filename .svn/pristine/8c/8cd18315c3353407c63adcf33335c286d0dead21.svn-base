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
    public class DepositBLL : IDeposit
    {
        readonly tt_dbContext ctx = new tt_dbContext();

        public IEnumerable<DepositVM> GetDepositDetails(int StartDate, int EndDate)
        {
            try
            {
                var result = ctx.CollectionByFromDateToDate.FromSqlRaw($"spCollectionByFromDateToDate {StartDate},{EndDate}");

                return result.ToList();

            }
            catch (Exception ex)
            {
                return null;

            }
        }


        public int SaveDeposit(DepositSaveVM obj)
        {
            try
            {
                
                using TransactionScope s = new TransactionScope();
                long ipk;
                var entity = new TblDeposit
                {
                    DepositId = obj.DepositId,
                    PaymentLedgerId = obj.PaymentLedgerId,
                    DepositAmount = obj.DepositAmount,
                    PaymentFromDate = obj.PaymentFromDate,
                    PaymentToDate = obj.PaymentToDate,
                    DepositDate = obj.DepositDate,
                    CreatedBy = obj.CreatedBy,
                    CreatedOn = Convert.ToDateTime(obj.CreatedOn),

                };
                ctx.TblDeposit.Add(entity);
                ctx.SaveChanges();
                s.Complete();
                s.Dispose();
                ipk = entity.DepositId;

                return (int)ipk;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }


        public List<DepositSaveVM> GetDepositupdatedisplay(string ChequeNo)
        {

            var data = (from pl in ctx.TblPaymentLeger.Where(pl => pl.PaymentModeNo == ChequeNo)
                        join pm in ctx.EnumPaymentMode on pl.PaymentModeId equals pm.PaymentModeId
                        join bb in ctx.MstBankBranch on pl.BankBranchId equals bb.BankBranchId
                        let td = ctx.TblDeposit.Where(y => y.PaymentLedgerId == pl.PaymentLedgerId).Max(x => x.DepositId)

                        select new DepositSaveVM
                        {

                            PaymentMode = pm.PaymentMode,
                            PaymentModeNo = pl.PaymentModeNo,
                            PaymentModeDate = (DateTime)pl.PaymentModeDate,
                            BranchName = bb.BranchName,
                            Amount = pl.Amount,
                            DepositId = td

                        });

            return data.ToList();
        }
        public IList<DepositSaveVM> GetDate()
        {

            var data = (from pl in ctx.TblDeposit
                       

                        select new DepositSaveVM
                        {

                            PaymentFromDate = pl.PaymentFromDate,
                            PaymentToDate = pl.PaymentToDate

                        });

            return data.ToList();
        }
        public bool DateIfExists(DateTime StartDate, DateTime EndDate)
        {
            return ctx.TblDeposit.Any(e => e.PaymentFromDate == StartDate && e.PaymentToDate == EndDate);
        }
        public long Update(DepositSaveVM obj)
        {
            try
            {
                using (TransactionScope s = new TransactionScope())
                {

                    var Data = ctx.TblDeposit.FirstOrDefault(u => u.DepositId == obj.DepositId);
                    Data.PaymentStatusId = obj.PaymentStatusId;


                   
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

        public bool DuplicateCheck(DateTime PaymentToDate, DateTime PaymentFromDate)
        {
            return ctx.TblDeposit.Any(e => e.PaymentToDate == PaymentToDate && e.PaymentFromDate == PaymentFromDate);
        }


        public IEnumerable<PaymentDepositReportVM> GetPaymentDepositReport(int StartDate, int EndDate)
        {
            try
            {
                var result = ctx.PaymentDepositReport.FromSqlRaw($"spPaymentDepositReport {StartDate},{EndDate}");

                return result.ToList();

            }
            catch (Exception ex)
            {
                return null;

            }
        }

        public IList<IndividualDetails> GetAll()
        {
            var data = (from x in ctx.TblPaymentLeger
                        join d in ctx.TblDeposit on x.PaymentLedgerId equals d.PaymentLedgerId
                        
                        join un in ctx.AspNetUsers on x.CreatedBy equals un.UserId
                        select new IndividualDetails
                        {
                            CreatedBy = un.FirstName + " " + ((un.MiddleName == null || un.MiddleName.Trim() == string.Empty) ? string.Empty : (un.MiddleName + " ")) + ((un.LastName == null || un.LastName.Trim() == string.Empty) ? string.Empty : (un.LastName + " ")),
                            PaymentFromDate = d.PaymentFromDate,
                            PaymentToDate = d.PaymentToDate
                        });
            return data.ToList();
        }
    }
}
