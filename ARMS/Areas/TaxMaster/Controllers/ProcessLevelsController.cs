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

namespace ARMS.Areas.TaxMaster.Controllers
{
    [Area("TaxMaster")]
    public class ProcessLevelsController : Controller
    {
        private readonly tt_dbContext _context;
        readonly IProcessLevel _repository = new ProcessLevelBLL();
        ICommonFunction _CommonRepo = new CommonFunctionBLL();

        public ProcessLevelsController(tt_dbContext context)
        {
            _context = context;
        }

        // GET: TaxMaster/ProcessLevels
        [Route("TaxMaster/ProcessLevels")]
        public async Task<IActionResult> Index()
        {
            _ = new List<ProcessLevelModel>();
            IList<ProcessLevelModel> obj = _repository.GetAll();
            return View(obj);
        }

        // GET: TaxMaster/ProcessLevels/Details/5
        [Route("TaxMaster/ProcessLevels/Details")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mstProcessLevel = await _context.MstProcessLevel
                .Include(m => m.TransactionType)
                .FirstOrDefaultAsync(m => m.ProcessLevelId == id);
            if (mstProcessLevel == null)
            {
                return NotFound();
            }

            return View(mstProcessLevel);
        }

        // GET: TaxMaster/ProcessLevels/Create
        [Route("TaxMaster/ProcessLevels/Create")]
        public IActionResult Create()
        {
            ViewData["TransactionTypeId"] = _CommonRepo.SelectListTransactionType();
            return View();
        }

        // POST: TaxMaster/ProcessLevels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("TaxMaster/ProcessLevels/Create")]
        public async Task<IActionResult> Create(ProcessLevelModel obj)
        {
            obj.CreatedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            obj.CreatedOn = Convert.ToDateTime(DateFunctions.getDatetypefrom(DateTime.Now.ToString("dd/MM/yyyy")));


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
            ViewData["TransactionTypeId"] = _CommonRepo.SelectListTransactionType();

            return View(obj);
        }

        // GET: TaxMaster/ProcessLevels/Edit/5
        [Route("TaxMaster/ProcessLevels/Edit")]
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
            ViewData["TransactionTypeId"] = _CommonRepo.SelectListTransactionType();
            return View(Data);
        }

        // POST: TaxMaster/ProcessLevels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("TaxMaster/ProcessLevels/Edit")]
        public async Task<IActionResult> Edit(ProcessLevelModel obj)
        {
            obj.ModifiedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            obj.ModifiedOn = Convert.ToDateTime(DateFunctions.getDatetypefrom(DateTime.Now.ToString("dd/MM/yyyy")));

            var Data = await _repository.Details(obj.ProcessLevelId);
            if (Data.ProcessLevelId != obj.ProcessLevelId)
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
                    if (!MstProcessLevelExists(obj.ProcessLevelId))
                    {
                        TempData["msg"] = "No record found.";
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            ViewData["TransactionTypeId"] = _CommonRepo.SelectListTransactionType();
            return View(obj);
        }

        // GET: TaxMaster/ProcessLevels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mstProcessLevel = await _context.MstProcessLevel
                .Include(m => m.TransactionType)
                .FirstOrDefaultAsync(m => m.ProcessLevelId == id);
            if (mstProcessLevel == null)
            {
                return NotFound();
            }

            return View(mstProcessLevel);
        }

        // POST: TaxMaster/ProcessLevels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mstProcessLevel = await _context.MstProcessLevel.FindAsync(id);
            _context.MstProcessLevel.Remove(mstProcessLevel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MstProcessLevelExists(int id)
        {
            return _context.MstProcessLevel.Any(e => e.ProcessLevelId == id);
        }
    }
}
