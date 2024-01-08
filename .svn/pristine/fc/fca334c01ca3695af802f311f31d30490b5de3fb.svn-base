using ARMS.Functions;
using ARMS.Models;
using AspNetCore.Reporting;
using CORE_BLL;
using CORE_BOL;
using CORE_BOL.Entities;
using CORE_DLL;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
//using Microsoft.Reporting;
//using Microsoft.Reporting.NETCore;
//using Microsoft.Reporting.NETCore;
using System;
using System.Collections.Generic;
using Microsoft.Data;
using Microsoft.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AutoMapper;

namespace ARMS.Areas.Property.Controllers
{
    [Area("Property")]
    public class GenerateOccupancyController : Controller
    {
        private readonly tt_dbContext _context;
        private readonly IMapper _mapper;
        ICommonFunction _CommonRepo = new CommonFunctionBLL();
        private readonly IWebHostEnvironment _IWebHostEnvironment;
        readonly tt_dbContext _ctx = new tt_dbContext();
        readonly IGenerateOccupancy _repository = new GenerateOccupancyBLL();
        private readonly ILogger<GenerateOccupancyController> _logger;

        //public GenerateOccupancyController(ILogger<GenerateOccupancyController> logger, IWebHostEnvironment webHostEnvironment)
        //{
        //    _logger = logger;
        //    _IWebHostEnvironment = webHostEnvironment;
        //}
        private void PopulateDropDown()
        {
            ViewData["OccupancyType"] = _CommonRepo.SelectListOccupancyType();

        }


        [Route("Property/GenerateOccupancy/Index")]
        public async Task<IActionResult> Index()
        {
            PopulateDropDown();
            return View();
        }
        [Route("Property/GenerateOccupancy/FetchLandOwnershipDetails")]
        public List<OccupancyCertificate> FetchLandOwnershipDetails(string Ttin, string Cid)
        {

            List<OccupancyCertificate> _dList = null;
            return _dList = _repository.FetchLandOwnershipDetails(Ttin, Cid);
            PopulateDropDown();
        }


        [Route("Property/GenerateOccupancy/FetchBuildingDetails")]
        public List<BuildingDetailModel> FetchBuildingDetails(int LandDetailId, int TaxpayerId)
        {

            List<BuildingDetailModel> _dList = null;
            return _dList = _repository.FetchBuildingDetails(LandDetailId,TaxpayerId);
            PopulateDropDown();
        }

        [Route("Property/GenerateOccupancy/FetchBuildingUnitDetails")]
        public List<BuildingUnitDetailModel> FetchBuildingUnitDetails(int BuildingDetailId,int TaxpayerId)
        {

            List<BuildingUnitDetailModel> _dList = null;
            return _dList = _repository.FetchBuildingUnitDetails(BuildingDetailId, TaxpayerId);
            PopulateDropDown();
        }

        [Route("Property/GenerateOccupancy/GetBDDetails")]
        public List<OccupancyCertificate> GetBDDetails(int BuildingDetailId)
        {

            List<OccupancyCertificate> _dList = null;
            return _dList = _repository.GetBDDetails(BuildingDetailId);
            PopulateDropDown();
        }

        [Route("Property/GenerateOccupancy/GetBUDDetails")]
        public List<OccupancyCertificate> GetBUDDetails(int BuildingUnitDetailId)
        {

            List<OccupancyCertificate> _dList = null;
            return _dList = _repository.GetBUDDetails(BuildingUnitDetailId);
            PopulateDropDown();
        }

        [HttpPost]
        [Route("Property/GenerateOccupancy/CreateBuildingOC")]
        public JsonResult CreateBuildingOC([FromBody] List<OccupancyCertificate> json_data)
        {
            if (json_data == null)
            {
                json_data = new List<OccupancyCertificate>();
            }
            int returnvalue = 0; // 
            OccupancyCertificate obj = new OccupancyCertificate();
            foreach (OccupancyCertificate item in json_data)
            {
                obj.OccupancyTypeId = item.OccupancyTypeId;
                obj.LandOwnershipId = item.LandOwnershipId;
                obj.LandDetailId = item.LandDetailId;
                obj.BuildingDetailId = item.BuildingDetailId;
                obj.TaxPayerId = item.TaxPayerId;
                obj.DateOfFinalInspection = item.DateOfFinalInspection;
                obj.LogoSignMapId = 1;
                obj.IsBuildingOc = true;
                obj.IssueDate = DateTime.Now;
                obj.ValidTillDate = DateTime.Now.AddYears(1);
                obj.IsNewOC = item.IsNewOC;
                obj.CreatedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
                obj.CreatedOn = DateTime.Now;
                returnvalue = _repository.SaveBuildingOC(obj);
            }
            PopulateDropDown();
            return Json(returnvalue);

        }

        [HttpPost]
        [Route("Property/GenerateOccupancy/CreateBuildingUnitOC")]
        public JsonResult CreateBuildingUnitOC([FromBody] List<OccupancyCertificate> json_data)
        {

            if (json_data == null)
            {
                json_data = new List<OccupancyCertificate>();
            }
            int returnvalue = 0; // 
            OccupancyCertificate obj = new OccupancyCertificate();
            foreach (OccupancyCertificate item in json_data)
            {
                obj.OccupancyTypeId = item.OccupancyTypeId;
                obj.LandOwnershipId = item.LandOwnershipId;
                obj.LandDetailId = item.LandDetailId;
                obj.BuildingDetailId = item.BuildingDetailId;
                obj.BuildingUnit = item.BuildingUnit;
                obj.TaxPayerId = item.TaxPayerId;
                obj.DateOfFinalInspection = item.DateOfFinalInspection;
                obj.LogoSignMapId = 1;
                obj.IsBuildingOc = false;
                obj.IssueDate = DateTime.Now;
                obj.ValidTillDate = DateTime.Now.AddYears(1);
                obj.IsNewOC = item.IsNewOC;
                obj.CreatedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
                obj.CreatedOn = DateTime.Now;
                returnvalue = _repository.SaveBuildingUnitOC(obj);
                }
                PopulateDropDown();
            return Json(returnvalue);

        }

        [Route("Property/GenerateOccupancy/CheckDuplicate")]
        public List<OccupancyCertificate> CheckDuplicate(int BDId, int BTId)
        {

            List<OccupancyCertificate> _dList = null;
            return _dList = _repository.CheckDuplicate(BDId, BTId);
            PopulateDropDown();
        }
        [Route("Property/GenerateOccupancy/CheckDuplicateU")]
        public List<OccupancyCertificate> CheckDuplicateU(int BUId, int UTId)
        {

            List<OccupancyCertificate> _dList = null;
            return _dList = _repository.CheckDuplicateU( BUId, UTId);
            PopulateDropDown();
        }
    }
}

