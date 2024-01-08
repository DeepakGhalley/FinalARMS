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
    public class AttributeUnitMapBLL : IAttributeUnitMap
    {
        readonly tt_dbContext ctx = new tt_dbContext();
        public bool CheckExists(int id)
        {
            return ctx.MstAttributeUnitMap.Any(e => e.AttributeUnitMapId == id); ;
        }

        public async Task Delete(int? id)
        {
            var MstAttributeUnitMap = await ctx.MstAttributeUnitMap
            .FirstOrDefaultAsync(m => m.AttributeUnitMapId == id);
        }

        public async Task DeleteConfirmed(int id)
        {
            using (TransactionScope s = new TransactionScope())
            {
                var MstAttributeUnitMap = ctx.MstAttributeUnitMap.Find(id);
                ctx.MstAttributeUnitMap.Remove(MstAttributeUnitMap);
                ctx.SaveChanges();
                s.Complete();
                s.Dispose();
            }
        }

        public async Task<AttributeUnitMapModel> Details(int? id)
        {
            var data = (from a in ctx.MstAttributeUnitMap.Where(aa => aa.AttributeUnitMapId == id)
                        select new AttributeUnitMapModel
                        {
                            AttributeUnitMapId = a.AttributeUnitMapId,
                            AttributeUnitMapName = a.AttributeUnitMapName,
                            AttributeUnitMapDescription = a.AttributeUnitMapDescription,
                            AssetAttributeId = a.AssetAttributeId,
                            IsActive = a.IsActive,
                            CreatedBy = a.CreatedBy,
                            CreatedOn = a.CreatedOn,
                            ModifiedBy = a.ModifiedBy,
                            ModifiedOn = a.ModifiedOn,
                            MeasurementUnitId = a.MeasurementUnitId

                        });

            return await data.FirstOrDefaultAsync();
        }

        public bool DuplicateCheckOnSave(string AttributeName)
        {
            return ctx.MstAttributeUnitMap.Any(e => e.AttributeUnitMapName == AttributeName);
        }

        public bool DuplicateCheckOnUpdate(string AttributeName, int Id, int AssetAttributeId, int MeasurementUnitId)
        {
            return ctx.MstAttributeUnitMap.Any(e => e.AttributeUnitMapName == AttributeName && e.AttributeUnitMapId != Id && e.AssetAttributeId == AssetAttributeId && e.MeasurementUnitId == MeasurementUnitId);
        }

        public IList<AttributeUnitMapModel> GetAll()
        {
            var data = (from x in ctx.MstAttributeUnitMap
                        join y in ctx.MstAssetAttribute on x.AssetAttributeId equals y.AssetAttributeId
                        join z in ctx.MstMeasurementUnit on x.MeasurementUnitId equals z.MeasurementUnitId
                        select new AttributeUnitMapModel
                        {
                            AttributeUnitMapId = x.AttributeUnitMapId,
                            AttributeUnitMapName = x.AttributeUnitMapName,
                            AttributeUnitMapDescription = x.AttributeUnitMapDescription,
                            AssetAttributeId = x.AssetAttributeId,
                            MeasurementUnitId = x.MeasurementUnitId,
                            MeasurementUnitName = z.MeasurementUnit,
                            IsActive = x.IsActive,
                            CreatedBy = x.CreatedBy,
                            CreatedOn = x.CreatedOn,
                            ModifiedOn = x.ModifiedOn,
                            ModifiedBy = x.ModifiedBy,
                        });
            return data.ToList();
        }

        public int Save(AttributeUnitMapModel obj)
        {
            try
            {
                using TransactionScope s = new TransactionScope();
                int ipk;
                var entity = new MstAttributeUnitMap
                {
                    AttributeUnitMapId = obj.AttributeUnitMapId,
                    AttributeUnitMapName = obj.AttributeUnitMapName,
                    AttributeUnitMapDescription = obj.AttributeUnitMapDescription,
                    AssetAttributeId = obj.AssetAttributeId,
                    MeasurementUnitId = obj.MeasurementUnitId,
                    IsActive = obj.IsActive,
                    CreatedBy = obj.CreatedBy,
                    CreatedOn = Convert.ToDateTime(obj.CreatedOn),
                };
                ctx.MstAttributeUnitMap.Add(entity);
                ctx.SaveChanges();
                s.Complete();
                s.Dispose();
                ipk = entity.AttributeUnitMapId;

                return ipk;
            }
            catch (System.Exception)
            {
                return 0;
            }
        }

        public int Update(AttributeUnitMapModel obj)
        {
            try
            {
                using (TransactionScope s = new TransactionScope())
                {
                    var Data = ctx.MstAttributeUnitMap.FirstOrDefault(u => u.AttributeUnitMapId == obj.AttributeUnitMapId);
                    Data.AttributeUnitMapName = obj.AttributeUnitMapName; Data.AttributeUnitMapDescription = obj.AttributeUnitMapDescription;
                    Data.IsActive = obj.IsActive; Data.AssetAttributeId = obj.AssetAttributeId;
                    Data.MeasurementUnitId = obj.MeasurementUnitId;
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
