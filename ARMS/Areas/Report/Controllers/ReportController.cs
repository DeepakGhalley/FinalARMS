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

namespace ARMS.Areas.Report.Controllers
{
    [Area("Report")]
    public class ReportController : Controller
    {
        private readonly tt_dbContext _context;
        private readonly IMapper _mapper;
        ICommonFunction _CommonRepo = new CommonFunctionBLL();
        readonly IRevenueReport _repository = new RevenueReportBLL();
        readonly ILedger _obj = new LedgerBLL();
        readonly IRevenueTransfer _rep = new RevenueTransferBLL();

        //private int _createdBy;
        //private DateTime _createdOn = DateTime.Now;

        public ReportController(tt_dbContext context)
        {
            _context = context;
        }

        // GET: AssetRegister/Assets
        [Route("Report/Report")]
        public async Task<IActionResult> Index()
        {
            return View();
        }
        [Route("Report/Report/Individualwise")]
        public async Task<IActionResult> Individualwise()
        {
            return View();
        }
        [Route("Report/Report/IndividualCollection")]
        public async Task<IActionResult> IndividualCollection()
        {
            return View();
        }
        [Route("Report/Report/Individualwisecollection")]
        public async Task<IActionResult> Individualwisecollection()
        {
            return View();
        }

        [Route("Report/Report/IndividualCollected")]
        public async Task<IActionResult> IndividualCollected()
        {
            return View();
        }


        [Route("Report/Report/GetRevenue")]
        public IEnumerable<ARevenueVM> GetRevenue(string StartDate, string EndDate)
        {

            IEnumerable<ARevenueVM> _dList = null;

                return _dList = _repository.Revenue(StartDate, EndDate);
            
        }

        [Route("Report/Report/GetWaterRevenueDetails")]

        public IEnumerable<AwaterVM> GetWaterRevenueDetails(string StartDate, string EndDate)
        {

            IEnumerable<AwaterVM> _dList = null;

            return _dList = _repository.Revenuewater(StartDate, EndDate);

        }
       

        [Route("Report/Report/GetHeadWaterRevenueDetails")]
   
             public IEnumerable<AwaterHeadwiseVM> GetHeadWaterRevenueDetails(string StartDate, string EndDate)
        {

            IEnumerable<AwaterHeadwiseVM> _dList = null;

            return _dList = _repository.Revenuewaterheadwise(StartDate, EndDate);

        }
        [Route("Report/Report/GetReceiptwiseWaterRevenueDetails")]
       
              public IEnumerable<AwaterReceiptwiseVM> GetReceiptwiseWaterRevenueDetails(string StartDate, string EndDate)
        {

            IEnumerable<AwaterReceiptwiseVM> _dList = null;

            return _dList = _repository.Revenuewaterrecepitwise(StartDate, EndDate);

        }
     
        [Route("Report/Report/fetchDreceiptuser")]
        public IList<LedgerDemandVM> fetchDreceiptuser(long ReceiptId)
        {
            return _obj.fetchDreceiptuser(ReceiptId).ToList();
        }
        [Route("Report/Report/PrintDuplicatePaymentModes")]
        public IList<LedgerDemandVM> PrintDuplicatePaymentModes(long ReceiptId)
        {
            return _obj.PrintDuplicatePaymentModes(ReceiptId).ToList();
        }
        [Route("Report/Report/fetchledgerdata")]
        public List<LedgerDemandVM> fetchledgerdata(long RecepitId)
        {
            return _obj.fetchledgerdata(RecepitId).ToList();
        }


        [Route("Report/Report/GetPropertyRevenueDetails")]
        public IEnumerable<ApropertyVM> GetPropertyRevenueDetails(string StartDate, string EndDate)
        {

            IEnumerable<ApropertyVM> _dList = null;

            return _dList = _repository.Revenueproperty(StartDate, EndDate);

        }

        [Route("Report/Report/GetPropertyheadwiseDetails")]
        public IEnumerable<ApropertyheadwiseVM> GetPropertyheadwiseDetails(string StartDate, string EndDate)
        {

            IEnumerable<ApropertyheadwiseVM> _dList = null;

            return _dList = _repository.Revenuepropertyheadwise(StartDate, EndDate);

        }

