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
    public class TertiaryAccountHeadBLL : ITertiaryAccountHead
    {
        readonly tt_dbContext ctx = new tt_dbContext();

        public IList<TertiaryAccountHeadModel> GetAll()
        {
            var data = (from x in ctx.MstTertiaryAccountHead
                        join y in ctx.MstSecondaryAccountHead on x.SecondaryAccountHeadId equals y.SecondaryAccountHeadId

                        select new TertiaryAccountHeadModel
                        {
                            TertiaryAccountHeadId = x.TertiaryAccountHeadId,
                            TertiaryAccountHeadName = x.TertiaryAccountHeadName,
                            TertiaryAccountHeadCode = x.TertiaryAccountHeadCode,
                            TertiaryAccountHeadDescription = x.TertiaryAccountHeadDescription,
                            TertiaryAccountHeadSymbol = x.TertiaryAccountHeadSymbol,
                            SecondaryAccountHeadName = y.SecondaryAccountHeadName,
                            SecondaryAccountHeadId = x.SecondaryAccountHeadId,
                            IsActive = x.IsActive,
                            CreatedBy = x.CreatedBy,
                            CreatedOn = x.CreatedOn,
                            ModifiedOn = x.ModifiedOn,
                            ModifiedBy = x.ModifiedBy
                        });
            return data.ToList();

        }
        public async Task<TertiaryAccountHeadModel> Details(int? id)
        {
            var data = (from a in ctx.MstTertiaryAccountHead.Where(aa => aa.TertiaryAccountHeadId == id)
                        select new TertiaryAccountHeadModel
                        {
                            TertiaryAccountHeadId = a.TertiaryAccountHeadId,
                            TertiaryAccountHeadName = a.TertiaryAccountHeadName,
                            TertiaryAccountHeadCode = a.TertiaryAccountHeadCode,
                            TertiaryAccountHeadDescription = a.TertiaryAccountHeadDescription,
                            TertiaryAccountHeadSymbol = a.TertiaryAccountHeadSymbol,
                            SecondaryAccountHeadId = a.SecondaryAccountHeadId,
                            IsActive = a.IsActive,
                            CreatedBy = a.CreatedBy,
                            CreatedOn = a.CreatedOn,
                            ModifiedBy = a.ModifiedBy,
                            ModifiedOn = a.ModifiedOn

                        });

            return await data.FirstOrDefaultAsync();

        }

        public int Save(TertiaryAccountHeadModel obj)
        {
            try
            {
                using TransactionScope s = new TransactionScope();
                int ipk;
                var entity = new MstTertiaryAccountHead
                {
                    TertiaryAccountHeadId = obj.TertiaryAccountHeadId,
                    TertiaryAccountHeadName = obj.TertiaryAccountHeadName,
                    TertiaryAccountHeadCode = obj.TertiaryAccountHeadCode,
                    TertiaryAccountHeadDescription = obj.TertiaryAccountHeadDescription,
                    TertiaryAccountHeadSymbol = obj.TertiaryAccountHeadSymbol,
                    SecondaryAccountHeadId = obj.SecondaryAccountHeadId,
                    IsActive = obj.IsActive,
                    CreatedBy = obj.CreatedBy,
                    CreatedOn = Convert.ToDateTime(obj.CreatedOn),
                };
                ctx.MstTertiaryAccountHead.Add(entity);
                ctx.SaveChanges();
                s.Complete();
                s.Dispose();
                ipk = entity.TertiaryAccountHeadId;

                return ipk;
            }
            catch (System.Exception)
            {
                return 0;
            }
        }

        public int Update(TertiaryAccountHeadModel obj)
        {
            try
            {
                using (TransactionScope s = new TransactionScope())
                {
                    var Data = ctx.MstTertiaryAccountHead.FirstOrDefault(u => u.TertiaryAccountHeadId == obj.TertiaryAccountHeadId);
                    Data.TertiaryAccountHeadName = obj.TertiaryAccountHeadName; Data.TertiaryAccountHeadCode = obj.TertiaryAccountHeadCode; Data.TertiaryAccountHeadDescription = obj.TertiaryAccountHeadDescription; Data.TertiaryAccountHeadSymbol = obj.TertiaryAccountHeadSymbol; Data.SecondaryAccountHeadId = obj.SecondaryAccountHeadId; Data.IsActive = obj.IsActive;
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
            return ctx.MstTertiaryAccountHead.Any(e => e.TertiaryAccountHeadId == id);
        }

        public async Task DeleteConfirmed(int id)
        {
            using (TransactionScope s = new TransactionScope())
            {
                var MstTertiary = ctx.MstTertiaryAccountHead.Find(id);
                ctx.MstTertiaryAccountHead.Remove(MstTertiary);
                ctx.SaveChanges();
                s.Complete();
                s.Dispose();
            }
        }

        public async Task Delete(int? id)
        {
            var MstTertiary = await ctx.MstTertiaryAccountHead
                           .FirstOrDefaultAsync(m => m.TertiaryAccountHeadId == id);
        }
        public bool DuplicateCheckOnSave(string TertiaryAccountHeadName)
        {
            return ctx.MstTertiaryAccountHead.Any(e => e.TertiaryAccountHeadName == TertiaryAccountHeadName);
        }
        public bool DuplicateCheckOnUpdate(string TertiaryAccountHeadName, int SecondaryAccountHeadId, int TertiaryAccountHeadId)
        {
            return ctx.MstTertiaryAccountHead.Any(e => e.TertiaryAccountHeadName == TertiaryAccountHeadName && e.SecondaryAccountHeadId == SecondaryAccountHeadId && e.TertiaryAccountHeadId != TertiaryAccountHeadId);
        }
    }
}