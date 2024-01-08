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

namespace ARMS.Areas.AssetRegister.Controllers
{
    [Area("AssetRegister")]
    public class AssetsController : Controller
    {
        private readonly tt_dbContext _context;
        private readonly IMapper _mapper;
        ICommonFunction _CommonRepo = new CommonFunctionBLL();
        readonly IAssetRegister _repository = new AssetRegisterBLL();

        //private int _createdBy;
        //private DateTime _createdOn = DateTime.Now;

        public AssetsController(tt_dbContext context)
        {
            _context = context;
        }

        // GET: AssetRegister/Assets
        [Route("AssetRegister/Assets")]
        public async Task<IActionResult> Index()
        {
            AssetDropDown();
          
            
            return View();
        }

        // GET: AssetRegister/Assets/Details/5
        [Route("AssetRegister/Assets/Details")]
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

        // GET: AssetRegister/Assets/Create
        [Route("AssetRegister/Assets/Create")]
        public IActionResult Create()
        {
            AssetDropDown();
            return View();
        }
        private void AssetDropDown()
        {
            ViewData["AssetFunctionId"] = _CommonRepo.SelectListAssetFunction();
            ViewData["AssetStatusId"] = _CommonRepo.SelectListAssetStatus();
            //ViewData["SectionId"] = _CommonRepo.SelectListSection();
            ViewData["SupplierId"] = _CommonRepo.SelectListSupplier();
            ViewData["TertiaryAccountHeadId"] = _CommonRepo.SelectListTertiaryHead();
            ViewData["LapId"] = _CommonRepo.SelectListLap();
            ViewData["DemkhongId"] = _CommonRepo.SelectListDemkhong();
            ViewData["DivisionId"] = _CommonRepo.SelectListDivision();
            ViewData["PrimaryAccountHeadId"] = _CommonRepo.SelectListPrimaryHead();
            ViewData["AreaId"] = _CommonRepo.SelectListArea();
            ViewData["User"] = _CommonRepo.SelectListUser();
            ViewData["Zone"] = _CommonRepo.SelectListZone();
        }

        // POST: AssetRegister/Assets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("AssetRegister/Assets/Create")]
        public async Task<IActionResult> Create(AssetRegisterVM obj)
        {
            obj.CreatedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            obj.CreatedOn = Convert.ToDateTime(DateFunctions.getDatetypefrom(DateTime.Now.ToString("dd/MM/yyyy")));
            bool CreateCheckDuplicate = _repository.DuplicateCheckOnSave(obj.AssetCode);
            if (CreateCheckDuplicate)
            {
                TempData["msg"] = "Duplicate data found, please find a different code";
                AssetDropDown();
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
                    TempData["msg"] = "New record creation failed";
                    return RedirectToAction(nameof(Create));
                }
            }
            AssetDropDown();
            return View(obj);
        }

