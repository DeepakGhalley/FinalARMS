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
    public class DetailTechnicalAttributeBLL : IDetailTechnicalAttribute
    {
        readonly tt_dbContext ctx = new tt_dbContext();
        public bool CheckExists(int id)
        {
            return ctx.MstDetailTechnicalAttribute.Any(e => e.DetailTechnicalAttributeId == id); ;
        }

        public async Task Delete(int? id)
        {
            var MstDetailTechnicalAttribute = await ctx.MstDetailTechnicalAttribute
            .FirstOrDefaultAsync(m => m.DetailTechnicalAttributeId == id);
        }

        public async Task DeleteConfirmed(int id)
        {
            using (TransactionScope s = new TransactionScope())
            {
                var MstDetailTechnicalAttribute = ctx.MstDetailTechnicalAttribute.Find(id);
                ctx.MstDetailTechnicalAttribute.Remove(MstDetailTechnicalAttribute);
                ctx.SaveChanges();
                s.Complete();
                s.Dispose();
            }
        }

        public async Task<DetailTechnicalAttributeModel> Details(int? id)
        {
            var data = (from a in ctx.MstDetailTechnicalAttribute.Where(aa => aa.DetailTechnicalAttributeId == id)
                        select new DetailTechnicalAttributeModel
                        {
                            DetailTechnicalAttributeId = a.DetailTechnicalAttributeId,
                            DetailTechnicalAttribute = a.DetailTechnicalAttribute,
                            DetailTechnicalAttributeDescription = a.DetailTechnicalAttributeDescription,
                            IsActive = a.IsActive,
                            CreatedBy = a.CreatedBy,
                            CreatedOn = a.CreatedOn,
                            ModifiedBy = a.ModifiedBy,
                            ModifiedOn = a.ModifiedOn,
                            TechnicalAttributeId = a.TechnicalAttributeId

                        });

            return await data.FirstOrDefaultAsync();
        }

        public bool DuplicateCheckOnSave(string DetailTechnicalAttribute)
        {
            return ctx.MstDetailTechnicalAttribute.Any(e => e.DetailTechnicalAttribute == DetailTechnicalAttribute);
        }

        public bool DuplicateCheckOnUpdate(string DetailTechnicalAttribute, int Id, int TechnicalAttributeId)
        {
            return ctx.MstDetailTechnicalAttribute.Any(e => e.DetailTechnicalAttribute == DetailTechnicalAttribute && e.TechnicalAttributeId != Id && e.TechnicalAttributeId == TechnicalAttributeId);
        }

        public IList<DetailTechnicalAttributeModel> GetAll()
        {
            var data = (from x in ctx.MstDetailTechnicalAttribute
                        join y in ctx.MstTechnicalAttribute on x.TechnicalAttributeId equals y.TechnicalAttributeId
                        select new DetailTechnicalAttributeModel
                        {
                            DetailTechnicalAttributeId = x.DetailTechnicalAttributeId,
                            DetailTechnicalAttribute = x.DetailTechnicalAttribute,
                            DetailTechnicalAttributeDescription = x.DetailTechnicalAttributeDescription,
                            TechnicalAttributeId = x.TechnicalAttributeId,
                            TechnicalAttributeName = y.TechnicalAttribute,
                            IsActive = x.IsActive,
                            CreatedBy = x.CreatedBy,
                            CreatedOn = x.CreatedOn,
                            ModifiedOn = x.ModifiedOn,
                            ModifiedBy = x.ModifiedBy,
                        });
            return data.ToList();
        }

        public int Save(DetailTechnicalAttributeModel obj)
        {
            try
            {
                using TransactionScope s = new TransactionScope();
                int ipk;
                var entity = new MstDetailTechnicalAttribute
                {
                    DetailTechnicalAttributeId = obj.DetailTechnicalAttributeId,
                    DetailTechnicalAttribute = obj.DetailTechnicalAttribute,
                    DetailTechnicalAttributeDescription = obj.DetailTechnicalAttributeDescription,
                    TechnicalAttributeId = obj.TechnicalAttributeId,
                    IsActive = obj.IsActive,
                    CreatedBy = obj.CreatedBy,
                    CreatedOn = Convert.ToDateTime(obj.CreatedOn),
                };
                ctx.MstDetailTechnicalAttribute.Add(entity);
                ctx.SaveChanges();
                s.Complete();
                s.Dispose();
                ipk = entity.DetailTechnicalAttributeId;

                return ipk;
            }
            catch (System.Exception)
            {
                return 0;
            }
        }

        public int Update(DetailTechnicalAttributeModel obj)
        {
            try
            {
                using (TransactionScope s = new TransactionScope())
                {
                    var Data = ctx.MstDetailTechnicalAttribute.FirstOrDefault(u => u.DetailTechnicalAttributeId == obj.DetailTechnicalAttributeId);
                    Data.DetailTechnicalAttribute = obj.DetailTechnicalAttribute; Data.DetailTechnicalAttributeDescription = obj.DetailTechnicalAttributeDescription;
                    Data.IsActive = obj.IsActive; Data.TechnicalAttributeId = obj.TechnicalAttributeId;
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
