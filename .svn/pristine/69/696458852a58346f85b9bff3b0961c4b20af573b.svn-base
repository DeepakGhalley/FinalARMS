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

namespace ARMS.Areas.Mannualreceipt.Controllers
{
    [Area("Mannualreceipt")]
    public class MannualreceiptsController : Controller
    {
        private readonly tt_dbContext _context;
        readonly IMannualreceipt _repository = new MannualreceiptBLL();

        public MannualreceiptsController(tt_dbContext context)
        {
            _context = context;
        }

       
        [Route("Mannualreceipt/Mannualreceipts")]
        public async Task<IActionResult> Index()
        {
            _ = new List<ManualReceiptVM>();
            IList<ManualReceiptVM> obj = _repository.GetAll();
            return View(obj);
        }

       
        [Route("Mannualreceipt/Mannualreceipts/Details")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblmannualreceipt = await _context.TblManualReceipt
                .FirstOrDefaultAsync(m => m.ManualReceiptId == id);
            if (tblmannualreceipt == null)
            {
                return NotFound();
            }

            return View(tblmannualreceipt);
        }

       
        [Route("Mannualreceipt/Mannualreceipts/Create")]
        public IActionResult Create()
        {
            return View();
        }

    
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Mannualreceipt/Mannualreceipts/Create")]
        public async Task<IActionResult> Create(ManualReceiptVM obj)
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
            return View(obj);
        }

        [Route("Mannualreceipt/Mannualreceipts/Edit")]
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

        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Mannualreceipt/Mannualreceipts/Edit")]
        public async Task<IActionResult> Edit(ManualReceiptVM obj)
        {
            obj.ModifiedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            obj.ModifiedOn = Convert.ToDateTime(DateFunctions.getDatetypefrom(DateTime.Now.ToString("dd/MM/yyyy")));
            
            var Data = await _repository.Details(obj.ManualReceiptId);
            if (Data.ManualReceiptId != obj.ManualReceiptId)
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
                    if (!tblmannualreceipt(obj.ManualReceiptId))
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

      

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var TblManualReceipt = await _context.TblManualReceipt
                .FirstOrDefaultAsync(m => m.ManualReceiptId == id);
            if (TblManualReceipt == null)
            {
                return NotFound();
            }

            return View(TblManualReceipt);
        }

       

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var TblManualReceipt = await _context.TblManualReceipt.FindAsync(id);
            _context.TblManualReceipt.Remove(TblManualReceipt);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool tblmannualreceipt(int id)
        {
            return _context.TblManualReceipt.Any(e => e.ManualReceiptId == id);
        }
    }
}
