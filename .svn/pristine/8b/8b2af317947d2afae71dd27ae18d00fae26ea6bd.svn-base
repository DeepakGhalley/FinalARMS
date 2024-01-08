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
    public class AreaBLL : IArea
    {
        readonly tt_dbContext ctx = new tt_dbContext();

        public IList<AreaModel> GetAll()
        {
            var data = (from x in ctx.MstArea
                        select new AreaModel
                        {
                            AreaId = x.AreaId,
                            AreaName = x.AreaName,
                            IsActive = x.IsActive,
                            CreatedBy = x.CreatedBy,
                            CreatedOn = x.CreatedOn,
                            ModifiedOn = x.ModifiedOn,
                            ModifiedBy = x.ModifiedBy,
                            AreaCode = x.AreaCode
                        });
            return data.ToList();

        }
        public async Task<AreaModel> Details(int? id)
        {
            var data = (from a in ctx.MstArea.Where(aa => aa.AreaId == id)
                        select new AreaModel
                        {
                            AreaId = a.AreaId,
                            AreaName = a.AreaName,
                            IsActive = a.IsActive,
                            CreatedBy = a.CreatedBy,
                            CreatedOn = a.CreatedOn,
                            ModifiedBy = a.ModifiedBy,
                            ModifiedOn = a.ModifiedOn,
                            AreaCode = a.AreaCode

                        });

            return await data.FirstOrDefaultAsync();

        }
        public int SaveArea(AreaModel obj)
        {
            try
            {
                using TransactionScope s = new TransactionScope();
                int ipk;
                var entity = new MstArea
                {
                    AreaId = obj.AreaId,
                    AreaName = obj.AreaName,
                    AreaCode = obj.AreaCode,
                    IsActive = obj.IsActive,
                    CreatedBy = obj.CreatedBy,
                    CreatedOn = Convert.ToDateTime(obj.CreatedOn),
                };
                ctx.MstArea.Add(entity);
                ctx.SaveChanges();
                s.Complete();
                s.Dispose();
                ipk = entity.AreaId;

                return ipk;
            }
            catch (System.Exception)
            {
                return 0;
            }
        }

        public int UpdateArea(AreaModel obj)
        {
            try
            {
                using (TransactionScope s = new TransactionScope())
                {
                    var Data = ctx.MstArea.FirstOrDefault(u => u.AreaId == obj.AreaId);
                    Data.AreaName = obj.AreaName; Data.IsActive = obj.IsActive; Data.AreaCode = obj.AreaCode;
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
            return ctx.MstArea.Any(e => e.AreaId == id);
        }

        public async Task DeleteConfirmed(int id)
        {
            using (TransactionScope s = new TransactionScope())
            {
                var MstArea = ctx.MstArea.Find(id);
                ctx.MstArea.Remove(MstArea);
                ctx.SaveChanges();
                s.Complete();
                s.Dispose();

            }
        }

        public async Task Delete(int? id)
        {
            var MstArea = await ctx.MstArea
                           .FirstOrDefaultAsync(m => m.AreaId == id);
        }
        public bool DuplicateCheckOnSave(string AreaName)
        {
            return ctx.MstArea.Any(e => e.AreaName == AreaName);
        }
        public bool DuplicateCheckOnUpdate(string AreaName, int AreaId)
        {
            return ctx.MstArea.Any(e => e.AreaName == AreaName && e.AreaId != AreaId);
        }
    }
}

