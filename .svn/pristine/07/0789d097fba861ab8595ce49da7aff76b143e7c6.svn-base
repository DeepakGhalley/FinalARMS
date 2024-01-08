using CORE_BOL;
using CORE_BOL.Entities;
using CORE_DLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;

namespace CORE_BLL
{
    public class FreezePropertyBLL : IFreezeProperty
    {
        readonly tt_dbContext ctx = new tt_dbContext();

        public int SaveDetails(FreezePropertyVM obj)
        {
            try
            {
                using TransactionScope s = new TransactionScope();
                int ipk;
                var entity = new TblFreezPropertyDetail
                {
                    LandDetailId = obj.LandDetailId,
                    LetterDate = obj.LetterDate,
                    LetterNo = obj.LetterNo,
                    Remarks = obj.Remarks,
                    IsFreeze = obj.IsFreeze,
                    CreatedBy = obj.CreatedBy,
                    CreatedOn = obj.CreatedOn
                };
                ctx.TblFreezPropertyDetail.Add(entity);
                ctx.SaveChanges();
                s.Complete();
                s.Dispose();
                ipk = (int)entity.FreezePropertyId;

                return ipk;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public List<FreezePropertyVM> SearchDetails(string plotno, string thramno)
        {
            var data = (from x in ctx.TblLandOwnershipDetail.Where(x => (string.IsNullOrEmpty(thramno) || x.ThramNo == thramno))
                        join a in ctx.MstLandDetail on x.LandDetailId equals a.LandDetailId
                        join b in ctx.MstTaxPayerProfile on x.TaxPayerId equals b.TaxPayerId
                        join c in ctx.EnumLandOwnershipType on x.LandOwnershipTypeId equals c.LandOwnershipTypeId
                        join d in ctx.MstLandType on a.LandTypeId equals d.LandTypeId
                        where (string.IsNullOrEmpty(plotno) || a.PlotNo == plotno)
                        select new FreezePropertyVM
                        {
                            ThramNo = x.ThramNo,
                            TaxPayerId =x.TaxPayerId,
                            LandOwnerShipId = x.LandOwnershipTypeId,
                            PlotNo = a.PlotNo,
                            LandTypeId = a.LandTypeId,
                            CID = b.Cid,
                            TTIN = b.Ttin,
                            LandDetailId = a.LandDetailId,
                            Fname = b.FirstName,
                            Mname = (b.MiddleName == null ? " " : b.MiddleName),
                            Lname = (b.LastName == null ? " " : b.LastName),
                            LandOwnerShip = c.LandOwnershipType,
                            LandType = d.LandTypeName

                        });
            return data.ToList();
        }

    }
}
