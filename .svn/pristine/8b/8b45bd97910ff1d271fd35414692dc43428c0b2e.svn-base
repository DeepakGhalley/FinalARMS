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
    public class LapBLL : ILap
    {
        readonly tt_dbContext ctx = new tt_dbContext();

        public IList<LapModel> GetAll()
        {
            var data = (from x in ctx.MstLap
                        select new LapModel
                        {
                            LapId = x.LapId,
                            LapName = x.LapName,
                            LapDescription = x.LapDescription,
                            IsActive = x.IsActive,
                            CreatedBy = x.CreatedBy,
                            CreatedOn = x.CreatedOn,
                            ModifiedOn = x.ModifiedOn,
                            ModifiedBy = x.ModifiedBy
                        });
            return data.ToList();

        }

        public async Task<LapModel> Details(int? id)
        {
            var data = (from a in ctx.MstLap.Where(aa => aa.LapId == id)
                        select new LapModel
                        {
                            LapId = a.LapId,
                            LapName = a.LapName,
                            LapDescription = a.LapDescription,
                            IsActive = a.IsActive,
                            CreatedBy = a.CreatedBy,
                            CreatedOn = a.CreatedOn,
                            ModifiedBy = a.ModifiedBy,
                            ModifiedOn = a.ModifiedOn

                        });

            return await data.FirstOrDefaultAsync();

        }
        public int SaveLap(LapModel obj)
        {
            try
            {
                using TransactionScope s = new TransactionScope();
                int ipk;
                var entity = new MstLap
                {
                    LapId = obj.LapId,
                    LapName = obj.LapName,
                    LapDescription = obj.LapDescription,
                    IsActive = obj.IsActive,
                    CreatedBy = obj.CreatedBy,
                    CreatedOn = Convert.ToDateTime(obj.CreatedOn),
                };
                ctx.MstLap.Add(entity);
                ctx.SaveChanges();
                s.Complete();
                s.Dispose();
                ipk = entity.LapId;

                return ipk;
            }
            catch (System.Exception)
            {
                return 0;
            }
        }

        public int UpdateLap(LapModel obj)
        {
            try
            {
                using (TransactionScope s = new TransactionScope())
                {
                    var Data = ctx.MstLap.FirstOrDefault(u => u.LapId == obj.LapId);
                    Data.LapName = obj.LapName; Data.LapDescription = obj.LapDescription; Data.IsActive = obj.IsActive;
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
            return ctx.MstLap.Any(e => e.LapId == id);
        }

        public async Task DeleteConfirmed(int id)
        {
            using (TransactionScope s = new TransactionScope())
            {
                var MstLap = ctx.MstLap.Find(id);
                ctx.MstLap.Remove(MstLap);
                ctx.SaveChanges();
                s.Complete();
                s.Dispose();

            }
        }

        public async Task Delete(int? id)
        {
            var MstLap = await ctx.MstLap
                           .FirstOrDefaultAsync(m => m.LapId == id);
        }
        public bool DuplicateCheckOnSave(string LapName)
        {
            return ctx.MstLap.Any(e => e.LapName == LapName);
        }
        public bool DuplicateCheckOnUpdate(string LapName, int LapId)
        {
            return ctx.MstLap.Any(e => e.LapName == LapName && e.LapId != LapId);
        }
    }
}
