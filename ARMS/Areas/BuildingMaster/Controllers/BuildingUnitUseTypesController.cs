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
    public class BuildingUnitUseTypesController : Controller
    {
        private readonly tt_dbContext _context;

        private readonly IMapper _mapper;
        ICommonFunction _CommonRepo = new CommonFunctionBLL();

        readonly IBuildingUnitUseType _repository = new BuildingUnitUseTypeBLL();
        public BuildingUnitUseTypesController(tt_dbContext context, IMapper mapper)
        {
            _context = context; _mapper = mapper;

        }

        [Route("BuildingMaster/BuildingUnitUseTypes")]
        public async Task<IActionResult> Index()
        {
            _ = new List<BuildingUnitUseTypeModel>();
            IList<BuildingUnitUseTypeModel> obj = _repository.GetAll();

            return View(obj);
        }

        [Route("BuildingMaster/BuildingUnitUseTypes/Details")]
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
        [Route("BuildingMaster/BuildingUnitUseTypes/Create")]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [Route("BuildingMaster/BuildingUnitUseTypes/Create")]
        public async Task<IActionResult> Create(BuildingUnitUseTypeModel obj)
        {
            obj.CreatedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            obj.CreatedOn = DateTime.Now;
            bool CreateCheckDuplicate = _repository.DuplicateCheckOnSave(obj.BuildingUnitUseType);
            if (CreateCheckDuplicate)
            {
                TempData["msg"] = "Duplicate data found, please enter a different Building Unit Use Type";

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
        [Route("BuildingMaster/BuildingUnitUseTypes/Edit")]
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
        [Route("BuildingMaster/BuildingUnitUseTypes/Edit")]
        public async Task<IActionResult> Edit(BuildingUnitUseTypeModel obj)
        {
            obj.ModifiedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            obj.ModifiedOn = Convert.ToDateTime(DateFunctions.getDatetypefrom(DateTime.Now.ToString("dd/MM/yyyy")));

            bool CheckDuplicate = _repository.DuplicateCheckOnUpdate(obj.BuildingUnitUseType, obj.BuildingUnitUseTypeId);
            if (CheckDuplicate)
            {
                TempData["msg"] = "Duplicate data found, please enter a different Building Unit Use Type";

                return View(obj);
            }
            var Data = await _repository.Details(obj.BuildingUnitUseTypeId);
            if (Data.BuildingUnitUseTypeId != obj.BuildingUnitUseTypeId)

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
                    if (!MstBuildingUnitUseTypeExists(obj.BuildingUnitUseTypeId))
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

        [Route("BuildingMaster/BuildingUnitUseTypes/Delete")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var MstBuildingUnitUseType = await _repository.Details(id);

            if (MstBuildingUnitUseType == null)
            {
                return NotFound();
            }

            return View(MstBuildingUnitUseType);
        }

        [HttpPost, ActionName("Delete")]
        [Route("BuildingMaster/BuildingUnitUseTypes/Delete")]
        public async Task<IActionResult> DeleteConfirmed(BuildingUnitUseTypeModel obj)
        {
            await _repository.DeleteConfirmed(obj.BuildingUnitUseTypeId);

            return RedirectToAction(nameof(Index));
        }

        private bool MstBuildingUnitUseTypeExists(int id)
        {
            return _context.MstBuildingUnitUseType.Any(e => e.BuildingUnitUseTypeId == id);
        }
    }
}
