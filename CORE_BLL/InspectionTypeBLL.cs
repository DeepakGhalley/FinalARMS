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
    public class InspectionTypeBLL : IInspectionType
    {
        readonly tt_dbContext ctx = new tt_dbContext();

        public IList<InspectionTypeMode> GetAll()
        {
            var data = (from x in ctx.MstInspectionType
                        select new InspectionTypeMode
                        {
                            InspectionTypeId = x.InspectionTypeId,
                            InspectionType = x.InspectionType,
                            InspectionTypeDescription = x.InspectionTypeDescription,
                            IsActive = x.IsActive,
                            CreatedBy = x.CreatedBy,
                            CreatedOn = x.CreatedOn,
                            ModifiedOn = x.ModifiedOn,
                            ModifiedBy = x.ModifiedBy
                        });
            return data.ToList();

        }
        public async Task<InspectionTypeMode> Details(int? id)
        {
            var data = (from a in ctx.MstInspectionType.Where(aa => aa.InspectionTypeId == id)
                        select new InspectionTypeMode
                        {
                            InspectionTypeId = a.InspectionTypeId,
                            InspectionType = a.InspectionType,
                            InspectionTypeDescription = a.InspectionTypeDescription,
                            IsActive = a.IsActive,
                            CreatedBy = a.CreatedBy,
                            CreatedOn = a.CreatedOn,
                            ModifiedBy = a.ModifiedBy,
                            ModifiedOn = a.ModifiedOn

                        });

            return await data.FirstOrDefaultAsync();

        }
        public int Save(InspectionTypeMode obj)
        {
            try
            {
                using TransactionScope s = new TransactionScope();
                int ipk;
                var entity = new MstInspectionType
                {
                    InspectionTypeId = obj.InspectionTypeId,
                    InspectionType = obj.InspectionType,
                    InspectionTypeDescription = obj.InspectionTypeDescription,
                    IsActive = obj.IsActive,
                    CreatedBy = obj.CreatedBy,
                    CreatedOn = Convert.ToDateTime(obj.CreatedOn),
                };
                ctx.MstInspectionType.Add(entity);
                ctx.SaveChanges();
                s.Complete();
                s.Dispose();
                ipk = entity.InspectionTypeId;

                return ipk;
            }
            catch (System.Exception)
            {
                return 0;
            }
        }

        public int Update(InspectionTypeMode obj)
        {
            try
            {
                using (TransactionScope s = new TransactionScope())
                {
                    var Data = ctx.MstInspectionType.FirstOrDefault(u => u.InspectionTypeId == obj.InspectionTypeId);
                    Data.InspectionType = obj.InspectionType; Data.InspectionTypeDescription = obj.InspectionTypeDescription; Data.IsActive = obj.IsActive;
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
            return ctx.MstInspectionType.Any(e => e.InspectionTypeId == id);
        }

        public async Task DeleteConfirmed(int id)
        {
            using (TransactionScope s = new TransactionScope())
            {
                var MstInspectionType = ctx.MstInspectionType.Find(id);
                ctx.MstInspectionType.Remove(MstInspectionType);
                ctx.SaveChanges();
                s.Complete();
                s.Dispose();

            }
        }

        public async Task Delete(int? id)
        {
            var MstInspectionType = await ctx.MstInspectionType
                           .FirstOrDefaultAsync(m => m.InspectionTypeId == id);
        }
        public bool DuplicateCheckOnSave(string InspectionType)
        {
            return ctx.MstInspectionType.Any(e => e.InspectionType == InspectionType);
        }
        public bool DuplicateCheckOnUpdate(string InspectionType, int InspectionTypeId)
        {
            return ctx.MstInspectionType.Any(e => e.InspectionType == InspectionType && e.InspectionTypeId != InspectionTypeId);
        }
    }
}

