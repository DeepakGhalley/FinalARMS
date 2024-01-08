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
    public class SlabBLL : ISlab
    {
        readonly tt_dbContext ctx = new tt_dbContext();
        public bool CheckExists(int id)
        {
            return ctx.MstSlab.Any(e => e.SlabId == id);
        }

        public Task Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteConfirmed(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<SlabVM> Details(int? id)
        {
            var data = (from a in ctx.MstSlab.Where(aa => aa.SlabId == id)
                        join b in ctx.MstBuildingUnitUseType on a.BuildingUnitUseTypeId equals b.BuildingUnitUseTypeId
                        join c in ctx.MstBuildingUnitClass on a.BuildingUnitClassId equals c.BuildingUnitClassId

                        select new SlabVM
                        {
                            SlabId = a.SlabId,
                            TaxId = a.TaxId,
                            SlabName = a.SlabName,
                            Define1 = a.Define1,
                            Define2 = a.Define2,
                            SlabStart = a.SlabStart,
                            SlabEnd = a.SlabEnd,
                            BuildingUnitUseTypeId = a.BuildingUnitUseTypeId,
                            BuildingUnitUseType = b.BuildingUnitUseType,
                            BuildingUnitClassId = a.BuildingUnitClassId,
                            BuildingUnitUnitClass = c.BuildingUnitClassName,
                            IsActive = a.IsActive,
                            CreatedBy = a.CreatedBy,
                            CreatedOn = a.CreatedOn,
                            ModifiedBy = a.ModifiedBy,
                            ModifiedOn = a.ModifiedOn

                        });

            return await data.FirstOrDefaultAsync();
        }

        public IList<SlabVM> GetAll()
        {
            var data = (from x in ctx.MstSlab
                       // join b in ctx.MstBuildingUnitUseType on x.BuildingUnitUseTypeId equals b.BuildingUnitUseTypeId
                       // join c in ctx.MstBuildingUnitClass on x.BuildingUnitClassId equals c.BuildingUnitClassId
                        join d in ctx.MstTaxMaster on x.TaxId equals d.TaxId
                        //join e in ctx.MstTaxTypeClassification on d.TaxTypeClassificationId equals e.TaxTypeClassificationId
                        select new SlabVM
                        {
                            SlabId = x.SlabId,
                            TaxId = x.TaxId,
                            TaxName = d.TaxName,
                            //TaxTypeClassificationId = e.TaxTypeClassificationId,
                            SlabName = x.SlabName,
                            Define1 = x.Define1,
                            Define2 = x.Define2,
                            SlabStart = x.SlabStart,
                            SlabEnd = x.SlabEnd,
                            BuildingUnitUseTypeId = x.BuildingUnitUseTypeId,
                            //BuildingUnitUseType = b.BuildingUnitUseType,
                            BuildingUnitClassId = x.BuildingUnitClassId,
                           // BuildingUnitUnitClass = c.BuildingUnitClassName,
                            IsActive = x.IsActive,
                            CreatedBy = x.CreatedBy,
                            CreatedOn = x.CreatedOn,
                            ModifiedBy = x.ModifiedBy,
                            ModifiedOn = x.ModifiedOn
                        });
            return data.ToList();
        }

        public int Save(SlabVM obj)
        {
            try
            {
                using TransactionScope s = new TransactionScope();
                int ipk=0;
                if (obj.TransactionTypeID == 1)
                {
                    var entity = new MstSlab
                    {
                        SlabId = obj.SlabId,
                        TaxId = obj.TaxId,
                        SlabName = obj.SlabName,
                        //Define1 = obj.Define1,
                        //Define2 = obj.Define2,
                        //SlabStart = obj.SlabStart,
                        //SlabEnd = obj.SlabEnd,
                        //BuildingUnitUseTypeId = obj.BuildingUnitUseTypeId,
                        //BuildingUnitClassId = obj.BuildingUnitClassId,
                        IsActive = obj.IsActive,
                        CreatedBy = obj.CreatedBy,
                        CreatedOn = Convert.ToDateTime(obj.CreatedOn)
                    };
                    ctx.MstSlab.Add(entity);
                    ctx.SaveChanges();
                    s.Complete();
                    s.Dispose();
                    ipk = entity.SlabId;
                   
                }
                else if (obj.TransactionTypeID == 2)
                {
                    var entity = new MstSlab
                    {
                        SlabId = obj.SlabId,
                        TaxId = obj.TaxId,
                        SlabName = obj.SlabName,
                        //Define1 = obj.Define1,
                        //Define2 = obj.Define2,
                        //SlabStart = obj.SlabStart,
                        //SlabEnd = obj.SlabEnd,
                        //BuildingUnitUseTypeId = obj.BuildingUnitUseTypeId,
                        //BuildingUnitClassId = obj.BuildingUnitClassId,
                        IsActive = obj.IsActive,
                        CreatedBy = obj.CreatedBy,
                        CreatedOn = Convert.ToDateTime(obj.CreatedOn)
                    };
                    ctx.MstSlab.Add(entity);
                    ctx.SaveChanges();
                    s.Complete();
                    s.Dispose();
                    ipk = entity.SlabId;                   
                }
                else if (obj.TransactionTypeID == 19)
                {
                    var entity = new MstSlab
                    {
                        SlabId = obj.SlabId,
                        TaxId = obj.TaxId,
                        SlabName = obj.SlabName,
                        //Define1 = obj.Define1,
                        //Define2 = obj.Define2,
                        //SlabStart = obj.SlabStart,
                        //SlabEnd = obj.SlabEnd,
                        BuildingUnitUseTypeId = obj.BuildingUnitUseTypeId,
                        //BuildingUnitClassId = obj.BuildingUnitClassId,
                        IsActive = obj.IsActive,
                        CreatedBy = obj.CreatedBy,
                        CreatedOn = Convert.ToDateTime(obj.CreatedOn)
                    };
                    ctx.MstSlab.Add(entity);
                    ctx.SaveChanges();
                    s.Complete();
                    s.Dispose();
                    ipk = entity.SlabId;
                }
                else if (obj.TransactionTypeID == 20)
                {
                    var entity = new MstSlab
                    {
                        SlabId = obj.SlabId,
                        TaxId = obj.TaxId,
                        SlabName = obj.SlabName,
                        LandUseSubCategoryId = obj.LandUseSubCategoryId,
                        ConstructionTypeId = obj.ConstructionTypeId,

                        //Define1 = obj.Define1,
                        //Define2 = obj.Define2,
                        //SlabStart = obj.SlabStart,
                        //SlabEnd = obj.SlabEnd,
                        //BuildingUnitUseTypeId = obj.BuildingUnitUseTypeId,
                        //BuildingUnitClassId = obj.BuildingUnitClassId,
                        IsActive = obj.IsActive,
                        CreatedBy = obj.CreatedBy,
                        CreatedOn = Convert.ToDateTime(obj.CreatedOn)
                    };
                    ctx.MstSlab.Add(entity);
                    ctx.SaveChanges();
                    s.Complete();
                    s.Dispose();
                    ipk = entity.SlabId;
                }
                else // if (obj.TransactionTypeID == 2)
                {
                    var entity = new MstSlab
                    {
                        SlabId = obj.SlabId,
                        TaxId = obj.TaxId,
                        SlabName = obj.SlabName,
                        //Define1 = obj.Define1,
                        //Define2 = obj.Define2,
                        //SlabStart = obj.SlabStart,
                        //SlabEnd = obj.SlabEnd,
                        //BuildingUnitUseTypeId = obj.BuildingUnitUseTypeId,
                        //BuildingUnitClassId = obj.BuildingUnitClassId,
                        IsActive = obj.IsActive,
                        CreatedBy = obj.CreatedBy,
                        CreatedOn = Convert.ToDateTime(obj.CreatedOn)
                    };
                    ctx.MstSlab.Add(entity);
                    ctx.SaveChanges();
                    s.Complete();
                    s.Dispose();
                    ipk = entity.SlabId;
                }
                return ipk;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public int Update(SlabVM obj)
        {
            try
            {
                using (TransactionScope s = new TransactionScope())
                {
                    var Data = ctx.MstSlab.FirstOrDefault(u => u.SlabId == obj.SlabId);
                    Data.TaxId = obj.TaxId;
                    Data.SlabName = obj.SlabName;
                    Data.Define1 = obj.Define1;
                    Data.Define2 = obj.Define2;
                    Data.SlabStart = obj.SlabStart;
                    Data.SlabEnd = obj.SlabEnd;
                    Data.BuildingUnitUseTypeId = obj.BuildingUnitUseTypeId;
                    Data.BuildingUnitClassId = obj.BuildingUnitClassId;
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
        //public List<MstTransactionTypeTaxMap> fetchTAX(int id)
        //{
        //    var data = (from a in ctx.MstTransactionTypeTaxMap.Where(x=>x.TransactionTypeId == id)
        //                join b in ctx.MstTaxMaster on a.TaxId equals b.TaxId
        //                    //.Where(x => x.TaxTypeClassificationId == id)

        //                select new 
        //                {
        //                    TaxId = a.TaxId,
        //                    TaxName = b.TaxName

        //                });


        //    return data.ToList();
        //}
    }
}
