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
    public class BuildingUnitClassBLL : IBuildingUnitClass
    {
        readonly tt_dbContext ctx = new tt_dbContext();
        public bool CheckExists(int id)
        {
            return ctx.MstBuildingUnitClass.Any(e => e.BuildingUnitClassId == id);
        }

        public async Task Delete(int? id)
        {
            var tblMstBuildingUnitClass = await ctx.MstBuildingUnitClass
           .FirstOrDefaultAsync(m => m.BuildingUnitClassId == id);
        }

        public async Task DeleteConfirmed(int id)
        {
            using (TransactionScope s = new TransactionScope())
            {
                var tblMstBuildingUnitClass = ctx.MstBuildingUnitClass.Find(id);
                ctx.MstBuildingUnitClass.Remove(tblMstBuildingUnitClass);
                ctx.SaveChanges();
                s.Complete();
                s.Dispose();

            }
        }

        public async Task<BuildingUnitClassModel> Details(int? id)
        {
            var data = (from a in ctx.MstBuildingUnitClass.Where(aa => aa.BuildingUnitClassId == id)
                        select new BuildingUnitClassModel
                        {
                            BuildingUnitClassId = a.BuildingUnitClassId,
                            BuildingUnitClassName = a.BuildingUnitClassName,
                            BuildingUnitClassDescription = a.BuildingUnitClassDescription,
                            IsActive = a.IsActive,
                            CreatedBy = a.CreatedBy,
                            CreatedDate = a.CreatedOn,
                            ModifiedBy = a.ModifiedBy,
                            ModifiedDate = a.ModifiedOn

                        });

            return await data.FirstOrDefaultAsync();
        }

        public bool DuplicateCheckOnSave(string BuildingUnitClass)
        {
            return ctx.MstBuildingUnitClass.Any(e => e.BuildingUnitClassName == BuildingUnitClass);
        }

        public bool DuplicateCheckOnUpdate(string BuildingUnitClass, int Id)
        {
            return ctx.MstBuildingUnitClass.Any(e => e.BuildingUnitClassName == BuildingUnitClass && e.BuildingUnitClassId != Id);
        }

        public IList<BuildingUnitClassModel> GetAll()
        {
            var data = (from x in ctx.MstBuildingUnitClass
                        select new BuildingUnitClassModel
                        {
                            BuildingUnitClassId = x.BuildingUnitClassId,
                            BuildingUnitClassName = x.BuildingUnitClassName,
                            BuildingUnitClassDescription = x.BuildingUnitClassDescription,
                            IsActive = x.IsActive,
                            CreatedBy = x.CreatedBy,
                            CreatedDate = x.CreatedOn,
                            ModifiedDate = x.ModifiedOn,
                            ModifiedBy = x.ModifiedBy,
                        });
            return data.ToList();
        }

        public int Save(BuildingUnitClassModel obj)
        {
            try
            {
                using (TransactionScope s = new TransactionScope())
                {
                    int ipk;
                    var entity = new MstBuildingUnitClass
                    {
                        BuildingUnitClassId = obj.BuildingUnitClassId,
                        BuildingUnitClassName = obj.BuildingUnitClassName,
                        BuildingUnitClassDescription = obj.BuildingUnitClassDescription,
                        IsActive = obj.IsActive,
                        CreatedBy = obj.CreatedBy,
                        CreatedOn = Convert.ToDateTime(obj.CreatedDate),
                    };
                    ctx.MstBuildingUnitClass.Add(entity);
                    ctx.SaveChanges();
                    s.Complete();
                    s.Dispose();
                    ipk = entity.BuildingUnitClassId;

                    return ipk;
                }
            }
            catch (System.Exception)
            {
                return 0;
            }
        }

        public int Update(BuildingUnitClassModel obj)
        {
            try
            {
                using (TransactionScope s = new TransactionScope())
                {
                    var Data = ctx.MstBuildingUnitClass.FirstOrDefault(u => u.BuildingUnitClassId == obj.BuildingUnitClassId);
                    Data.BuildingUnitClassName = obj.BuildingUnitClassName; Data.BuildingUnitClassDescription = obj.BuildingUnitClassDescription; Data.IsActive = obj.IsActive;
                    Data.ModifiedBy = obj.ModifiedBy; Data.ModifiedOn = obj.ModifiedDate;
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
