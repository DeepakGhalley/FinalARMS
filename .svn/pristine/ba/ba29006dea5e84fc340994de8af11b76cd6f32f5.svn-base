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
    public class StructureTypeBLL : IStructureType
    {
        readonly tt_dbContext ctx = new tt_dbContext();

        public IList<StructureTypeModel> GetAll()
        {
            var data = (from x in ctx.MstStructureType
                        select new StructureTypeModel
                        {
                            StructureTypeId = x.StructureTypeId,
                            StructureType = x.StructureType,
                            StructureTypeDescription = x.StructureTypeDescription,
                            IsActive = x.IsActive,
                            CreatedBy = x.CreatedBy,
                            CreatedOn = x.CreatedOn,
                            ModifiedOn = x.ModifiedOn,
                            ModifiedBy = x.ModifiedBy
                        });
            return data.ToList();

        }
        public async Task<StructureTypeModel> Details(int? id)
        {
            var data = (from a in ctx.MstStructureType.Where(aa => aa.StructureTypeId == id)
                        select new StructureTypeModel
                        {
                            StructureTypeId = a.StructureTypeId,
                            StructureType = a.StructureType,
                            StructureTypeDescription = a.StructureTypeDescription,
                            IsActive = a.IsActive,
                            CreatedBy = a.CreatedBy,
                            CreatedOn = a.CreatedOn,
                            ModifiedBy = a.ModifiedBy,
                            ModifiedOn = a.ModifiedOn

                        });

            return await data.FirstOrDefaultAsync();

        }
        public int Save(StructureTypeModel obj)
        {
            try
            {
                using TransactionScope s = new TransactionScope();
                int ipk;
                var entity = new MstStructureType
                {
                    StructureTypeId = obj.StructureTypeId,
                    StructureType = obj.StructureType,
                    StructureTypeDescription = obj.StructureTypeDescription,
                    IsActive = obj.IsActive,
                    CreatedBy = obj.CreatedBy,
                    CreatedOn = Convert.ToDateTime(obj.CreatedOn),
                };
                ctx.MstStructureType.Add(entity);
                ctx.SaveChanges();
                s.Complete();
                s.Dispose();
                ipk = entity.StructureTypeId;

                return ipk;
            }
            catch (System.Exception)
            {
                return 0;
            }
        }

        public int Update(StructureTypeModel obj)
        {
            try
            {
                using (TransactionScope s = new TransactionScope())
                {
                    var Data = ctx.MstStructureType.FirstOrDefault(u => u.StructureTypeId == obj.StructureTypeId);
                    Data.StructureType = obj.StructureType; Data.StructureTypeDescription = obj.StructureTypeDescription; Data.IsActive = obj.IsActive;
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
            return ctx.MstStructureType.Any(e => e.StructureTypeId == id);
        }

        public async Task DeleteConfirmed(int id)
        {
            using (TransactionScope s = new TransactionScope())
            {
                var MstStructureType = ctx.MstStructureType.Find(id);
                ctx.MstStructureType.Remove(MstStructureType);
                ctx.SaveChanges();
                s.Complete();
                s.Dispose();

            }
        }

        public async Task Delete(int? id)
        {
            var MstStructureType = await ctx.MstStructureType
                           .FirstOrDefaultAsync(m => m.StructureTypeId == id);
        }
        public bool DuplicateCheckOnSave(string StructureType)
        {
            return ctx.MstStructureType.Any(e => e.StructureType == StructureType);
        }
        public bool DuplicateCheckOnUpdate(string StructureType, int StructureTypeId)
        {
            return ctx.MstStructureType.Any(e => e.StructureType == StructureType && e.StructureTypeId != StructureTypeId);
        }
    }
}

