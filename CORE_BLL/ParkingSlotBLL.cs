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
    public class ParkingSlotBLL : IParkingSlot
    {
        readonly tt_dbContext ctx = new tt_dbContext();

        public IList<ParkingSlotModel> GetAll()
        {
            var data = (from x in ctx.MstParkingSlot
                        select new ParkingSlotModel
                        {
                          ParkingSlotId = x.ParkingSlotId,
                            ParkingSlotName = x.ParkingSlotName,
                            ParkingSlotDescription = x.ParkingSlotDescription,
                            IsActive = x.IsActive,
                            CreatedBy = x.CreatedBy,
                            CreatedOn = x.CreatedOn,
                            ModifiedOn = x.ModifiedOn,
                            ModifiedBy = x.ModifiedBy
                        });
            return data.ToList();

        }
        public async Task<ParkingSlotModel> Details(int? id)
        {
            var data = (from a in ctx.MstParkingSlot.Where(aa => aa.ParkingSlotId == id)
                        select new ParkingSlotModel
                        {
                            ParkingSlotId = a.ParkingSlotId,
                            ParkingSlotName = a.ParkingSlotName,
                            ParkingSlotDescription = a.ParkingSlotDescription,
                            IsActive = a.IsActive,
                            CreatedBy = a.CreatedBy,
                            CreatedOn = a.CreatedOn,
                            ModifiedBy = a.ModifiedBy,
                            ModifiedOn = a.ModifiedOn

                        });

            return await data.FirstOrDefaultAsync();

        }
        public int Save(ParkingSlotModel obj)
        {
            try
            {
                using TransactionScope s = new TransactionScope();
                int ipk;
                var entity = new MstParkingSlot
                {
                    ParkingSlotId = obj.ParkingSlotId,
                    ParkingSlotName = obj.ParkingSlotName,
                    ParkingSlotDescription = obj.ParkingSlotDescription,
                    IsActive = obj.IsActive,
                    CreatedBy = obj.CreatedBy,
                    CreatedOn = Convert.ToDateTime(obj.CreatedOn),
                };
                ctx.MstParkingSlot.Add(entity);
                ctx.SaveChanges();
                s.Complete();
                s.Dispose();
                ipk = entity.ParkingSlotId;

                return ipk;
            }
            catch (System.Exception)
            {
                return 0;
            }
        }

        public int Update(ParkingSlotModel obj)
        {
            try
            {
                using (TransactionScope s = new TransactionScope())
                {
                    var Data = ctx.MstParkingSlot.FirstOrDefault(u => u.ParkingSlotId == obj.ParkingSlotId);
                    Data.ParkingSlotName = obj.ParkingSlotName; Data.ParkingSlotDescription = obj.ParkingSlotDescription; Data.IsActive = obj.IsActive;
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
            return ctx.MstParkingSlot.Any(e => e.ParkingSlotId == id);
        }

        public async Task DeleteConfirmed(int id)
        {
            using (TransactionScope s = new TransactionScope())
            {
                var MstParkingSlot = ctx.MstParkingSlot.Find(id);
                ctx.MstParkingSlot.Remove(MstParkingSlot);
                ctx.SaveChanges();
                s.Complete();
                s.Dispose();

            }
        }

        public async Task Delete(int? id)
        {
            var MstParkingSlot = await ctx.MstParkingSlot
                           .FirstOrDefaultAsync(m => m.ParkingSlotId == id);
        }
        public bool DuplicateCheckOnSave(string ParkingSlotName)
        {
            return ctx.MstParkingSlot.Any(e => e.ParkingSlotName == ParkingSlotName);
        }
        public bool DuplicateCheckOnUpdate(string ParkingSlotName, int ParkingSlotId)
        {
            return ctx.MstParkingSlot.Any(e => e.ParkingSlotName == ParkingSlotName && e.ParkingSlotId != ParkingSlotId);
        }

    }
}

