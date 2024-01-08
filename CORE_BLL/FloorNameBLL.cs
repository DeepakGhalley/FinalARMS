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
    public class FloorNameBLL : IFloorName
    {
        readonly tt_dbContext ctx = new tt_dbContext();

        public bool CheckExists(int id)
        {
            return ctx.MstFloorName.Any(e => e.FloorNameId == id);
        }

        public async Task Delete(int? id)
        {
            var MstFloorName = await ctx.MstFloorName
                                       .FirstOrDefaultAsync(m => m.FloorNameId == id);
        }

        public async Task DeleteConfirmed(int id)
        {
            using (TransactionScope s = new TransactionScope())
            {
                var MstFloorName = ctx.MstFloorName.Find(id);
                ctx.MstFloorName.Remove(MstFloorName);
                ctx.SaveChanges();
                s.Complete();
                s.Dispose();

            }
        }

        public async Task<FloorNameModel> Details(int? id)
        {
            var data = (from a in ctx.MstFloorName.Where(aa => aa.FloorNameId == id)
                        select new FloorNameModel
                        {
                            FloorNameId = a.FloorNameId,
                            FloorName = a.FloorName,
                            FloorNameDescription = a.FloorNameDescription,
                            IsActive = a.IsActive,
                            CreatedBy = a.CreatedBy,
                            CreatedOn = a.CreatedOn,
                            ModifiedBy = a.ModifiedBy,
                            ModifiedOn = a.ModifiedOn

                        });

            return await data.FirstOrDefaultAsync();
        }

        public bool DuplicateCheckOnSave(string FloorName)
        {
            return ctx.MstFloorName.Any(e => e.FloorName == FloorName);
        }

        public bool DuplicateCheckOnUpdate(string FloorName, int FloorNameId)
        {
            return ctx.MstFloorName.Any(e => e.FloorName == FloorName && e.FloorNameId != FloorNameId);
        }

        public IList<FloorNameModel> GetAll()
        {
            var data = (from x in ctx.MstFloorName
                        select new FloorNameModel
                        {
                            FloorNameId = x.FloorNameId,
                            FloorName = x.FloorName,
                            FloorNameDescription = x.FloorNameDescription,
                            IsActive = x.IsActive,
                            CreatedBy = x.CreatedBy,
                            CreatedOn = x.CreatedOn,
                            ModifiedOn = x.ModifiedOn,
                            ModifiedBy = x.ModifiedBy
                        });
            return data.ToList();
        }

        public int SaveFloorName(FloorNameModel obj)
        {
            try
            {
                using TransactionScope s = new TransactionScope();
                int ipk;
                var entity = new MstFloorName
                {
                    FloorNameId = obj.FloorNameId,
                    FloorName = obj.FloorName,
                    FloorNameDescription = obj.FloorNameDescription,
                    IsActive = obj.IsActive,
                    CreatedBy = obj.CreatedBy,
                    CreatedOn = Convert.ToDateTime(obj.CreatedOn),
                };
                ctx.MstFloorName.Add(entity);
                ctx.SaveChanges();
                s.Complete();
                s.Dispose();
                ipk = entity.FloorNameId;

                return ipk;
            }
            catch (System.Exception)
            {
                return 0;
            }
        }

        public int UpdateFloorName(FloorNameModel obj)
        {
            try
            {
                using (TransactionScope s = new TransactionScope())
                {
                    var Data = ctx.MstFloorName.FirstOrDefault(u => u.FloorNameId == obj.FloorNameId);
                    Data.FloorName = obj.FloorName; Data.FloorNameDescription = obj.FloorNameDescription; Data.IsActive = obj.IsActive;
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
