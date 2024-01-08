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
    public class ConstructionTypeBLL : IConstructionType
    {
        readonly tt_dbContext ctx = new tt_dbContext();

        public IList<ConstructionTypeModel> GetAll()
        {
            var data = (from x in ctx.MstConstructionType
                        select new ConstructionTypeModel
                        {
                            ConstructionTypeId = x.ConstructionTypeId,
                            ConstructionType = x.ConstructionType,
                            ConstructionTypeDescription = x.ConstructionTypeDescription,
                            IsActive = x.IsActive,
                            CreatedBy = x.CreatedBy,
                            CreatedOn = x.CreatedOn,
                            ModifiedOn = x.ModifiedOn,
                            ModifiedBy = x.ModifiedBy
                        });
            return data.ToList();

        }
        public async Task<ConstructionTypeModel> Details(int? id)
        {
            var data = (from a in ctx.MstConstructionType.Where(aa => aa.ConstructionTypeId == id)
                        select new ConstructionTypeModel
                        {
                            ConstructionTypeId = a.ConstructionTypeId,
                            ConstructionType = a.ConstructionType,
                            ConstructionTypeDescription = a.ConstructionTypeDescription,
                            IsActive = a.IsActive,
                            CreatedBy = a.CreatedBy,
                            CreatedOn = a.CreatedOn,
                            ModifiedBy = a.ModifiedBy,
                            ModifiedOn = a.ModifiedOn

                        });

            return await data.FirstOrDefaultAsync();

        }
        public int Save(ConstructionTypeModel obj)
        {
            try
            {
                using TransactionScope s = new TransactionScope();
                int ipk;
                var entity = new MstConstructionType
                {
                    ConstructionTypeId = obj.ConstructionTypeId,
                    ConstructionType = obj.ConstructionType,
                    ConstructionTypeDescription = obj.ConstructionTypeDescription,
                    IsActive = obj.IsActive,
                    CreatedBy = obj.CreatedBy,
                    CreatedOn = Convert.ToDateTime(obj.CreatedOn),
                };
                ctx.MstConstructionType.Add(entity);
                ctx.SaveChanges();
                s.Complete();
                s.Dispose();
                ipk = entity.ConstructionTypeId;

                return ipk;
            }
            catch (System.Exception)
            {
                return 0;
            }
        }

        public int Update(ConstructionTypeModel obj)
        {
            try
            {
                using (TransactionScope s = new TransactionScope())
                {
                    var Data = ctx.MstConstructionType.FirstOrDefault(u => u.ConstructionTypeId == obj.ConstructionTypeId);
                    Data.ConstructionType = obj.ConstructionType; Data.ConstructionTypeDescription = obj.ConstructionType; Data.IsActive = obj.IsActive;
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
            return ctx.MstConstructionType.Any(e => e.ConstructionTypeId == id);
        }

        public async Task DeleteConfirmed(int id)
        {
            using (TransactionScope s = new TransactionScope())
            {
                var MstConstructionType = ctx.MstConstructionType.Find(id);
                ctx.MstConstructionType.Remove(MstConstructionType);
                ctx.SaveChanges();
                s.Complete();
                s.Dispose();

            }
        }

        public async Task Delete(int? id)
        {
            var MstConstructionType = await ctx.MstConstructionType
                           .FirstOrDefaultAsync(m => m.ConstructionTypeId == id);
        }
        public bool DuplicateCheckOnSave(string ConstructionType)
        {
            return ctx.MstConstructionType.Any(e => e.ConstructionType == ConstructionType);
        }
        public bool DuplicateCheckOnUpdate(string ConstructionType, int ConstructionTypeId)
        {
            return ctx.MstConstructionType.Any(e => e.ConstructionType == ConstructionType && e.ConstructionTypeId != ConstructionTypeId);
        }
    }
}

