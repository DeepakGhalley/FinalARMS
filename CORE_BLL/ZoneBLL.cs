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
    public class ZoneBLL : IZone
    {
            readonly tt_dbContext ctx = new tt_dbContext();

        public IList<ZoneModel> GetAll()
        {
            var data = (from x in ctx.MstZone
                        select new ZoneModel
                        {
                            ZoneId = x.ZoneId,
                            ZoneName = x.ZoneName,
                            ZoneCode = x.ZoneCode,
                            ZoneReader = x.ZoneReader,
                            IsActive = x.IsActive,
                            CreatedBy = x.CreatedBy,
                            CreatedOn = x.CreatedOn,
                            ModifiedOn = x.ModifiedOn,
                            ModifiedBy = x.ModifiedBy
                        });
            return data.ToList();

        }
        public async Task<ZoneModel> Details(int? id)
        {
            var data = (from a in ctx.MstZone.Where(aa => aa.ZoneId == id)
                        select new ZoneModel
                        {
                            ZoneId = a.ZoneId,
                            ZoneName = a.ZoneName,
                            ZoneCode = a.ZoneCode, 
                            ZoneReader = a.ZoneReader,
                            IsActive = a.IsActive,
                            CreatedBy = a.CreatedBy,
                            CreatedOn = a.CreatedOn,
                            ModifiedBy = a.ModifiedBy,
                            ModifiedOn = a.ModifiedOn
                          
                          });

            return await data.FirstOrDefaultAsync();

        }
        public int SaveZone(ZoneModel obj)
        {
            try
            {
                using TransactionScope s = new TransactionScope();
                int ipk;
                var entity = new MstZone
                {
                    ZoneId = obj.ZoneId,
                    ZoneName = obj.ZoneName,
                    ZoneCode = obj.ZoneCode,
                    ZoneReader = obj.ZoneReader,
                    IsActive = obj.IsActive,
                    CreatedBy = obj.CreatedBy,
                    CreatedOn = Convert.ToDateTime(obj.CreatedOn),
                };
                ctx.MstZone.Add(entity);
                ctx.SaveChanges();
                s.Complete();
                s.Dispose();
                ipk = entity.ZoneId;

                return ipk;
            }
            catch (System.Exception)
            {
                return 0;
            }
        }

        public int UpdateZone(ZoneModel obj)
        {
            try
            {
                using (TransactionScope s = new TransactionScope())
                {
                    var Data = ctx.MstZone.FirstOrDefault(u => u.ZoneId == obj.ZoneId);
                    Data.ZoneName = obj.ZoneName; Data.ZoneCode = obj.ZoneCode; Data.ZoneReader = obj.ZoneReader; Data.IsActive = obj.IsActive;
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
            return ctx.MstZone.Any(e => e.ZoneId == id);
        }

        public async Task DeleteConfirmed(int id)
        {
            using (TransactionScope s = new TransactionScope())
            {
                var MstZone = ctx.MstZone.Find(id);
                ctx.MstZone.Remove(MstZone);
                ctx.SaveChanges();
                s.Complete();
                s.Dispose();

            }
        }

        public async Task Delete(int? id)
        {
            var MstZone = await ctx.MstZone
                           .FirstOrDefaultAsync(m => m.ZoneId == id);
        }
        public bool DuplicateCheckOnSave(string ZoneName)
        {
            return ctx.MstZone.Any(e => e.ZoneName == ZoneName);
        }
        public bool DuplicateCheckOnUpdate(string ZoneName, int ZoneId)
        {
            return ctx.MstZone.Any(e => e.ZoneName == ZoneName && e.ZoneId != ZoneId);
        }
    }
}
