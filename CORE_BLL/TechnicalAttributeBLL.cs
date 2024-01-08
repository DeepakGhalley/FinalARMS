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
    public class TechnicalAttributeBLL : ITechnicalAttribute
    {
        readonly tt_dbContext ctx = new tt_dbContext();
        public bool CheckExists(int id)
        {
            return ctx.MstTechnicalAttribute.Any(e => e.TechnicalAttributeId == id); ;
        }

        public async Task Delete(int? id)
        {
            var MstTechnicalAttribute = await ctx.MstTechnicalAttribute
            .FirstOrDefaultAsync(m => m.TechnicalAttributeId == id);
        }

        public async Task DeleteConfirmed(int id)
        {
            using (TransactionScope s = new TransactionScope())
            {
                var MstTechnicalAttribute = ctx.MstTechnicalAttribute.Find(id);
                ctx.MstTechnicalAttribute.Remove(MstTechnicalAttribute);
                ctx.SaveChanges();
                s.Complete();
                s.Dispose();
            }
        }

        public async Task<TechnicalAttributeModel> Details(int? id)
        {
            var data = (from a in ctx.MstTechnicalAttribute.Where(aa => aa.TechnicalAttributeId == id)
                        select new TechnicalAttributeModel
                        {
                            TechnicalAttributeId = a.TechnicalAttributeId,
                            TechnicalAttribute = a.TechnicalAttribute,
                            TechnicalAttributeDescription = a.TechnicalAttributeDescription,
                            IsActive = a.IsActive,
                            CreatedBy = a.CreatedBy,
                            CreatedOn = a.CreatedOn,
                            ModifiedBy = a.ModifiedBy,
                            ModifiedOn = a.ModifiedOn,
                            ParentAttributeId = a.ParentAttributeId

                        });

            return await data.FirstOrDefaultAsync();

        }

        public bool DuplicateCheckOnSave(string TechnicalAttribute)
        {
            return ctx.MstTechnicalAttribute.Any(e => e.TechnicalAttribute == TechnicalAttribute);
        }

        public bool DuplicateCheckOnUpdate(string TechnicalAttribute, int Id, int ParentAttributeId)
        {
            return ctx.MstTechnicalAttribute.Any(e => e.TechnicalAttribute == TechnicalAttribute && e.TechnicalAttributeId != Id && e.ParentAttributeId == ParentAttributeId);
        }

        public IList<TechnicalAttributeModel> GetAll()
        {
            var data = (from x in ctx.MstTechnicalAttribute
                        join y in ctx.MstTertiaryAccountHead on x.ParentAttributeId equals y.TertiaryAccountHeadId
                        select new TechnicalAttributeModel
                        {
                            TechnicalAttributeId = x.TechnicalAttributeId,
                            TechnicalAttribute = x.TechnicalAttribute,
                            TechnicalAttributeDescription = x.TechnicalAttributeDescription,
                            ParentAttributeId
                            = x.ParentAttributeId,
                            TertiaryAccountHeadName = y.TertiaryAccountHeadName,
                            IsActive = x.IsActive,
                            CreatedBy = x.CreatedBy,
                            CreatedOn = x.CreatedOn,
                            ModifiedOn = x.ModifiedOn,
                            ModifiedBy = x.ModifiedBy,
                        });
            return data.ToList();
        }

        public int Save(TechnicalAttributeModel obj)
        {
            try
            {
                using TransactionScope s = new TransactionScope();
                int ipk;
                var entity = new MstTechnicalAttribute
                {
                    TechnicalAttributeId = obj.TechnicalAttributeId,
                    TechnicalAttribute = obj.TechnicalAttribute,
                    TechnicalAttributeDescription = obj.TechnicalAttributeDescription,
                    ParentAttributeId = obj.ParentAttributeId,
                    IsActive = obj.IsActive,
                    CreatedBy = obj.CreatedBy,
                    CreatedOn = Convert.ToDateTime(obj.CreatedOn),
                };
                ctx.MstTechnicalAttribute.Add(entity);
                ctx.SaveChanges();
                s.Complete();
                s.Dispose();
                ipk = entity.TechnicalAttributeId;

                return ipk;
            }
            catch (System.Exception)
            {
                return 0;
            }
        }

        public int Update(TechnicalAttributeModel obj)
        {

            try
            {
                using (TransactionScope s = new TransactionScope())
                {
                    var Data = ctx.MstTechnicalAttribute.FirstOrDefault(u => u.TechnicalAttributeId == obj.TechnicalAttributeId);
                    Data.TechnicalAttribute = obj.TechnicalAttribute; Data.TechnicalAttributeDescription = obj.TechnicalAttributeDescription;
                    Data.IsActive = obj.IsActive; Data.ParentAttributeId = obj.ParentAttributeId;
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
