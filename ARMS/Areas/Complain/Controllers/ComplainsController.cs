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

namespace ARMS.Areas.Complain.Controllers
{
    [Area("Complain")]
    public class ComplainsController : Controller
    {
        private readonly tt_dbContext _context;
        ICommonFunction _CommonRepo = new CommonFunctionBLL();
        readonly IComplainDetail _repository = new ComplainDetailBLL();

        public ComplainsController(tt_dbContext context)
        {
            _context = context;
        }
        [Route("Complain/Index")]
        public async Task<IActionResult> Index()
        {
            ViewData["ComplainType"] = _CommonRepo.SelectListComplainType();
            return View();
            
        }
        [Route("Complain/GetWaterConnection")]
        public List<WaterConnectionModel> GetWaterConnection(string ConsumerNo)
        {
            ViewData["ComplainType"] = _CommonRepo.SelectListComplainType();
            List<WaterConnectionModel> _dList = null;
            return _dList = _repository.GetWaterConnection(ConsumerNo);
        }

        [HttpPost]
        [Route("Complain/ComplainDetail/CreateComplainDetail")]
        public JsonResult CreateComplainDetail([FromBody] List<ComplainDetail> json_data)
        {
            if (json_data == null)
            {
                json_data = new List<ComplainDetail>();
            }
            int returnvalue = 0; // 
            ComplainDetail obj = new ComplainDetail();
            foreach (ComplainDetail item in json_data)
            {
                obj.WaterConnectionId = item.WaterConnectionId;
                obj.ComplainTypeId = item.ComplainTypeId;
                obj.ComplainStatusId = 1;
                obj.Instruction = item.Instruction;
                obj.DeadLine = item.DeadLine;
                obj.CreatedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
                obj.CreatedOn = DateTime.Now;
                returnvalue = _repository.SaveComplainDetail(obj);
            }
            ViewData["ComplainType"] = _CommonRepo.SelectListComplainType();
            return Json(returnvalue);

        }
        [Route("Complain/ComplainDetail/GetComplainDetail")]
        public List<ComplainDetail> GetComplainDetail(int ComplainDetailId)
        {
            List<ComplainDetail> _dList = null;
            return _dList = _repository.GetComplainDetail(ComplainDetailId);
        }
        [Route("Complain/ComplainDetail/ReviewComplain")]
        public async Task<IActionResult> ReviewComplain()
        {
            return View();

        }
        [Route("Complain/ComplainDetail/GetReviewComplainDetail")]
        public List<ComplainDetail> GetReviewComplainDetail(int WCID)
        {
            List<ComplainDetail> _dList = null;
            return _dList = _repository.GetReviewComplainDetail(WCID);
        }
        [HttpPost]
        [Route("Complain/ComplainDetail/ReviewComplainDetail")]
        public JsonResult ReviewComplainDetail([FromBody] List<ComplainDetail> json_data)
        {
            if (json_data == null)
            {
                json_data = new List<ComplainDetail>();
            }
            int returnvalue = 0; // 
            ComplainDetail obj = new ComplainDetail();
            foreach (ComplainDetail item in json_data)
            {
                obj.ComplainDetailId = item.ComplainDetailId;
                obj.ComplainStatusId = 2;
                obj.ComplainReviewRemarks = item.ComplainReviewRemarks;
                obj.ComplainReviewedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
                obj.ComplainReviewedOn = DateTime.Now;
                returnvalue = _repository.SaveReviewComplainDetail(obj);
            }
            return Json(returnvalue);

        }

        [HttpPost]
        [Route("Complain/ComplainDetail/ApproveComplainDetail")]
        public JsonResult ApproveComplainDetail([FromBody] List<ComplainDetail> json_data)
        {
            if (json_data == null)
            {
                json_data = new List<ComplainDetail>();
            }
            int returnvalue = 0; // 
            ComplainDetail obj = new ComplainDetail();
            foreach (ComplainDetail item in json_data)
            {
                obj.ComplainDetailId = item.ComplainDetailId;
                obj.ComplainStatusId = 5;
                obj.ComplainApprovalRemarks = item.ComplainApprovalRemarks;
                obj.ComplainApprovedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
                obj.ComplainApprovedOn = DateTime.Now;
                returnvalue = _repository.SaveApprovalComplainDetail(obj);
            }
            return Json(returnvalue);

        }

        [HttpPost]
        [Route("Complain/ComplainDetail/RejectComplainDetail")]
        public JsonResult RejectComplainDetail([FromBody] List<ComplainDetail> json_data)
        {
            if (json_data == null)
            {
                json_data = new List<ComplainDetail>();
            }
            int returnvalue = 0; // 
            ComplainDetail obj = new ComplainDetail();
            foreach (ComplainDetail item in json_data)
            {
                obj.ComplainDetailId = item.ComplainDetailId;
                obj.ComplainStatusId = 5;
                obj.ComplainRejectRemarks = item.ComplainRejectRemarks;
                obj.ComplainRejectedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
                obj.ComplainRejectedOn = DateTime.Now;
                returnvalue = _repository.SaveRejectionComplainDetail(obj);
            }
            return Json(returnvalue);

        }
    }
}
