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
    public class BankBLL : IBank
    {
        readonly tt_dbContext ctx = new tt_dbContext();

        public bool CheckExistsAsync(int id)
        {
            return ctx.MstBank.Any(e => e.BankId == id);
        }

        public async Task Delete(int? id)
        {
            var tblMstBank = await ctx.MstBank
           .FirstOrDefaultAsync(m => m.BankId == id);
        }

        public async Task DeleteConfirmed(int id)
        {
            using (TransactionScope s = new TransactionScope())
            {
                var tblMstBank = ctx.MstBank.Find(id);
                ctx.MstBank.Remove(tblMstBank);
                ctx.SaveChanges();
                s.Complete();
                s.Dispose();

            }
        }

        public async Task<BankModel> Details(int? id)
        {
            var data = (from a in ctx.MstBank.Where(aa => aa.BankId == id)
                        select new BankModel
                        {
                            BankId = a.BankId,
                            BankCode = a.BankCode,
                            BankName = a.BankName,
                            IsActive = a.IsActive,
                            CreatedBy = a.CreatedBy,
                            CreatedDate = a.CreatedOn,
                            ModifiedBy = a.ModifiedBy,
                            ModifiedDate = a.ModifiedOn

                        });

            return await data.FirstOrDefaultAsync();
        }

        public bool DuplicateCheckOnSave(string BankName)
        {
            return ctx.MstBank.Any(e => e.BankName == BankName);
        }

        public bool DuplicateCheckOnUpdate(string BankName, int Id)
        {
            return ctx.MstBank.Any(e => e.BankName == BankName && e.BankId != Id);
        }

        public IList<BankModel> GetAll()
        {
            var data = (from x in ctx.MstBank
                        select new BankModel
                        {
                            BankId = x.BankId,
                            BankCode = x.BankCode,
                            BankName = x.BankName,
                            IsActive = x.IsActive,
                            CreatedBy = x.CreatedBy,
                            CreatedDate = x.CreatedOn,
                            ModifiedDate = x.ModifiedOn,
                            ModifiedBy = x.ModifiedBy,
                        });
            return data.ToList();
        }

        public int Save(BankModel obj)
        {
            try
            {
                using (TransactionScope s = new TransactionScope())
                {
                    int ipk;
                    var entity = new MstBank
                    {
                        BankId = obj.BankId,
                        BankCode = obj.BankCode,
                        BankName = obj.BankName,
                        IsActive = obj.IsActive,
                        CreatedBy = obj.CreatedBy,
                        CreatedOn = Convert.ToDateTime(obj.CreatedDate),
                    };
                    ctx.MstBank.Add(entity);
                    ctx.SaveChanges();
                    s.Complete();
                    s.Dispose();
                    ipk = entity.BankId;

                    return ipk;
                }
            }
            catch (System.Exception)
            {
                return 0;
            }
        }

        public int Update(BankModel obj)
        {
            try
            {
                using (TransactionScope s = new TransactionScope())
                {
                    var Data = ctx.MstBank.FirstOrDefault(u => u.BankId == obj.BankId);
                    Data.BankCode = obj.BankCode; Data.BankName = obj.BankName; Data.IsActive = obj.IsActive;
                    Data.ModifiedBy = obj.ModifiedBy; Data.ModifiedOn = obj.ModifiedDate;
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
