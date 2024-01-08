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
using Microsoft.AspNetCore.Http;
using QRCoder;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;


namespace ARMS.Areas.MiscellaneousRecord
{
    [Area("MiscellaneousRecord")]
    public class MiscellaneousRecordsController : Controller
    {
        private readonly tt_dbContext _context;
        ICommonFunction _CommonRepo = new CommonFunctionBLL();
        readonly IMiscellaneousRecord _repository = new MiscellaneousRecordBLL();
        readonly IMiscellaneousRecord _obj = new MiscellaneousRecordBLL();

        public MiscellaneousRecordsController(tt_dbContext context)
        {
            _context = context;
        }

        // GET: BuildingType/BuildingTypes
        [Route("MiscellaneousRecord/MiscellaneousRecords")]
        //public async Task<IActionResult> Index()
        //{
        //    _ = new List<MiscellaneousRecordModel>();
        //    IList<MiscellaneousRecordModel> obj = _repository.GetAll();
        //    return View(obj);
        //}
        public IActionResult Index()
        {

            _ = new List<MiscellaneousRecordModel>();
            IList<MiscellaneousRecordModel> obj = _repository.GetAll();
            return View(obj);
        }

        [Route("MiscellaneousRecord/MiscellaneousRecords/MiscellaneousReport")]
        public IActionResult MiscellaneousReport()
        {
            PopulateDropDowns();

            return View();
        }
        [HttpPost]
        [Route("MiscellaneousRecord/MiscellaneousRecords")]

        public ActionResult Index(string txtQRCode)
        {
            ViewBag.txtQRCode = txtQRCode;
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(txtQRCode, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            //System.Web.UI.WebControls.Image imgBarCode = new System.Web.UI.WebControls.Image();
            //imgBarCode.Height = 150;
            //imgBarCode.Width = 150;
            using (Bitmap bitMap = qrCode.GetGraphic(20))
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    bitMap.Save(ms, ImageFormat.Png);
                    ViewBag.imageBytes = ms.ToArray();
                    //imgBarCode.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(byteImage);
                }
            }
            return View();
        }


        [ValidateAntiForgeryToken]




        // GET: BuildingType/BuildingTypes/Details/5
        [Route("MiscellaneousRecord/MiscellaneousRecords/Details")]
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

        // GET: BuildingType/BuildingTypes/Create
        [Route("MiscellaneousRecord/MiscellaneousRecords/Create")]
        public IActionResult Create()
        {
            PopulateDropDowns();

            return View();
        }
        private void PopulateDropDowns()
        {
            ViewData["TransactionTypeId"] = _CommonRepo.SelectListMiscellaneousTransactionType();
            ViewData["TaxId"] = _CommonRepo.SelectListTaxMaster();
            //ViewData["SlabId"] = _CommonRepo.SelectListSlab();
            //ViewData["TransactionId"] = _CommonRepo.SelectListTransactionDetail();       

        }

        // POST: BuildingType/BuildingTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("MiscellaneousRecord/MiscellaneousRecords/Create")]
        public async Task<IActionResult> Create(MiscellaneousRecordModel obj)
        {
            obj.CreatedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            obj.CreatedOn = DateTime.Now;
            //bool CreateCheckDuplicate = _repository.DuplicateCheckOnSave(obj.BuildingType);
            //if (CreateCheckDuplicate)
            //{
            //    TempData["msg"] = "Duplicate data found, please find a different value";
            //    return View(obj);
            //}
            if (ModelState.IsValid)
            {
                long returnvalue = _repository.SaveMiscellaneousRecord(obj);

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

        // GET: BuildingType/BuildingTypes/Edit/5
        [Route("MiscellaneousRecord/MiscellaneousRecords/Edit")]
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
            ViewData["TransactionTypeId"] = _CommonRepo.SelectListMiscellaneousTransactionType();
            //ViewData["TaxId"] = _CommonRepo.SelectListTaxMaster();
            //ViewData["SlabId"] = _CommonRepo.SelectListSlab();

            //ViewData["TransactionId"] = _CommonRepo.SelectListTransactionDetail();


            return View(Data);
        }

        // POST: BuildingType/BuildingTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("MiscellaneousRecord/MiscellaneousRecords/Edit")]
        public async Task<IActionResult> Edit(MiscellaneousRecordModel obj)
        {
            obj.ModifiedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            obj.ModifiedOn = DateTime.Now;
            //bool CheckDuplicate = _repository.DuplicateCheckOnUpdate(obj.BuildingType, obj.BuildingTypeId);//checks duplicate user name
            //if (CheckDuplicate)
            //{
            //    TempData["msg"] = "Duplicate data found, please find a different value";
            //    return View(obj);
            //}
            var Data = await _repository.Details(obj.MiscellaneousRecordId);
            if (Data.MiscellaneousRecordId != obj.MiscellaneousRecordId)
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
                        // return RedirectToAction(nameof(Index));
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MstBuildingTypeExists(obj.MiscellaneousRecordId))
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
            return View(obj);
        }

