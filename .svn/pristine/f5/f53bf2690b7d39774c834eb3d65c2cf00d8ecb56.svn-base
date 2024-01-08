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
    public class ActivityTypeBLL : IActivityType
    {
        readonly tt_dbContext ctx = new tt_dbContext();

        public IList<ActivityTypeModel> GetAll()
        {
            var data = (from x in ctx.MstEcactivityType
                        select new ActivityTypeModel
                        {
                            ActivityTypeId = x.EcActivityTypeId,
                            ActivityType = x.ActivityType,
                            ActivityDescription = x.ActivityDescription,
                            IsActive = x.IsActive,
                            CreatedBy = x.CreatedBy,
                            CreatedOn = x.CreatedOn,
                            ModifiedOn = x.ModifiedOn,
                            ModifiedBy = x.ModifiedBy
                        });
            return data.ToList();

        }
        public async Task<ActivityTypeModel> Details(int? id)
        {
            var data = (from a in ctx.MstEcactivityType.Where(aa => aa.EcActivityTypeId == id)
                        select new ActivityTypeModel
                        {
                            ActivityTypeId = a.EcActivityTypeId,
                            ActivityType = a.ActivityType,
                            ActivityDescription = a.ActivityDescription,
                            IsActive = a.IsActive,
                            CreatedBy = a.CreatedBy,
                            CreatedOn = a.CreatedOn,
                            ModifiedBy = a.ModifiedBy,
                            ModifiedOn = a.ModifiedOn

                        });

            return await data.FirstOrDefaultAsync();

        }
        public int SaveActivityType(ActivityTypeModel obj)
        {
            try
            {
                using TransactionScope s = new TransactionScope();
                int ipk;
                var entity = new MstEcactivityType
                {
                    EcActivityTypeId = obj.ActivityTypeId,
                    ActivityType = obj.ActivityType,
                    ActivityDescription = obj.ActivityDescription,
                    IsActive = obj.IsActive,
                    CreatedBy = obj.CreatedBy,
                    CreatedOn = Convert.ToDateTime(obj.CreatedOn),
                };
                ctx.MstEcactivityType.Add(entity);
                ctx.SaveChanges();
                s.Complete();
                s.Dispose();
                ipk = entity.EcActivityTypeId;

                return ipk;
            }
            catch (System.Exception)
            {
                return 0;
            }
        }

        public int UpdateActivityType(ActivityTypeModel obj)
        {
            try
            {
                using (TransactionScope s = new TransactionScope())
                {
                    var Data = ctx.MstEcactivityType.FirstOrDefault(u => u.EcActivityTypeId == obj.ActivityTypeId);
                    Data.ActivityType = obj.ActivityType; Data.ActivityDescription = obj.ActivityDescription; Data.IsActive = obj.IsActive;
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
            return ctx.MstEcactivityType.Any(e => e.EcActivityTypeId == id);
        }

        public async Task DeleteConfirmed(int id)
        {
            using (TransactionScope s = new TransactionScope())
            {
                var MstECActivityType = ctx.MstEcactivityType.Find(id);
                ctx.MstEcactivityType.Remove(MstECActivityType);
                ctx.SaveChanges();
                s.Complete();
                s.Dispose();

            }
        }

        public async Task Delete(int? id)
        {
            var MstECActivityType = await ctx.MstEcactivityType
                           .FirstOrDefaultAsync(m => m.EcActivityTypeId == id);
        }
        public bool DuplicateCheckOnSave(string ActivityType)
        {
            return ctx.MstEcactivityType.Any(e => e.ActivityType == ActivityType);
        }
        public bool DuplicateCheckOnUpdate(string ActivityType, int ActivityTypeId)
        {
            return ctx.MstEcactivityType.Any(e => e.ActivityType == ActivityType && e.EcActivityTypeId != ActivityTypeId);
        }
    }
}

