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
namespace ARMS.Areas.BuildingUnit.Controllers
{
    [Area("BuildingUnit")]
    public class FloorNamesController : Controller
    {
        private readonly tt_dbContext _context;

        private readonly IMapper _mapper;
        ICommonFunction _CommonRepo = new CommonFunctionBLL();

        readonly IFloorName _repository = new FloorNameBLL();
        public FloorNamesController(tt_dbContext context, IMapper mapper)
        {
            _context = context; _mapper = mapper;

        }

        [Route("BuildingUnit/FloorNames")]
        public async Task<IActionResult> Index()
        {
            _ = new List<FloorNameModel>();
            IList<FloorNameModel> obj = _repository.GetAll();

            return View(obj);
        }

        [Route("BuildingUnit/FloorNames/Details")]
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
        [Route("BuildingUnit/FloorNames/Create")]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [Route("BuildingUnit/FloorNames/Create")]
        public async Task<IActionResult> Create(FloorNameModel obj)
        {
            obj.CreatedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            obj.CreatedOn = DateTime.Now;
            bool CreateCheckDuplicate = _repository.DuplicateCheckOnSave(obj.FloorName);
            if (CreateCheckDuplicate)
            {
                TempData["msg"] = "Duplicate data found, please enter a different Floor name";
              
                return View(obj);
            }
            if (ModelState.IsValid)
            {
                int returnvalue = _repository.SaveFloorName(obj);

                if (returnvalue > 0)
                {
                    TempData["msg"] = "New record created successfully";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    TempData["msg"] = " New record creation failed";
                    return RedirectToAction(nameof(Create));
                }

            }
            return View(obj);
        }

        [HttpGet]
        [Route("BuildingUnit/FloorNames/Edit")]
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
        [Route("BuildingUnit/FloorNames/Edit")]
        public async Task<IActionResult> Edit(FloorNameModel obj)
        {
            obj.ModifiedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            obj.ModifiedOn = Convert.ToDateTime(DateFunctions.getDatetypefrom(DateTime.Now.ToString("dd/MM/yyyy")));

            bool CheckDuplicate = _repository.DuplicateCheckOnUpdate(obj.FloorName, obj.FloorNameId);
            if (CheckDuplicate)
            {
                TempData["msg"] = "Duplicate data found, please enter a different Floor name";
              
                return View(obj);
            }
            var Data = await _repository.Details(obj.FloorNameId);
            if (Data.FloorNameId != obj.FloorNameId)

            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    int returnvalue = _repository.UpdateFloorName(obj);
                    if (returnvalue > 0)
                    {
                        TempData["msg"] = "Record updated successfully";
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        TempData["msg"] = "Error while updating";
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MstFloorNameExists(obj.FloorNameId))
                    {
                        TempData["msg"] = "No record found";
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

        [Route("BuildingUnit/FloorNames/Delete")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var MstFloorName = await _repository.Details(id);

            if (MstFloorName == null)
            {
                return NotFound();
            }

            return View(MstFloorName);
        }

        [HttpPost, ActionName("Delete")]
        [Route("BuildingUnit/FloorNames/Delete")]
        public async Task<IActionResult> DeleteConfirmed(FloorNameModel obj)
        {
            await _repository.DeleteConfirmed(obj.FloorNameId);
            
            return RedirectToAction(nameof(Index));
        }

        private bool MstFloorNameExists(int id)
        {
            return _context.MstArea.Any(e => e.AreaId == id);
        }
    }
}
