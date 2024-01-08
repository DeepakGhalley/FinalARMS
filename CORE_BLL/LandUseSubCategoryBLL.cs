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
    public class LandUseSubCategoryBLL : ILandUseSubCategory
    {
        readonly tt_dbContext ctx = new tt_dbContext();

        public bool CheckExists(int id)
        {
            return ctx.MstLandUseSubCategory.Any(e => e.LandUseSubCategoryId == id);
        }

        public Task Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteConfirmed(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<LandUseSubCategoryModel> Details(int? id)
        {
            var data = (from a in ctx.MstLandUseSubCategory.Where(aa => aa.LandUseSubCategoryId == id)
                        select new LandUseSubCategoryModel
                        {
                            LandUseSubCategoryId = a.LandUseSubCategoryId,
                            LandUseCategoryId = a.LandUseCategoryId,
                            LandUseSubCategory = a.LandUseSubCategory,
                            LandUseCategoryDescription = a.LandUseCategoryDescription,
                            IsActive = a.IsActive,
                            CreatedBy = a.CreatedBy,
                            CreatedOn = a.CreatedOn,
                            ModifiedBy = a.ModifiedBy,
                            ModifiedOn = a.ModifiedOn

                        });

            return await data.FirstOrDefaultAsync();
        }

        public bool DuplicateCheckOnSave(string LandUseSubCategory)
        {
            return ctx.MstLandUseSubCategory.Any(e => e.LandUseSubCategory == LandUseSubCategory);
        }

        public bool DuplicateCheckOnUpdate(string LandUseSubCategory, int Id)
        {
            return ctx.MstLandUseSubCategory.Any(e => e.LandUseSubCategory == LandUseSubCategory && e.LandUseSubCategoryId != Id);
        }

        public IList<LandUseSubCategoryModel> GetAll()
        {
            var data = (from x in ctx.MstLandUseSubCategory
                        join y in ctx.MstLandUseCategory on x.LandUseCategoryId equals y.LandUseCategoryId
                        select new LandUseSubCategoryModel
                        {
                            LandUseSubCategoryId = x.LandUseSubCategoryId,
                            LandUseCategoryId = x.LandUseCategoryId,
                            LandUseCategoryName = y.LandUseCategory,
                            LandUseSubCategory = x.LandUseSubCategory,
                            LandUseCategoryDescription = x.LandUseCategoryDescription,
                            IsActive = x.IsActive,
                            CreatedBy = x.CreatedBy,
                            CreatedOn = x.CreatedOn,
                            ModifiedBy = x.ModifiedBy,
                            ModifiedOn = x.ModifiedOn
                        });
            return data.ToList();
        }

        public int Save(LandUseSubCategoryModel obj)
        {
            try
            {
                using TransactionScope s = new TransactionScope();
                int ipk;
                var entity = new MstLandUseSubCategory
                {
                    LandUseSubCategoryId = obj.LandUseSubCategoryId,
                    LandUseCategoryId = obj.LandUseCategoryId,
                    LandUseSubCategory = obj.LandUseSubCategory,
                    LandUseCategoryDescription = obj.LandUseCategoryDescription,
                    IsActive = obj.IsActive,
                    CreatedBy = obj.CreatedBy,
                    CreatedOn = Convert.ToDateTime(obj.CreatedOn),
                };
                ctx.MstLandUseSubCategory.Add(entity);
                ctx.SaveChanges();
                s.Complete();
                s.Dispose();
                ipk = entity.LandUseSubCategoryId;

                return ipk;
            }
            catch (System.Exception)
            {
                return 0;
            }
        }

        public int Update(LandUseSubCategoryModel obj)
        {
            try
            {
                using (TransactionScope s = new TransactionScope())
                {
                    var Data = ctx.MstLandUseSubCategory.FirstOrDefault(u => u.LandUseSubCategoryId == obj.LandUseSubCategoryId);
                    Data.LandUseCategoryId = obj.LandUseCategoryId;
                    Data.LandUseSubCategory = obj.LandUseSubCategory;
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
    }
}
