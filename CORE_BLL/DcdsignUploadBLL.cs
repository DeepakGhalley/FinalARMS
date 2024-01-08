using CORE_BOL;
using CORE_BOL.Entities;
using CORE_DLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace CORE_BLL
{
    public class DcdsignUploadBLL : IDcdSignUpload
    {
        readonly tt_dbContext ctx = new tt_dbContext();

        public bool CheckExists(int id)
        {
            return ctx.MstDcdsignUpload.Any(e => e.DcdSignId == id);
        }

        public Task Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteConfirmed(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<DcdsignUploadModel> Details(int? id)
        {
            var data = (from a in ctx.MstDcdsignUpload.Where(aa => aa.DcdSignId == id)
                        select new DcdsignUploadModel
                        {
                            DcdSignId = a.DcdSignId,
                            UserId = a.UserId,
                            SignPath = a.SignPath,
                            IsActive = a.IsActive,
                            CreatedBy = a.CreatedBy,
                            ModifiedBy = a.ModifiedBy

                        });

            return await data.FirstOrDefaultAsync();
        }

        public IList<DcdsignUploadModel> GetAll()
        {
            var data = (from x in ctx.MstDcdsignUpload
                        select new DcdsignUploadModel
                        {
                            DcdSignId = x.DcdSignId,
                            UserId = x.UserId,
                            SignPath = x.SignPath,
                            IsActive = x.IsActive,
                            CreatedBy = x.CreatedBy,
                            ModifiedBy = x.ModifiedBy
                        });
            return data.ToList();
        }

        public int Save(DcdsignUploadModel obj, IFormFile SourceFile)
        {
            try
            {
                using TransactionScope s = new TransactionScope();
                int ipk;
                var entity = new MstDcdsignUpload
                {
                    DcdSignId = obj.DcdSignId,
                    UserId = obj.UserId,
                    SignPath = obj.SignPath,
                    IsActive = obj.IsActive,
                    CreatedBy = obj.CreatedBy,
                    CreatedOn = Convert.ToDateTime(obj.CreatedDate),
                };
                ctx.MstDcdsignUpload.Add(entity);
                ctx.SaveChanges();
                s.Complete();
                s.Dispose();
                ipk = entity.DcdSignId;

                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Uploads/DCDSign", obj.SignPath);
                var stream = new FileStream(path, FileMode.Create);
                //use await
                SourceFile.CopyToAsync(stream);

                return ipk;
            }
            catch (System.Exception)
            {
                return 0;
            }
        }

        public int Update(DcdsignUploadModel obj, IFormFile SourceFile)
        {
            try
            {
                using (TransactionScope s = new TransactionScope())
                {
                    var Data = ctx.MstDcdsignUpload.FirstOrDefault(u => u.DcdSignId == obj.DcdSignId);
                    Data.UserId = obj.UserId; Data.SignPath = obj.SignPath; Data.IsActive = obj.IsActive;
                    Data.ModifiedBy = obj.ModifiedBy; Data.ModifiedOn = obj.ModifiedDate;
                    ctx.SaveChanges();
                    s.Complete();
                    s.Dispose();

                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/DCDSign", obj.SignPath);
                    var stream = new FileStream(path, FileMode.Create);
                    //use await
                    SourceFile.CopyToAsync(stream);

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
            return ctx.MstDcdsignUpload.Any(e => e.UserId == UserId);
        }
        public bool DuplicateCheckOnUpdate(int UserId, int Id)
        {
            return ctx.MstDcdsignUpload.Any(e => e.UserId == UserId && e.DcdSignId != Id);
        }
    }
}
