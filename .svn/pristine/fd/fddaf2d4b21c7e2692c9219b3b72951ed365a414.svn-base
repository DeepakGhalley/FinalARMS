using CORE_BOL;
using CORE_BOL.Entities;
using CORE_DLL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace CORE_BLL
{
    public class TaxPeriodBLL : ITaxPeriod
    {
        readonly tt_dbContext ctx = new tt_dbContext();
        public bool CheckExists(int id)
        {
            return ctx.MstTaxPeriod.Any(e => e.TaxPeriodId == id);
        }

        public Task Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteConfirmed(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<TaxPeriodVM> Details(int? id)
        {
            var data = (from a in ctx.MstTaxPeriod.Where(aa => aa.TaxPeriodId == id)
                        join b in ctx.MstTransactionType on a.TransactionTypeId equals b.TransactionTypeId
                        join c in ctx.MstCalendarYear on a.CalendarYearId equals c.CalendarYearId

                        select new TaxPeriodVM
                        {
                            TaxPeriodId = a.TaxPeriodId,
                            TransactionTypeId = a.TransactionTypeId,
                            CalendarYearId = a.CalendarYearId,
                            EffectiveDate = a.EffectiveDate,
                            Penalty = a.PenaltyOrRate,
                            CreatedBy = a.CreatedBy,
                            CreatedOn = a.CreatedOn,
                            ModifiedBy = a.ModifiedBy,
                            ModifiedOn = a.ModifiedOn

                        });

            return await data.FirstOrDefaultAsync();
        }

        public IList<TaxPeriodVM> GetAll()
        {
            var data = (from x in ctx.MstTaxPeriod
                        join a in ctx.MstTransactionType on x.TransactionTypeId equals a.TransactionTypeId

                        join c in ctx.MstCalendarYear on x.CalendarYearId equals c.CalendarYearId
                        orderby x.TransactionTypeId ascending, x.EffectiveDate  descending
                        select new TaxPeriodVM
                        {
                            TaxPeriodId = x.TaxPeriodId,
                            TransactionTypeId = x.TransactionTypeId,
                            CalendarYearId = x.CalendarYearId,
                            CalendarYr=c.CalendarYear,
                            TaxTypeClass = a.TransactionType,
                            EffectiveDate = x.EffectiveDate,
                            Penalty = x.PenaltyOrRate,
                            CreatedBy = x.CreatedBy,
                            CreatedOn = x.CreatedOn,
                            ModifiedBy = x.ModifiedBy,
                            ModifiedOn = x.ModifiedOn
                        });
            return data.ToList();
        }

        public int Save(TaxPeriodVM obj)
        {
            try
            {
                using TransactionScope s = new TransactionScope();
                int ipk;
                var entity = new MstTaxPeriod
                {
                    TaxPeriodId = obj.TaxPeriodId,
                     CalendarYearId = obj.CalendarYearId,
                    TransactionTypeId = obj.TransactionTypeId,
                    EffectiveDate = obj.EffectiveDate,
                    PenaltyOrRate = obj.Penalty,
                    CreatedBy = obj.CreatedBy,
                    CreatedOn = Convert.ToDateTime(obj.CreatedOn),
                };
                ctx.MstTaxPeriod.Add(entity);
                ctx.SaveChanges();
                s.Complete();
                s.Dispose();
                ipk = entity.TaxPeriodId;

                return ipk;
            }
            catch (System.Exception)
            {
                return 0;
            }
        }

        public int Update(TaxPeriodVM obj)
        {
            try
            {
                using (TransactionScope s = new TransactionScope())
                {
                    var Data = ctx.MstTaxPeriod.FirstOrDefault(u => u.TaxPeriodId == obj.TaxPeriodId);
                    Data.TransactionTypeId = obj.TransactionTypeId;
                    Data.CalendarYearId = obj.CalendarYearId;
                    Data.EffectiveDate = obj.EffectiveDate;
                    Data.PenaltyOrRate = obj.Penalty;
                    Data.ModifiedBy = obj.ModifiedBy; Data.ModifiedOn = obj.ModifiedOn;
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
