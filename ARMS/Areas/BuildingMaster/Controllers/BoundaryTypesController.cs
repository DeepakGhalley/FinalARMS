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
namespace ARMS.Areas.BuildingMaster.Controllers
{
    [Area("BuildingMaster")]
    public class BoundaryTypesController : Controller
    {
        private readonly tt_dbContext _context;

        private readonly IMapper _mapper;
        ICommonFunction _CommonRepo = new CommonFunctionBLL();

        readonly IBoundaryType _repository = new BoundaryTypeBLL();
        public BoundaryTypesController(tt_dbContext context, IMapper mapper)
        {
            _context = context; _mapper = mapper;

        }

        [Route("BuildingMaster/BoundaryTypes")]
        public async Task<IActionResult> Index()
        {
            _ = new List<BoundaryTypeModel>();
            IList<BoundaryTypeModel> obj = _repository.GetAll();

            return View(obj);
        }

        [Route("BUildingMaster/BoundaryTypes/Details")]
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
        [Route("BuildingMaster/BoundaryTypes/Create")]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [Route("BuildingMaster/BoundaryTypes/Create")]
        public async Task<IActionResult> Create(BoundaryTypeModel obj)
        {
            obj.CreatedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            obj.CreatedOn = Convert.ToDateTime(DateFunctions.getDatetypefrom(DateTime.Now.ToString("dd/MM/yyyy")));
            bool CreateCheckDuplicate = _repository.DuplicateCheckOnSave(obj.BoundaryType);
            if (CreateCheckDuplicate)
            {
                TempData["msg"] = "Duplicate data found, please enter a different  name";

                return View(obj);
            }
            if (ModelState.IsValid)
            {
                int returnvalue = _repository.Save(obj);

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
        [Route("BuildingMaster/BoundaryTypes/Edit")]
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
        [Route("BuildingMaster/BoundaryTypes/Edit")]
        public async Task<IActionResult> Edit(BoundaryTypeModel obj)
        {
            obj.ModifiedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            obj.ModifiedOn = Convert.ToDateTime(DateFunctions.getDatetypefrom(DateTime.Now.ToString("dd/MM/yyyy")));

            bool CheckDuplicate = _repository.DuplicateCheckOnUpdate(obj.BoundaryType, obj.BoundaryTypeId);
            if (CheckDuplicate)
            {
                TempData["msg"] = "Duplicate data found, please enter a different name";

                return View(obj);
            }
            var Data = await _repository.Details(obj.BoundaryTypeId);
            if (Data.BoundaryTypeId != obj.BoundaryTypeId)

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
                    if (!MstBoundaryTypeExists(obj.BoundaryTypeId))
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



        [Route("BuildingMaster/BoundaryTypes/Delete")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var MstBoundaryType = await _repository.Details(id);

            if (MstBoundaryType == null)
            {
                return NotFound();
            }

            return View(MstBoundaryType);
        }

        [HttpPost, ActionName("Delete")]
        [Route("BuildingMaster/BoundaryTypes/Delete")]
        public async Task<IActionResult> DeleteConfirmed(BoundaryTypeModel obj)
        {
            await _repository.DeleteConfirmed(obj.BoundaryTypeId);

            return RedirectToAction(nameof(Index));
        }

        private bool MstBoundaryTypeExists(int id)
        {
            return _context.MstBoundaryType.Any(e => e.BoundaryTypeId == id);
        }
    }
}
