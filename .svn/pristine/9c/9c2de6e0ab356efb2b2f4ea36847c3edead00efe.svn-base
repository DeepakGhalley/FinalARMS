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

namespace ARMS.Areas.OpeningBalance.Controllers
{
    [Area("OpeningBalance")]
    public class OpeningBalancesController : Controller
    {
        private readonly tt_dbContext _context;
        readonly IOpeningBalance _repository = new OpeningBalanceBLL();
      
        public OpeningBalancesController(tt_dbContext context)
        {
            _context = context;
        }

       
        [Route("OpeningBalance/OpeningBalances")]
        public async Task<IActionResult> Index()
        {
            _ = new List<OpeningBalaceVM>();
            IList<OpeningBalaceVM> obj = _repository.GetAll();
            return View(obj);
        }
       

        [Route("OpeningBalance/OpeningBalances/Details")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var TblOpeningBalance = await _context.TblOpeningBalance
                .FirstOrDefaultAsync(m => m.OpeningBalanceId == id);
            if (TblOpeningBalance == null)
            {
                return NotFound();
            }

            return View(TblOpeningBalance);
        }

       
        [Route("OpeningBalance/OpeningBalances/Create")]
        public IActionResult Create()
        {
            return View();
        }

    
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("OpeningBalance/OpeningBalances/Create")]
        public async Task<IActionResult> Create(OpeningBalaceVM obj)
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

        [Route("OpeningBalance/OpeningBalances/Edit")]
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
        [Route("OpeningBalance/OpeningBalances/Edit")]
        public async Task<IActionResult> Edit(OpeningBalaceVM obj)
        {
            obj.ModifiedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            obj.ModifiedOn = Convert.ToDateTime(DateFunctions.getDatetypefrom(DateTime.Now.ToString("dd/MM/yyyy")));
            
            var Data = await _repository.Details(obj.OpeningBalanceId);
            if (Data.OpeningBalanceId != obj.OpeningBalanceId)
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
                    if (!TblOpeningBalance(obj.OpeningBalanceId))
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

            var TblOpeningBalance = await _context.TblOpeningBalance
                .FirstOrDefaultAsync(m => m.OpeningBalanceId == id);
            if (TblOpeningBalance == null)
            {
                return NotFound();
            }

            return View(TblOpeningBalance);
        }

       

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var TblOpeningBalance = await _context.TblOpeningBalance.FindAsync(id);
            _context.TblOpeningBalance.Remove(TblOpeningBalance);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblOpeningBalance(int id)
        {
            return _context.TblOpeningBalance.Any(e => e.OpeningBalanceId == id);
        }

    }
}