        [Route("Report/Report/GetRevenuepropertyeceiptwise")]
        public IEnumerable<ApropertyrecepitwiseVM> GetRevenuepropertyeceiptwise(string StartDate, string EndDate)
        {

            IEnumerable<ApropertyrecepitwiseVM> _dList = null;

            return _dList = _repository.Revenuepropertyeceiptwise(StartDate, EndDate);

        }
        [Route("Report/Report/PrintPaymentreceipt")]
        public List<LedgerDemandVM> PrintPaymentreceipt(int id)
        {
            return _obj.PrintPaymentreceipt(id).ToList();
        }
        [Route("Report/Report/PrintNames")]

        public IList<LedgerDemandVM> PrintNames(int id)
        {
            return _obj.PrintNames(id).ToList();
        }

        [Route("Report/Report/PrintPaymentModes")]
        public IList<LedgerDemandVM> PrintPaymentModes(int ReceiptId)
        {
            return _obj.PrintPaymentModes(ReceiptId).ToList();
        }

        [Route("Report/Report/fetchreceiptuser")]
        public IList<LedgerDemandVM> fetchreceiptuser(int RecepitId)
        {
            return _obj.fetchreceiptuser(RecepitId).ToList();
        }



        [Route("Report/Report/GetwiseCollection")]
        public IEnumerable<wiseCollectionVM> GetwiseCollection(string StartDate, string EndDate)
        {

            IEnumerable<wiseCollectionVM> _dList = null;

            return _dList = _repository.wiseCollection(StartDate, EndDate);

        }
        //********************************************************WISE COLLECTION **********************************************************

        [Route("Report/Report/Showdetails")]

        public IEnumerable<wiseCollectionVM> Showdetails()
        {

            IEnumerable<wiseCollectionVM> _dList = null;

            return _dList = _repository.showwiseCollection();

        }

        [Route("Report/Report/CreatewiseCollection")]
        public IEnumerable<SavewiseCollectionVM> CreatewiseCollection(int UserId, int CreatedBy, decimal checkedAmount, string collectionStartDate,string collectionEndDate)
        {

            IEnumerable<SavewiseCollectionVM> _dList = null;
             CreatedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
           
            return _dList = _repository.SavewiseCollection(UserId, CreatedBy, checkedAmount, collectionStartDate, collectionEndDate);

        }


        [Route("Report/Report/GetCollected")]
        public IEnumerable<wiseCollectedVM> GetCollected(string StartDate, string EndDate)
        {

            IEnumerable<wiseCollectedVM> _dList = null;

            return _dList = _repository.Collected(StartDate, EndDate);

        }
        private void PopulateDropDowns()
        {
            ViewData["Mode"] = _CommonRepo.SelectListPaymentModeType();
            ViewData["User"] = _CommonRepo.SelectListUser();

        }

        [Route("Report/Report/GetModeWise")]
        public IEnumerable<ModeWiseCollectionVM> GetModeWise(string StartDate, string EndDate, int PaymentModeId, int UserId)
        {

            IEnumerable<ModeWiseCollectionVM> _dList = null;

            return _dList = _repository.ModeWise(StartDate, EndDate, PaymentModeId, UserId);

        }
        [Route("Report/Report/Modewisecollection")]
        public async Task<IActionResult> Modewisecollection()

        { 
        PopulateDropDowns();
            return View();
        }

        [Route("Report/Report/Getdetailwise")]
        public IEnumerable<wisedetailVM> Getdetailwise(string StartDate, string EndDate, int UserId)
        {

            IEnumerable<wisedetailVM> _dList = null;

            return _dList = _repository.detailwise(StartDate, EndDate, UserId);

        }

        [Route("Report/Report/mannual")]
        public IEnumerable<RevenueIOVM> mannual(string StartDate,string EndDate)
        {

            IEnumerable<RevenueIOVM> _dList = null;

            return _dList = _rep.Rmannual(StartDate, EndDate);

        }
    }

}
