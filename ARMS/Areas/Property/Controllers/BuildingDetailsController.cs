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
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;

namespace ARMS.Areas.Property.Controllers
{
    [Area("Property")]
    public class BuildingDetailsController : Controller
    {
        private readonly tt_dbContext _context;
        ICommonFunction _CommonRepo = new CommonFunctionBLL();
        readonly IBuildingDetail _repository = new BuildingDetailBLL();
        readonly IBuildingDetail _obj = new BuildingDetailBLL();

        public BuildingDetailsController(tt_dbContext context)
        {
            _context = context;
        }

        // GET: Property/BuildingDetails
        [Route("Property/BuildingDetails")]
        public async Task<IActionResult> Index()
        {
            _ = new List<BuildingDetailModel>();
            IList<BuildingDetailModel> obj = _repository.GetAll();
            BuildingDropDown();
            return View(obj);
        }

        // GET: Property/BuildingDetails/Details/5
        [Route("Property/BuildingDetails/Details")]
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
            BuildingDropDown();
            return View(data);
        }

        // GET: Property/BuildingDetails/Create
        //[Route("Property/BuildingDetails/Create")]
        //public IActionResult Create()
        //{
        //    BuildingDropDown();
        //    return View();
        //}

        private void BuildingDropDown()
        {
            ViewData["ModificationReasonId"] = _CommonRepo.SelectListModificationReason();
            ViewData["BoundaryTypeId"] = _CommonRepo.SelectListBoundaryType();
            //ViewData["TransactionId"] = _CommonRepo.SelectListTransactionDetail();
            ViewData["OccupancyReferenceId"] = _CommonRepo.SelectListOccupancyType();
            ViewData["BuildingColourId"] = _CommonRepo.SelectListBuildingColour();
            ViewData["ConstructionTypeId"] = _CommonRepo.SelectListConstructionType();
            ViewData["ServiceAccessibility"] = _CommonRepo.SelectListServiceAccessibilityType();
            ViewData["LandDetailId"] = _CommonRepo.SelectListLandDetail();
            ViewData["MaterialTypeId"] = _CommonRepo.SelectListMaterialType();
            ViewData["ParkingSlotId"] = _CommonRepo.SelectListParkingSlot();
            ViewData["StructureCategoryId"] = _CommonRepo.SelectListStructureCategory();
            ViewData["StructureTypeId"] = _CommonRepo.SelectListStructureType();
            ViewData["WaterTankLocationId"] = _CommonRepo.SelectListWaterTankLocation();
            ViewData["RoofingTypeId"] = _CommonRepo.SelectListRoofingType();
            ViewData["StoreyTypeId"] = _CommonRepo.SelectListStoreyType();
            ViewData["BuildingDetailId"] = _CommonRepo.SelectListBuildingDetail();
            ViewData["BuildingUnitClassId"] = _CommonRepo.SelectListBuildingUnitClass();
            ViewData["FloorNameId"] = _CommonRepo.SelectListFloorName();
            ViewData["BuildingUnitUseTypeId"] = _CommonRepo.SelectListBuildingUnitUseType();
            ViewData["OwnerTypeId"] = _CommonRepo.SelectListUnitOwnerType();
            ViewData["Buildingclassid"] = _CommonRepo.SelectListBuildingclass();

        }

        // GET: Property/BuildingDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mstBuildingDetail = await _context.MstBuildingDetail
                .Include(m => m.LandDetail)
                .FirstOrDefaultAsync(m => m.BuildingDetailId == id);
            if (mstBuildingDetail == null)
            {
                return NotFound();
            }

