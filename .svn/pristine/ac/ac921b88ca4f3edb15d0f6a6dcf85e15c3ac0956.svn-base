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
    public class DepreciationTypeBLL : IDepreciationType
    {
        readonly tt_dbContext ctx = new tt_dbContext();
        public bool CheckExists(int id)
        {
            return ctx.MstDepreciationType.Any(e => e.DepreciationTypeId == id);
        }

        public async Task Delete(int? id)
        {
            var tblMstDepreciationType = await ctx.MstDepreciationType
           .FirstOrDefaultAsync(m => m.DepreciationTypeId == id);
        }

        public async Task DeleteConfirmed(int id)
        {
            using (TransactionScope s = new TransactionScope())
            {
                var tblMstDepreciationType = ctx.MstDepreciationType.Find(id);
                ctx.MstDepreciationType.Remove(tblMstDepreciationType);
                ctx.SaveChanges();
                s.Complete();
                s.Dispose();

            }
        }

        public async Task<DepreciationTypeModel> Details(int? id)
        {
            var data = (from a in ctx.MstDepreciationType.Where(aa => aa.DepreciationTypeId == id)
                        select new DepreciationTypeModel
                        {
                            DepreciationTypeId = a.DepreciationTypeId,
                            DepreciationType = a.DepreciationType,
                            DepreciationTypeDescription = a.DepreciationTypeDescription,
                            IsActive = a.IsActive,
                            CreatedBy = a.CreatedBy,
                            CreatedOn = a.CreatedOn,
                            ModifiedBy = a.ModifiedBy,
                            ModifiedOn = a.ModifiedOn

                        });

            return await data.FirstOrDefaultAsync();
        }

        public bool DuplicateCheckOnSave(string type)
        {
            return ctx.MstDepreciationType.Any(e => e.DepreciationType == type);
        }

        public bool DuplicateCheckOnUpdate(string type, int Id)
        {
            return ctx.MstDepreciationType.Any(e => e.DepreciationType == type && e.DepreciationTypeId != Id);
        }

        public IList<DepreciationTypeModel> GetAll()
        {
            var data = (from x in ctx.MstDepreciationType
                        select new DepreciationTypeModel
                        {
                            DepreciationTypeId = x.DepreciationTypeId,
                            DepreciationType = x.DepreciationType,
                            DepreciationTypeDescription = x.DepreciationTypeDescription,
                            IsActive = x.IsActive,
                            CreatedBy = x.CreatedBy,
                            CreatedOn = x.CreatedOn,
                            ModifiedOn = x.ModifiedOn,
                            ModifiedBy = x.ModifiedBy,
                        });
            return data.ToList();
        }

        public int Save(DepreciationTypeModel obj)
        {
            try
            {
                using (TransactionScope s = new TransactionScope())
                {
                    int ipk;
                    var entity = new MstDepreciationType
                    {
                        DepreciationTypeId = obj.DepreciationTypeId,
                        DepreciationType = obj.DepreciationType,
                        DepreciationTypeDescription = obj.DepreciationTypeDescription,
                        IsActive = obj.IsActive,
                        CreatedBy = obj.CreatedBy,
                        CreatedOn = Convert.ToDateTime(obj.CreatedOn),
                    };
                    ctx.MstDepreciationType.Add(entity);
                    ctx.SaveChanges();
                    s.Complete();
                    s.Dispose();
                    ipk = entity.DepreciationTypeId;

                    return ipk;
                }
            }
            catch (System.Exception)
            {
                return 0;
            }
        }

        public int Update(DepreciationTypeModel obj)
        {
            try
            {
                using (TransactionScope s = new TransactionScope())
                {
                    var Data = ctx.MstDepreciationType.FirstOrDefault(u => u.DepreciationTypeId == obj.DepreciationTypeId);
                    Data.DepreciationType = obj.DepreciationType; Data.DepreciationTypeDescription = obj.DepreciationTypeDescription; Data.IsActive = obj.IsActive;
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
