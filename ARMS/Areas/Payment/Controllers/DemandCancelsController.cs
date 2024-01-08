using System;
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

namespace ARMS.Areas.Payment.Controllers
{
    [Area("Payment")]
    [Authorize]
    public class DemandCancelsController : Controller
    {
        private readonly tt_dbContext _context;
        readonly IDemandCancel _repository = new DemandCancelBLL();
        ICommonFunction _CommonRepo = new CommonFunctionBLL();
        public DemandCancelsController(tt_dbContext context)
        {
            _context = context;
        }
        [Authorize]
        [Route("Payment/DemandCancels/DemandCancel")]
        public async Task<IActionResult> DemandCancel()
        {
           return View();
           
        }

        [Authorize]
        [Route("Payment/DemandCancels/GetDemandWithSearch")]
        public List<DemandCancelVM> GetDemandWithSearch(string DemandNo)
        {
            List<DemandCancelVM> _dList = null;

            return _dList = _repository.GetDemandWithSearch(DemandNo);
        }

        [Authorize]
        [Route("Payment/DemandCancels/GetDemandDetails")]
        public List<DemandCancelVM> GetDemandDetails(int? id)
        {
            List<DemandCancelVM> _dList = null;

            return _dList = _repository.GetDemandDetails(id);
        }

        [Authorize]
        [HttpPost]
        [Route("Payment/DemandCancels/SaveDemandCancel")]
        public JsonResult SaveDemandCancel([FromBody] List<DemandCancelVM> json_data)
        {
            if (json_data == null)
            {
                json_data = new List<DemandCancelVM>();
            }
            int returnvalue = 0; // 
            DemandCancelVM obj = new DemandCancelVM();
            foreach (DemandCancelVM item in json_data)
            {
                obj.DemandNoId = item.DemandNoId;
                obj.TotalCancelAmount = item.TotalCancelAmount;
                obj.Remarks = item.Remarks;               
                obj.CreatedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
                obj.CreatedOn = DateTime.Now;
                obj.DemandId = item.DemandId;
                //obj.DemandAmount = item.DemandAmount;
                returnvalue = _repository.SaveDemandCancel(obj);
            }

            return Json(returnvalue);

        }



    }
}
