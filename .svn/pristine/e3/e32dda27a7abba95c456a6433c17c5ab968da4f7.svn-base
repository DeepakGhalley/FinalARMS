using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CORE_BOL.Entities;
using AutoMapper;
using CORE_DLL;
using CORE_BLL;
using CORE_BOL;
using ARMS.Functions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace ARMS.Areas.Year.Controllers
{
    [Area("Year")]
    [Authorize]
    public class YearsController : Controller
    {

        private readonly tt_dbContext _context;

        private readonly IMapper _mapper;
        ICommonFunction _CommonRepo = new CommonFunctionBLL();

        readonly IFinancialYear _repository = new FinancialYearBLL();
        public YearsController(tt_dbContext context, IMapper mapper)
        {
            _context = context; _mapper = mapper;

        }

        // GET: FinancialYear/FinancialYears
        [Route("FinancialYear/FinancialYears")]
        public async Task<IActionResult> Index()
        {
            _ = new List<FinancialYearVM>();
            IList<FinancialYearVM> obj = _repository.GetAll();
            return View(obj);
        }

        // GET: FinancialYear/FinancialYears/Details/5
        [Route("FinancialYear/FinancialYears/Details")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mstFinancialYear = await _context.MstFinancialYear
                .FirstOrDefaultAsync(m => m.FinancialYearId == id);
            if (mstFinancialYear == null)
            {
                return NotFound();
            }

            return View(mstFinancialYear);
        }

        // GET: FinancialYear/FinancialYears/Create
        [Route("FinancialYear/FinancialYears/Create")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: FinancialYear/FinancialYears/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("FinancialYear/FinancialYears/Create")]
        public async Task<IActionResult> Create(FinancialYearVM obj)
        {
            obj.CreatedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            obj.CreatedOn = DateTime.Now;
            bool CreateCheckDuplicate = _repository.DuplicateCheckOnSave(obj.FinancialYear);
            if (CreateCheckDuplicate)
            {
                TempData["msg"] = "Duplicate data found, please find a different Year.";
                return View(obj);
            }

            if (ModelState.IsValid)
            {

                int returnvalue = _repository.Save(obj);

                if (returnvalue > 0)
                {
                    TempData["msg"] = "New Record created successfully.";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    TempData["msg"] = "New Record creation failed.";
                    return RedirectToAction(nameof(Create));
                }

            }
            //  ViewData["RoleId"] = _CommonRepo.SelectListRole();
            return View(obj);
        }

        // GET: FinancialYear/FinancialYears/Edit/5
        [HttpGet]
        [Route("FinancialYear/FinancialYears/Edit")]
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

        // POST: FinancialYear/FinancialYears/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("FinancialYear/FinancialYears/Edit")]
        public async Task<IActionResult> Edit(FinancialYearVM obj)
        {
            obj.ModifiedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            obj.ModifiedOn = DateTime.Now;
            bool CheckDuplicate = _repository.DuplicateCheckOnUpdate(obj.FinancialYear, obj.FinancialYearId);//checks duplicate user name
            if (CheckDuplicate)
            {
                TempData["msg"] = "Duplicate data found, please find a different Financial Year.";
                return View(obj);
            }

            var Data = await _repository.Details(obj.FinancialYearId);
            if (Data.FinancialYearId != obj.FinancialYearId)


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
                        TempData["msg"] = "Record updated successfully.";
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        TempData["msg"] = "Error on updation.";
                        // return RedirectToAction(nameof(Index));
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MstFinancialYearExists(obj.FinancialYearId))
                    {
                        TempData["msg"] = "No detail found.";
                        return RedirectToAction(nameof(Edit));
                        //return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

            }
            ViewData["RoleId"] = _CommonRepo.SelectListRole();// new SelectList(_context.TblMstRole, "RoleId", "RoleName", tblMstUser.RoleId);
            return View(obj);
        }

        // GET: FinancialYear/FinancialYears/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mstFinancialYear = await _context.MstFinancialYear
                .FirstOrDefaultAsync(m => m.FinancialYearId == id);
            if (mstFinancialYear == null)
            {
                return NotFound();
            }

            return View(mstFinancialYear);
        }

        // POST: FinancialYear/FinancialYears/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mstFinancialYear = await _context.MstFinancialYear.FindAsync(id);
            _context.MstFinancialYear.Remove(mstFinancialYear);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MstFinancialYearExists(int id)
        {
            return _context.MstFinancialYear.Any(e => e.FinancialYearId == id);
        }
    }
}
