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
using System.Runtime.InteropServices.ComTypes;
using System.Transactions;

namespace ARMS.Areas.EnvironmentClearance.Controllers
{
    [Area("EnvironmentClearance")]
    public class ECdetailsController : Controller
    {
        private readonly tt_dbContext _context;
        private readonly IMapper _mapper;
        ICommonFunction _CommonRepo = new CommonFunctionBLL();
        readonly IECDetail _repository = new ECDetailBLL();
        readonly tt_dbContext ctx = new tt_dbContext();

        private void ECDetailDropDown()
        {
            ViewData["ApplicantId"] = _CommonRepo.SelectListApplicantDetail();
            ViewData["ApprovalStatusId"] = _CommonRepo.SelectListApprovslStatus();
            ViewData["ActivityTypeId"] = _CommonRepo.SelectListECAcitvityType();
            ViewData["IndustryTypeId"] = _CommonRepo.SelectListIndustryType();
            ViewData["ProjectStatusId"] = _CommonRepo.SelectListProjectStatus();
        }

        [Route("EnvironmentClearance/ECdetails")]
        public async Task<IActionResult> Index()
        {
            _ = new List<ECDetailModel>();
            IList<ECDetailModel> obj = _repository.GetAll();
            ECDetailDropDown();
            return View(obj);
        }

        [Route("EnvironmentClearance/ECdetails/GetApplicantDetails")]
        public List<ECDetailModel> GetApplicantDetails(string CIDLicenceNo, string ApplicantName)
        {

            List<ECDetailModel> _dList = null;
            return _dList = _repository.GetApplicantDetails(CIDLicenceNo, ApplicantName);
        }

        [HttpPost]
        [Route("EnvironmentClearance/ECdetails/SaveECDetail")]
        public JsonResult SaveECDetail([FromBody] List<ECDetailModel> json_data)
        {
            if (json_data == null)
            {
                json_data = new List<ECDetailModel>();
            }
            int returnvalue = 0;
            ECDetailModel obj = new ECDetailModel();
            foreach (ECDetailModel item in json_data)
            {
                obj.ApplicantId = item.ApplicantId;
                obj.ProjectName = item.ProjectName;
                obj.StartDate = item.StartDate;
                obj.EndDate = item.EndDate;
                obj.EcActivityTypeId = item.EcActivityTypeId;
                obj.IndustryTypeId = item.IndustryTypeId;
                obj.Quantity = item.Quantity;
                obj.CreatedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
                obj.CreatedOn = DateTime.Now;

                returnvalue = _repository.SaveECDetail(obj);
            }
            return Json(returnvalue);
        }

        [Route("EnvironmentClearance/ECdetails/GetECDetails")]
        public List<ECDetailModel> GetECDetails(int ApplicantId)
        {

            List<ECDetailModel> _dList = null;
            return _dList = _repository.GetECDetails(ApplicantId);
        }

        [HttpPost]
        [Route("EnvironmentClearance/ECdetails/SaveApprovalStatus")]
        public JsonResult SaveApprovalStatus([FromBody] List<ECDetailModel> json_data)
        {
            if (json_data == null)
            {
                json_data = new List<ECDetailModel>();
            }
            int returnvalue = 0;
            ECDetailModel obj = new ECDetailModel();
            foreach (ECDetailModel item in json_data)
            {
                obj.EcDetailId = item.EcDetailId;
                obj.ApprovalStatusId = item.ApprovalStatusId;
                obj.ApprovalRemarks = item.ApprovalRemarks;
                obj.ProjectStatusId = 1;
                obj.ApprovedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
                obj.ApprovalOn = DateTime.Now;

                returnvalue = _repository.SaveApprovalStatus(obj);
            }
            return Json(returnvalue);
        }
        [Route("EnvironmentClearance/ECdetails/GetECStatus")]
        public List<ECDetailModel> GetECStatus(int ECDetailId)
        {

            List<ECDetailModel> _dList = null;
            return _dList = _repository.GetECStatus(ECDetailId);
        }

