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

namespace ARMS.Areas.TaxMaster.Controllers
{
    [Area("TaxMaster")]
    public class TaxTypeClassificationsController : Controller
    {
        private readonly tt_dbContext _context;
        readonly ITaxTypeClassification _repository = new TaxTypeClassificationBLL();

        public TaxTypeClassificationsController(tt_dbContext context)
        {
            _context = context;
        }

        // GET: TaxMaster/TaxTypeClassifications
        [Route("TaxMaster/TaxTypeClassifications")]
        public async Task<IActionResult> Index()
        {
            _ = new List<TaxTypeClassificationVM>();
            IList<TaxTypeClassificationVM> obj = _repository.GetAll();
            return View(obj);
        }

        // GET: TaxMaster/TaxTypeClassifications/Details/5
        [Route("TaxMaster/TaxTypeClassifications/Details")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mstTaxTypeClassification = await _context.MstTaxTypeClassification
                .FirstOrDefaultAsync(m => m.TaxTypeClassificationId == id);
            if (mstTaxTypeClassification == null)
            {
                return NotFound();
            }

            return View(mstTaxTypeClassification);
        }

        // GET: TaxMaster/TaxTypeClassifications/Create
        [Route("TaxMaster/TaxTypeClassifications/Create")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: TaxMaster/TaxTypeClassifications/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("TaxMaster/TaxTypeClassifications/Create")]
        public async Task<IActionResult> Create(TaxTypeClassificationVM obj)
        {
            obj.CreatedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            obj.CreatedOn = Convert.ToDateTime(DateFunctions.getDatetypefrom(DateTime.Now.ToString("dd/MM/yyyy")));

            bool CreateCheckDuplicate = _repository.DuplicateCheckOnSave(obj.TaxTypeClassification);
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

        // GET: TaxMaster/TaxTypeClassifications/Edit/5
        [Route("TaxMaster/TaxTypeClassifications/Edit")]
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

        // POST: TaxMaster/TaxTypeClassifications/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("TaxMaster/TaxTypeClassifications/Edit")]
        public async Task<IActionResult> Edit(TaxTypeClassificationVM obj)
        {
            obj.ModifiedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            obj.ModifiedOn = Convert.ToDateTime(DateFunctions.getDatetypefrom(DateTime.Now.ToString("dd/MM/yyyy")));

            bool CheckDuplicate = _repository.DuplicateCheckOnUpdate(obj.TaxTypeClassification, obj.TaxTypeClassificationId);
            if (CheckDuplicate)
            {
                TempData["msg"] = "Duplicate data found, please enter a different value";
                return View(obj);
            }

            var Data = await _repository.Details(obj.TaxTypeClassificationId);
            if (Data.TaxTypeClassificationId != obj.TaxTypeClassificationId)
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
                    if (!MstTaxTypeClassificationExists(obj.TaxTypeClassificationId))
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

        // GET: TaxMaster/TaxTypeClassifications/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mstTaxTypeClassification = await _context.MstTaxTypeClassification
                .FirstOrDefaultAsync(m => m.TaxTypeClassificationId == id);
            if (mstTaxTypeClassification == null)
            {
                return NotFound();
            }

            return View(mstTaxTypeClassification);
        }

        // POST: TaxMaster/TaxTypeClassifications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mstTaxTypeClassification = await _context.MstTaxTypeClassification.FindAsync(id);
            _context.MstTaxTypeClassification.Remove(mstTaxTypeClassification);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MstTaxTypeClassificationExists(int id)
        {
            return _context.MstTaxTypeClassification.Any(e => e.TaxTypeClassificationId == id);
        }
    }
}
