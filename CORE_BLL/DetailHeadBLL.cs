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
    public class DetailHeadBLL : IDetailHead
    {
        readonly tt_dbContext ctx = new tt_dbContext();

        public IList<DetailHeadModel> GetAll()
        {
            var data = (from x in ctx.MstDetailHead
                        join y in ctx.MstMinorHead on x.MinorHeadId equals y.MinorHeadId

                        select new DetailHeadModel
                        {
                            DetailHeadId = x.DetailHeadId,
                            DetailHeadName = x.DetailHeadName,
                            DetailHeadCode = x.DetailHeadCode,
                            DetailHeadDescription = x.DetailHeadDescription,
                            DetailHeadSymbol = x.DetailHeadSymbol,
                            MinorHeadName = y.MinorHeadName,
                            MinorHeadId = x.MinorHeadId,
                            IsActive = x.IsActive,
                            CreatedBy = x.CreatedBy,
                            CreatedOn = x.CreatedOn,
                            ModifiedOn = x.ModifiedOn,
                            ModifiedBy = x.ModifiedBy
                        });
            return data.ToList();

        }
        public async Task<DetailHeadModel> Details(int? id)
        {
            var data = (from a in ctx.MstDetailHead.Where(aa => aa.DetailHeadId == id)
                        select new DetailHeadModel
                        {
                            DetailHeadId = a.DetailHeadId,
                            DetailHeadName = a.DetailHeadName,
                            DetailHeadCode = a.DetailHeadCode,
                            DetailHeadDescription = a.DetailHeadDescription,
                            DetailHeadSymbol = a.DetailHeadSymbol,
                            MinorHeadId = a.MinorHeadId,
                            IsActive = a.IsActive,
                            CreatedBy = a.CreatedBy,
                            CreatedOn = a.CreatedOn,
                            ModifiedBy = a.ModifiedBy,
                            ModifiedOn = a.ModifiedOn

                        });

            return await data.FirstOrDefaultAsync();

        }

        public int SaveDetailHead(DetailHeadModel obj)
        {
            try
            {
                using TransactionScope s = new TransactionScope();
                int ipk;
                var entity = new MstDetailHead
                {
                    DetailHeadId = obj.DetailHeadId,
                    DetailHeadName = obj.DetailHeadName,
                    DetailHeadCode = obj.DetailHeadCode,
                    DetailHeadDescription = obj.DetailHeadDescription,
                    DetailHeadSymbol = obj.DetailHeadSymbol,
                    MinorHeadId = obj.MinorHeadId,
                    IsActive = obj.IsActive,
                    CreatedBy = obj.CreatedBy,
                    CreatedOn = Convert.ToDateTime(obj.CreatedOn),
                };
                ctx.MstDetailHead.Add(entity);
                ctx.SaveChanges();
                s.Complete();
                s.Dispose();
                ipk = entity.DetailHeadId;

                return ipk;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public int UpdateDetailHead(DetailHeadModel obj)
        {
            try
            {
                using (TransactionScope s = new TransactionScope())
                {
                    var Data = ctx.MstDetailHead.FirstOrDefault(u => u.DetailHeadId == obj.DetailHeadId);
                    Data.DetailHeadName = obj.DetailHeadName; Data.DetailHeadCode = obj.DetailHeadCode; Data.DetailHeadDescription = obj.DetailHeadDescription; Data.DetailHeadSymbol = obj.DetailHeadSymbol; Data.MinorHeadId = obj.MinorHeadId; Data.IsActive = obj.IsActive;
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
            return ctx.MstDetailHead.Any(e => e.DetailHeadId == id);
        }

        public async Task DeleteConfirmed(int id)
        {
            using (TransactionScope s = new TransactionScope())
            {
                var MstDetailHead = ctx.MstDetailHead.Find(id);
                ctx.MstDetailHead.Remove(MstDetailHead);
                ctx.SaveChanges();
                s.Complete();
                s.Dispose();
            }
        }

        public async Task Delete(int? id)
        {
            var MstDetailHead = await ctx.MstDetailHead
                           .FirstOrDefaultAsync(m => m.DetailHeadId == id);
        }
        public bool DuplicateCheckOnSave(string DetailHeadName)
        {
            return ctx.MstDetailHead.Any(e => e.DetailHeadName == DetailHeadName);
        }
        public bool DuplicateCheckOnUpdate(string DetailHeadName, int DetailHeadId)
        {
            return ctx.MstDetailHead.Any(e => e.DetailHeadName == DetailHeadName && e.DetailHeadId != DetailHeadId);
        }
    }
}
