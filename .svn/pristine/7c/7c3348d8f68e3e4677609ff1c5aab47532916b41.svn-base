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
    public class ParentAttributeBLL : IParentAttribute
    {
        readonly tt_dbContext ctx = new tt_dbContext();
        public bool CheckExists(int id)
        {
            return ctx.MstParentAttribute.Any(e => e.ParentAttributeId == id);
        }

        public async Task Delete(int? id)
        {
            var mstParentAttribute = await ctx.MstParentAttribute
            .FirstOrDefaultAsync(m => m.ParentAttributeId == id);
        }

        public async Task DeleteConfirmed(int id)
        {
            using (TransactionScope s = new TransactionScope())
            {
                var mstParentAttribute = ctx.MstParentAttribute.Find(id);
                ctx.MstParentAttribute.Remove(mstParentAttribute);
                ctx.SaveChanges();
                s.Complete();
                s.Dispose();

            }
        }

        public async Task<ParentAttributeModel> Details(int? id)
        {
            var data = (from a in ctx.MstParentAttribute.Where(aa => aa.ParentAttributeId == id)
                        select new ParentAttributeModel
                        {
                            ParentAttributeId = a.ParentAttributeId,
                            ParentAttribute = a.ParentAttribute,
                            ParentAttributeDescription = a.ParentAttributeDescription,
                          TertiaryAccountHeadId=a.TertiaryAccountHeadId,
                            IsActive = a.IsActive,
                            CreatedBy = a.CreatedBy,
                            CreatedOn = a.CreatedOn,
                            ModifiedBy = a.ModifiedBy,
                            ModifiedOn = a.ModifiedOn

                        });

            return await data.FirstOrDefaultAsync();
        }

        public bool DuplicateCheckOnSave(string ParentAttribute)
        {
            return ctx.MstParentAttribute.Any(e => e.ParentAttribute == ParentAttribute);
        }
        public bool DuplicateCheckOnUpdate(string ParentAttribute, int TertiaryAccountHeadId, int Id)
        {
            return ctx.MstParentAttribute.Any(e => e.ParentAttribute == ParentAttribute && e.TertiaryAccountHeadId == TertiaryAccountHeadId && e.ParentAttributeId != Id);
        }

        public IList<ParentAttributeModel> GetAll()
        {
            var data = (from x in ctx.MstParentAttribute
                        join y in ctx.MstTertiaryAccountHead on x.TertiaryAccountHeadId equals y.TertiaryAccountHeadId
                        select new ParentAttributeModel
                        {
                            ParentAttributeId = x.ParentAttributeId,
                            ParentAttribute= x.ParentAttribute,
                            ParentAttributeDescription = x.ParentAttributeDescription,
                            TertiaryAccountHeadId = x.TertiaryAccountHeadId,
                            TertiaryAccountHeadNames = y.TertiaryAccountHeadName,
                            IsActive = x.IsActive,
                            CreatedBy = x.CreatedBy,
                            CreatedOn = x.CreatedOn,
                            ModifiedBy = x.ModifiedBy,
                            ModifiedOn = x.ModifiedOn

                        });
            return data.ToList();
        }

        public int SaveParentArribute(ParentAttributeModel obj)
        {
            try
            {
                using (TransactionScope s = new TransactionScope())
                {
                    int ipk;
                    var entity = new MstParentAttribute
                    {
                        ParentAttributeId = obj.ParentAttributeId,
                        ParentAttribute = obj.ParentAttribute,
                        ParentAttributeDescription = obj.ParentAttributeDescription,
                        TertiaryAccountHeadId = obj.TertiaryAccountHeadId,
                        IsActive = obj.IsActive,
                        CreatedBy = obj.CreatedBy,
                        CreatedOn = Convert.ToDateTime(obj.CreatedOn),
                    };
                    ctx.MstParentAttribute.Add(entity);
                    ctx.SaveChanges();
                    s.Complete();
                    s.Dispose();
                    ipk = entity.ParentAttributeId;

                    return ipk;
                }
            }
            catch (System.Exception)
            {
                return 0;
            }
        }

        public int UpdateParentArribute(ParentAttributeModel obj)
        {
            try
            {
                using (TransactionScope s = new TransactionScope())
                {
                    var Data = ctx.MstParentAttribute.FirstOrDefault(u => u.ParentAttributeId == obj.ParentAttributeId);
                    Data.ParentAttribute = obj.ParentAttribute; Data.ParentAttributeDescription = obj.ParentAttributeDescription; Data.TertiaryAccountHeadId = obj.TertiaryAccountHeadId; Data.IsActive = obj.IsActive;
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