        // GET: BuildingType/BuildingTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var TblMiscellaneousRecord = await _context.TblMiscellaneousRecord
                .FirstOrDefaultAsync(m => m.MiscellaneousRecordId == id);
            if (TblMiscellaneousRecord == null)
            {
                return NotFound();
            }

            return View(TblMiscellaneousRecord);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var TblMiscellaneousRecord = await _context.TblMiscellaneousRecord.FindAsync(id);
            _context.TblMiscellaneousRecord.Remove(TblMiscellaneousRecord);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MstBuildingTypeExists(long id)
        {
            return _context.TblMiscellaneousRecord.Any(e => e.MiscellaneousRecordId == id);
        }

        [Route("MiscellaneousRecord/MiscellaneousRecords/PopulatePV")]
        public List<MstTransactionTypeTaxMap> PopulatePV(int id)
        {
            List<MstTransactionTypeTaxMap> _dataList = null;

            return _dataList = _repository.fetchPV(id);

        }
        [HttpPost]
        [Route("MiscellaneousRecord/MiscellaneousRecords/PopulateTaxByTransactionTypeId")]
        public List<MstTaxMaster> PopulateTaxByTransactionTypeId(int id)
        {
            List<MstTaxMaster> _dataList = null;
            return _dataList = _repository.fetchPG(id);
        }
        [Route("MiscellaneousRecord/MiscellaneousRecords/PopulateSlabByTaxId")]

        public List<MstSlab> PopulateSlabByTaxId(int id)
        {
            List<MstSlab> _dataList = null;

            return _dataList = _repository.fetchLUSC(id);

        }
        [HttpPost]
        [Route("MiscellaneousRecord/MiscellaneousRecords/CreateMiscellaneousRecordModel")]
        public JsonResult CreateMiscellaneousRecordModel([FromBody] List<MiscellaneousRecordModel> json_data)
        {
            if (json_data == null)
            {
                json_data = new List<MiscellaneousRecordModel>();
            }
            long returnvalue = 0;
            MiscellaneousRecordModel obj = new MiscellaneousRecordModel();
            foreach (MiscellaneousRecordModel item in json_data)
            {
                // obj.MiscellaneousRecordId = item.MiscellaneousRecordId;
                obj.TransactionTypeId = item.TransactionTypeId;
                obj.TaxId = item.TaxId;
                obj.SlabId = item.SlabId;
                obj.Name = item.Name;
                obj.Address = item.Address;
                obj.Cid = item.Cid;
                obj.MobileNo = item.MobileNo;
                obj.Quantity = item.Quantity;
                obj.Amount = item.Amount;
                obj.CreatedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
                obj.CreatedOn = DateTime.Now;
                returnvalue = _repository.SaveMiscellaneousRecord(obj);
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
            //}
        }
        [Route("MiscellaneousRecord/MiscellaneousRecords/Getdata")]
        public List<MiscellaneousRecordModel> Getdata(string Cid, string Name, string fromdate, string todate)
        {

            List<MiscellaneousRecordModel> _dList = null;
            return _dList = _obj.fetchdataByCid(Cid, Name, fromdate, todate);
        }
        [Route("MiscellaneousRecord/MiscellaneousRecords/GetDemand")]
        public List<MiscellaneousRecordModel> GetDemand(int id)
        {

            List<MiscellaneousRecordModel> _dList = null;
            return _dList = _obj.PrintDemand(id);
        }

        [Route("MiscellaneousRecord/MiscellaneousRecords/mGetDemand")]
        public List<MiscellaneousRecordModel> mGetDemand(int id)
        {

            List<MiscellaneousRecordModel> _dList = null;
            return _dList = _obj.mPrintDemand(id);
        }
        [Route("MiscellaneousRecord/MiscellaneousRecords/GetApplicantDetails")]
        public List<MiscellaneousRecordModel> GetApplicantDetails(int id)
        {

            List<MiscellaneousRecordModel> _dList = null;
            return _dList = _obj.GetApplicantDetails(id);
        }
        [Route("MiscellaneousRecord/MiscellaneousRecords/FetchRate")]
        public List<MstRate> FetchRate(int id)
        {
            var data = (from a in _context.MstTransactionTypeTaxMap.Where(x => x.TransactionTypeId == id)
                        join b in _context.MstSlab on a.TaxId equals b.TaxId
                        join c in _context.MstRate on b.SlabId equals c.SlabId
                        select new MstRate
                        {
                            RateId = c.RateId,
                            Rate = c.Rate
                        });
            return data.ToList();
        }


        [Route("MiscellaneousRecord/MiscellaneousRecords/Report")]
        public List<MiscellaneousRecordModel> Report(int TaxId, string fromdate, string todate)
        {

            List<MiscellaneousRecordModel> _dList = null;
            return _dList = _obj.MReport(TaxId, fromdate, todate);
        }

    }
}
