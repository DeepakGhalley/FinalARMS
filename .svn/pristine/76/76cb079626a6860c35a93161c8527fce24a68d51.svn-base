using CORE_DLL;
using System;
using System.Collections.Generic;
using CORE_BOL;
using CORE_BOL.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Transactions;
namespace CORE_BLL
{
    public class WaterConnectionBLL : IWaterConnection
    {
        readonly tt_dbContext ctx = new tt_dbContext();

        public IList<WaterConnectionModel> GetAll()
        {
            var data = (from x in ctx.MstWaterConnection
                        join y in ctx.MstLandDetail on x.LandDetailId equals y.LandDetailId
                        join z in ctx.EnumWaterConnectionStatus on x.WaterConnectionStatusId equals z.WaterConnectionStatusId
                        join a in ctx.MstWaterMeterType on x.WaterMeterTypeId equals a.WaterMeterTypeId
                        join b in ctx.MstWaterConnectionType on x.WaterConnectionTypeId equals b.WaterConnectionTypeId
                        join c in ctx.MstWaterLineType on x.WaterLineTypeId equals c.WaterLineTypeId
                        join d in ctx.MstZone on x.ZoneId equals d.ZoneId
                        join e in ctx.EnumOwnerType on x.OwnerTypeId equals e.OwnerTypeId

                        select new WaterConnectionModel
                        {
                            WaterConnectionId = x.WaterConnectionId,
                            LandDetailId = x.LandDetailId,
                            PlotNo = y.PlotNo,
                            WaterConnectionStatusId = x.WaterConnectionStatusId,
                            WaterMeterNo = x.WaterMeterNo,
                            WaterMeterTypeId = x.WaterMeterTypeId,
                            ConsumerNo = x.ConsumerNo,
                            ConnectionDate = x.ConnectionDate,
                            SewerageConnection = x.SewerageConnection,
                            WaterConnectionTypeId = b.WaterConnectionTypeId,
                            WaterLineTypeId = x.WaterLineTypeId,
                            StandardCosumption = (int)x.StandardConsumption,
                            BillingAddress = x.BillingAddress,
                            ZoneId = d.ZoneId,
                            FlatNo = x.FlatNo,
                            InitialReading = x.InitialReading,
                            OrganisationName = x.OrganisationName,
                            Remarks = x.Remarks,
                            ReUse = (bool)x.IsPermanentDisconnect,
                            DisconnectDate = (DateTime)x.DisconnectDate,
                            NoOfUnits = x.NoOfUnits,
                            OwnerTypeId = x.OwnerTypeId,
                            ChangeTypeId = (int)x.ChangeTypeId,
                            ReconnectionDate = (DateTime)x.ReconnectionDate,
                            SewarageConnectionDate = (DateTime)x.SewarageConnectionDate,
                            SewarageConnectedBy = (int)x.SewarageConnectedBy,
                            PrimaryMobileNo = x.PrimaryMobileNo,
                            SecondaryMobileNo = x.SecondaryMobileNo,
                            IsActive = x.IsActive,
                            CreatedBy = x.CreatedBy,
                            CreatedOn = x.CreatedOn,
                            ModifiedOn = x.ModifiedOn,
                            ModifiedBy = x.ModifiedBy
                        });
            return data.ToList();

        }

