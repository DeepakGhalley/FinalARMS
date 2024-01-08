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
using ARMS.Functions;
using Microsoft.AspNetCore.Http;

namespace ARMS.Areas.Occupation.Controllers
{
    [Area("Occupation")]
    public class OccupationsController : Controller
    {

        private readonly tt_dbContext _context;
        readonly IOccupation _repository = new OccupationBLL();

        public OccupationsController(tt_dbContext context)
        {
            _context = context;
        }

        // GET: Occupation/Occupations
        [Route("Occupation/Occupations")]
        public async Task<IActionResult> Index()
        {
            _ = new List<OccupationVM>();
            IList<OccupationVM> obj = _repository.GetAll();
            return View(obj);
        }

        // GET: Occupation/Occupations/Details/5
        [Route("Occupation/Occupations/Details")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mstOccupation = await _context.MstOccupation
                .FirstOrDefaultAsync(m => m.OccupationId == id);
            if (mstOccupation == null)
            {
                return NotFound();
            }

            return View(mstOccupation);
        }

        // GET: Occupation/Occupations/Create
        [Route("Occupation/Occupations/Create")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Occupation/Occupations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Occupation/Occupations/Create")]
        public async Task<IActionResult> Create(OccupationVM obj)
        {
            obj.CreatedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            obj.CreatedOn = DateTime.Now;

            bool CreateCheckDuplicate = _repository.DuplicateCheckOnSave(obj.Occupation);
            if (CreateCheckDuplicate)
            {
                TempData["msg"] = "Duplicate data found, please enter a different value";
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

        // GET: Occupation/Occupations/Edit/5
        [Route("Occupation/Occupations/Edit")]
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

        // POST: Occupation/Occupations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Occupation/Occupations/Edit")]
        public async Task<IActionResult> Edit(OccupationVM obj)
        {
            obj.ModifiedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            obj.ModifiedOn = DateTime.Now;

            bool CheckDuplicate = _repository.DuplicateCheckOnUpdate(obj.Occupation, obj.OccupationId);
            if (CheckDuplicate)
            {
                TempData["msg"] = "Duplicate data found, please enter a different value";
                return View(obj);
            }

            var Data = await _repository.Details(obj.OccupationId);
            if (Data.OccupationId != obj.OccupationId)
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
                    if (!MstOccupationExists(obj.OccupationId))
                    {
                        TempData["msg"] = "No record found.";
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

        // GET: Occupation/Occupations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mstOccupation = await _context.MstOccupation
                .FirstOrDefaultAsync(m => m.OccupationId == id);
            if (mstOccupation == null)
            {
                return NotFound();
            }

            return View(mstOccupation);
        }

        // POST: Occupation/Occupations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mstOccupation = await _context.MstOccupation.FindAsync(id);
            _context.MstOccupation.Remove(mstOccupation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MstOccupationExists(int id)
        {
            return _context.MstOccupation.Any(e => e.OccupationId == id);
        }
    }
}
