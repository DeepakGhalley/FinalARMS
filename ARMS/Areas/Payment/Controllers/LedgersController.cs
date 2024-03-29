﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CORE_BOL.Entities;
using Microsoft.AspNetCore.Authorization;
using CORE_DLL;
using CORE_BLL;
using CORE_BOL;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;

namespace ARMS.Areas.Payment.Controllers
{
    [Area("Payment")]
    [Authorize]
    public class LedgersController : Controller
    {
        private readonly tt_dbContext _context;
        readonly ILedger _repository = new LedgerBLL();
        readonly IPaymentReceiptByReceiptNo _res = new PaymentReceiptByReceiptNoBLL();
        readonly IDuplicateDemandPrint _obj = new DuplicateDemandPrintBLL();
        ICommonFunction _CommonRepo = new CommonFunctionBLL();
        public LedgersController(tt_dbContext context)
        {
            _context = context;
        }
        [Authorize]
        // GET: Payment/Ledgers
        [Route("Payment/Ledgers")]
        public async Task<IActionResult> Index()
        {
            //    //var tt_dbContext = _context.TblLedger.Include(t => t.Applicant).Include(t => t.CalendarYear).Include(t => t.Demand).Include(t => t.EcRenewal).Include(t => t.FinancialYear).Include(t => t.HouseRentDemandDetail).Include(t => t.LandLeaseDemandDetail).Include(t => t.MiscellaneousRecord).Include(t => t.ParkingDemandDetail).Include(t => t.StallDemandDetail).Include(t => t.Tax).Include(t => t.Transaction);
            //_ = new DemandCountModel();
            //    DemandCountModel obj = _repository.GetDemandCount();
            var
            Role = Convert.ToInt32(HttpContext.Session.GetInt32("RoleId"));
            HttpContext.Session.SetInt32("roleid", Role);
            return View();
           
        }
        [Authorize]
        [Route("Payment/Ledgers/GetAllDemands")]
        public List<LedgerDemandVM> GetAllDemands(int id)
        {
          
            return _repository.GetAllDemands(id).ToList();
        }
        [Authorize]
        [Route("Payment/Ledgers/GetDemandWithSearch")]
        public async Task<List<LedgerDemandVM>> GetDemandWithSearch(string DemandNo, string ConsumerNo)
        {
            return (List<LedgerDemandVM>)await _repository.GetDemandWithSearch(DemandNo, ConsumerNo);
        }
        [Authorize]
        [Route("Payment/Ledgers/GetDemandWithSearch1")]
        public List<LedgerDemandVM> GetDemandWithSearch1(string DemandNo, string Ttin)
        {
            return _repository.GetDemandWithSearch1(DemandNo, Ttin).ToList();
        }
        [Authorize]
        [Route("Payment/Ledgers/GetpDemandWithSearch")]
        public List<LedgerDemandVM> GetpDemandWithSearch(string DemandNo, string Ttin)
        {
            return _repository.GetpDemandWithSearch(DemandNo, Ttin).ToList();
        }
        [Authorize]
        [Route("Payment/Ledgers/GetmDemandWithSearch")]
        public List<LedgerDemandVM> GetmDemandWithSearch(string DemandNo, string Cid)
        {
            return _repository.GetmDemandWithSearch(DemandNo, Cid).ToList();
        }
        [Authorize]
        [Route("Payment/Ledgers/GetvacuumtankerDemandWithSearch")]
        public List<LedgerDemandVM> GetvacuumtankerDemandWithSearch(string DemandNo, string Name)
        {
            return _repository.GetvacuumtankerDemandWithSearch(DemandNo, Name).ToList();
        }
        [Authorize]
        [Route("Payment/Ledgers/GetWaterConnectionDemand")]
        public List<LedgerDemandVM> GetWaterConnectionDemand(string DemandNo, string G2cNo, string Ttin)
        {
            return _repository.GetWaterConnectionDemand(DemandNo, G2cNo, Ttin).ToList();
        }
        [Authorize]
        [Route("Payment/Ledgers/GetDemandDetail")]
        public List<LedgerDemandVM> GetDemandDetail(string id)
        {          
            return _repository.GetDemandDetail(id).ToList();
        }
        [Authorize]
        [Route("Payment/Ledgers/CheckDuplicatePayment")]
        public List<LedgerDemandVM> CheckDuplicatePayment(string id)
        {           
            return _repository.CheckDuplicatePayment(id).ToList();
        }
        [Authorize]
        [Route("Payment/Ledgers/CreateLedger")]
        public JsonResult CreateLedger([FromBody] List<LedgerDemandVM> json_data,List<LedgerDemandVM> json_data1)
        {


            //using (tt_dbContext entities = new tt_dbContext())
            //{
            //Check for NULL.  
            if (json_data == null)
            {
                json_data = new List<LedgerDemandVM>();
            }
            
            long returnvalue = 0;

            //string[] ids = json_data.Ids.Split(',');

            //var data = ctx.TblDemand.Where(x => ids.Contains(x.DemandId.ToString()));

            if (Convert.ToInt32(HttpContext.Session.GetInt32("UserId")) == 0)
            {
                returnvalue = 0;
                return  Json(returnvalue);
            }
            LedgerDemandVM obj = new LedgerDemandVM();
            //Loop and insert records. 
            foreach (LedgerDemandVM item in json_data)
            {
                obj.Ids = item.Ids;
                //obj.DemandId = item.DemandId;
                //obj.Transac   tionId = item.TransactionId;
                //obj.TaxId = item.TaxId;
                //obj.FinancialYearId = item.FinancialYearId;
                //obj.CalendarYearId = item.CalendarYearId;
                //obj.TotalAmount = item.TotalAmount;
                obj.CreatedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
                //obj.CreatedOn =DateTime.Now;
                returnvalue = _repository.CreateLedger(obj);
            }
            

            return Json(returnvalue);

        }
        [Authorize]
        [Route("Payment/Ledgers/CreatePaymentLedger")]

