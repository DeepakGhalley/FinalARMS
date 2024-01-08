using CORE_BOL;
using CORE_BOL.Entities;
using CORE_DLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CORE_BLL
{
    public class LandLeaseDemandDetailBLL : ILandLeaseDemandDetail
    {
        readonly tt_dbContext ctx = new tt_dbContext();

        public bool CheckExists(int id)
        {
            return ctx.TblLandLeaseDemandDetail.Any(e => e.LandLeaseDemandDetailId == id);
        }

        public Task Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteConfirmed(int id)
        {
            throw new NotImplementedException();
        }

        public Task<LandLeaseDemandDetailModel> Details(int? id)
        {
            throw new NotImplementedException();
        }

        public List<LandLeaseDemandDetailModel> fetchLandAndLeaseDetails(string Cid, string Ttin)
        {
            var data = (from x in ctx.MstTaxPayerProfile.Where(x=> x.Cid == Cid || x.Ttin == Ttin)
                        join y in ctx.TblLandLease on x.TaxPayerId equals y.TaxPayerId
                        join z in ctx.MstLandDetail on y.LandDetailId equals z.LandDetailId
                        join a in ctx.TblLandOwnershipDetail on x.TaxPayerId equals a.TaxPayerId
                        select new LandLeaseDemandDetailModel { 
                            Cid = x.Cid,
                            taxPayerName = x.FirstName + " " + x.MiddleName + " " + x.LastName,
                            Ttin = x.Ttin,
                            CAddressID = x.CAddress,
                            MobileNoID = x.MobileNo,
                            EmailID = x.Email,

                            Location = z.Location,
                            ThramNo = a.ThramNo,
                            PlotNo = z.PlotNo,
                            StartDate = y.StartDate
                        });
            return data.ToList();
        }

        public IList<LandLeaseDemandDetailModel> GetAll()
        {
            var data = (from x in ctx.TblLandLeaseDemandDetail
                        join y in ctx.TblLandLease on x.LandLeaseId equals y.LandLeaseId
                        join z in ctx.MstTaxPayerProfile on y.TaxPayerId equals z.TaxPayerId
                        join a in ctx.MstLandDetail on y.LandLeaseId equals a.LandDetailId
                        join b in ctx.TblLandOwnershipDetail on a.LandDetailId equals b.LandDetailId

                        select new LandLeaseDemandDetailModel
                        {
                            LandLeaseDemandDetailId = x.LandLeaseDemandDetailId,
                            LandLeaseId = x.LandLeaseId,
                            DemandYear = x.DemandYear,
                            DemandGenerateScheduleId = x.DemandGenerateScheduleId,
                            InstallmentAmount = x.InstallmentAmount,
                            DemandNoId = x.DemandNoId,
                            DemandGenerateSchedule = x.DemandGenerateSchedule,

                            Cid = z.Cid,
                            Ttin = z.Ttin,
                            taxPayerName = z.FirstName,
                            CAddressID = z.CAddress,
                            MobileNoID = z.MobileNo,
                            EmailID = z.Email,
                            PlotNo = a.PlotNo,
                            Location = a.Location,
                            StartDate = y.StartDate,
                            ThramNo = b.ThramNo
                          
                        });
            return data.ToList();
        }

        public int Save(LandLeaseDemandDetailModel obj)
        {
            throw new NotImplementedException();
        }
    }
}
