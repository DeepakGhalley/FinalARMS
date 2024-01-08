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
    public class MaintenanceTypeBLL : IMaintenanceType
    {
        readonly tt_dbContext ctx = new tt_dbContext();

        public bool CheckExists(int id)
        {
            return ctx.MstMaintenanceType.Any(e => e.MaintenanceTypeId == id);
        }

        public async Task Delete(int? id)
        {
            var MstMaintenanceType = await ctx.MstMaintenanceType
            .FirstOrDefaultAsync(m => m.MaintenanceTypeId == id);
        }

        public async Task DeleteConfirmed(int id)
        {
            using (TransactionScope s = new TransactionScope())
            {
                var MstMaintenanceType = ctx.MstMaintenanceType.Find(id);
                ctx.MstMaintenanceType.Remove(MstMaintenanceType);
                ctx.SaveChanges();
                s.Complete();
                s.Dispose();
            }
        }

        public async Task<MaintenanceTypeVM> Details(int? id)
        {
            var data = (from a in ctx.MstMaintenanceType.Where(aa => aa.MaintenanceTypeId == id)
                        select new MaintenanceTypeVM
                        {
                            MaintenanceTypeId = a.MaintenanceTypeId,
                            MaintenanceType = a.MaintenanceType,
                            MaintenanceTypeDescription = a.MaintenanceTypeDescription,
                            IsActive = a.IsActive,
                            CreatedBy = a.CreatedBy,
                            CreatedOn = a.CreatedOn,
                            ModifiedBy = a.ModifiedBy,
                            ModifiedOn = a.ModifiedOn

                        });

            return await data.FirstOrDefaultAsync();
        }

        public IList<MaintenanceTypeVM> GetAll()
        {
            var data = (from x in ctx.MstMaintenanceType
                        select new MaintenanceTypeVM
                        {
                            MaintenanceTypeId = x.MaintenanceTypeId,
                            MaintenanceType = x.MaintenanceType,
                            MaintenanceTypeDescription = x.MaintenanceTypeDescription,
                            IsActive = x.IsActive,
                            CreatedBy = x.CreatedBy,
                            CreatedOn = x.CreatedOn,
                            ModifiedOn = x.ModifiedOn,
                            ModifiedBy = x.ModifiedBy
                        });
            return data.ToList();
        }

        public int Save(MaintenanceTypeVM obj)
        {
            try
            {
                using TransactionScope s = new TransactionScope();
                int ipk;
                var entity = new MstMaintenanceType
                {
                    MaintenanceTypeId = obj.MaintenanceTypeId,
                    MaintenanceType = obj.MaintenanceType,
                    MaintenanceTypeDescription = obj.MaintenanceTypeDescription,
                    IsActive = obj.IsActive,
                    CreatedBy = obj.CreatedBy,
                    CreatedOn = Convert.ToDateTime(obj.CreatedOn),
                };
                ctx.MstMaintenanceType.Add(entity);
                ctx.SaveChanges();
                s.Complete();
                s.Dispose();
                ipk = entity.MaintenanceTypeId;

                return ipk;
            }
            catch (System.Exception)
            {
                return 0;
            }
        }

        public int Update(MaintenanceTypeVM obj)
        {
            try
            {
                using (TransactionScope s = new TransactionScope())
                {
                    var Data = ctx.MstMaintenanceType.FirstOrDefault(u => u.MaintenanceTypeId == obj.MaintenanceTypeId);
                    Data.MaintenanceType = obj.MaintenanceType; Data.MaintenanceTypeDescription = obj.MaintenanceTypeDescription; Data.IsActive = obj.IsActive;
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
        public bool DuplicateCheckOnSave(string MaintenanceType)
        {
            return ctx.MstMaintenanceType.Any(e => e.MaintenanceType == MaintenanceType);
        }
        public bool DuplicateCheckOnUpdate(string MaintenanceType, int Id)
        {
            return ctx.MstMaintenanceType.Any(e => e.MaintenanceType == MaintenanceType && e.MaintenanceTypeId != Id);
        }
    }
}
