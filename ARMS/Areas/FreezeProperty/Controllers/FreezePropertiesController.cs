using CORE_BLL;
using CORE_BOL;
using CORE_DLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ARMS.Areas.FreezeProperty.Controllers
{
    [Area("FreezeProperty")]
    public class FreezePropertiesController : Controller
    {
        readonly IFreezeProperty _repository = new FreezePropertyBLL();

        // GET: FreezePropertiesController
        [Route("FreezeProperty/FreezeProperties")]
        public ActionResult Index()
        {
            return View();
        }

        // GET: FreezePropertiesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: FreezePropertiesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FreezePropertiesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FreezePropertiesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: FreezePropertiesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FreezePropertiesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: FreezePropertiesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [Route("FreezeProperty/FreezeProperties/SearchDetails")]
        public List<FreezePropertyVM> SearchDetails(string plotno, string thramno)
        {
            List<FreezePropertyVM> _dList = null;
            return _dList = _repository.SearchDetails(plotno, thramno);
        }

        [HttpPost]
        [Route("FreezeProperty/FreezeProperties/SaveDetails")]
        public JsonResult SaveDetails([FromBody] List<FreezePropertyVM> json_data)
        {  
            if (json_data == null)
            {
                json_data = new List<FreezePropertyVM>();
            }

            FreezePropertyVM obj = new FreezePropertyVM();

            foreach (FreezePropertyVM item in json_data)
            {
                obj.LetterNo = item.LetterNo;
                obj.LandDetailId = item.LandDetailId;
                obj.LetterDate = item.LetterDate;
                obj.IsFreeze = item.IsFreeze;
                obj.Remarks = item.Remarks;
                obj.CreatedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
                obj.CreatedOn = DateTime.Now;
                _repository.SaveDetails(obj);
            }
            try
            {
                int returnvalue = 1; // 

                if (returnvalue > 0)
                {
                    TempData["msg"] = "Data  Saved Successfully!";

                }
                else
                {
                    TempData["msg"] = "New record creation failed";
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }

            return Json(TempData["msg"]);
        }



    }
}
