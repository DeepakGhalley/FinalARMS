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

namespace ARMS.Areas.Bank.Controllers
{
    [Area("Bank")]
    public class BanksController : Controller
    {
        private readonly tt_dbContext _context;
        readonly IBank _repository = new BankBLL();

        public BanksController(tt_dbContext context)
        {
            _context = context;
        }

        // GET: Bank/Banks
        [Route("Bank/Banks")]
        public async Task<IActionResult> Index()
        {
            _ = new List<BankModel>();
            IList<BankModel> obj = _repository.GetAll();
            return View(obj);
        }

        // GET: Bank/Banks/Details/5
        [Route("Bank/Banks/Details")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mstBank = await _context.MstBank
                .FirstOrDefaultAsync(m => m.BankId == id);
            if (mstBank == null)
            {
                return NotFound();
            }

            return View(mstBank);
        }

        // GET: Bank/Banks/Create
        [Route("Bank/Banks/Create")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Bank/Banks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Bank/Banks/Create")]
        public async Task<IActionResult> Create(BankModel obj)
        {
            obj.CreatedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            obj.CreatedDate = Convert.ToDateTime(DateFunctions.getDatetypefrom(DateTime.Now.ToString("dd/MM/yyyy")));
            bool CreateCheckDuplicate = _repository.DuplicateCheckOnSave(obj.BankName);
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

        // GET: Bank/Banks/Edit/5
        [Route("Bank/Banks/Edit")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var mstBank = await _context.MstBank.FindAsync(id);
            var Data = await _repository.Details(id);
            if (Data == null)
            {
                return NotFound();
            }
            return View(Data);
        }

        // POST: Bank/Banks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Bank/Banks/Edit")]
        public async Task<IActionResult> Edit(BankModel obj)
        {
            obj.ModifiedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            obj.ModifiedDate = Convert.ToDateTime(DateFunctions.getDatetypefrom(DateTime.Now.ToString("dd/MM/yyyy")));
            bool CheckDuplicate = _repository.DuplicateCheckOnUpdate(obj.BankName, obj.BankId);//checks duplicate user name
            if (CheckDuplicate)
            {
                TempData["msg"] = "Duplicate data found, please find a different value";
                return View(obj);
            }
            var Data = await _repository.Details(obj.BankId);
            if (Data.BankId != obj.BankId)
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
                    if (!MstBankExists(obj.BankId))
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

        // GET: Bank/Banks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mstBank = await _context.MstBank
                .FirstOrDefaultAsync(m => m.BankId == id);
            if (mstBank == null)
            {
                return NotFound();
            }

            return View(mstBank);
        }

        // POST: Bank/Banks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mstBank = await _context.MstBank.FindAsync(id);
            _context.MstBank.Remove(mstBank);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MstBankExists(int id)
        {
            return _context.MstBank.Any(e => e.BankId == id);
        }
    }
}
