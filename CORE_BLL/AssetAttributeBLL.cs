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

    public class AssetAttributeBLL : IAssetAttribute
    {
    readonly tt_dbContext ctx = new tt_dbContext();
        public bool CheckExists(int id)
        {
            return ctx.MstAssetAttribute.Any(e => e.AssetAttributeId == id);
        }

        public Task Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteConfirmed(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<AssetAttributeVM> Details(int? id)
        {
            var data = (from a in ctx.MstAssetAttribute.Where(aa => aa.AssetAttributeId == id)
                        select new AssetAttributeVM
                        {
                            AssetAttributeId = a.AssetAttributeId,
                            ParentAttributeId = a.ParentAttributeId,
                            AttributeName = a.AttributeName,
                            AttributeDescription = a.AttributeDescription,
                            ValueRequired = a.ValueRequired,
                            IsActive = a.IsActive,
                            CreatedBy = a.CreatedBy,
                            CreatedOn = a.CreatedOn,
                            ModifiedBy = a.ModifiedBy,
                            ModifiedOn = a.ModifiedOn

                        });

            return await data.FirstOrDefaultAsync();
        }

        public bool DuplicateCheckOnSave(string AttributeName)
        {
            return ctx.MstAssetAttribute.Any(e => e.AttributeName == AttributeName);
        }

        public bool DuplicateCheckOnUpdate(string AttributeName, int ParentAttributeId, int AssetAttributeId)
        {
            return ctx.MstAssetAttribute.Any(e => e.AttributeName == AttributeName && e.ParentAttributeId == ParentAttributeId && e.AssetAttributeId != AssetAttributeId);
        }

        public IList<AssetAttributeVM> GetAll()
        {
            var data = (from x in ctx.MstAssetAttribute
                        join y in ctx.MstParentAttribute on x.ParentAttributeId equals y.ParentAttributeId
                        select new AssetAttributeVM
                        {
                            AssetAttributeId = x.AssetAttributeId,
                            ParentAttributeId = x.ParentAttributeId,
                            ParentAttributeName = y.ParentAttribute,
                            AttributeName = x.AttributeName,
                            AttributeDescription = x.AttributeDescription,
                            ValueRequired = x.ValueRequired,
                            IsActive = x.IsActive,
                            CreatedBy = x.CreatedBy,
                            CreatedOn = x.CreatedOn,
                            ModifiedBy = x.ModifiedBy,
                            ModifiedOn = x.ModifiedOn
                        });
            return data.ToList();
        }

        public int Save(AssetAttributeVM obj)
        {
            try
            {
                using TransactionScope s = new TransactionScope();
                int ipk;
                var entity = new MstAssetAttribute
                {
                    AssetAttributeId = obj.AssetAttributeId,
                    ParentAttributeId = obj.ParentAttributeId,
                    AttributeName = obj.AttributeName,
                    AttributeDescription = obj.AttributeDescription,
                    ValueRequired = obj.ValueRequired,
                    IsActive = obj.IsActive,
                    CreatedBy = obj.CreatedBy,
                    CreatedOn = Convert.ToDateTime(obj.CreatedOn),
                };
                ctx.MstAssetAttribute.Add(entity);
                ctx.SaveChanges();
                s.Complete();
                s.Dispose();
                ipk = entity.AssetAttributeId;

                return ipk;
            }
            catch (System.Exception)
            {
                return 0;
            }
        }

        public int Update(AssetAttributeVM obj)
        {
            try
            {
                using (TransactionScope s = new TransactionScope())
                {
                    var Data = ctx.MstAssetAttribute.FirstOrDefault(u => u.AssetAttributeId == obj.AssetAttributeId);
                    Data.AssetAttributeId = obj.AssetAttributeId;
                    Data.ParentAttributeId = obj.ParentAttributeId;
                    Data.AttributeName = obj.AttributeName;
                    Data.AttributeDescription = obj.AttributeDescription;
                    Data.ValueRequired = obj.ValueRequired;
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
