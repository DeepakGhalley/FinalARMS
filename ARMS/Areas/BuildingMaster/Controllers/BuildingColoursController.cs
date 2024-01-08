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
    public class BuildingColoursController : Controller
    {
        private readonly tt_dbContext _context;

        private readonly IMapper _mapper;
        ICommonFunction _CommonRepo = new CommonFunctionBLL();

        readonly IBuildingColor _repository = new BuldingColorBLL();
        public BuildingColoursController(tt_dbContext context, IMapper mapper)
        {
            _context = context; _mapper = mapper;

        }

        [Route("BuildingMaster/BuildingColours")]
        public async Task<IActionResult> Index()
        {
            _ = new List<BuildingColourModel>();
            IList<BuildingColourModel> obj = _repository.GetAll();

            return View(obj);
        }

        [Route("BUildingMaster/BuildingColours/Details")]
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
        [Route("BuildingMaster/BuildingColours/Create")]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [Route("BuildingMaster/BuildingColours/Create")]
        public async Task<IActionResult> Create(BuildingColourModel obj)
        {
            obj.CreatedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            obj.CreatedOn = Convert.ToDateTime(DateFunctions.getDatetypefrom(DateTime.Now.ToString("dd/MM/yyyy")));
            bool CreateCheckDuplicate = _repository.DuplicateCheckOnSave(obj.BuildingColourType);
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
        [Route("BuildingMaster/BuildingColours/Edit")]
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
        [Route("BuildingMaster/BuildingColours/Edit")]
        public async Task<IActionResult> Edit(BuildingColourModel obj)
        {
            obj.ModifiedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            obj.ModifiedOn = Convert.ToDateTime(DateFunctions.getDatetypefrom(DateTime.Now.ToString("dd/MM/yyyy")));

            bool CheckDuplicate = _repository.DuplicateCheckOnUpdate(obj.BuildingColourType, obj.BuildingColourId);
            if (CheckDuplicate)
            {
                TempData["msg"] = "Duplicate data found, please enter a differentame";

                return View(obj);
            }
            var Data = await _repository.Details(obj.BuildingColourId);
            if (Data.BuildingColourId != obj.BuildingColourId)

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
                    if (!MstBuildingColorExists(obj.BuildingColourId))
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



        [Route("BuildingMaster/BuildingColours/Delete")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var MstBuildingColour = await _repository.Details(id);

            if (MstBuildingColour == null)
            {
                return NotFound();
            }

            return View(MstBuildingColour);
        }

        [HttpPost, ActionName("Delete")]
        [Route("BuildingMaster/BuildingColours/Delete")]
        public async Task<IActionResult> DeleteConfirmed(BuildingColourModel obj)
        {
            await _repository.DeleteConfirmed(obj.BuildingColourId);

            return RedirectToAction(nameof(Index));
        }

        private bool MstBuildingColorExists(int id)
        {
            return _context.MstBuildingColour.Any(e => e.BuildingColourId == id);
        }
    }
}
