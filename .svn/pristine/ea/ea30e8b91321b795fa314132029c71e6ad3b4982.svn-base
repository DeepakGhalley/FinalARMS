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
    public class MinorHeadBLL : IMinorHead
    {
        readonly tt_dbContext ctx = new tt_dbContext();

        public IList<MinorHeadModel> GetAll()
        {
            var data = (from x in ctx.MstMinorHead
                        join y in ctx.MstMajorHead on x.MajorHeadId equals y.MajorHeadId

                        select new MinorHeadModel
                        {
                            MinorHeadId = x.MinorHeadId,
                            MinorHeadName = x.MinorHeadName,
                            MinorHeadCode = x.MinorHeadCode,
                            MajorHeadId = x.MajorHeadId,
                            MajorHeadName = y.MajorHeadName,
                            MinorHeadDescription = x.MinorHeadDescription,
                            MinorHeadSymbol = x.MinorHeadSymbol,
                            IsActive = x.IsActive,
                            CreatedBy = x.CreatedBy,
                            CreatedOn = x.CreatedOn,
                            ModifiedOn = x.ModifiedOn,
                            ModifiedBy = x.ModifiedBy
                        });
            return data.ToList();

        }
        public async Task<MinorHeadModel> Details(int? id)
        {
            var data = (from a in ctx.MstMinorHead.Where(aa => aa.MinorHeadId == id)
                        select new MinorHeadModel
                        {
                            MinorHeadId = a.MinorHeadId,
                            MajorHeadId = a.MajorHeadId,
                            MinorHeadName = a.MinorHeadName,
                            MinorHeadCode = a.MinorHeadCode,
                            MinorHeadDescription = a.MinorHeadDescription,
                            MinorHeadSymbol = a.MinorHeadSymbol,
                            IsActive = a.IsActive,
                            CreatedBy = a.CreatedBy,
                            CreatedOn = a.CreatedOn,
                            ModifiedBy = a.ModifiedBy,
                            ModifiedOn = a.ModifiedOn

                        });

            return await data.FirstOrDefaultAsync();

        }

        public int SaveMinorHead(MinorHeadModel obj)
        {
            try
            {
                using TransactionScope s = new TransactionScope();
                int ipk;
                var entity = new MstMinorHead
                {
                    MinorHeadId = obj.MinorHeadId,
                    MajorHeadId = obj.MajorHeadId,
                    MinorHeadName = obj.MinorHeadName,
                    MinorHeadCode = obj.MinorHeadCode,
                    MinorHeadDescription = obj.MinorHeadDescription,
                    MinorHeadSymbol = obj.MinorHeadSymbol,
                    IsActive = obj.IsActive,
                    CreatedBy = obj.CreatedBy,
                    CreatedOn = Convert.ToDateTime(obj.CreatedOn),
                };
                ctx.MstMinorHead.Add(entity);
                ctx.SaveChanges();
                s.Complete();
                s.Dispose();
                ipk = entity.MinorHeadId;

                return ipk;
            }
            catch (System.Exception)
            {
                return 0;
            }
        }

        public int UpdateMinorHead(MinorHeadModel obj)
        {
            try
            {
                using (TransactionScope s = new TransactionScope())
                {
                    var Data = ctx.MstMinorHead.FirstOrDefault(u => u.MinorHeadId == obj.MinorHeadId);
                    Data.MinorHeadName = obj.MinorHeadName; Data.MinorHeadCode = obj.MinorHeadCode; Data.MinorHeadDescription = obj.MinorHeadDescription; Data.MajorHeadId = obj.MajorHeadId; Data.MinorHeadSymbol = obj.MinorHeadSymbol; Data.IsActive = obj.IsActive;
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
            return ctx.MstMinorHead.Any(e => e.MinorHeadId == id);
        }

        public async Task DeleteConfirmed(int id)
        {
            using (TransactionScope s = new TransactionScope())
            {
                var MstMinorHead = ctx.MstMinorHead.Find(id);
                ctx.MstMinorHead.Remove(MstMinorHead);
                ctx.SaveChanges();
                s.Complete();
                s.Dispose();

            }
        }

        public async Task Delete(int? id)
        {
            var MstMinorHead = await ctx.MstMinorHead
                           .FirstOrDefaultAsync(m => m.MinorHeadId == id);
        }
        public bool DuplicateCheckOnSave(string MinorHeadName)
        {
            return ctx.MstMinorHead.Any(e => e.MinorHeadName == MinorHeadName);
        }
        public bool DuplicateCheckOnUpdate(string MinorHeadName, int MinorHeadId)
        {
            return ctx.MstMinorHead.Any(e => e.MinorHeadName == MinorHeadName && e.MinorHeadId != MinorHeadId);
        }
    }
}
