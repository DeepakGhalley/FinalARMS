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
    public class DzongkhagBLL : IDzongkhag
    {
        readonly tt_dbContext ctx = new tt_dbContext();

        public IList<DzongkhagModel> GetAll()
        {
            var data = (from x in ctx.MstDzongkhag
                        select new DzongkhagModel
                        {
                            DzongkhagId = x.DzongkhagId,
                            DzongkhagName = x.DzongkhagName,
                            IsActive = x.IsActive,
                            CreatedBy = x.CreatedBy,
                            CreatedOn = x.CreatedOn,
                            ModifiedOn = x.ModifiedOn,
                            ModifiedBy = x.ModifiedBy
                        });
            return data.ToList();

        }

        public async Task<DzongkhagModel> Details(int? id)
        {
            var data = (from a in ctx.MstDzongkhag.Where(aa => aa.DzongkhagId == id)
                        select new DzongkhagModel
                        {
                            DzongkhagId = a.DzongkhagId,
                            DzongkhagName = a.DzongkhagName,
                            IsActive = a.IsActive,
                            CreatedBy = a.CreatedBy,
                            CreatedOn = a.CreatedOn,
                            ModifiedBy = a.ModifiedBy,
                            ModifiedOn = a.ModifiedOn

                        });

            return await data.FirstOrDefaultAsync();

        }
        public int SaveDzongkhag(DzongkhagModel obj)
        {
            try
            {
                using TransactionScope s = new TransactionScope();
                int ipk;
                var entity = new MstDzongkhag
                {
                    DzongkhagId = obj.DzongkhagId,
                    DzongkhagName = obj.DzongkhagName,
                    IsActive = obj.IsActive,
                    CreatedBy = obj.CreatedBy,
                    CreatedOn = Convert.ToDateTime(obj.CreatedOn),
                };
                ctx.MstDzongkhag.Add(entity);
                ctx.SaveChanges();
                s.Complete();
                s.Dispose();
                ipk = entity.DzongkhagId;

                return ipk;
            }
            catch (System.Exception)
            {
                return 0;
            }
        }

        public int UpdateDzongkhag(DzongkhagModel obj)
        {
            try
            {
                using (TransactionScope s = new TransactionScope())
                {
                    var Data = ctx.MstDzongkhag.FirstOrDefault(u => u.DzongkhagId == obj.DzongkhagId);
                    Data.DzongkhagName = obj.DzongkhagName; Data.IsActive = obj.IsActive;
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
            return ctx.MstDzongkhag.Any(e => e.DzongkhagId == id);
        }

        public async Task DeleteConfirmed(int id)
        {
            using (TransactionScope s = new TransactionScope())
            {
                var MstDzongkhag = ctx.MstDzongkhag.Find(id);
                ctx.MstDzongkhag.Remove(MstDzongkhag);
                ctx.SaveChanges();
                s.Complete();
                s.Dispose();

            }
        }

        public async Task Delete(int? id)
        {
            var MstDzongkhag = await ctx.MstDzongkhag
                           .FirstOrDefaultAsync(m => m.DzongkhagId == id);
        }
        public bool DuplicateCheckOnSave(string DzongkhagName)
        {
            return ctx.MstDzongkhag.Any(e => e.DzongkhagName == DzongkhagName);
        }
        public bool DuplicateCheckOnUpdate(string DzongkhagName, int DzongkhagId)
        {
            return ctx.MstDzongkhag.Any(e => e.DzongkhagName == DzongkhagName && e.DzongkhagId != DzongkhagId);
        }
    }
}
