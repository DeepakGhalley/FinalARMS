using CORE_DLL;
using System;
using System.Collections.Generic;
using CORE_BOL;
using CORE_BOL.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Transactions;
//using System.Security.Cryptography.X509Certificates;

namespace CORE_BLL
{
    public class AssetStatusBLL : IAssetStatus
    {
        readonly tt_dbContext ctx = new tt_dbContext();
        public async Task<IEnumerable<MstAssetStatus>> GetAll()
        {
            try
            {

                //var data = ctx.MstAssetStatus.Include(t => t.AssetStatusId);
                var data = ctx.MstAssetStatus;
                return await data.ToListAsync();
            }
            catch (Exception ex)
            {

                throw;
            }

        }


       

        public async Task<AssetStatusModel> Details(int? id)
        {
            try
            {
                var data = (from a in ctx.MstAssetStatus.Where(aa => aa.AssetStatusId == id)

                            select new AssetStatusModel
                            {
                                AssetStatusId = a.AssetStatusId,
                                AssetStatus = a.AssetStatus,
                                StatusDescription = a.StatusDescription,
                                IsActive = a.IsActive,
                                CreatedBy = a.CreatedBy,
                                CreatedOn = a.CreatedOn,
                                ModifiedBy = a.ModifiedBy,
                                ModifiedOn = a.ModifiedOn

                            });

                return await data.FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {

                throw;
            }

        }
        
        public int SaveAssetStatus(AssetStatusModel obj)
        {
            try
            {
                using (TransactionScope s = new TransactionScope())
                {
                    int ipk;
                    var entity = new MstAssetStatus
                    {
                        AssetStatusId = obj.AssetStatusId,
                        AssetStatus = obj.AssetStatus,
                        StatusDescription = obj.StatusDescription,                        
                        IsActive = true,
                        CreatedBy = obj.CreatedBy,
                        CreatedOn = Convert.ToDateTime(obj.CreatedOn),
                    };
                    ctx.MstAssetStatus.Add(entity);
                    ctx.SaveChanges();
                    s.Complete();
                    s.Dispose();
                    ipk = entity.AssetStatusId;

                    return ipk;
                }
            }
            //catch (System.Exception)
            //{
            //    return 0;
            //}
            catch (Exception ex)
            {

                throw;
            }
        }

        public int UpdateAssetStatus(AssetStatusModel obj)
        {
            try
            {


                using (TransactionScope s = new TransactionScope())
                {
                    var Data = ctx.MstAssetStatus.FirstOrDefault(u => u.AssetStatusId == obj.AssetStatusId);
                    Data.AssetStatus = obj.AssetStatus; Data.StatusDescription = obj.StatusDescription; Data.IsActive = obj.IsActive; 
                    Data.ModifiedBy = obj.ModifiedBy; Data.ModifiedOn = obj.ModifiedOn;
                    ctx.SaveChanges();
                    s.Complete();
                    s.Dispose();
                    return 1;
                         
                }

            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public bool CheckExists(int id)
        {
            try
            {
                return ctx.MstAssetStatus.Any(e => e.AssetStatusId == id);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task DeleteConfirmed(int id)
        {
            try
            {
                using (TransactionScope s = new TransactionScope())
                {
                    var mstAssetStatus = ctx.MstAssetStatus.Find(id);
                    ctx.MstAssetStatus.Remove(mstAssetStatus);
                    ctx.SaveChanges();
                    s.Complete();
                    s.Dispose();


                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public bool DuplicateCheckOnSave(string AssetStatus)
        {
            return ctx.MstAssetStatus.Any(e => e.AssetStatus == AssetStatus);
        }
        public bool DuplicateCheckOnUpdate(string AssetStatus, int Id)
        {
            return ctx.MstAssetStatus.Any(e => e.AssetStatus == AssetStatus && e.AssetStatusId != Id);
        }
        public async Task Delete(int? id)
        {

            try
            {
                var mstAssetStatus = await ctx.MstAssetStatus                               
                               .FirstOrDefaultAsync(m => m.AssetStatusId == id);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

       
    }
}
