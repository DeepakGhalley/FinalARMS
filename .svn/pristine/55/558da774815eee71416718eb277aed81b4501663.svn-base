using AutoMapper;
using CORE_BLL;
using CORE_BOL;
using CORE_BOL.Entities;
using CORE_DLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ARMS.Areas.Property.Controllers
{
    [Area("Property")]
    public class LandFeeDetailsController : Controller
    {
        private readonly tt_dbContext _context;
        private readonly IMapper _mapper;
        ICommonFunction _CommonRepo = new CommonFunctionBLL();
        readonly ILandFeeDetail _repository = new LandFeeDetailBLL();
        readonly ILandFeeDetail _obj = new LandFeeDetailBLL();

        public LandFeeDetailsController(tt_dbContext context)
        {
            _context = context;
        }
        [Route("Property/LandFeeDetails")]
        public IActionResult Index()
        {
            PopulateDropDowns();
            return View();
        }
        [Route("Property/LandFeeDetails/FetchlandOwnershipDetails")]
        public IList<LedgerDemandVM> FetchlandOwnershipDetails(string Ttin, string Cid, string PlotNo, string ThramNo)
        {
            IList<LedgerDemandVM> _dList = null;
            return _dList = _repository.FetchlandOwnershipDetails(Ttin, Cid, PlotNo, ThramNo);
        }
        private void PopulateDropDowns()
        {
            ViewData["LandServiceType"] = _CommonRepo.SelectListLandServiceType();
        }
        [HttpPost]
        [Route("Property/LandFeeDetails/SaveLandFeeDetails")]
        public JsonResult SaveLandFeeDetails([FromBody] List<LandFeeDetailVM> json_data)
        {
            if (json_data == null)
            {
                json_data = new List<LandFeeDetailVM>();
            }
            LandFeeDetailVM obj = new LandFeeDetailVM();

            //bool CreateCheckDuplicate = _repository.DuplicateCheckOnSave(obj.ConsumerNo);
            //if (CreateCheckDuplicate)
            //{
            //    TempData["msg"] = "Duplicate data found, please enter a different Water Connection";
            //    PopulateDropDowns();
            //    return null;
            //}
            long returnvalue = 0;


            foreach (LandFeeDetailVM item in json_data)
            {
                // obj.MiscellaneousRecordId = item.MiscellaneousRecordId;
                obj.LandOwnershipId = item.LandOwnershipId;
                obj.LandServiceTypeId = item.LandServiceTypeId;
                obj.LandDetailId = item.LandDetailId;
                obj.TaxPayerId = item.TaxPayerId;
                obj.Amount = item.Amount;
                obj.LandDetailId = item.LandDetailId;
                obj.LandOwnershipId = item.LandOwnershipId;
                obj.TaxPayerId = item.TaxPayerId;
                obj.CreatedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));

                returnvalue = _repository.Save(obj);
            }
            return Json(returnvalue);

        }

        [HttpPost]
        [Route("Property/LandFeeDetails/SavemajorLandFeeDetails")]
        public JsonResult SavemajorLandFeeDetails([FromBody] List<LandFeeDetailVM> json_data)
        {
            if (json_data == null)
            {
                json_data = new List<LandFeeDetailVM>();
            }
            LandFeeDetailVM obj = new LandFeeDetailVM();

            //bool CreateCheckDuplicate = _repository.DuplicateCheckOnSave(obj.ConsumerNo);
            //if (CreateCheckDuplicate)
            //{
            //    TempData["msg"] = "Duplicate data found, please enter a different Water Connection";
            //    PopulateDropDowns();
            //    return null;
            //}
            long returnvalue = 0;


            foreach (LandFeeDetailVM item in json_data)
            {
                // obj.MiscellaneousRecordId = item.MiscellaneousRecordId;
                obj.LandOwnershipId = item.LandOwnershipId;
                obj.LandServiceTypeId = item.LandServiceTypeId;
                obj.LandDetailId = item.LandDetailId;
                obj.TaxPayerId = item.TaxPayerId;
                obj.ScrutinyFeeAmount = item.ScrutinyFeeAmount;
                obj.ServiceandAmenitiesfeeAmount = item.ServiceandAmenitiesfeeAmount;
               
                obj.LandDetailId = item.LandDetailId;
                obj.LandOwnershipId = item.LandOwnershipId;
                obj.TaxPayerId = item.TaxPayerId;
                obj.CreatedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));

                returnvalue = _repository.Save(obj);
            }
            return Json(returnvalue);

        }


        [Route("Property/LandFeeDetails/PrintDemand")]
        public IList<LedgerDemandVM> PrintDemand(int TransactionId)
        {
            IList<LedgerDemandVM> _dList = null;
            return _dList = _repository.PrintDemand(TransactionId);
        }

        [Route("Property/LandFeeDetails/FetchAmount")]
        public List<MstRate> FetchRate(int id)
        {
            var data = (from a in _context.MstTransactionTypeTaxMap.Where(x => x.TransactionTypeId == id)
                        join b in _context.MstSlab on a.TaxId equals b.TaxId
                        join c in _context.MstRate on b.SlabId equals c.SlabId
                        select new MstRate
                        {
                            RateId = c.RateId,
                            Rate = c.Rate
                        });
            return data.ToList();
        }

        [Route("Property/LandFeeDetails/PrintUser")]
        public List<LedgerDemandVM> PrintUser(int TransactionId)
        {
            List<LedgerDemandVM> _dList = null;
            return _dList = _repository.PrintUser(TransactionId);
        }

        [Route("Property/LandFeeDetails/FetchTaxDetails")]
        public List<LedgerDemandVM> FetchTaxDetails(long TaxPayerId)
        {
            List<LedgerDemandVM> _dList = null;
            return _dList = _repository.FetchTaxDetails(TaxPayerId);
        }
        [Route("Property/LandFeeDetails/LandTransactionFeeRecepit")]
        public List<LedgerDemandVM> LandTransactionFeeRecepit(long TransactionId)
        {
            List<LedgerDemandVM> _dList = null;
            return _dList = _repository.LandTransactionFeeRecepit(TransactionId);
        }

        [Route("Property/LandFeeDetails/fetchreceiptuser")]
        public List<LedgerDemandVM> fetchreceiptuser(long TransactionId)
        {
            List<LedgerDemandVM> _dList = null;
            return _dList = _repository.fetchreceiptuser(TransactionId);
        }
       
    }
}
