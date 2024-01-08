using System;
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

using Microsoft.AspNetCore.Authorization;

namespace ARMS.Areas.HouseRent.Controllers
{
    [Area("HouseRent")]
    //[Authorize]
    public class HouseDetailsController : Controller
    {
        private readonly tt_dbContext _context;

        private readonly IMapper _mapper;
        ICommonFunction _CommonRepo = new CommonFunctionBLL();

        readonly IHouseDetail _obj = new HouseDetailBLL();
        readonly IHouseDetail _repo = new HouseDetailBLL();
        readonly IHouseDetail _repository = new HouseDetailBLL();

        public HouseDetailsController(tt_dbContext context, IMapper mapper)
        {
            _context = context; _mapper = mapper;

        }

        // GET: HouseRent/HouseDetails   
        [Route("HouseRent/HouseDetails/Index")]
        public async Task<IActionResult> Index()
        {
            _ = new List<HouseAllocationVM>();
            IList<HouseAllocationVM> obj = _repository.GetAll();
            PopulateDropDowns();


            return View(obj);
        }

        // GET: HouseRent/HouseDetails/Details/5
        [Route("HouseRent/HouseDetails/Details")]
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

        // GET: HouseRent/HouseDetails/Create
        [Route("HouseRent/HouseDetails/Create")]
        public IActionResult Create()
        {
            PopulateDropDowns();
            return View();
        }
        [HttpPost]
        [Route("HouseRent/HouseDetails/Create")]
        public async Task<IActionResult> Create(HouseRentDetailVM obj)
        {
            obj.CreatedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            obj.CreatedOn = DateTime.Now;

            bool CreateCheckDuplicate = _repository.DuplicateCheckOnSave(obj.HouseNo);
            if (CreateCheckDuplicate)
            {
                TempData["msg"] = "Duplicate data found, please enter a different Stall ";
               
                return View(obj);
            }
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

        // GET: HouseRent/HouseDetails/Edit/5
        [Route("HouseRent/HouseDetails/Edit")]
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

        // POST: HouseRent/HouseDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Route("HouseRent/HouseDetails/Edit")]
        public async Task<IActionResult> Edit(HouseRentDetailVM obj)
        {
            obj.ModifiedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            obj.ModifiedOn = Convert.ToDateTime(DateFunctions.getDatetypefrom(DateTime.Now.ToString("dd/MM/yyyy")));

            bool CheckDuplicate = _repository.DuplicateCheckOnUpdate(obj.HouseNo, obj.HouseDetailId);
            if (CheckDuplicate)
            {
                TempData["msg"] = "Duplicate data found, please enter a different House rent";
                PopulateDropDowns();

                return View(obj);
            }
            var Data = await _repository.Details(obj.HouseDetailId);
            if (Data.HouseDetailId != obj.HouseDetailId)

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
                    if (!TblHouseRentDetailExists(obj.HouseDetailId))
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
        private void PopulateDropDowns()
        {
            
            ViewData["TaxPayerId"] = _CommonRepo.SelectListTaxPayerProfile();
            ViewData["BillingScheduleId"] = _CommonRepo.SelectListBillingSchedule();
            ViewData["HouseAllocationId"] = _CommonRepo.SelectListHouseAllocations();
            ViewData["RateId"] = _CommonRepo.SelectListRates();
            ViewData["HouseDetailId"] = _CommonRepo.SelectListHouseDetails();


        }

        // GET: HouseRent/HouseDetails/Delete/5
        [Route("ouseRent/HouseDetails/Delete")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var TblHouseDetail = await _repository.Details(id);

            if (TblHouseDetail == null)
            {
                return NotFound();
            }

            return View(TblHouseDetail);
        }

        // POST: HouseRent/HouseDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [Route("SHouseRent/HouseDetails/Delete")]
        public async Task<IActionResult> DeleteConfirmed(HouseRentDetailVM obj)
        {
            await _repository.DeleteConfirmed(obj.HouseDetailId);

            return RedirectToAction(nameof(Index));
        }

        private bool TblHouseRentDetailExists(int id)
        {
            return _context.TblHouseDetail.Any(e => e.HouseDetailId == id);
        }


        [HttpPost]
        [Route("HouseRent/HouseDetails/CreateHouseAllocation")]
        public JsonResult CreateHouseAllocation([FromBody] List<HouseAllocationVM> json_data)
        {
            if (json_data == null)
            {
                json_data = new List<HouseAllocationVM>();
            }
            int returnvalue = 0;
            HouseAllocationVM obj = new HouseAllocationVM();
            foreach (HouseAllocationVM item in json_data)
            {
                obj.HouseAllocationId = item.HouseAllocationId;
                obj.HouseDetailId = item.HouseDetailId;
                obj.TaxPayerId = item.TaxPayerId;
                obj.BillingScheduleId = 1;
                obj.AllocationDate = item.AllocationDate;
                obj.RateId = 1;
                obj.RentalAmount = item.RentalAmount;
                obj.HasSecurityDeposit = item.HasSecurityDeposit;
                obj.SStartDate = item.SStartDate;
                obj.EEndDate = item.EEndDate;
               
                obj.SecurityAmount = item.SecurityAmount;
                obj.Remarks = item.Remarks;
                
               
                obj.CreatedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
                obj.CreatedOn = DateTime.Now;
               


                returnvalue = _repository.SaveHouseAllocation(obj);
            }
            try
            {
               // int returnvalue = 1; 

                if (returnvalue > 0)
                {
                    TempData["msg"] = "House Allocation Saved Successfully!";

                }
                else
                {
                    TempData["msg"] = "New record creation failed";
                }
            }
            catch (DbUpdateConcurrencyException)
            {

            }

            return Json(TempData["msg"]);

        }

        [Route("HouseRent/HouseDetails/GetHouseDetails")]
        public List<HouseRentDetailVM> GetHouseDetails(int? id)
        {
            List<HouseRentDetailVM> _dList = null;

            return _dList = _repository.GetHouseDetails(id);
        }
        [Route("HouseRent/HouseDetails/GetTaxPayer")]
        public List<TaxPayerProfileModel> GetTaxPayer(string cid, string ttin)
        {

            List<TaxPayerProfileModel> _dList = null;
            return _dList = _repository.GetTaxPayer(cid, ttin);
        }
        [Route("HouseRent/HouseDetails/GetHouseAllocationDetail")]
        public List<HouseAllocationVM> GetHouseAllocationDetail(int? id)
        {
            List<HouseAllocationVM> _dList = null;

            return _dList = _repository.GetHouseAllocationDetail(id);
        }

        [Route("HouseRent/HouseDetails/GetRenewDetails")]
        public List<HousePeriodVM> GetRenewDetails(int? id)
        {
            List<HousePeriodVM> _dList = null;

            return _dList = _repository.GetRenewDetails(id);
        }

        [Route("HouseRent/HouseDetails/Terminate")]
        public async Task<IActionResult> Terminate(int id)
        {
            
            HouseAllocationVM obj = new HouseAllocationVM();
            obj.HouseAllocationId = id;
            return View(obj);
        }



        [Route("HouseRent/HouseDetails/Terminate")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Terminate(HouseAllocationVM obj)
        {
            obj.ModifiedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            obj.TerminatedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            obj.ModifiedOn = Convert.ToDateTime(DateFunctions.getDatetypefrom(DateTime.Now.ToString("dd/MM/yyyy")));

            var Data = await _repository.Details(obj.HouseAllocationId);
            if (Data.HouseAllocationId != obj.HouseAllocationId)
            {
                return NotFound();
            }
            if (Data.IsTerminated == true)
            {
                TempData["msg"] = "House Allocation already Terminated!";
                return View(obj);
            }
            if (ModelState.IsValid)
            {
                try
                {
                    int returnvalue = _repository.Terminate(obj);
                    if (returnvalue > 0)
                    {
                        TempData["msg"] = "Terminated successfully";
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        TempData["msg"] = "Error while Terminating";
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblHouseAllocationTerminateExists(obj.HouseAllocationId))
                    {
                        TempData["msg"] = "No record found.";
                        return RedirectToAction(nameof(Terminate));
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
        private bool TblHouseAllocationTerminateExists(int id)
        {
            return _context.TblHouseAllocation.Any(e => e.HouseAllocationId == id);
        }
        // GET: ParkingFee/ParkingfeeDetails/HouseRentMonthlyDemand
        [Route("HouseRent/HouseDetails/HouseRentMonthlyDemand")]
        public IActionResult HouseRentMonthlyDemand()
        {
           
            return View();
        }
        [Route("HouseRent/HouseDetails/GetHouseRentDemandScheduleMonthly")]
        public IEnumerable<HouseRentDemandScheduleModule> GetHouseRentDemandScheduleMonthly(int Id,int year, string StartDate, string EndDate)
        {

            IEnumerable<HouseRentDemandScheduleModule> _dList = null;
            return _dList = _repository.GetHouseRentDemandScheduleMonthly(Id, year,StartDate, EndDate);
        }
        [Route("HouseRent/HouseDetails/GenerateDemand")]
        public long GenerateDemand(int HouseAllocationId, int pDays, int pMonth, int pYear, int ScheduleId, decimal Amount, int taxPayerId, int totalDays)
        {
            int CreatedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));

            return _repository.GenerateDemand(HouseAllocationId, pDays, pMonth, pYear, ScheduleId, Amount, CreatedBy, taxPayerId, totalDays);
        }

        [Route("HouseRent/HouseDetails/HouseRentMonthlyDemands")]
        public List<TaxPayerProfileModel> HouseRentMonthlyDemands(string cid, string ttin)
        {

            List<TaxPayerProfileModel> _dList = null;
            return _dList = _repository.fetchHouseRentDemandByCid(cid, ttin);
        }

        [Route("HouseRent/HouseDetails/GetHouseRentDemand")]
        public List<HouseAllocationVM> GetHouseRentDemand(int DemandNoId)
        {

            List<HouseAllocationVM> _dList = null;
            return _dList = _repository.generateHouseRentDemand(DemandNoId);
        }

        [Route("HouseRent/HouseDetails/HouseRentDetails")]
        public List<HouseAllocationVM> HouseRentDetails(int id)
        {

            List<HouseAllocationVM> _dList = null;
            return _dList = _repository.fetchHouseRentDetails(id);
        }

        [Route("HouseRent/HouseDetails/HouseRentPeriod")]
        public List<HousePeriodVM> HouseRentPeriod(int id)
        {

            List<HousePeriodVM> _dList = null;
            return _dList = _repository.fetchHouseRentPeriod(id);
        }

        //House Renewal
        [Route("HouseRent/HouseDetails/HouseRentRenewal")]
        public IActionResult HouseRentRenewal()
        {
            PopulateDropDowns();
            return View();
        }
        [Route("HouseRent/HouseDetails/GetRenewalHouseRentDetail")]
        public List<HouseRentDetailVM> GetRenewalHouseRentDetail(int? id)
        {
            List<HouseRentDetailVM> _dList = null;

            return _dList = _repository.GetRenewalHouseRentDetail(id);
        }
        [Route("HouseRent/HouseDetails/GetRenewalHouseRentAllocation")]
        public List<HouseAllocationVM> GetRenewalHouseRentAllocation(int? id)
        {
            List<HouseAllocationVM> _dList = null;

            return _dList = _repository.GetRenewalHouseRentAllocation(id);
        }
        [Route("HouseRent/HouseDetails/GetYear")]
        public IEnumerable<DemandYearsModel> GetYear(string StartDate, string EndDate)
        {

            IEnumerable<DemandYearsModel> _dList = null;
            return _dList = _CommonRepo.VendorDemandYears(StartDate, EndDate);
        }

        [HttpPost]
        [Route("HouseRent/HouseDetails/CreateRenewHouseRentAllocation")]
        public JsonResult CreateRenewHouseRentAllocation([FromBody] List<HousePeriodVM> json_data)
        {
            if (json_data == null)
            {
                json_data = new List<HousePeriodVM>();
            }

            HousePeriodVM obj = new HousePeriodVM();
            foreach (HousePeriodVM item in json_data)
            {
                obj.HouseRentPeriodId = item.HouseRentPeriodId;
                obj.HouseAllocationId = item.HouseAllocationId;
                obj.StartDate = item.StartDate;
                obj.EndDate = item.EndDate;
                obj.Remarks = item.Remarks;
                obj.ModifiedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
                obj.CreatedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
                obj.CreatedOn = DateTime.Now;
                obj.ModifiedOn = DateTime.Now;
                _repository.SaveRenew(obj);
            }
            try
            {
                int returnvalue = 1; // 

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
    }
}
