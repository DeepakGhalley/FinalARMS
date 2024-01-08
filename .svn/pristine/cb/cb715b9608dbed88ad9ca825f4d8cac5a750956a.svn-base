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
    public class SectionBLL : ISection
    {
        readonly tt_dbContext ctx = new tt_dbContext();
        public bool CheckExists(int id)
        {
            return ctx.MstSection.Any(e => e.SectionId == id);
        }

        public async Task Delete(int? id)
        {
            var MstSection = await ctx.MstSection
               .FirstOrDefaultAsync(m => m.SectionId == id);
        }

        public async Task DeleteConfirmed(int id)
        {
            using (TransactionScope s = new TransactionScope())
            {
                var MstSection = ctx.MstSection.Find(id);
                ctx.MstSection.Remove(MstSection);
                ctx.SaveChanges();
                s.Complete();
                s.Dispose();
            }
        }

        public async Task<SectionModel> Details(int? id)
        {
            var data = (from a in ctx.MstSection.Where(aa => aa.SectionId == id)
                        select new SectionModel
                        {
                            SectionId = a.SectionId,
                            SectionCode = a.SectionCode,
                            SectionName = a.SectionName,
                            IsActive = a.IsActive,
                            CreatedBy = a.CreatedBy,
                            CreatedOn = a.CreatedOn,
                            ModifiedBy = a.ModifiedBy,
                            ModifiedOn = a.ModifiedOn,
                            DivisionId = a.DivisionId

                        });

            return await data.FirstOrDefaultAsync();

        }

        public bool DuplicateCheckOnSave(string SectionName)
        {
            return ctx.MstSection.Any(e => e.SectionName == SectionName);
        }

        public bool DuplicateCheckOnUpdate(string SectionName, int Id, int Division)
        {
            return ctx.MstSection.Any(e => e.SectionName == SectionName && e.SectionId != Id && e.DivisionId == Division);
        }

        public IList<SectionModel> GetAll()
        {
            var data = (from x in ctx.MstSection 
                        join y in ctx.MstDivision on x.DivisionId equals y.DivisionId
                        orderby x.DivisionId ascending,x.SectionId ascending
                        select new SectionModel
                        {
                            SectionId = x.SectionId,
                            SectionCode = x.SectionCode,
                            SectionName = x.SectionName,
                            DivisionId = x.DivisionId,
                            DivisionName = y.DivisionName,
                            IsActive = x.IsActive,
                            CreatedBy = x.CreatedBy,
                            CreatedOn = x.CreatedOn,
                            ModifiedOn = x.ModifiedOn,
                            ModifiedBy = x.ModifiedBy,
                        });
            return data.ToList();
        }

        public int SaveSection(SectionModel obj)
        {
            try
            {
                using TransactionScope s = new TransactionScope();
                int ipk;
                var entity = new MstSection
                {
                    SectionId = obj.SectionId,
                    DivisionId = obj.DivisionId,
                    SectionCode = obj.SectionCode,
                    SectionName = obj.SectionName,
                    IsActive = obj.IsActive,
                    CreatedBy = obj.CreatedBy,
                    CreatedOn = Convert.ToDateTime(obj.CreatedOn),
                };
                ctx.MstSection.Add(entity);
                ctx.SaveChanges();
                s.Complete();
                s.Dispose();
                ipk = entity.SectionId;

                return ipk;
            }
            catch (System.Exception)
            {
                return 0;
            }
        }

        public int UpdateSection(SectionModel obj)
        {
            try
            {
                using (TransactionScope s = new TransactionScope())
                {
                    var Data = ctx.MstSection.FirstOrDefault(u => u.SectionId == obj.SectionId);
                    Data.SectionCode = obj.SectionCode; Data.SectionName = obj.SectionName; Data.IsActive = obj.IsActive; Data.DivisionId = obj.DivisionId;
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
