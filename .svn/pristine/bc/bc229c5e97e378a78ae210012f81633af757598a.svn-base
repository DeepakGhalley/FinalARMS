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
    [Area("Location")]
    public class AreasController : Controller
    {
        private readonly tt_dbContext _context;

        private readonly IMapper _mapper;
        ICommonFunction _CommonRepo = new CommonFunctionBLL();

        readonly IArea _repository = new AreaBLL();
        public AreasController(tt_dbContext context, IMapper mapper)
        {
            _context = context; _mapper = mapper;

        }

        [Route("Location/Areas")]
        public async Task<IActionResult> Index()
        {
            _ = new List<AreaModel>();
            IList<AreaModel> obj = _repository.GetAll();

            return View(obj);
        }

        [Route("Location/Areas/Details")]
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
        [Route("Location/Areas/Create")]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [Route("Location/Areas/Create")]
        public async Task<IActionResult> Create(AreaModel obj)
        {
            obj.CreatedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            obj.CreatedOn = DateTime.Now;
            bool CreateCheckDuplicate = _repository.DuplicateCheckOnSave(obj.AreaName);
            if (CreateCheckDuplicate)
            {
                TempData["msg"] = "Duplicate data found, please enter a different Area name";
              
                return View(obj);
            }
            if (ModelState.IsValid)
            {
                int returnvalue = _repository.SaveArea(obj);

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
        [Route("Location/Areas/Edit")]
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
        [Route("Location/Areas/Edit")]
        public async Task<IActionResult> Edit(AreaModel obj)
        {
            obj.ModifiedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            obj.ModifiedOn = Convert.ToDateTime(DateFunctions.getDatetypefrom(DateTime.Now.ToString("dd/MM/yyyy")));

            bool CheckDuplicate = _repository.DuplicateCheckOnUpdate(obj.AreaName, obj.AreaId);
            if (CheckDuplicate)
            {
                TempData["msg"] = "Duplicate data found, please enter a different Area name";
              
                return View(obj);
            }
            var Data = await _repository.Details(obj.AreaId);
            if (Data.AreaId != obj.AreaId)

            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    int returnvalue = _repository.UpdateArea(obj);
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
                    if (!MstAreaExists(obj.AreaId))
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

        [Route("Location/Areas/Delete")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var MstArea = await _repository.Details(id);

            if (MstArea == null)
            {
                return NotFound();
            }

            return View(MstArea);
        }

        [HttpPost, ActionName("Delete")]
        [Route("Location/Areas/Delete")]
        public async Task<IActionResult> DeleteConfirmed(AreaModel obj)
        {
            await _repository.DeleteConfirmed(obj.AreaId);
            
            return RedirectToAction(nameof(Index));
        }

        private bool MstAreaExists(int id)
        {
            return _context.MstArea.Any(e => e.AreaId == id);
        }
    }
}