            return View(mstBuildingDetail);
        }

        // POST: Property/BuildingDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mstBuildingDetail = await _context.MstBuildingDetail.FindAsync(id);
            _context.MstBuildingDetail.Remove(mstBuildingDetail);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MstBuildingDetailExists(int id)
        {
            return _context.MstBuildingDetail.Any(e => e.BuildingDetailId == id);
        }

        // GET: Property/BuildingDetails/AddMore/5
        [Route("Property/BuildingDetails/AddMore")]
        public async Task<IActionResult> AddMore(int? id)
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
            BuildingDropDown();
            return View(Data);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Property/BuildingDetails/AddMore")]
        public async Task<IActionResult> AddMore(BuildingDetailModel obj)
        {
            obj.ModifiedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            obj.ModifiedOn = Convert.ToDateTime(DateFunctions.getDatetypefrom(DateTime.Now.ToString("dd/MM/yyyy")));

            var Data = await _repository.Details(obj.BuildingDetailId);
            if (Data.BuildingDetailId != obj.BuildingDetailId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    int returnvalue = _repository.SaveAddMore(obj);
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
                    if (!MstBuildingDetailExists(obj.BuildingDetailId))
                    {
                        TempData["msg"] = "No record found.";
                        return RedirectToAction(nameof(AddMore));
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            BuildingDropDown();
            return View(obj);
        }

        [Route("Property/BuildingDetails/SearchLAndDetailsByPlotNo")]
        public List<LandDetailModel> SearchLAndDetailsByPlotNo(string plotno)
        {

            List<LandDetailModel> _dList = null;
            return _dList = _obj.SearchLAndDetailsByPlotNo(plotno);
        }

        [Route("Property/BuildingDetails/GetBuildingdata")]
        public List<BuildingDetailModel> GetBuildingdata(int LandDetailId)
        {

            List<BuildingDetailModel> _dList = null;
            return _dList = _repository.fetchBuildingDetail(LandDetailId);
        }

        [Route("Property/BuildingDetails/GetBuildingUnit")]
        public List<BuildingUnitDetailModel> GetBuildingUnit(int BuildingDetailId, int TaxPayerId)
        {

            List<BuildingUnitDetailModel> _dList = null;
            return _dList = _repository.GetBuildingUnit(BuildingDetailId, TaxPayerId);
        }

        [Route("Property/BuildingDetails/GetLandOwnershipDetails")]
        public List<LandOwneshipModel> GetLandOwnershipDetails(string plotno, string cid)
        {

            List<LandOwneshipModel> _dList = null;
            return _dList = _repository.GetLandOwnershipDetails(plotno, cid);
        }

        [HttpGet]
        //[ValidateAntiForgeryToken]
        [Route("Property/BuildingDetails/RemoveBuildingDetail")]
        public string RemoveBuildingDetail(int id, int id2, int id1)
        {

            bool CheckDuplicate = _repository.Check(id, id2);
            if (CheckDuplicate)
            {

                return ("sorry");
            }

            bool CheckBO = _repository.CheckBuildingOwnership(id);
            if(CheckBO)
            {
                return ("MultipleOwner");
            }

            bool CheckOC = _repository.CheckOccupancy(id, id2);
            if (CheckOC)
            {
                return ("OCGenerated");
            }

            else
            {
                using (tt_dbContext db = new tt_dbContext())
                {
                    if(id1 == 0)
                    {
                        MstBuildingDetail mstBuildingDetail = db.MstBuildingDetail.Find(id);
                        _context.MstBuildingDetail.Remove(mstBuildingDetail);
                        _context.SaveChanges();
                        return ("deleted");
                    }
                    else
                    {
                        TblBuildingOwnership BO = db.TblBuildingOwnership.Find(id1);
                        _context.TblBuildingOwnership.Remove(BO);
                        _context.SaveChanges();

                        MstBuildingDetail mstBuildingDetail = db.MstBuildingDetail.Find(id);
                        _context.MstBuildingDetail.Remove(mstBuildingDetail);
                        _context.SaveChanges();
                        return ("deleted");

                    }
                }
            }

        }

        //*****************************************BUILDING DETAIL ENTRY********************************************************************
        [HttpPost]
        [Route("Property/BuildingDetails/CreateBuildingDetail")]
        public JsonResult CreateBuildingDetail([FromBody] List<BuildingDetailModel> json_data)
        {
            if (json_data == null)
            {
                json_data = new List<BuildingDetailModel>();
            }
            int returnvalue = 0; // 
            BuildingDetailModel obj = new BuildingDetailModel();
            foreach (BuildingDetailModel item in json_data)
            {
                obj.LandDetailId = item.LandDetailId;
                obj.BuildingClassId = 1;
                obj.StoryTypeId = item.StoryTypeId;
                obj.BuildingNo = item.BuildingNo;
                obj.BuildupArea = item.BuildupArea;
                obj.NoOfUnits = 0; 
                obj.ConstructionTypeId = item.ConstructionTypeId;
                obj.YearOfConstruction = item.YearOfConstruction;
                obj.NumberOfFloors = item.NumberOfFloors;
                obj.Remarks = item.Remarks;
                obj.StructureTypeId = item.StructureTypeId;
                obj.GarbagServiceAccessibilityId = item.GarbagServiceAccessibilityId;
                obj.StreetLightAccessibilityId = item.StreetLightAccessibilityId;
                obj.StructureCategoryId = item.StructureCategoryId;
                obj.BoundaryTypeId = item.BoundaryTypeId;
                obj.RoofingTypeId = item.RoofingTypeId;
                obj.BuildingColourId = item.BuildingColourId;
                obj.MaterialTypeId = item.MaterialTypeId;
                obj.ParkingSlotId = item.ParkingSlotId;
                obj.WaterTankLocationId = item.WaterTankLocationId;
                obj.DateOfFinalInspection = item.DateOfFinalInspection;
                obj.WaterSupplyAccessibilityId = item.WaterSupplyAccessibilityId;
                obj.PlinthArea = item.PlinthArea;
                obj.SC = item.SC;
                obj.AT = item.AT;
                obj.WC = item.WC;
                obj.AF = item.AF;
                obj.TP = item.TP;
                obj.PT = item.PT;
                obj.ND = item.ND;
                obj.FE = item.FE;
                obj.DTSWD = item.DTSWD;
                obj.RA = item.RA;
                obj.OCI = item.OCI;
                obj.RF = item.RF;
                obj.CreatedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
                obj.CreatedOn = DateTime.Now;
                returnvalue = _repository.SaveBuildingDetail(obj);
            }

            return Json(returnvalue);

        }

        [Route("Property/BuildingDetails/GetTaxPayerDetails")]
        public List<TaxPayerProfileModel> GetTaxPayerDetails(string TTIN, string CID)
        {

            List<TaxPayerProfileModel> _dList = null;
            return _dList = _repository.GetTaxPayerDetails(TTIN, CID);
        }

        //*******************************************BUILDING UNIT DETAIL ENTRY*****************************************************************
        [HttpPost]
        [Route("Property/BuildingDetails/CreateBuildingUnitDetail")]
        public JsonResult CreateBuildingUnitDetail([FromBody] List<BuildingUnitDetailModel> json_data)
        {
                if (json_data == null)
                {
                    json_data = new List<BuildingUnitDetailModel>();
                }
                int returnvalue = 0; // 
                BuildingUnitDetailModel obj = new BuildingUnitDetailModel();
                foreach (BuildingUnitDetailModel item in json_data)
                {
                    obj.LandDetailId = item.LandDetailId;
                    obj.BuildingDetailId = item.BuildingDetailId;
                    obj.BuildingUnitClassId = item.BuildingUnitClassId;
                    obj.FloorNameId = item.FloorNameId;
                    obj.BuildingUnitUseTypeId = item.BuildingUnitUseTypeId;
                    obj.IsR = item.IsR;
                    obj.FloorNo = item.FloorNo;
                    obj.FlatNo = item.FlatNo;
                    obj.NoOfUnit = item.NoOfUnit;
                    obj.FloorArea = item.FloorArea;
                    obj.NoOfrooms = item.NoOfrooms;
                    obj.TaxPayerId = item.TaxPayerId;
                    obj.UnitOwnerTypeId = item.UnitOwnerTypeId;
                    obj.IsMOwner = item.IsMOwner;
                    obj.Remarks = item.Remarks;
                    obj.CreatedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
                    obj.CreatedOn = DateTime.Now;
                    returnvalue = _repository.SaveBuildingUnitDetail(obj);
                
            }

                return Json(returnvalue);
            
    }

        [HttpGet]
        //[ValidateAntiForgeryToken]
        [Route("Property/BuildingDetails/RemoveBuildingUnitDetail")]
        public string RemoveBuildingUnitDetail(int id)
        {

                using (tt_dbContext db = new tt_dbContext())
                {
                    MstBuildingUnitDetail mstBuildingUnitDetail = db.MstBuildingUnitDetail.Find(id);
                    _context.MstBuildingUnitDetail.Remove(mstBuildingUnitDetail);
                    _context.SaveChanges();
                    return ("Deleted");
                }
            }

        
        // Here
        [Route("Property/BuildingDetails/UnitDetails")]
        public async Task<IActionResult> UnitDetails(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var data = await _obj.UnitDetails(id);

            if (data == null)
            {
                return NotFound();
            }
            BuildingDropDown();
            return View(data);
        }

        [Route("Property/BuildingDetails/EditBuildingUnit")]
        public async Task<IActionResult> EditBuildingUnit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Data = await _obj.UnitDetails(id);
            if (Data == null)
            {
                return NotFound();
            }
            BuildingDropDown();
            return View(Data);
        }
       
        [Route("Property/BuildingDetails/GetBuildingForUpdate")]
        public List<BuildingDetailModel> GetBuildingForUpdate(int BuildingDetailId)
        {
            BuildingDropDown();
            return _repository.GetBuildingForUpdate(BuildingDetailId).ToList();

        }

        [HttpPost]
        [Route("Property/BuildingDetails/UpdateBuildingDetail")]
        public JsonResult UpdateBuildingDetail([FromBody] List<BuildingDetailModel> json_data)
        {
            if (json_data == null)
            {
                json_data = new List<BuildingDetailModel>();
            }
            int returnvalue = 0; 
            BuildingDetailModel obj = new BuildingDetailModel();
            foreach (BuildingDetailModel item in json_data)
            {
                obj.BuildingDetailId = item.BuildingDetailId;
                obj.StoryTypeId = item.StoryTypeId;
                obj.StructureTypeId = item.StructureTypeId;
                obj.ConstructionTypeId = item.ConstructionTypeId;
                obj.GarbagServiceAccessibilityId = item.GarbagServiceAccessibilityId;
                obj.StreetLightAccessibilityId = item.StreetLightAccessibilityId;
                obj.StructureCategoryId = item.StructureCategoryId;
                obj.BoundaryTypeId = item.BoundaryTypeId;
                obj.RoofingTypeId = item.RoofingTypeId;
                obj.BuildingColourId = item.BuildingColourId;
                obj.MaterialTypeId = item.MaterialTypeId;
                obj.ParkingSlotId = item.ParkingSlotId;
                obj.WaterTankLocationId = item.WaterTankLocationId;
                obj.WaterSupplyAccessibilityId = item.WaterSupplyAccessibilityId;
                obj.LandDetailId = item.LandDetailId;
                obj.YearOfConstruction = item.YearOfConstruction;
                obj.BuildingNo = item.BuildingNo;
                obj.BuildupArea = item.BuildupArea;
                obj.NoOfUnits = item.NoOfUnits;
                obj.NumberOfFloors = item.NumberOfFloors;
                obj.DateOfFinalInspection = item.DateOfFinalInspection;
                obj.Remarks = item.Remarks;
                obj.BuildingClassId = item.BuildingClassId;
                obj.PlinthArea = item.PlinthArea;
                obj.SC = item.SC;
                obj.AT = item.AT;
                obj.WC = item.WC;
                obj.AF = item.AF;
                obj.TP = item.TP;
                obj.PT = item.PT;
                obj.ND = item.ND;
                obj.FE = item.FE;
                obj.DTSWD = item.DTSWD;
                obj.RA = item.RA;
                obj.RF = item.RF;
                obj.OCI = item.OCI;
                
                obj.ModifiedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
                obj.ModifiedOn = DateTime.Now;
                returnvalue = _repository.UpdateBuildingDetail(obj);
            }

            return Json(returnvalue);

        }

        [Route("Property/BuildingDetails/GetBuildingUnitForUpdate")]
        public List<BuildingUnitDetailModel> GetBuildingUnitForUpdate(int BuildingUnitDetailId)
        {
            BuildingDropDown();
            return _repository.GetBuildingUnitForUpdate(BuildingUnitDetailId).ToList();

        }
       
        [HttpPost]
        [Route("Property/BuildingDetails/UpdateBuildingUnitDetail")]
        public async Task<JsonResult> UpdateBuildingUnitDetailAsync([FromBody] List<BuildingUnitDetailModel> json_data)
        {
            if (json_data == null)
            {
                json_data = new List<BuildingUnitDetailModel>();
            }
            int returnvalue = 0;
            BuildingUnitDetailModel obj = new BuildingUnitDetailModel();
            foreach (BuildingUnitDetailModel item in json_data)
            {
                obj.BuildingDetailId = item.BuildingDetailId;
                obj.BuildingUnitDetailId = item.BuildingUnitDetailId;
                obj.LandDetailId = item.LandDetailId;
                obj.TaxPayerId = item.TaxPayerId;
                obj.BuildingUnitUseTypeId = item.BuildingUnitUseTypeId;
                obj.IsR = item.IsR;
                obj.BuildingUnitClassId = item.BuildingUnitClassId;
                obj.FloorNameId = item.FloorNameId;
                obj.UnitOwnerTypeId = item.UnitOwnerTypeId;
                obj.IsMOwner = item.IsMOwner;
                obj.NoOfUnit = item.NoOfUnit;
                obj.FloorArea = item.FloorArea;
                obj.FloorNo = item.FloorNo;
                obj.FlatNo = item.FlatNo;
                obj.LandDetailId = item.LandDetailId;
                obj.NoOfrooms = item.NoOfrooms;
                obj.Remarks = item.Remarks;
                obj.ModifiedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
                obj.ModifiedOn = DateTime.Now;
                returnvalue = _repository.UpdateBuildingUnitDetail(obj);
            }

            // Define the URL of the API endpoint
            string apiUrl = "http://172.30.3.57:8118/updateBuildingUnits";

            // Create an instance of HttpClient
            using (var httpClient = new HttpClient())
            {
                // Create an object to send as a parameter
                var data = new
                {
                    buildingUnitDetailId= 12346,
   buildingDetailId= 67890,
   buildingUnitClassId= 1,
   floorNameId= 2,
   buildingUnitUseTypeId= 3,
   isRegularized= 1,
   floorNo= 1,
   flatNo= "101",
   noOfUnit= 1,
   floorArea= 100.5,
   noOfrooms= 3,
   taxPayerId= 54321,
   landDetailId= 98765,
   unitOwnerTypeId= 4,
   isMainOwner= 1,
   createdBy= "KrishnaPowdyelnew",
   createdOn= "2023-08-18",
   modifiedBy= "JaneSmith",
   modifiedOn= "2023-08-18",
   transferStatusId= 5,
   isActive= true,
   createG2cApplicationNo= "APP-333",
   UpdateG2cApplicationNo= "APP-333",
   hasIssue= true,
   remarks= "done"
                };

                // Serialize the object to JSON
                string jsonData = JsonConvert.SerializeObject(data);

                // Create a StringContent object with the JSON data
                var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

                // Send the POST request
                var response = await httpClient.PostAsync(apiUrl, content);

                if (response.IsSuccessStatusCode)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("POST request was successful!");
                    Console.WriteLine(responseContent); // If the response is in JSON format
                }
                else
                {
                    Console.WriteLine($"POST request failed with status code {response.StatusCode}");
                    string errorContent = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(errorContent); // Print the response content for error debugging
                }
            }


            return Json(returnvalue);

        }



        [Route("Property/BuildingDetails/GetBDetail")]
        public List<BuildingDetailModel> GetBDetail(int BuildingDetailId)
        {

            List<BuildingDetailModel> _dList = null;
            return _dList = _repository.GetBDetail(BuildingDetailId);
        }

        [Route("Property/BuildingDetails/GetTaxPayerName")]
        public List<LandOwneshipModel> GetTaxPayerName(int TaxPayerId, int LandOwnershipId)
        {

            List<LandOwneshipModel> _dList = null;
            return _dList = _repository.GetTaxPayerName(TaxPayerId, LandOwnershipId);
        }
    }
}
