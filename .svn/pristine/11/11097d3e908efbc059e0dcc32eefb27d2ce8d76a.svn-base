using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CORE_BOL.Entities;
using CORE_DLL;
using CORE_BLL;
using CORE_BOL;
using Microsoft.AspNetCore.Http;
using ARMS.Functions;

namespace ARMS.Areas.vacuumTankerService.Controllers
{
    [Area("vacuumTankerService")]
    public class VacuumTankersController : Controller
    {
    
        private readonly tt_dbContext _context;
        readonly IVacuumTankerService _repository = new VacuumTankerServiceBLL();

        public VacuumTankersController(tt_dbContext context)
        {
            _context = context;
        }

        // GET: Bank/Banks
        [Route("vacuumTankerService/VacuumTankers")]
        public async Task<IActionResult> Index()
        {
            _ = new List<VacuumTankerServiceVM>();
            IList<VacuumTankerServiceVM> obj = _repository.GetAll();
            return View(obj);
        }
        [Route("vacuumTankerService/VacuumTankers/Taxpayercreate")]
        public IActionResult Taxpayercreate()
        {


            return View();
        }
        [Route("vacuumTankerService/VacuumTankers/GetTaxpayer")]
        public IList<TaxPayerProfileModel> GetTaxpayer(string Cid, String Ttin)
        {

            IList<TaxPayerProfileModel> _dList = null;
            return _dList = _repository.GetTaxpayer(Cid, Ttin);
        }
        [Route("vacuumTankerService/VacuumTankers/Create")]
        public IActionResult Create()
        {
          

            return View();
        }
        

        // POST: BuildingType/BuildingTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
       
        [Route("vacuumTankerService/VacuumTankers/Create")]
        public JsonResult Create([FromBody] List<VacuumTankerServiceVM> json_data)
            {
                //using (tt_dbContext entities = new tt_dbContext())
                //{
                //Check for NULL.  
                if (json_data == null)
                {
                    json_data = new List<VacuumTankerServiceVM>();
                }
                long pk = 0;
                VacuumTankerServiceVM obj = new VacuumTankerServiceVM();
                //Loop and insert records. 


                foreach (VacuumTankerServiceVM item in json_data)
                {

                    
                    obj.Name = item.Name;
                    obj.ContactAddress = item.ContactAddress;
                    obj.MobileNo = item.MobileNo;
                    obj.NoOfTrips = item.NoOfTrips;
                    obj.Amount = item.Amount;
                    obj.CreatedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
                    obj.CreatedOn = DateTime.Now;
                    pk = _repository.Save(obj);
                }


                return Json(pk);
                //}
            }

            [HttpPost]
        
        [Route("vacuumTankerService/VacuumTankers/Createwithtaxpayer")]
        public JsonResult Createwithtaxpayer([FromBody] List<VacuumTankerServiceVM> json_data)
        {
            //using (tt_dbContext entities = new tt_dbContext())
            //{
            //Check for NULL.  
            if (json_data == null)
            {
                json_data = new List<VacuumTankerServiceVM>();
            }
            long pk = 0;
            VacuumTankerServiceVM obj = new VacuumTankerServiceVM();
            //Loop and insert records. 


            foreach (VacuumTankerServiceVM item in json_data)
            {
                
                obj.LandOwnershipId = item.LandOwnershipId;
                obj.Name = item.Name;
                obj.ContactAddress = item.ContactAddress;
                obj.MobileNo = item.MobileNo;
                obj.NoOfTrips = item.NoOfTrips;
                obj.Amount = item.Amount;
                obj.CreatedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
                obj.CreatedOn = DateTime.Now;
                pk = _repository.Save(obj);
            }
               
            
            return Json(pk);
            //}
        }


        [Route("vacuumTankerService/VacuumTankers/FetchRate")]
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

        [Route("VacuumTankers/VacuumTankers/GetDemand")]
        public IList<LedgerDemandVM> GetDemand(int id)
        {

            IList<LedgerDemandVM> _dList = null;
            return _dList = _repository.PrintDemand(id);
        }
    }
}
