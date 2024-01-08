using CORE_BOL;
using CORE_BOL.Entities;
using CORE_DLL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace CORE_BLL
{
    public class LandUseCategoryBLL : ILandUseCategory
    {
        readonly tt_dbContext ctx = new tt_dbContext();

        public bool CheckExists(int id)
        {
            return ctx.MstParentAttribute.Any(e => e.ParentAttributeId == id);
        }

        public Task Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteConfirmed(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<LandUseCategoryModel> Details(int? id)
        {
            var data = (from a in ctx.MstLandUseCategory.Where(aa => aa.LandUseCategoryId == id)
                        select new LandUseCategoryModel
                        {
                            LandUseCategoryId = a.LandUseCategoryId,
                            LandUseCategory = a.LandUseCategory,
                            LandUseCategoryDescription = a.LandUseCategoryDescription,
                            IsActive = a.IsActive,
                            CreatedBy = a.CreatedBy,
                            CreatedOn = a.CreatedOn,
                            ModifiedBy = a.ModifiedBy,
                            ModifiedOn = a.ModifiedOn

                        });

            return await data.FirstOrDefaultAsync();
        }

        public IList<LandUseCategoryModel> GetAll()
        {
            var data = (from x in ctx.MstLandUseCategory
                        select new LandUseCategoryModel
                        {
                            LandUseCategoryId = x.LandUseCategoryId,
                            LandUseCategory = x.LandUseCategory,
                            LandUseCategoryDescription = x.LandUseCategoryDescription,
                            IsActive = x.IsActive,
                            CreatedBy = x.CreatedBy,
                            CreatedOn = x.CreatedOn,
                            ModifiedBy = x.ModifiedBy,
                            ModifiedOn = x.ModifiedOn
                        });
            return data.ToList();
        }

        public int Save(LandUseCategoryModel obj)
        {
            try
            {
                using TransactionScope s = new TransactionScope();
                int ipk;
                var entity = new MstLandUseCategory
                {
                    LandUseCategoryId = obj.LandUseCategoryId,
                    LandUseCategory = obj.LandUseCategory,
                    LandUseCategoryDescription = obj.LandUseCategoryDescription,
                    IsActive = obj.IsActive,
                    CreatedBy = obj.CreatedBy,
                    CreatedOn = Convert.ToDateTime(obj.CreatedOn),
                };
                ctx.MstLandUseCategory.Add(entity);
                ctx.SaveChanges();
                s.Complete();
                s.Dispose();
                ipk = entity.LandUseCategoryId;

                return ipk;
            }
            catch (System.Exception)
            {
                return 0;
            }
        }

        public int Update(LandUseCategoryModel obj)
        {
            try
            {
                using (TransactionScope s = new TransactionScope())
                {
                    var Data = ctx.MstLandUseCategory.FirstOrDefault(u => u.LandUseCategoryId == obj.LandUseCategoryId);
                    Data.LandUseCategory = obj.LandUseCategory;
                    Data.LandUseCategoryDescription = obj.LandUseCategoryDescription;
                    Data.IsActive = obj.IsActive;
                    Data.ModifiedBy = obj.ModifiedBy; 
                    Data.ModifiedOn = obj.ModifiedOn;
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
        public bool DuplicateCheckOnSave(string LandUseCategory)
        {
            return ctx.MstLandUseCategory.Any(e => e.LandUseCategory == LandUseCategory);
        }
        public bool DuplicateCheckOnUpdate(string LandUseCategory, int Id)
        {
            return ctx.MstLandUseCategory.Any(e => e.LandUseCategory == LandUseCategory && e.LandUseCategoryId != Id);
        }
    }
}
