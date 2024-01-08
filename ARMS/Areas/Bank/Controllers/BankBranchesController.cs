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
    public class BankBranchesController : Controller
    {
        private readonly tt_dbContext _context;
        readonly IBankBranch _repository = new BankBranchBLL();
        ICommonFunction _CommonRepo = new CommonFunctionBLL();

        public BankBranchesController(tt_dbContext context)
        {
            _context = context;
        }

        // GET: Bank/BankBranches
        [Route("Bank/BankBranches")]
        public async Task<IActionResult> Index()
        {
            _ = new List<BankBranchModel>();
            IList<BankBranchModel> obj = _repository.GetAll();
            return View(obj);
        }

        // GET: Bank/BankBranches/Details/5
        [Route("Bank/BankBranches/Details")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mstBankBranch = await _context.MstBankBranch
                .Include(m => m.Bank)
                .FirstOrDefaultAsync(m => m.BankBranchId == id);
            if (mstBankBranch == null)
            {
                return NotFound();
            }

            return View(mstBankBranch);
        }

        // GET: Bank/BankBranches/Create
        [Route("Bank/BankBranches/Create")]
        public IActionResult Create()
        {
            PopulateDropDowns();
            return View();
        }

        private void PopulateDropDowns()
        {
            ViewData["Bank"] = _CommonRepo.SelectListBank();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Bank/BankBranches/Create")]
        public async Task<IActionResult> Create(BankBranchModel obj)
        {
            obj.CreatedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            obj.CreatedOn = DateTime.Now;
            bool CreateCheckDuplicate = _repository.DuplicateCheckOnSave(obj.BranchName);
            if (CreateCheckDuplicate)
            {
                TempData["msg"] = "Duplicate data found, please find a different value";
                PopulateDropDowns();

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
            PopulateDropDowns();
            return View(obj);
        }


        // GET: Bank/BankBranches/Edit/5
        [Route("Bank/BankBranches/Edit")]
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
            ViewData["Bank"] = _CommonRepo.SelectListBank();
            return View(Data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Bank/BankBranches/Edit")]
        public async Task<IActionResult> Edit(BankBranchModel obj)
        {
            obj.ModifiedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            obj.ModifiedOn = DateTime.Now;
            bool CheckDuplicate = _repository.DuplicateCheckOnUpdate(obj.BranchName, obj.BankBranchId, obj.BankId);
            if (CheckDuplicate)
            {
                TempData["msg"] = "Duplicate data found, please find a different value";
                PopulateDropDowns();

                return View(obj);
            }
            var Data = await _repository.Details(obj.BankBranchId);
            if (Data.BankBranchId != obj.BankBranchId)
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
                    if (!MstBankBranchExists(obj.BankBranchId))
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
            ViewData["Bank"] = _CommonRepo.SelectListBank();
            return View(obj);
        }

        // GET: Bank/BankBranches/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mstBankBranch = await _context.MstBankBranch
                .Include(m => m.Bank)
                .FirstOrDefaultAsync(m => m.BankBranchId == id);
            if (mstBankBranch == null)
            {
                return NotFound();
            }

            return View(mstBankBranch);
        }

        // POST: Bank/BankBranches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mstBankBranch = await _context.MstBankBranch.FindAsync(id);
            _context.MstBankBranch.Remove(mstBankBranch);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MstBankBranchExists(int id)
        {
            return _context.MstBankBranch.Any(e => e.BankBranchId == id);
        }

       

        }
    }

