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
    public class SecondaryAccountHeadBLL : ISecondaryAccountHead
    {
        readonly tt_dbContext ctx = new tt_dbContext();

        public IList<SecondaryAccountHeadModel> GetAll()
        {
            var data = (from x in ctx.MstSecondaryAccountHead
                        join y in ctx.MstPrimaryAccountHead on x.PrimaryAccountHeadId equals y.PrimaryAccountHeadId

                        select new SecondaryAccountHeadModel
                        {
                            SecondaryAccountHeadId = x.SecondaryAccountHeadId,
                            SecondaryAccountHeadName = x.SecondaryAccountHeadName,
                            SecondaryAccountHeadCode = x.SecondaryaccountHeadCode,
                            PrimaryAccountHeadId = x.PrimaryAccountHeadId,
                            PrimaryAccountHeadName = y.PrimaryAccountHeadName,
                            SecondaryAccountHeadDescription = x.SecondaryaccountHeadDescription,
                            SecondaryAccountHeadSymbol = x.SecondaryaccountHeadSymbol,
                            IsActive = x.IsActive,
                            CreatedBy = x.CreatedBy,
                            CreatedOn = x.CreatedOn,
                            ModifiedOn = x.ModifiedOn,
                            ModifiedBy = x.ModifiedBy
                        });
            return data.ToList();

        }
        public async Task<SecondaryAccountHeadModel> Details(int? id)
        {
            var data = (from a in ctx.MstSecondaryAccountHead.Where(aa => aa.SecondaryAccountHeadId == id)
                        select new SecondaryAccountHeadModel
                        {
                            SecondaryAccountHeadId = a.SecondaryAccountHeadId,
                            PrimaryAccountHeadId = a.PrimaryAccountHeadId,
                            SecondaryAccountHeadName = a.SecondaryAccountHeadName,
                            SecondaryAccountHeadCode = a.SecondaryaccountHeadCode,
                            SecondaryAccountHeadDescription = a.SecondaryaccountHeadDescription,
                            SecondaryAccountHeadSymbol = a.SecondaryaccountHeadSymbol,
                            IsActive = a.IsActive,
                            CreatedBy = a.CreatedBy,
                            CreatedOn = a.CreatedOn,
                            ModifiedBy = a.ModifiedBy,
                            ModifiedOn = a.ModifiedOn

                        });

            return await data.FirstOrDefaultAsync();

        }

        public int Save(SecondaryAccountHeadModel obj)
        {
            try
            {
                using TransactionScope s = new TransactionScope();
                int ipk;
                var entity = new MstSecondaryAccountHead
                {
                    SecondaryAccountHeadId = obj.SecondaryAccountHeadId,
                    PrimaryAccountHeadId = obj.PrimaryAccountHeadId,
                    SecondaryAccountHeadName = obj.SecondaryAccountHeadName,
                    SecondaryaccountHeadCode = obj.SecondaryAccountHeadCode,
                    SecondaryaccountHeadDescription = obj.SecondaryAccountHeadDescription,
                    SecondaryaccountHeadSymbol = obj.SecondaryAccountHeadSymbol,
                    IsActive = obj.IsActive,
                    CreatedBy = obj.CreatedBy,
                    CreatedOn = Convert.ToDateTime(obj.CreatedOn),
                };
                ctx.MstSecondaryAccountHead.Add(entity);
                ctx.SaveChanges();
                s.Complete();
                s.Dispose();
                ipk = entity.SecondaryAccountHeadId;

                return ipk;
            }
            catch (System.Exception)
            {
                return 0;
            }
        }

        public int Update(SecondaryAccountHeadModel obj)
        {
            try
            {
                using (TransactionScope s = new TransactionScope())
                {
                    var Data = ctx.MstSecondaryAccountHead.FirstOrDefault(u => u.SecondaryAccountHeadId == obj.SecondaryAccountHeadId);
                    Data.SecondaryAccountHeadName = obj.SecondaryAccountHeadName; Data.SecondaryaccountHeadCode = obj.SecondaryAccountHeadCode; Data.SecondaryaccountHeadDescription = obj.SecondaryAccountHeadDescription; Data.PrimaryAccountHeadId = obj.PrimaryAccountHeadId; Data.SecondaryaccountHeadSymbol = obj.SecondaryAccountHeadSymbol; Data.IsActive = obj.IsActive;
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
            return ctx.MstSecondaryAccountHead.Any(e => e.SecondaryAccountHeadId == id);
        }

        public async Task DeleteConfirmed(int id)
        {
            using (TransactionScope s = new TransactionScope())
            {
                var MstAccounts = ctx.MstSecondaryAccountHead.Find(id);
                ctx.MstSecondaryAccountHead.Remove(MstAccounts);
                ctx.SaveChanges();
                s.Complete();
                s.Dispose();

            }
        }

        public async Task Delete(int? id)
        {
            var MstAccounts = await ctx.MstSecondaryAccountHead
                           .FirstOrDefaultAsync(m => m.SecondaryAccountHeadId == id);
        }
        public bool DuplicateCheckOnSave(string SecondaryAccountHeadName)
        {
            return ctx.MstSecondaryAccountHead.Any(e => e.SecondaryAccountHeadName == SecondaryAccountHeadName);
        }
        public bool DuplicateCheckOnUpdate(string SecondaryAccountHeadName, int PrimaryAccountHeadId, int SecondaryAccountHeadId)
        {
            return ctx.MstSecondaryAccountHead.Any(e => e.SecondaryAccountHeadName == SecondaryAccountHeadName && e.PrimaryAccountHeadId == PrimaryAccountHeadId && e.SecondaryAccountHeadId != SecondaryAccountHeadId);
        }
    }
}
      