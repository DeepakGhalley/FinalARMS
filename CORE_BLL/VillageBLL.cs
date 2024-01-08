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
    public class VillageBLL : IVillage
    {
        readonly tt_dbContext ctx = new tt_dbContext();

        public IList<VillageModel> GetAll()
        {
            var data = (from x in ctx.MstVillage
                        join y in ctx.MstGewog on x.GewogId equals y.GewogId

                        select new VillageModel
                        {
                            VillageId = x.VillageId,
                            VillageName = x.VillageName,
                            GewogId = x.GewogId,
                            GewogName = y.GewogName,
                            IsActive = x.IsActive,
                            CreatedBy = x.CreatedBy,
                            CreatedOn = x.CreatedOn,
                            ModifiedOn = x.ModifiedOn,
                            ModifiedBy = x.ModifiedBy
                        });
            return data.ToList();

        }

        public async Task<VillageModel> Details(int? id)
        {
            var data = (from a in ctx.MstVillage.Where(aa => aa.VillageId == id)
                        select new VillageModel
                        {
                            VillageId = a.VillageId,
                            VillageName = a.VillageName,
                            IsActive = a.IsActive,
                            CreatedBy = a.CreatedBy,
                            CreatedOn = a.CreatedOn,
                            ModifiedBy = a.ModifiedBy,
                            ModifiedOn = a.ModifiedOn

                        });

            return await data.FirstOrDefaultAsync();

        }
        public int SaveVillage(VillageModel obj)
        {
            try
            {
                using TransactionScope s = new TransactionScope();
                int ipk;
                var entity = new MstVillage
                {
                    VillageId = obj.VillageId,
                    VillageName = obj.VillageName,
                    GewogId = obj.GewogId,
                    IsActive = obj.IsActive,
                    CreatedBy = obj.CreatedBy,
                    CreatedOn = Convert.ToDateTime(obj.CreatedOn),
                };
                ctx.MstVillage.Add(entity);
                ctx.SaveChanges();
                s.Complete();
                s.Dispose();
                ipk = entity.VillageId;

                return ipk;
            }
            catch (System.Exception)
            {
                return 0;
            }
        }

        public int UpdateVillage(VillageModel obj)
        {
            try
            {
                using (TransactionScope s = new TransactionScope())
                {
                    var Data = ctx.MstVillage.FirstOrDefault(u => u.VillageId == obj.VillageId);
                    Data.GewogId = obj.GewogId; Data.VillageName = obj.VillageName; Data.IsActive = obj.IsActive;
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
            return ctx.MstVillage.Any(e => e.VillageId == id);
        }

        public async Task DeleteConfirmed(int id)
        {
            using (TransactionScope s = new TransactionScope())
            {
                var MstVillage = ctx.MstVillage.Find(id);
                ctx.MstVillage.Remove(MstVillage);
                ctx.SaveChanges();
                s.Complete();
                s.Dispose();

            }
        }

        public async Task Delete(int? id)
        {
            var MstLap = await ctx.MstVillage
                           .FirstOrDefaultAsync(m => m.VillageId == id);
        }
        public bool DuplicateCheckOnSave(string VillageName)
        {
            return ctx.MstVillage.Any(e => e.VillageName == VillageName);
        }
        public bool DuplicateCheckOnUpdate(string VillageName,int GewogId, int VillageId)
        {
            return ctx.MstVillage.Any(e => e.VillageName == VillageName && e.GewogId == GewogId && e.VillageId != VillageId);
        }
    }
}
