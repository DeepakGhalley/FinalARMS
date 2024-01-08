using CORE_DLL;
using System;
using System.Collections.Generic;
using CORE_BOL;
using CORE_BOL.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Transactions;
using Microsoft.EntityFrameworkCore.Internal;
using QRCoder;
using System.Drawing;
using System.IO;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CORE_BLL
{
    public class DemandCancelBLL : IDemandCancel
    {
        readonly tt_dbContext ctx = new tt_dbContext();


        public List<DemandCancelVM> GetDemandWithSearch(string DemandNo)
        {
            var data = (from x in ctx.TblDemandNo.Where(x => x.DemandNo == DemandNo)
                        join d in ctx.TblDemand on x.DemandNoId equals d.DemandNoId
                        join t in ctx.MstTaxMaster on d.TaxId equals t.TaxId
                        join tpp in ctx.MstTaxPayerProfile on d.TaxPayerId equals tpp.TaxPayerId
                        where d.IsCancelled == false

                        select new DemandCancelVM
                        {
                            TaxName = t.TaxName,
                            DemandAmount = d.DemandAmount,
                            ExemptionAmount = (decimal)d.ExemptionAmount,
                            TotalAmount = d.TotalAmount,
                            Name = tpp.FirstName + " " + ((tpp.MiddleName == null || tpp.MiddleName.Trim() == string.Empty) ? string.Empty : (tpp.MiddleName + " ")) + ((tpp.LastName == null || tpp.LastName.Trim() == string.Empty) ? string.Empty : (tpp.LastName + " ")),
                            TTIN = tpp.Ttin,
                            CID = tpp.Cid,
                            DemandId = (int)d.DemandId,
                            IsPaymentMade = d.IsPaymentMade

                        });
            return data.ToList();
        }

        public List<DemandCancelVM> GetDemandDetails(int? id)
        {
            var data = (from x in ctx.TblDemand.Where(x => x.DemandId == id)

                        select new DemandCancelVM
                        {
                            ExemptionAmount = (decimal)x.ExemptionAmount,
                            TotalAmount = x.TotalAmount,
                            DemandAmount = x.DemandAmount,
                            DemandNoId = (int)x.DemandNoId,
                            IsPaymentMade = x.IsPaymentMade
                        });
            return data.ToList();
        }

        public int SaveDemandCancel(DemandCancelVM obj)
        {
            try
            {
                using TransactionScope s = new TransactionScope();
                int ipk;
                var entity = new TblDemandCancel
                {
                    DemandNoId = obj.DemandNoId,
                    TotalCancelAmount = obj.TotalCancelAmount,
                    Remarks = obj.Remarks,
                    CreatedBy = obj.CreatedBy,
                    CreatedOn = Convert.ToDateTime(obj.CreatedOn),
                };
                ctx.TblDemandCancel.Add(entity);
                ctx.SaveChanges();
               
                var DataDemand = ctx.TblDemand.Where(u => u.DemandNoId==obj.DemandNoId);
                foreach (var item in DataDemand)
                {
                    var Data1 = ctx.TblDemand.Where(u => u.DemandId == item.DemandId);
                    Data1.FirstOrDefault().IsCancelled = true;
                    Data1.FirstOrDefault().CancelDemandAmount = Data1.FirstOrDefault().DemandAmount;
                    Data1.FirstOrDefault().CancelTotalAmount = Data1.FirstOrDefault().TotalAmount;
                    Data1.FirstOrDefault().DemandAmount = 0;
                    Data1.FirstOrDefault().TotalAmount = 0;
                  
                    //ctx.Entry(Data).State = EntityState.Modified;
                    ctx.SaveChanges();
                }
                s.Complete();
                s.Dispose();
                ipk = entity.DemandCancelId;

                return ipk;
            }
            catch (System.Exception)
            {
                return 0;
            }
        }
    }
}