        public JsonResult CreatePaymentLedger([FromBody] List<LedgerPaymentLedgerModel> json_dataPaymentLedger)
        {
            //using (tt_dbContext entities = new tt_dbContext())
            //{
            //Check for NULL.  
            if (json_dataPaymentLedger == null)
            {
                json_dataPaymentLedger = new List<LedgerPaymentLedgerModel>();
            }

            long returnvalue = 0;
            if (Convert.ToInt32(HttpContext.Session.GetInt32("UserId")) == 0)
            {
                returnvalue = 0;
                return Json(returnvalue);
            }


            LedgerPaymentLedgerModel obj = new LedgerPaymentLedgerModel();
            //Loop and insert records. 
            foreach (LedgerPaymentLedgerModel item in json_dataPaymentLedger)
            {
                if (item.PaymentModeId == 2)
                {
                    obj.BankBranchId = item.BankBranchId;
                    obj.PaymentModeNo = item.PaymentModeNo;
                    obj.PaymentModeDate = item.PaymentModeDate;
                }
                else if (item.PaymentModeId == 13)
                {
                    obj.BankBranchId = item.BankBranchId;
                    obj.PaymentModeNo = item.PaymentModeNo;
                    obj.PaymentModeDate = item.PaymentModeDate;
                }
                obj.PaymentModeId = item.PaymentModeId;
                obj.Amount = item.Amount;               
                obj.CreatedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
                obj.CreatedOn = DateTime.Now;
                obj.ReceiptId = item.ReceiptId;
                returnvalue = _repository.CreatePaymentLedger(obj);
            }

            return Json(returnvalue);
        }
        [Authorize]
        [Route("Payment/Ledgers/Details")]

        // GET: Payment/Ledgers/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblLedger = await _context.TblLedger
                .Include(t => t.Applicant)
                .Include(t => t.CalendarYear)
                .Include(t => t.Demand)
                .Include(t => t.EcRenewal)
                .Include(t => t.FinancialYear)
                .Include(t => t.HouseRentDemandDetail)
                .Include(t => t.LandLeaseDemandDetail)
                .Include(t => t.MiscellaneousRecord)
                .Include(t => t.ParkingDemandDetail)
                .Include(t => t.StallDemandDetail)
                //.Include(t => t.tax)
                .Include(t => t.Transaction)
                .FirstOrDefaultAsync(m => m.LedgerId == id);
            if (tblLedger == null)
            {
                return NotFound();
            }

            return View(tblLedger);
        }

        // GET: Payment/Ledgers/Create
        [Authorize]
        [Route("Payment/Ledgers/Create")]
        public IActionResult Create(int id)
        {
            int TransactionTypeId = id;

            ViewData["Transactiontype"] = _CommonRepo.SelectListTransactionType();
            ViewData["ApplicantId"] = new SelectList(_context.MstEcapplicantdetail, "ApplicantId", "Address");
            ViewData["CalendarYearId"] = new SelectList(_context.MstCalendarYear, "CalendarYearId", "CalendarYear");
            ViewData["DemandId"] = new SelectList(_context.TblDemand, "DemandId", "DemandId");
            ViewData["EcRenewalId"] = new SelectList(_context.TblEcrenewalDetail, "EcRenewalId", "EcRenewalId");
            ViewData["FinancialYearId"] = new SelectList(_context.MstFinancialYear, "FinancialYearId", "FinancialYear");
            ViewData["HouseRentDemandDetailId"] = new SelectList(_context.TblHouseRentDemandDetail, "HouseRentDemandDetailId", "HouseRentDemandDetailId");
            ViewData["LandLeaseDemandDetailId"] = new SelectList(_context.TblLandLeaseDemandDetail, "LandLeaseDemandDetailId", "LandLeaseDemandDetailId");
            ViewData["MiscellaneousRecordId"] = new SelectList(_context.TblMiscellaneousRecord, "MiscellaneousRecordId", "Address");
            ViewData["ParkingDemandDetailId"] = new SelectList(_context.TblParkingFeeDemandDetail, "ParkingDemandDetailId", "ParkingDemandDetailId");
            ViewData["StallDemandDetailId"] = new SelectList(_context.TblStallDetailDemand, "StallDemandDetailId", "StallDemandDetailId");
            ViewData["TaxId"] = new SelectList(_context.MstTaxMaster, "TaxId", "TaxName");
            ViewData["TransactionId"] = new SelectList(_context.TblTransactionDetail, "TransactionId", "TransactionId");
            LedgerDemandVM obj = new LedgerDemandVM();
            obj.RoleId=Convert.ToInt32(HttpContext.Session.GetInt32("RoleId"));
            obj.TransactionTypeId = TransactionTypeId;
            return View(obj);
        }

