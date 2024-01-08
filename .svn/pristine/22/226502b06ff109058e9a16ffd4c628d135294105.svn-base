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
    public class RoleBLL : IRole
    {
        readonly tt_dbContext ctx = new tt_dbContext();

        public bool CheckExists(int id)
        {
            return ctx.TblRole.Any(e => e.RoleId == id);
        }

        public Task Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteConfirmed(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<RoleVM> Details(int? id)
        {
            var data = (from a in ctx.TblRole.Where(aa => aa.RoleId == id)
                        select new RoleVM
                        {
                            RoleId = a.RoleId,
                            RoleName = a.RoleName,
                            Description = a.Description,
                            IsActive = a.IsActive,
                            CreatedBy = a.CreatedBy,
                            CreatedOn = a.CreatedOn,
                            ModifiedBy = a.ModifiedBy,
                            ModifiedOn = a.ModifiedOn

                        });

            return await data.FirstOrDefaultAsync();
        }

        public IList<RoleVM> GetAll()
        {
            var data = (from x in ctx.TblRole
                        select new RoleVM
                        {
                            RoleId = x.RoleId,
                            RoleName = x.RoleName,
                            Description = x.Description,
                            IsActive = x.IsActive,
                            CreatedBy = x.CreatedBy,
                            CreatedOn = x.CreatedOn,
                            ModifiedBy = x.ModifiedBy,
                            ModifiedOn = x.ModifiedOn
                        });
            return data.ToList();
        }

        public int Save(RoleVM obj)
        {
            try
            {
                using TransactionScope s = new TransactionScope();
                int ipk;
                var entity = new TblRole
                {
                    RoleId = obj.RoleId,
                    RoleName = obj.RoleName,
                    Description = obj.Description,
                    IsActive = obj.IsActive,
                    CreatedBy = obj.CreatedBy,
                    CreatedOn = Convert.ToDateTime(obj.CreatedOn),
                };
                ctx.TblRole.Add(entity);
                ctx.SaveChanges();
                s.Complete();
                s.Dispose();
                ipk = entity.RoleId;

                return ipk;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public int Update(RoleVM obj)
        {
            try
            {
                using (TransactionScope s = new TransactionScope())
                {
                    var Data = ctx.TblRole.FirstOrDefault(u => u.RoleId == obj.RoleId);
                    Data.RoleId = obj.RoleId; 
                    Data.RoleName = obj.RoleName; 
                    Data.Description = obj.Description; 
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
