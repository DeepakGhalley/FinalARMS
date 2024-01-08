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
    public class PavaRateBLL : IPavaRate
    {
        readonly tt_dbContext ctx = new tt_dbContext();
        public bool CheckExists(int id)
        {
            return ctx.MstPavaRate.Any(e => e.PavaRateId == id);
        }

        public async Task Delete(int? id)
        {
            var tblMstPavaRate = await ctx.MstPavaRate
            .FirstOrDefaultAsync(m => m.PavaRateId == id);
        }

        public async Task DeleteConfirmed(int id)
        {
            using (TransactionScope s = new TransactionScope())
            {
                var tblMstPavaRate = ctx.MstPavaRate.Find(id);
                ctx.MstPavaRate.Remove(tblMstPavaRate);
                ctx.SaveChanges();
                s.Complete();
                s.Dispose();

            }
        }

        public async Task<PavaRateModel> Details(int? id)
        {

            var data = (from a in ctx.MstPavaRate.Where(aa => aa.PavaRateId == id)
                        select new PavaRateModel
                        {
                            PavaRateId = a.PavaRateId,
                            LandUseSubCategoryId = a.LandUseSubCategoryId,
                            LandValue = a.LandValue,
                            ApplicableDate = a.ApplicableDate,
                            IsActive = a.IsActive,
                            CreatedBy = a.CreatedBy,
                            CreatedOn = a.CreatedOn,
                            ModifiedBy = a.ModifiedBy,
                            ModifiedOn = a.ModifiedOn

                        });

            return await data.FirstOrDefaultAsync();
        }

        public bool DuplicateCheckOnSave(string PavaRate)
        {
            throw new NotImplementedException();
        }

        public bool DuplicateCheckOnUpdate(string PavaRate, int Id, int LandUseSubCategory)
        {
            throw new NotImplementedException();
        }

        public IList<PavaRateModel> GetAll()
        {
            var data = (from x in ctx.MstPavaRate
                        join y in ctx.MstLandUseSubCategory on x.LandUseSubCategoryId equals y.LandUseSubCategoryId
                        select new PavaRateModel
                        {
                            PavaRateId = x.PavaRateId,
                            LandUseSubCategoryId = x.LandUseSubCategoryId,
                            LandUseSubCategoryName = y.LandUseSubCategory,
                            LandValue = x.LandValue,
                            ApplicableDate = x.ApplicableDate,
                            IsActive = x.IsActive,
                            CreatedBy = x.CreatedBy,
                            CreatedOn = x.CreatedOn,
                            ModifiedOn = x.ModifiedOn,
                            ModifiedBy = x.ModifiedBy,
                        });
            return data.ToList();
        }

        public int Save(PavaRateModel obj)
        {
            try
            {
                using (TransactionScope s = new TransactionScope())
                {
                    int ipk;
                    var entity = new MstPavaRate
                    {
                        PavaRateId = obj.PavaRateId,
                        LandUseSubCategoryId = obj.LandUseSubCategoryId,
                        LandValue = obj.LandValue,
                        ApplicableDate = obj.ApplicableDate,
                        IsActive = obj.IsActive,
                        CreatedBy = obj.CreatedBy,
                        CreatedOn = Convert.ToDateTime(obj.CreatedOn),
                    };
                    ctx.MstPavaRate.Add(entity);
                    ctx.SaveChanges();
                    s.Complete();
                    s.Dispose();
                    ipk = entity.PavaRateId;

                    return ipk;
                }
            }
            catch (System.Exception)
            {
                return 0;
            }
        }

        public int Update(PavaRateModel obj)
        {
            try
            {
                using (TransactionScope s = new TransactionScope())
                {
                    var Data = ctx.MstPavaRate.FirstOrDefault(u => u.PavaRateId == obj.PavaRateId);
                    Data.LandUseSubCategoryId = obj.LandUseSubCategoryId; Data.LandValue = obj.LandValue; Data.ApplicableDate = obj.ApplicableDate; Data.IsActive = obj.IsActive;
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
