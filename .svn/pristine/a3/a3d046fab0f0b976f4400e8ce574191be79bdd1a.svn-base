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

namespace ARMS.Areas.ParkingFee.Controllers
{
    [Area("ParkingFee")]
    public class ParkingfeeDetailsController : Controller
    {
        private readonly tt_dbContext _context;
        ICommonFunction _CommonRepo = new CommonFunctionBLL();
        readonly IParkingFee _repository = new ParkingFeeBLL();

        public ParkingfeeDetailsController(tt_dbContext context)
        {
            _context = context;
        }

        // GET: ParkingFee/ParkingfeeDetails
        [Route("ParkingFee/ParkingfeeDetails")]
        public async Task<IActionResult> Index()
        {
            ParkingFeeDropdown();
            return View();
        }

        //// GET: ParkingFee/ParkingfeeDetails/ParkingFeeMonthlyDemand
        //[Route("ParkingFee/ParkingfeeDetails/ParkingFeeMonthlyDemand")]
        //public async Task<IActionResult> ParkingFeeMonthlyDemand()
        //{
        //    _ = new List<ParkingFeePeriodVM>();
        //    IList<ParkingFeePeriodVM> obj = _repository.GetParkingFeeDemand();
        //    return View(obj);
        //}

        // GET: ParkingFee/ParkingfeeDetails/ParkingFeeMonthlyDemand
        [Route("ParkingFee/ParkingfeeDetails/ParkingFeeMonthlyDemand")]
        public IActionResult ParkingFeeMonthlyDemand()
        {
            ParkingFeeDropdown();
            return View();
        }

        [Route("ParkingFee/ParkingfeeDetails/ParkingFeeMonthlyDemands")]
        public List<TaxPayerProfileModel> ParkingFeeMonthlyDemands(string cid, string ttin)
        {

            List<TaxPayerProfileModel> _dList = null;
            return _dList = _repository.fetchParkingFeeDemandByCid(cid, ttin);
        }

        [Route("ParkingFee/ParkingfeeDetails/GetParkingDemand")]
        public List<ParkingFeeVM> GetParkingDemand(int DemandNoId)
        {

            List<ParkingFeeVM> _dList = null;
            return _dList = _repository.generateParkingFeeDemand(DemandNoId);
        }

        [Route("ParkingFee/ParkingfeeDetails/ParkingFeeDetails")]
        public List<ParkingFeeVM> ParkingFeeDetails(int id)
        {

            List<ParkingFeeVM> _dList = null;
            return _dList = _repository.fetchParkingFeeDetails(id);
        }

        [Route("ParkingFee/ParkingfeeDetails/ParkingFeePeriod")]
        public List<ParkingFeePeriodVM> ParkingFeePeriod(int id)
        {

            List<ParkingFeePeriodVM> _dList = null;
            return _dList = _repository.fetchParkingFeePeriod(id);
        }

        // GET: ParkingFee/ParkingfeeDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblParkingfeeDetail = await _context.TblParkingfeeDetail
                .Include(t => t.BillingSchedule)
                .Include(t => t.ParkingZone)
                .Include(t => t.TaxPayer)
                .FirstOrDefaultAsync(m => m.ParkingFeeDetailId == id);
            if (tblParkingfeeDetail == null)
            {
                return NotFound();
            }

            return View(tblParkingfeeDetail);
        }

        // GET: ParkingFee/ParkingfeeDetails/Create
        [Route("ParkingFee/ParkingfeeDetails/Create")]
        public IActionResult Create()
        {
            ParkingFeeDropdown();
            return View();
        }
        private void ParkingFeeDropdown()
        {
            ViewData["ParkingZoneId"] = _CommonRepo.SelectListParkingZones();
            ViewData["TaxPayerId"] = _CommonRepo.SelectListTaxPayerProfile();
            ViewData["BillingScheduleId"] = _CommonRepo.SelectListBillingSchedule();
        }

        // POST: ParkingFee/ParkingfeeDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Route("ParkingFee/ParkingfeeDetails/Create")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ParkingFeeVM obj)
        {
            obj.CreatedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            obj.CreatedOn = Convert.ToDateTime(DateFunctions.getDatetypefrom(DateTime.Now.ToString("dd/MM/yyyy")));
            try
            {
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
                        TempData["msg"] = "New record creation failed";
                        return RedirectToAction(nameof(Create));
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            ParkingFeeDropdown();
            return View(obj);
        }

        // GET: ParkingFee/ParkingfeeDetails/Edit/5
        [Route("ParkingFee/ParkingfeeDetails/Edit")]
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
            ParkingFeeDropdown();
            return View(Data);
        }

        // POST: ParkingFee/ParkingfeeDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Route("ParkingFee/ParkingfeeDetails/Edit")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ParkingFeeVM obj)
        {
            obj.ModifiedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            obj.ModifiedOn = Convert.ToDateTime(DateFunctions.getDatetypefrom(DateTime.Now.ToString("dd/MM/yyyy")));

            var Data = await _repository.Details(obj.ParkingFeeDetailId);
            if (Data.ParkingFeeDetailId != obj.ParkingFeeDetailId)
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
                    if (!TblParkingfeeDetailExists(obj.ParkingFeeDetailId))
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
            ParkingFeeDropdown();
            return View(obj);
        }

