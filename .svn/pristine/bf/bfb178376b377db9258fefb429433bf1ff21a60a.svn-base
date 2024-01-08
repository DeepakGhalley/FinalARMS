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
    public class BuildingTypeBLL : IBuildingType
    {
        readonly tt_dbContext ctx = new tt_dbContext();
        public bool CheckExists(int id)
        {
            return ctx.MstBuildingType.Any(e => e.BuildingTypeId == id);
        }

        public async Task Delete(int? id)
        {
            var tblMstBuildingType = await ctx.MstBuildingType
           .FirstOrDefaultAsync(m => m.BuildingTypeId == id);
        }

        public async Task DeleteConfirmed(int id)
        {
            using (TransactionScope s = new TransactionScope())
            {
                var tblMstBuildingType = ctx.MstBuildingType.Find(id);
                ctx.MstBuildingType.Remove(tblMstBuildingType);
                ctx.SaveChanges();
                s.Complete();
                s.Dispose();

            }
        }

        public async Task<BuildingTypeModel> Details(int? id)
        {
            var data = (from a in ctx.MstBuildingType.Where(aa => aa.BuildingTypeId == id)
                        select new BuildingTypeModel
                        {
                            BuildingTypeId = a.BuildingTypeId,
                            BuildingType = a.BuildingType,
                            IsActive = a.IsActive,
                            CreatedBy = a.CreatedBy,
                            CreatedDate = a.CreatedOn,
                            ModifiedBy = a.ModifiedBy,
                            ModifiedDate = a.ModifiedOn

                        });

            return await data.FirstOrDefaultAsync();
        }

        public bool DuplicateCheckOnSave(string BuildingType)
        {
            return ctx.MstBuildingType.Any(e => e.BuildingType == BuildingType);
        }

        public bool DuplicateCheckOnUpdate(string BuildingType, int Id)
        {
            return ctx.MstBuildingType.Any(e => e.BuildingType == BuildingType && e.BuildingTypeId != Id);
        }

        public IList<BuildingTypeModel> GetAll()
        {
            var data = (from x in ctx.MstBuildingType
                        select new BuildingTypeModel
                        {
                            BuildingTypeId = x.BuildingTypeId,
                            BuildingType = x.BuildingType,
                            IsActive = x.IsActive,
                            CreatedBy = x.CreatedBy,
                            CreatedDate = x.CreatedOn,
                            ModifiedDate = x.ModifiedOn,
                            ModifiedBy = x.ModifiedBy,
                        });
            return data.ToList();
        }

        public int Save(BuildingTypeModel obj)
        {
            try
            {
                using (TransactionScope s = new TransactionScope())
                {
                    int ipk;
                    var entity = new MstBuildingType
                    {
                        BuildingTypeId = obj.BuildingTypeId,
                        BuildingType = obj.BuildingType,
                        IsActive = obj.IsActive,
                        CreatedBy = obj.CreatedBy,
                        CreatedOn = Convert.ToDateTime(obj.CreatedDate),
                    };
                    ctx.MstBuildingType.Add(entity);
                    ctx.SaveChanges();
                    s.Complete();
                    s.Dispose();
                    ipk = entity.BuildingTypeId;

                    return ipk;
                }
            }
            catch (System.Exception)
            {
                return 0;
            }
        }

        public int Update(BuildingTypeModel obj)
        {
            try
            {
                using (TransactionScope s = new TransactionScope())
                {
                    var Data = ctx.MstBuildingType.FirstOrDefault(u => u.BuildingTypeId == obj.BuildingTypeId);
                    Data.BuildingType = obj.BuildingType;  Data.IsActive = obj.IsActive;
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
