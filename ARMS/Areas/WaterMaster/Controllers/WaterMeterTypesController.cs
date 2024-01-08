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
    public class WaterMeterTypesController : Controller
    {
        private readonly tt_dbContext _context;

        private readonly IMapper _mapper;
        ICommonFunction _CommonRepo = new CommonFunctionBLL();

        readonly IwaterMeterType _repository = new WaterMeterTypesBLL();
        public WaterMeterTypesController(tt_dbContext context, IMapper mapper)
        {
            _context = context; _mapper = mapper;

        }

        
        [Route("WaterMaster/WaterMeterTypes")]
        public async Task<IActionResult> Index()
        {
            _ = new List<WaterMeterTypesModel>();
            IList<WaterMeterTypesModel> obj = _repository.GetAll();

            return View(obj);
        }

        [Route("WaterMaster/WaterMeterTypes/Details")]
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
        [Route("WaterMaster/WaterMeterTypes/Create")]
        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        
        [Route("WaterMaster/WaterMeterTypes/Create")]
        public async Task<IActionResult> Create(WaterMeterTypesModel obj)
        {
            obj.CreatedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            obj.CreatedOn = Convert.ToDateTime(DateFunctions.getDatetypefrom(DateTime.Now.ToString("dd/MM/yyyy")));
            bool CreateCheckDuplicate = _repository.DuplicateCheckOnSave(obj.WaterMeterType);
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
        [Route("WaterMaster/WaterMeterTypes/Edit")]
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
        
        [Route("WaterMaster/WaterMeterTypes/Edit")]
        public async Task<IActionResult> Edit(WaterMeterTypesModel obj)
        {
            obj.ModifiedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            obj.ModifiedOn = Convert.ToDateTime(DateFunctions.getDatetypefrom(DateTime.Now.ToString("dd/MM/yyyy")));
            bool CheckDuplicate = _repository.DuplicateCheckOnUpdate(obj.WaterMeterType, obj.WaterMeterTypeId);
            if (CheckDuplicate)
            {
                TempData["msg"] = "Duplicate data found, please enter a different Inspection Type name";

                return View(obj);
            }
            var Data = await _repository.Details(obj.WaterMeterTypeId);
            if (Data.WaterMeterTypeId != obj.WaterMeterTypeId)

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
                    if (!MstWaterMeterTypesExists(obj.WaterMeterTypeId))
                    {
                        TempData["msg"] = "No user detail found.";
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

        [Route("WaterMaster/WaterMeterTypes/Delete")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }


            var MstWaterMeterType = await _repository.Details(id);

            if (MstWaterMeterType == null)
            {
                return NotFound();
            }

            return View(MstWaterMeterType);
        }

      

        [HttpPost, ActionName("Delete")]
        [Route(" WaterMaster/WaterMeterTypes/Delete")]
        
        public async Task<IActionResult> DeleteConfirmed(WaterMeterTypesModel obj)
        {
            await _repository.DeleteConfirmed(obj.WaterMeterTypeId);
           
            return RedirectToAction(nameof(Index));
        }

        private bool MstWaterMeterTypesExists(int id)
        {
            
            return _context.MstWaterMeterType.Any(e => e.WaterMeterTypeId == id);
        }
    }
}
