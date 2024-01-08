using CORE_DLL;
using System;
using System.Collections.Generic;
using CORE_BOL;
using CORE_BOL.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Transactions;

namespace CORE_BLL
{
    public class BuildingUnitUseTypeBLL : IBuildingUnitUseType
    {
        readonly tt_dbContext ctx = new tt_dbContext();

        public bool CheckExists(int id)
        {
            return ctx.MstBuildingUnitUseType.Any(e => e.BuildingUnitUseTypeId == id);
        }

        public async Task Delete(int? id)
        {
            var MstBuildingUnitUseType = await ctx.MstBuildingUnitUseType
                                      .FirstOrDefaultAsync(m => m.BuildingUnitUseTypeId == id);
        }

        public async Task DeleteConfirmed(int id)
        {
            using (TransactionScope s = new TransactionScope())
            {
                var MstBuildingUnitUseType = ctx.MstBuildingUnitUseType.Find(id);
                ctx.MstBuildingUnitUseType.Remove(MstBuildingUnitUseType);
                ctx.SaveChanges();
                s.Complete();
                s.Dispose();

            }
        }

        public async Task<BuildingUnitUseTypeModel> Details(int? id)
        {
            var data = (from a in ctx.MstBuildingUnitUseType.Where(aa => aa.BuildingUnitUseTypeId == id)
                        select new BuildingUnitUseTypeModel
                        {
                            BuildingUnitUseTypeId = a.BuildingUnitUseTypeId,
                            BuildingUnitUseType = a.BuildingUnitUseType,
                            BuildingUnitUseTypeDescription = a.BuildingUnitUseTypeDescription,
                            IsActive = a.IsActive,
                            CreatedBy = a.CreatedBy,
                            CreatedOn = a.CreatedOn,
                            ModifiedBy = a.ModifiedBy,
                            ModifiedOn = a.ModifiedOn

                        });

            return await data.FirstOrDefaultAsync();
        }

        public bool DuplicateCheckOnSave(string BuildingUnitUseType)
        {
            return ctx.MstBuildingUnitUseType.Any(e => e.BuildingUnitUseType == BuildingUnitUseType);
        }

        public bool DuplicateCheckOnUpdate(string BuildingUnitUseType, int BuildingUnitUseTypeId)
        {
            return ctx.MstBuildingUnitUseType.Any(e => e.BuildingUnitUseType == BuildingUnitUseType && e.BuildingUnitUseTypeId != BuildingUnitUseTypeId);
        }

        public IList<BuildingUnitUseTypeModel> GetAll()
        {
            var data = (from x in ctx.MstBuildingUnitUseType
                        select new BuildingUnitUseTypeModel
                        {
                            BuildingUnitUseTypeId = x.BuildingUnitUseTypeId,
                            BuildingUnitUseType = x.BuildingUnitUseType,
                            BuildingUnitUseTypeDescription = x.BuildingUnitUseTypeDescription,
                            IsActive = x.IsActive,
                            CreatedBy = x.CreatedBy,
                            CreatedOn = x.CreatedOn,
                            ModifiedOn = x.ModifiedOn,
                            ModifiedBy = x.ModifiedBy
                        });
            return data.ToList();
        }

        public int Save(BuildingUnitUseTypeModel obj)
        {
            try
            {
                using TransactionScope s = new TransactionScope();
                int ipk;
                var entity = new MstBuildingUnitUseType
                {
                    BuildingUnitUseTypeId = obj.BuildingUnitUseTypeId,
                    BuildingUnitUseType = obj.BuildingUnitUseType,
                    BuildingUnitUseTypeDescription = obj.BuildingUnitUseTypeDescription,
                    IsActive = obj.IsActive,
                    CreatedBy = obj.CreatedBy,
                    CreatedOn = Convert.ToDateTime(obj.CreatedOn),
                };
                ctx.MstBuildingUnitUseType.Add(entity);
                ctx.SaveChanges();
                s.Complete();
                s.Dispose();
                ipk = entity.BuildingUnitUseTypeId;

                return ipk;
            }
            catch (System.Exception)
            {
                return 0;
            }
        }

        public int Update(BuildingUnitUseTypeModel obj)
        {
            try
            {
                using (TransactionScope s = new TransactionScope())
                {
                    var Data = ctx.MstBuildingUnitUseType.FirstOrDefault(u => u.BuildingUnitUseTypeId == obj.BuildingUnitUseTypeId);
                    Data.BuildingUnitUseType = obj.BuildingUnitUseType; Data.BuildingUnitUseTypeDescription = obj.BuildingUnitUseTypeDescription; Data.IsActive = obj.IsActive;
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
