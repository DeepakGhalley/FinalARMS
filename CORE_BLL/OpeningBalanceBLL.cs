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
    public class OpeningBalanceBLL : IOpeningBalance
    {
        readonly tt_dbContext ctx = new tt_dbContext();

        public bool CheckExistsAsync(int id)
        {
            return ctx.TblOpeningBalance.Any(e => e.OpeningBalanceId == id);
        }

        public async Task Delete(int? id)
        {
            var tblmannualreceipt = await ctx.TblOpeningBalance
           .FirstOrDefaultAsync(m => m.OpeningBalanceId == id);
        }

        public async Task DeleteConfirmed(int id)
        {
            using (TransactionScope s = new TransactionScope())
            {
                var TblOpeningBalance = ctx.TblOpeningBalance.Find(id);
                ctx.TblOpeningBalance.Remove(TblOpeningBalance);
                ctx.SaveChanges();
                s.Complete();
                s.Dispose();

            }
        }

        public async Task<OpeningBalaceVM> Details(int? id)
        {
            var data = (from a in ctx.TblOpeningBalance.Where(aa => aa.OpeningBalanceId == id)
                        
                        select new OpeningBalaceVM
                        {
                            OpeningBalanceId= a.OpeningBalanceId,
                            Particular = a.Particular,
                            Amount = a.Amount,
                            Remarks = a.Remarks,
                            OpeningBalanceCarriedOn = a.OpeningBalanceCarriedOn,

                           
                        


                        });

            return await data.FirstOrDefaultAsync();
        }

       

     

        public IList<OpeningBalaceVM> GetAll()
        {
            var data = (from a in ctx.TblOpeningBalance
                        select new OpeningBalaceVM
                        {
                            OpeningBalanceId = a.OpeningBalanceId,
                            Particular = a.Particular,
                            Amount = a.Amount,
                            Remarks = a.Remarks,
                            OpeningBalanceCarriedOn = a.OpeningBalanceCarriedOn,

                        });
            return data.ToList();
        }

        public int Save(OpeningBalaceVM obj)
        {
            try
            {
                using (TransactionScope s = new TransactionScope())
                {
                    int ipk;
                    var entity = new TblOpeningBalance
                    {
                       
       
                       OpeningBalanceId = obj.OpeningBalanceId,
                          Particular = obj.Particular,
                        Amount = obj.Amount,
                        OpeningBalanceCarriedOn = obj.OpeningBalanceCarriedOn,
                        
                        Remarks = obj.Remarks,
                        CreatedBy = obj.CreatedBy,
                        CreatedOn = DateTime.Now,


                    };
                    ctx.TblOpeningBalance.Add(entity);
                    ctx.SaveChanges();
                    s.Complete();
                    s.Dispose();
                    ipk = entity.OpeningBalanceId;

                    return ipk;
                }
            }
            catch (System.Exception)
            {
                return 0;
            }
        }

        public int Update(OpeningBalaceVM obj)
        {
            try
            {
                using (TransactionScope s = new TransactionScope())
                {
                    var Data = ctx.TblOpeningBalance.FirstOrDefault(u => u.OpeningBalanceId == obj.OpeningBalanceId);
                    Data.Particular = obj.Particular; Data.Amount = obj.Amount; 
                    Data.OpeningBalanceCarriedOn = obj.OpeningBalanceCarriedOn;
                  
                    Data.Remarks = obj.Remarks;
                    Data.ModifiedBy = obj.ModifiedBy; Data.ModifiedOn = DateTime.Now;
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
