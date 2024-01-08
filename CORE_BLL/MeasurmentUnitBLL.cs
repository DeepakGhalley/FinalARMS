using CORE_BOL;
using CORE_BOL.Entities;
using CORE_DLL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace CORE_BLL
{
    public class MeasurmentUnitBLL : IMeasurmentUnit
    {
        readonly tt_dbContext ctx = new tt_dbContext();
        public bool CheckExists(int id)
        {
            return ctx.MstMeasurementUnit.Any(e => e.MeasurementUnitId == id);
        }

        public async Task Delete(int? id)
        {
            var mstMeasurmentUnit = await ctx.MstMeasurementUnit
            .FirstOrDefaultAsync(m => m.MeasurementUnitId == id);
        }

        public async Task DeleteConfirmed(int id)
        {
            using (TransactionScope s = new TransactionScope())
            {
                var mstMeasurmentUnit = ctx.MstMeasurementUnit.Find(id);
                ctx.MstMeasurementUnit.Remove(mstMeasurmentUnit);
                ctx.SaveChanges();
                s.Complete();
                s.Dispose();

            }
        }

        public async Task<MeasurementUnitModel> Details(int? id)
        {
            var data = (from a in ctx.MstMeasurementUnit.Where(aa => aa.MeasurementUnitId == id)
                        select new MeasurementUnitModel
                        {
                            MeasurementUnitId = a.MeasurementUnitId,
                            MeasurementUnit = a.MeasurementUnit,
                            MeasurementUnitDescription = a.MeasurementUnitDescription,
                            MeasurementUnitSymbol = a.MeasurementUnitSymbol,
                            IsActive = a.IsActive,
                            CreatedBy = a.CreatedBy,
                            CreatedOn = a.CreatedOn,
                            ModifiedBy = a.ModifiedBy,
                            ModifiedOn = a.ModifiedOn

                        });

            return await data.FirstOrDefaultAsync();
        }

        //public bool DuplicateCheckOnSave(string Symbol)
        //{
        //    return ctx.MstMeasurementUnit.Any(e => e.MeasurementUnitSymbol == Symbol);
        //}

        //public bool DuplicateCheckOnUpdate(string Symbol, int Id)
        //{
        //    return ctx.MstMeasurementUnit.Any(e => e.MeasurementUnitSymbol == Symbol && e.MeasurementUnitId != Id);
        //}

        public IList<MeasurementUnitModel> GetAll()
        {
                var data = (from x in ctx.MstMeasurementUnit
                        select new MeasurementUnitModel
                        {
                            
                            MeasurementUnitId = x.MeasurementUnitId,
                            MeasurementUnit = x.MeasurementUnit,
                            MeasurementUnitDescription = x.MeasurementUnitDescription,
                            MeasurementUnitSymbol = x.MeasurementUnitSymbol,
                            IsActive = x.IsActive,
                            CreatedBy = x.CreatedBy,
                            CreatedOn = x.CreatedOn,
                            ModifiedOn = x.ModifiedOn,
                            ModifiedBy = x.ModifiedBy,
                        });
            return data.ToList();
       
        }

        public int SaveMeasurmentUnit(MeasurementUnitModel obj)
        {
            try
            {
                using (TransactionScope s = new TransactionScope())
                {
                    int ipk;
                    var entity = new MstMeasurementUnit
                    {
                        MeasurementUnitId = obj.MeasurementUnitId,
                        MeasurementUnit = obj.MeasurementUnit,
                        MeasurementUnitDescription = obj.MeasurementUnitDescription,
                        MeasurementUnitSymbol = obj.MeasurementUnitSymbol,
                        IsActive = obj.IsActive,
                        CreatedBy = obj.CreatedBy,
                        CreatedOn = Convert.ToDateTime(obj.CreatedOn),
                    };
                    ctx.MstMeasurementUnit.Add(entity);
                    ctx.SaveChanges();
                    s.Complete();
                    s.Dispose();
                    ipk = entity.MeasurementUnitId;

                    return ipk;
                }
            }
            catch (System.Exception)
            {
                return 0;
            }
        }

  

        public int UpdateMeasurmentUnit(MeasurementUnitModel obj)
        {
            try
            {
                using (TransactionScope s = new TransactionScope())
                {
                    var Data = ctx.MstMeasurementUnit.FirstOrDefault(u => u.MeasurementUnitId == obj.MeasurementUnitId);
                    Data.MeasurementUnit = obj.MeasurementUnit; Data.MeasurementUnitDescription = obj.MeasurementUnitDescription; Data.MeasurementUnitSymbol = obj.MeasurementUnitSymbol; Data.IsActive = obj.IsActive;
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