        [HttpPost]
        [Route("EnvironmentClearance/ECdetails/SaveProjectStatus")]
        public JsonResult SaveProjectStatus([FromBody] List<ECDetailModel> json_data)
        {
            if (json_data == null)
            {
                json_data = new List<ECDetailModel>();
            }
            int returnvalue = 0;
            ECDetailModel obj = new ECDetailModel();
            foreach (ECDetailModel item in json_data)
            {
                obj.EcDetailId = item.EcDetailId;
                obj.ProjectStatusId = item.ProjectStatusId;
                obj.ProjectClosedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
                obj.ProjectCloseDate = item.ProjectCloseDate;
                obj.ProjectCloseRemarks = item.ProjectCloseRemarks;

                returnvalue = _repository.SaveProjectStatus(obj);
            }
            return Json(returnvalue);
        }

        [Route("EnvironmentClearance/ECdetails/GetECDetailsForUpdate")]
        public List<ECDetailModel> GetECDetailsForUpdate(int ECDetailId)
        {

            List<ECDetailModel> _dList = null;
            return _dList = _repository.GetECDetailsForUpdate(ECDetailId);
        }

        [HttpPost]
        [Route("EnvironmentClearance/ECdetails/UpdateECDetail")]
        public JsonResult UpdateECDetail([FromBody] List<ECDetailModel> json_data)
        {
            if (json_data == null)
            {
                json_data = new List<ECDetailModel>();
            }
            int returnvalue = 0;
            ECDetailModel obj = new ECDetailModel();
            foreach (ECDetailModel item in json_data)
            {
                obj.EcDetailId = item.EcDetailId;
                obj.ProjectName = item.ProjectName;
                obj.IndustryTypeId = item.IndustryTypeId;
                obj.EcActivityTypeId = item.EcActivityTypeId;
                obj.StartDate = item.StartDate;
                obj.EndDate = item.EndDate;
                obj.Quantity = item.Quantity;
                obj.EcRenewalId = item.EcRenewalId;
                returnvalue = _repository.UpdateECDetail(obj);
            }
            return Json(returnvalue);
        }

        [Route("EnvironmentClearance/ECdetails/GetECDetailView")]
        public List<ECDetailModel> GetECDetailView(int ECDetailId)
        {

            List<ECDetailModel> _dList = null;
            return _dList = _repository.GetECDetailView(ECDetailId);
        }

        [HttpPost]
        [Route("EnvironmentClearance/ECdetails/GenerateECDemand")]
        public JsonResult GenerateECDemand([FromBody] List<ECDetailModel> json_data)
        {
            if (json_data == null)
            {
                json_data = new List<ECDetailModel>();
            }
            int returnvalue = 0;
            ECDetailModel obj = new ECDetailModel();
            foreach (ECDetailModel item in json_data)
            {
                obj.EcRenewalId = item.EcRenewalId;
                obj.IndustryTypeId = item.IndustryTypeId;
                obj.EcActivityTypeId = item.EcActivityTypeId;
                obj.ApplicantId = item.ApplicantId;
                obj.Quantity = item.Quantity;
                obj.CreatedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
                obj.CreatedOn = DateTime.Now;
                obj.EcDetailId = item.EcDetailId;
                returnvalue = _repository.GenerateECDemand(obj);
            }
            return Json(returnvalue);
        }

        [Route("EnvironmentClearance/ECdetails/GetECDemand")]
        public List<ECDetailModel> GetECDemand(int DemandNoId)
        {

            List<ECDetailModel> _dList = null;
            return _dList = _repository.GetECDemand(DemandNoId);
        }

        [Route("EnvironmentClearance/ECdetails/GetUserName")]
        public List<ECDetailModel> GetUserName(int DemandNoId)
        {

            List<ECDetailModel> _dList = null;
            return _dList = _repository.GetUserName(DemandNoId);
        }
    }

    
}