        // POST: Payment/Ledgers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create([Bind("LedgerId,DemandId,TransactionId,TaxId,FinancialYearId,CalendarYearId,LandDetailId,TaxPayerId,TotalAmount,PaymentDate,ReceiptNo,ReconciledOn,CreatedBy,CreatedOn,ModifiedBy,ModifiedOn,ApplicantId,EcRenewalId,LandLeaseDemandDetailId,ParkingDemandDetailId,StallDemandDetailId,HouseRentDemandDetailId,MiscellaneousRecordId")] TblLedger tblLedger)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblLedger);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ApplicantId"] = new SelectList(_context.MstEcapplicantdetail, "ApplicantId", "Address", tblLedger.ApplicantId);
            ViewData["CalendarYearId"] = new SelectList(_context.MstCalendarYear, "CalendarYearId", "CalendarYear", tblLedger.CalendarYearId);
            ViewData["DemandId"] = new SelectList(_context.TblDemand, "DemandId", "DemandId", tblLedger.DemandId);
            ViewData["EcRenewalId"] = new SelectList(_context.TblEcrenewalDetail, "EcRenewalId", "EcRenewalId", tblLedger.EcRenewalId);
            ViewData["FinancialYearId"] = new SelectList(_context.MstFinancialYear, "FinancialYearId", "FinancialYear", tblLedger.FinancialYearId);
            ViewData["HouseRentDemandDetailId"] = new SelectList(_context.TblHouseRentDemandDetail, "HouseRentDemandDetailId", "HouseRentDemandDetailId", tblLedger.HouseRentDemandDetailId);
            ViewData["LandLeaseDemandDetailId"] = new SelectList(_context.TblLandLeaseDemandDetail, "LandLeaseDemandDetailId", "LandLeaseDemandDetailId", tblLedger.LandLeaseDemandDetailId);
            ViewData["MiscellaneousRecordId"] = new SelectList(_context.TblMiscellaneousRecord, "MiscellaneousRecordId", "Address", tblLedger.MiscellaneousRecordId);
            ViewData["ParkingDemandDetailId"] = new SelectList(_context.TblParkingFeeDemandDetail, "ParkingDemandDetailId", "ParkingDemandDetailId", tblLedger.ParkingDemandDetailId);
            ViewData["StallDemandDetailId"] = new SelectList(_context.TblStallDetailDemand, "StallDemandDetailId", "StallDemandDetailId", tblLedger.StallDemandDetailId);
            ViewData["TaxId"] = new SelectList(_context.MstTaxMaster, "TaxId", "TaxName", tblLedger.TaxId);
            ViewData["TransactionId"] = new SelectList(_context.TblTransactionDetail, "TransactionId", "TransactionId", tblLedger.TransactionId);
            return View(tblLedger);
        }

        // GET: Payment/Ledgers/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblLedger = await _context.TblLedger.FindAsync(id);
            if (tblLedger == null)
            {
                return NotFound();
            }
            ViewData["ApplicantId"] = new SelectList(_context.MstEcapplicantdetail, "ApplicantId", "Address", tblLedger.ApplicantId);
            ViewData["CalendarYearId"] = new SelectList(_context.MstCalendarYear, "CalendarYearId", "CalendarYear", tblLedger.CalendarYearId);
            ViewData["DemandId"] = new SelectList(_context.TblDemand, "DemandId", "DemandId", tblLedger.DemandId);
            ViewData["EcRenewalId"] = new SelectList(_context.TblEcrenewalDetail, "EcRenewalId", "EcRenewalId", tblLedger.EcRenewalId);
            ViewData["FinancialYearId"] = new SelectList(_context.MstFinancialYear, "FinancialYearId", "FinancialYear", tblLedger.FinancialYearId);
            ViewData["HouseRentDemandDetailId"] = new SelectList(_context.TblHouseRentDemandDetail, "HouseRentDemandDetailId", "HouseRentDemandDetailId", tblLedger.HouseRentDemandDetailId);
            ViewData["LandLeaseDemandDetailId"] = new SelectList(_context.TblLandLeaseDemandDetail, "LandLeaseDemandDetailId", "LandLeaseDemandDetailId", tblLedger.LandLeaseDemandDetailId);
            ViewData["MiscellaneousRecordId"] = new SelectList(_context.TblMiscellaneousRecord, "MiscellaneousRecordId", "Address", tblLedger.MiscellaneousRecordId);
            ViewData["ParkingDemandDetailId"] = new SelectList(_context.TblParkingFeeDemandDetail, "ParkingDemandDetailId", "ParkingDemandDetailId", tblLedger.ParkingDemandDetailId);
            ViewData["StallDemandDetailId"] = new SelectList(_context.TblStallDetailDemand, "StallDemandDetailId", "StallDemandDetailId", tblLedger.StallDemandDetailId);
            ViewData["TaxId"] = new SelectList(_context.MstTaxMaster, "TaxId", "TaxName", tblLedger.TaxId);
            ViewData["TransactionId"] = new SelectList(_context.TblTransactionDetail, "TransactionId", "TransactionId", tblLedger.TransactionId);
            return View(tblLedger);
        }

        // POST: Payment/Ledgers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Edit(long id, [Bind("LedgerId,DemandId,TransactionId,TaxId,FinancialYearId,CalendarYearId,LandDetailId,TaxPayerId,TotalAmount,PaymentDate,ReceiptNo,ReconciledOn,CreatedBy,CreatedOn,ModifiedBy,ModifiedOn,ApplicantId,EcRenewalId,LandLeaseDemandDetailId,ParkingDemandDetailId,StallDemandDetailId,HouseRentDemandDetailId,MiscellaneousRecordId")] TblLedger tblLedger)
        {
            if (id != tblLedger.LedgerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblLedger);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblLedgerExists(tblLedger.LedgerId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ApplicantId"] = new SelectList(_context.MstEcapplicantdetail, "ApplicantId", "Address", tblLedger.ApplicantId);
            ViewData["CalendarYearId"] = new SelectList(_context.MstCalendarYear, "CalendarYearId", "CalendarYear", tblLedger.CalendarYearId);
            ViewData["DemandId"] = new SelectList(_context.TblDemand, "DemandId", "DemandId", tblLedger.DemandId);
            ViewData["EcRenewalId"] = new SelectList(_context.TblEcrenewalDetail, "EcRenewalId", "EcRenewalId", tblLedger.EcRenewalId);
            ViewData["FinancialYearId"] = new SelectList(_context.MstFinancialYear, "FinancialYearId", "FinancialYear", tblLedger.FinancialYearId);
            ViewData["HouseRentDemandDetailId"] = new SelectList(_context.TblHouseRentDemandDetail, "HouseRentDemandDetailId", "HouseRentDemandDetailId", tblLedger.HouseRentDemandDetailId);
            ViewData["LandLeaseDemandDetailId"] = new SelectList(_context.TblLandLeaseDemandDetail, "LandLeaseDemandDetailId", "LandLeaseDemandDetailId", tblLedger.LandLeaseDemandDetailId);
            ViewData["MiscellaneousRecordId"] = new SelectList(_context.TblMiscellaneousRecord, "MiscellaneousRecordId", "Address", tblLedger.MiscellaneousRecordId);
            ViewData["ParkingDemandDetailId"] = new SelectList(_context.TblParkingFeeDemandDetail, "ParkingDemandDetailId", "ParkingDemandDetailId", tblLedger.ParkingDemandDetailId);
            ViewData["StallDemandDetailId"] = new SelectList(_context.TblStallDetailDemand, "StallDemandDetailId", "StallDemandDetailId", tblLedger.StallDemandDetailId);
            ViewData["TaxId"] = new SelectList(_context.MstTaxMaster, "TaxId", "TaxName", tblLedger.TaxId);
            ViewData["TransactionId"] = new SelectList(_context.TblTransactionDetail, "TransactionId", "TransactionId", tblLedger.TransactionId);
            return View(tblLedger);
        }

        // GET: Payment/Ledgers/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblLedger = await _context.TblLedger
                .Include(t => t.Applicant)
                .Include(t => t.CalendarYear)
                .Include(t => t.Demand)
                .Include(t => t.EcRenewal)
                .Include(t => t.FinancialYear)
                .Include(t => t.HouseRentDemandDetail)
                .Include(t => t.LandLeaseDemandDetail)
                .Include(t => t.MiscellaneousRecord)
                .Include(t => t.ParkingDemandDetail)
                .Include(t => t.StallDemandDetail)
                .Include(t => t.Tax)
                .Include(t => t.Transaction)
                .FirstOrDefaultAsync(m => m.LedgerId == id);
            if (tblLedger == null)
            {
                return NotFound();
            }

            return View(tblLedger);
        }

        // POST: Payment/Ledgers/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var tblLedger = await _context.TblLedger.FindAsync(id);
            _context.TblLedger.Remove(tblLedger);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        [Authorize]
        private bool TblLedgerExists(long id)
        {
            return _context.TblLedger.Any(e => e.LedgerId == id);
        }
        [Authorize]
        [Route("Payment/Ledgers/GetPaymentMode")]       
        public List<CommonFunctionModel> GetPaymentMode()
        {
            return _CommonRepo.SelectListPaymentModeTypeOffLine().ToList();

        }
        [Authorize]
        [Route("Payment/Ledgers/GetBankBranch")]
        public List<CommonFunctionModel> GetBankBranch()
        {
           return _CommonRepo.SelectListBankBranch().ToList();
        }

        [HttpGet]
        [Authorize]
        [Route("Payment/Ledgers/PrintNewWaterPaymentreceipt")]
        public IList<LedgerDemandVM> PrintNewWaterPaymentreceipt(long RecepitId)
        {
            return _repository.PrintNewWaterPaymentreceipt(RecepitId).ToList();
        }

        [HttpGet]
        [Authorize]
        [Route("Payment/Ledgers/printmetershifting")]
        public List<LedgerDemandVM> printmetershifting(long RecepitId)
        {
            return _repository.printmetershifting(RecepitId).ToList();
        }
        [HttpGet]
        [Authorize]
        [Route("Payment/Ledgers/PrintWaterPaymentreceipt")]
        public List<LedgerDemandVM> PrintWaterPaymentreceipt(int id)
        {
            return _repository.PrintWaterPaymentreceipt(id).ToList();
        }
        [Authorize]
        [Route("Payment/Ledgers/PrintPaymentreceipt")]
        public List<LedgerDemandVM> PrintPaymentreceipt(int id)
        {
            return _repository.PrintPaymentreceipt(id).ToList();
        }

        //Dupliate Recepit Print
        private void PopulateDropDowns()
        {

            ViewData["Transactiontype"] = _CommonRepo.SelectListTransactionType();
            ViewData["year"] = _CommonRepo.SelectListCalYear();

        }
        [Authorize]
        [Route("Payment/Ledgers/DuplicateRecepitPrint")]
        public IActionResult DuplicateRecepitPrint()
        {
            PopulateDropDowns();
            return View();
        }
        [Authorize]
        [Route("Payment/Ledgers/PaymentReceiptByReceiptNo")]
        public IActionResult PaymentReceiptByReceiptNo()
        {
            PopulateDropDowns();
            return View();
        }
        //Water details
        [Authorize]
        [Route("Payment/Ledgers/DuplicatewaterReceiptPrint")]
        public List<TranWaterConnectionModel> DuplicatewaterReceiptPrint(string ConsumerNo, int Year,int TransactionTypeId)
        {
            return _repository.fetchWaterDetails(ConsumerNo, Year, TransactionTypeId).ToList();
        }
        [Authorize]
        [Route("Payment/Ledgers/fetchledgerdata")]
        public List<LedgerDemandVM> fetchledgerdata(long RecepitId)
        {
            return _repository.fetchledgerdata(RecepitId).ToList();
        }

        [Authorize]
        [Route("Payment/Ledgers/fetchWatershifting")]
        public List<LedgerDemandVM> fetchWatershifting(long RecepitId)
        {
            return _repository.fetchWatershifting(RecepitId).ToList();
        }
        [Authorize]
        [Route("Payment/Ledgers/Watercharges")]
        public IList<LedgerDemandVM> Watercharges(long RecepitId)
        {
            return _repository.Watercharges(RecepitId).ToList().OrderBy(d=>d.TransactionId).ToList(); ;
        }
        [Authorize]
        [Route("Payment/Ledgers/fetchMiscellaneousdata")]
        public List<MiscellaneousRecordModel> fetchMiscellaneousdata(String Cid)
        {
            return _repository.fetchMiscellaneousdata(Cid).ToList();
        }
        [Authorize]
        [Route("Payment/Ledgers/printdemand")]
        public List<LedgerDemandVM> printdemand(long RecepitId)
        {
            return _repository.PrintDemand(RecepitId).ToList();
        }
        [Authorize]
        [Route("Payment/Ledgers/FetchlanddetailsByCID")]
        public List<LandOwneshipModel> FetchlanddetailsByCID(string Cid, string Ttin, string Year)
        {
            return _repository.FetchlanddetailsByCID(Cid,Ttin, Year).ToList();
        }


        [Authorize]
        [Route("Payment/Ledgers/Printreceiptforpropertytax")]
        public List<LedgerDemandVM> Printreceiptforpropertytax(int RecepitId)
        {
            return _repository.Printreceiptforpropertytax(RecepitId).ToList();
        }
        //******************************fetchvendorDetailByCid*******************************
        [Authorize]
        [Route("Payment/Ledgers/fetchHouseDetailByCid")]
        public IEnumerable<Object> fetchHouseDetailByCid(string cid, string ttin, int Year)
        {
            return _repository.fetchHouseDetailByCid(cid, ttin, Year).ToList();
        }
        [Authorize]
        [Route("Payment/Ledgers/fetchStallDetailByCid")]
        public IEnumerable<Object> fetchStallDetailByCid(string cid, string ttin, int Year)
        {
            return _repository.fetchStallDetailByCid(cid, ttin, Year).ToList();
        }
        [Authorize]
        [Route("Payment/Ledgers/fetchLandLeaseDetailByCid")]
        public IEnumerable<Object> fetchLandLeaseDetailByCid(string cid, string ttin, int Year)
        {
            return _repository.fetchLandLeaseDetailByCid(cid, ttin, Year).ToList();
        }
        [Authorize]
        [Route("Payment/Ledgers/fetchParkingDetailByCid")]
        public IEnumerable<Object> fetchParkingDetailByCid(string cid, string ttin, int Year)
        {
            return _repository.fetchParkingDetailByCid(cid, ttin, Year).ToList();
        }
        [Authorize]
        [Route("Payment/Ledgers/fetchVendorRecepit")]
        public IEnumerable<Object> fetchVendorRecepit(long ReceiptId)
        {
            return _repository.fetchVendorRecepit(ReceiptId).ToList();
        }

        //******************************miscellaeunes paymrnt receipt*******************************
        [Authorize]
        [Route("Payment/Ledgers/PrintMiscellauenousreceipt")]
        public IList<LedgerDemandVM> PrintMiscellauenousreceipt(int id)
        {
            return _repository.PrintMiscellauenousreceipt(id).ToList();
        }
        //******************************Vendor paymrnt receipt*******************************
        [Authorize]
        [Route("Payment/Ledgers/PrintHousereceipt")]
        public IList<LedgerDemandVM> PrintHousereceipt(int id)
        {
            return _repository.PrintHousereceipt(id).ToList();
        }
        [Authorize]
        [Route("Payment/Ledgers/Printstallreceipt")]
        public IList<LedgerDemandVM> Printstallreceipt(int id)
        {
            return _repository.Printstallreceipt(id).ToList();
        }
        [Authorize]
        [Route("Payment/Ledgers/PrintLandLeasereceipt")]
        public IList<LedgerDemandVM> PrintLandLeasereceipt(int id)
        {
            return _repository.PrintLandLeasereceipt(id).ToList();
        }
        [Authorize]
        [Route("Payment/Ledgers/PrintParkingFeereceipt")]
        public IList<LedgerDemandVM> PrintParkingFeereceipt(int id)
        {
            return _repository.PrintParkingFeereceipt(id).ToList();
        }
        //***********************************************payment mode****************************************
        [Authorize]
        [Route("Payment/Ledgers/PrintPaymentModes")]
        public IList<LedgerDemandVM> PrintPaymentModes(int ReceiptId)
        {
            return _repository.PrintPaymentModes(ReceiptId).ToList();
        }
        //*********************************************** duplicate payment mode****************************************
        [Authorize]
        [Route("Payment/Ledgers/PrintDuplicatePaymentModes")]
        public IList<LedgerDemandVM> PrintDuplicatePaymentModes(long ReceiptId)
        {
            return _repository.PrintDuplicatePaymentModes(ReceiptId).ToList();
        }
        [Authorize]
        [Route("Payment/Ledgers/fetchDreceiptuser")]
        public IList<LedgerDemandVM> fetchDreceiptuser(long ReceiptId)
        {
            return _repository.fetchDreceiptuser(ReceiptId).ToList();
        }
        [Authorize]
        [Route("Payment/Ledgers/fetchreceiptuser")]
        public IList<LedgerDemandVM> fetchreceiptuser(int RecepitId)
        {
            return _repository.fetchreceiptuser(RecepitId).ToList();
        }
        //******************************************** Land Transaction fee********************************************************************
        [Authorize]
        [Route("Payment/Ledgers/GetLandTransactionFee")]
        public List<LedgerDemandVM> GetLandTransactionFee(string DemandNo, string Ttin, string Cid)
        {
            return _repository.GetLandTransactionFee(DemandNo, Ttin, Cid).ToList();
        }
        [Authorize]
        [Route("Payment/Ledgers/LandTransactionFeeRecepit")]
        public IList<LedgerDemandVM> LandTransactionFeeRecepit(int RecepitId)
        {
            return _repository.LandTransactionFeeRecepit(RecepitId).ToList();
        }
        //******************************************** DuplicateDemandPrint********************************************************************
        [Route("Payment/Ledgers/DuplicateDemandPrint")]
        public IActionResult DuplicateDemandPrint()
        {
            PopulateDropDowns();
            return View();
        }
        [Authorize]
        [Route("Payment/Ledgers/FetchDuplicateDemandProperty")]
        public List<LandOwneshipModel> FetchDuplicateDemandProperty(string Cid, string Ttin, string Year)
        {
            return _obj.FetchDuplicateDemandProperty(Cid, Ttin, Year).ToList();
        }
        [Authorize]
        [Route("Payment/Ledgers/fetchdemandreceiptuser")]
        public IList<LedgerDemandVM> fetchdemandreceiptuser(int DemandNoId)
        {
            return _obj.fetchdemandreceiptuser(DemandNoId).ToList();
        }
        [Authorize]
        [Route("Payment/Ledgers/PrintDemandforpropertytax")]
        public List<LedgerDemandVM> PrintDemandforpropertytax(int DemandNoId)
        {
            return _obj.PrintDemandforpropertytax(DemandNoId).ToList();
        }
        [Authorize]
        [Route("Payment/Ledgers/GetWaterConnectionId")]
        public async Task< decimal> GetWaterConnectionId(string DemandNo, string ConsumerNo)
        {
            return  await _repository.GetWaterConnectionId(DemandNo, ConsumerNo);
        }


        //********************************************************************************Land Transaction************************************************************************************************
        [Authorize]
        [Route("Payment/Ledgers/fetchLandTransactions")]
        public List<LedgerDemandVM> fetchLandTransactions(string Ttin, string Cid)
        {
            return _repository.fetchLandTransactions(Ttin, Cid).ToList();
        }
        [Authorize]
        [Route("Payment/Ledgers/landtransactionRecepit")]
        public List<LedgerDemandVM> landtransactionRecepit(long ReceiptId)
        {
            return  _repository.landtransactionRecepit(ReceiptId);
        }
        [Authorize]
        [Route("Payment/Ledgers/creatorlandtransactions")]
        public List<LedgerDemandVM> creatorlandtransactions(long ReceiptId)
        {
            return _repository.creatorlandtransactions(ReceiptId);
        }

        //******************************************************************************** sewerage connection************************************************************************************************
        [Authorize]
        [Route("Payment/Ledgers/SewerageConnectionRecepit")]
        public List<LedgerDemandVM> SewerageConnectionRecepit(long RecepitId)
        {
            return _repository.SewerageConnectionRecepit(RecepitId).ToList();
        }

        //******************************************************************************** sewerage connection************************************************************************************************
        [Authorize]
        [Route("Payment/Ledgers/GetUnScheduledParkingRecord")]
       
        public List<LedgerDemandVM> GetUnScheduledParkingRecord(string DemandNo, string Cid)
        {
            return _repository.GetUnScheduledParkingRecord(DemandNo, Cid).ToList();
        }
        [Authorize]
        [Route("Payment/Ledgers/UnScheduledParkingRecordrecepit")]
        public List<LedgerDemandVM> UnScheduledParkingRecordrecepit(long RecepitId)
        {
            return _repository.UnScheduledParkingRecordrecepit(RecepitId).ToList();
        }



        //******************************************************************************** Construction Approval Application Fee Detail************************************************************************************************
        [Authorize]
        [Route("Payment/Ledgers/FetchConstructionApprovalApplicationFeeDetail")]

        public List<LedgerDemandVM> FetchConstructionApprovalApplicationFeeDetail(string DemandNo,string Ttin, string Cid)
        {
            return _repository.FetchConstructionApprovalApplicationFeeDetail(DemandNo, Ttin, Cid).ToList();
        }

        [Authorize]
        [Route("Payment/Ledgers/ConstructionApprovalApplicationFeeDetailRecepit")]
        public List<LedgerDemandVM> ConstructionApprovalApplicationFeeDetailRecepit(long RecepitId)
        {
            return _repository.ConstructionApprovalApplicationFeeDetailRecepit(RecepitId).ToList();
        }



        //******************************************************************************** Construction Approval ************************************************************************************************
        [Authorize]
        [Route("Payment/Ledgers/FetchConstructionApproval")]

        public List<LedgerDemandVM> FetchConstructionApproval(string DemandNo, string Ttin, string Cid)
        {
            return _repository.FetchConstructionApproval(DemandNo, Ttin, Cid).ToList();
        }

        [Authorize]
        [Route("Payment/Ledgers/ConstructionApprovalRecepit")]
        public List<LedgerDemandVM> ConstructionApprovalRecepit(long RecepitId)
        {
            return _repository.ConstructionApprovalRecepit(RecepitId).ToList();
        }

        //********************************************************************************  Printnames ************************************************************************************************
        [Authorize]
        [Route("Payment/Ledgers/PrintNames")]

        public IList<LedgerDemandVM> PrintNames(int id)
        {
            return _repository.PrintNames(id).ToList();
        }
        
        [Route("Payment/Ledgers/GetReceiptDetails")]
        public List<PaymentReceiptByReceiptNo> GetReceiptDetails(string ReceiptNo)
        {

            List<PaymentReceiptByReceiptNo> _dList = null;
            return _dList = _res.GetReceiptDetails(ReceiptNo);
        }

        [Route("Payment/Ledgers/GetDemand")]
        public IList<LedgerDemandVM> GetDemand(int id)
        {

            IList<LedgerDemandVM> _dList = null;
            return _dList = _repository.PrintDemand(id);
        }

        [Route("Payment/Ledgers/fetchwatertax")]
        public IList<LedgerDemandVM> fetchwatertax(long RecepitId)
        {

            IList<LedgerDemandVM> _dList = null;
            return _dList = _repository.fetchwatertax(RecepitId);
        }

        [Route("Payment/Ledgers/fetchVacuumtanker")]
        public List<VacuumTankerServiceVM> fetchVacuumtanker(string RecepitNo, string Name)
        {

            List<VacuumTankerServiceVM> _dList = null;
            return _dList = _repository.fetchVacuumtanker(RecepitNo, Name);
        }

        //***************************************************   ENVIRONMENTAL CLERANCE   **************************************************************************
        [Authorize]
        [Route("Payment/Ledgers/GetECDemandWithSearch")]
        public List<LedgerDemandVM> GetECDemandWithSearch(string DemandNo, string Cid)
        {
            return _repository.GetECDemandWithSearch(DemandNo, Cid).ToList();
        }

        //******************************************************************************** ENVIRONMENTAL CLERANCE ************************************************************************************************
        [Authorize]
        [Route("Payment/Ledgers/PrintEC")]
        public IList<LedgerDemandVM> PrintEC(long RecepitId)
        {
            return _repository.PrintEC(RecepitId).ToList();
        }

        [Authorize]
        [Route("Payment/Ledgers/fetchECDetail")]
        public IEnumerable<Object> fetchECDetail(string Name, string Cid)
        {
            return _repository.fetchECDetail(Name, Cid).ToList();
        }

        [Authorize]
        [Route("Payment/Ledgers/fetchECRecepit")]
        public IEnumerable<Object> fetchECRecepit(long ReceiptId)
        {
            return _repository.fetchECRecepit(ReceiptId).ToList();
        }


        [Authorize][HttpGet]
        [Route("Payment/Ledgers/FetchLatestTaxCalculationAPI")]
        public async Task<decimal> FetchLatestTaxCalculationAPI(string ids)
        {
            try
            {

                List<SqlParameter> parms = new List<SqlParameter>
                {
                    // Create parameter(s)    
                    new SqlParameter { ParameterName = "@ids", Value = ids },
                    //new SqlParameter { ParameterName = "@taxpayerid", Value = TaxPayerId }

                };
                //var resultS = await ctx.GetLandTaX.FromSqlRaw("EXECUTE [dbo].[spTaxCalculationAPI] @calendarYearId,@taxpayerid", parms.ToArray()).ToListAsync();
                var resultS = await _context.TaxCalculationAPI.FromSqlRaw("EXECUTE [dbo].[spTaxCalculationAPICheckInWeb] @ids", parms.ToArray()).ToListAsync();

                List<spTaxCalculationAPIModel> data = resultS.Select(s => new spTaxCalculationAPIModel
                 {
                     Sl = s.Sl,
                     pType = s.pType,
                     calendarYearId = s.calendarYearId,
                     calendarYear = s.calendarYear,
                     plotNo = s.plotNo,
                     landAcerage = s.landAcerage,
                     landOwnershipId = s.landOwnershipId,
                     taxPayerId = s.taxPayerId,
                     thramNo = s.thramNo,
                     pLR = s.pLR,
                     lastTaxPaidYear = s.lastTaxPaidYear,
                     landDetailId = s.landDetailId,
                     isApportioned = s.isApportioned,
                     LandTaxId = s.LandTaxId,
                     LandTaxRate = s.LandTaxRate,
                     LandTaxAmount = s.LandTaxAmount,
                     LandTaxPenalty = s.LandTaxPenalty,
                     UDTaxId = s.UDTaxId,
                     UDTaxApplicable = s.UDTaxApplicable,
                     penaltyOrRate = s.penaltyOrRate,
                     UDTaxRate = s.UDTaxRate,
                     UDTaxAmount = s.UDTaxAmount,
                     UDTaxPenaltyAmount = s.UDTaxPenaltyAmount,
                     UnitTaxId = s.UnitTaxId,
                     GarbageTaxId = s.GarbageTaxId,
                     StreetLightTaxId = s.StreetLightTaxId,
                     noOfUnit = s.noOfUnit,
                     UnitTax = s.UnitTax,
                     GarbageTax = s.GarbageTax,
                     StreetLightTax = s.StreetLightTax,
                     UnitTaxRate = s.UnitTaxRate,
                     GarbageTaxRate = s.GarbageTaxRate,
                     StreetLightRate = s.StreetLightRate,
                     UnitTaxPenalty = s.UnitTaxPenalty,
                     GarbageTaxPenalty = s.GarbageTaxPenalty,
                     StreetLightTaxPenalty = s.StreetLightTaxPenalty,
                     PenaltyDays = s.PenaltyDays,
                     TotalDays = s.TotalDays,
                     flatNo = s.flatNo,
                     //GrandTotal = (s.LandTaxAmount + s.UDTaxAmount + s.UnitTax + s.GarbageTax + s.StreetLightTax)
                 }
                        ).ToList();
                return data.Select(x => new 
                {
                    GrandTotal = x.LandTaxAmount+x.UDTaxAmount+x.UnitTax+x.GarbageTax+x.StreetLightTax                   
                }).ToList().Sum(a=>a.GrandTotal);

                ;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }





    }
}
