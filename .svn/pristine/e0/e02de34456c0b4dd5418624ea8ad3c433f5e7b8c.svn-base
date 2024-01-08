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
    public class TaxMasterBLL : ITaxMaster
    {
        readonly tt_dbContext ctx = new tt_dbContext();

        public bool CheckExists(int id)
        {
            return ctx.MstTaxMaster.Any(e => e.TaxId == id);
        }

        public async Task Delete(int? id)
        {
            var MstTaxMaster = await ctx.MstTaxMaster
            .FirstOrDefaultAsync(m => m.TaxId == id);
        }

        public async Task DeleteConfirmed(int id)
        {
            using (TransactionScope s = new TransactionScope())
            {
                var MstTaxMaster = ctx.MstParentAttribute.Find(id);
                ctx.MstParentAttribute.Remove(MstTaxMaster);
                ctx.SaveChanges();
                s.Complete();
                s.Dispose();
            }
        }

        public async Task<TaxMasterVM> Details(int? id)
        {
            var data = (from a in ctx.MstTaxMaster.Where(aa => aa.TaxId == id)
                        select new TaxMasterVM
                        {
                            TaxId = a.TaxId,
                            DetailHeadId = a.DetailHeadId,
                            //TaxTypeClassificationId = a.TaxTypeClassificationId,
                            TaxName = a.TaxName,
                            IsActive = a.IsActive,
                            CreatedBy = a.CreatedBy,
                            CreatedOn = a.CreatedOn,
                            ModifiedBy = a.ModifiedBy,
                            ModifiedOn = a.ModifiedOn

                        });

            return await data.FirstOrDefaultAsync();
        }

        public IList<TaxMasterVM> GetAll()
        {
            var data = (from x in ctx.MstTaxMaster
                        join y in ctx.MstDetailHead on x.DetailHeadId equals y.DetailHeadId
                        //join z in ctx.MstTaxTypeClassification on x.TaxTypeClassificationId equals z.TaxTypeClassificationId
                       orderby// x.TaxTypeClassificationId ascending,
                       y.DetailHeadId ascending
                        select new TaxMasterVM
                        {
                            TaxId = x.TaxId,
                            DetailHeadId = x.DetailHeadId,
                            DetailHeadName = y.DetailHeadName,
                            //TaxTypeClassificationName = z.TaxTypeClassification,
                            TaxName = x.TaxName,
                            IsActive = x.IsActive,
                            CreatedBy = x.CreatedBy,
                            CreatedOn = x.CreatedOn,
                            ModifiedBy = x.ModifiedBy,
                            ModifiedOn = x.ModifiedOn
                        });
            return data.ToList();
        }

        public int Save(TaxMasterVM obj)
        {
            try
            {
                using TransactionScope s = new TransactionScope();
                int ipk;
                var entity = new MstTaxMaster
                {
                    TaxId = obj.TaxId,
                    DetailHeadId = obj.DetailHeadId,
                    //TaxTypeClassificationId = obj.TaxTypeClassificationId,
                    TaxName = obj.TaxName,
                    IsActive = obj.IsActive,
                    CreatedBy = obj.CreatedBy,
                    CreatedOn = Convert.ToDateTime(obj.CreatedOn),
                };
                ctx.MstTaxMaster.Add(entity);
                ctx.SaveChanges();
                s.Complete();
                s.Dispose();
                ipk = entity.TaxId;

                return ipk;
            }
            catch (System.Exception)
            {
                return 0;
            }
        }

        public int Update(TaxMasterVM obj)
        {
            try
            {
                using (TransactionScope s = new TransactionScope())
                {
                    var Data = ctx.MstTaxMaster.FirstOrDefault(u => u.TaxId == obj.TaxId);
                    Data.DetailHeadId = obj.DetailHeadId;
                    //Data.TaxTypeClassificationId = obj.TaxTypeClassificationId;
                    Data.TaxName = obj.TaxName; 
                    Data.IsActive = obj.IsActive;
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
        public bool DuplicateCheckOnSave(string TaxName)
        {
            return ctx.MstParentAttribute.Any(e => e.ParentAttribute == TaxName);
        }
        public bool DuplicateCheckOnUpdate(string TaxName, int DetailHeadId, int Id )
        {
            return ctx.MstTaxMaster.Any(e => e.TaxName == TaxName && e.DetailHeadId == DetailHeadId && e.TaxId != Id);
        }
    }
}
