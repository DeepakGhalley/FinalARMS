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
    public class StructureCategoryBLL : IStructureCategory
    {
        readonly tt_dbContext ctx = new tt_dbContext();

        public IList<StructureCategoryModel> GetAll()
        {
            var data = (from x in ctx.MstStructureCategory
                        select new StructureCategoryModel
                        {
                            StructureCategoryId = x.StructureCategoryId,
                            StructureCategory = x.StructureCategory,
                            StructureCategoryDescription = x.StructureCategoryDescription,
                            IsActive = x.IsActive,
                            CreatedBy = x.CreatedBy,
                            CreatedOn = x.CreatedOn,
                            ModifiedOn = x.ModifiedOn,
                            ModifiedBy = x.ModifiedBy
                        });
            return data.ToList();

        }
        public async Task<StructureCategoryModel> Details(int? id)
        {
            var data = (from a in ctx.MstStructureCategory.Where(aa => aa.StructureCategoryId == id)
                        select new StructureCategoryModel
                        {
                            StructureCategoryId = a.StructureCategoryId,
                            StructureCategory = a.StructureCategory,
                            StructureCategoryDescription = a.StructureCategoryDescription,
                            IsActive = a.IsActive,
                            CreatedBy = a.CreatedBy,
                            CreatedOn = a.CreatedOn,
                            ModifiedBy = a.ModifiedBy,
                            ModifiedOn = a.ModifiedOn

                        });

            return await data.FirstOrDefaultAsync();

        }
        public int Save(StructureCategoryModel obj)
        {
            try
            {
                using TransactionScope s = new TransactionScope();
                int ipk;
                var entity = new MstStructureCategory
                {
                    StructureCategoryId = obj.StructureCategoryId,
                    StructureCategory = obj.StructureCategory,
                    StructureCategoryDescription = obj.StructureCategoryDescription,
                    IsActive = obj.IsActive,
                    CreatedBy = obj.CreatedBy,
                    CreatedOn = Convert.ToDateTime(obj.CreatedOn),
                };
                ctx.MstStructureCategory.Add(entity);
                ctx.SaveChanges();
                s.Complete();
                s.Dispose();
                ipk = entity.StructureCategoryId;

                return ipk;
            }
            catch (System.Exception)
            {
                return 0;
            }
        }

        public int Update(StructureCategoryModel obj)
        {
            try
            {
                using (TransactionScope s = new TransactionScope())
                {
                    var Data = ctx.MstStructureCategory.FirstOrDefault(u => u.StructureCategoryId == obj.StructureCategoryId);
                    Data.StructureCategory = obj.StructureCategory; Data.StructureCategoryDescription = obj.StructureCategoryDescription; Data.IsActive = obj.IsActive;
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
            return ctx.MstStructureCategory.Any(e => e.StructureCategoryId == id);
        }

        public async Task DeleteConfirmed(int id)
        {
            using (TransactionScope s = new TransactionScope())
            {
                var MstStructureCategory = ctx.MstStructureCategory.Find(id);
                ctx.MstStructureCategory.Remove(MstStructureCategory);
                ctx.SaveChanges();
                s.Complete();
                s.Dispose();

            }
        }

        public async Task Delete(int? id)
        {
            var MstStructureCategory = await ctx.MstStructureCategory
                           .FirstOrDefaultAsync(m => m.StructureCategoryId == id);
        }
        public bool DuplicateCheckOnSave(string StructureType)
        {
            return ctx.MstStructureCategory.Any(e => e.StructureCategory == StructureType);
        }
        public bool DuplicateCheckOnUpdate(string StructureCategory, int StructureCategoryId)
        {
            return ctx.MstStructureCategory.Any(e => e.StructureCategory == StructureCategory && e.StructureCategoryId != StructureCategoryId);
        }
    }
}

