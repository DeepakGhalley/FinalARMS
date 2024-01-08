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
     public class DisposalTypeBLL : IDisposalType
    {
        readonly tt_dbContext ctx = new tt_dbContext();

        public bool CheckExists(int id)
        {
            return ctx.MstDisposalType.Any(e => e.DisposalTypeId == id);
        }

        public async Task Delete(int? id)
        {
            var tblMstDivision = await ctx.MstDisposalType
           .FirstOrDefaultAsync(m => m.DisposalTypeId == id);
        }

        public async Task DeleteConfirmed(int id)
        {
            using (TransactionScope s = new TransactionScope())
            {
                var tblMstDisposalType = ctx.MstDisposalType.Find(id);
                ctx.MstDisposalType.Remove(tblMstDisposalType);
                ctx.SaveChanges();
                s.Complete();
                s.Dispose();

            }
        }

        public async Task<DisposalTypeModel> Details(int? id)
        {
            var data = (from a in ctx.MstDisposalType.Where(aa => aa.DisposalTypeId == id)
                        select new DisposalTypeModel
                        {
                            DisposalTypeId = a.DisposalTypeId,
                            DisposalType = a.DisposalType,
                            DisposalTypeDescription = a.DisposalTypeDescription,
                            IsActive = a.IsActive,
                            CreatedBy = a.CreatedBy,
                            CreatedOn = a.CreatedOn  ,
                            ModifiedBy = a.ModifiedBy,
                            ModifiedOn = a.ModifiedOn

                        });

            return await data.FirstOrDefaultAsync();
        }

        public bool DuplicateCheckOnSave(string disposal)
        {
            return ctx.MstDisposalType.Any(e => e.DisposalType == disposal);
        }

        public bool DuplicateCheckOnUpdate(string disposal, int Id)
        {
            return ctx.MstDisposalType.Any(e => e.DisposalType == disposal && e.DisposalTypeId != Id);
        }

        public IList<DisposalTypeModel> GetAll()
        {
            var data = (from x in ctx.MstDisposalType
                        select new DisposalTypeModel
                        {
                            DisposalTypeId = x.DisposalTypeId,
                            DisposalType = x.DisposalType,
                            DisposalTypeDescription = x.DisposalTypeDescription,
                            IsActive = x.IsActive,
                            CreatedBy = x.CreatedBy,
                            CreatedOn = x.CreatedOn,
                            ModifiedOn = x.ModifiedOn,
                            ModifiedBy = x.ModifiedBy,
                        });
            return data.ToList();
        }

        public int Save(DisposalTypeModel obj)
        {
            try
            {
                using (TransactionScope s = new TransactionScope())
                {
                    int ipk;
                    var entity = new MstDisposalType
                    {
                        DisposalTypeId = obj.DisposalTypeId,
                        DisposalType = obj.DisposalType,
                        DisposalTypeDescription = obj.DisposalTypeDescription,
                        IsActive = obj.IsActive,
                        CreatedBy = obj.CreatedBy,
                        CreatedOn = Convert.ToDateTime(obj.CreatedOn),
                    };
                    ctx.MstDisposalType.Add(entity);
                    ctx.SaveChanges();
                    s.Complete();
                    s.Dispose();
                    ipk = entity.DisposalTypeId;

                    return ipk;
                }
            }
            catch (System.Exception)
            {
                return 0;
            }
        }

        public int Update(DisposalTypeModel obj)
        {
            try
            {
                using (TransactionScope s = new TransactionScope())
                {
                    var Data = ctx.MstDisposalType.FirstOrDefault(u => u.DisposalTypeId == obj.DisposalTypeId);
                    Data.DisposalType = obj.DisposalType; Data.DisposalTypeDescription = obj.DisposalTypeDescription; Data.IsActive = obj.IsActive;
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
    }
}
