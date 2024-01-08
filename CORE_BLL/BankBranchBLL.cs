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
    public class BankBranchBLL : IBankBranch
    {
        readonly tt_dbContext ctx = new tt_dbContext();
        public bool CheckExistsAsync(int id)
        {
            return ctx.MstBankBranch.Any(e => e.BankBranchId == id);
        }

        public async Task Delete(int? id)
        {
            var tblMstBankBranch = await ctx.MstBankBranch
           .FirstOrDefaultAsync(m => m.BankBranchId == id);
        }

        public async Task DeleteConfirmed(int id)
        {
            using (TransactionScope s = new TransactionScope())
            {
                var tblMstBankBranch = ctx.MstBankBranch.Find(id);
                ctx.MstBankBranch.Remove(tblMstBankBranch);
                ctx.SaveChanges();
                s.Complete();
                s.Dispose();

            }
        }

        public async Task<BankBranchModel> Details(int? id)
        {
            var data = (from a in ctx.MstBankBranch.Where(aa => aa.BankBranchId == id)
                        select new BankBranchModel
                        {
                            BankBranchId = a.BankBranchId,
                            BankId = a.BankId,
                            BranchName = a.BranchName,
                            BranchOfficeAddress = a.BranchOfficeAddress,
                            PhoneNo = a.PhoneNo,
                            FaxNo = a.FaxNo,
                            ContactEmail = a.ContactEmail,
                            ContactPerson = a.ContactPerson,
                            IsActive = a.IsActive,
                            CreatedBy = a.CreatedBy,
                            CreatedOn = a.CreatedOn,
                            ModifiedBy = a.ModifiedBy,
                            ModifiedOn = a.ModifiedOn

                        });

            return await data.FirstOrDefaultAsync();
        }

        public bool DuplicateCheckOnSave(string BranchName)
        {
            return ctx.MstBankBranch.Any(e => e.BranchName == BranchName);
        }

        public bool DuplicateCheckOnUpdate(string BranchName, int Id, int Bank)
        {
            return ctx.MstBankBranch.Any(e => e.BranchName == BranchName && e.BankBranchId != Id && e.BankId == Bank);
        }
        

        public IList<BankBranchModel> GetAll()
        {
            var data = (from x in ctx.MstBankBranch
                        join y in ctx.MstBank on x.BankId equals y.BankId
                        select new BankBranchModel
                        {
                            BankBranchId = x.BankBranchId,
                            BankId = x.BankId,
                            BankName = y.BankName,
                            BranchName = x.BranchName,
                            BranchOfficeAddress = x.BranchOfficeAddress,
                            PhoneNo = x.PhoneNo,
                            FaxNo = x.FaxNo,
                            ContactEmail = x.ContactEmail,
                            ContactPerson = x.ContactPerson,
                            IsActive = x.IsActive,
                            CreatedBy = x.CreatedBy,
                            CreatedOn = x.CreatedOn,
                            ModifiedOn = x.ModifiedOn,
                            ModifiedBy = x.ModifiedBy,
                        });
            return data.ToList();
        }

        public int Save(BankBranchModel obj)
        {
            try
            {
                using (TransactionScope s = new TransactionScope())
                {
                    int ipk;
                    var entity = new MstBankBranch
                    {
                        //BankBranchId = obj.BankBranchId,
                        BankId = obj.BankId,
                        BranchName = obj.BranchName,
                        BranchOfficeAddress = obj.BranchOfficeAddress,
                        PhoneNo = obj.PhoneNo,
                        FaxNo = obj.FaxNo,
                        ContactEmail = obj.ContactEmail,
                        ContactPerson = obj.ContactPerson,
                        IsActive = obj.IsActive,
                        CreatedBy = obj.CreatedBy,
                        CreatedOn = Convert.ToDateTime(obj.CreatedOn),
                    };
                    ctx.MstBankBranch.Add(entity);
                    ctx.SaveChanges();
                    s.Complete();
                    s.Dispose();
                    ipk = entity.BankBranchId;

                    return ipk;
                }
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public int Update(BankBranchModel obj)
        {
            try
            {
                using (TransactionScope s = new TransactionScope())
                {
                    var Data = ctx.MstBankBranch.FirstOrDefault(u => u.BankBranchId == obj.BankBranchId);
                    Data.BankId = obj.BankId; Data.BranchOfficeAddress = obj.BranchOfficeAddress; Data.BranchName = obj.BranchName;
                    Data.PhoneNo = obj.PhoneNo; Data.FaxNo = obj.FaxNo; Data.ContactPerson = obj.ContactPerson;
                    Data.ContactEmail = obj.ContactEmail; Data.IsActive = obj.IsActive;
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
