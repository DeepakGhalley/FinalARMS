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
using System.Transactions;
using Microsoft.AspNetCore.Http;
using ARMS.Functions;

namespace ARMS.Areas.Property.Controllers
{
    [Area("Property")]
    public class LandDetailsController : Controller
    {
        private readonly tt_dbContext _context;
        private readonly IMapper _mapper;
        ICommonFunction _CommonRepo = new CommonFunctionBLL();
        readonly ITaxPayerProfile _obj = new TaxPayerProfileBLL();
        readonly ILandDetail _repo = new LandDetailBLL();
        readonly ILandDetail _repository = new LandDetailBLL();


        public LandDetailsController(tt_dbContext context)
        {
            _context = context;
        }

        
        [Route("Property/LandDetails")]
        public async Task<IActionResult> Index()
        {
            _ = new List<LandDetailModel>();
            IList<LandDetailModel> obj = _repository.GetAll();
            PopulateDropDowns();
            return View(obj);
        }

        [Route("Property/LandDetails/Getdata")]
        public List<LandDetailModel> Getdata(string plotno)
        {

            List<LandDetailModel> _dList = null;
            return _dList = _repository.fetchLandDetailByPlotNo(plotno);
            PopulateDropDowns();
        }
        [Route("Property/LandDetails/Getdata1")]
        public List<LandDetailModel> Getdata1(string ttin)
        {

            List<LandDetailModel> _dList = null;
            return _dList = _repository.GetData1(ttin);
            PopulateDropDowns();
        }

        [Route("Property/LandDetails/Getdata2")]
        public List<LandDetailModel> Getdata2(string cid)
        {

            List<LandDetailModel> _dList = null;
            return _dList = _repository.GetData2(cid);
            PopulateDropDowns();
        }

        [Route("Property/LandDetails/Details")]
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
            PopulateDropDowns();
            return View(data);
        }

        
        [Route("Property/LandDetails/Create")]
        public IActionResult Create()
        {
            PopulateDropDowns();
            return View();
        }

        private void PopulateDropDowns()
        {
           
            ViewData["StreetNameId"] = _CommonRepo.SelectListStreetName();
            ViewData["LandUseCategory"] = _CommonRepo.SelectListLandUseCategory();
            ViewData["DemkhongId"] = _CommonRepo.SelectListDemkhong();
            ViewData["LapId"] = _CommonRepo.SelectListLap();
            ViewData["LandTypeId"] = _CommonRepo.SelectListLandType();
            ViewData["LandOwnershipTypeId"] = _CommonRepo.SelectListLandOwnershipType();
            ViewData["LandDetailId"] = _CommonRepo.SelectListLandDetail();
            ViewData["TaxPayerId"] = _CommonRepo.SelectListTaxPayerProfile();
            ViewData["PropertyTypeId"] = _CommonRepo.SelectListPropertyType();
        }

