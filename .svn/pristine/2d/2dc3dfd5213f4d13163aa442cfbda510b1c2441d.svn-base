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
namespace ARMS.Areas.Location.Controllers
{
    [Area("WaterMaster")]
    public class WaterConnectionTypesController : Controller
    {
        private readonly tt_dbContext _context;

        private readonly IMapper _mapper;
        ICommonFunction _CommonRepo = new CommonFunctionBLL();

        readonly IWaterConnectionTypes _repository = new WaterConnectionTypesBLL();
        public WaterConnectionTypesController(tt_dbContext context, IMapper mapper)
        {
            _context = context; _mapper = mapper;

        }

       
        [Route("WaterMaster/WaterConnectionTypes")]
        public async Task<IActionResult> Index()
        {
            _ = new List<WaterConnectionTypesModel>();
            IList<WaterConnectionTypesModel> obj = _repository.GetAll();

            return View(obj);
        }

        [Route("WaterMaster/WaterConnectionTypes/Details")]
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
        [Route("WaterMaster/WaterConnectionTypes/Create")]
        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        
        [Route("WaterMaster/WaterConnectionTypes/Create")]
        public async Task<IActionResult> Create(WaterConnectionTypesModel obj)
        {
            obj.CreatedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            obj.CreatedOn = Convert.ToDateTime(DateFunctions.getDatetypefrom(DateTime.Now.ToString("dd/MM/yyyy")));
            bool CreateCheckDuplicate = _repository.DuplicateCheckOnSave(obj.WaterConnectionType);
            if (CreateCheckDuplicate)
            {
                TempData["msg"] = "Duplicate data found, please enter a different Inspection Type name";

                return View(obj);
            }
            if (ModelState.IsValid)
            {
                int returnvalue = _repository.Save(obj);

                if (returnvalue > 0)
                {
                    TempData["msg"] = "Created successfully.";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    TempData["msg"] = "Creation failed.";
                    return RedirectToAction(nameof(Create));
                }

            }
            return View(obj);
        }

        
        [HttpGet]
        [Route("WaterMaster/WaterConnectionTypes/Edit")]
        public async Task<IActionResult> Edit(int? id)
        
        {
            if (id == null)
            {
                return NotFound();
            }
           
            var Data = await _repository.Details(id);
           
            if (Data == null)
            {
                return NotFound();
            }
            return View(Data);
        }

        [HttpPost]
       
        [Route("WaterMaster/WaterConnectionTypes/Edit")]
        public async Task<IActionResult> Edit(WaterConnectionTypesModel obj)
        {
            obj.ModifiedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            obj.ModifiedOn = Convert.ToDateTime(DateFunctions.getDatetypefrom(DateTime.Now.ToString("dd/MM/yyyy")));
            bool CheckDuplicate = _repository.DuplicateCheckOnUpdate(obj.WaterConnectionType, obj.WaterConnectionTypeId);
            if (CheckDuplicate)
            {
                TempData["msg"] = "Duplicate data found, please enter a different Inspection Type name";

                return View(obj);
            }
          
            var Data = await _repository.Details(obj.WaterConnectionTypeId);
            if (Data.WaterConnectionTypeId != obj.WaterConnectionTypeId)

          
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    int returnvalue = _repository.Update(obj);
                    if (returnvalue > 0)
                    {
                        TempData["msg"] = "Detail updated successfully.";
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        TempData["msg"] = "Error on updation.";
                        
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MstWaterConnectionTypesExists(obj.WaterConnectionTypeId))
                    {
                        TempData["msg"] = "Detail found.";
                        return RedirectToAction(nameof(Edit));
                        
                    }
                    else
                    {
                        throw;
                    }
                }

            }
            return View(obj);
        }

       
        [Route("WaterMaster/WaterConnectionTypes/Delete")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }


            var MstWaterConnectionType = await _repository.Details(id);

            if (MstWaterConnectionType == null)
            {
                return NotFound();
            }

            return View(MstWaterConnectionType);
        }

        

        [HttpPost, ActionName("Delete")]
        [Route(" WaterMaster/WaterConnectionTypes/Delete")]
        
        public async Task<IActionResult> DeleteConfirmed(WaterConnectionTypesModel obj)
        {
            await _repository.DeleteConfirmed(obj.WaterConnectionTypeId);
            
            return RedirectToAction(nameof(Index));
        }

        private bool MstWaterConnectionTypesExists(int id)
        {
            
            return _context.MstWaterConnectionType.Any(e => e.WaterConnectionTypeId == id);
        }
    }
}
