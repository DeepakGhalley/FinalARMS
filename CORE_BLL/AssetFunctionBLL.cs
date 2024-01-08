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
    public class AssetFunctionBLL : IAssetFunction
    {
        readonly tt_dbContext ctx = new tt_dbContext();

        public bool CheckExists(int id)
        {
            return ctx.MstAssetFunction.Any(e => e.AssetFunctionId == id);
        }

        public async Task Delete(int? id)
        {
            var mstAssetFunction = await ctx.MstAssetFunction
            .FirstOrDefaultAsync(m => m.AssetFunctionId == id);
        }

        public async Task DeleteConfirmed(int id)
        {
            using (TransactionScope s = new TransactionScope())
            {
                var mstAssetFunction = ctx.MstAssetFunction.Find(id);
                ctx.MstAssetFunction.Remove(mstAssetFunction);
                ctx.SaveChanges();
                s.Complete();
                s.Dispose();

            }
        }

        public async Task<AssetFunctionModel> Details(int? id)
        {
            var data = (from a in ctx.MstAssetFunction.Where(aa => aa.AssetFunctionId == id)
                        select new AssetFunctionModel
                        {
                            AssetFunctionId = a.AssetFunctionId,
                            AssetFunctionName = a.AssetFunctionName,
                            IsActive = a.IsActive,
                            CreatedBy = a.CreatedBy,
                            CreatedOn = a.CreatedOn,
                            ModifiedBy = a.ModifiedBy,
                            ModifiedOn = a.ModifiedOn,
                            AssetFunctionCode = a.FunctionCode
                            

                        });

            return await data.FirstOrDefaultAsync();
        }

        public bool DuplicateCheckOnSave(string FunctionName)
        {
            return ctx.MstAssetFunction.Any(e => e.AssetFunctionName == FunctionName);
        }

        public bool DuplicateCheckOnUpdate(string FunctionName, int Id)
        {
            return ctx.MstAssetFunction.Any(e => e.AssetFunctionName == FunctionName && e.AssetFunctionId != Id);
        }

        public IList<AssetFunctionModel> GetAll()
        {
            var data = (from x in ctx.MstAssetFunction
                        select new AssetFunctionModel
                        {
                            AssetFunctionId = x.AssetFunctionId,
                            AssetFunctionName = x.AssetFunctionName,
                            IsActive = x.IsActive,
                            CreatedBy = x.CreatedBy,
                            CreatedOn = x.CreatedOn,
                            ModifiedOn = x.ModifiedOn,
                            ModifiedBy = x.ModifiedBy,
                            AssetFunctionCode = x.FunctionCode
                        });
            return data.ToList();
        }

        public int SaveAssetFunction(AssetFunctionModel obj)
        {
            try
            {
                using (TransactionScope s = new TransactionScope())
                {
                    int ipk;
                    var entity = new MstAssetFunction
                    {
                        AssetFunctionId = obj.AssetFunctionId,
                        AssetFunctionName = obj.AssetFunctionName,
                        IsActive = obj.IsActive,
                        CreatedBy = obj.CreatedBy,
                        CreatedOn = Convert.ToDateTime(obj.CreatedOn),
                        FunctionCode = obj.AssetFunctionCode
                    };
                    ctx.MstAssetFunction.Add(entity);
                    ctx.SaveChanges();
                    s.Complete();
                    s.Dispose();
                    ipk = entity.AssetFunctionId;

                    return ipk;
                }
            }
            catch (System.Exception)
            {
                return 0;
            }
        }

        public int UpdateAssetFunction(AssetFunctionModel obj)
        {
            try
            {
                using (TransactionScope s = new TransactionScope())
                {
                    var Data = ctx.MstAssetFunction.FirstOrDefault(u => u.AssetFunctionId == obj.AssetFunctionId);
                    Data.AssetFunctionName = obj.AssetFunctionName; Data.IsActive = obj.IsActive;
                    Data.ModifiedBy = obj.ModifiedBy; Data.ModifiedOn = obj.ModifiedOn; Data.FunctionCode = obj.AssetFunctionCode;
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
