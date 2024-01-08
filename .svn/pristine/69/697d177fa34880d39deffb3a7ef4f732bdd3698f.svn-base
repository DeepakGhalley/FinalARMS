using CORE_BOL;
using CORE_BOL.Entities;
using CORE_DLL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace CORE_BLL
{
    public class ApplicantDetailBLL : IApplicantDetails
    {
        readonly tt_dbContext ctx = new tt_dbContext();
        public bool CheckExists(int id)
        {
            return ctx.MstEcapplicantdetail.Any(e => e.ApplicantId == id); ;
        }

        public async Task Delete(int? id)
        {
            var MstApplicantDetail = await ctx.MstEcapplicantdetail
            .FirstOrDefaultAsync(m => m.ApplicantId == id);
        }

        public async Task DeleteConfirmed(int id)
        {
            using (TransactionScope s = new TransactionScope())
            {
                var MstApplicantDetail = ctx.MstEcapplicantdetail.Find(id);
                ctx.MstEcapplicantdetail.Remove(MstApplicantDetail);
                ctx.SaveChanges();
                s.Complete();
                s.Dispose();
            }
        }

        public async Task<ApplicantdetailModel> Details(int? id)
        {
            var data = (from a in ctx.MstEcapplicantdetail.Where(aa => aa.ApplicantId == id)
                        select new ApplicantdetailModel
                        {
                            ApplicantId = a.ApplicantId,
                            Cid = a.Cid,
                            LicenceNo = a.LicenceNo,
                            ApplicantName = a.ApplicantName,
                            Remarks = a.Remarks,
                            Address = a.Address,
                            PostBoxNo = a.PostBoxNo,
                            FaxNo = a.FaxNo,
                            ContactNo =a.ContactNo,
                            IsActive =a.IsActive,
                            CreatedBy = a.CreatedBy,
                            CreatedOn = a.CreatedOn,
                            ModifiedBy = a.ModifiedBy,
                            ModifiedOn = a.ModifiedOn

                        });

            return await data.FirstOrDefaultAsync();
        }

        public bool DuplicateCheckOnSave(string CID)
        {
            return ctx.MstEcapplicantdetail.Any(e => e.Cid == CID );
        }

        public bool DuplicateCheckOnUpdate(string CID, int Id)
        {
            return ctx.MstEcapplicantdetail.Any(e => e.Cid == CID && e.ApplicantId != Id);
        }

        public IList<ApplicantdetailModel> GetAll()
        {
            var data = (from x in ctx.MstEcapplicantdetail
                        select new ApplicantdetailModel
                        {
                            ApplicantId = x.ApplicantId,
                            Cid = x.Cid,
                            LicenceNo = x.LicenceNo,
                            Address = x.Address,
                            ApplicantName = x.ApplicantName,
                            Remarks = x.Remarks,
                            PostBoxNo = x.PostBoxNo,
                            FaxNo = x.FaxNo,
                            ContactNo = x.ContactNo,
                            IsActive = x.IsActive,
                            CreatedBy = x.CreatedBy,
                            CreatedOn = x.CreatedOn,
                            ModifiedOn = x.ModifiedOn,
                            ModifiedBy = x.ModifiedBy
                        });
            return data.ToList();
        }

        public int Save(ApplicantdetailModel obj)
        {
            try
            {
                using TransactionScope s = new TransactionScope();
                int ipk;
                var entity = new MstEcapplicantdetail
                {
                    ApplicantId = obj.ApplicantId,
                    Cid = obj.Cid,
                    LicenceNo = obj.LicenceNo,
                    ApplicantName = obj.ApplicantName,
                    Address = obj.Address,
                    PostBoxNo = obj.PostBoxNo,
                    Remarks = obj.Remarks,
                    FaxNo = obj.FaxNo,
                    ContactNo = obj.ContactNo,
                    IsActive = obj.IsActive,
                    CreatedBy = obj.CreatedBy,
                    CreatedOn = Convert.ToDateTime(obj.CreatedOn),
                };
                ctx.MstEcapplicantdetail.Add(entity);
                ctx.SaveChanges();
                s.Complete();
                s.Dispose();
                ipk = entity.ApplicantId;

                return ipk;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public int Update(ApplicantdetailModel obj)
        {
            try
            {
                using (TransactionScope s = new TransactionScope())
                {
                    var Data = ctx.MstEcapplicantdetail.FirstOrDefault(u => u.ApplicantId == obj.ApplicantId);
                    Data.Cid = obj.Cid; Data.LicenceNo = obj.LicenceNo; Data.ApplicantName = obj.ApplicantName;
                    Data.Address = obj.Address; Data.PostBoxNo = obj.PostBoxNo; Data.Remarks = obj.Remarks;
                    Data.FaxNo = obj.FaxNo; Data.ContactNo = obj.ContactNo; Data.IsActive = obj.IsActive;
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
