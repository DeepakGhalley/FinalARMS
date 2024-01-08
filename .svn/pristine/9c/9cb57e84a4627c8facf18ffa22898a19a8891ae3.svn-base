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
    public class WaterConnectionTypesBLL : IWaterConnectionTypes
    {
        readonly tt_dbContext ctx = new tt_dbContext();

        public IList<WaterConnectionTypesModel> GetAll()
        {
            var data = (from x in ctx.MstWaterConnectionType
                        select new WaterConnectionTypesModel
                        {
                            WaterConnectionTypeId = x.WaterConnectionTypeId,
                            WaterConnectionType = x.WaterConnectionType,

                            IsActive = x.IsActive,
                            CreatedBy = x.CreatedBy,
                            CreatedOn = x.CreatedOn,
                            ModifiedOn = x.ModifiedOn,
                            ModifiedBy = x.ModifiedBy
                        });
            return data.ToList();

        }
        //public async Task<UserDTO> Details(int? id)
        //{


        //    var tblMstUser = ctx.TblMstUser

        //        .Include(t => t.Role)
        //        .Where(m => m.UserId == id);

        //    return await tblMstUser.FirstOrDefaultAsync();
        //}


        public async Task<WaterConnectionTypesModel> Details(int? id)
        {
            //var data1 = ctx.TblMstUser.Include(t => t.Role);
            var data = (from a in ctx.MstWaterConnectionType.Where(aa => aa.WaterConnectionTypeId == id)
                        select new WaterConnectionTypesModel
                        {
                            WaterConnectionTypeId = a.WaterConnectionTypeId,
                            WaterConnectionType = a.WaterConnectionType,
                            IsActive = a.IsActive,
                            CreatedBy = a.CreatedBy,
                            CreatedOn = a.CreatedOn,
                            ModifiedBy = a.ModifiedBy,
                            ModifiedOn = a.ModifiedOn

                        });

            return await data.FirstOrDefaultAsync();

        }
        //public async Task<IEnumerable<TblMstUser>> Details(int? id)
        //{


        //    var tblMstUser = ctx.TblMstUser

        //        .Include(t => t.Role)
        //        .Where(m => m.UserId == id);

        //    return await tblMstUser.ToListAsync();
        //}

        public int Save(WaterConnectionTypesModel obj)
        {
            try
            {
                using TransactionScope s = new TransactionScope();
                int ipk;
                var entity = new MstWaterConnectionType
                {
                    WaterConnectionTypeId = obj.WaterConnectionTypeId,
                    WaterConnectionType = obj.WaterConnectionType,
                    IsActive = obj.IsActive,
                    CreatedBy = obj.CreatedBy,
                    CreatedOn = Convert.ToDateTime(obj.CreatedOn),
                };
                ctx.MstWaterConnectionType.Add(entity);
                ctx.SaveChanges();
                s.Complete();
                s.Dispose();
                ipk = entity.WaterConnectionTypeId;

                return ipk;
            }
            catch (System.Exception)
            {
                return 0;
            }
        }

        public int Update(WaterConnectionTypesModel obj)
        {
            try
            {
                using (TransactionScope s = new TransactionScope())
                {
                    var Data = ctx.MstWaterConnectionType.FirstOrDefault(u => u.WaterConnectionTypeId == obj.WaterConnectionTypeId);
                    Data.WaterConnectionType = obj.WaterConnectionType; Data.IsActive = obj.IsActive;
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
            return ctx.MstWaterConnectionType.Any(e => e.WaterConnectionTypeId == id);
        }

        public async Task DeleteConfirmed(int id)
        {
            using (TransactionScope s = new TransactionScope())
            {
                var MstWaterConnectionType = ctx.MstWaterConnectionType.Find(id);
                ctx.MstWaterConnectionType.Remove(MstWaterConnectionType);
                ctx.SaveChanges();
                s.Complete();
                s.Dispose();
                //var user = ctx.TblMstUser.FirstOrDefault(u => u.UserId == obj.UserId);
                //user.UserName = obj.UserName; user.IsActive = obj.IsActive;
                //user.ModifiedBy = obj.ModifiedBy; user.ModifiedOn = obj.ModifiedOn;
                //ctx.SaveChanges();
                //s.Complete();

            }
        }

        public async Task Delete(int? id)
        {
            var MstWaterConnectionType = await ctx.MstWaterConnectionType
                           .FirstOrDefaultAsync(m => m.WaterConnectionTypeId == id);
        }
        public bool DuplicateCheckOnSave(string WaterConnectionType)
        {
            return ctx.MstWaterConnectionType.Any(e => e.WaterConnectionType == WaterConnectionType);
        }
        public bool DuplicateCheckOnUpdate(string WaterConnectionType, int WaterConnectionTypeId)
        {
            return ctx.MstWaterConnectionType.Any(e => e.WaterConnectionType == WaterConnectionType && e.WaterConnectionTypeId != WaterConnectionTypeId);
        }
    }

}
