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
    public class LandTypeBLL : ILandType
    {
        readonly tt_dbContext ctx = new tt_dbContext();

        public bool CheckExists(int id)
        {
            return ctx.MstLandType.Any(e => e.LandTypeId == id);
        }

        public Task Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteConfirmed(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<LandTypeVM> Details(int? id)
        {
            var data = (from a in ctx.MstLandType.Where(aa => aa.LandTypeId == id)
                        select new LandTypeVM
                        {
                            LandTypeId = a.LandTypeId,
                            LandTypeName = a.LandTypeName,
                            IsActive = a.IsActive,
                            CreatedBy = a.CreatedBy,
                            CreatedOn = a.CreatedOn,
                            ModifiedBy = a.ModifiedBy,
                            ModifiedOn = a.ModifiedOn

                        });

            return await data.FirstOrDefaultAsync();
        }

        public bool DuplicateCheckOnSave(string LandTypeName)
        {
            return ctx.MstLandType.Any(e => e.LandTypeName == LandTypeName);
        }

        public bool DuplicateCheckOnUpdate(string LandTypeName, int Id)
        {
            return ctx.MstLandType.Any(e => e.LandTypeName == LandTypeName && e.LandTypeId != Id);
        }

            public IList<LandTypeVM> GetAll()
        {
            var data = (from x in ctx.MstLandType

                        select new LandTypeVM
                        {
                            LandTypeId = x.LandTypeId,
                            LandTypeName = x.LandTypeName,
                            IsActive = x.IsActive,
                            CreatedBy = x.CreatedBy,
                            CreatedOn = x.CreatedOn,
                            ModifiedBy = x.ModifiedBy,
                            ModifiedOn = x.ModifiedOn
                        });
            return data.ToList();
        }

        public int Save(LandTypeVM obj)
        {
            try
            {
                using TransactionScope s = new TransactionScope();
                int ipk;
                var entity = new MstLandType
                {
                    LandTypeId = obj.LandTypeId,
                    LandTypeName = obj.LandTypeName,
                    IsActive = obj.IsActive,
                    CreatedBy = obj.CreatedBy,
                    CreatedOn = Convert.ToDateTime(obj.CreatedOn),
                };
                ctx.MstLandType.Add(entity);
                ctx.SaveChanges();
                s.Complete();
                s.Dispose();
                ipk = entity.LandTypeId;

                return ipk;
            }
            catch (System.Exception)
            {
                return 0;
            }
        }

        public int Update(LandTypeVM obj)
        {
            try
            {
                using (TransactionScope s = new TransactionScope())
                {
                    var Data = ctx.MstLandType.FirstOrDefault(u => u.LandTypeId == obj.LandTypeId);
                    Data.LandTypeName = obj.LandTypeName;
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
