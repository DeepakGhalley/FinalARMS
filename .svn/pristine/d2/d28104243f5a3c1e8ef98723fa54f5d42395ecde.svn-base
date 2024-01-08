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
    public class WaterLineTypesController : Controller
    {
        private readonly tt_dbContext _context;

        private readonly IMapper _mapper;
        ICommonFunction _CommonRepo = new CommonFunctionBLL();

        readonly IWaterLineTypes _repository = new WaterLineTypesBLL();
        public WaterLineTypesController(tt_dbContext context, IMapper mapper)
        {
            _context = context; _mapper = mapper;

        }

       
        [Route("WaterMaster/WaterLineTypes")]
        public async Task<IActionResult> Index()
        {
            _ = new List<WaterLineTypesModel>();
            IList<WaterLineTypesModel> obj = _repository.GetAll();

            return View(obj);
        }

        [Route("WaterMaster/WaterLineTypes/Details")]
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
        [Route("WaterMaster/WaterLineTypes/Create")]
        public IActionResult Create()
        {
            return View();
        }
       
        [HttpPost]
        [Route("WaterMaster/WaterLineTypes/Create")]
        public async Task<IActionResult> Create(WaterLineTypesModel obj)
        {
            obj.CreatedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            obj.CreatedOn = Convert.ToDateTime(DateFunctions.getDatetypefrom(DateTime.Now.ToString("dd/MM/yyyy")));
            bool CreateCheckDuplicate = _repository.DuplicateCheckOnSave(obj.WaterLineType);
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
        [Route("WaterMaster/WaterLineTypes/Edit")]
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
        
        [Route("WaterMaster/WaterLineTypes/Edit")]
        public async Task<IActionResult> Edit(WaterLineTypesModel obj)
        {
            obj.ModifiedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            obj.ModifiedOn = Convert.ToDateTime(DateFunctions.getDatetypefrom(DateTime.Now.ToString("dd/MM/yyyy")));
            bool CheckDuplicate = _repository.DuplicateCheckOnUpdate(obj.WaterLineType, obj.WaterLineTypeId);
            if (CheckDuplicate)
            {
                TempData["msg"] = "Duplicate data found, please enter a different Inspection Type name";

                return View(obj);
            }
            var Data = await _repository.Details(obj.WaterLineTypeId);
            if (Data.WaterLineTypeId != obj.WaterLineTypeId)

            
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
                        TempData["msg"] = "Updated successfully.";
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        TempData["msg"] = "Error on updation.";
                        
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MstWaterLineTypesExists(obj.WaterLineTypeId))
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

       
        [Route("WaterMaster/WaterLineTypes/Delete")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }


            var MstWaterLineType = await _repository.Details(id);

            if (MstWaterLineType == null)
            {
                return NotFound();
            }

            return View(MstWaterLineType);
        }

        

        [HttpPost, ActionName("Delete")]
        [Route(" WaterMaster/WaterLineTypes/Delete")]
        
        public async Task<IActionResult> DeleteConfirmed(WaterLineTypesModel obj)
        {
            await _repository.DeleteConfirmed(obj.WaterLineTypeId);
            
            return RedirectToAction(nameof(Index));
        }

        private bool MstWaterLineTypesExists(int id)
        {
           
            return _context.MstWaterLineType.Any(e => e.WaterLineTypeId == id);
        }
    }
}
