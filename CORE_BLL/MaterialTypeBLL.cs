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
    public class MaterialTypeBLL : IMaterialType
    {
        readonly tt_dbContext ctx = new tt_dbContext();

        public IList<MaterialTypeModel> GetAll()
        {
            var data = (from x in ctx.MstMaterialType
                        select new MaterialTypeModel
                        {
                            MaterialTypeId = x.MaterialTypeId,
                            MaterialType = x.MaterialType,
                            MaterialTypeDescription = x.MaterialTypeDescription,
                            IsActive = x.IsActive,
                            CreatedBy = x.CreatedBy,
                            CreatedOn = x.CreatedOn,
                            ModifiedOn = x.ModifiedOn,
                            ModifiedBy = x.ModifiedBy
                        });
            return data.ToList();

        }
        public async Task<MaterialTypeModel> Details(int? id)
        {
            var data = (from a in ctx.MstMaterialType.Where(aa => aa.MaterialTypeId == id)
                        select new MaterialTypeModel
                        {
                            MaterialTypeId = a.MaterialTypeId,
                            MaterialType = a.MaterialType,
                            MaterialTypeDescription = a.MaterialTypeDescription,
                            IsActive = a.IsActive,
                            CreatedBy = a.CreatedBy,
                            CreatedOn = a.CreatedOn,
                            ModifiedBy = a.ModifiedBy,
                            ModifiedOn = a.ModifiedOn

                        });

            return await data.FirstOrDefaultAsync();

        }
        public int Save(MaterialTypeModel obj)
        {
            try
            {
                using TransactionScope s = new TransactionScope();
                int ipk;
                var entity = new MstMaterialType
                {
                    MaterialTypeId = obj.MaterialTypeId,
                    MaterialType = obj.MaterialType,
                    MaterialTypeDescription = obj.MaterialTypeDescription,
                    IsActive = obj.IsActive,
                    CreatedBy = obj.CreatedBy,
                    CreatedOn = Convert.ToDateTime(obj.CreatedOn),
                };
                ctx.MstMaterialType.Add(entity);
                ctx.SaveChanges();
                s.Complete();
                s.Dispose();
                ipk = entity.MaterialTypeId;

                return ipk;
            }
            catch (System.Exception)
            {
                return 0;
            }
        }

        public int Update(MaterialTypeModel obj)
        {
            try
            {
                using (TransactionScope s = new TransactionScope())
                {
                    var Data = ctx.MstMaterialType.FirstOrDefault(u => u.MaterialTypeId == obj.MaterialTypeId);
                    Data.MaterialType = obj.MaterialType; Data.MaterialTypeDescription = obj.MaterialTypeDescription; Data.IsActive = obj.IsActive;
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
            return ctx.MstMaterialType.Any(e => e.MaterialTypeId == id);
        }

        public async Task DeleteConfirmed(int id)
        {
            using (TransactionScope s = new TransactionScope())
            {
                var MstMaterialType = ctx.MstMaterialType.Find(id);
                ctx.MstMaterialType.Remove(MstMaterialType);
                ctx.SaveChanges();
                s.Complete();
                s.Dispose();

            }
        }

        public async Task Delete(int? id)
        {
            var MstMaterialType = await ctx.MstMaterialType
                           .FirstOrDefaultAsync(m => m.MaterialTypeId == id);
        }
        public bool DuplicateCheckOnSave(string MaterialType)
        {
            return ctx.MstMaterialType.Any(e => e.MaterialType == MaterialType);
        }
        public bool DuplicateCheckOnUpdate(string MaterialType, int MaterialTypeId)
        {
            return ctx.MstMaterialType.Any(e => e.MaterialType == MaterialType && e.MaterialTypeId != MaterialTypeId);
        }
    }
}

