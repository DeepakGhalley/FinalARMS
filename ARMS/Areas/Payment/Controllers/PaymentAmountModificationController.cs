using System;
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
using AutoMapper;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.AspNetCore.Http;
using ARMS.Functions;
using System.IO;

namespace ARMS.Areas.Location.Controllers
{
    [Area("Payment")]
    public class PaymentAmountModificationController : Controller
    {
        private readonly tt_dbContext _context;

        private readonly IMapper _mapper;
        ICommonFunction _CommonRepo = new CommonFunctionBLL();

        readonly IPaymentAmountModification _repository = new PaymentAmountModificationBLL();
        public PaymentAmountModificationController(tt_dbContext context, IMapper mapper)
        {
            _context = context; _mapper = mapper;

        }

        [Route("Payment/PaymentAmountModification/PaymentAmountModification")]
        public async Task<IActionResult> PaymentAmountModification()
        {
            return View();
        }
        [Route("Payment/PaymentAmountModification/PaymentModification")]
        public IActionResult PaymentModification()
        {
            return View();
        }

        [Route("Payment/PaymentAmountModification/GetDemandDetails")]
        public List<PaymentAmountModification> GetDemandDetails(string DemandNo)
        {

            List<PaymentAmountModification> _dList = null;
            return _dList = _repository.GetDemandDetails(DemandNo);
        }

        [Route("Payment/PaymentAmountModification/GetReceiptDetails")]
        public List<PaymentAmountModification> GetReceiptDetails(string ReceiptNo)
        {

            List<PaymentAmountModification> _dList = null;
            return _dList = _repository.GetReceiptDetails(ReceiptNo);
        }

        [HttpPost]
        [Route("Payment/PaymentAmountModification/SaveDemand")]
        public JsonResult SaveDemand([FromBody] List<PaymentAmountModification> json_data)
        {
            
            if (json_data == null)
            {
                json_data = new List<PaymentAmountModification>();
            }
            int returnvalue = 0; // 
            PaymentAmountModification obj = new PaymentAmountModification();
            foreach (PaymentAmountModification item in json_data)
            {
                string myFilePath = item.DemandUpload;
                string ext = Path.GetExtension(myFilePath);

                obj.DemandId = item.DemandId;
                obj.PreviousDemandAmount = item.PreviousDemandAmount;
                obj.TotalDemandAmount = item.TotalDemandAmount;
                obj.DSL = item.DSL;
                obj.CreatedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
                obj.DemandUpload = Convert.ToString("D_" + obj.DSL + Path.GetExtension(ext));
                obj.CreatedOn = DateTime.Now;
                returnvalue = _repository.SaveDemand(obj);
            }
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/DemandLedgerPaymentUpdate", obj.DemandUpload);
            //var stream = new FileStream(path, FileMode.Create);
            return Json(returnvalue);
        }

        [Route("Payment/PaymentAmountModification/GetPaymentModeDetails")]
        public List<PaymentAmountModification> GetPaymentModeDetails(int ReceiptId)
        {

            List<PaymentAmountModification> _dList = null;
            return _dList = _repository.GetPaymentModeDetails(ReceiptId);
        }


        [HttpPost]
        [Route("Payment/PaymentAmountModification/SavePayment")]
        public JsonResult SavePayment([FromBody] List<PaymentAmountModification> json_data)
        {

            if (json_data == null)
            {
                json_data = new List<PaymentAmountModification>();
            }
            int returnvalue = 0; // 
            PaymentAmountModification obj = new PaymentAmountModification();
            foreach (PaymentAmountModification item in json_data)
            {
                string myFilePath = item.PaymentUpload;
                string ext = Path.GetExtension(myFilePath);

                obj.DemandId = item.DemandId;
                obj.LedgerId = item.LedgerId;
                obj.PaymentLedgerId = item.PaymentLedgerId;
                obj.PreviousPaymentAmount = item.PreviousPaymentAmount;
                obj.TotalPaymentAmount = item.TotalPaymentAmount;
                obj.CreatedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
                obj.RSL = item.RSL;
                obj.PaymentUpload = Convert.ToString("R_" + obj.RSL + Path.GetExtension(ext));
                obj.CreatedOn = DateTime.Now;
                returnvalue = _repository.SavePayment(obj);
            }
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/DemandLedgerPaymentUpdate", obj.PaymentUpload);
            //var stream = new FileStream(path, FileMode.Create);

            return Json(returnvalue);
        }

        [HttpPost]
        [Route("Payment/PaymentAmountModification/SavePaymentModeAmount")]
        public JsonResult SavePaymentModeAmount([FromBody] List<PaymentAmountModification> json_data)
        {

            if (json_data == null)
            {
                json_data = new List<PaymentAmountModification>();
            }
            int returnvalue = 0; // 
            PaymentAmountModification obj = new PaymentAmountModification();
            foreach (PaymentAmountModification item in json_data)
            {
                string myFilePath = item.PaymentUpload;
                string ext = Path.GetExtension(myFilePath);

                
                obj.PreviousPaymentModeAmount = item.PreviousPaymentModeAmount;
                obj.PaymentLedgerId = item.PaymentLedgerId;
                obj.TotalPaymentModeAmount = item.TotalPaymentModeAmount;
                obj.RSL = item.RSL;
                obj.CreatedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
                obj.PaymentUpload = Convert.ToString("R_" + obj.RSL + Path.GetExtension(ext));
                obj.CreatedOn = DateTime.Now;
                returnvalue = _repository.SavePaymentModeAmount(obj);
            }
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/DemandLedgerPaymentUpdate", obj.PaymentUpload);
            return Json(returnvalue);
        }
    }
}
