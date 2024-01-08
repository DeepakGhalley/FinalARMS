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
using QRCoder;
using System.Drawing;
using System.IO;
using Microsoft.Data.SqlClient;

namespace ARMS.Areas.Water.Controllers
{
    [Area("Water")]
    [Authorize]
    public class WaterMeterReadingsController : Controller
    {
        private readonly tt_dbContext _context;
        ICommonFunction _CommonRepo = new CommonFunctionBLL();
        readonly IWaterMeterReading _repository = new WaterMeterReadingBLL();
        public WaterMeterReadingsController(tt_dbContext context)
        {
            _context = context;
        }

        // GET: Water/WaterMeterReadings
        [Route("Water/WaterMeterReadings")]
        public async Task<IActionResult> Index()
        {
            _ = new List<WaterMeterReadingModel>();
            IList<WaterMeterReadingModel> obj = _repository.GetAll();
            ViewData["Zone"] = _CommonRepo.SelectListZone();
            ViewData["ZoneReader"] = _CommonRepo.SelectListZoneReader();
            ViewData["Year"] = _CommonRepo.SelectListCalYear();
            ViewData["Month"] = _CommonRepo.SelectListMonths();
            return View(obj);


        }

        // GET: Water/WaterMeterReadings/BillGenerate
        [Route("Water/WaterMeterReadings/BillGenerate")]
        public async Task<IActionResult> BillGenerate()
        {
            _ = new List<WaterMeterReadingModel>();
            IList<WaterMeterReadingModel> obj = _repository.GetAll();
            return View(obj);


        }
        
        // GET: Water/WaterMeterReadings/Details/5
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

        // GET: Water/WaterMeterReadings/ZoneWiseBillGenerate
        [Route("Water/WaterMeterReadings/ZoneWiseBillGenerate")]
        public IActionResult ZoneWiseBillGenerate()
        {
            ViewData["Zone"] = _CommonRepo.SelectListZone();
            ViewData["Year"] = _CommonRepo.SelectListCalYear();
            ViewData["Month"] = _CommonRepo.SelectListMonths();
            return View();
        }

        // GET: Water/WaterMeterReadings/ZoneWiseBillPrint
        [Route("Water/WaterMeterReadings/ZoneWiseBillPrint")]
        public IActionResult ZoneWiseBillPrint()
        {
            ViewData["Zone"] = _CommonRepo.SelectListZone();
            ViewData["Year"] = _CommonRepo.SelectListCalYear();
            ViewData["Month"] = _CommonRepo.SelectListMonths();
            return View();
        }

        // GET: Water/WaterMeterReadings/WaterPaymentReceipt
        [Route("Water/WaterMeterReadings/WaterPaymentReceipt")]
        public IActionResult WaterPaymentReceipt()
        {
            ViewData["Year"] = _CommonRepo.SelectListCalYear();
            ViewData["Month"] = _CommonRepo.SelectListMonths();
            return View();
        }


        // GET: Water/WaterMeterReadings/IndividualWiseBillPrint
        [HttpGet]
        [Route("Water/WaterMeterReadings/IndividualWiseBillPrint")]        
        public IActionResult IndividualWiseBillPrint()
        {
            ViewData["Zone"] = _CommonRepo.SelectListZone();
            ViewData["Year"] = _CommonRepo.SelectListCalYear();
            ViewData["Month"] = _CommonRepo.SelectListMonths();
            return View();
        }

       

        //[HttpPost]
        //[Route("Water/WaterMeterReadings/IndividualWiseBillPrint")]
        //public IActionResult IndividualWiseBillPrint(string IDconsumerno)
        //{

        //    ViewData["Zone"] = _CommonRepo.SelectListZone();
        //    ViewData["Year"] = _CommonRepo.SelectListCalYear();
        //    ViewData["Month"] = _CommonRepo.SelectListMonths();

        //    QRCodeGenerator qrGenerator = new QRCodeGenerator();
        //    QRCodeData qrCodeData = qrGenerator.CreateQrCode(IDconsumerno, QRCodeGenerator.ECCLevel.Q);

