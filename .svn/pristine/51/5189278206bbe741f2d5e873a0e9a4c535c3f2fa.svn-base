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
    public class TransactionTypeTaxMapBLL : ITransactionTypeTaxMap
    {
        readonly tt_dbContext ctx = new tt_dbContext();
        public bool CheckExists(int id)
        {
            return ctx.MstTransactionTypeTaxMap.Any(e => e.TransactionTypeTaxMapId == id);
        }

        public Task Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteConfirmed(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<TransactionTypeTaxMapVM> Details(int? id)
        {
            var data = (from a in ctx.MstTransactionTypeTaxMap.Where(aa => aa.TransactionTypeTaxMapId == id)
                        select new TransactionTypeTaxMapVM
                        {
                            TransactionTypeTaxMapId = a.TransactionTypeTaxMapId,
                            TransactionTypeId = a.TransactionTypeId,
                            TaxId = a.TaxId,
                            IsActive = a.IsActive,
                            CreatedBy = a.CreatedBy,
                            CreatedOn = a.CreatedOn,
                            ModifiedBy = a.ModifiedBy,
                            ModifiedOn = a.ModifiedOn

                        });

            return await data.FirstOrDefaultAsync();
        }

        public IList<TransactionTypeTaxMapVM> GetAll()
        {
            var data = (from x in ctx.MstTransactionTypeTaxMap
                        join a in ctx.MstTransactionType on x.TransactionTypeId equals a.TransactionTypeId
                        join b in ctx.MstTaxMaster on x.TaxId equals b.TaxId
                        orderby x.TransactionTypeId ascending
                        select new TransactionTypeTaxMapVM
                        {
                            TransactionTypeTaxMapId = x.TransactionTypeTaxMapId,
                            TransactionTypeId = x.TransactionTypeId,
                            TransactionTypeName = a.TransactionType,
                            TaxId = x.TaxId,
                            IsActive = x.IsActive,
                            CreatedBy = x.CreatedBy,
                            CreatedOn = x.CreatedOn,
                            ModifiedBy = x.ModifiedBy,
                            ModifiedOn = x.ModifiedOn,
                            TaxName=b.TaxName
                            
                        });
            return data.ToList();
        }

        public int Save(TransactionTypeTaxMapVM obj)
        {
            try
            {
                using TransactionScope s = new TransactionScope();
                int ipk;
                var entity = new MstTransactionTypeTaxMap
                {
                    TransactionTypeTaxMapId = obj.TransactionTypeTaxMapId,
                    TransactionTypeId = obj.TransactionTypeId,
                    TaxId = obj.TaxId,
                    IsActive = obj.IsActive,
                    CreatedBy = obj.CreatedBy,
                    CreatedOn = Convert.ToDateTime(obj.CreatedOn),
                };
                ctx.MstTransactionTypeTaxMap.Add(entity);
                ctx.SaveChanges();
                s.Complete();
                s.Dispose();
                ipk = entity.TransactionTypeTaxMapId;

                return ipk;
            }
            catch (System.Exception)
            {
                return 0;
            }
        }

        public int Update(TransactionTypeTaxMapVM obj)
        {
            try
            {
                using (TransactionScope s = new TransactionScope())
                {
                    var Data = ctx.MstTransactionTypeTaxMap.FirstOrDefault(u => u.TransactionTypeTaxMapId == obj.TransactionTypeTaxMapId);
                    Data.TransactionTypeId = obj.TransactionTypeId;
                    Data.TaxId = obj.TaxId;
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
        //public IEnumerable<CommonFunctionModel> SelectListTaxByTransactionType(int TransactionTypeId)
        //{
        //    try
        //    {
        //        List<CommonFunctionModel> SerLst = new List<CommonFunctionModel>();
        //        SerLst.Add(new CommonFunctionModel { Value = 0, Text = "-- Select One --" });
        //        using (tt_dbContext ctx = new tt_dbContext())
        //        {
        //            var result = (from a in ctx.MstTransactionTypeTaxMap.Where(x => x.TransactionTypeId == TransactionTypeId)//.OrderBy(x => x.ParentAttributeId)
        //                          join b in ctx.MstTaxMaster on a.TaxId equals b.TaxId
        //                          select new
        //                          {
        //                              TaxId = b.TaxId,
        //                              //AttributeName = a.AttributeName,
        //                              TaxName = b.TaxName
        //                          }
        //                          ).ToList();
        //            if (result.Count > 0)
        //            {
        //                foreach (var item in result)
        //                {
        //                    CommonFunctionModel smast = new CommonFunctionModel();
        //                    smast.Value = item.TaxId;
        //                    smast.Text = (item.TaxName);//+ "=>" + item.AttributeName);
        //                    SerLst.Add(smast);
        //                }
        //            }
        //            if (result.Count < 0 && result.Count == 0)
        //            {
        //                CommonFunctionModel smast = new CommonFunctionModel();
        //                SerLst.Add(smast);
        //            }
        //        }
        //        return SerLst.ToList();
        //    }
        //    catch
        //    {
        //        return null;
        //    }
        //}


        //public List<MstTaxMaster> PopulateTaxByTransactionType(int id)
        //{
        //    var data = (from a in ctx.MstTransactionTypeTaxMap.Where(x => x.TransactionTypeId == id)

        //                select new MstSecondaryAccountHead
        //                {
        //                    SecondaryAccountHeadId = a.SecondaryAccountHeadId,
        //                    SecondaryAccountHeadName = a.SecondaryAccountHeadName

        //                });


        //    return data.ToList();
        //}

    }
}
