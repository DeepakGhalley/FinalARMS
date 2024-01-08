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
    public class BoundaryTypeBLL : IBoundaryType
    {
        readonly tt_dbContext ctx = new tt_dbContext();

        public IList<BoundaryTypeModel> GetAll()
        {
            var data = (from x in ctx.MstBoundaryType
                        select new BoundaryTypeModel
                        {
                            BoundaryTypeId = x.BoundaryTypeId,
                            BoundaryType = x.BoundaryType,
                            BoundaryTypeDescription = x.BoundaryTypeDescription,
                            IsActive = x.IsActive,
                            CreatedBy = x.CreatedBy,
                            CreatedOn = x.CreatedOn,
                            ModifiedOn = x.ModifiedOn,
                            ModifiedBy = x.ModifiedBy
                        });
            return data.ToList();

        }
        public async Task<BoundaryTypeModel> Details(int? id)
        {
            var data = (from a in ctx.MstBoundaryType.Where(aa => aa.BoundaryTypeId == id)
                        select new BoundaryTypeModel
                        {
                            BoundaryTypeId = a.BoundaryTypeId,
                            BoundaryType = a.BoundaryType,
                            BoundaryTypeDescription = a.BoundaryTypeDescription,
                            IsActive = a.IsActive,
                            CreatedBy = a.CreatedBy,
                            CreatedOn = a.CreatedOn,
                            ModifiedBy = a.ModifiedBy,
                            ModifiedOn = a.ModifiedOn

                        });

            return await data.FirstOrDefaultAsync();

        }
        public int Save(BoundaryTypeModel obj)
        {
            try
            {
                using TransactionScope s = new TransactionScope();
                int ipk;
                var entity = new MstBoundaryType
                {
                    BoundaryTypeId = obj.BoundaryTypeId,
                    BoundaryType = obj.BoundaryType,
                    BoundaryTypeDescription = obj.BoundaryTypeDescription,
                    IsActive = obj.IsActive,
                    CreatedBy = obj.CreatedBy,
                    CreatedOn = Convert.ToDateTime(obj.CreatedOn),
                };
                ctx.MstBoundaryType.Add(entity);
                ctx.SaveChanges();
                s.Complete();
                s.Dispose();
                ipk = entity.BoundaryTypeId;

                return ipk;
            }
            catch (System.Exception)
            {
                return 0;
            }
        }

        public int Update(BoundaryTypeModel obj)
        {
            try
            {
                using (TransactionScope s = new TransactionScope())
                {
                    var Data = ctx.MstBoundaryType.FirstOrDefault(u => u.BoundaryTypeId == obj.BoundaryTypeId);
                    Data.BoundaryType = obj.BoundaryType; Data.BoundaryTypeDescription = obj.BoundaryTypeDescription; Data.IsActive = obj.IsActive;
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
            return ctx.MstBoundaryType.Any(e => e.BoundaryTypeId == id);
        }

        public async Task DeleteConfirmed(int id)
        {
            using (TransactionScope s = new TransactionScope())
            {
                var MstBoundaryType = ctx.MstBoundaryType.Find(id);
                ctx.MstBoundaryType.Remove(MstBoundaryType);
                ctx.SaveChanges();
                s.Complete();
                s.Dispose();

            }
        }

        public async Task Delete(int? id)
        {
            var MstBoundaryType = await ctx.MstBoundaryType
                           .FirstOrDefaultAsync(m => m.BoundaryTypeId == id);
        }
        public bool DuplicateCheckOnSave(string BoundaryType)
        {
            return ctx.MstBoundaryType.Any(e => e.BoundaryType == BoundaryType);
        }
        public bool DuplicateCheckOnUpdate(string BoundaryType, int BoundaryTypeId)
        {
            return ctx.MstBoundaryType.Any(e => e.BoundaryType == BoundaryType && e.BoundaryTypeId != BoundaryTypeId);
        }
    }
}

