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
    public class DemkhongBLL : IDemkhong
    {
        readonly tt_dbContext ctx = new tt_dbContext();

        public IList<DemkhongModel> GetAll()
        {
            var data = (from x in ctx.MstDemkhong
                        select new DemkhongModel
                        {
                            DemkhongId = x.DemkhongId,
                            DemkhongName = x.DemkhongName,
                            IsActive = x.IsActive,
                            CreatedBy = x.CreatedBy,
                            CreatedOn = x.CreatedOn,
                            ModifiedOn = x.ModifiedOn,
                            ModifiedBy = x.ModifiedBy
                        });
            return data.ToList();

        }

        public async Task<DemkhongModel> Details(int? id)
        {
            var data = (from a in ctx.MstDemkhong.Where(aa => aa.DemkhongId == id)
                        select new DemkhongModel
                        {
                            DemkhongId = a.DemkhongId,
                            DemkhongName = a.DemkhongName,
                            IsActive = a.IsActive,
                            CreatedBy = a.CreatedBy,
                            CreatedOn = a.CreatedOn,
                            ModifiedBy = a.ModifiedBy,
                            ModifiedOn = a.ModifiedOn

                        });

            return await data.FirstOrDefaultAsync();

        }

        public int SaveDemkhong(DemkhongModel obj)
        {
            try
            {
                using TransactionScope s = new TransactionScope();
                int ipk;
                var entity = new MstDemkhong
                {
                    DemkhongId = obj.DemkhongId,
                    DemkhongName = obj.DemkhongName,
                    IsActive = obj.IsActive,
                    CreatedBy = obj.CreatedBy,
                    CreatedOn = Convert.ToDateTime(obj.CreatedOn),
                };
                ctx.MstDemkhong.Add(entity);
                ctx.SaveChanges();
                s.Complete();
                s.Dispose();
                ipk = entity.DemkhongId;

                return ipk;
            }
            catch (System.Exception)
            {
                return 0;
            }
        }

        public int UpdateDemkhong(DemkhongModel obj)
        {
            try
            {
                using (TransactionScope s = new TransactionScope())
                {
                    var Data = ctx.MstDemkhong.FirstOrDefault(u => u.DemkhongId == obj.DemkhongId);
                    Data.DemkhongName = obj.DemkhongName; Data.IsActive = obj.IsActive;
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
            return ctx.MstDemkhong.Any(e => e.DemkhongId == id);
        }

        public async Task DeleteConfirmed(int id)
        {
            using (TransactionScope s = new TransactionScope())
            {
                var MstDemkhong = ctx.MstDemkhong.Find(id);
                ctx.MstDemkhong.Remove(MstDemkhong);
                ctx.SaveChanges();
                s.Complete();
                s.Dispose();

            }
        }

        public async Task Delete(int? id)
        {
            var MstDemkhong = await ctx.MstDemkhong
                           .FirstOrDefaultAsync(m => m.DemkhongId == id);
        }
        public bool DuplicateCheckOnSave(string DemkhongName)
        {
            return ctx.MstDemkhong.Any(e => e.DemkhongName == DemkhongName);
        }
        public bool DuplicateCheckOnUpdate(string DemkhongName, int DemkhongId)
        {
            return ctx.MstDemkhong.Any(e => e.DemkhongName == DemkhongName && e.DemkhongId != DemkhongId);
        }
    }
}
