﻿using CORE_BLL;
using CORE_BOL;
using CORE_BOL.Entities;
using CORE_DLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ARMS.Areas.Payment.Controllers
{
    [Area("Payment")]
    public class BfsFailedOnlineTransactionDetailsController : Controller
    {
        readonly IBfsFailedOnlineTransactionDetails _repository = new BfsFailedOnlineTransactionDetailBLL();
        ICommonFunction _CommonRepo = new CommonFunctionBLL();


        [Route("Payment/BfsFailedOnlineTransactionDetails/Index")]
        //[Route("Payment/DemandCancels/Index1")]
        public ActionResult Index()
        {
            return View();
        }

        [Route("Payment/BfsFailedOnlineTransactionDetails/Search")]
        public async Task<List<LedgerDemandVM>> Search(string search)
        {
            List<LedgerDemandVM> _dList = null;
            return _dList = _repository.Search(search);
        }
        [Route("Payment/BfsFailedOnlineTransactionDetails/GetDemandDetail")]
        public List<LedgerDemandVM> GetDemandDetail(string id,DateTime paymentdate)
        {
            return _repository.GetDemandDetail(id, paymentdate).ToList();
        }
        [Route("Payment/BfsFailedOnlineTransactionDetails/GetPaymentMode")]
        public List<CommonFunctionModel> GetPaymentMode()
        {
            return _CommonRepo.SelectListPaymentModeTypePaymentFailure().ToList();

        }
        [Route("Payment/BfsFailedOnlineTransactionDetails/GetBankBranch")]
        public List<CommonFunctionModel> GetBankBranch()
        {
            return _CommonRepo.SelectListBankBranch().ToList();
        }
        [Route("Payment/BfsFailedOnlineTransactionDetails/CheckDuplicatePayment")]
        public List<LedgerDemandVM> CheckDuplicatePayment(string id)
        {
            return _repository.CheckDuplicatePayment(id).ToList();
        }
        [Route("Payment/BfsFailedOnlineTransactionDetails/CreateLedger")]
        public JsonResult CreateLedger([FromBody] List<LedgerDemandVM> json_data, List<LedgerDemandVM> json_data1)
        {
            if (json_data == null)
            {
                json_data = new List<LedgerDemandVM>();
            }
            long returnvalue = 0;
            if (Convert.ToInt32(HttpContext.Session.GetInt32("UserId")) == 0)
            {
                returnvalue = 0;
                return Json(returnvalue);
            }
            LedgerDemandVM obj = new LedgerDemandVM();
            foreach (LedgerDemandVM item in json_data)
            {
                obj.Ids = item.Ids;
                obj.PaymentDate = item.PaymentDate;
                //obj.CreatedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
                returnvalue = _repository.CreateLedger(obj);
            }


            return Json(returnvalue);

        }
        [Route("Payment/BfsFailedOnlineTransactionDetails/CreatePaymentLedger")]

        public JsonResult CreatePaymentLedger([FromBody] List<LedgerPaymentLedgerModel> json_dataPaymentLedger)
        {

            if (json_dataPaymentLedger == null)
            {
                json_dataPaymentLedger = new List<LedgerPaymentLedgerModel>();
            }
            long returnvalue = 0;
            LedgerPaymentLedgerModel obj = new LedgerPaymentLedgerModel();
            foreach (LedgerPaymentLedgerModel item in json_dataPaymentLedger)
            {

                if (item.PaymentModeId == 3)//TTPAY
                {
                    obj.CreatedBy = 187;
                    //bname = "DK";
                }
                else if (item.PaymentModeId == 4)//op
                {
                    obj.CreatedBy = 192;
                    //bname = "op";
                }
                else if (item.PaymentModeId == 5)//epems
                {
                    obj.CreatedBy = 194;
                    //PaymentModeId = 5;
                    //bname = "ePems";
                }
                else if (item.PaymentModeId == 6)//MBOB
                {
                    obj.CreatedBy = 189;
                    //bname = "MBOB";
                }
                else if (item.PaymentModeId == 7)//BNB
                {
                    //obj.CreatedBy = 188;
                    //bname = "MBOB";
                }
                else if (item.PaymentModeId == 8)//DK
                {
                    obj.CreatedBy = 188;
                    //bname = "DK";
                }
                else if (item.PaymentModeId == 9)//TPAY
                {
                    //obj.CreatedBy = 188;
                    //bname = "DK";
                }
                else if (item.PaymentModeId == 10)//DRUK PAY
                {
                    //obj.CreatedBy = 188;
                    //bname = "DK";
                }
                else if (item.PaymentModeId == 11)//E PAY
                {
                    //obj.CreatedBy = 188;
                    //bname = "DK";
                }

                else if (item.PaymentModeId == 12)//etteru
                {
                    obj.CreatedBy = 191;
                    //PaymentModeId = 12;
                    //bname = "eTeeru";
                }
              
                if (item.PaymentModeId == 3|| item.PaymentModeId == 4 || item.PaymentModeId == 5|| item.PaymentModeId == 6 || item.PaymentModeId == 7 || item.PaymentModeId == 8 || item.PaymentModeId == 9 || item.PaymentModeId == 10 || item.PaymentModeId == 11 || item.PaymentModeId == 12)
                {
                    obj.BankBranchId = item.BankBranchId;
                    obj.PaymentModeNo = item.PaymentModeNo;
                    obj.PaymentModeDate = item.PaymentDate;
                    obj.CreatedOn = item.PaymentDate;
                    obj.PaymentDate = item.PaymentDate;
                }
                obj.PaymentModeId = item.PaymentModeId;
                obj.Amount = item.Amount;
                
                obj.ReceiptId = item.ReceiptId;
                returnvalue = _repository.CreatePaymentLedger(obj);
            }

            return Json(returnvalue);
        }
    }
}