        //    string fileGuid = Guid.NewGuid().ToString().Substring(0, 4);

        //    qrCodeData.SaveRawData("wwwroot/qrr/file-" + fileGuid + ".qrr", QRCodeData.Compression.Uncompressed);

        //    QRCodeData qrCodeData1 = new QRCodeData("wwwroot/qrr/file-" + fileGuid + ".qrr", QRCodeData.Compression.Uncompressed);

        //    QRCode qrCode = new QRCode(qrCodeData1);
        //    Bitmap qrCodeImage = qrCode.GetGraphic(20);
        //    return View(BitmapToBytesCode(qrCodeImage));
        //}




        // GET: Water/WaterMeterReadings/Create
        [Route("Water/WaterMeterReadings/Create")]
        public IActionResult Create()
        {
            ViewData["ZoneId"] = _CommonRepo.SelectListZone();
            ViewData["YearId"] = _CommonRepo.SelectListCalendarYear();
            ViewData["MonthId"] = _CommonRepo.SelectListMonths();
            PopulateDropDowns();
            return View();
        }

        // GET: Water Bill Edit  AnyWaterBillEdit
        [Route("Water/WaterMeterReadings/WaterBillEdit")]
        public IActionResult WaterBillEdit()
        {
            ViewData["Year"] = _CommonRepo.SelectListCalYear();
            ViewData["Month"] = _CommonRepo.SelectListMonths();
            PopulateDropDowns();

            return View();
        }

        [Route("Water/WaterMeterReadings/AnyWaterBillEdit")]
        public IActionResult AnyWaterBillEdit()
        {
            ViewData["Year"] = _CommonRepo.SelectListCalYear();
            ViewData["Month"] = _CommonRepo.SelectListMonths();
            PopulateDropDowns();

            return View();
        }

        private void PopulateDropDowns()
        {
            ViewData["ModificationReason"] = _CommonRepo.SelectListWaterBIllEditReason();

            ViewData["WaterConnectionId"] = _CommonRepo.SelectListWorkLevel();
            ViewData["WaterConnectionStatusId"] = _CommonRepo.SelectListWaterConnectionStatus();
            ViewData["WaterMeterTypeId"] = _CommonRepo.SelectListWaterMeterType();
            ViewData["WaterConnectionTypeId"] = _CommonRepo.SelectListWaterConnectionType();
            ViewData["WaterLineTypeId"] = _CommonRepo.SelectListWaterLineType();
          
        }

        // GET: Water/WaterMeterReadings/WaterMeterReadingEdit
        [Route("Water/WaterMeterReadings/WaterMeterReadingEdit")]
        public IActionResult WaterMeterReadingEdit()
        {
            ViewData["Year"] = _CommonRepo.SelectListCalYear();
            ViewData["Month"] = _CommonRepo.SelectListMonths();
            PopulateDropDowns();
            return View();
        }

