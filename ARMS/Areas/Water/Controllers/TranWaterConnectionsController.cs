using AutoMapper;
using CORE_BLL;
using CORE_BOL;
using CORE_BOL.Entities;
using CORE_DLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ARMS.Areas.Water.Controllers
{
    [Area("Water")]

    public class TranWaterConnectionsController : Controller
    {
        private readonly tt_dbContext _context;
        private readonly IMapper _mapper;
        ICommonFunction _CommonRepo = new CommonFunctionBLL();
        readonly ITranWaterConnection _repository = new TranWaterConnectionBLL();
        readonly ITranWaterConnection _obj = new TranWaterConnectionBLL();

        public TranWaterConnectionsController(tt_dbContext context)
        {
            _context = context;
        }

        [Route("Water/TranWaterConnections")]
        public async Task<IActionResult> Index()
        {
            _ = new List<TranWaterConnectionModel>();
            IList<TranWaterConnectionModel> obj = _repository.GetAll();
            return View(obj);
        }
        [Route("Water/TranWaterConnections/Details")]
        public async Task<IActionResult> Details(int? id)
        {
                if (id == null)
                {
                    return NotFound();
                }

                var data = await _repository.Details(id);
                if (data == null)
                {
                    return NotFound();
                }

                return View(data);
        }
        

            [Route("Water/TranWaterConnections/Create")]
            public IActionResult Create()
            {
            _ = new List<TranWaterConnectionModel>();
            IList<TranWaterConnectionModel> obj = _repository.GetAll();
            PopulateDropDowns();
                return View();
            }
            private void PopulateDropDowns()
            {
                ViewData["WorkLevelId"] = _CommonRepo.SelectListWorkLevel();
                ViewData["WaterMeterTypeId"] = _CommonRepo.SelectListWaterMeterType();
                ViewData["WaterConnectionStatusId"] = _CommonRepo.SelectListWaterConnectionStatus();
                ViewData["WaterConnectionTypeId"] = _CommonRepo.SelectListWaterConnectionType();
                ViewData["WaterLineTypeId"] = _CommonRepo.SelectListWaterLineType();
                ViewData["ZoneId"] = _CommonRepo.SelectListZone();
                ViewData["OwnerTypeId"] = _CommonRepo.SelectListOwnerType();
                ViewData["TaxPayerProfileId"] = _CommonRepo.SelectListTaxPayerProfile();

            }
        [HttpPost]
        [Route("Water/TranWaterConnections/SaveNewwaterConnection")]
        public JsonResult SaveNewwaterConnection([FromBody] List<TranWaterConnectionModel> json_data)
        {
            if (json_data == null)
            {
                json_data = new List<TranWaterConnectionModel>();
            }
            TranWaterConnectionModel obj = new TranWaterConnectionModel();

            bool CreateCheckDuplicate = _repository.DuplicateCheckOnSave(obj.ConsumerNo);
            if (CreateCheckDuplicate)
            {
                TempData["msg"] = "Duplicate data found, please enter a different Water Connection";
                PopulateDropDowns();
                return null;
            }
            long returnvalue = 0;
            //TranWaterConnectionModel obj = new TranWaterConnectionModel();
           
            foreach (TranWaterConnectionModel item in json_data)
            {
                // obj.MiscellaneousRecordId = item.MiscellaneousRecordId;
                obj.WaterConnectionStatusId = item.WaterConnectionStatusId;
                obj.WaterMeterNo = item.WaterMeterNo;
                obj.WaterMeterTypeId = item.WaterMeterTypeId;
                obj.ConsumerNo = item.ConsumerNo;
                obj.ConnectionDate = item.ConnectionDate;
                obj.WaterLineTypeId = item.WaterLineTypeId;
                obj.StandardCosumption = item.StandardCosumption;
                obj.BillingAddress = item.BillingAddress;
                obj.ZoneId = item.ZoneId;
                obj.FlatNo = item.FlatNo;
                obj.InitialReading = item.InitialReading;
                obj.OrganisationName = item.OrganisationName;
                obj.Remarks = item.Remarks;
                obj.NoOfUnits = item.NoOfUnits;
                obj.OwnerTypeId = item.OwnerTypeId;
                obj.PrimaryMobileNo = item.PrimaryMobileNo;
                obj.SecondaryMobileNo = item.SecondaryMobileNo;
                obj.WaterConnectionTypeId = item.WaterConnectionTypeId;
                obj.LandDetailId = item.LandDetailId;
                obj.LandOwnershipId = item.LandOwnershipId;
                obj.TaxPayerId = item.TaxPayerId;
                obj.CreatedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
                obj.CreatedOn = DateTime.Now;
                obj.IPC = item.IPC;
              
                returnvalue = _repository.Save(obj);
            }
            //try
            //{


            //    if (returnvalue > 0)
            //    {
            //        return Json(returnvalue);
            //    }
            //    else
            //    {
            //        return Json(returnvalue);

            //    }
            //}
            //catch (DbUpdateConcurrencyException)
            //{

            //}

            return Json(returnvalue);

        }
            //[HttpPost]
            //[ValidateAntiForgeryToken]
            //[Route("Water/TranWaterConnections/Create")]
            //public async Task<IActionResult> Create(TranWaterConnectionModel obj)
            //{
            //    obj.CreatedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            //    obj.CreatedOn = DateTime.Now;

            //    bool CreateCheckDuplicate = _repository.DuplicateCheckOnSave(obj.ConsumerNo);
            //    if (CreateCheckDuplicate)
            //    {
            //        TempData["msg"] = "Duplicate data found, please enter a different Water Connection";
            //        PopulateDropDowns();
            //        return View(obj);
            //    }
            //    if (ModelState.IsValid)
            //    {
            //        int returnvalue = _repository.Save(obj);

            //        if (returnvalue > 0)
            //        {
            //            TempData["msg"] = "New record created successfully";
                        
            //        }
            //        else
            //        {
            //            TempData["msg"] = "New record creation failed";
                        
            //        }

            //    }
            //    PopulateDropDowns();

            //    return View(obj);
            //}

            [HttpGet]
            [Route("Water/TranWaterConnections/Edit")]
            public async Task<IActionResult> Edit(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var Data = await _repository.Details(id);
                if (Data == null)
                {
                    return NotFound();
                }
            PopulateDropDowns();
           
            return View(Data);
            }

            [HttpPost]
            [ValidateAntiForgeryToken]
            [Route("Water/TranWaterConnections/Edit")]
            public async Task<IActionResult> Edit(TranWaterConnectionModel obj)
            {
                obj.ModifiedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
                obj.ModifiedOn = DateTime.Now;

                //bool CheckDuplicate = _repository.DuplicateCheckOnUpdate(obj.ConsumerNo, obj.WaterConnectionId, obj.LandDetailId, obj.WaterMeterTypeId, obj.WaterConnectionTypeId, obj.WaterLineTypeId, obj.ZoneId, obj.OwnerTypeId);
                //if (CheckDuplicate)
                //{
                //    TempData["msg"] = "Duplicate data found, please enter a different Water Connection";
                //    PopulateDropDowns();
                //    return View(obj);
                //}
                var Data = await _repository.Details((int?)obj.TrnWaterConnectionId);
                if (Data.TrnWaterConnectionId != obj.TrnWaterConnectionId)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        int returnvalue = _repository.Update(obj);
                        if (returnvalue > 0)
                        {
                            TempData["msg"] = "Record updated successfully";
                            return RedirectToAction(nameof(Index));
                        }
                        else
                        {
                            TempData["msg"] = "Error while updating";
                        }
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!MstWaterConnectionExists((int)obj.TrnWaterConnectionId))
                        {
                            TempData["msg"] = "No record found.";
                            return RedirectToAction(nameof(Edit));
                        }
                        else
                        {
                            throw;
                        }
                    }

                }
            PopulateDropDowns();

            return View(obj);
            }

            [Route("Water/TranWaterConnections/Delete")]
            public async Task<IActionResult> Delete(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var mstWaterConnection = await _repository.Details(id);
                if (mstWaterConnection == null)
                {
                    return NotFound();
                }

                return View(mstWaterConnection);
            }

            [HttpPost, ActionName("Delete")]
            [ValidateAntiForgeryToken]
            [Route("Water/TranWaterConnections/Delete")]

            public async Task<IActionResult> DeleteConfirmed(TranWaterConnectionModel obj)
            {
                await _repository.DeleteConfirmed(obj.WaterConnectionId);
                return RedirectToAction(nameof(Index));
            }

            private bool MstWaterConnectionExists(int id)
            {
                return _context.MstWaterConnection.Any(e => e.WaterConnectionId == id);
            }

            [Route("Water/TranWaterConnections/GetTranWaterConnectionDetails")]
            public List<TranWaterConnectionModel> GetTranWaterConnectionDetails(int id)
            {
                List<TranWaterConnectionModel> _dList = null;
                return _dList = _repository.GetTranWaterConnectionDetails(id);
            }

            [Route("Water/TranWaterConnections/fetchLandOwnershipDetails")]
            public List<GetLandOwnershipDetails> fetchLandOwnershipDetails(string cid, string ttin)
            {
                List<GetLandOwnershipDetails> _dList = null;
                return _dList = _repository.fetchLandOwnershipDetails(cid, ttin);
            }


        [Route("Water/TranWaterConnections/MeterReconnection")]
        public async Task<IActionResult> MeterReconnection()
        {
            return View();
        }
        [Route("Water/TranWaterConnections/MeterReplacement")]
        public async Task<IActionResult> MeterReplacement()
        {
            PopulateDropDowns();
            return View();
        }
        [Route("Water/TranWaterConnections/MeterReplacementwithoutdemand")]
        public async Task<IActionResult> MeterReplacementwithoutdemand()
        {
            PopulateDropDowns();
            return View();
        }
        [Route("Water/TranWaterConnections/MeterShifting")]
        public async Task<IActionResult> MeterShifting()
        {
            PopulateDropDowns();
            return View();
        }

        [Route("Water/TranWaterConnections/SewerageIndex")]
        public async Task<IActionResult> SewerageIndex()
        {
            _ = new List<SewerageConnectionVM>();
            IList<SewerageConnectionVM> obj = _repository.GetSewerage();
            return View(obj);
        }
        [Route("Water/TranWaterConnections/SewerageConnection")]
        public async Task<IActionResult> SewerageConnection()
        {
            return View();
        }

        [Route("water/TranWaterConnections/fetchWaterConnection")]
        public List<TranWaterConnectionModel> fetchWaterConnection(string Cid, string Ttin)
        {

            List<TranWaterConnectionModel> _dList = null;
            return _dList = _repository.fetchWaterConnection(Cid, Ttin);
        }

        //Water Disconnection
        [Route("water/TranWaterConnections/WaterDisconnection")]
        public IActionResult WaterDisconnection()
        {
            PopulateDropDowns();
            return View();
        }

        [Route("water/TranWaterConnections/GetWaterDisconnection")]
        public List<WaterConnectionModel> GetWaterDisconnection(string cid, string ttin, string consumerno, string meterno)
        {
            List<WaterConnectionModel> _dList = null;

            return _dList = _repository.getWaterDisconnection(cid, ttin, consumerno, meterno);
        }

        [Route("water/TranWaterConnections/GetWaterConnectionDetails")]
        public List<WaterConnectionModel> GetWaterConnectionDetails(int? id)
        {
            List<WaterConnectionModel> _dList = null;

            return _dList = _repository.getWaterConnectionDetails(id);
        }


        [Route("water/TranWaterConnections/FetchWaterConnectionDetails")]
        public List<WaterConnectionModel> fetchWaterConnectionDetails(string watermeterno)
        {
            List<WaterConnectionModel> _dList = null;

            return _dList = _repository.fetchWaterConnectionDetails(watermeterno);
        }


        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //[Route("Water/TranWaterConnections/saveWaterDisconnection")]
        //public IActionResult saveWaterDisconnection(TranWaterConnectionModel obj)
        //{
        //    obj.CreatedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
        //    obj.CreatedOn = DateTime.Now;

        //    if (obj.IsPermanentDisconnect == true)
        //    {
        //        obj.IsPermanentDisconnect = true;
        //    }
        //    else
        //    {
        //        obj.IsPermanentDisconnect = false;
        //    }

        //    bool CreateCheckDuplicate = _repository.DuplicateCheckOnSave(obj.ConsumerNo);
        //    if (CreateCheckDuplicate)
        //    {
        //        TempData["msg"] = "Duplicate data found, please enter a different Water Connection";
        //        PopulateDropDowns();
        //        return View(obj);
        //    }
        //    if (ModelState.IsValid)
        //    {
        //        int returnvalue = _repository.SaveWaterDisconnection(obj);

        //        if (returnvalue > 0)
        //        {
        //            TempData["msg"] = "New record created successfully";
        //            return RedirectToAction(nameof(WaterDisconnection));
        //        }
        //        else
        //        {
        //            TempData["msg"] = "New record creation failed";
        //            return RedirectToAction(nameof(WaterDisconnection));
        //        }

        //    }
        //    PopulateDropDowns();

        //    return View(obj);
        //}


        //for Meter Replacement
        [Route("water/TranWaterConnections/fetchWaterConnectionMR")]
        public List<TranWaterConnectionModel> fetchWaterConnectionMR(string cid, string ttin, string ConsumerNo, string MeterNo)
    {

            List<TranWaterConnectionModel> _dList = null;
            return _dList = _repository.fetchWaterConnectionMR(cid, ttin, ConsumerNo, MeterNo);
        }


        //for Meter Replacement
        [Route("water/TranWaterConnections/GetWaterDetails")]
        public List<WaterConnectionModel> GetWaterDetails(int? id)
        {
            List<WaterConnectionModel> _dList = null;

            return _dList = _repository.GetWaterDetails(id);
        }

        //for Meter Replacement
        [Route("water/TranWaterConnections/GetReadingDetails")]
        public List<TranWaterConnectionModel> GetReadingDetails(int? id)
        {
            List<TranWaterConnectionModel> _dList = null;

            return _dList = _repository.GetReadingDetails(id);
        }


        //SearchBox for TranwaterConnection
        [Route("water/TranWaterConnections/fetchWaterConnections")] 
        public List<TranWaterConnectionModel> fetchWaterConnections(string cid, string ttin, string ConsumerNo, string MeterNo)
        {

            List<TranWaterConnectionModel> _dList = null;
            return _dList = _obj.fetchWaterConnections(cid, ttin, ConsumerNo, MeterNo);
        }


        //SearchBox for fetchWaterReconnection
        [Route("water/TranWaterConnections/fetchWaterReconnection")]
        public List<TranWaterConnectionModel> fetchWaterReconnection(string cid, string ttin, string ConsumerNo, string MeterNo)
        {

            List<TranWaterConnectionModel> _dList = null;
            return _dList = _obj.fetchWaterReconnection(cid, ttin, ConsumerNo, MeterNo);
        }
        //Displaying LandDetails for WaterReconnection
        [Route("water/TranWaterConnections/GetLandDetails")]
        public List<LandDetailModel> GetLandDetails(int? id)
        {
            List<LandDetailModel> _dList = null;

            return _dList = _repository.GetLandDetails(id);
        }

        //Water Reconnection Start//

        [Route("water/TranWaterConnections/GetDisconnectWaterDetails")]
        public List<TranWaterConnectionModel> GetDisconnectWaterDetails(int? id)
        {
            List<TranWaterConnectionModel> _dList = null;

            return _dList = _repository.GetDisconnectWaterDetails(id);
        }

        [Route("water/TranWaterConnections/WaterMerterReadingMReconnection")]
        public List<TranWaterConnectionModel> WaterMerterReadingMReconnection(int? id)
        {
            List<TranWaterConnectionModel> _dList = null;

            return _dList = _repository.WaterMerterReadingMReconnection(id);
        }

        [HttpPost]
        [Route("water/TranWaterConnections/CreateWaterReconnection")]
        public JsonResult CreateWaterReconnection([FromBody] List<TranWaterConnectionModel> json_data)
        {
            if (json_data == null)
            {
                json_data = new List<TranWaterConnectionModel>();
            }
            int returnvalue = 0; // 

            TranWaterConnectionModel obj = new TranWaterConnectionModel();
            foreach (TranWaterConnectionModel item in json_data)
            {
                obj.LandDetailId = item.LandDetailId;
                obj.WaterConnectionStatusId = item.WaterConnectionStatusId;
                obj.WaterMeterNo = item.WaterMeterNo;
                obj.WaterMeterTypeId = item.WaterMeterTypeId;
                obj.ConsumerNo = item.ConsumerNo;
                obj.ApplicationDate = DateTime.Now;
                obj.SewerageConnection = item.SewerageConnection;
                obj.WaterConnectionTypeId = item.WaterConnectionTypeId;
                obj.WaterLineTypeId = item.WaterLineTypeId;
                obj.StandardCosumption = item.StandardCosumption;
                obj.CreatedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
                obj.CreatedOn = DateTime.Now;
                obj.BillingAddress = item.BillingAddress;
                obj.ZoneId = item.ZoneId;
                obj.FlatNo = item.FlatNo;
                obj.InitialReading = item.InitialReading;
                obj.OrganisationName = item.OrganisationName;
                obj.IsActive = true;
                obj.Remarks = item.Remarks;
                obj.ReUse = true;
                obj.DisconnectDate = item.DisconnectDate;
                obj.NoOfUnits = item.NoOfUnits;
                obj.OwnerTypeId = item.OwnerTypeId;
                obj.ChangeTypeId = item.ChangeTypeId;
                obj.ReconnectionDate = DateTime.Now;
                obj.SewarageConnectionDate = item.SewarageConnectionDate;
                obj.SewarageConnectedBy = item.SewarageConnectedBy;
                obj.PrimaryMobileNo = item.PrimaryMobileNo;
                obj.SecondaryMobileNo = item.SecondaryMobileNo;
                obj.IsPermanentDisconnect = item.IsPermanentDisconnect;
                //obj.ApprovalStatusId = item.ApprovalStatusId;
                obj.LandOwnershipId = item.LandOwnershipId;
                obj.ReadingDate = DateTime.Now;
                obj.previousReadingDate = item.previousReadingDate;
                obj.previousReading = item.previousReading;
                obj.WorkLevelId = 3;
                obj.OldWaterConnectionId = item.OldWaterConnectionId;
                obj.TaxPayerId = item.TaxPayerId;

                returnvalue = _repository.Savewaterreconnection(obj);
            }
            

            return Json(returnvalue);

        }
        //Water Reconnection End//

        //Meter Shifting Start//
        [Route("water/TranWaterConnections/DisplayWaterReconnectionDetail")]
        public List<TranWaterConnectionModel> DisplayWaterReconnectionDetail(int id)
        {

            List<TranWaterConnectionModel> _dList = null;

            return _dList = _repository.DisplayWaterReconnectionDetail(id);
        }

        [Route("water/TranWaterConnections/GetWaterMeterDetails")]
        public List<TranWaterConnectionModel> GetWaterMeterDetails(int id)
        {

            List<TranWaterConnectionModel> _dList = null;

            return _dList = _repository.GetWaterMeterDetails(id);
        }

        [Route("water/TranWaterConnections/DisplayMeterShiftingDetail")]
        public List<TranWaterConnectionModel> DisplayMeterShiftingDetail(int id)
        {
            //ViewData["LandDetailId"] = _CommonRepo.SelectListPlotWithOwnership(id);

            List<TranWaterConnectionModel> _dList = null;

            return _dList = _repository.DisplayMeterShiftingDetail(id);
        }

        [HttpPost]
        [Route("water/TranWaterConnections/CreateMetershifting")]
        public JsonResult CreateMetershifting([FromBody] List<TranWaterConnectionModel> json_data)
        {
            if (json_data == null)
            {
                json_data = new List<TranWaterConnectionModel>();
            }
            int returnvalue = 0; // 

            TranWaterConnectionModel obj = new TranWaterConnectionModel();
            foreach (TranWaterConnectionModel item
                in json_data)
            {
                obj.LandDetailId = item.LandDetailId;
                obj.WaterConnectionStatusId = item.WaterConnectionStatusId;
                obj.WaterMeterNo = item.WaterMeterNo;
                obj.WaterMeterTypeId = item.WaterMeterTypeId;
                obj.ConsumerNo = item.ConsumerNo;
                obj.ApplicationDate = DateTime.Now;
                obj.SewerageConnection = item.SewerageConnection;
                obj.WaterConnectionTypeId = item.WaterConnectionTypeId;
                obj.WaterLineTypeId = item.WaterLineTypeId;
                obj.StandardCosumption = item.StandardCosumption;
                obj.CreatedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
                obj.CreatedOn = DateTime.Now;
                obj.BillingAddress = item.BillingAddress;
                obj.ZoneId = item.ZoneId;
                obj.FlatNo = item.FlatNo;
                obj.InitialReading = item.InitialReading;
                obj.OrganisationName = item.OrganisationName;
                obj.IsActive = true;
                obj.Remarks = item.Remarks;
                obj.ReUse = true;
                obj.DisconnectDate = item.DisconnectDate;
                obj.NoOfUnits = item.NoOfUnits;
                obj.OwnerTypeId = item.OwnerTypeId;
                obj.ChangeTypeId = item.ChangeTypeId;
                obj.ReconnectionDate = DateTime.Now;
                obj.SewarageConnectionDate = item.SewarageConnectionDate;
                obj.SewarageConnectedBy = item.SewarageConnectedBy;
                obj.PrimaryMobileNo = item.PrimaryMobileNo;
                obj.SecondaryMobileNo = item.SecondaryMobileNo;
                obj.IsPermanentDisconnect = item.IsPermanentDisconnect;
                obj.LandOwnershipId = item.LandOwnershipId;
                obj.ReadingDate = DateTime.Now;
                obj.previousReadingDate = item.previousReadingDate;
                obj.previousReading = item.previousReading;
                obj.WorkLevelId = 3;
                obj.OldWaterConnectionId = item.OldWaterConnectionId;
                obj.TaxPayerId = item.TaxPayerId;

                returnvalue = _repository.Savewatermetershifting(obj);
            }
            return Json(returnvalue);


        }
        //Meter Shifting End//


        //for Meter Replacement
        [Route("water/TranWaterConnections/getWaterConnectionDetailsMR")]
        public List<TranWaterConnectionModel> getWaterConnectionDetailsMR(int id)
        {
            List<TranWaterConnectionModel> _dList = null;

            return _dList = _repository.getWaterConnectionDetailsMR(id);
        }

        //for Meter Replacement
        [Route("water/TranWaterConnections/fetchPlotDetails")]
        public List<TranWaterConnectionModel> fetchPlotDetails(string Plotno)
        {

            List<TranWaterConnectionModel> _dList = null;
            return _dList = _repository.fetchPlotDetails(Plotno);
        }

        //for Meter Replacement
        [HttpPost]
        [Route("water/TranWaterConnections/SaveWaterMeterReplacement")]
        public JsonResult SaveWaterMeterReplacement([FromBody] List<TranWaterConnectionModel> json_data)
        {
            int returnvalue = 0;
            if (json_data == null)
            {
                json_data = new List<TranWaterConnectionModel>();
            }
            TranWaterConnectionModel obj = new TranWaterConnectionModel();

            foreach (TranWaterConnectionModel item in json_data)
            {

                //obj.WaterConnectionId = item.WaterConnectionId;
                obj.LandDetailId = item.LandDetailId;
                obj.WaterConnectionStatusId = 1;
                obj.WaterMeterNo = item.WaterMeterNo;
                obj.WaterMeterTypeId = item.WaterMeterTypeId;
                obj.ConsumerNo = item.ConsumerNo;
                obj.ApplicationDate = DateTime.Now;
                obj.SewerageConnection = true;
                obj.WaterConnectionTypeId = item.WaterConnectionTypeId;
                obj.WaterLineTypeId = item.WaterLineTypeId;
                obj.StandardCosumption = item.StandardCosumption;
                obj.CreatedOn = DateTime.Now;
                obj.CreatedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
                obj.BillingAddress = item.BillingAddress;
                obj.ZoneId = item.ZoneId;
                obj.FlatNo = item.FlatNo;
                obj.InitialReading = item.InitialReading;
                obj.OrganisationName = item.OrganisationName;
                obj.IsActive = item.IsActive;
                obj.Remarks = item.Remarks;
                obj.ReUse = true;
                obj.DisconnectDate = item.DisconnectDate;
                obj.NoOfUnits = item.NoOfUnits;
                obj.OwnerTypeId = item.OwnerTypeId;
                obj.ChangeTypeId = item.ChangeTypeId;
                obj.ReconnectionDate = item.ReconnectionDate;
                obj.SewarageConnectionDate = item.SewarageConnectionDate;
                obj.SewarageConnectedBy = item.SewarageConnectedBy;
                obj.PrimaryMobileNo = item.PrimaryMobileNo;
               
                obj.IsPermanentDisconnect = item.IsPermanentDisconnect;
                obj.LandOwnershipId = item.LandOwnershipId;
                obj.ReadingDate = item.ReadingDate;
                obj.previousReadingDate = item.previousReadingDate;
                obj.previousReading = item.previousReading;
                obj.OldWaterConnectionId = item.OldWaterConnectionId;
                obj.TaxPayerId = item.TaxPayerId;
                
                returnvalue = _repository.SaveWaterMeterReplacement(obj);

            }

            PopulateDropDowns();
            return Json(returnvalue);
        }
        //end


        //for Meter Replacement without demand 
        [HttpPost]
        [Route("water/TranWaterConnections/SaveWaterMeterReplacementwithoutdemand")]
        public JsonResult SaveWaterMeterReplacementwithoutdemand([FromBody] List<TranWaterConnectionModel> json_data)
        {
            int returnvalue = 0;
            if (json_data == null)
            {
                json_data = new List<TranWaterConnectionModel>();
            }
            TranWaterConnectionModel obj = new TranWaterConnectionModel();

            foreach (TranWaterConnectionModel item in json_data)
            {

                //obj.WaterConnectionId = item.WaterConnectionId;
                obj.LandDetailId = item.LandDetailId;
                obj.WaterConnectionStatusId = 1;
                obj.WaterMeterNo = item.WaterMeterNo;
                obj.WaterMeterTypeId = item.WaterMeterTypeId;
                obj.ConsumerNo = item.ConsumerNo;
                obj.ApplicationDate = DateTime.Now;
                obj.SewerageConnection = true;
                obj.WaterConnectionTypeId = item.WaterConnectionTypeId;
                obj.WaterLineTypeId = item.WaterLineTypeId;
                obj.StandardCosumption = item.StandardCosumption;
                obj.CreatedOn = DateTime.Now;
                obj.CreatedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
                obj.BillingAddress = item.BillingAddress;
                obj.ZoneId = item.ZoneId;
                obj.FlatNo = item.FlatNo;
                obj.InitialReading = item.InitialReading;
                obj.OrganisationName = item.OrganisationName;
                obj.IsActive = item.IsActive;
                obj.Remarks = item.Remarks;
                obj.ReUse = true;
                obj.DisconnectDate = item.DisconnectDate;
                obj.NoOfUnits = item.NoOfUnits;
                obj.OwnerTypeId = item.OwnerTypeId;
                obj.ChangeTypeId = item.ChangeTypeId;
                obj.ReconnectionDate = item.ReconnectionDate;
                obj.SewarageConnectionDate = item.SewarageConnectionDate;
                obj.SewarageConnectedBy = item.SewarageConnectedBy;
                obj.PrimaryMobileNo = item.PrimaryMobileNo;

                obj.IsPermanentDisconnect = item.IsPermanentDisconnect;
                obj.LandOwnershipId = item.LandOwnershipId;
                obj.ReadingDate = item.ReadingDate;
                obj.previousReadingDate = item.previousReadingDate;
                obj.previousReading = item.previousReading;
                obj.OldWaterConnectionId = item.OldWaterConnectionId;
                obj.TaxPayerId = item.TaxPayerId;

                returnvalue = _repository.SaveWaterMeterReplacementwithourDemand(obj);

            }

            PopulateDropDowns();
            return Json(returnvalue);
        }
        //end


        [Route("water/TranWaterConnections/GetWaterConnectionDemand")]
        public List<WaterconnectionDemandVM> GetWaterConnectionDemand(int TransactionId)
            {
            List<WaterconnectionDemandVM> _dList = null;

            return _dList = _repository.PrintDemandWater(TransactionId);
        }

        [Route("water/TranWaterConnections/checkpayment")]
        public List<WaterconnectionDemandVM> checkpayment(int WaterConnectionId)
        {
            List<WaterconnectionDemandVM> _dList = null;

            return _dList = _repository.checkpayment(WaterConnectionId);
        }

        [HttpPost]
        [Route("water/TranWaterConnections/savewaterdisconnection")]
        public JsonResult savewaterdisconnection([FromBody] List<TranWaterConnectionModel> json_data)
        {
            if (json_data == null)
            {
                json_data = new List<TranWaterConnectionModel>();
            }
            int returnvalue = 0; // 

            TranWaterConnectionModel obj = new TranWaterConnectionModel();
            foreach (TranWaterConnectionModel item in json_data)
            {
                
                obj.WaterConnectionId = item.WaterConnectionId;
                obj.DisconnectDate = DateTime.Now;
                obj.Remarks = item.Remarks;
                obj.IPD = item.IPD;
                returnvalue = _repository.SaveWaterDisconnection(obj);
            }


            return Json(returnvalue);

        }


        //SEWERAGE CONNECTION ENTRY
        [HttpPost]
        [Route("Water/TranWaterConnections/SaveSewerageConnection")]
        public JsonResult SaveSewerageConnection([FromBody] List<TranWaterConnectionModel> json_data)
        {
            if (json_data == null)
            {
                json_data = new List<TranWaterConnectionModel>();
            }
            TranWaterConnectionModel obj = new TranWaterConnectionModel();

            bool CreateCheckDuplicate = _repository.DuplicateCheckOnSewerage(obj.SewerageConnectionId);

            if (CreateCheckDuplicate)
            {
                TempData["msg"] = "Duplicate data found, please enter a different Sewerage Connection";
                PopulateDropDowns();
                return null;
            }
            long returnvalue = 0;

            foreach (TranWaterConnectionModel item in json_data)
            {
                obj.CAddress = item.CAddress;
                obj.PhoneNo = item.PhoneNo;
                obj.LandOwnershipId = item.LandOwnershipId;
                obj.CreatedOn = DateTime.Now;
                obj.CreatedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
                obj.TaxPayerId = item.TaxPayerId;


                returnvalue = _repository.SaveSewerage(obj);
            }
            

            return Json(returnvalue);

        }

        [Route("water/TranWaterConnections/GetSewerageConnectionDemand")]
        public List<WaterconnectionDemandVM> GetSewerageConnectionDemand(int TransactionId)
        {
            List<WaterconnectionDemandVM> _dList = null;

            return _dList = _repository.PrintDemandSewerage(TransactionId);
        }


        //************************************************Upgrade and downgrade***********************************************************************************************

        [Route("Water/TranWaterConnections/upanddowngrade")]
        public IActionResult upanddowngrade()
        {
            _ = new List<TranWaterConnectionModel>();
            IList<TranWaterConnectionModel> obj = _repository.GetAll();
            PopulateDropDowns();
            return View();
        }
        

        [Route("Water/TranWaterConnections/fetchtaxpayer")]
        public List<GetLandOwnershipDetails>fetchtaxpayer(string cid, string ttin)
        {
            List<GetLandOwnershipDetails> _dList = null;
            return _dList = _repository.fetchLandOwnershipDetails(cid, ttin);
        }


        [Route("Water/TranWaterConnections/Getwaterdetailstoupgadeanddowngrate")]
        public List<TranWaterConnectionModel> Getwaterdetailstoupgadeanddowngrate(int id)
        {
            List<TranWaterConnectionModel> _dList = null;
            return _dList = _repository.Getwaterdetailstoupgadeanddowngrate(id);
        }


        [HttpPost]
        [Route("Water/TranWaterConnections/Upgrade")]
        public JsonResult Upgrade([FromBody] List<TranWaterConnectionModel> json_data)
        {
            if (json_data == null)
            {
                json_data = new List<TranWaterConnectionModel>();
            }
            TranWaterConnectionModel obj = new TranWaterConnectionModel();

          
            long returnvalue = 0;
            //TranWaterConnectionModel obj = new TranWaterConnectionModel();

            foreach (TranWaterConnectionModel item in json_data)
            {
               
                obj.WaterConnectionId = item.WaterConnectionId;
                obj.WaterMeterReadingId = item.WaterMeterReadingId;
                obj.WaterMeterTypeId = item.WaterMeterTypeId;
                obj.ConsumerNo = item.ConsumerNo;
               
                obj.WaterLineTypeId = item.WaterLineTypeId;
                obj.StandardCosumption = item.StandardCosumption;
                obj.LandDetailId = item.LandDetailId;
                obj.LandOwnershipId = item.LandOwnershipId;
                obj.TaxPayerId = item.TaxPayerId;
                obj.InitialReading = item.InitialReading;
                obj.CreatedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));

                obj.ModifiedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
                obj.ModifiedOn = DateTime.Now;
               

                returnvalue = _repository.upgrade(obj);
            }
            
            return Json(returnvalue);

        }



        [Route("water/TranWaterConnections/Printupgrade")]
        public List<WaterconnectionDemandVM> Printupgrade(int TransactionId)
        {
            List<WaterconnectionDemandVM> _dList = null;

            return _dList = _repository.Printupgrade(TransactionId);
        }
    }

}

