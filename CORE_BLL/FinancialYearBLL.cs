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
  public  class FinancialYearBLL : IFinancialYear
    {

        readonly tt_dbContext ctx = new tt_dbContext();
        public IList<FinancialYearVM> GetAll()
        {
            try
            {
                var data = (from x in ctx.MstFinancialYear
                            select new FinancialYearVM
                            {
                                FinancialYearId = x.FinancialYearId,
                                FinancialYear = x.FinancialYear,
                                StartDate = x.StartDate,
                                EndDate = x.EndDate,                               
                                IsActive = x.IsActive,
                                CreatedBy = x.CreatedBy,
                                CreatedOn = x.CreatedOn,
                                ModifiedOn = x.ModifiedOn,
                                ModifiedBy = x.ModifiedBy
                            });
                return data.ToList();
            }
            catch (Exception ex)
            {

                throw;
            }

        }
        public int Save(FinancialYearVM obj)
        {
            try
            {
                using (TransactionScope s = new TransactionScope())
                {
                    int ipk;
                    var entity = new MstFinancialYear
                    {
                        FinancialYearId = obj.FinancialYearId,
                        FinancialYear = obj.FinancialYear,
                        StartDate = obj.StartDate,
                        EndDate = obj.EndDate,                      
                        IsActive = true,
                        CreatedBy = obj.CreatedBy,
                        CreatedOn = Convert.ToDateTime(obj.CreatedOn),
                    };
                    ctx.MstFinancialYear.Add(entity);
                    ctx.SaveChanges();
                    s.Complete();
                    s.Dispose();
                    ipk = entity.FinancialYearId;

                    return ipk;
                }
            }

            catch (Exception ex)
            {

                throw;
            }
        }
        public async Task<FinancialYearVM> Details(int? id)
        {
            try
            {

                var data = (from a in ctx.MstFinancialYear.Where(aa => aa.FinancialYearId == id)

                            select new FinancialYearVM
                            {
                                FinancialYearId = a.FinancialYearId,
                                FinancialYear = a.FinancialYear,
                                StartDate = a.StartDate,
                                EndDate = a.EndDate,                               
                                IsActive = a.IsActive,
                                CreatedBy = a.CreatedBy,
                                CreatedOn = a.CreatedOn,
                                ModifiedBy = a.ModifiedBy,
                                ModifiedOn = a.ModifiedOn,

                            });

                return await data.FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {

                throw;
            }

        }
        public int Update(FinancialYearVM obj)
        {
            try
            {
                using (TransactionScope s = new TransactionScope())
                {
                    var Data = ctx.MstFinancialYear.FirstOrDefault(u => u.FinancialYearId == obj.FinancialYearId);
                    Data.FinancialYear = obj.FinancialYear; Data.StartDate = obj.StartDate;
                    Data.EndDate = obj.EndDate;
                    Data.IsActive = obj.IsActive; Data.ModifiedBy = obj.ModifiedBy; Data.ModifiedOn = obj.ModifiedOn;
                    ctx.SaveChanges();
                    s.Complete();
                    s.Dispose();
                    return 1;
                }

            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public async Task Delete(int? id)
        {
            try
            {
                var mstFinancialYear = await ctx.MstFinancialYear
                               .FirstOrDefaultAsync(m => m.FinancialYearId == id);
            }
            catch (Exception ex)
            {

                throw;
            }
        }


        public async Task DeleteConfirmed(int id)
        {
            try
            {

                using (TransactionScope s = new TransactionScope())
                {
                    var mstFinancialYear = ctx.MstFinancialYear.Find(id);
                    ctx.MstFinancialYear.Remove(mstFinancialYear);
                    ctx.SaveChanges();
                    s.Complete();
                    s.Dispose();

                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public bool CheckExists(int id)
        {
            try
            {
                return ctx.MstFinancialYear.Any(e => e.FinancialYearId == id);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public bool DuplicateCheckOnSave(string FinancialYear)
        {
            return ctx.MstFinancialYear.Any(e => e.FinancialYear == FinancialYear);
        }

        public bool DuplicateCheckOnUpdate(string FinancialYear, int Id)
        {
            return ctx.MstFinancialYear.Any(e => e.FinancialYear == FinancialYear && e.FinancialYearId != Id);
        }

    }
}
