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
    public class ConditionRatingBLL : IConditionRating
    {
        readonly tt_dbContext ctx = new tt_dbContext();

        public bool CheckExists(int id)
        {
            return ctx.MstConditionRating.Any(e => e.ConditionRatingId == id);
        }

        public async Task Delete(int? id)
        {
            var MstMaintenanceType = await ctx.MstConditionRating
            .FirstOrDefaultAsync(m => m.ConditionRatingId == id);
        }

        public async Task DeleteConfirmed(int id)
        {
            using (TransactionScope s = new TransactionScope())
            {
                var MstConditionRating = ctx.MstConditionRating.Find(id);
                ctx.MstConditionRating.Remove(MstConditionRating);
                ctx.SaveChanges();
                s.Complete();
                s.Dispose();
            }
        }

        public async Task<ConditionRatingVM> Details(int? id)
        {
            var data = (from a in ctx.MstConditionRating.Where(aa => aa.ConditionRatingId == id)
                        select new ConditionRatingVM
                        {
                            ConditionRatingId = a.ConditionRatingId,
                            ConditionRating = a.ConditionRating,
                            ConditionRatingDescription = a.ConditionRatingDescription,
                            IsActive = a.IsActive,
                            CreatedBy = a.CreatedBy,
                            CreatedOn = a.CreatedOn,
                            ModifiedBy = a.ModifiedBy,
                            ModifiedOn = a.ModifiedOn

                        });

            return await data.FirstOrDefaultAsync();
        }

        public IList<ConditionRatingVM> GetAll()
        {
            var data = (from x in ctx.MstConditionRating
                        select new ConditionRatingVM
                        {
                            ConditionRatingId = x.ConditionRatingId,
                            ConditionRating = x.ConditionRating,
                            ConditionRatingDescription = x.ConditionRatingDescription,
                            IsActive = x.IsActive,
                            CreatedBy = x.CreatedBy,
                            CreatedOn = x.CreatedOn,
                            ModifiedBy = x.ModifiedBy,
                            ModifiedOn = x.ModifiedOn
                        });
            return data.ToList();
        }

        public int Save(ConditionRatingVM obj)
        {
            try
            {
                using TransactionScope s = new TransactionScope();
                int ipk;
                var entity = new MstConditionRating
                {
                    ConditionRatingId = obj.ConditionRatingId,
                    ConditionRating = obj.ConditionRating,
                    ConditionRatingDescription = obj.ConditionRatingDescription,
                    IsActive = obj.IsActive,
                    CreatedBy = obj.CreatedBy,
                    CreatedOn = Convert.ToDateTime(obj.CreatedOn),
                };
                ctx.MstConditionRating.Add(entity);
                ctx.SaveChanges();
                s.Complete();
                s.Dispose();
                ipk = entity.ConditionRatingId;

                return ipk;
            }
            catch (System.Exception)
            {
                return 0;
            }
        }

        public int Update(ConditionRatingVM obj)
        {
            try
            {
                using (TransactionScope s = new TransactionScope())
                {
                    var Data = ctx.MstConditionRating.FirstOrDefault(u => u.ConditionRatingId == obj.ConditionRatingId);
                    Data.ConditionRating = obj.ConditionRating; Data.ConditionRatingDescription = obj.ConditionRatingDescription; Data.IsActive = obj.IsActive;
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
        public bool DuplicateCheckOnSave(string ConditionRating)
        {
            return ctx.MstConditionRating.Any(e => e.ConditionRating == ConditionRating);
        }
        public bool DuplicateCheckOnUpdate(string ConditionRating, int Id)
        {
            return ctx.MstConditionRating.Any(e => e.ConditionRating == ConditionRating && e.ConditionRatingId != Id);
        }
    }
}