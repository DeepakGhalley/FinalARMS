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

namespace ARMS.Areas.Lease.Controllers
{
    [Area("Lease")]
    public class LandLeasesController : Controller
    {
        private readonly tt_dbContext _context;
        private readonly IMapper _mapper;
        ICommonFunction _CommonRepo = new CommonFunctionBLL();

        readonly ILandLease _repository = new LandLeaseBLL();
        readonly ILandLease _obj = new LandLeaseBLL();
        readonly ILandLeaseDemandDetail _repo = new LandLeaseDemandDetailBLL();
        public LandLeasesController(tt_dbContext context)
        {
            _context = context;
        }

        [Route("Lease/LandLeases")]
        public async Task<IActionResult> Index()
        {
            _ = new List<LandLeaseModel>();
            IList<LandLeaseModel> obj = _repository.GetAll();
            PopulateDropDowns();
            return View(obj);
        }

        [Route("Lease/LandLeases/LandLeaseMonthlyDemand")]
        public IActionResult LandLeaseMonthlyDemand()
        {
            PopulateDropDowns();
            return View();
        }

        [Route("Lease/LandLeases/Details")]
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

        [Route("Lease/LandLeases/GetDetails")]
        public async Task<IActionResult> GetDetails(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var data = await _repository.GetDetails(id);
            if (data == null)
            {
                return NotFound();
            }

            return View(data);
        }

        [Route("Lease/LandLeases/Extension")]
        public async Task<IActionResult> Extension(int? id)
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
            ViewData["LandDetailId"] = _CommonRepo.SelectListLandDetail();
            ViewData["TaxPayerId"] = _CommonRepo.SelectListTaxPayerProfile();
            ViewData["BillingScheduleId"] = _CommonRepo.SelectListBillingSchedule();
            ViewData["LeaseTypeId"] = _CommonRepo.SelectListLeaseType();
            ViewData["LeaseActivityTypeId"] = _CommonRepo.SelectListLeaseActivityType();
            ViewData["TaxPeriodId"] = _CommonRepo.SelectListTaxPeriod();
            return View(Data);
        }

        //Save Extension

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Property/LandLeases/CreateExtension")]
        public async Task<IActionResult> CreateExtension(LandLeasePeriodVM obj)
        {
            obj.LandLeaseId = 1;
            obj.CreatedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            obj.CreatedOn = DateTime.Now;

            if (ModelState.IsValid)
            {
                int returnvalue = _repository.SaveExtension(obj);

                if (returnvalue > 0)
                {
                    TempData["msg"] = "New record created successfully";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    TempData["msg"] = "New record creation failed";
                    return RedirectToAction(nameof(Index));
                }

            }
            PopulateDropDowns();

            return View(obj);
        }

        //[Route("Lease/LandLeases/Terminate")]
        //public async Task<IActionResult> Terminate(int id)
        //{

        //    LandLeaseModel obj = new LandLeaseModel();
        //    obj.LandLeaseId = id;
        //    return View(obj);
        //}
        [HttpGet]
        [Route("Lease/LandLeases/Terminate")]
        public async Task<IActionResult> Terminate(int? id)
        {


            if (id == null)
            {
                return NotFound();
            }

            var Data = await _repository.GetTerminateDetails(id);
            if (Data == null)
            {
                return NotFound();
            }
            ViewData["LandDetailId"] = _CommonRepo.SelectListLandDetail();
            ViewData["TaxPayerId"] = _CommonRepo.SelectListTaxPayerProfile();
            ViewData["BillingScheduleId"] = _CommonRepo.SelectListBillingSchedule();
            ViewData["LeaseTypeId"] = _CommonRepo.SelectListLeaseType();
            ViewData["LeaseActivityTypeId"] = _CommonRepo.SelectListLeaseActivityType();
            ViewData["TaxPeriodId"] = _CommonRepo.SelectListTaxPeriod();
            return View(Data);
        }

