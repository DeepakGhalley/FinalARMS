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
    public class ProcessLevelBLL : IProcessLevel
    {
        readonly tt_dbContext ctx = new tt_dbContext();
        public bool CheckExists(int id)
        {
            return ctx.MstProcessLevel.Any(e => e.ProcessLevelId == id);
        }

        public async Task Delete(int? id)
        {
            var MstProcessLevel = await ctx.MstProcessLevel
            .FirstOrDefaultAsync(m => m.ProcessLevelId == id);
        }

        public async Task DeleteConfirmed(int id)
        {
            using (TransactionScope s = new TransactionScope())
            {
                var MstProcessLevel = ctx.MstProcessLevel.Find(id);
                ctx.MstProcessLevel.Remove(MstProcessLevel);
                ctx.SaveChanges();
                s.Complete();
                s.Dispose();
            }
        }

        public async Task<ProcessLevelModel> Details(int? id)
        {
            var data = (from a in ctx.MstProcessLevel.Where(aa => aa.ProcessLevelId == id)
                        select new ProcessLevelModel
                        {
                            ProcessLevelId = a.ProcessLevelId,
                            TransactionTypeId = a.TransactionTypeId,
                            Process2Approval = (bool)a.Process2Approval,
                            Process3Approval = (bool)a.Process3Approval,
                            CreatedBy = a.CreatedBy,
                            CreatedOn = a.CreatedOn,
                            ModifiedBy = a.ModifiedBy,
                            ModifiedOn = a.ModifiedOn

                        });

            return await data.FirstOrDefaultAsync();
        }

        public IList<ProcessLevelModel> GetAll()
        {
            var data = (from x in ctx.MstProcessLevel
                        join y in ctx.MstTransactionType on x.TransactionTypeId equals y.TransactionTypeId
                        select new ProcessLevelModel
                        {
                            ProcessLevelId = x.ProcessLevelId,
                            TransactionTypeId = x.TransactionTypeId,
                            Process2Approval = (bool)x.Process2Approval,
                            Process3Approval = (bool)x.Process3Approval,
                            TransationTypeName = y.TransactionType,
                            CreatedBy = x.CreatedBy,
                            CreatedOn = x.CreatedOn,
                            ModifiedOn = x.ModifiedOn,
                            ModifiedBy = x.ModifiedBy,
                        });
            return data.ToList();
        }

        public int Save(ProcessLevelModel obj)
        {
            try
            {
                using TransactionScope s = new TransactionScope();
                int ipk;
                var entity = new MstProcessLevel
                {
                    ProcessLevelId = obj.ProcessLevelId,
                    TransactionTypeId = obj.TransactionTypeId,
                    Process2Approval = obj.Process2Approval,
                    Process3Approval = obj.Process3Approval,
                    CreatedBy = obj.CreatedBy,
                    CreatedOn = Convert.ToDateTime(obj.CreatedOn),
                };
                ctx.MstProcessLevel.Add(entity);
                ctx.SaveChanges();
                s.Complete();
                s.Dispose();
                ipk = entity.ProcessLevelId;

                return ipk;
            }
            catch (System.Exception)
            {
                return 0;
            }
        }

        public int Update(ProcessLevelModel obj)
        {
            try
            {
                using (TransactionScope s = new TransactionScope())
                {
                    var Data = ctx.MstProcessLevel.FirstOrDefault(u => u.ProcessLevelId == obj.ProcessLevelId);
                    Data.TransactionTypeId = obj.TransactionTypeId; Data.Process2Approval = obj.Process2Approval; Data.Process3Approval = obj.Process3Approval;
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
