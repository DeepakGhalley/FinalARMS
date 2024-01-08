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

namespace ARMS.Areas.Property.Controllers
{
    [Area("Property")]
    public class BettermentChargesController : Controller
    {
        private readonly tt_dbContext _context;
        readonly IBettermentCharges _repository = new BettermentChargesBLL();
        readonly IBettermentCharges _obj = new BettermentChargesBLL();

        public BettermentChargesController(tt_dbContext context)
        {
            _context = context;
        }

        [Route("Property/BettermentCharges/Index")]
        public IActionResult Index()
        {
            return View();
        }
        [Route("Property/BettermentCharges/GetTaxPayerDetails")]
        public List<LandDetailModel> GetTaxPayerDetails(string cid, string ttin, string plotno, string thramno)
        {
            List<LandDetailModel> _dList = null;
            return _dList = _repository.GetTaxPayerDetails(cid, ttin, plotno, thramno);
        }

        [Route("Property/BettermentCharges/GetLandDetails")]
        public List<LandDetailModel> GetLandDetails(int? id)
        {
            List<LandDetailModel> _dList = null;
            return _dList = _repository.GetLandDetails(id);
        }

        [Route("Property/BettermentCharges/GetBuildingDetails")]
        public List<LandDetailModel> GetBuildingDetails(int? id)
        {
            List<LandDetailModel> _dList = null;
            return _dList = _repository.GetBuildingDetails(id);
        }

        [Route("Property/BettermentCharges/GetBuildingUnitDetails")]
        public List<LandDetailModel> GetBuildingUnitDetails(int? id)
        {
            List<LandDetailModel> _dList = null;
            return _dList = _repository.GetBuildingUnitDetails(id);
        }

        [HttpPost]
        [Route("Property/BettermentCharges/SaveLandPoolingRate")]
        public JsonResult SaveLandPoolingRate([FromBody] List<trnLandDetailVM> json_data)
        {
            if (json_data == null)
            {
                json_data = new List<trnLandDetailVM>();
            }

            trnLandDetailVM obj = new trnLandDetailVM();
            foreach (trnLandDetailVM item in json_data)
            {
                obj.TrnLandDetailId = item.TrnLandDetailId;             
                obj.LandPoolingRate = item.LandPoolingRate;              
                _repository.SaveLandPoolingRate(obj);
            }
            try
            {
                int returnvalue = 1; // 

                if (returnvalue > 0)
                {
                    TempData["msg"] = "Record Saved Successfully!";

                }
                else
                {
                    TempData["msg"] = "Saving failed";
                }
            }
            catch (DbUpdateConcurrencyException)
            {

            }

            return Json(TempData["msg"]);

        }
    }
}
