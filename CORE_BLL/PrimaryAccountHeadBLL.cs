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
    public class PrimaryAccountHeadBLL : IPrimaryAccountHead
    {
        readonly tt_dbContext ctx = new tt_dbContext();

        public IList<PrimaryAccountHeadModel> GetAll()
        {
            var data = (from x in ctx.MstPrimaryAccountHead
                        select new PrimaryAccountHeadModel
                        {
                            PrimaryAccountHeadId = x.PrimaryAccountHeadId,
                            PrimaryAccountHeadName = x.PrimaryAccountHeadName,
                            PrimaryAccountHeadCode = x.PrimaryAccountHeadCode,
                            PrimaryAccountHeadDescription = x.PrimaryAccountHeadDescription,
                            PrimaryAccountHeadSymbol = x.PrimaryAccountHeadSymbol,
                            IsActive = x.IsActive,
                            CreatedBy = x.CreatedBy,
                            CreatedOn = x.CreatedOn,
                            ModifiedOn = x.ModifiedOn,
                            ModifiedBy = x.ModifiedBy
                        });
            return data.ToList();

        }

        public async Task<PrimaryAccountHeadModel> Details(int? id)
        {
            var data = (from a in ctx.MstPrimaryAccountHead.Where(aa => aa.PrimaryAccountHeadId == id)
                        select new PrimaryAccountHeadModel
                        {
                            PrimaryAccountHeadId = a.PrimaryAccountHeadId,
                            PrimaryAccountHeadName = a.PrimaryAccountHeadName,
                            PrimaryAccountHeadCode = a.PrimaryAccountHeadCode,
                            PrimaryAccountHeadDescription = a.PrimaryAccountHeadDescription,
                            PrimaryAccountHeadSymbol = a.PrimaryAccountHeadSymbol,
                            IsActive = a.IsActive,
                            CreatedBy = a.CreatedBy,
                            CreatedOn = a.CreatedOn,
                            ModifiedBy = a.ModifiedBy,
                            ModifiedOn = a.ModifiedOn

                        });

            return await data.FirstOrDefaultAsync();

        }
        public int Save(PrimaryAccountHeadModel obj)
        {
            try
            {
                using TransactionScope s = new TransactionScope();
                int ipk;
                var entity = new MstPrimaryAccountHead
                {
                    PrimaryAccountHeadId = obj.PrimaryAccountHeadId,
                    PrimaryAccountHeadName = obj.PrimaryAccountHeadName,
                    PrimaryAccountHeadCode = obj.PrimaryAccountHeadCode,
                    PrimaryAccountHeadDescription = obj.PrimaryAccountHeadDescription,
                    PrimaryAccountHeadSymbol = obj.PrimaryAccountHeadSymbol,
                    IsActive = obj.IsActive,
                    CreatedBy = obj.CreatedBy,
                    CreatedOn = Convert.ToDateTime(obj.CreatedOn),
                };
                ctx.MstPrimaryAccountHead.Add(entity);
                ctx.SaveChanges();
                s.Complete();
                s.Dispose();
                ipk = entity.PrimaryAccountHeadId;

                return ipk;
            }
            catch (System.Exception)
            {
                return 0;
            }
        }

        public int Update(PrimaryAccountHeadModel obj)
        {
            try
            {
                using (TransactionScope s = new TransactionScope())
                {
                    var Data = ctx.MstPrimaryAccountHead.FirstOrDefault(u => u.PrimaryAccountHeadId == obj.PrimaryAccountHeadId);
                    Data.PrimaryAccountHeadName = obj.PrimaryAccountHeadName; Data.PrimaryAccountHeadCode = obj.PrimaryAccountHeadCode; Data.PrimaryAccountHeadDescription = obj.PrimaryAccountHeadDescription; Data.PrimaryAccountHeadSymbol = obj.PrimaryAccountHeadSymbol; Data.IsActive = obj.IsActive;
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
            return ctx.MstPrimaryAccountHead.Any(e => e.PrimaryAccountHeadId == id);
        }

        public async Task DeleteConfirmed(int id)
        {
            using (TransactionScope s = new TransactionScope())
            {
                var MstPrimaryAccountHead = ctx.MstPrimaryAccountHead.Find(id);
                ctx.MstPrimaryAccountHead.Remove(MstPrimaryAccountHead);
                ctx.SaveChanges();
                s.Complete();
                s.Dispose();

            }
        }

        public async Task Delete(int? id)
        {
            var MstPrimaryAccountHead = await ctx.MstPrimaryAccountHead
                           .FirstOrDefaultAsync(m => m.PrimaryAccountHeadId == id);
        }
        public bool DuplicateCheckOnSave(string PrimaryAccountHeadName)
        {
            return ctx.MstPrimaryAccountHead.Any(e => e.PrimaryAccountHeadName == PrimaryAccountHeadName);
        }
        public bool DuplicateCheckOnUpdate(string PrimaryAccountHeadName, int PrimaryAccountHeadId)
        {
            return ctx.MstPrimaryAccountHead.Any(e => e.PrimaryAccountHeadName == PrimaryAccountHeadName && e.PrimaryAccountHeadId != PrimaryAccountHeadId);
        }
        }
}
