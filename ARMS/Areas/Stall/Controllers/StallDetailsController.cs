﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CORE_BOL.Entities;
using CORE_BLL;
using CORE_DLL;
using CORE_BOL;
using AutoMapper;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.AspNetCore.Http;
using ARMS.Functions;
namespace ARMS.Areas.Stall.Controllers
{
    [Area("Stall")]
    public class StallDetailsController : Controller
    {
        private readonly tt_dbContext _context;

        private readonly IMapper _mapper;
        ICommonFunction _CommonRepo = new CommonFunctionBLL();

        readonly ITaxPayerProfile _obj = new TaxPayerProfileBLL();
        readonly IStallDetail _repo = new StallDetailBLL();
        readonly IStallDetail _repository = new StallDetailBLL();


        public StallDetailsController(tt_dbContext context, IMapper mapper)
        {
            _context = context; _mapper = mapper;

        }

        [Route("Stall/StallDetails")]
        public async Task<IActionResult> Index()
        {
            _ = new List<StallAllocationVM>();
            IList<StallAllocationVM> obj = _repository.GetAll();
            PopulateDropDowns();

            return View(obj);
        }

        [Route("Stall/StallDetails/Details")]
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

//**********************************************************************STALL DETAIL ENTRY***************************************************************************************
        [Route("Stall/StallDetails/Create")]
        public IActionResult Create()
        {
            PopulateDropDowns();
            return View();
        }
        [HttpPost]
        [Route("Stall/StallDetails/Create")]
        public async Task<IActionResult> Create(StallDetailVM obj)
        {
            obj.CreatedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            //obj.CreatedOn = DateTime.Now;

            //bool CreateCheckDuplicate = _repository.DuplicateCheckOnSave(obj.StallNo);
            //if (CreateCheckDuplicate)
            //{
            //    TempData["msg"] = "Duplicate data found, please enter a different Stall ";
            //    PopulateDropDowns();
            //    return View(obj);
            //}

            if (ModelState.IsValid)
            {
                int returnvalue = _repository.Save(obj);

                if (returnvalue > 0)
                {
                    TempData["msg"] = "New record created successfully";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    TempData["msg"] = " New record creation failed";
                    return RedirectToAction(nameof(Create));
                }

            }
            PopulateDropDowns();
            return View(obj);
        }

        [HttpGet]
        [Route("Stall/StallDetails/Edit")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var Data = await _repository.GetDetails(id);
            if (Data == null)
            {
                return NotFound();
            }
            PopulateDropDowns();
            return View(Data);
        }

        [HttpGet]
        [Route("Stall/StallDetails/PEdit")]
        public async Task<IActionResult> PEdit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var Data = await _repository.GetPDetails(id);
            if (Data == null)
            {
                return NotFound();
            }
            PopulateDropDowns();
            return View(Data);
        }


