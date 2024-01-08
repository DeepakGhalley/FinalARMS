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

namespace ARMS.Areas.BuildingUnitClass.Controllers
{
    [Area("BuildingUnitClass")]
    public class BuildingUnitClassesController : Controller
    {
        private readonly tt_dbContext _context;
        readonly IBuildingUnitClass _repository = new BuildingUnitClassBLL();

        public BuildingUnitClassesController(tt_dbContext context)
        {
            _context = context;
        }

        // GET: BuildingUnitClass/BuildingUnitClasses
        [Route("BuildingUnitClass/BuildingUnitClasses")]
        public async Task<IActionResult> Index()
        {
            _ = new List<BuildingUnitClassModel>();
            IList<BuildingUnitClassModel> obj = _repository.GetAll();
            return View(obj);
        }

        // GET: BuildingUnitClass/BuildingUnitClasses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mstBuildingUnitClass = await _context.MstBuildingUnitClass
                .FirstOrDefaultAsync(m => m.BuildingUnitClassId == id);
            if (mstBuildingUnitClass == null)
            {
                return NotFound();
            }

            return View(mstBuildingUnitClass);
        }

        // GET: BuildingUnitClass/BuildingUnitClasses/Create
        [Route("BuildingUnitClass/BuildingUnitClasses/Create")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: BuildingUnitClass/BuildingUnitClasses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("BuildingUnitClass/BuildingUnitClasses/Create")]
        public async Task<IActionResult> Create(BuildingUnitClassModel obj)
        {
            obj.CreatedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            obj.CreatedDate = DateTime.Now;
            bool CreateCheckDuplicate = _repository.DuplicateCheckOnSave(obj.BuildingUnitClassName);
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

        // GET: BuildingUnitClass/BuildingUnitClasses/Edit/5
        [Route("BuildingUnitClass/BuildingUnitClasses/Edit")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // var mstBuildingUnitClass = await _context.MstBuildingUnitClass.FindAsync(id);
            var Data = await _repository.Details(id);
            if (Data == null)
            {
                return NotFound();
            }
            return View(Data);
        }

        // POST: BuildingUnitClass/BuildingUnitClasses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("BuildingUnitClass/BuildingUnitClasses/Edit")]
        public async Task<IActionResult> Edit(BuildingUnitClassModel obj)
        {
            obj.ModifiedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            obj.ModifiedDate = DateTime.Now;
            bool CheckDuplicate = _repository.DuplicateCheckOnUpdate(obj.BuildingUnitClassName, obj.BuildingUnitClassId);//checks duplicate user name
            if (CheckDuplicate)
            {
                TempData["msg"] = "Duplicate data found, please find a different value";
                return View(obj);
            }
            var Data = await _repository.Details(obj.BuildingUnitClassId);
            if (Data.BuildingUnitClassId != obj.BuildingUnitClassId)
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
                        TempData["msg"] = "Error while updating.";
                        // return RedirectToAction(nameof(Index));
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MstBuildingUnitClassExists(obj.BuildingUnitClassId))
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

        // GET: BuildingUnitClass/BuildingUnitClasses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mstBuildingUnitClass = await _context.MstBuildingUnitClass
                .FirstOrDefaultAsync(m => m.BuildingUnitClassId == id);
            if (mstBuildingUnitClass == null)
            {
                return NotFound();
            }

            return View(mstBuildingUnitClass);
        }

        // POST: BuildingUnitClass/BuildingUnitClasses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mstBuildingUnitClass = await _context.MstBuildingUnitClass.FindAsync(id);
            _context.MstBuildingUnitClass.Remove(mstBuildingUnitClass);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MstBuildingUnitClassExists(int id)
        {
            return _context.MstBuildingUnitClass.Any(e => e.BuildingUnitClassId == id);
        }
    }
}