        // GET: ParkingFee/ParkingfeeDetails/Terminate/5
        [Route("ParkingFee/ParkingfeeDetails/Terminate")]
        public async Task<IActionResult> Terminate(int? id)
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
            ParkingFeeDropdown();
            return View(Data);
        }

        // POST: ParkingFee/ParkingfeeDetails/Terminate/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Route("ParkingFee/ParkingfeeDetails/Terminate")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Terminate(ParkingFeeVM obj)
        {
            obj.ModifiedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            obj.TerminatedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            obj.ModifiedOn = Convert.ToDateTime(DateFunctions.getDatetypefrom(DateTime.Now.ToString("dd/MM/yyyy")));
            bool CheckDuplicate = _repository.DuplicateCheckOnUpdate();
            if (CheckDuplicate)
            {
                TempData["msg"] = "Already Terminated";
                ParkingFeeDropdown();
                return View();

            }

            var Data = await _repository.Details(obj.ParkingFeeDetailId);
            if (Data.ParkingFeeDetailId != obj.ParkingFeeDetailId)
            {
                return NotFound();
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
                    if (!TblParkingfeeDetailExists(obj.ParkingFeeDetailId))
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
            ParkingFeeDropdown();
            return View(obj);
        }

        [Route("ParkingFee/ParkingfeeDetails/Extension")]
        [HttpPost]
        public JsonResult Extension([FromBody] List<ParkingFeePeriodVM> json_data)
        {
            //using (tt_dbContext entities = new tt_dbContext())
            //{
            //Check for NULL.  
            if (json_data == null)
            {
                json_data = new List<ParkingFeePeriodVM>();
            }

            ParkingFeePeriodVM obj = new ParkingFeePeriodVM();
            //Loop and insert records. 
            foreach (ParkingFeePeriodVM item in json_data)
            {
                obj.ParkingFeeDetailId = item.ParkingFeeDetailId;
                obj.StartDate = item.StartDate;
                obj.EndDate = item.EndDate;
                obj.Remarks = item.Remarks;
                obj.CreatedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
                obj.CreatedOn = DateTime.Now;
                _repository.Extension(obj);
            }
            try
            {
                int returnvalue = _repository.Extension(obj);

                if (returnvalue > 0)
                {
                    TempData["msg"] = "Extended Successfully!";
                }
                else
                {
                    TempData["msg"] = "Extension failed";
                }
            }
            catch (DbUpdateConcurrencyException)
            {

            }

            return Json(TempData["msg"]);
            //}
        }

        // GET: ParkingFee/ParkingfeeDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblParkingfeeDetail = await _context.TblParkingfeeDetail
                .Include(t => t.BillingSchedule)
                .Include(t => t.ParkingZone)
                .Include(t => t.TaxPayer)
                .FirstOrDefaultAsync(m => m.ParkingFeeDetailId == id);
            if (tblParkingfeeDetail == null)
            {
                return NotFound();
            }

            return View(tblParkingfeeDetail);
        }

        // POST: ParkingFee/ParkingfeeDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblParkingfeeDetail = await _context.TblParkingfeeDetail.FindAsync(id);
            _context.TblParkingfeeDetail.Remove(tblParkingfeeDetail);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblParkingfeeDetailExists(int id)
        {
            return _context.TblParkingfeeDetail.Any(e => e.ParkingFeeDetailId == id);
        }

        [Route("ParkingFee/ParkingfeeDetails/Getdata")]
        public List<TaxPayerProfileModel> Getdata(string cid, string ttin)
        {

            List<TaxPayerProfileModel> _dList = null;
            return _dList = _repository.fetchParkingFeeDemandByCid(cid, ttin);
        }

        [Route("ParkingFee/ParkingfeeDetails/GetVendorDemandSchedule")]
        public IEnumerable<VendorDemandScheduleModel> GetVendorDemandSchedule(int Id, int yr, string StartDate, string EndDate)
        {

            IEnumerable<VendorDemandScheduleModel> _dList = null;
            return _dList = _repository.GetVendorDemandSchedule(Id,yr, StartDate, EndDate);
        }
        [HttpPost]
        [Route("ParkingFee/ParkingfeeDetails/GenerateDemand")]
        public long GenerateDemand(int ParkingFeeDetailId, int pDays, int pMonth, int pYear, int ScheduleId, decimal Amount, int taxPayerId, int totalDays)
        {
            int CreatedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));

            return _repository.GenerateDemand(ParkingFeeDetailId, pDays, pMonth, pYear, ScheduleId, Amount, CreatedBy, taxPayerId,totalDays);
        }

        [Route("ParkingFee/ParkingfeeDetails/GetYear")]
        public IEnumerable<DemandYearsModel> GetYear(string StartDate, string EndDate)
        {

            IEnumerable<DemandYearsModel> _dList = null;
            return _dList = _CommonRepo.VendorDemandYears(StartDate, EndDate);
        }

    }
}