        public async Task<WaterConnectionModel> Details(int? id)
        {
            var data = (from a in ctx.MstWaterConnection.Where(aa => aa.WaterConnectionId == id)
                        join b in ctx.MstLandDetail on a.LandDetailId equals b.LandDetailId
                        join z in ctx.MstZone on a.ZoneId equals z.ZoneId
                        join o in ctx.EnumOwnerType on a.OwnerTypeId equals o.OwnerTypeId
                        join wlt in ctx.MstWaterLineType on a.WaterLineTypeId equals wlt.WaterLineTypeId
                        join wct in ctx.MstWaterConnectionType on a.WaterConnectionTypeId equals wct.WaterConnectionTypeId
                        join wmt in ctx.MstWaterMeterType on a.WaterMeterTypeId equals wmt.WaterMeterTypeId
                        join c in ctx.EnumWaterConnectionStatus on a.WaterConnectionStatusId equals c.WaterConnectionStatusId
                        select new WaterConnectionModel
                        {
                            WaterConnectionId = a.WaterConnectionId,
                            WaterConnectionStatusId = a.WaterConnectionStatusId,
                            LandDetailId = a.LandDetailId,
                            WaterMeterNo = a.WaterMeterNo,
                            WaterMeterTypeId = wmt.WaterMeterTypeId,
                            ConsumerNo = a.ConsumerNo,
                            ConnectionDate = a.ConnectionDate,
                            SewerageConnection = a.SewerageConnection,
                            WaterConnectionTypeId = wct.WaterConnectionTypeId,
                            WaterLineTypeId = wlt.WaterLineTypeId,
                            StandardCosumption = (int)a.StandardConsumption,
                            BillingAddress = a.BillingAddress,
                            ZoneId = z.ZoneId,
                            FlatNo = a.FlatNo,
                            InitialReading = a.InitialReading,
                            OrganisationName = a.OrganisationName,
                            Remarks = a.Remarks,
                            ReUse = (bool)a.IsPermanentDisconnect,
                            DisconnectDate = (DateTime)a.DisconnectDate,
                            NoOfUnits = a.NoOfUnits,
                            OwnerTypeId = o.OwnerTypeId,
                            ReconnectionDate = (DateTime)a.ReconnectionDate,
                            SewarageConnectionDate = (DateTime)a.SewarageConnectionDate,
                            SewarageConnectedBy = (int)a.SewarageConnectedBy,
                            PrimaryMobileNo = a.PrimaryMobileNo,
                            SecondaryMobileNo = a.SecondaryMobileNo,
                            IsActive = a.IsActive,
                            CreatedBy = a.CreatedBy,
                            CreatedOn = a.CreatedOn,
                            ModifiedOn = a.ModifiedOn,
                            ModifiedBy = a.ModifiedBy,
                            PlotNo = b.PlotNo,
                            WaterConnectionStatus = c.WaterConnectionStatus

                        });

            return await data.FirstOrDefaultAsync();

        }
        public int Save(WaterConnectionModel obj)
        {
            try
            {
                using TransactionScope s = new TransactionScope();
                int ipk;
                var entity = new MstWaterConnection
                {
                    WaterConnectionId = obj.WaterConnectionId,
                    LandDetailId = obj.LandDetailId,
                    WaterConnectionStatusId = obj.WaterConnectionStatusId,
                    WaterMeterNo = obj.WaterMeterNo,
                    WaterMeterTypeId = obj.WaterMeterTypeId,
                    ConsumerNo = obj.ConsumerNo,
                    ConnectionDate = obj.ConnectionDate,
                    SewerageConnection = Convert.ToBoolean("false"),
                    WaterConnectionTypeId = obj.WaterConnectionTypeId,
                    WaterLineTypeId = obj.WaterLineTypeId,
                    StandardConsumption = obj.StandardCosumption,
                    BillingAddress = obj.BillingAddress,
                    ZoneId = obj.ZoneId,
                    FlatNo = obj.FlatNo,
                    InitialReading = obj.InitialReading,
                    OrganisationName = obj.OrganisationName,
                    Remarks = obj.Remarks,
                   // IsPermanentDisconnect = Convert.ToBoolean("true"),
                    NoOfUnits = obj.NoOfUnits,
                    OwnerTypeId = obj.OwnerTypeId,
                    PrimaryMobileNo = obj.PrimaryMobileNo,
                    SecondaryMobileNo = obj.SecondaryMobileNo,
                    IsActive = Convert.ToBoolean("true"),
                    CreatedBy = obj.CreatedBy,
                    CreatedOn = Convert.ToDateTime(obj.CreatedOn),
                    //TransactionId = Convert.ToInt32("3"),
                    LandOwnershipId=obj.LandOwnershipId
                };
                ctx.MstWaterConnection.Add(entity);
                ctx.SaveChanges();

                ipk = entity.WaterConnectionId;

                var tblWaterMeterReading = new TblWaterMeterReading {
                    WaterConnectionId = ipk,
                    WaterConnectionTypeId = obj.WaterConnectionTypeId,
                    WaterMeterTypeId = obj.WaterMeterTypeId,
                    WaterLineTypeId = obj.WaterLineTypeId,
                    WaterConnectionStatusId = obj.WaterConnectionStatusId,
                    Reading = (int)obj.InitialReading,
                    PreviousReading = 0,
                    PreviousReadingDate = DateTime.Now,
                    ReadBy = 0,
                    ReadingDate = DateTime.Now,
                    NoOfUnit = obj.NoOfUnits,
                    Consumption = 0,
                    IsPermanentConnection = false,
                    Sewerage = false,
                    SolidWaste = false,
                    BillingAddress = obj.BillingAddress,
                    PrimaryMobileNo = obj.PrimaryMobileNo
                };
                ctx.TblWaterMeterReading.Add(tblWaterMeterReading);
                ctx.SaveChanges();
                s.Complete();
                s.Dispose();

                return ipk;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public int Update(WaterConnectionModel obj)
        {
            try
            {
                using (TransactionScope s = new TransactionScope())
                {
                    var Data = ctx.MstWaterConnection.FirstOrDefault(u => u.WaterConnectionId == obj.WaterConnectionId);
                    Data.LandDetailId = obj.LandDetailId; 
                    Data.WaterConnectionStatusId = obj.WaterConnectionStatusId;
                    Data.WaterMeterNo = obj.WaterMeterNo; 
                    Data.WaterMeterTypeId = obj.WaterMeterTypeId;
                    Data.ConsumerNo = obj.ConsumerNo; 
                    Data.ConnectionDate = obj.ConnectionDate;
                    Data.WaterLineTypeId = obj.WaterLineTypeId; 
                    Data.StandardConsumption = obj.StandardCosumption;
                    Data.BillingAddress = obj.BillingAddress; 
                    Data.ZoneId = obj.ZoneId; 
                    Data.FlatNo = obj.FlatNo;
                    Data.InitialReading = obj.InitialReading; 
                    Data.OrganisationName = obj.OrganisationName; 
                    Data.Remarks = obj.Remarks;
                    Data.NoOfUnits = obj.NoOfUnits;
                    Data.OwnerTypeId = obj.OwnerTypeId;
                    //Data.PrimaryMobileNo = obj.PrimaryMobileNo; 
                    //Data.SecondaryMobileNo = obj.SecondaryMobileNo;
                    Data.WaterConnectionTypeId = obj.WaterConnectionTypeId;
                    Data.ModifiedBy = obj.ModifiedBy; 
                    Data.ModifiedOn = obj.ModifiedOn;
                    ctx.SaveChanges();
                    s.Complete();
                    s.Dispose();
                    return 0;
                }

            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        public bool CheckExists(int id)
        {
            return ctx.MstWaterConnection.Any(e => e.WaterConnectionId == id);
        }

        public async Task DeleteConfirmed(int id)
        {
            using (TransactionScope s = new TransactionScope())
            {
                var MstWaterConnection = ctx.MstWaterConnection.Find(id);
                ctx.MstWaterConnection.Remove(MstWaterConnection);
                ctx.SaveChanges();
                s.Complete();
                s.Dispose();

            }
        }

        public async Task Delete(int? id)
        {
            var MstWaterConnection = await ctx.MstWaterConnection
                           .FirstOrDefaultAsync(m => m.WaterConnectionId == id);
        }
        public bool DuplicateCheckOnSave(string ConsumerNo)
        {
            return ctx.MstWaterConnection.Any(e => e.ConsumerNo == ConsumerNo);
        }

        //public bool DuplicateCheckOnUpdate(string ConsumerNo, int WaterConnectionId, int LandDetailId, int WaterMeterTypeId, int WaterConnectionTypeId, int WaterLineTypeId, int ZoneId, int OwnerTypeId)
        //{
        //    return ctx.MstWaterConnection.Any(e => e.ConsumerNo == ConsumerNo && e.LandDetailId == LandDetailId && e.WaterMeterTypeId == WaterMeterTypeId && e.WaterConnectionTypeId == WaterConnectionTypeId && e.WaterLineTypeId == WaterLineTypeId && e.ZoneId == ZoneId && e.OwnerTypeId == OwnerTypeId);
        //}

        public List<GetLandOwnershipDetails> fetchLandOwnershipDetails(string cid, string ttin, string name)
        {
            var data = (from a in ctx.MstTaxPayerProfile.Where(x => (string.IsNullOrEmpty(cid) || x.Cid == cid) && (string.IsNullOrEmpty(ttin) || x.Ttin == ttin) && x.FirstName + "" + x.MiddleName + "" + x.LastName == name)
                            //var data = (from a in ctx.MstTaxPayerProfile.Where(x => x.Cid == cid || x.Ttin == ttin || x.FirstName +""+ x.MiddleName +""+ x.LastName == name)
                        join b in ctx.TblLandOwnershipDetail on a.TaxPayerId equals b.TaxPayerId
                        join c in ctx.MstLandDetail on b.LandDetailId equals c.LandDetailId
                        select new GetLandOwnershipDetails
                        {
                            CID = a.Cid,
                            TPN = a.Tpn,
                            TTIN = a.Ttin,
                            Name = a.FirstName + "" + a.MiddleName + "" + a.LastName,
                            ThramNo = b.ThramNo,
                            PlotNo = c.PlotNo,
                            PlotAddress = c.PlotAddress,
                            LandAcreage = c.LandAcerage,
                            LandValue = c.LandValue,
                            LandDetailId = b.LandDetailId
                            ,LandOwnershipId=b.LandOwnershipId,
                            TaxPayerId=a.TaxPayerId
                        });
            return data.ToList();
        }

        public List<WaterConnectionModel> GetWaterConnectionDetails(int id, int LandOwnershipId)
        {
            var Data = (from a in ctx.MstWaterConnection.Where(x => x.LandDetailId == id)
                        select new WaterConnectionModel { 
                            WaterMeterNo = a.WaterMeterNo,
                            ConsumerNo = a.ConsumerNo,
                            OrganisationName = a.OrganisationName,
                            NoOfUnits = a.NoOfUnits,
                            BillingAddress = a.BillingAddress,
                            PrimaryMobileNo = a.PrimaryMobileNo,
                            LandOwnershipId = LandOwnershipId

                        });
            return Data.ToList();
        }

        public List<WaterConnectionModel> GetWaterConnectionDetails(string consumerno,string Plotno)
        {
            var data = (from a in ctx.MstWaterConnection
                        join l in ctx.MstLandDetail on a.LandDetailId equals l.LandDetailId
                        join w in ctx.MstWaterConnectionType on a.WaterConnectionTypeId equals w.WaterConnectionTypeId
                        join z in ctx.MstZone on a.ZoneId equals z.ZoneId
                        where a.ConsumerNo == consumerno || l.PlotNo == Plotno
                        //Where  x.ConsumerNo == consumerno
                        select new WaterConnectionModel
                        {
                           PlotNo = l.PlotNo,
                           WaterMeterNo = a.WaterMeterNo,
                           ConsumerNo = a.ConsumerNo,
                           WaterConnectionType = w.WaterConnectionType,
                           BillingAddress = a.BillingAddress,
                           ZoneName = z.ZoneName,
                           PrimaryMobileNo = a.PrimaryMobileNo,
                           WaterConnectionId = a.WaterConnectionId,
                           IsActive = a.IsActive,
                           TransactionId = (long)a.TransactionId

                        });
            return data.ToList();
        }

        //for Update/edit page(plot no search)
        public List<WaterConnectionModel> SearchDetails(string plotno)
        {
            var data = (from b in ctx.MstLandDetail.Where(aa => aa.PlotNo == plotno)
                        join a in ctx.MstWaterConnection on b.LandDetailId equals a.LandDetailId
                        join z in ctx.MstZone on a.ZoneId equals z.ZoneId
                        join o in ctx.EnumOwnerType on a.OwnerTypeId equals o.OwnerTypeId
                        join wlt in ctx.MstWaterLineType on a.WaterLineTypeId equals wlt.WaterLineTypeId
                        join wct in ctx.MstWaterConnectionType on a.WaterConnectionTypeId equals wct.WaterConnectionTypeId
                        join wmt in ctx.MstWaterMeterType on a.WaterMeterTypeId equals wmt.WaterMeterTypeId
                        join c in ctx.EnumWaterConnectionStatus on a.WaterConnectionStatusId equals c.WaterConnectionStatusId
                        select new WaterConnectionModel
                        {
                            WaterConnectionId = a.WaterConnectionId,
                            WaterConnectionStatusId = a.WaterConnectionStatusId,
                            LandDetailId = a.LandDetailId,
                            WaterMeterNo = a.WaterMeterNo,
                            WaterMeterTypeId = wmt.WaterMeterTypeId,
                            ConsumerNo = a.ConsumerNo,
                            ConnectionDate = a.ConnectionDate,
                            SewerageConnection = a.SewerageConnection,
                            WaterConnectionTypeId = wct.WaterConnectionTypeId,
                            WaterLineTypeId = wlt.WaterLineTypeId,
                            StandardCosumption = (int)a.StandardConsumption,
                            BillingAddress = a.BillingAddress,
                            ZoneId = z.ZoneId,
                            FlatNo = a.FlatNo,
                            InitialReading = a.InitialReading,
                            OrganisationName = a.OrganisationName,
                            Remarks = a.Remarks,
                            ReUse = (bool)a.IsPermanentDisconnect,
                            DisconnectDate = (DateTime)a.DisconnectDate,
                            NoOfUnits = a.NoOfUnits,
                            OwnerTypeId = o.OwnerTypeId,
                            ReconnectionDate = (DateTime)a.ReconnectionDate,
                            SewarageConnectionDate = (DateTime)a.SewarageConnectionDate,
                            SewarageConnectedBy = (int)a.SewarageConnectedBy,
                            PrimaryMobileNo = a.PrimaryMobileNo,
                            SecondaryMobileNo = a.SecondaryMobileNo,
                            IsActive = a.IsActive,
                            CreatedBy = a.CreatedBy,
                            CreatedOn = a.CreatedOn,
                            ModifiedOn = a.ModifiedOn,
                            ModifiedBy = a.ModifiedBy,
                            PlotNo = b.PlotNo,
                            WaterConnectionStatus = c.WaterConnectionStatus

                        });
            return data.ToList();
        }
        public List<WaterConnectionModel> SearchPlotNo(string PlotNo)
        {
            var data = (from a in ctx.TblLandOwnershipDetail
                        //join a in ctx.TblLandOwnershipDetail on w.LandOwnershipId equals a.LandOwnershipId
                        join l in ctx.MstLandDetail on a.LandDetailId equals l.LandDetailId
                        join t in ctx.MstTaxPayerProfile on a.TaxPayerId equals t.TaxPayerId
                        join ot in ctx.EnumLandOwnershipType on a.LandOwnershipTypeId equals ot.LandOwnershipTypeId
                       let w = (ctx.MstWaterConnection.Where(lod => lod.LandOwnershipId == a.LandOwnershipId)).Take(1).FirstOrDefault().ConsumerNo
                        where l.PlotNo == PlotNo && a.IsActive == true

                        select new WaterConnectionModel
                        {
                            PlotNo = l.PlotNo,
                            ThramNo = a.ThramNo,
                            TTIN = t.Ttin,
                            CID = t.Cid,
                            TaxPayerName = t.FirstName + " " + ((t.MiddleName == null || t.MiddleName.Trim() == string.Empty) ? string.Empty : (t.MiddleName + " ")) + ((t.LastName == null || t.LastName.Trim() == string.Empty) ? string.Empty : (t.LastName + " ")),
                            PrimaryMobileNo = t.MobileNo,
                            OwnerType = ot.LandOwnershipType,
                            OwnerTypeId = (int)a.OwnershipPercentage,
                            LandOwnershipId = a.LandOwnershipId,
                            LandDetailId = a.LandDetailId,
                            ConsumerNo = w
                        });
            return data.ToList();
        }

        public int UpdateLandOwnership(WaterConnectionModel obj)
        {
            try
            {
                using (TransactionScope s = new TransactionScope())
                {
                    var ld = ctx.TblLandOwnershipDetail.Single(x => x.LandOwnershipId == obj.LandOwnershipId);
                    var lid = ld.LandDetailId;
                    var Data = ctx.MstWaterConnection.FirstOrDefault(u => u.WaterConnectionId == obj.WaterConnectionId);
                    Data.LandDetailId = lid;
                    Data.LandOwnershipId = obj.LandOwnershipId;                  
                    Data.ModifiedBy = obj.ModifiedBy;
                    Data.ModifiedOn = obj.ModifiedOn;
                    ctx.SaveChanges();

                    s.Complete();
                    s.Dispose();
                    return 0;
                }

            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public List<WaterConnectionModel> DisplayLandOwnership(int? id)
        {
            var data = (from x in ctx.TblLandOwnershipDetail.Where(x => x.LandOwnershipId == id)
                        join d in ctx.MstTaxPayerProfile on x.TaxPayerId equals d.TaxPayerId
                        join l in ctx.MstLandDetail on x.LandDetailId equals l.LandDetailId

                        select new WaterConnectionModel
                        {
                            //ConsumerNo = a.ConsumerNo,
                            TaxPayerName = d.FirstName + " " + ((d.MiddleName == null || d.MiddleName.Trim() == string.Empty) ? string.Empty : (d.MiddleName + " ")) + ((d.LastName == null || d.LastName.Trim() == string.Empty) ? string.Empty : (d.LastName + " ")),
                            PlotNo = l.PlotNo,
                            ThramNo = x.ThramNo,
                            PrimaryMobileNo = d.MobileNo,
                            LandOwnershipId = x.LandOwnershipId
                        });
            return data.ToList();
        }

        public List<WaterConnectionModel> GetWaterConnectionForUpdate(int WaterConnectionId)
        {
            var data = (from x in ctx.MstWaterConnection.Where(x => x.WaterConnectionId == WaterConnectionId)
                        join z in ctx.MstZone on x.ZoneId equals z.ZoneId
                        join ot in ctx.EnumOwnerType on x.OwnerTypeId equals ot.OwnerTypeId
                        join wct in ctx.MstWaterConnectionType on x.WaterConnectionTypeId equals wct.WaterConnectionTypeId
                        join wlt in ctx.MstWaterLineType on x.WaterLineTypeId equals wlt.WaterLineTypeId
                        join wmt in ctx.MstWaterMeterType on x.WaterMeterTypeId equals wmt.WaterMeterTypeId                      
                        join wcs in ctx.EnumWaterConnectionStatus on x.WaterConnectionStatusId equals wcs.WaterConnectionStatusId                      

                        select new WaterConnectionModel
                        {
                            ConsumerNo = x.ConsumerNo,
                            WaterMeterNo = x.WaterMeterNo,
                            ZoneId = x.ZoneId,
                            ZoneName = z.ZoneName,
                            OwnerTypeId = x.OwnerTypeId,
                            OwnerType = ot.OwnerType,
                            FlatNo = x.FlatNo,
                            PrimaryMobileNo = x.PrimaryMobileNo,
                            WaterConnectionTypeId = x.WaterConnectionTypeId,
                            WaterConnectionType = wct.WaterConnectionType,
                            WaterLineTypeId = x.WaterLineTypeId,
                            WaterLineType = wlt.WaterLineType,
                            WaterMeterTypeId = x.WaterMeterTypeId,
                            WaterMeterType = wmt.WaterMeterType,
                            WaterConnectionStatusId = x.WaterConnectionStatusId,
                            WaterConnectionStatus = wcs.WaterConnectionStatus,
                            ConnectionDate = x.ConnectionDate,
                            InitialReading = x.InitialReading,
                            StandardCosumption = x.StandardConsumption,
                            NoOfUnits = x.NoOfUnits,
                            BillingAddress = x.BillingAddress,
                            Remarks = x.Remarks,
                            WaterConnectionId = x.WaterConnectionId

                        });
            return data.ToList();
        }

        public int UpdateWaterConnection(WaterConnectionModel obj)
        {
            try
            {
                using (TransactionScope s = new TransactionScope())
                {
                    var Data = ctx.MstWaterConnection.FirstOrDefault(u => u.WaterConnectionId == obj.WaterConnectionId);
                    Data.ZoneId = obj.ZoneId;
                    Data.BillingAddress = obj.BillingAddress;
                    Data.WaterLineTypeId = obj.WaterLineTypeId;
                    Data.PrimaryMobileNo = obj.PrimaryMobileNo;
                    Data.WaterMeterTypeId = obj.WaterMeterTypeId;
                    Data.Remarks = obj.Remarks;
                    Data.ModifiedBy = obj.ModifiedBy;
                    Data.ModifiedOn = obj.ModifiedOn;
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


        public int MeterReplacement(WaterConnectionModel obj)
        {
            try
            {
                using (TransactionScope s = new TransactionScope())
                {
                    var Data = ctx.MstWaterConnection.FirstOrDefault(u => u.WaterConnectionId == obj.WaterConnectionId);
                
                    Data.WaterLineTypeId = obj.WaterLineTypeId;
                    Data.WaterMeterNo = obj.WaterMeterNo;
                    Data.WaterMeterTypeId = obj.WaterMeterTypeId;
                    Data.Remarks = obj.Remarks;
                    Data.ModifiedBy = obj.ModifiedBy;
                    Data.ModifiedOn = obj.ModifiedOn;
                    Data.InitialReading = 0;
                    ctx.SaveChanges();
                    
                        
                        
                  var entitymaxReadingId = ctx.TblWaterMeterReading.Where(u => u.WaterConnectionId == obj.WaterConnectionId).Max(y => y.WaterMeterReadingId);

                    var entitywr = ctx.TblWaterMeterReading.Where(u => u.WaterMeterReadingId == entitymaxReadingId);
                    entitywr.FirstOrDefault().PreviousReading = 0;
                    entitywr.FirstOrDefault().PreviousReadingDate = DateTime.Now;
                    entitywr.FirstOrDefault().Consumption = 0;
                    entitywr.FirstOrDefault().Reading = 0;
                    entitywr.FirstOrDefault().ReadingDate = DateTime.Now;
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
   
