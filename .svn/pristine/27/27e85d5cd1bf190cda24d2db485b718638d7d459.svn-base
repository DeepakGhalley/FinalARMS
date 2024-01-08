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
    public class WaterMeterTypesBLL : IwaterMeterType
    {
        readonly tt_dbContext ctx = new tt_dbContext();

        public bool CheckExists(int id)
        {
            return ctx.MstWaterMeterType.Any(e => e.WaterMeterTypeId == id);
        }

        public async Task Delete(int? id)
        {
            var mstWaterMeterType = await ctx.MstWaterMeterType
            .FirstOrDefaultAsync(m => m.WaterMeterTypeId == id);
        }

        public async Task DeleteConfirmed(int id)
        {
            using (TransactionScope s = new TransactionScope())
            {
                var mstWaterMeterType = ctx.MstWaterMeterType.Find(id);
                ctx.MstWaterMeterType.Remove(mstWaterMeterType);
                ctx.SaveChanges();
                s.Complete();
                s.Dispose();
            }
        }

        public async Task<WaterMeterTypesModel> Details(int? id)
        {
            var data = (from a in ctx.MstWaterMeterType.Where(aa => aa.WaterMeterTypeId == id)
                        select new WaterMeterTypesModel
                        {
                            WaterMeterTypeId = a.WaterMeterTypeId,
                            WaterMeterType = a.WaterMeterType,
                            IsActive = a.IsActive,
                            CreatedBy = a.CreatedBy,
                            CreatedOn = a.CreatedOn,
                            ModifiedBy = a.ModifiedBy,
                            ModifiedOn = a.ModifiedOn

                        });

            return await data.FirstOrDefaultAsync();
        }

        public IList<WaterMeterTypesModel> GetAll()
        {
            var data = (from x in ctx.MstWaterMeterType
                        select new WaterMeterTypesModel
                        {

                            WaterMeterTypeId = x.WaterMeterTypeId,
                            WaterMeterType = x.WaterMeterType,
                            IsActive = x.IsActive,
                            CreatedBy = x.CreatedBy,
                            CreatedOn = x.CreatedOn,
                            ModifiedOn = x.ModifiedOn,
                            ModifiedBy = x.ModifiedBy,
                        });
            return data.ToList();

        }

        public int Save(WaterMeterTypesModel obj)
        {
            try
            {
                using (TransactionScope s = new TransactionScope())
                {
                    int ipk;
                    var entity = new MstWaterMeterType
                    {
                        WaterMeterTypeId = obj.WaterMeterTypeId,
                        WaterMeterType = obj.WaterMeterType,
                         IsActive = obj.IsActive,
                        CreatedBy = obj.CreatedBy,
                        CreatedOn = Convert.ToDateTime(obj.CreatedOn),
                    };
                    ctx.MstWaterMeterType.Add(entity);
                    ctx.SaveChanges();
                    s.Complete();
                    s.Dispose();
                    ipk = entity.WaterMeterTypeId;

                    return ipk;
                }
            }
            catch (System.Exception)
            {
                return 0;
            }
        }

        public int Update(WaterMeterTypesModel obj)
        {
            try
            {
                using (TransactionScope s = new TransactionScope())
                {
                    var Data = ctx.MstWaterMeterType.FirstOrDefault(u => u.WaterMeterTypeId == obj.WaterMeterTypeId);
                    Data.WaterMeterType = obj.WaterMeterType; Data.IsActive = obj.IsActive;
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
        public bool DuplicateCheckOnSave(string WaterMeterType)
        {
            return ctx.MstWaterMeterType.Any(e => e.WaterMeterType == WaterMeterType);
        }
        public bool DuplicateCheckOnUpdate(string WaterMeterType, int WaterMeterTypeId)
        {
            return ctx.MstWaterMeterType.Any(e => e.WaterMeterType == WaterMeterType && e.WaterMeterTypeId != WaterMeterTypeId);
        }

    }
}
