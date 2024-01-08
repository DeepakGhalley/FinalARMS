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
    public class TaxTypeClassificationBLL : ITaxTypeClassification
    {
        readonly tt_dbContext ctx = new tt_dbContext();
        public bool CheckExists(int id)
        {
            return ctx.MstTaxTypeClassification.Any(e => e.TaxTypeClassificationId == id);
        }

        public Task Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteConfirmed(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<TaxTypeClassificationVM> Details(int? id)
        {
            var data = (from a in ctx.MstTaxTypeClassification.Where(aa => aa.TaxTypeClassificationId == id)
                        select new TaxTypeClassificationVM
                        {
                            TaxTypeClassificationId = a.TaxTypeClassificationId,
                            TaxTypeClassification = a.TaxTypeClassificationName,
                            TaxTypeDescription = a.TaxTypeDescription,
                            IsActive = a.IsActive,
                            CreatedBy = a.CreatedBy,
                            CreatedOn = a.CreatedOn,
                            ModifiedBy = a.ModifiedBy,
                            ModifiedOn = a.ModifiedOn

                        });

            return await data.FirstOrDefaultAsync();
        }

        public bool DuplicateCheckOnSave(string TaxTypeClassification)
        {
            return ctx.MstTaxTypeClassification.Any(e => e.TaxTypeClassificationName == TaxTypeClassification);
        }

        public bool DuplicateCheckOnUpdate(string TaxTypeClassification, int Id)
        {
            return ctx.MstTaxTypeClassification.Any(e => e.TaxTypeClassificationName == TaxTypeClassification && e.TaxTypeClassificationId != Id);
        }

        public IList<TaxTypeClassificationVM> GetAll()
        {
            var data = (from x in ctx.MstTaxTypeClassification

                        select new TaxTypeClassificationVM
                        {
                            TaxTypeClassificationId = x.TaxTypeClassificationId,
                            TaxTypeClassification = x.TaxTypeClassificationName,
                            TaxTypeDescription = x.TaxTypeDescription,
                            IsActive = x.IsActive,
                            CreatedBy = x.CreatedBy,
                            CreatedOn = x.CreatedOn,
                            ModifiedBy = x.ModifiedBy,
                            ModifiedOn = x.ModifiedOn
                        });
            return data.ToList();
        }

        public int Save(TaxTypeClassificationVM obj)
        {
            try
            {
                using TransactionScope s = new TransactionScope();
                int ipk;
                var entity = new MstTaxTypeClassification
                {
                    TaxTypeClassificationId = obj.TaxTypeClassificationId,
                    TaxTypeClassificationName = obj.TaxTypeClassification,
                    TaxTypeDescription = obj.TaxTypeDescription,
                    IsActive = obj.IsActive,
                    CreatedBy = obj.CreatedBy,
                    CreatedOn = Convert.ToDateTime(obj.CreatedOn),
                };
                ctx.MstTaxTypeClassification.Add(entity);
                ctx.SaveChanges();
                s.Complete();
                s.Dispose();
                ipk = entity.TaxTypeClassificationId;

                return ipk;
            }
            catch (System.Exception)
            {
                return 0;
            }
        }

        public int Update(TaxTypeClassificationVM obj)
        {
            try
            {
                using (TransactionScope s = new TransactionScope())
                {
                    var Data = ctx.MstTaxTypeClassification.FirstOrDefault(u => u.TaxTypeClassificationId == obj.TaxTypeClassificationId);
                    Data.TaxTypeClassificationName = obj.TaxTypeClassification;
                    Data.TaxTypeDescription = obj.TaxTypeDescription;
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
