using CORE_DLL;
using System;
using System.Collections.Generic;
using CORE_BOL;
using CORE_BOL.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Transactions;
//using System.Security.Cryptography.X509Certificates;

namespace CORE_BLL
{
    public class DivisionBLL : IDivision
    {
        readonly tt_dbContext ctx = new tt_dbContext();
        public IList<DivisionModel> GetAll()
        {
            var data = (from x in ctx.MstDivision
                        select new DivisionModel
                        {
                            DivisionId = x.DivisionId,
                            DivisionCode = x.DivisionCode,
                            DivisionName = x.DivisionName,
                            IsActive = x.IsActive,
                            CreatedBy = x.CreatedBy,
                            CreatedOn = x.CreatedOn,
                            ModifiedOn = x.ModifiedOn,
                            ModifiedBy = x.ModifiedBy,
                        });
            return data.ToList();

        }

        public async Task<DivisionModel> Details(int? id)
        {
            //var data1 = ctx.TblMstUser.Include(t => t.Role);
            var data = (from a in ctx.MstDivision.Where(aa => aa.DivisionId == id)
                        select new DivisionModel
                        {
                            DivisionId = a.DivisionId,DivisionName=a.DivisionName,DivisionCode=a.DivisionCode
                            ,IsActive=a.IsActive,CreatedBy=a.CreatedBy,CreatedOn=a.CreatedOn
                            ,ModifiedBy=a.ModifiedBy,ModifiedOn=a.ModifiedOn

                        });

            return await data.FirstOrDefaultAsync();
            
        }

        public int SaveDivision(DivisionModel obj)
        {
            try
            {
                using (TransactionScope s = new TransactionScope())
                {
                    int ipk;
                    var entity = new MstDivision
                    {
                        DivisionId  = obj.DivisionId,
                        DivisionCode =  obj.DivisionCode,
                        DivisionName = obj.DivisionName,
                        IsActive = obj.IsActive,
                        CreatedBy = obj.CreatedBy,
                        CreatedOn = Convert.ToDateTime(obj.CreatedOn),
                    };
                    ctx.MstDivision.Add(entity);                   
                     ctx.SaveChanges();
                    s.Complete();
                    s.Dispose();
                    ipk = entity.DivisionId;

                    return ipk;
                }
            }
            catch (System.Exception)
            { 
                return 0;
            }
        }

        public int UpdateDivision(DivisionModel obj)
        {
            try
            {
                using (TransactionScope s = new TransactionScope())
                {
                    var Data = ctx.MstDivision.FirstOrDefault(u => u.DivisionId == obj.DivisionId);
                    Data.DivisionCode = obj.DivisionCode;Data.DivisionName = obj.DivisionName; Data.IsActive = obj.IsActive;
                    Data.ModifiedBy = obj.ModifiedBy; Data.ModifiedOn = obj.ModifiedOn;
                    ctx.SaveChanges();
                    s.Complete();
                    s.Dispose();
                    return 1;
                    //  var dataUP = ctx.TblMstUser.Where(x => x.UserId == obj.UserId);

                    ////  dataUP.UserName = obj.UserName;
                    //      ctx.Entry(dataUP).State = EntityState.Modified;
                    //      ctx.SaveChanges();               
                }

            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        public bool CheckExists(int id)
        {
            return ctx.MstDivision.Any(e => e.DivisionId == id);
        }

        public async Task DeleteConfirmed(int id)
        {
            using (TransactionScope s = new TransactionScope())
            {
                var tblMstDivision =  ctx.MstDivision.Find(id);
                ctx.MstDivision.Remove(tblMstDivision);
                 ctx.SaveChanges();
                s.Complete();
                s.Dispose();

            }
        }

        public async Task Delete(int? id)
        {
            var tblMstDivision = await ctx.MstDivision
                           .FirstOrDefaultAsync(m => m.DivisionId == id);
        }

        public bool DuplicateCheckOnSave(string DivisionName)
        {
            return ctx.MstDivision.Any(e => e.DivisionName == DivisionName);
        }

        public bool DuplicateCheckOnUpdate(string DivisionName, int Id)
        {
            return ctx.MstDivision.Any(e => e.DivisionName == DivisionName && e.DivisionId != Id);
        }
    }
}
