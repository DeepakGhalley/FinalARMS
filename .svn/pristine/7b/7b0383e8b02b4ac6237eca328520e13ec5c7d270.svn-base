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
    public class DesignationBLL : IDesignation
    {
        readonly tt_dbContext ctx = new tt_dbContext();

        public bool CheckExists(int id)
        {
            return ctx.MstDesignation.Any(e => e.DesignationId == id); ;
        }

        public async Task Delete(int? id)
        {
            var MStDesignation = await ctx.MstDesignation
            .FirstOrDefaultAsync(m => m.DesignationId == id);
        }

        public async Task DeleteConfirmed(int id)
        {
            using (TransactionScope s = new TransactionScope())
            {
                var MstDesignation = ctx.MstDesignation.Find(id);
                ctx.MstDesignation.Remove(MstDesignation);
                ctx.SaveChanges();
                s.Complete();
                s.Dispose();
            }
        }

        public async Task<DesignationModel> Details(int? id)
        {
            var data = (from a in ctx.MstDesignation.Where(aa => aa.DesignationId == id)
                        select new DesignationModel
                        {DesignationId=a.DesignationId,
                            Designation = a.Designation,
                            IsActive = a.IsActive,
                            CreatedBy = a.CreatedBy,
                            CreatedOn = a.CreatedOn,
                            ModifiedBy = a.ModifiedBy,
                            ModifiedOn = a.ModifiedOn,
                            SectionId = a.SectionId

                        });

            return await data.FirstOrDefaultAsync();
        }

        public bool DuplicateCheckOnSave(string DesignationName)
        {
            return ctx.MstDesignation.Any(e => e.Designation == DesignationName);
        }

        public bool DuplicateCheckOnUpdate(string DesignationName, int Id, int Section)
        {
            return ctx.MstDesignation.Any(e => e.Designation == DesignationName && e.DesignationId != Id && e.SectionId == Section);

        }

        public IList<DesignationModel> GetAll()
        {
            var data = (from x in ctx.MstDesignation 
                        join y in ctx.MstSection on x.SectionId equals y.SectionId
                        select new DesignationModel
                        {
                            DesignationId = x.DesignationId,
                            Designation = x.Designation,
                            SectionId = x.SectionId,
                            SectionName = y.SectionName,
                            IsActive = x.IsActive,
                            CreatedBy = x.CreatedBy,
                            CreatedOn = x.CreatedOn,
                            ModifiedOn = x.ModifiedOn,
                            ModifiedBy = x.ModifiedBy,
                        });
            return data.ToList();
        }

        public int SaveDesignation(DesignationModel obj)
        {
            try
            {
                using TransactionScope s = new TransactionScope();
                int ipk;
                var entity = new MstDesignation
                {
                    DesignationId = obj.DesignationId,
                    Designation = obj.Designation,
                    SectionId = obj.SectionId,
                    IsActive = obj.IsActive,
                    CreatedBy = obj.CreatedBy,
                    CreatedOn = Convert.ToDateTime(obj.CreatedOn),
                };
                ctx.MstDesignation.Add(entity);
                ctx.SaveChanges();
                s.Complete();
                s.Dispose();
                ipk = entity.DesignationId;

                return ipk;
            }
            catch (System.Exception)
            {
                return 0;
            }
        }

        public int UpdateDesignation(DesignationModel obj)
        {
            try
            {
                using (TransactionScope s = new TransactionScope())
                {
                    var Data = ctx.MstDesignation.FirstOrDefault(u => u.DesignationId == obj.DesignationId);
                    Data.Designation = obj.Designation;  Data.IsActive = obj.IsActive; Data.SectionId = obj.SectionId;
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
