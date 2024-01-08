using CORE_BOL;
using CORE_BOL.Entities;
using CORE_DLL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace CORE_BLL
{
    public class ParkingZoneBLL : IParkingZone
    {
        readonly tt_dbContext ctx = new tt_dbContext();
        public bool CheckExists(int id)
        {
            return ctx.MstParkingZone.Any(e => e.ParkingZoneId == id);
        }

        public Task Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteConfirmed(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ParkingZoneVM> Details(int? id)
        {
            var data = (from a in ctx.MstParkingZone.Where(aa => aa.ParkingZoneId == id)
                        select new ParkingZoneVM
                        {
                            ParkingZoneId = a.ParkingZoneId,
                            ParkingzoneName = a.ParkingzoneName,
                            ParkingzoneDesc = a.ParkingzoneDesc,
                            IsActive = a.IsActive,
                            CreatedBy = a.CreatedBy,
                            CreatedOn = a.CreatedOn,
                            ModifiedBy = a.ModifiedBy,
                            ModifiedOn = a.ModifiedOn
                        });

            return await data.FirstOrDefaultAsync();
        }

        public IList<ParkingZoneVM> GetAll()
        {
            var data = (from x in ctx.MstParkingZone
                        select new ParkingZoneVM
                        {
                            ParkingZoneId = x.ParkingZoneId,
                            ParkingzoneName = x.ParkingzoneName,
                            ParkingzoneDesc = x.ParkingzoneDesc,
                            IsActive = x.IsActive,
                            CreatedBy = x.CreatedBy,
                            CreatedOn = x.CreatedOn,
                            ModifiedBy = x.ModifiedBy,
                            ModifiedOn = x.ModifiedOn
                        });
            return data.ToList();
        }

        public int Save(ParkingZoneVM obj)
        {
            try
            {
                using TransactionScope s = new TransactionScope();
                int ipk;
                var entity = new MstParkingZone
                {
                    ParkingzoneName = obj.ParkingzoneName,
                    ParkingzoneDesc = obj.ParkingzoneDesc,
                    IsActive = obj.IsActive,
                    CreatedBy = obj.CreatedBy,
                    CreatedOn = Convert.ToDateTime(obj.CreatedOn)
                };
                ctx.MstParkingZone.Add(entity);
                ctx.SaveChanges();
                s.Complete();
                s.Dispose();
                ipk = entity.ParkingZoneId;

                return ipk;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Update(ParkingZoneVM obj)
        {
            try
            {
                using (TransactionScope s = new TransactionScope())
                {
                    var Data = ctx.MstParkingZone.FirstOrDefault(u => u.ParkingZoneId == obj.ParkingZoneId);
                    Data.ParkingzoneName = obj.ParkingzoneName;
                    Data.ParkingzoneDesc = obj.ParkingzoneDesc;
                    Data.IsActive = obj.IsActive;
                    Data.ModifiedBy = obj.ModifiedBy;
                    Data.ModifiedOn = Convert.ToDateTime(obj.ModifiedOn);
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
