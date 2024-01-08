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
    public class LogoSignMapBLL : ILogoSignMap
    {
        readonly tt_dbContext ctx = new tt_dbContext();

        public bool CheckExists(int id)
        {
            return ctx.MstLogoSignMap.Any(e => e.LogoSignMapId == id);
        }

        public Task Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteConfirmed(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<LogoSignMapModel> Details(int? id)
        {
            var data = (from a in ctx.MstLogoSignMap.Where(aa => aa.LogoSignMapId == id)
                        select new LogoSignMapModel
                        {
                            LogoSignMapId = a.LogoSignMapId,
                            LogoId = a.LogoId,
                            ESSignId = a.EsSignId,
                            DCDSignId = a.DcdSignId,
                            IsActive = a.IsActive,
                            CreatedBy = a.CreatedBy,
                            ModifiedBy = a.ModifiedBy
                        });

            return await data.FirstOrDefaultAsync();
        }

        public IList<LogoSignMapModel> GetAll()
        {
            var data = (from x in ctx.MstLogoSignMap
                       join lu in ctx.MstLogoUpload on x.LogoId equals lu.LogoId
                       join dcdsu in ctx.MstDcdsignUpload on x.DcdSignId equals dcdsu.DcdSignId
                       join essu in ctx.MstEsSignUpload on x.EsSignId equals essu.EsSignId
                        select new LogoSignMapModel
                        {
                            LogoName = lu.LogoName,
                            SignPath = dcdsu.SignPath,
                            SSignPath = essu.SignPath,
                            IsActive = x.IsActive,
                            ModifiedOn = x.ModifiedOn,
                            CreatedOn = x.CreatedOn,
                            CreatedBy = x.CreatedBy,
                            ModifiedBy = x.ModifiedBy,
                            LogoSignMapId = x.LogoSignMapId
                        });
            return data.ToList();
        }

        public int Save(LogoSignMapModel obj)
        {
            try
            {
                using TransactionScope s = new TransactionScope();
                int ipk;
                var entity = new MstLogoSignMap
                {
                    LogoSignMapId = obj.LogoSignMapId,
                    EsSignId = obj.ESSignId,
                    DcdSignId = obj.DCDSignId,
                    LogoId = obj.LogoId,
                    IsActive = obj.IsActive,
                    CreatedBy = obj.CreatedBy,
                    CreatedOn = Convert.ToDateTime(obj.CreatedOn),
                };
                ctx.MstLogoSignMap.Add(entity);
                ctx.SaveChanges();
                s.Complete();
                s.Dispose();
                ipk = entity.LogoSignMapId;

                return ipk;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public int Update(LogoSignMapModel obj)
        {
            try
            {
                using (TransactionScope s = new TransactionScope())
                {
                    var Data = ctx.MstLogoSignMap.FirstOrDefault(u => u.LogoSignMapId == obj.LogoSignMapId);
                    Data.DcdSignId = obj.DCDSignId; Data.LogoId = obj.LogoId; Data.EsSignId = obj.ESSignId; Data.IsActive = obj.IsActive;
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
       
    }
}
