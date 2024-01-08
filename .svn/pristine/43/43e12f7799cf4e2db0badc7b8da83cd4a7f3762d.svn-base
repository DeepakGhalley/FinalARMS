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
    public class WaterLineTypesBLL : IWaterLineTypes
    {
        readonly tt_dbContext ctx = new tt_dbContext();

        public IList<WaterLineTypesModel> GetAll()
        {
            var data = (from x in ctx.MstWaterLineType
                        select new WaterLineTypesModel
                        {
                            WaterLineTypeId = x.WaterLineTypeId,
                            WaterLineType = x.WaterLineType,
                            
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


        public async Task<WaterLineTypesModel> Details(int? id)
        {
            //var data1 = ctx.TblMstUser.Include(t => t.Role);
            var data = (from a in ctx.MstWaterLineType.Where(aa => aa.WaterLineTypeId == id)
                        select new WaterLineTypesModel
                        {
                            WaterLineTypeId = a.WaterLineTypeId,
                            WaterLineType = a.WaterLineType,
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

        public int Save(WaterLineTypesModel obj)
        {
            try
            {
                using TransactionScope s = new TransactionScope();
                int ipk;
                var entity = new MstWaterLineType
                {
                    WaterLineTypeId = obj.WaterLineTypeId,
                    WaterLineType = obj.WaterLineType,
                    IsActive = obj.IsActive,
                    CreatedBy = obj.CreatedBy,
                    CreatedOn = Convert.ToDateTime(obj.CreatedOn),
                };
                ctx.MstWaterLineType.Add(entity);
                ctx.SaveChanges();
                s.Complete();
                s.Dispose();
                ipk = entity.WaterLineTypeId;

                return ipk;
            }
            catch (System.Exception)
            {
                return 0;
            }
        }

        public int Update(WaterLineTypesModel obj)
        {
            try
            {
                using (TransactionScope s = new TransactionScope())
                {
                    var Data = ctx.MstWaterLineType.FirstOrDefault(u => u.WaterLineTypeId == obj.WaterLineTypeId);
                    Data.WaterLineType = obj.WaterLineType;  Data.IsActive = obj.IsActive;
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
            return ctx.MstWaterLineType.Any(e => e.WaterLineTypeId == id);
        }

        public async Task DeleteConfirmed(int id)
        {
            using (TransactionScope s = new TransactionScope())
            {
                var MstWaterLineType = ctx.MstWaterLineType.Find(id);
                ctx.MstWaterLineType.Remove(MstWaterLineType);
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
            var MstWaterLineType = await ctx.MstWaterLineType
                           .FirstOrDefaultAsync(m => m.WaterLineTypeId == id);
        }
        public bool DuplicateCheckOnSave(string WaterLineType)
        {
            return ctx.MstWaterLineType.Any(e => e.WaterLineType == WaterLineType);
        }
        public bool DuplicateCheckOnUpdate(string WaterLineType, int WaterLineTypeId)
        {
            return ctx.MstWaterLineType.Any(e => e.WaterLineType == WaterLineType && e.WaterLineTypeId != WaterLineTypeId);
        }
    }
}
