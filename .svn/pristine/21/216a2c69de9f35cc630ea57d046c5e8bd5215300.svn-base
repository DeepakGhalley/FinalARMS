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
  public  class ModificationReasonBLL : IModificationReason
    {
        readonly tt_dbContext ctx = new tt_dbContext();
        public IList<ModificationReasonVM> GetAll()
        {
            try
            {
                var data = (from x in ctx.MstModificationReason
                            select new ModificationReasonVM
                            {
                                ModificationReasonId = x.ModificationReasonId,
                                ModificationReason = x.ModificationReason,
                                ReasonDescription = x.ReasonDescription,
                                ReasonCode = x.ReasonCode,
                                IsActive = x.IsActive,
                                CreatedBy = x.CreatedBy,
                                CreatedOn = x.CreatedOn,
                                ModifiedOn = x.ModifiedOn,
                                ModifiedBy = x.ModifiedBy
                            });
                return data.ToList();
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public int Save(ModificationReasonVM obj)
        {
            try
            {
                using (TransactionScope s = new TransactionScope())
                {
                    int ipk;
                    var entity = new MstModificationReason
                    {
                        ModificationReasonId = obj.ModificationReasonId,
                        ModificationReason = obj.ModificationReason,
                        ReasonDescription = obj.ReasonDescription,
                        ReasonCode = obj.ReasonCode,                       
                        IsActive = true,
                        CreatedBy = obj.CreatedBy,
                        CreatedOn = Convert.ToDateTime(obj.CreatedOn),
                    };
                    ctx.MstModificationReason.Add(entity);
                    ctx.SaveChanges();
                    s.Complete();
                    s.Dispose();
                    ipk = entity.ModificationReasonId;

                    return ipk;
                }
            }

            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<ModificationReasonVM> Details(int? id)
        {
            try
            {

                var data = (from a in ctx.MstModificationReason.Where(aa => aa.ModificationReasonId == id)

                            select new ModificationReasonVM
                            {
                                ModificationReasonId = a.ModificationReasonId,
                                ModificationReason = a.ModificationReason,
                                ReasonDescription = a.ReasonDescription,
                                ReasonCode = a.ReasonCode,                              
                                IsActive = a.IsActive,
                                CreatedBy = a.CreatedBy,
                                CreatedOn = a.CreatedOn,
                                ModifiedBy = a.ModifiedBy,
                                ModifiedOn = a.ModifiedOn,

                            });

                return await data.FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {

                throw;
            }

        }
        public int Update(ModificationReasonVM obj)
        {
            try
            {
                using (TransactionScope s = new TransactionScope())
                {
                    var Data = ctx.MstModificationReason.FirstOrDefault(u => u.ModificationReasonId == obj.ModificationReasonId);
                    Data.ModificationReason = obj.ModificationReason; Data.ReasonDescription = obj.ReasonDescription;
                    Data.ReasonCode = obj.ReasonCode;Data.IsActive = obj.IsActive; Data.ModifiedBy = obj.ModifiedBy; Data.ModifiedOn = obj.ModifiedOn;
                    ctx.SaveChanges();
                    s.Complete();
                    s.Dispose();
                    return 1;
                }

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task Delete(int? id)
        {
            try
            {
                var mstModificationReason = await ctx.MstModificationReason                               
                               .FirstOrDefaultAsync(m => m.ModificationReasonId == id);
            }
            catch (Exception ex)
            {

                throw;
            }
        }


        public async Task DeleteConfirmed(int id)
        {
            try
            {

                using (TransactionScope s = new TransactionScope())
                {
                    var mstModificationReason = ctx.MstModificationReason.Find(id);
                    ctx.MstModificationReason.Remove(mstModificationReason);
                    ctx.SaveChanges();
                    s.Complete();
                    s.Dispose();

                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public bool CheckExists(int id)
        {
            try
            {
                return ctx.MstModificationReason.Any(e => e.ModificationReasonId == id);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public bool DuplicateCheckOnSave(string ModificationReason)
        {
            return ctx.MstModificationReason.Any(e => e.ModificationReason == ModificationReason);
        }
        public bool DuplicateCheckOnUpdate(string ModificationReason, int Id)
        {
            return ctx.MstModificationReason.Any(e => e.ModificationReason == ModificationReason && e.ModificationReasonId != Id);
        }

    }
}
