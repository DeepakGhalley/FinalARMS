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
    public class MajorHeadBLL : IMajorHead
    {
        readonly tt_dbContext ctx = new tt_dbContext();

        public IList<MajorHeadModel> GetAll()
        {
            var data = (from x in ctx.MstMajorHead
                        select new MajorHeadModel
                        {
                            MajorHeadId = x.MajorHeadId,
                            MajorHeadName = x.MajorHeadName,
                            MajorHeadCode = x.MajorHeadCode,
                            MajorHeadDescription = x.MajorHeadDescription,
                            MajorHeadSymbol = x.MajorHeadSymbol,
                            IsActive = x.IsActive,
                            CreatedBy = x.CreatedBy,
                            CreatedOn = x.CreatedOn,
                            ModifiedOn = x.ModifiedOn,
                            ModifiedBy = x.ModifiedBy
                        });
            return data.ToList();

        }

        public async Task<MajorHeadModel> Details(int? id)
        {
            var data = (from a in ctx.MstMajorHead.Where(aa => aa.MajorHeadId == id)
                        select new MajorHeadModel
                        {
                            MajorHeadId = a.MajorHeadId,
                            MajorHeadName = a.MajorHeadName,
                            MajorHeadCode = a.MajorHeadCode,
                            MajorHeadDescription = a.MajorHeadDescription,
                            MajorHeadSymbol = a.MajorHeadSymbol,
                            IsActive = a.IsActive,
                            CreatedBy = a.CreatedBy,
                            CreatedOn = a.CreatedOn,
                            ModifiedBy = a.ModifiedBy,
                            ModifiedOn = a.ModifiedOn

                        });

            return await data.FirstOrDefaultAsync();

        }
        public int SaveMajorHead(MajorHeadModel obj)
        {
            try
            {
                using TransactionScope s = new TransactionScope();
                int ipk;
                var entity = new MstMajorHead
                {
                    MajorHeadId = obj.MajorHeadId,
                    MajorHeadName = obj.MajorHeadName,
                    MajorHeadCode = obj.MajorHeadCode,
                    MajorHeadDescription = obj.MajorHeadDescription,
                    MajorHeadSymbol = obj.MajorHeadSymbol,
                    IsActive = obj.IsActive,
                    CreatedBy = obj.CreatedBy,
                    CreatedOn = Convert.ToDateTime(obj.CreatedOn),
                };
                ctx.MstMajorHead.Add(entity);
                ctx.SaveChanges();
                s.Complete();
                s.Dispose();
                ipk = entity.MajorHeadId;

                return ipk;
            }
            catch (System.Exception)
            {
                return 0;
            }
        }

        public int UpdateMajorHead(MajorHeadModel obj)
        {
            try
            {
                using (TransactionScope s = new TransactionScope())
                {
                    var Data = ctx.MstMajorHead.FirstOrDefault(u => u.MajorHeadId == obj.MajorHeadId);
                    Data.MajorHeadName = obj.MajorHeadName; Data.MajorHeadCode = obj.MajorHeadCode; Data.MajorHeadDescription = obj.MajorHeadDescription; Data.MajorHeadSymbol = obj.MajorHeadSymbol; Data.IsActive = obj.IsActive;
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
            return ctx.MstMajorHead.Any(e => e.MajorHeadId == id);
        }

        public async Task DeleteConfirmed(int id)
        {
            using (TransactionScope s = new TransactionScope())
            {
                var MstMajorHead = ctx.MstMajorHead.Find(id);
                ctx.MstMajorHead.Remove(MstMajorHead);
                ctx.SaveChanges();
                s.Complete();
                s.Dispose();

            }
        }

        public async Task Delete(int? id)
        {
            var MstMajorHead = await ctx.MstMajorHead
                           .FirstOrDefaultAsync(m => m.MajorHeadId == id);
        }
        public bool DuplicateCheckOnSave(string MajorHeadName)
        {
            return ctx.MstMajorHead.Any(e => e.MajorHeadName == MajorHeadName);
        }
        public bool DuplicateCheckOnUpdate(string MajorHeadName, int MajorHeadId)
        {
            return ctx.MstMajorHead.Any(e => e.MajorHeadName == MajorHeadName && e.MajorHeadId != MajorHeadId);
        }
    }
}
