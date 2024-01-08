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

namespace ARMS.Areas.ConditionRating.Controllers
{
    [Area("ConditionRating")]
    public class ConditionRatingsController : Controller
    {
        private readonly tt_dbContext _context;

        readonly IConditionRating _repository = new ConditionRatingBLL();

        public ConditionRatingsController(tt_dbContext context)
        {
            _context = context;
        }

        // GET: ConditionRating/ConditionRatings
        [Route("ConditionRating/ConditionRatings")]
        public async Task<IActionResult> Index()
        {
            _ = new List<ConditionRatingVM>();
            IList<ConditionRatingVM> obj = _repository.GetAll();
            return View(obj);
        }

        // GET: ConditionRating/ConditionRatings/Details/5
        [Route("ConditionRating/ConditionRatings/Details")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mstConditionRating = await _context.MstConditionRating
                .FirstOrDefaultAsync(m => m.ConditionRatingId == id);
            if (mstConditionRating == null)
            {
                return NotFound();
            }

            return View(mstConditionRating);
        }

        // GET: ConditionRating/ConditionRatings/Create
        [Route("ConditionRating/ConditionRatings/Create")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: ConditionRating/ConditionRatings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("ConditionRating/ConditionRatings/Create")]
        public async Task<IActionResult> Create(ConditionRatingVM obj)
        {
            obj.CreatedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            obj.CreatedOn = Convert.ToDateTime(DateFunctions.getDatetypefrom(DateTime.Now.ToString("dd/MM/yyyy")));
            
            bool CreateCheckDuplicate = _repository.DuplicateCheckOnSave(obj.ConditionRating);
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

        // GET: ConditionRating/ConditionRatings/Edit/5
        [Route("ConditionRating/ConditionRatings/Edit")]
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

        // POST: ConditionRating/ConditionRatings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("ConditionRating/ConditionRatings/Edit")]
        public async Task<IActionResult> Edit(ConditionRatingVM obj)
        {
            obj.ModifiedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            obj.ModifiedOn = Convert.ToDateTime(DateFunctions.getDatetypefrom(DateTime.Now.ToString("dd/MM/yyyy")));

            bool CheckDuplicate = _repository.DuplicateCheckOnUpdate(obj.ConditionRating, obj.ConditionRatingId);
            if (CheckDuplicate)
            {
                TempData["msg"] = "Duplicate data found, please enter a different value";
                return View(obj);
            }

            var Data = await _repository.Details(obj.ConditionRatingId);
            if (Data.ConditionRatingId != obj.ConditionRatingId)
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
                    if (!MstConditionRatingExists(obj.ConditionRatingId))
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

        // GET: ConditionRating/ConditionRatings/Delete/5
        [Route("ConditionRating/ConditionRatings/Delete")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mstConditionRating = await _context.MstConditionRating
                .FirstOrDefaultAsync(m => m.ConditionRatingId == id);
            if (mstConditionRating == null)
            {
                return NotFound();
            }

            return View(mstConditionRating);
        }

        // POST: ConditionRating/ConditionRatings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mstConditionRating = await _context.MstConditionRating.FindAsync(id);
            _context.MstConditionRating.Remove(mstConditionRating);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MstConditionRatingExists(int id)
        {
            return _context.MstConditionRating.Any(e => e.ConditionRatingId == id);
        }
    }
}
