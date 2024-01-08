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

namespace ARMS.Areas.EnvironmentClearance.Controllers
{
    [Area("EnvironmentClearance")]
    public class ECRenewalDetailsController : Controller
    {
        private readonly tt_dbContext _context;
        private readonly IMapper _mapper;
        ICommonFunction _CommonRepo = new CommonFunctionBLL();
        readonly IECRenewalDetail _repository = new ECRenewalDetailBLL();
        readonly IECRenewalDetail _obj = new ECRenewalDetailBLL();


        public ECRenewalDetailsController(tt_dbContext context)
        {
            _context = context;
        }

        [Route("EnvironmentClearance/ECRenewalDetails")]
        public async Task<IActionResult> Index()
        {
            _ = new List<ECRenewalDetailModel>();
            IList<ECRenewalDetailModel> obj = _repository.GetAll();
            return View(obj);
        }

        [Route("EnvironmentClearance/ECRenewalDetails/Details")]
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
        private void ECRenewalDropDown()
        {
            ViewData["EcUseTypeId"] = _CommonRepo.SelectListECUseType();
            ViewData["EcDetailId"] = _CommonRepo.SelectListECDetails();
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblEcrenewalDetail = await _context.TblEcrenewalDetail
                .Include(t => t.EcUseType)
                .Include(t => t.EcDetail)
                .FirstOrDefaultAsync(m => m.EcRenewalId == id);
            if (tblEcrenewalDetail == null)
            {
                return NotFound();
            }

            return View(tblEcrenewalDetail);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblEcrenewalDetail = await _context.TblEcrenewalDetail.FindAsync(id);
            _context.TblEcrenewalDetail.Remove(tblEcrenewalDetail);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        [Route("EnvironmentClearance/ECRenewalDetails/GetECDetails")]
        public List<ECDetailModel> GetECDetails(int ApplicantId)
        {

            List<ECDetailModel> _dList = null;
            return _dList = _obj.GetECDetails(ApplicantId);
        }

        [Route("EnvironmentClearance/ECRenewalDetails/GetEcRenewal")]
        public List<ECDetailModel> GetEcRenewal(string cid, string applicantname)
        {

            List<ECDetailModel> _dList = null;
            return _dList = _obj.fetchECRenewalByCid(cid, applicantname);
        }

        [Route("EnvironmentClearance/ECRenewalDetails/GetECRenewalDetails")]
        public List<ECRenewalDetailModel> GetECRenewalDetails(int ECDetailId)
        {

            List<ECRenewalDetailModel> _dList = null;
            return _dList = _obj.GetECRenewalDetails(ECDetailId);
        }

        [HttpPost]
        [Route("EnvironmentClearance/ECRenewalDetails/SaveECRenewal")]
        public JsonResult SaveECRenewal([FromBody] List<ECRenewalDetailModel> json_data)
        {
            if (json_data == null)
            {
                json_data = new List<ECRenewalDetailModel>();
            }
            int returnvalue = 0;
            ECRenewalDetailModel obj = new ECRenewalDetailModel();
            foreach (ECRenewalDetailModel item in json_data)
            {
                obj.EcRenewalId = item.EcRenewalId;
                obj.ValidUpTo = item.ValidUpTo;
                obj.ModifiedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
                obj.Remarks = item.Remarks;
                obj.ModifiedOn = DateTime.Now;
                obj.EcDetailId = item.EcDetailId;
                returnvalue = _repository.SaveECRenewal(obj);
            }
            return Json(returnvalue);
        }

        [HttpPost]
        [Route("EnvironmentClearance/ECRenewalDetails/GenerateECDemand")]
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
                obj.EndDate = item.EndDate;
                returnvalue = (int)_repository.GenerateECDemand(obj);
            }
            return Json(returnvalue);
        }
        [Route("EnvironmentClearance/ECRenewalDetails/GetECDemand")]
        public List<ECDetailModel> GetECDemand(int DemandNoId)
        {

            List<ECDetailModel> _dList = null;
            return _dList = _repository.GetECDemand(DemandNoId);
        }

        [Route("EnvironmentClearance/ECRenewalDetails/GetUserName")]
        public List<ECDetailModel> GetUserName(int DemandNoId)
        {

            List<ECDetailModel> _dList = null;
            return _dList = _repository.GetUserName(DemandNoId);
        }
    }
}
