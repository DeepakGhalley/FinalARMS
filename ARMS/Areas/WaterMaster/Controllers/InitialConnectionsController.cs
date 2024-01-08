using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CORE_BOL.Entities;
using AutoMapper;
using CORE_DLL;
using CORE_BLL;
using CORE_BOL;
using Microsoft.AspNetCore.Http;
using ARMS.Functions;
//using QRCoder;
//using System.Drawing;
//using System.IO;

namespace ARMS.Areas.WaterMaster.Controllers
{
    [Area("WaterMaster")]
    public class InitialConnectionsController : Controller
    {
        private readonly tt_dbContext _context;
        private readonly IMapper _mapper;
        ICommonFunction _CommonRepo = new CommonFunctionBLL();
        readonly IInitialConnections _repository = new InitialConnectionsBLL();
        public InitialConnectionsController(tt_dbContext context)
        {
            _context = context;
        }

        private void PopulateDropDowns()
        {
            ViewData["LandDetailId"] = _CommonRepo.SelectListLandDetail();
            ViewData["LandOwnershipId"] = _CommonRepo.SelectListLandOwnershipType();
            ViewData["WaterConnectionStatusId"] = _CommonRepo.SelectListWaterConnectionStatus();
            ViewData["OwnerTypeId"] = _CommonRepo.SelectListOwnerType();
            ViewData["WaterMeterTypeId"] = _CommonRepo.SelectListWaterMeterType();
            ViewData["WaterConnectionTypeId"] = _CommonRepo.SelectListWaterConnectionType();
            ViewData["WaterLineTypeId"] = _CommonRepo.SelectListWaterLineType();
            ViewData["ZoneId"] = _CommonRepo.SelectListZone();

        }

        [Route("WaterMaster/InitialConnections/InitialConnection")]
        public IActionResult InitialConnection()
        {
            PopulateDropDowns();
            return View();
        }
       
        [Route("WaterMaster/InitialConnections/SearchConsumerNo")]
        public List<WaterConnectionModel> SearchConsumerNo(string ConsumerNo)
        {
            List<WaterConnectionModel> _dList = null;
            PopulateDropDowns();
            return _dList = _repository.SearchConsumerNo(ConsumerNo);
        }

        [Route("WaterMaster/InitialConnections/WaterMeterReading")]
        public List<WaterMeterReadingModel> WaterMeterReading(int? id)
        {
            List<WaterMeterReadingModel> _dList = null;

            return _dList = _repository.WaterMeterReading(id);
        }

        [Route("WaterMaster/InitialConnections/DisplayWaterConnectionDetail")]
        public List<WaterConnectionModel> DisplayWaterConnectionDetail(string ConsumerNo)
        {
            List<WaterConnectionModel> _dList = null;

            return _dList = _repository.DisplayWaterConnectionDetail(ConsumerNo);
        }

        [HttpPost]
        [Route("WaterMaster/InitialConnections/SaveWaterMeterReading")]
        public JsonResult SaveWaterMeterReading([FromBody] List<WaterMeterReadingModel> json_data)
        {
            if (json_data == null)
            {
                json_data = new List<WaterMeterReadingModel>();
            }
            WaterMeterReadingModel obj = new WaterMeterReadingModel();          
            long returnvalue = 0;

            foreach (WaterMeterReadingModel item in json_data)
            {
                obj.WaterConnectionId = item.WaterConnectionId;
                //obj.TransactionId = item.TransactionId;
                obj.WaterConnectionTypeId = item.WaterConnectionTypeId;
                obj.WaterMeterTypeId = item.WaterMeterTypeId;
                obj.WaterLineTypeId = item.WaterLineTypeId;
                obj.WaterConnectionStatusId = item.WaterConnectionStatusId;
                obj.zoneId = item.zoneId;
                obj.Reading = item.Reading;
                obj.IsRead = false;
                obj.ReadingDate = item.ReadingDate;
                obj.PreviousReading = item.PreviousReading;
                obj.PreviousReadingDate = item.PreviousReadingDate;
                obj.ReadBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
                obj.NoOfUnit = item.NoOfUnit;
                obj.StandardConsumption = item.StandardConsumption;
                if (item.IsPConnection == 0)
                {
                    obj.IsPermanentConnection = false;
                }
                else
                {
                    obj.IsPermanentConnection = true;
                }
                obj.SolidWaste = false;
                obj.Sewerage = true;
                obj.Remarks = "Initial Connection";
                obj.FlatNo = item.FlatNo;
                obj.BillingAddress = item.BillingAddress;
                obj.PrimaryMobileNo = item.PrimaryMobileNo;
                //obj.SecondaryMobileNo = item.SecondaryMobileNo;
                obj.Active = true;
                obj.IsDisconnected = false;
                obj.CreatedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
                obj.CreatedOn = DateTime.Now;
                obj.Consumption = 0;


                returnvalue = _repository.SaveWaterMeterReading(obj);
            }         

            return Json(returnvalue);

        }

        [HttpPost]
        [Route("WaterMaster/InitialConnections/SaveWaterConnection")]
        public JsonResult SaveWaterConnection([FromBody] List<WaterConnectionModel> json_data)
        {
            if (json_data == null)
            {
                json_data = new List<WaterConnectionModel>();
            }
            WaterConnectionModel obj = new WaterConnectionModel();
            long returnvalue = 0;

            foreach (WaterConnectionModel item in json_data)
            {
                obj.LandDetailId = item.LandDetailId;
                obj.LandOwnershipId = item.LandOwnershipId;
                obj.WaterConnectionStatusId = item.WaterConnectionStatusId;
                obj.OwnerTypeId = item.OwnerTypeId;
                obj.WaterMeterNo = item.WaterMeterNo;
                obj.WaterMeterTypeId = item.WaterMeterTypeId;
                obj.ConsumerNo = item.ConsumerNo;
                obj.WaterConnectionTypeId = item.WaterConnectionTypeId;
                obj.WaterLineTypeId = item.WaterLineTypeId;
                obj.StandardCosumption = item.StandardCosumption;
                obj.BillingAddress = item.BillingAddress;
                obj.ZoneId = item.ZoneId;
                obj.FlatNo = item.FlatNo;
                obj.InitialReading = item.InitialReading;
                obj.Remarks = item.Remarks;
                obj.NoOfUnits = item.NoOfUnits;
                obj.PrimaryMobileNo = item.PrimaryMobileNo;
                obj.SecondaryMobileNo = item.SecondaryMobileNo;
                obj.CreatedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
                obj.CreatedOn = DateTime.Now;
                obj.SewerageConnection = true;
                obj.SolidWaste = false;
                obj.IsActive = true;
                obj.IsPermanentConnect = true;
                obj.IsPermanentDisconnect = false;
                obj.PreviousReadingDate = item.PreviousReadingDate;
                obj.ReadingDate = item.ReadingDate;
                returnvalue = _repository.SaveWaterConnection(obj);
            }
            PopulateDropDowns();
            return Json(returnvalue);

        }

        [Route("WaterMaster/InitialConnections/SearchLandDetails")]
        public List<LandOwnershipDetailsVM> SearchLandDetails(string PlotNo, string ThramNo, string TTIN)
        {
            List<LandOwnershipDetailsVM> _dList = null;
            return _dList = _repository.SearchLandDetails(PlotNo, ThramNo, TTIN);
        }
    }
}