        // POST: EnvironmentClearance/Applicantdetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Property/LandDetails/Create")]
        public async Task<IActionResult> Create(LandDetailModel obj)
        {
            obj.CreatedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            obj.CreationOn = DateTime.Now;
            bool CreateCheckDuplicate = _repository.DuplicateCheckOnSave(obj.PlotNo, obj.LandDetailId);
            if (CreateCheckDuplicate)
            {
                TempData["msg"] = "Duplicate data found, please find a different code";
                PopulateDropDowns();

                return View(obj);
            }

            if (ModelState.IsValid)
            {
                //if(obj.LandValue == 0)
                //{
                //    obj.LandValue = 0;
                //}
                //if(obj.LandPoolingRate == 0)
                //{
                //    obj.LandPoolingRate = 0;
                //}
                if (obj.StreetNameId == 0)
                {
                    obj.StreetNameId = 1;
                }
                if (obj.DemkhongId == 0)
                {
                    obj.DemkhongId = 10;
                }
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
       


        [Route("Property/LandDetails/Edit")]
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
        [Route("Property/LandDetails/Edit")]
        public async Task<IActionResult> Edit(LandDetailModel obj)
        {
            obj.ModifiedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            obj.ModifiedOn = Convert.ToDateTime(DateFunctions.getDatetypefrom(DateTime.Now.ToString("dd/MM/yyyy")));
            bool CheckDuplicate = _repository.DuplicateCheckOnUpdate(obj.LandDetailId,obj.PlotNo);//checks duplicate user name
            if (CheckDuplicate)
            {
                TempData["msg"] = "Duplicate data found, please find a different name.";
                PopulateDropDowns();

                return View(obj);
            }
            var Data = await _repository.Details(obj.LandDetailId);
            if (Data.LandDetailId != obj.LandDetailId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (obj.DemkhongId == 0)
                    {
                        obj.DemkhongId = 10;
                    }
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
                    if (!MstLandDetailExists(obj.LandDetailId))
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
            PopulateDropDowns();
            return View(obj);
        }

        
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var mstLandDetail = await _context.MstLandDetail
        //        .FirstOrDefaultAsync(m => m.LandDetailId == id);
        //    if (mstLandDetail == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(mstLandDetail);
        //}

       
        [HttpGet]
        //[ValidateAntiForgeryToken]
        [Route("Property/LandDetails/Delete")]
        public async Task<Int32> Delete(int id)
        {
            try
            {

                //using (TransactionScope s = new TransactionScope())
                //{

                    //var DataBuildingOwnershipDelete = _context.TblBuildingOwnership.Where(u => u.BuildingOwnershipId == id);
                    //DataBuildingOwnershipDelete.ForEachAsync(a => a.DeletedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId")));
                    //DataBuildingOwnershipDelete.ForEachAsync(a => a.DeletedOn = DateTime.Now);
                    //_context.SaveChanges();
                    //using (TransactionScope d = new TransactionScope()) {
                    //   // d.Dispose();
                    //    var DataBuildingOwnership = await _context.TblBuildingOwnership.FindAsync(id);
                    ////var deleteid = DataBuildingOwnership.BuildingDetailId;
                    //_context.TblBuildingOwnership.Remove(DataBuildingOwnership);
                    //await _context.SaveChangesAsync();

                    //    _context.Entry(entity).State = EntityState.Modified;
                    //    d.Complete();

                    //}

                    var DataTrnUpdate = _context.TblBuildingOwnership.Where(o => o.BuildingOwnershipId == id);
                    DataTrnUpdate.ForEachAsync(b => b.DeletedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId")));
                    DataTrnUpdate.ForEachAsync(b => b.DeletedOn = DateTime.Now);
                    //   var bdid=DataTrnUpdate.FirstOrDefault().BuildingDetailId;
                    //_context.Entry(DataTrnUpdate).State = EntityState.Modified;
                    _context.SaveChanges();

                   

                var DataBuildingOwnership = _context.TblBuildingOwnership.Find(id);
                    _context.TblBuildingOwnership.Remove(DataBuildingOwnership);
                    _context.SaveChanges();
                var DataBuildingUnit = _context.MstBuildingUnitDetail.Where(u => u.BuildingDetailId == DataTrnUpdate.FirstOrDefault().BuildingDetailId);
                DataBuildingUnit.ForEachAsync(a => a.TaxPayerId = 100024);
                //_context.Entry(DataBuildingUnit).State = EntityState.Modified;
                _context.SaveChangesAsync();


                //s.Complete();
                //s.Dispose();
                //}
                //var DataBuildingUnit = _context.MstBuildingUnitDetail.Where(u => u.BuildingDetailId == 101106);
                //DataBuildingUnit.ForEachAsync(a => a.TaxPayerId = 100024);
                //_context.SaveChanges();
                //s.Complete();
                //s.Dispose();


                //d.Dispose();


                return 1;
            }
            catch (Exception  ex) 
            {
                return 0;
            }
        }

        private bool MstLandDetailExists(int id)
        {
            return _context.MstLandDetail.Any(e => e.LandDetailId == id);
            PopulateDropDowns();
        }

        [Route("Property/LandDetails/PopulateLUSC")]
        public List<MstLandUseSubCategory> PopulateLUSC(int id)
        {
            List<MstLandUseSubCategory> _dataList = null;
            PopulateDropDowns();
            return _dataList = _repository.fetchLUSC(id);

        }
        [Route("Property/LandDetails/GetTaxPayerProfile")]
        public List<MstTaxPayerProfile> GetTaxPayerProfile(string cid, string ttin)
        {

            List<MstTaxPayerProfile> _dList = null;
            PopulateDropDowns();
            return _dList = _obj.fetchCID(cid, ttin);
        }
        
        [HttpPost]
        [Route("Property/LandDetails/CreateLandOwnershipDetail")]
        public JsonResult CreateLandOwnershipDetail([FromBody] List<LandOwnershipDetailsVM> json_data)
        {
            int returnvalue = 0;
            if (json_data == null)
            {
                json_data = new List<LandOwnershipDetailsVM>();
            }
           
            LandOwnershipDetailsVM obj = new LandOwnershipDetailsVM();
                foreach (LandOwnershipDetailsVM item in json_data)
            {
                //obj.LandOwnershipId = item.LandOwnershipId;
                obj.LandDetailId = item.LandDetailId;
                obj.TaxPayerId = item.TaxPayerId;
                obj.LandOwnershipTypeId = item.LandOwnershipTypeId;
                obj.ThramNo = item.ThramNo;
                obj.OwnershipPercentage = item.OwnershipPercentage;
                obj.PLr = item.PLr;
                //obj.ModifiedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));               
                //obj.ModifiedOn = DateTime.Now;
                obj.CreatedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
                obj.CreatedOn = DateTime.Now;
                obj.Remarks = item.Remarks;
                obj.IA = item.IA;
                obj.LandOwnershipId = item.LandOwnershipId;
                 returnvalue = _repository.SaveLandOwnershipDetail(obj);
            }
            try
            {
                // 

                if (returnvalue > 0)
                {
                    TempData["msg"] = "Land Ownership Details Saved Successfully!";

                }
                else
                {
                    TempData["msg"] = "New record creation failed";
                }
            }
            catch (DbUpdateConcurrencyException)
            {

            }
            PopulateDropDowns();
            return Json(TempData["msg"]);
            //}
        }


         
        [HttpGet]
        [Route("Property/LandDetails/GetLandOwnershipDetail")]
        public List<LandOwnershipDetailsVM> GetLandOwnershipDetail(int? id)
        {
            List<LandOwnershipDetailsVM> _dList = null;
            PopulateDropDowns();
            return _dList = _repository.GetLandOwnershipDetail(id);
        }
       
        [HttpGet]
        [Route("Property/LandDetails/GetBuildingOwnershipDetail")]
        public List<BuildingOwnershipVM> GetBuildingOwnershipDetail(int? id)
        {
            List<BuildingOwnershipVM> _dList = null;
            PopulateDropDowns();
            return _dList = _repository.GetBuildingOwnershipDetail(id);
        }
        
        [HttpGet]
        [Route("Property/LandDetails/DisplayOtherBuildingDetail")]
        public List<BuildingDetailVM> DisplayOtherBuildingDetail(int landOwnId)
        {
            List<BuildingDetailVM> _dList = null;
            PopulateDropDowns();
            return _dList = _repository.DisplayOtherBuildingDetail(landOwnId);
        }

        [HttpGet]
        [Route("Property/LandDetails/CheckDuplicateLandOwnership")]
        public List<LandOwnershipDetailsVM> CheckDuplicateLandOwnership(int LandDetailId, int TaxPayerId)
        {
            List<LandOwnershipDetailsVM> _dList = null;
            PopulateDropDowns();
            return _dList = _repository.CheckDuplicateLandOwnership(LandDetailId, TaxPayerId);
                
                
        }


        [HttpPost]
        [Route("Property/LandDetails/CreateBuildingOwnership")]
        public JsonResult CreateBuildingOwnership([FromBody] List<BuildingOwnershipVM> json_data)
        {
            if (json_data == null)
            {
                json_data = new List<BuildingOwnershipVM>();
            }

            BuildingOwnershipVM obj = new BuildingOwnershipVM();
            foreach (BuildingOwnershipVM item in json_data)
            {
                obj.LandOwnershipId = item.LandOwnershipId;
                obj.Ids = item.Ids;
                obj.CreatedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
                obj.CreatedOn = DateTime.Now;
            }
           int returnvalue= _repository.CreateBuildingOwnership(obj);
            PopulateDropDowns();
            return Json(returnvalue);
            //}
        }

        [HttpPost]
        [Route("Property/LandDetails/CreateBuildingUnit")]
        public JsonResult CreateBuildingUnit([FromBody] List<BuildingUnitDetailModel> json_data)
        {
            if (json_data == null)
            {
                json_data = new List<BuildingUnitDetailModel>();
            }

            BuildingUnitDetailModel obj = new BuildingUnitDetailModel();
            foreach (BuildingUnitDetailModel item in json_data)
            {
                obj.LandOwnershipId = item.LandOwnershipId;
                obj.BUID = item.BUID;
                //obj.TaxPayerId = item.TaxPayerId;
            }
            int returnvalue = _repository.CreateBuildingUnit(obj);
            PopulateDropDowns();
            return Json(returnvalue);
            //}
        }

        [HttpGet]
        //[ValidateAntiForgeryToken]
        [Route("Property/LandDetails/RemoveOwnership")]
        public async Task<Int32> RemoveOwnership(int LandOwnershipId)
        {

            try
            {
                var DataLandOwnershipDetail = _context.TblLandOwnershipDetail.Single(x=>x.LandOwnershipId == LandOwnershipId);
                DataLandOwnershipDetail.IsActive = false;
                DataLandOwnershipDetail.PLr = 0;
                DataLandOwnershipDetail.OwnershipPercentage = 0;
                _context.SaveChanges();
                return 1;
            }
            catch(Exception ex)
            {
                return 0;
            }
            
        }

        [HttpGet]
        [Route("Property/LandDetails/GetLandOwneshipForUpdate")] 
        public List<LandOwneshipModel> GetLandOwneshipForUpdate(int LandOwnershipId)
        {
            List<LandOwneshipModel> _dList = null;
            PopulateDropDowns();
            return _dList = _repository.GetLandOwneshipForUpdate(LandOwnershipId);
        }

        [HttpPost]
        [Route("Property/LandDetails/UpdateLandOwnership")]
        public JsonResult UpdateLandOwnership([FromBody] List<LandOwneshipModel> json_data)
        {
            if (json_data == null)
            {
                json_data = new List<LandOwneshipModel>();
            }
            int returnvalue = 0;
            LandOwneshipModel obj = new LandOwneshipModel();
            foreach (LandOwneshipModel item in json_data)
            {
                obj.LandOwnershipId = item.LandOwnershipId;
                obj.Plr = item.Plr;
                obj.ThramNo = item.ThramNo;
                obj.LandOwnershipTypeId = item.LandOwnershipTypeId;
                obj.Remarks = item.Remarks;            
                obj.ModifiedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
                obj.ModifiedOn = DateTime.Now;
                obj.IA = item.IA; 
                returnvalue = _repository.UpdateLandOwnership(obj);
            }

            return Json(returnvalue);

        }

        private bool MstLandOwnershipExists(int id)
        {
            return _context.TblLandOwnershipDetail.Any(e => e.LandOwnershipId == id);
        }

        [HttpGet]
        [Route("Property/LandDetails/ViewBuildingUnit")]
        public List<BuildingUnitDetailModel> ViewBuildingUnit(string Ids)
        {
            return _repository.ViewBuildingUnit(Ids).ToList();
        }
        
    }

}

