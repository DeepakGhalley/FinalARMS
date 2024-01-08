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
    public class GewogBLL : IGewog
    {
        readonly tt_dbContext ctx = new tt_dbContext();

        public IList<GewogModel> GetAll()
        {
            var data = (from x in ctx.MstGewog
                        join y in ctx.MstDzongkhag on x.DzongkhagId equals y.DzongkhagId
                        select new GewogModel
                        {
                            GewogId = x.GewogId,
                            GewogName = x.GewogName,
                            DzongkhagId = x.DzongkhagId,
                            DzongkhagName= y.DzongkhagName,
                            IsActive = x.IsActive,
                            CreatedBy = x.CreatedBy,
                            CreatedOn = x.CreatedOn,
                            ModifiedOn = x.ModifiedOn,
                            ModifiedBy = x.ModifiedBy
                        });
            return data.ToList();

        }

        public async Task<GewogModel> Details(int? id)
        {
            var data = (from a in ctx.MstGewog.Where(aa => aa.GewogId == id)
                        select new GewogModel
                        {
                            GewogId = a.GewogId,
                            DzongkhagId = a.DzongkhagId,
                            GewogName = a.GewogName,
                            IsActive = a.IsActive,
                            CreatedBy = a.CreatedBy,
                            CreatedOn = a.CreatedOn,
                            ModifiedBy = a.ModifiedBy,
                            ModifiedOn = a.ModifiedOn

                        });

            return await data.FirstOrDefaultAsync();

        }
        public int SaveGewog(GewogModel obj)
        {
            try
            {
                using TransactionScope s = new TransactionScope();
                int ipk;
                var entity = new MstGewog
                {
                    GewogId = obj.GewogId,
                    DzongkhagId = obj.DzongkhagId,
                    GewogName = obj.GewogName,
                    IsActive = obj.IsActive,
                    CreatedBy = obj.CreatedBy,
                    CreatedOn = Convert.ToDateTime(obj.CreatedOn),
                };
                ctx.MstGewog.Add(entity);
                ctx.SaveChanges();
                s.Complete();
                s.Dispose();
                ipk = entity.GewogId;

                return ipk;
            }
            catch (System.Exception)
            {
                return 0;
            }
        }

        public int UpdateGewog(GewogModel obj)
        {
            try
            {
                using (TransactionScope s = new TransactionScope())
                {
                    var Data = ctx.MstGewog.FirstOrDefault(u => u.GewogId == obj.GewogId);
                    Data.GewogName = obj.GewogName; Data.DzongkhagId = obj.DzongkhagId;Data.IsActive = obj.IsActive;
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
            return ctx.MstGewog.Any(e => e.GewogId == id);
        }

        public async Task DeleteConfirmed(int id)
        {
            using (TransactionScope s = new TransactionScope())
            {
                var MstGewog = ctx.MstGewog.Find(id);
                ctx.MstGewog.Remove(MstGewog);
                ctx.SaveChanges();
                s.Complete();
                s.Dispose();

            }
        }

        public async Task Delete(int? id)
        {
            var MstGewog = await ctx.MstGewog
                           .FirstOrDefaultAsync(m => m.GewogId == id);
        }
        public bool DuplicateCheckOnSave(string GewogName)
        {
            return ctx.MstGewog.Any(e => e.GewogName == GewogName);
        }
        public bool DuplicateCheckOnUpdate(string GewogName, int DzongkhagId, int GewogId)
        {
            return ctx.MstGewog.Any(e => e.GewogName == GewogName && e.DzongkhagId == DzongkhagId && e.GewogId != GewogId);
        }
    }
}
