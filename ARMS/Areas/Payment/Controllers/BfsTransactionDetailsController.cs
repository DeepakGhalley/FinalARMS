using CORE_BLL;
using CORE_BOL;
using CORE_BOL.Entities;
using CORE_DLL;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ARMS.Areas.Payment.Controllers
{
    [Area("Payment")]
    public class BfsTransactionDetailsController : Controller
    {
        readonly IBfsTransactionDetails _repository = new BfsTransactionDetailBLL();


        [Route("Payment/BfsTransactionDetails/Index")]
        //[Route("Payment/DemandCancels/Index1")]
        public ActionResult Index()
        {
            return View();
        }


        [Route("Payment/BfsTransactionDetails/Search")]
        //[Route("Payment/DemandCancels/Search")]
        public List<BfsModel> Search(string search)
        {
            List<BfsModel> _dList = null;
            return _dList = _repository.Search(search);
        }
        [Route("Payment/BfsTransactionDetails/SearchAll")]
        //[Route("Payment/DemandCancels/Search")]
        public List<BfsModel> SearchAll()
        {
            List<BfsModel> _dList = null;
            return _dList = _repository.SearchAll();
        }


        [Route("Payment/BfsTransactionDetails/showDetails")]
        public List<BfsModel> showDetails(int id)
        {
            List<BfsModel> _dList = null;
            return _dList = _repository.showDetails(id);
        }


        //for Checking BFS 
        [Route("Payment/BfsTransactionDetails/bfsCheck")]
        public List<BfsModel> bfsCheck(int id)
        {
            List<BfsModel> _dList = null;
            return _dList = _repository.bfsCheck(id);
        }


        //BfsModel objBfs
        [Route("Payment/BfsTransactionDetails/SavePaymentSuccess")]
        public JsonResult SavePaymentSuccess([FromBody] List<BfsModel> json_data, List<BfsModel> json_data1)
        { 
            if (json_data == null)
            {
                json_data = new List<BfsModel>();
            }

            long returnvalue = 0;

            BfsModel obj = new BfsModel();
          
            foreach (BfsModel item in json_data)
            {
                obj.BfsTransactionDetailId = item.BfsTransactionDetailId;
              
                
                returnvalue = _repository.SavePaymentSuccess(obj);
            }


            return Json(returnvalue);

        }
    }
}
