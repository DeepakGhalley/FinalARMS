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
    public class OccupationBLL : IOccupation
    {
        readonly tt_dbContext ctx = new tt_dbContext();
        public bool CheckExists(int id)
        {
            return ctx.MstOccupation.Any(e => e.OccupationId == id);
        }

        public Task Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteConfirmed(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<OccupationVM> Details(int? id)
        {
            var data = (from a in ctx.MstOccupation.Where(aa => aa.OccupationId == id)
                        select new OccupationVM
                        {
                            OccupationId = a.OccupationId,
                            Occupation = a.Occupation,
                            IsActive = a.IsActive,
                            CreatedBy = a.CreatedBy,
                            CreatedOn = a.CreatedOn,
                            ModifiedBy = a.ModifiedBy,
                            ModifiedOn = a.ModifiedOn

                        });

            return await data.FirstOrDefaultAsync();
        }

        public bool DuplicateCheckOnSave(string Occupation)
        {
            return ctx.MstOccupation.Any(e => e.Occupation == Occupation);
        }

        public bool DuplicateCheckOnUpdate(string Occupation, int Id)
        {
            return ctx.MstOccupation.Any(e => e.Occupation == Occupation && e.OccupationId != Id);
        }

        public IList<OccupationVM> GetAll()
        {
            var data = (from x in ctx.MstOccupation

                        select new OccupationVM
                        {
                            OccupationId = x.OccupationId,
                            Occupation = x.Occupation,
                            IsActive = x.IsActive,
                            CreatedBy = x.CreatedBy,
                            CreatedOn = x.CreatedOn,
                            ModifiedBy = x.ModifiedBy,
                            ModifiedOn = x.ModifiedOn
                        });
            return data.ToList();
        }

        public int Save(OccupationVM obj)
        {
            try
            {
                using TransactionScope s = new TransactionScope();
                int ipk;
                var entity = new MstOccupation
                {
                    OccupationId = obj.OccupationId,
                    Occupation = obj.Occupation,
                    IsActive = obj.IsActive,
                    CreatedBy = obj.CreatedBy,
                    CreatedOn = Convert.ToDateTime(obj.CreatedOn),
                };
                ctx.MstOccupation.Add(entity);
                ctx.SaveChanges();
                s.Complete();
                s.Dispose();
                ipk = entity.OccupationId;

                return ipk;
            }
            catch (System.Exception)
            {
                return 0;
            }
        }

        public int Update(OccupationVM obj)
        {
            try
            {
                using (TransactionScope s = new TransactionScope())
                {
                    var Data = ctx.MstOccupation.FirstOrDefault(u => u.OccupationId == obj.OccupationId);
                    Data.Occupation = obj.Occupation;
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
