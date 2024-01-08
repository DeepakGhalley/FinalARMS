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
    public class BuldingColorBLL : IBuildingColor
    {
        readonly tt_dbContext ctx = new tt_dbContext();

        public IList<BuildingColourModel> GetAll()
        {
            var data = (from x in ctx.MstBuildingColour
                        select new BuildingColourModel
                        {
                            BuildingColourId = x.BuildingColourId,
                            BuildingColourType = x.BuildingColourType,
                            BuildingColourDescription = x.BuildingColourDescription,
                            IsActive = x.IsActive,
                            CreatedBy = x.CreatedBy,
                            CreatedOn = x.CreatedOn,
                            ModifiedOn = x.ModifiedOn,
                            ModifiedBy = x.ModifiedBy
                        });
            return data.ToList();

        }
        public async Task<BuildingColourModel> Details(int? id)
        {
            var data = (from a in ctx.MstBuildingColour.Where(aa => aa.BuildingColourId == id)
                        select new BuildingColourModel
                        {
                            BuildingColourId = a.BuildingColourId,
                            BuildingColourType = a.BuildingColourType,
                            BuildingColourDescription = a.BuildingColourDescription,
                            IsActive = a.IsActive,
                            CreatedBy = a.CreatedBy,
                            CreatedOn = a.CreatedOn,
                            ModifiedBy = a.ModifiedBy,
                            ModifiedOn = a.ModifiedOn

                        });

            return await data.FirstOrDefaultAsync();

        }
        public int Save(BuildingColourModel obj)
        {
            try
            {
                using TransactionScope s = new TransactionScope();
                int ipk;
                var entity = new MstBuildingColour
                {
                    BuildingColourId = obj.BuildingColourId,
                    BuildingColourType = obj.BuildingColourType,
                    BuildingColourDescription = obj.BuildingColourDescription,
                    IsActive = obj.IsActive,
                    CreatedBy = obj.CreatedBy,
                    CreatedOn = Convert.ToDateTime(obj.CreatedOn),
                };
                ctx.MstBuildingColour.Add(entity);
                ctx.SaveChanges();
                s.Complete();
                s.Dispose();
                ipk = entity.BuildingColourId;

                return ipk;
            }
            catch (System.Exception)
            {
                return 0;
            }
        }

        public int Update(BuildingColourModel obj)
        {
            try
            {
                using (TransactionScope s = new TransactionScope())
                {
                    var Data = ctx.MstBuildingColour.FirstOrDefault(u => u.BuildingColourId == obj.BuildingColourId);
                    Data.BuildingColourType = obj.BuildingColourType; Data.BuildingColourDescription = obj.BuildingColourDescription; Data.IsActive = obj.IsActive;
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
        public bool CheckExists(int id)
        {
            return ctx.MstBuildingColour.Any(e => e.BuildingColourId == id);
        }

        public async Task DeleteConfirmed(int id)
        {
            using (TransactionScope s = new TransactionScope())
            {
                var MstBuildingColour = ctx.MstBuildingColour.Find(id);
                ctx.MstBuildingColour.Remove(MstBuildingColour);
                ctx.SaveChanges();
                s.Complete();
                s.Dispose();

            }
        }

        public async Task Delete(int? id)
        {
            var MstInspectionType = await ctx.MstBuildingColour
                           .FirstOrDefaultAsync(m => m.BuildingColourId == id);
        }
        public bool DuplicateCheckOnSave(string BuildingColourType)
        {
            return ctx.MstBuildingColour.Any(e => e.BuildingColourType == BuildingColourType);
        }
        public bool DuplicateCheckOnUpdate(string BuildingColourType, int BuildingColourTypeId)
        {
            return ctx.MstBuildingColour.Any(e => e.BuildingColourType == BuildingColourType && e.BuildingColourId != BuildingColourTypeId);
        }
    }
}