        [HttpPost]
        [Route("Stall/StallDetails/Edit")]
        public async Task<IActionResult> Edit(StallDetailVM obj)
        {
            obj.ModifiedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            obj.ModifiedOn = Convert.ToDateTime(DateFunctions.getDatetypefrom(DateTime.Now.ToString("dd/MM/yyyy")));

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
                    if (!TblStallDetailExists(obj.StallDetailId))
                    {
                        TempData["msg"] = "No record found";
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


        [HttpPost]
        [Route("Stall/StallDetails/PEdit")]
        public async Task<IActionResult> PEdit(StallDetailVM obj)
        {
            obj.ModifiedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            obj.ModifiedOn = Convert.ToDateTime(DateFunctions.getDatetypefrom(DateTime.Now.ToString("dd/MM/yyyy")));

            if (ModelState.IsValid)
            {
                try
                {
                    int returnvalue = _repository.PUpdate(obj);
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
                    if (!TblStallDetailExists1(obj.StallAllocationId))
                    {
                        TempData["msg"] = "No record found";
                        return RedirectToAction(nameof(PEdit));
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
        private void PopulateDropDowns()
        {
            ViewData["StallLocationId"] = _CommonRepo.SelectListStallLocations();
            ViewData["TaxPayerId"] = _CommonRepo.SelectListTaxPayerProfile();
            ViewData["BillingScheduleId"] = _CommonRepo.SelectListBillingSchedule();
            ViewData["StallDetailId"] = _CommonRepo.SelectListStallDetails();
            ViewData["RateId"] = _CommonRepo.SelectListRates();
            ViewData["StallAllocationId"] = _CommonRepo.SelectListStallAllocations();
            ViewData["StallTypeId"] = _CommonRepo.SelectListStallType();
            
        }

        [Route("Stall/StallDetails/Delete")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var TblStallDetail = await _repository.Details(id);

            if (TblStallDetail == null)
            {
                return NotFound();
            }

            return View(TblStallDetail);
        }

        [HttpPost, ActionName("Delete")]
        [Route("Stall/StallDetails/Delete")]
        public async Task<IActionResult> DeleteConfirmed(StallDetailVM obj)
        {
            await _repository.DeleteConfirmed(obj.StallDetailId);

            return RedirectToAction(nameof(Index));
        }

        private bool TblStallDetailExists(int id)
        {
            return _context.TblStallDetail.Any(e => e.StallDetailId == id);
        }
        private bool TblStallDetailExists1(int id)
        {
            return _context.TblStallPeriod.Any(e => e.StallAllocationId == id);
        }


        //*********************************************************************STALL ALLOCATION ENTRY************************************************************************************
        //
        [HttpPost]
        [Route("Stall/StallDetails/CreateStallAllocation")]
        public JsonResult CreateStallAllocation([FromBody] List<StallAllocationVM> json_data)
        {
            if (json_data == null)
            {
                json_data = new List<StallAllocationVM>();
            }
            int returnvalue = 0; // 
            StallAllocationVM obj = new StallAllocationVM();
            foreach (StallAllocationVM item in json_data)
            {
                obj.StallDetailId = item.StallDetailId;
                obj.StallAllocationId = item.StallAllocationId;
                obj.TaxPayerId = item.TaxPayerId;
                obj.BillingScheduleId = 1;
                obj.AllocationDate = item.AllocationDate;
                obj.RateId = 1;
                obj.RentalAmount = item.RentalAmount;
                obj.HasSecurityDeposit = item.HasSecurityDeposit;
                //obj.IsTerminated = item.IsTerminated;
                obj.SecurityAmount = item.SecurityAmount;
                obj.Remarks = item.Remarks;
                obj.SDate = item.SDate;
                obj.EDate = item.EDate;
                //obj.TerminatedBy = item.TerminatedBy;
                //obj.ModifiedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
                obj.CreatedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
                obj.CreatedOn = DateTime.Now;
               //obj.ModifiedOn = DateTime.Now;
                returnvalue =  _repository.SaveStallAllocation(obj);
            }
            
            return Json(returnvalue);
            
        }

//*******************************************************************************RENEW STALL ALLOCATION**********************************************************************************************
        
        [HttpPost]
        [Route("Stall/StallDetails/CreateRenewStallAllocation")]
        public JsonResult CreateRenewStallAllocation([FromBody] List<StallPeriodVM> json_data)
        {
            if (json_data == null)
            {
                json_data = new List<StallPeriodVM>();
            }
            int returnvalue = 0;
            StallPeriodVM obj = new StallPeriodVM();
            foreach (StallPeriodVM item in json_data)
            {
                obj.StallPeriodId = item.StallPeriodId;
                obj.StallAllocationId = item.StallAllocationId;
                obj.StartDate = item.StartDate;
                obj.EndDate = item.EndDate;
                obj.Remarks = item.Remarks;
                obj.RevisedRent = item.RevisedRent;
                obj.ModifiedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
                obj.CreatedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
                obj.CreatedOn = DateTime.Now;
                obj.ModifiedOn = DateTime.Now;

                returnvalue = _repository.SaveRenew(obj);
            }
            try
            {
                 // 

                if (returnvalue > 0)
                {
                    TempData["msg"] = "Record Renewed Successfully!";

                }
                else
                {
                    TempData["msg"] = "Renew failed";
                }
            }
            catch (DbUpdateConcurrencyException)
            {

            }

            return Json(TempData["msg"]);

        }

        [Route("Stall/StallDetails/GetStallDetails")]
        public List<StallDetailVM> GetStallDetails(int? id)
        {
            List<StallDetailVM> _dList = null;

            return _dList = _repository.GetStallDetails(id);
        }
       
        [Route("Stall/StallDetails/GetTaxPayer")]
        public List<TaxPayerProfileModel> GetTaxPayer(string cid, string ttin)
        {

            List<TaxPayerProfileModel> _dList = null;
            return _dList = _repository.GetTaxPayer(cid, ttin);
        }
        [Route("Stall/StallDetails/GetStallAllocationDetail")]
        public List<StallAllocationVM> GetStallAllocationDetail(int? id)
        {
            List<StallAllocationVM> _dList = null;

            return _dList = _repository.GetStallAllocationDetail(id);
        }

        [Route("Stall/StallDetails/GetRenewDetails")]
        public List<StallPeriodVM> GetRenewDetails(int? id)
        {
            List<StallPeriodVM> _dList = null;

            return _dList = _repository.GetRenewDetails(id);
        }

        [Route("Stall/StallDetails/Terminate")]
        public async Task<IActionResult> Terminate(int id)
        {
            StallAllocationVM obj = new StallAllocationVM();
            obj.StallAllocationId = id;
            return View(obj);           
        }

//********************************************************************TERMINATE STALL ALLOCATION***********************************************************************************       

        [Route("Stall/StallDetails/Terminate")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Terminate(StallAllocationVM obj)
        {
            obj.ModifiedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            obj.TerminatedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            obj.ModifiedOn = DateTime.Now;
            
            var Data = await _repository.Details(obj.StallAllocationId);       
            if (Data.IsTerminated == true)
            {
                    TempData["msg"] = "StallAllocation already Terminated!";
                    return View(obj);
            }
            if (ModelState.IsValid)
            {
                //try
                //{
                    int returnvalue = _repository.Terminate(obj);                  
                    if (returnvalue > 0)
                        {
                            TempData["msg"] = "Record Terminated Successfully";
                            return RedirectToAction(nameof(Index));
                        }
                    
                    else
                    {
                        TempData["msg"] = "Error while Terminating";
                    }                              
            }
            PopulateDropDowns();
            return View(obj);
        }
        private bool TblStallAllocationTerminateExists(int id)
        {
            return _context.TblStallAllocation.Any(e => e.StallAllocationId == id);
        }
        [Route("Stall/StallDetails/StallRentMonthlyDemand")]
        public IActionResult StallRentMonthlyDemand()
        {
            return View();
        }
        [Route("Stall/StallDetails/GetTaxPayerProfile")]
       public List<TaxPayerProfileModel> GetTaxPayerProfile(string Cid, string Ttin)
        {
            return _repository.GetTaxPayerProfile(Cid, Ttin).ToList();
        }

        //Demand Generation

        [Route("Stall/StallDetails/GetStallRentDemandByCid")]
        public List<TaxPayerProfileModel> GetStallRentDemandByCid(string cid, string ttin)
        {

            List<TaxPayerProfileModel> _dList = null;
            return _dList = _repository.fetchStallRentDemandByCid(cid, ttin);
        }

        [Route("Stall/StallDetails/StallRentDetails")]
        public List<StallDetailVM> StallRentDetails(int id)
        {

            List<StallDetailVM> _dList = null;
            return _dList = _repository.fetchStallRentDetails(id);
        }

//*****************************************************************STALL DEMAND*****************************************************************************

        [Route("Stall/StallDetails/GetStallDemandScheduleMonthly")]
        public IEnumerable<StallRentDemandScheduleModel> GetStallDemandScheduleMonthly(int Id, int yr, string StartDate, string EndDate)
        {

            IEnumerable<StallRentDemandScheduleModel> _dList = null;
            return _dList = _repository.GetStallDemandScheduleMonthly(Id, yr, StartDate, EndDate);
        }

        [Route("Stall/StallDetails/GetYear")]
        public IEnumerable<DemandYearsModel> GetYear(string StartDate, string EndDate)
        {

            IEnumerable<DemandYearsModel> _dList = null;
            return _dList = _CommonRepo.VendorDemandYears(StartDate, EndDate);
        }

        [HttpPost]
        [Route("Stall/StallDetails/GenerateDemand")]
        public long GenerateDemand(int StallAllocationId, int pDays, int pMonth, int pYear, int ScheduleId, decimal Amount, int taxPayerId, int totalDays, int StallTypeId)
        {
            int CreatedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));

            return _repository.GenerateDemand(StallAllocationId, pDays, pMonth, pYear, ScheduleId, Amount, CreatedBy, taxPayerId, totalDays, StallTypeId);
        }
        [Route("Stall/StallDetails/GetStallRentDemand")]
        public List<StallDetailVM> GetStallRentDemand(int DemandNoId)
        {

            List<StallDetailVM> _dList = null;
            return _dList = _repository.generateStallRentDemand(DemandNoId);
        }

        [Route("Stall/StallDetails/GetUserName")]
        public List<StallDetailVM> GetUserName(int DemandNoId)
        {

            List<StallDetailVM> _dList = null;
            return _dList = _repository.GetUserName(DemandNoId);
        }

        //Stall Renewal Start

        [Route("Stall/StallDetails/StallRenewal")]
        public IActionResult StallRenewal()
        {
            PopulateDropDowns();
            return View();
        }

        [Route("Stall/StallDetails/GetRenewalStallDetail")]
        public List<StallDetailVM> GetRenewalStallDetail(int? id)
        {
            List<StallDetailVM> _dList = null;

            return _dList = _repository.GetRenewalStallDetail(id);
        }
        [Route("Stall/StallDetails/GetRenewalStallAllocation")]
        public List<StallAllocationVM> GetRenewalStallAllocation(int? id)
        {
            List<StallAllocationVM> _dList = null;

            return _dList = _repository.GetRenewalStallAllocation(id);
        }

        [Route("Stall/StallDetails/GetStartDateEndDate")]
        public List<StallAllocationVM> GetStartDateEndDate(int? id)
        {
            List<StallAllocationVM> _dList = null;

            return _dList = _repository.GetStartDateEndDate(id);
        }




    }
}
