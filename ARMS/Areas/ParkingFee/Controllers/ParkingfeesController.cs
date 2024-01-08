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
    [Area("ParkingFee")]
    public class ParkingfeesController : Controller
    {
        private readonly tt_dbContext _context;
        private readonly IMapper _mapper;
        ICommonFunction _CommonRepo = new CommonFunctionBLL();
        readonly IParkingFee1 _repository = new Parkingfee1Bll();
        readonly IParkingFee1 _obj = new Parkingfee1Bll();

        public ParkingfeesController(tt_dbContext context)
        {
            _context = context;
        }
        [Route("ParkingFee/Parkingfees")]
        public IActionResult Index()
        {
            _ = new List<Parkingfee1VM>();
            IList<Parkingfee1VM> obj = _repository.GetAll();
            return View(obj);
        }


        [Route("ParkingFee/Parkingfees/Create")]
        public IActionResult Create()
        {
          
            return View();
        }
        [HttpPost]
        [Route("ParkingFee/Parkingfees/Save")]
        public JsonResult Save([FromBody] List<Parkingfee1VM> json_data)
        {
            if (json_data == null)
            {
                json_data = new List<Parkingfee1VM>();
            }
            Parkingfee1VM obj = new Parkingfee1VM();

            //bool CreateCheckDuplicate = _repository.DuplicateCheckOnSave(obj.ConsumerNo);
            //if (CreateCheckDuplicate)
            //{
            //    TempData["msg"] = "Duplicate data found, please enter a different Water Connection";
            //    PopulateDropDowns();
            //    return null;
            //}
            long returnvalue = 0;
           

            foreach (Parkingfee1VM item in json_data)
            {
                // obj.MiscellaneousRecordId = item.MiscellaneousRecordId;
                obj.Cid = item.Cid;
                obj.VendorName = item.VendorName;
                obj.VendorAddress = item.VendorAddress;
                obj.Amount = item.Amount;
                obj.ToDate = item.ToDate;
                obj.FromDate = item.FromDate;
                obj.CreatedOn = DateTime.Now;
                obj.CreatedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
                
                returnvalue = _repository.Save(obj);
            }
            return Json(returnvalue);

        }
        [Route("ParkingFee/Parkingfees/PrintDemand")]
        public IList<Parkingfee1VM> PrintDemand(int TransactionId)
        {
            IList<Parkingfee1VM> _dList = null;
            return _dList = _repository.PrintDemand(TransactionId);
        }
        [Route("ParkingFee/Parkingfees/PrintUser")]
        public IList<Parkingfee1VM> PrintUser(int TransactionId)
        {
            IList<Parkingfee1VM> _dList = null;
            return _dList = _repository.PrintUser(TransactionId);
        }

      
    }
}
