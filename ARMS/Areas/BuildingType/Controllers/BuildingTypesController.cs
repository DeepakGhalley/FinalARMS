using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CORE_BOL.Entities;
using CORE_DLL;
using CORE_BLL;
using CORE_BOL;
using Microsoft.AspNetCore.Http;
using ARMS.Functions;

namespace ARMS.Areas.BuildingType.Controllers
{
    [Area("BuildingType")]
    public class BuildingTypesController : Controller
    {
        private readonly tt_dbContext _context;
        readonly IBuildingType _repository = new BuildingTypeBLL();

        public BuildingTypesController(tt_dbContext context)
        {
            _context = context;
        }

        // GET: BuildingType/BuildingTypes
        [Route("BuildingType/BuildingTypes")]
        public async Task<IActionResult> Index()
        {
            _ = new List<BuildingTypeModel>();
            IList<BuildingTypeModel> obj = _repository.GetAll();
            return View(obj);
        }

        // GET: BuildingType/BuildingTypes/Details/5
        [Route("BuildingType/BuildingTypes/Details")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mstBuildingType = await _context.MstBuildingType
                .FirstOrDefaultAsync(m => m.BuildingTypeId == id);
            if (mstBuildingType == null)
            {
                return NotFound();
            }

            return View(mstBuildingType);
        }

        // GET: BuildingType/BuildingTypes/Create
        [Route("BuildingType/BuildingTypes/Create")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: BuildingType/BuildingTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("BuildingType/BuildingTypes/Create")]
        public async Task<IActionResult> Create(BuildingTypeModel obj)
        {
            obj.CreatedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            obj.CreatedDate = Convert.ToDateTime(DateFunctions.getDatetypefrom(DateTime.Now.ToString("dd/MM/yyyy")));
            bool CreateCheckDuplicate = _repository.DuplicateCheckOnSave(obj.BuildingType);
            if (CreateCheckDuplicate)
            {
                TempData["msg"] = "Duplicate data found, please find a different value";
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
                    TempData["msg"] = "New record creation failed";
                    return RedirectToAction(nameof(Create));
                }
            }
            return View(obj);
        }

        // GET: BuildingType/BuildingTypes/Edit/5
        [Route("BuildingType/BuildingTypes/Edit")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var mstBuildingType = await _context.MstBuildingType.FindAsync(id);
            var Data = await _repository.Details(id);
            if (Data == null)
            {
                return NotFound();
            }
            return View(Data);
        }

        // POST: BuildingType/BuildingTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("BuildingType/BuildingTypes/Edit")]
        public async Task<IActionResult> Edit(BuildingTypeModel obj)
        {
            obj.ModifiedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            obj.ModifiedDate = Convert.ToDateTime(DateFunctions.getDatetypefrom(DateTime.Now.ToString("dd/MM/yyyy")));
            bool CheckDuplicate = _repository.DuplicateCheckOnUpdate(obj.BuildingType, obj.BuildingTypeId);//checks duplicate user name
            if (CheckDuplicate)
            {
                TempData["msg"] = "Duplicate data found, please find a different value";
                return View(obj);
            }
            var Data = await _repository.Details(obj.BuildingTypeId);
            if (Data.BuildingTypeId != obj.BuildingTypeId)
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
                        // return RedirectToAction(nameof(Index));
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MstBuildingTypeExists(obj.BuildingTypeId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(obj);
        }

        // GET: BuildingType/BuildingTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mstBuildingType = await _context.MstBuildingType
                .FirstOrDefaultAsync(m => m.BuildingTypeId == id);
            if (mstBuildingType == null)
            {
                return NotFound();
            }

            return View(mstBuildingType);
        }

        // POST: BuildingType/BuildingTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mstBuildingType = await _context.MstBuildingType.FindAsync(id);
            _context.MstBuildingType.Remove(mstBuildingType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MstBuildingTypeExists(int id)
        {
            return _context.MstBuildingType.Any(e => e.BuildingTypeId == id);
        }
    }
}
