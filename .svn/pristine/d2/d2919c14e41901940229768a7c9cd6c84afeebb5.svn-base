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
    public class RoofingTypeBLL : IRoofingType
    {
        readonly tt_dbContext ctx = new tt_dbContext();

        public IList<RoofingTypemodel> GetAll()
        {
            var data = (from x in ctx.MstRoofingType
                        select new RoofingTypemodel
                        {
                            RoofingTypeId = x.RoofingTypeId,
                            RoofingType = x.RoofingType,
                            RoofingTypeDescription = x.RoofingTypeDescription,
                            IsActive = x.IsActive,
                            CreatedBy = x.CreatedBy,
                            CreatedOn = x.CreatedOn,
                            ModifiedOn = x.ModifiedOn,
                            ModifiedBy = x.ModifiedBy
                        });
            return data.ToList();

        }
        public async Task<RoofingTypemodel> Details(int? id)
        {
            var data = (from a in ctx.MstRoofingType.Where(aa => aa.RoofingTypeId == id)
                        select new RoofingTypemodel
                        {
                            RoofingTypeId = a.RoofingTypeId,
                            RoofingType = a.RoofingType,
                            RoofingTypeDescription = a.RoofingTypeDescription,
                            IsActive = a.IsActive,
                            CreatedBy = a.CreatedBy,
                            CreatedOn = a.CreatedOn,
                            ModifiedBy = a.ModifiedBy,
                            ModifiedOn = a.ModifiedOn

                        });

            return await data.FirstOrDefaultAsync();

        }
        public int Save(RoofingTypemodel obj)
        {
            try
            {
                using TransactionScope s = new TransactionScope();
                int ipk;
                var entity = new MstRoofingType
                {
                    RoofingTypeId = obj.RoofingTypeId,
                    RoofingType = obj.RoofingType,
                    RoofingTypeDescription = obj.RoofingTypeDescription,
                    IsActive = obj.IsActive,
                    CreatedBy = obj.CreatedBy,
                    CreatedOn = Convert.ToDateTime(obj.CreatedOn),
                };
                ctx.MstRoofingType.Add(entity);
                ctx.SaveChanges();
                s.Complete();
                s.Dispose();
                ipk = entity.RoofingTypeId;

                return ipk;
            }
            catch (System.Exception)
            {
                return 0;
            }
        }

        public int Update(RoofingTypemodel obj)
        {
            try
            {
                using (TransactionScope s = new TransactionScope())
                {
                    var Data = ctx.MstRoofingType.FirstOrDefault(u => u.RoofingTypeId == obj.RoofingTypeId);
                    Data.RoofingType = obj.RoofingType; Data.RoofingTypeDescription = obj.RoofingTypeDescription; Data.IsActive = obj.IsActive;
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
            return ctx.MstRoofingType.Any(e => e.RoofingTypeId == id);
        }

        public async Task DeleteConfirmed(int id)
        {
            using (TransactionScope s = new TransactionScope())
            {
                var MstRoofingType = ctx.MstRoofingType.Find(id);
                ctx.MstRoofingType.Remove(MstRoofingType);
                ctx.SaveChanges();
                s.Complete();
                s.Dispose();

            }
        }

        public async Task Delete(int? id)
        {
            var MstRoofingType = await ctx.MstRoofingType
                           .FirstOrDefaultAsync(m => m.RoofingTypeId == id);
        }
        public bool DuplicateCheckOnSave(string RoofingType)
        {
            return ctx.MstRoofingType.Any(e => e.RoofingType == RoofingType);
        }
        public bool DuplicateCheckOnUpdate(string RoofingType, int RoofingTypeId)
        {
            return ctx.MstRoofingType.Any(e => e.RoofingType == RoofingType && e.RoofingTypeId != RoofingTypeId);
        }
    }
}

