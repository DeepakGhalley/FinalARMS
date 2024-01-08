using CORE_BOL;
using CORE_BOL.Entities;
using CORE_DLL;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Microsoft.AspNetCore.Http;

namespace CORE_BLL
{
    public class EsSignUploadsBLL : IEsSignUpload
    {
        readonly tt_dbContext ctx = new tt_dbContext();

        public bool CheckExists(int id)
        {
            return ctx.MstEsSignUpload.Any(e => e.EsSignId == id);
        }

        public Task Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteConfirmed(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<EsSignUploadsModel> Details(int? id)
        {
            var data = (from a in ctx.MstEsSignUpload.Where(aa => aa.EsSignId == id)
                        select new EsSignUploadsModel
                        {
                            esSignId = a.EsSignId,
                            userId = a.UserId,
                            SignPath = a.SignPath,
                            IsActive = a.IsActive,
                            CreatedDate = a.CreatedOn,
                            ModifiedDate = a.ModifiedOn,
                            ModifiedBy = a.ModifiedBy,
                            CreatedBy = a.CreatedBy

                        });

            return await data.FirstOrDefaultAsync();
        }

        public IList<EsSignUploadsModel> GetAll()
        {
            var data = (from x in ctx.MstEsSignUpload
                        select new EsSignUploadsModel
                        {
                            esSignId = x.EsSignId,
                            userId = x.UserId,
                            SignPath = x.SignPath,
                            IsActive = x.IsActive,
                            CreatedBy = x.CreatedBy,
                            ModifiedBy = x.ModifiedBy
                        });
            return data.ToList();
        }

        public int Save(EsSignUploadsModel obj, IFormFile SourceFile)
        {
            try
            {
                using TransactionScope s = new TransactionScope();
                int ipk;
                var entity = new MstEsSignUpload
                {
                    EsSignId = obj.esSignId,
                    UserId = obj.userId,
                    SignPath = obj.SignPath,
                    IsActive = obj.IsActive,
                    CreatedBy = obj.CreatedBy,
                    CreatedOn = obj.CreatedDate,
                };
                ctx.MstEsSignUpload.Add(entity);             
                ctx.SaveChanges();               
                s.Complete();
                s.Dispose();
                ipk = entity.EsSignId;
                return ipk;
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/ESSign", obj.SignPath);
                var stream = new FileStream(path, FileMode.Create);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public int Update(EsSignUploadsModel obj, IFormFile SourceFile)
        {
            try
            {
                using (TransactionScope s = new TransactionScope())
                {
                    var Data = ctx.MstEsSignUpload.FirstOrDefault(u => u.EsSignId == obj.esSignId);
                    Data.UserId = obj.userId; Data.SignPath = obj.SignPath; Data.IsActive = obj.IsActive;
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
        public bool DuplicateCheckOnSave(int UserId)
        {
            return ctx.MstEsSignUpload.Any(e => e.UserId == UserId);
        }
        public bool DuplicateCheckOnUpdate(int UserId, int Id)
        {
            return ctx.MstEsSignUpload.Any(e => e.UserId == UserId && e.EsSignId != Id);
        }

       
    }

   
}