        // GET: AssetRegister/Assets/Edit/5
        [Route("AssetRegister/Assets/Edit")]
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
            AssetDropDown();
            return View(Data);
        }

        // POST: AssetRegister/Assets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("AssetRegister/Assets/Edit")]
        public async Task<IActionResult> Edit(AssetRegisterVM obj)
        {
            obj.ModifiedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            obj.ModifiedOn = Convert.ToDateTime(DateFunctions.getDatetypefrom(DateTime.Now.ToString("dd/MM/yyyy")));
            bool CheckDuplicate = _repository.DuplicateCheckOnUpdate(obj.AssetCode, obj.TertiaryAccountHeadId, obj.SectionId, obj.AssetStatusId, obj.AssetFunctionId, obj.AssetId);
            if (CheckDuplicate)
            {
                TempData["msg"] = "Duplicate data found, please find a different name.";
                AssetDropDown();
                return View(obj);
            }
            var Data = await _repository.Details(obj.AssetId);

            if (Data.AssetId != obj.AssetId)
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
                    if (!MstAssetExists(obj.AssetId))
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
            AssetDropDown();
            return View(obj);
        }

        // GET: AssetRegister/Assets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mstAsset = await _context.MstAsset
                .Include(m => m.AssetFunction)
                .Include(m => m.AssetStatus)
                .Include(m => m.Section)
                .Include(m => m.Supplier)
                .Include(m => m.TertiaryAccountHead)
                .FirstOrDefaultAsync(m => m.AssetId == id);
            if (mstAsset == null)
            {
                return NotFound();
            }

            return View(mstAsset);
        }

        // POST: AssetRegister/Assets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mstAsset = await _context.MstAsset.FindAsync(id);
            _context.MstAsset.Remove(mstAsset);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MstAssetExists(int id)
        {
            return _context.MstAsset.Any(e => e.AssetId == id);
        }

        [Route("AssetRegister/Assets/PopulateSEC")]
        [HttpPost]
        public List<MstSection> PopulateSEC(int id)
        {
            List<MstSection> _dataList = null;

            return _dataList = _repository.fetchSEC(id);

        }

        [Route("AssetRegister/Assets/PopulateSED")]
        [HttpPost]
        public List<MstSecondaryAccountHead> PopulateSED(int id)
        {
            List<MstSecondaryAccountHead> _dataList = null;

            return _dataList = _repository.fetchSED(id);

        }

        [Route("AssetRegister/Assets/PopulateTER")]
        [HttpPost]
        public List<MstTertiaryAccountHead> PopulateTER(int id)
        {
            List<MstTertiaryAccountHead> _dataList = null;

            return _dataList = _repository.fetchTER(id);

        }

        [HttpPost]
        [Route("AssetRegister/Assets/CreateFinancial")]
        public JsonResult CreateFinancial([FromBody] List<FinancialInformationVM> json_data)
        {
            //using (tt_dbContext entities = new tt_dbContext())
            //{
            //Check for NULL.  
            if (json_data == null)
            {
                json_data = new List<FinancialInformationVM>();
            }

            FinancialInformationVM obj = new FinancialInformationVM();
            //Loop and insert records. 
            foreach (FinancialInformationVM item in json_data)
            {
                obj.AssetId = item.AssetId;
                obj.ProcurementOrderRefNo = item.ProcurementOrderRefNo;
                obj.ProcurementOrderDate = item.ProcurementOrderDate;
                obj.DateofProcurement = item.DateofProcurement;
                obj.DateofCommissioning = item.DateofCommissioning;
                obj.UsefulLife = item.UsefulLife;
                obj.CostofProcurement = item.CostofProcurement;
                obj.CreatedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
                obj.CreatedOn = DateTime.Now;
                _repository.SaveFinancial(obj);
            }
            try
            {
                int returnvalue = 1; // 

                if (returnvalue > 0)
                {
                    TempData["msg"] = "Financial Details Saved Successfully!";

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

        [Route("AssetRegister/Assets/CheckDuplicateInformation")]
        public List<TechicalInformationVM> CheckDuplicateInformation(int id)
        {
            List<TechicalInformationVM> _dList = null;

            return _dList = _repository.CheckDuplicateInformation(id);
        }

        [Route("AssetRegister/Assets/CheckDuplicateFinancial")]
        public List<FinancialInformationVM> CheckDuplicateFinancial(int id)
        {
            List<FinancialInformationVM> _dList = null;

            return _dList = _repository.CheckDuplicateFinancial(id);
        }


        [Route("AssetRegister/Assets/CreateTechnicalInformation")]
        public JsonResult CreateTechnicalInformation([FromBody] List<TechicalInformationVM> json_data)
        {
            //using (tt_dbContext entities = new tt_dbContext())
            //{
            //Check for NULL.  
            if (json_data == null)
            {
                json_data = new List<TechicalInformationVM>();
            }
            int returnvalue = 0;
            TechicalInformationVM obj = new TechicalInformationVM();
            //Loop and insert records. 
            foreach (TechicalInformationVM item in json_data)
            {
                obj.AssetId = item.AssetId;
                obj.AssetAttributeId = item.AssetAttributeId;
                obj.MeasurementUnitId = item.MeasurementUnitId;
                obj.Value = item.Value;
                obj.CreatedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
                obj.CreatedOn = Convert.ToDateTime(DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"));
                returnvalue = _repository.SaveTechnical(obj);
            }
            

            return Json(returnvalue);
            
        }
        /*[HttpGet]
        // GET: AssetRegister/Assets
        [Route("AssetRegister/Assets/GetTechnical")]
        public async Task<IActionResult> GetTechnical(int? id)
        {
            _ = new List<AssetRegisterVM>();
            IList<AssetRegisterVM> obj1 =  _repository.GetTechnical(id);
            return Json(obj1);
        }*/



        [Route("AssetRegister/Assets/GetTechnical")]
        public List<AssetRegisterVM> GetTechnical(int? id)
        {
            List<AssetRegisterVM> _dList = null;
            
            return _dList = _repository.GetTechnical(id);
        }


        [Route("AssetRegister/Assets/GetMeasurementUnit")]
        public List<CommonFunctionModel> GetMeasurementUnit(int AssetAttributeId)
        {
           
                List<CommonFunctionModel> _dList = null;

                return _dList = _CommonRepo.SelectListAttributeUnitMap(AssetAttributeId);
            
        }

        [Route("AssetRegister/Assets/GetFinancialDetail")]
        public List<FinancialDetailVM> GetFinancialDetail(int? id)
        {
            List<FinancialDetailVM> _dList = null;

            return _dList = _repository.GetFinancialDetail(id);
        }

        [Route("AssetRegister/Assets/GetTechnicalDetail")]
        public List<TechicalInformationVM> GetTechnicalDetail(int? id)
        {
            List<TechicalInformationVM> _dList = null;

            return _dList = _repository.GetTechnicalDetail(id);
        }

        [HttpPost]
        [Route("AssetRegister/Assets/UpdateFinancial")]
        public JsonResult UpdateFinancial([FromBody] List<FinancialInformationVM> json_data)
        {
            //using (tt_dbContext entities = new tt_dbContext())
            //{
            //Check for NULL.  
            if (json_data == null)
            {
                json_data = new List<FinancialInformationVM>();
            }

            FinancialInformationVM obj = new FinancialInformationVM();
            //Loop and insert records. 
            foreach (FinancialInformationVM item in json_data)
            {
                obj.AssetId = item.AssetId;
                obj.ProcurementOrderRefNo = item.ProcurementOrderRefNo;
                obj.ProcurementOrderDate = item.ProcurementOrderDate;
                obj.DateofProcurement = item.DateofProcurement;
                obj.DateofCommissioning = item.DateofCommissioning;
                obj.UsefulLife = item.UsefulLife;
                obj.CostofProcurement = item.CostofProcurement;
                obj.ModifiedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
                obj.ModifiedOn = Convert.ToDateTime(DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"));
                _repository.UpdateFinancial(obj);
            }
            try
            {
                int returnvalue = 1; // 

                if (returnvalue > 0)
                {
                    TempData["msg"] = "Financial Details Saved Successfully!";

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

        [Route("AssetRegister/Assets/GetAssetsNumber")]
        public List<AssetRegisterVM> GetAssetsNumber(int AssetId)
        {
            List<AssetRegisterVM> _dList = null;

            return _dList = _repository.GetAssetsNumber(AssetId);
        }


        //[Route("AssetRegister/Assets/FetchZone")]

        //public List<MstZone> FetchZone(int zid)
        //{
        //    List<MstZone> _dataList = null;

        //    return _dataList = FetchZone(zid);

        //}
        //[Route("AssetRegister/Assets/FetchArea")]

        //public List<MstArea> FetchArea(int aid)
        //{
        //    List<MstArea> _dataList = null;

        //    return _dataList = FetchArea(aid);

        //}

       
        [Route("AssetRegister/Assets/Fetchuser")]
        public List<UsersModel> Fetchuser(int uid)
        {
            List<UsersModel> _dList = null;

            return _dList = _repository.Fetchuser(uid);
        }

        [Route("AssetRegister/Assets/FetchAssetRegiser")]
        public IEnumerable<AssetManagementVM> FetchAssetRegiser(int PrimaryHeadId)
        {

            IEnumerable<AssetManagementVM> _dList = null;
            return _dList = _repository.FetchAssetRegiser(PrimaryHeadId);
        }

        [Route("AssetRegister/Assets/GetAsset")]
        public IList<AssetRegisterVM> GetAsset(int SecondaryAccountHeadId)
        {
            IList<AssetRegisterVM> _dList = null;

            return _dList = _repository.GetAll(SecondaryAccountHeadId);
        }
    }

}
