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
    public class TransactionTypeBLL : ITransactionType
    {
        readonly tt_dbContext ctx = new tt_dbContext();
        public bool CheckExists(int id)
        {
            return ctx.MstTransactionType.Any(e => e.TransactionTypeId == id);
        }

        public Task Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteConfirmed(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<TransactionTypeVM> Details(int? id)
        {
            var data = (from a in ctx.MstTransactionType.Where(aa => aa.TransactionTypeId == id)
                        join x in ctx.MstSection on a.SectionId equals x.SectionId
                        select new TransactionTypeVM
                        {
                            TransactionTypeId = a.TransactionTypeId,
                            TransactionType = a.TransactionType,
                            TransactionTypeDescription = a.TransactionTypeDescription,
                            SectionId = a.SectionId,
                            SectionName = x.SectionCode,
                            Node = a.Node,
                            HasApprovalProcess=a.HasApprovalProcess,
                            IsActive = a.IsActive,
                            CreatedBy = a.CreatedBy,
                            CreatedOn = a.CreatedOn,
                            ModifiedBy = a.ModifiedBy,
                            ModifiedOn = a.ModifiedOn

                        });

            return await data.FirstOrDefaultAsync();
        }

        public bool DuplicateCheckOnSave(string TransactionType)
        {
            return ctx.MstTransactionType.Any(e => e.TransactionType == TransactionType);
        }

        public bool DuplicateCheckOnUpdate(string TransactionType, int TransactionTypeId)
        {
            return ctx.MstTransactionType.Any(e => e.TransactionType == TransactionType && e.TransactionTypeId != TransactionTypeId);
        }

        public IList<TransactionTypeVM> GetAll()
        {
            var data = (from x in ctx.MstTransactionType
                        join y in ctx.MstSection on x.SectionId equals y.SectionId

                        select new TransactionTypeVM
                        {
                            TransactionTypeId = x.TransactionTypeId,
                            TransactionType = x.TransactionType,
                            TransactionTypeDescription = x.TransactionTypeDescription,
                            SectionId = x.SectionId,
                            SectionName = y.SectionName,
                            Node = x.Node,
                            HasApprovalProcess = x.HasApprovalProcess,
                            IsActive = x.IsActive,
                            CreatedBy = x.CreatedBy,
                            CreatedOn = x.CreatedOn,
                            ModifiedBy = x.ModifiedBy,
                            ModifiedOn = x.ModifiedOn
                        });
            return data.ToList();
        }

        public int Save(TransactionTypeVM obj)
        {
            try
            {
                using TransactionScope s = new TransactionScope();
                int ipk;
                var entity = new MstTransactionType
                {
                    TransactionTypeId = obj.TransactionTypeId,
                    TransactionType = obj.TransactionType,
                    TransactionTypeDescription = obj.TransactionTypeDescription,
                    SectionId = obj.SectionId,
                    Node = obj.Node, HasApprovalProcess = obj.HasApprovalProcess,
                    IsActive = obj.IsActive,
                    CreatedBy = obj.CreatedBy,
                    CreatedOn = Convert.ToDateTime(obj.CreatedOn),
                };
                ctx.MstTransactionType.Add(entity);
                ctx.SaveChanges();
                s.Complete();
                s.Dispose();
                ipk = entity.TransactionTypeId;

                return ipk;
            }
            catch (System.Exception)
            {
                return 0;
            }
        }

        public int Update(TransactionTypeVM obj)
        {
            try
            {
                using (TransactionScope s = new TransactionScope())
                {
                    var Data = ctx.MstTransactionType.FirstOrDefault(u => u.TransactionTypeId == obj.TransactionTypeId);
                    Data.TransactionTypeId = obj.TransactionTypeId;
                    Data.TransactionType = obj.TransactionType;
                    Data.TransactionTypeDescription = obj.TransactionTypeDescription;
                    Data.SectionId = obj.SectionId;
                    Data.Node = obj.Node; Data.HasApprovalProcess = obj.HasApprovalProcess;
                    Data.IsActive = obj.IsActive;
                    Data.ModifiedBy = obj.ModifiedBy;
                    Data.ModifiedOn = obj.ModifiedOn;
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
