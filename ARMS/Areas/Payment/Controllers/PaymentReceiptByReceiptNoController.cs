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
using Microsoft.AspNetCore.Authorization;

namespace ARMS.Areas.Location.Controllers
{
    [Area("Payment")]
    public class PaymentReceiptByReceiptNoController : Controller
    {
        private readonly tt_dbContext _context;

        private readonly IMapper _mapper;
        ICommonFunction _CommonRepo = new CommonFunctionBLL();

        readonly IPaymentReceiptByReceiptNo _repository = new PaymentReceiptByReceiptNoBLL();
        public PaymentReceiptByReceiptNoController(tt_dbContext context, IMapper mapper)
        {
            _context = context; _mapper = mapper;

        }

        [Route("Payment/PaymentReceiptByReceiptNo/PaymentReceiptByReceiptNo")]
        public async Task<IActionResult> PaymentReceiptByReceiptNo()
        {
            return View();
        }

        [Route("Payment/PaymentReceiptByReceiptNo/GetReceiptDetails")]
        public List<PaymentReceiptByReceiptNo> GetReceiptDetails(string ReceiptNo)
        {

            List<PaymentReceiptByReceiptNo> _dList = null;
            return _dList = _repository.GetReceiptDetails(ReceiptNo);
        }
        [Route("Payment/PaymentReceiptByReceiptNo/GetECReceiptDetails")]
        public List<PaymentReceiptByReceiptNo> GetECReceiptDetails(string ReceiptNo)
        {

            List<PaymentReceiptByReceiptNo> _dList = null;
            return _dList = _repository.GetECReceiptDetails(ReceiptNo);
        }
        [Authorize]
        [Route("Payment/PaymentReceiptByReceiptNo/fetchECledgerdata")]
        public List<LedgerDemandVM> fetchECledgerdata(long RecepitId)
        {
            return _repository.fetchECledgerdata(RecepitId).ToList();
        }
    }
}
