using CORE_BOL;
using CORE_BOL.Entities;
using CORE_DLL;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace CORE_BLL
{
    public class LogoUploadBLL : ILogoUpload
    {
        readonly tt_dbContext ctx = new tt_dbContext();

        public bool CheckExists(int id)
        {
            return ctx.MstLogoUpload.Any(e => e.LogoId == id);
        }

        public Task Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteConfirmed(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<LogoUploadModel> Details(int? id)
        {
            var data = (from a in ctx.MstLogoUpload.Where(aa => aa.LogoId == id)
                        select new LogoUploadModel
                        {
                            LogoId = a.LogoId,
                            LogoName = a.LogoName,
                            LogoPath = a.LogoPath,
                            IsActive = a.IsActive,
                            CreatedBy = a.CreatedBy,
                            ModifiedBy = a.ModifiedBy
                        });

            return await data.FirstOrDefaultAsync();
        }

        public IList<LogoUploadModel> GetAll()
        {
            var data = (from x in ctx.MstLogoUpload
                        select new LogoUploadModel
                        {
                            LogoId = x.LogoId,
                            LogoName = x.LogoName,
                            LogoPath = x.LogoPath,
                            IsActive = x.IsActive,
                            CreatedBy = x.CreatedBy,
                            ModifiedBy = x.ModifiedBy
                        });
            return data.ToList();
        }

        public int Save(LogoUploadModel obj, IFormFile SourceFile)
        {
            try
            {
                using TransactionScope s = new TransactionScope();
                int ipk;
                var entity = new MstLogoUpload
                {
                    LogoId = obj.LogoId,
                    LogoName = obj.LogoName,
                    LogoPath = obj.LogoPath,
                    IsActive = obj.IsActive,
                    CreatedBy = obj.CreatedBy,
                    CreatedOn = Convert.ToDateTime(obj.CreatedOn),
                };
                ctx.MstLogoUpload.Add(entity);
                ctx.SaveChanges();
                s.Complete();
                s.Dispose();
                ipk = entity.LogoId;

                return ipk;
            }
            catch (System.Exception)
            {
                return 0;
            }
        }

        public int Update(LogoUploadModel obj, IFormFile SourceFile)
        {
            try
            {
                using (TransactionScope s = new TransactionScope())
                {
                    var Data = ctx.MstLogoUpload.FirstOrDefault(u => u.LogoId == obj.LogoId);
                    Data.LogoName = obj.LogoName; Data.LogoPath = obj.LogoPath; Data.IsActive = obj.IsActive;
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
        public bool DuplicateCheckOnSave(string LogoName)
        {
            return ctx.MstLogoUpload.Any(e => e.LogoName == LogoName);
        }
        public bool DuplicateCheckOnUpdate(int LogoId, string LogoName)
        {
            return ctx.MstLogoUpload.Any(e => e.LogoName == LogoName && e.LogoId != LogoId);
        }
    }
}