        //Save Terminate

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Lease/LandLeases/Terminate")]
        public async Task<IActionResult> Terminate(LandLeaseModel obj)
        {
            obj.ModifiedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            obj.ModifiedOn = DateTime.Now;
            bool CheckDuplicate = _repository.DuplicateCheckOnUpdate();
            if (CheckDuplicate)
            {
                TempData["msg"] = "Already Terminated";
                PopulateDropDowns();
                return View();

            }

            var Data = await _repository.GetTerminateDetails(obj.LandLeaseId);
            if (Data.LandLeaseId != obj.LandLeaseId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    int returnvalue = _repository.UpdateTermination(obj);
                    if (returnvalue > 0)
                    {
                        TempData["msg"] = "Record terminated successfully";
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        TempData["msg"] = "Error while terminating";
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblLandLeaseExists(obj.LandLeaseId))
                    {
                        TempData["msg"] = "No record found.";
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        throw;
                    }
                }

            }
            ViewData["LandDetailId"] = _CommonRepo.SelectListLandDetail();
            ViewData["TaxPayerId"] = _CommonRepo.SelectListTaxPayerProfile();
            ViewData["BillingScheduleId"] = _CommonRepo.SelectListBillingSchedule();
            ViewData["LeaseTypeId"] = _CommonRepo.SelectListLeaseType();
            ViewData["LeaseActivityTypeId"] = _CommonRepo.SelectListLeaseActivityType();
            ViewData["TaxPeriodId"] = _CommonRepo.SelectListTaxPeriod();
            return View(obj);
        }


        [Route("Lease/LandLeases/Create")]
        public IActionResult Create()
        {
            PopulateDropDowns();
            return View();
        }
        private void PopulateDropDowns()
        {
            ViewData["LandDetailId"] = _CommonRepo.SelectListLandDetail();
            ViewData["TaxPayerId"] = _CommonRepo.SelectListTaxPayerProfile();
            ViewData["BillingScheduleId"] = _CommonRepo.SelectListBillingSchedule();
            ViewData["LeaseTypeId"] = _CommonRepo.SelectListLeaseType();
            ViewData["LeaseActivityTypeId"] = _CommonRepo.SelectListLeaseActivityType();
            ViewData["TaxPeriodId"] = _CommonRepo.SelectListTaxPeriod();

            //For Land Details
            ViewData["StreetNameId"] = _CommonRepo.SelectListStreetName();
            ViewData["LandUseCategory"] = _CommonRepo.SelectListLandUseCategory();
            ViewData["DemkhongId"] = _CommonRepo.SelectListDemkhong();
            ViewData["LapId"] = _CommonRepo.SelectListLap();
            ViewData["LandTypeId"] = _CommonRepo.SelectListLandType();
            ViewData["LandOwnershipTypeId"] = _CommonRepo.SelectListLandOwnershipType();
            ViewData["LandDetailId"] = _CommonRepo.SelectListLandDetail();
            ViewData["PropertyTypeId"] = _CommonRepo.SelectListPropertyType();

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Lease/LandLeases/Create")]
        public async Task<IActionResult> Create(LandLeaseModel obj)
        {
            obj.CreatedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            obj.CreatedOn = DateTime.Now;

            // bool CreateCheckDuplicate = _repository.DuplicateCheckOnSave(obj.LandLeaseId);
            //if (CreateCheckDuplicate)
            //{
            //  TempData["msg"] = "Duplicate data found, please enter a different Gewog name.";
            //  PopulateDropDowns();
            // return View(obj);
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
                    TempData["msg"] = "New record creation failed";
                    return RedirectToAction(nameof(Create));
                }

            }
            PopulateDropDowns();

            return View(obj);
        }

        [HttpGet]
        [Route("Lease/LandLeases/Edit")]
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
            ViewData["LandDetailId"] = _CommonRepo.SelectListLandDetail();
            ViewData["TaxPayerId"] = _CommonRepo.SelectListTaxPayerProfile();
            ViewData["BillingScheduleId"] = _CommonRepo.SelectListBillingSchedule();
            ViewData["LeaseTypeId"] = _CommonRepo.SelectListLeaseType();
            ViewData["LeaseActivityTypeId"] = _CommonRepo.SelectListLeaseActivityType();
            ViewData["TaxPeriodId"] = _CommonRepo.SelectListTaxPeriod();
            return View(Data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Lease/LandLeases/Edit")]
        public async Task<IActionResult> Edit(LandLeaseModel obj)
        {
            obj.ModifiedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            obj.ModifiedOn = Convert.ToDateTime(DateFunctions.getDatetypefrom(DateTime.Now.ToString("dd/MM/yyyy")));
            //  bool CheckDuplicate = _repository.DuplicateCheckOnUpdate(obj.GewogName, obj.DzongkhagId, obj.GewogId);
            //if (CheckDuplicate)
            //{
            //  TempData["msg"] = "Duplicate data found, please enter a different Gewog name.";
            //PopulateDropDowns();
            //return View(obj);
            //}
            var Data = await _repository.Details(obj.LandLeaseId);
            if (Data.LandLeaseId != obj.LandLeaseId)
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
                    if (!TblLandLeaseExists(obj.LandLeaseId))
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
            ViewData["LandDetailId"] = _CommonRepo.SelectListLandDetail();
            ViewData["TaxPayerId"] = _CommonRepo.SelectListTaxPayerProfile();
            ViewData["BillingScheduleId"] = _CommonRepo.SelectListBillingSchedule();
            ViewData["LeaseTypeId"] = _CommonRepo.SelectListLeaseType();
            ViewData["LeaseActivityTypeId"] = _CommonRepo.SelectListLeaseActivityType();
            ViewData["TaxPeriodId"] = _CommonRepo.SelectListTaxPeriod(); return View(obj);
        }

        [Route("Lease/LandLeases/Delete")]

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var TblLandLease = await _repository.Details(id);
            if (TblLandLease == null)
            {
                return NotFound();
            }

            return View(TblLandLease);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Route("Lease/LandLeases/Delete")]

        public async Task<IActionResult> DeleteConfirmed(LandLeaseModel obj)
        {
            await _repository.DeleteConfirmed(obj.LandLeaseId);
            return RedirectToAction(nameof(Index));
        }

        private bool TblLandLeaseExists(int id)
        {
            return _context.TblLandLease.Any(e => e.LandLeaseId == id);
        }

        [Route("Lease/LandLeases/getLandOwnerShip")]
        public List<LandLeaseModel> getLandOwnerShip(string Cid, string Ttin, string plotno)
        {

            List<LandLeaseModel> _dList = null;
            return _dList = _obj.fetchLandOwnerShipDetails(Cid, Ttin, plotno);
        }
        [Route("Lease/LandLeases/Listall")]
        public List<LandLeaseModel> Listall()
        {
            List<LandLeaseModel> _dList = null;
            return _dList = _obj.Listall();
        }

        [Route("Lease/LandLeases/Temporary")]
        public List<LandLeaseModel> Temporary()
        {
            List<LandLeaseModel> _dList = null;
            return _dList = _obj.Temporary();
        }

        [Route("Lease/LandLeases/Shortterm")]
        public List<LandLeaseModel> Shortterm()
        {
            List<LandLeaseModel> _dList = null;
            return _dList = _obj.Shortterm();
        }


        [Route("Lease/LandLeases/Longterm")]
        public List<LandLeaseModel> Longterm()
        {
            List<LandLeaseModel> _dList = null;
            return _dList = _obj.Longterm();
        }

        [Route("Lease/LandLeases/fetchLandAndLeaseDetails")]
        public List<LandLeaseDemandDetailModel> fetchLandAndLeaseDetails(string Cid, string Ttin)
        {

            List<LandLeaseDemandDetailModel> _dList = null;
            return _dList = _repo.fetchLandAndLeaseDetails(Cid, Ttin);
        }

        [Route("water/LandLeases/fetchTaxPayer")]
        public List<LandLeaseModel> fetchTaxPayer(string cid, string ttin)
        {

            List<LandLeaseModel> _dList = null;
            return _dList = _repository.fetchTaxPayer(cid, ttin);
        }

        [Route("Lease/LandLeases/GetTaxPayer")]
        public List<TaxPayerProfileModel> GetTaxPayer(string cid, string ttin)
        {

            List<TaxPayerProfileModel> _dList = null;
            return _dList = _repository.fetchTaxPayerDetail(cid, ttin);
        }

        [HttpPost]
        [Route("Lease/LandLeases/CreateLand")]
        public JsonResult CreateLand([FromBody] List<LandDetailModel> json_data)
        {
            //using (tt_dbContext entities = new tt_dbContext())
            //{
            //Check for NULL.  
            if (json_data == null)
            {
                json_data = new List<LandDetailModel>();
            }
            long pk = 0;
            LandDetailModel obj = new LandDetailModel();
            //Loop and insert records. 
           
          
                foreach (LandDetailModel item in json_data)
                {
                if (item.BSI == 1)
                {
                  
                    obj.PlotNo = item.PlotNo;
                    obj.LandAcerage = item.LandAcerage;
                    obj.LandValue = 0;
                    obj.LandPoolingRate = 0;
                    obj.PlotAddress = item.PlotAddress;
                    obj.Location = item.PlotAddress;
                    obj.PropertyTypeId = 2;
                    obj.StreetNameId = item.StreetNameId;
                    obj.LandUseSubCategoryId = item.LandUseSubCategoryId;
                    obj.DemkhongId = item.DemkhongId;
                    obj.LandTypeId = item.LandTypeId;
                    obj.LapId = item.LapId;
                    obj.StructureAvailable = item.StructureAvailable;
                    obj.VacantLandTaxApplicable = item.VacantLandTaxApplicable;
                    obj.GarbageApplicable = item.GarbageApplicable;
                    obj.StreetLightApplicable = item.StreetLightApplicable;
                    //land lease & land period
                    obj.TaxPayerId = item.TaxPayerId;
                    obj.BillingScheduleId = 3;
                    obj.LeaseTypeId = item.LeaseTypeId;
                    obj.LeaseActivityTypeId = item.LeaseActivityTypeId;
                    obj.HasShed = item.HasShed;
                    //obj.HassecurityDeposit = item.HassecurityDeposit;
                    obj.StartDate = item.StartDate;
                    obj.EndDate = item.EndDate;
                    obj.LeaseAmount = item.LeaseAmount;
                    obj.ShedAmount = item.ShedAmount;
                    obj.Remarks = item.Remarks;
                    obj.LeaseApprovalNo = item.LeaseApprovalNo;
                    //obj.IsActive = item.IsActive;
                    obj.CreatedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
                    obj.CreationOn = DateTime.Now;
                    pk = _repository.Savelongterm(obj);
                
            }
            else
            {
               
                    obj.PlotNo = item.PlotNo;
                    obj.LandAcerage = item.LandAcerage;
                    obj.LandValue = 0;
                    obj.LandPoolingRate = 0;
                    obj.PlotAddress = item.PlotAddress;
                    obj.Location = item.PlotAddress;
                    obj.PropertyTypeId = 2;
                    obj.StreetNameId = item.StreetNameId;
                    obj.LandUseSubCategoryId = 1;
                    obj.DemkhongId = item.DemkhongId;
                    obj.LandTypeId = item.LandTypeId;
                    obj.LapId = item.LapId;
                    obj.StructureAvailable = item.StructureAvailable;
                    obj.VacantLandTaxApplicable = item.VacantLandTaxApplicable;
                    obj.GarbageApplicable = item.GarbageApplicable;
                    obj.StreetLightApplicable = item.StreetLightApplicable;
                    //land lease & land period
                    obj.TaxPayerId = item.TaxPayerId;
                    obj.BillingScheduleId = 1;
                    obj.LeaseTypeId = item.LeaseTypeId;
                    obj.LeaseActivityTypeId = item.LeaseActivityTypeId;
                    obj.HasShed = item.HasShed;
                    //obj.HassecurityDeposit = item.HassecurityDeposit;
                    obj.StartDate = item.StartDate;
                    obj.EndDate = item.EndDate;
                    obj.LeaseAmount = item.LeaseAmount;
                    obj.ShedAmount = item.ShedAmount;
                    obj.Remarks = item.Remarks;
                    obj.LeaseApprovalNo = item.LeaseApprovalNo;
                    //obj.IsActive = item.IsActive;
                    obj.CreatedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
                    obj.CreationOn = DateTime.Now;
                    pk = _repository.SaveLandDetail(obj);
                }
            }
            return Json(pk);
            //}
        }

        [HttpPost]
        [Route("Lease/LandLeases/CreateLandLease")]
        public JsonResult CreateLandLease([FromBody] List<LandDetailModel> json_data)
        {
            //using (tt_dbContext entities = new tt_dbContext())
            //{
            //Check for NULL.  
            if (json_data == null)
            {
                json_data = new List<LandDetailModel>();
            }
            long pk = 0;
            LandDetailModel obj = new LandDetailModel();
            //Loop and insert records. 
          
                foreach (LandDetailModel item in json_data)
                {
                if (item.BSI == 1)
                {
                    //land lease & land period
                    obj.TaxPayerId = item.TaxPayerId;
                    obj.LandDetailId = item.LandDetailId;
                    obj.BillingScheduleId = 3;
                    obj.LeaseTypeId = item.LeaseTypeId;
                    obj.LeaseActivityTypeId = item.LeaseActivityTypeId;
                    obj.HasShed = item.HasShed;
                    //obj.HassecurityDeposit = item.HassecurityDeposit;
                    obj.StartDate = item.StartDate;
                    obj.EndDate = item.EndDate;
                    obj.LeaseAmount = item.LeaseAmount;
                    obj.ShedAmount = item.ShedAmount;
                    obj.Remarks = item.Remarks;
                    obj.IsActive = item.IsActive;
                    obj.CreatedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
                    obj.CreationOn = DateTime.Now;
                    obj.LeaseApprovalNo = item.LeaseApprovalNo;
                    pk = _repository.SaveLandLeaselongterm(obj);
                }
            
            else
            {
               
                    //land lease & land period
                    obj.TaxPayerId = item.TaxPayerId;
                    obj.LandDetailId = item.LandDetailId;
                    obj.BillingScheduleId = 1;
                    obj.LeaseTypeId = item.LeaseTypeId;
                    obj.LeaseActivityTypeId = item.LeaseActivityTypeId;
                    obj.HasShed = item.HasShed;
                    //obj.HassecurityDeposit = item.HassecurityDeposit;
                    obj.StartDate = item.StartDate;
                    obj.EndDate = item.EndDate;
                    obj.LeaseAmount = item.LeaseAmount;
                    obj.ShedAmount = item.ShedAmount;
                    obj.Remarks = item.Remarks;
                    obj.IsActive = item.IsActive;
                    obj.LeaseApprovalNo = item.LeaseApprovalNo;
                    obj.CreatedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
                    obj.CreationOn = DateTime.Now;
                    pk = _repository.SaveLandLease(obj);
                }
            }
            return Json(pk);
            //}
        }

        [HttpPost]
        [Route("Lease/LandLeases/CreateLandPeriod")]
        public JsonResult CreateLandPeriod([FromBody] List<LandLeasePeriodVM> json_data)
        {
            //using (tt_dbContext entities = new tt_dbContext())
            //{
            //Check for NULL.  
            if (json_data == null)
            {
                json_data = new List<LandLeasePeriodVM>();
            }

            LandLeasePeriodVM obj = new LandLeasePeriodVM();
            //Loop and insert records. 
            foreach (LandLeasePeriodVM item in json_data)
            {
                obj.LandLeasePeriodId = item.LandLeasePeriodId;
                obj.LandLeaseId = item.LandLeaseId;
                obj.StartDate = item.StartDate;
                obj.EndDate = item.EndDate;
                obj.CreatedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
                obj.CreatedOn = DateTime.Now;
                _repository.SaveLandPeriod(obj);
            }
            try
            {
                int returnvalue = 1;

                if (returnvalue > 0)
                {
                    TempData["msg"] = "Saved Successfully!";
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
            //}
        }

        [Route("Lease/LandLeases/PopulateLUSC")]
        public List<MstLandUseSubCategory> PopulateLUSC(int id)
        {
            List<MstLandUseSubCategory> _dataList = null;

            return _dataList = _repository.fetchLUSC(id);

        }


        [Route("Lease/LandLeases/LandLeaseDetails")]
        public List<LandLeaseModel> LandLeaseDetails(int id)
        {

            List<LandLeaseModel> _dList = null;
            return _dList = _obj.LandLeaseDetails(id);
        }

        [Route("Lease/LandLeases/GetVendorDemandSchedule")]
        public IEnumerable<VendorDemandScheduleModel> GetVendorDemandSchedule(int Id, int yr, string StartDate, string EndDate)
        {

            IEnumerable<VendorDemandScheduleModel> _dList = null;
            return _dList = _repository.GetVendorDemandSchedule(Id,yr, StartDate, EndDate);
        }
        [Route("Lease/LandLeases/GetLongTermLandLease")]
        public IEnumerable<LongtermleaseVM> GetLongTermLandLease(int Id, string StartDate, string EndDate)
        {

            IEnumerable<LongtermleaseVM> _dList = null;
            return _dList = _repository.GetLongTermLandLease(Id,StartDate, EndDate);
        }

        [HttpPost]
        [Route("Lease/LandLeases/GenerateDemand")]
        public long GenerateDemand(int landLeaseId, int pDays, int pMonth, int pYear, int ScheduleId, decimal Amount, int taxPayerId, int taxId, int totalDays, string IDate)
        {
            int CreatedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));

            return _repository.GenerateDemand(landLeaseId, pDays, pMonth, pYear, ScheduleId, Amount, CreatedBy, taxPayerId, taxId, totalDays, IDate);
        }

        [Route("Lease/LandLeases/GetDemand")]
        public List<LandLeaseModel> GetDemand(int DemandNoId)
        {

            List<LandLeaseModel> _dList = null;
            return _dList = _repository.GetDemand(DemandNoId);
        }

        [Route("Lease/LandLeases/LandLeaseYearlyDemand")]
        public IActionResult LandLeaseYearlyDemand()
        {
            PopulateDropDowns();
            return View();
        }

        [Route("Lease/LandLeases/GetYear")]
        public IEnumerable<DemandYearsModel> GetYear(string StartDate, string EndDate)
        {

            IEnumerable<DemandYearsModel> _dList = null;
            return _dList = _CommonRepo.VendorDemandYears(StartDate, EndDate);
        }

        [Route("Lease/LandLeases/GetPlotNo")]
        public IEnumerable<LandDetailModel> GetPlotNo(string plotNo)
        {

            IEnumerable<LandDetailModel> _dList = null;
            return _dList = _repository.GetPlotNo(plotNo);
        }

        [Route("Lease/LandLeases/GetDemandlongterm")]
        public List<LandLeaseModel> GetDemandlongterm(long TransactionId)
        {

            List<LandLeaseModel> _dList = null;
            return _dList = _obj.GetDemandlongterm(TransactionId);
        }

        [Route("Lease/LandLeases/FetchRate")]
        public List<MstRate> FetchRate(int id)
        {
            var data = (from a in _context.MstSlab.Where(x => x.LeaseActivityTypeId == id)
                       
                        join c in _context.MstRate on a.SlabId equals c.SlabId
                        select new MstRate
                        {
                            RateId = c.RateId,
                            Rate = c.Rate
                        });
            return data.ToList();
        }
        [Route("Lease/LandLeases/DisplayExistingLease")]
        public List<LandLeaseModel> DisplayExistingLease(int TaxPayerId)
        {

            List<LandLeaseModel> _dList = null;
            return _dList = _repository.DisplayExistingLease(TaxPayerId);
        }
        [Route("Lease/LandLeases/GetLeaseDetailsForUpdate")]
        public List<LandLeaseModel> GetLeaseDetailsForUpdate(int LandLeaseId)
        {

            List<LandLeaseModel> _dList = null;
            return _dList = _repository.GetLeaseDetailsForUpdate(LandLeaseId);
        }

        [HttpPost]
        [Route("Lease/LandLeases/UpdateLandLease")]
        public JsonResult UpdateLandLease([FromBody] List<LandLeaseModel> json_data)
        {
            if (json_data == null)
            {
                json_data = new List<LandLeaseModel>();
            }
            long pk = 0;
            LandLeaseModel obj = new LandLeaseModel();

            foreach (LandLeaseModel item in json_data)
            {
                if (item.BSI == 3)
                {
                    obj.BillingScheduleId = 3;
                }
                else if (item.BSI == 1)
                {
                    obj.BillingScheduleId = 1;
                }
                else
                {
                    obj.BillingScheduleId = 0;
                }
                if (item.HS == 1)
                {
                    obj.HasShed = true;
                }
                else
                {
                    obj.HasShed = false;
                }
                obj.LandDetailId = item.LandDetailId;
                obj.LandLeaseId = item.LandLeaseId;
                obj.LandLeasePeriodId = item.LandLeasePeriodId;
                obj.PlotNo = item.PlotNo;
                obj.LandAcerage = item.LandAcerage;
                obj.StreetNameId = item.StreetNameId;
                obj.DemkhongId = item.DemkhongId;
                obj.LapId = item.LapId;
                obj.PlotAddress = item.PlotAddress;
                obj.LeaseTypeId = item.LeaseTypeId;
                obj.LeaseActivityTypeId = item.LeaseActivityTypeId;
                obj.StartDate = item.StartDate;
                obj.EndDate = item.EndDate;
                obj.LeaseApprovalNo = item.LeaseApprovalNo;
                obj.LeaseAmount = item.LeaseAmount;
                obj.ShedAmount = item.ShedAmount;
                obj.HasShed = item.HasShed;
                obj.ModifiedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
                obj.ModifiedOn = DateTime.Now;
                pk = _repository.UpdateLandLease(obj);
            }
            return Json(pk);
        }
    }
}





