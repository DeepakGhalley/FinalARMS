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
    public class StreetNameBLL : IStreetName
    {
        readonly tt_dbContext ctx = new tt_dbContext();

        public IList<StreetNameModel> GetAll()
        {
            var data = (from x in ctx.MstStreetName
                        select new StreetNameModel
                        {
                            StreetNameId = x.StreetNameId,
                            StreetName = x.StreetName,
                            IsActive = x.IsActive,
                            CreatedBy = x.CreatedBy,
                            CreationOn = x.CreationOn,
                            ModifiedOn = x.ModifiedOn,
                            ModifiedBy = x.ModifiedBy
                        });
            return data.ToList();

        }
        public async Task<StreetNameModel> Details(int? id)
        {
            var data = (from a in ctx.MstStreetName.Where(aa => aa.StreetNameId == id)
                        select new StreetNameModel
                        {
                            StreetNameId = a.StreetNameId,
                            StreetName = a.StreetName,
                            IsActive = a.IsActive,
                            CreatedBy = a.CreatedBy,
                            CreationOn = a.CreationOn,
                            ModifiedBy = a.ModifiedBy,
                            ModifiedOn = a.ModifiedOn

                        });

            return await data.FirstOrDefaultAsync();

        }
        public int Save(StreetNameModel obj)
        {
            try
            {
                using TransactionScope s = new TransactionScope();
                int ipk;
                var entity = new MstStreetName
                {
                    StreetNameId = obj.StreetNameId,
                    StreetName = obj.StreetName,
                    IsActive = obj.IsActive,
                    CreatedBy = obj.CreatedBy,
                    CreationOn = Convert.ToDateTime(obj.CreationOn),
                };
                ctx.MstStreetName.Add(entity);
                ctx.SaveChanges();
                s.Complete();
                s.Dispose();
                ipk = entity.StreetNameId;

                return ipk;
            }
            catch (System.Exception)
            {
                return 0;
            }
        }

        public int Update(StreetNameModel obj)
        {
            try
            {
                using (TransactionScope s = new TransactionScope())
                {
                    var Data = ctx.MstStreetName.FirstOrDefault(u => u.StreetNameId == obj.StreetNameId);
                    Data.StreetName = obj.StreetName;  Data.IsActive = obj.IsActive;
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
        public bool CheckExists(int id)
        {
            return ctx.MstStreetName.Any(e => e.StreetNameId == id);
        }

        public async Task DeleteConfirmed(int id)
        {
            using (TransactionScope s = new TransactionScope())
            {
                var MstStreetName = ctx.MstStreetName.Find(id);
                ctx.MstStreetName.Remove(MstStreetName);
                ctx.SaveChanges();
                s.Complete();
                s.Dispose();

            }
        }

        public async Task Delete(int? id)
        {
            var MstStreetName = await ctx.MstStreetName
                           .FirstOrDefaultAsync(m => m.StreetNameId == id);
        }
        public bool DuplicateCheckOnSave(string StreetName)
        {
            return ctx.MstStreetName.Any(e => e.StreetName == StreetName);
        }
        public bool DuplicateCheckOnUpdate(string StreetName, int StreetNameId)
        {
            return ctx.MstStreetName.Any(e => e.StreetName == StreetName && e.StreetNameId != StreetNameId);
        }
    }
}