        // POST: Water/WaterMeterReadings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Water/WaterMeterReadings/Create")]
        public async Task<IActionResult> Create(WaterMeterReadingModel obj)
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
                    return RedirectToAction(nameof(Index));
                }

            }
            PopulateDropDowns();

            return View(obj);
        }

        // GET: Water/WaterMeterReadings/Edit/5
        [Route("Water/WaterMeterReadings/Edit")]
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

        // POST: Water/WaterMeterReadings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Water/WaterMeterReadings/Edit")]
        public async Task<IActionResult> Edit(WaterMeterReadingModel obj)
        {
            var Data = await _repository.Details((int?)obj.WaterMeterReadingId);
            if (Data.WaterMeterReadingId != obj.WaterMeterReadingId)
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
                    if (!TrnWaterMeterReadingExists((int)obj.WaterMeterReadingId))
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

        // GET: Water/WaterMeterReadings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trnWaterMeterReading = await _context.TrnWaterMeterReading
                .Include(t => t.TrnWaterConnection)
                .Include(t => t.WaterConnectionStatus)
                .Include(t => t.WaterConnectionType)
                .Include(t => t.WaterLineType)
                .Include(t => t.WaterMeterType)
                .FirstOrDefaultAsync(m => m.TrnWaterMeterReadingId == id);
            if (trnWaterMeterReading == null)
            {
                return NotFound();
            }

            return View(trnWaterMeterReading);
        }

        // POST: Water/WaterMeterReadings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var trnWaterMeterReading = await _context.TrnWaterMeterReading.FindAsync(id);
            _context.TrnWaterMeterReading.Remove(trnWaterMeterReading);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TrnWaterMeterReadingExists(int id)
        {
            return _context.TrnWaterMeterReading.Any(e => e.TrnWaterMeterReadingId == id);
        }

      
        [Route("Water/WaterMeterReadings/CheckDuplicateReadings")]
        public List<WaterMeterReadingModel> CheckDuplicateReadings(int WaterConnectionId, DateTime ReadingDate)
        {
            return _repository.CheckDuplicateReadings(WaterConnectionId, ReadingDate);
        }

        [HttpPost]
        [Route("Water/WaterMeterReadings/CreateWMR")]
        public JsonResult CreateWMR([FromBody] List<WaterMeterReadingModel> json_data)
        {
            long pk = 0;
            try
            {
            //    if (json_data == null)
            //{
            //    json_data = new List<WaterMeterReadingModel>();
            //}
            WaterMeterReadingModel obj = new WaterMeterReadingModel();
         
            foreach (WaterMeterReadingModel item in json_data)
            {
                //var consumption = item.PreviousReading - item.Reading;

                obj.WaterMeterReadingId = item.WaterMeterReadingId;
                obj.WaterConnectionId = item.WaterConnectionId;
                //obj.WaterConnectionStatusId = item.WaterConnectionStatusId;
                //obj.WaterConnectionTypeId = item.WaterConnectionTypeId;
                //obj.WaterLineTypeId = item.WaterLineTypeId;
                //obj.WaterMeterTypeId = item.WaterMeterTypeId;
                obj.ReadBy = item.ReadBy;
                obj.Reading = item.Reading;
                obj.ReadingDate = item.ReadingDate;
                obj.PreviousReading = item.PreviousReading;
                obj.PreviousReadingDate = item.PreviousReadingDate; 
               // obj.NoOfUnit = item.NoOfUnit;
                obj.Consumption =item.Consumption;
                //obj.IsPermanentConnection = item.IsPermanentConnection;
                ////obj.Seweragename = true;
                //obj.SolidWaste = item.SolidWaste;
               // obj.BillingAddress = item.BillingAddress;
                //obj.PrimaryMobileNo = item.PrimaryMobileNo;
                //obj.TransactionId = item.TransactionId;
                //obj.StandardConsumption = item.StandardConsumption;

                obj.CreatedBy= Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
                obj.CreatedOn = DateTime.Now;
                pk=_repository.SaveWaterMeterReading(obj);
            }

                //if (pk > 0)
                //{
                //    TempData["msg"] = "Data Saved Successfully!";

                //}
                //else
                //{
                //    TempData["msg"] = "New record creation failed";
                //}
            }
            catch (DbUpdateConcurrencyException)
            {
                return Json (pk);

            }

            return Json(pk);
         }

        [Route("Water/WaterMeterReadings/fetchWaterConnectionByConsumerNo")]
        public List<WaterMeterReadingModel> fetchWaterConnectionByConsumerNo(string consumerNo, string waterMeterNo)
        {

            List<WaterMeterReadingModel> _dList = null;
            return _dList = _repository.fetchWaterConnectionByConsumerNo(consumerNo, waterMeterNo);
        }

        [Route("Water/WaterMeterReadings/fetchReadinfById")]
        public List<WaterMeterReadingModel> fetchReadinfById(int id)
        {
            List<WaterMeterReadingModel> _dList = null;
            return _dList = _repository.fetchReadinfById(id);
        }
        //[Route("Water/WaterMeterReadings/fetchReadinfById")]
        //public List<WaterMeterReadingModel> fetchReadinfById(int id)
        //{

        //    List<WaterMeterReadingModel> _dList = null;
        //    return _dList = _repository.fetchReadinfById(id);
        //}

        [Route("Water/WaterMeterReadings/GenerateDemand")]
        public JsonResult GenerateDemand([FromBody] List<WaterMeterReadingModel> json_data)
        {
            long returnvalue = 0;
            try
            {

                if (json_data == null)
            {
                json_data = new List<WaterMeterReadingModel>();
            }
            WaterMeterReadingModel obj = new WaterMeterReadingModel();

            foreach (WaterMeterReadingModel item in json_data)
            {
                obj.WaterMeterReadingId = item.WaterMeterReadingId;
                obj.CreatedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
                obj.CreatedOn = DateTime.Now;
                 returnvalue=_repository.GenerateDemand(obj);

            }
              
              
            }
            catch (DbUpdateConcurrencyException)
            {
                returnvalue = 0;
            }

            return Json(returnvalue);
        }

        //Generate Zone Wise Bill
        [Route("Water/WaterMeterReadings/GenerateZoneWiseBill")]
        public List<WaterMeterReadingModel> GenerateZoneWiseBill(int zone, int year, int month)
        {

            List<WaterMeterReadingModel> _dList = null;
            return _dList = _repository.GenerateZoneWiseBill(zone, year, month);
        }

        //Water Reading INFO
        [Route("Water/WaterMeterReadings/getReadingInfo")]
        public List<WaterMeterReadingModel> getReadingInfo(int id)
        {

            List<WaterMeterReadingModel> _dList = null;
            return _dList = _repository.getReadingInfo(id);
        }

        //Water Billing INFO
        [Route("Water/WaterMeterReadings/GetBillingInfo")]
        public List<WaterMeterReadingModel> getBillingInfo(string consumerno, int year, int month)
        {

            List<WaterMeterReadingModel> _dList = null;
            return _dList = _repository.getBillingInfo(consumerno, year, month);

        }

        //Water Slab&Rate INFO
        [Route("Water/WaterMeterReadings/GetSlabInfo")]
        public List<SlabVM> getSlabInfo(int id)
        {

            List<SlabVM> _dList = null;
            return _dList = _repository.getSlabInfo(id);
        }       
        
        //Get Service Charges INFO
        [Route("Water/WaterMeterReadings/GetServiceChargesInfo")]
        public List<WaterMeterReadingModel> getServiceChargesInfo(int id)
        {

            List<WaterMeterReadingModel> _dList = null;
            return _dList = _repository.getServiceChargesInfo(id);
        }        
        
        //Get Utility Charges INFO
        [Route("Water/WaterMeterReadings/GetUtilityChargesInfo")]
        public List<WaterMeterReadingModel> getUtilityChargesInfo(int id, string consumerno,int CalendarYear)
        {

            List<WaterMeterReadingModel> _dList = null;
            return _dList = _repository.getUtilityChargesInfo(id, consumerno, CalendarYear);
        }

        //Water Billing INFO
        [Route("Water/WaterMeterReadings/getZoneWiseBillingInfo")]
        public List<WaterMeterReadingModel> getZoneWiseBillingInfo(int zone, int year/*, int month*/)
        {

            List<WaterMeterReadingModel> _dList = null;
            return _dList = _repository.getZoneWiseBillingInfo(zone, year/*, month*/);

        }

        //Water READING INFO
        [Route("Water/WaterMeterReadings/GetMeterReadingDetails")]
        public List<WaterMeterReadingModel> getMeterReadingDetails(string consumerno, int year, int month)
        {

            List<WaterMeterReadingModel> _dList = null;
            return _dList = _repository.getMeterReadingDetails(consumerno, year, month);

        }

        //WATER METER READING EDIT
        // GET: Water/WaterMeterReadings/EditMeterReading/5
        [Route("Water/WaterMeterReadings/EditMeterReading")]
        public JsonResult EditMeterReading([FromBody] List<WaterMeterReadingModel> json_data)
        {
            long returnvalue = 0;
            try
            {

                if (json_data == null)
                {
                    json_data = new List<WaterMeterReadingModel>();
                }
                WaterMeterReadingModel obj = new WaterMeterReadingModel();

                foreach (WaterMeterReadingModel item in json_data)
                {
                    obj.WaterMeterReadingId = item.WaterMeterReadingId;
                    obj.ReadingDate = item.ReadingDate;
                    obj.PreviousReadingDate = item.PreviousReadingDate;
                    obj.Reading = item.Reading;
                    obj.PreviousReading = item.PreviousReading;
                    returnvalue = _repository.Update(obj);

                }


            }
            catch (DbUpdateConcurrencyException)
            {
                returnvalue = 0;
            }

            return Json(returnvalue);
        }

        //Water Bill Edit
        [Route("water/WaterMeterReadings/fetchWaterBillEdit")]
        public List<WaterMeterReadingModel> fetchWaterBillEdit(string ConsumerNo, int Year, int Month)
        {

            List<WaterMeterReadingModel> _dList = null;
            return _dList = _repository.fetchWaterBillEdit(ConsumerNo, Year, Month);
        }

        [Route("water/WaterMeterReadings/checkPaymentStatusForWaterBillEdit")]
        public List<WaterMeterReadingModel> checkPaymentStatusForWaterBillEdit(int WaterMeterReadingId)
        {

            List<WaterMeterReadingModel> _dList = null;
            return _dList = _repository.checkPaymentStatusForWaterBillEdit(WaterMeterReadingId);
        }


        //WATER BILL EDIT
        // GET: Water/WaterMeterReadings/WaterBillEditupdate/5
        [Route("Water/WaterMeterReadings/WaterBillEditupdate")]
        public JsonResult WaterBillEditupdate([FromBody] List<WaterMeterReadingModel> json_data)
        {
            long returnvalue = 0;
            try
            {

                if (json_data == null)
                {
                    json_data = new List<WaterMeterReadingModel>();
                }
                WaterMeterReadingModel obj = new WaterMeterReadingModel();

                foreach (WaterMeterReadingModel item in json_data)
                {
                    obj.WaterMeterReadingId = item.WaterMeterReadingId;
                    obj.WaterConnectionTypeId = item.WaterConnectionTypeId;
                    obj.Reading = item.Reading;
                    obj.Remarks = item.Remarks;
                    obj.NoOfUnit = item.NoOfUnit;
                    obj.StandardConsumption = item.StandardConsumption;
                    obj.ModifiedBy= Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
                    returnvalue = _repository.WaterBillEditupdate(obj);

                }


            }
            catch (DbUpdateConcurrencyException)
            {
                returnvalue = 0;
            }

            return Json(returnvalue);
        }

        //Water PAYMENT INFO ---START--
        [Route("Water/WaterMeterReadings/GetWaterPaymentDetails")]
        public List<WaterMeterReadingModel> GetWaterPaymentDetails(string ConsumerNo, int Year)
        {

            List<WaterMeterReadingModel> _dList = null;
            return _dList = _repository.GetWaterPaymentDetails(ConsumerNo, Year);

        }

        [Route("Water/WaterMeterReadings/GetWaterPaymentInfo")]
        public List<WaterMeterReadingModel> GetWaterPaymentInfo(int TransactionId)
        {

            List<WaterMeterReadingModel> _dList = null;
            return _dList = _repository.GetWaterPaymentInfo(TransactionId);

        }

        [Route("Water/WaterMeterReadings/FetchWaterPaymentInfo")]
        public List<WaterMeterReadingModel> FetchWaterPaymentInfo(int TransactionId)
        {

            List<WaterMeterReadingModel> _dList = null;
            return _dList = _repository.FetchWaterPaymentInfo(TransactionId);

        }


        //Display Water Meter Reading Details
        [Route("Water/WaterMeterReadings/getWaterMeterReadingDetails")]
        public List<WaterMeterReadingModel> getWaterMeterReadingDetails(int zone,DateTime ReadingDate)
        {
          
            return  _repository.getWaterMeterReadingDetails(zone,  ReadingDate).ToList();
        }

        [Route("Water/WaterMeterReadings/GetWaterMeterPayment")]
        public List<WaterMeterReadingModel> GetWaterMeterPayment(int id)
        {

            List<WaterMeterReadingModel> _dList = null;
            return _dList = _repository.GetWaterMeterPayment(id);
        }


        //public async Task<IActionResult> PrintReport()
        //{
        //    DateTime fd = Convert.ToDateTime(DateTime.Today.AddDays(-1));
        //    DateTime td = Convert.ToDateTime(DateTime.Now);

        //    //string mimetype = "";
        //    //int extension = 1;
        //    //var ReportPath = $"{this._IWebHostEnvironment.WebRootPath}\\Reports\\rptOnlinePaymentByFromDateToDate.rdlc";
        //    Dictionary<string, string> parameter = new Dictionary<string, string>();
        //  //  LocalReport lc = new LocalReport(ReportPath);
        //    //sp
        //    List<SqlParameter> parms = new List<SqlParameter>
        //        {
        //            // Create parameter(s)    
        //            new SqlParameter { ParameterName = "@FromDate", Value = fd },
        //            new SqlParameter { ParameterName = "@ToDate", Value = td }
        //        };
        //    var resultS = await _context.OnlinePaymentByFromDateToDate.FromSqlRaw("EXECUTE [dbo].[rptOnlinePaymentByFromDateToDate] @FromDate,@ToDate", parms.ToArray()).ToListAsync();
        //    List<OnlinePaymentByFromDateToDateModel> data = resultS.Select(s => new OnlinePaymentByFromDateToDateModel
        //            {
        //                Sl = s.Sl,
        //                PaymentDate = s.PaymentDate,
        //                ReceiptNo = s.ReceiptNo,
        //                PaymentModeNo = s.PaymentModeNo,
        //                PaymentModeDate = s.PaymentModeDate,
        //                TotalAmount = s.TotalAmount
        //            }
        //    ).ToList();
        //    //sp end
        //    //lc.AddDataSource("DataSet1", resultS);
        //    //var result = lc.Execute(RenderType.Pdf, extension, parameter, mimetype);
        //    //return File(result.MainStream, "application/pdf");

        //}



        // ***************** Check ConsumerNo Sequence *****************
        [Route("Water/WaterMeterReadings/CheckConsumerNoSequence")]
        public IActionResult CheckConsumerNoSequence()
        {
            ViewData["Zone"] = _CommonRepo.SelectListZone();
            return View();
        }
        [Route("Water/WaterMeterReadings/SearchCnoSequence")]
        public List<WaterMeterReadingModel> SearchCnoSequence(int zone)
        {
            List<WaterMeterReadingModel> _dList = null;
            return _dList = _repository.SearchCnoSequence(zone);
        }

        [Route("Water/WaterMeterReadings/Paymentstatement")]
        public IActionResult Paymentstatement()
        {
            ViewData["Year"] = _CommonRepo.SelectListCalYear();
            ViewData["Month"] = _CommonRepo.SelectListMonths();
            PopulateDropDowns();
            return View();
        }

        [Route("Water/WaterMeterReadings/fetchWater")]
        public IList<TranWaterConnectionModel> fetchWater(string ConsumerNo, int Year,int eMonth,int sMonth)
        {
            IList<TranWaterConnectionModel> _dList = null;
            return _dList = _repository.fetchWaterDetails(ConsumerNo,Year, sMonth, eMonth);
        }

        // ***************** End of Check ConsumerNo Sequence *****************




    }
}