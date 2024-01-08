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
    public class RateBLL : IRate
    {
        readonly tt_dbContext ctx = new tt_dbContext();

        public bool CheckExists(int id)
        {
            return ctx.MstRate.Any(e => e.RateId == id);
        }

        public Task Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteConfirmed(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<RateVM> Details(int? id)
        {
            var data = (from a in ctx.MstRate.Where(aa => aa.RateId == id)
                        join b in ctx.MstSlab on a.SlabId equals b.SlabId
                        select new RateVM
                        {
                            RateId = a.RateId,
                            TaxId = a.TaxId,
                            SlabId = a.SlabId,
                            Slab = b.SlabName,
                            Rate = a.Rate,
                            MinimumRate = a.MinimumRate,
                            EffectiveDate = a.EffectiveDate,
                            IsActive = a.IsActive,
                            CreatedBy = a.CreatedBy,
                            CreatedOn = a.CreatedOn,
                            ModifiedBy = a.ModifiedBy,
                            ModifiedOn = a.ModifiedOn

                        });

            return await data.FirstOrDefaultAsync();
        }

        public IList<RateVM> GetAll()
        {
            var data = (from x in ctx.MstRate
                        join y in ctx.MstTaxMaster on x.TaxId equals y.TaxId
                        join z in ctx.MstSlab on x.SlabId equals z.SlabId
                        select new RateVM
                        {
                            RateId = x.RateId,
                            TaxId = x.TaxId,
                            TaxName = y.TaxName,
                            SlabId = x.SlabId,
                            Slab = z.SlabName,
                            Rate = x.Rate,
                            MinimumRate = x.MinimumRate,
                            EffectiveDate = x.EffectiveDate,
                            IsActive = x.IsActive,
                            CreatedBy = x.CreatedBy,
                            CreatedOn = x.CreatedOn,
                            ModifiedBy = x.ModifiedBy,
                            ModifiedOn = x.ModifiedOn
                        });
            return data.ToList();
        }

        public int Save(RateVM obj)
        {
            try
            {
                using TransactionScope s = new TransactionScope();
                int ipk;
                var entity = new MstRate
                {
                    RateId = obj.RateId,
                    TaxId = obj.TaxId,
                    SlabId = obj.SlabId,
                    Rate = obj.Rate,
                    MinimumRate = obj.MinimumRate,
                    EffectiveDate = obj.EffectiveDate,
                    IsActive = obj.IsActive,
                    CreatedBy = obj.CreatedBy,
                    CreatedOn = Convert.ToDateTime(obj.CreatedOn),
                    ModifiedBy = obj.ModifiedBy,
                    ModifiedOn = obj.ModifiedOn,
                };
                ctx.MstRate.Add(entity);
                ctx.SaveChanges();
                s.Complete();
                s.Dispose();
                ipk = entity.RateId;

                return ipk;
            }
            catch (System.Exception)
            {
                return 0;
            }
        }

        public int Update(RateVM obj)
        {
            try
            {
                using (TransactionScope s = new TransactionScope())
                {
                    var Data = ctx.MstRate.FirstOrDefault(u => u.RateId == obj.RateId);
                   // Data.RateId = obj.RateId;
                    Data.TaxId = obj.TaxId;
                    Data.SlabId = obj.SlabId;
                    Data.Rate = obj.Rate;
                    Data.MinimumRate = obj.MinimumRate;
                    Data.EffectiveDate = obj.EffectiveDate;
                    Data.IsActive = obj.IsActive;
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
    }
}
