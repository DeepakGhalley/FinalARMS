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
    public class StallLocationBLL : IStallLocation
    {
        readonly tt_dbContext ctx = new tt_dbContext();

        public IList<StallLocationVM> GetAll()
        {
            var data = (from x in ctx.MstStallLocation

                        select new StallLocationVM
                        {
                            StallLocationId = x.StallLocationId,
                            StallLocation = x.StallLocation,
                            StallLocationDetail = x.StallLocationDetail,
                            IsActive = x.IsActive,
                            CreatedBy = x.CreatedBy,
                            CreatedOn = x.CreatedOn,
                            ModifiedOn = x.ModifiedOn,
                            ModifiedBy = x.ModifiedBy
                        });
            return data.ToList();

        }
        public async Task<StallLocationVM> Details(int? id)
        {
            var data = (from a in ctx.MstStallLocation.Where(aa => aa.StallLocationId == id)
                        select new StallLocationVM
                        {
                            StallLocationId = a.StallLocationId,
                            StallLocation = a.StallLocation,
                            StallLocationDetail = a.StallLocationDetail,
                            IsActive = a.IsActive,
                            CreatedBy = a.CreatedBy,
                            CreatedOn = a.CreatedOn,
                            ModifiedBy = a.ModifiedBy,
                            ModifiedOn = a.ModifiedOn

                        });

            return await data.FirstOrDefaultAsync();

        }

        public int Save(StallLocationVM obj)
        {
            try
            {
                using TransactionScope s = new TransactionScope();
                int ipk;
                var entity = new MstStallLocation
                {
                    StallLocationId = obj.StallLocationId,
                    StallLocation = obj.StallLocation,
                    StallLocationDetail = obj.StallLocationDetail,
                    IsActive = obj.IsActive,
                    CreatedBy = obj.CreatedBy,
                    CreatedOn = Convert.ToDateTime(obj.CreatedOn),
                };
                ctx.MstStallLocation.Add(entity);
                ctx.SaveChanges();
                s.Complete();
                s.Dispose();
                ipk = entity.StallLocationId;

                return ipk;
            }
            catch (System.Exception)
            {
                return 0;
            }
        }

        public int Update(StallLocationVM obj)
        {
            try
            {
                using (TransactionScope s = new TransactionScope())
                {
                    var Data = ctx.MstStallLocation.FirstOrDefault(u => u.StallLocationId == obj.StallLocationId);
                    Data.StallLocation = obj.StallLocation; Data.StallLocationDetail = obj.StallLocationDetail; Data.IsActive = obj.IsActive;
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
        public bool CheckExists(int id)
        {
            return ctx.MstStallLocation.Any(e => e.StallLocationId == id);
        }

        public async Task DeleteConfirmed(int id)
        {
            using (TransactionScope s = new TransactionScope())
            {
                var MstStallLocation = ctx.MstStallLocation.Find(id);
                ctx.MstStallLocation.Remove(MstStallLocation);
                ctx.SaveChanges();
                s.Complete();
                s.Dispose();

            }
        }

        public async Task Delete(int? id)
        {
            var MstStallLocation = await ctx.MstStallLocation
                           .FirstOrDefaultAsync(m => m.StallLocationId == id);
        }
      
    }
}
