using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CORE_BOL.Entities;
using CORE_BOL;
using AutoMapper;
using CORE_DLL;
using CORE_BLL;
using Microsoft.AspNetCore.Http;
using ARMS.Functions;

namespace ARMS.Areas.Maintenance.Controllers
{
    [Area("Maintenance")]
    public class DepreciationTypesController : Controller
    {
        private readonly tt_dbContext _context;

        private readonly IMapper _mapper;
        ICommonFunction _CommonRepo = new CommonFunctionBLL();

        readonly IModificationReason _repository = new ModificationReasonBLL();
        public DepreciationTypesController(tt_dbContext context, IMapper mapper)
        {
            _context = context; _mapper = mapper;

        }

        // GET: Maintenance/ModificationReason
        [Route("Maintenance/ModificationReason")]
        public async Task<IActionResult> Index()
        {
            _ = new List<ModificationReasonVM>();
            IList<ModificationReasonVM> obj = _repository.GetAll();
            return View(obj);
        }

        // GET: Maintenance/ModificationReason/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mstModificationReason = await _context.MstModificationReason
                .FirstOrDefaultAsync(m => m.ModificationReasonId == id);
            if (mstModificationReason == null)
            {
                return NotFound();
            }

            return View(mstModificationReason);
        }

        // GET: Maintenance/ModificationReason/Create
        [Route("Maintenance/ModificationReason/Create")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Maintenance/ModificationReason/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Maintenance/ModificationReason/Create")]
        public async Task<IActionResult> Create(ModificationReasonVM obj)
        {
            obj.CreatedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            obj.CreatedOn = Convert.ToDateTime(DateFunctions.getDatetypefrom(DateTime.Now.ToString()));

            bool CreateCheckDuplicate = _repository.DuplicateCheckOnSave(obj.ModificationReason);
            if (CreateCheckDuplicate)
            {
                TempData["msg"] = "Duplicate data found, please find a different Modification Name.";
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

        // GET: Maintenance/ModificationReason/Edit/5
        [HttpGet]
        [Route("Maintenance/ModificationReason/Edit")]
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

        // POST: Maintenance/ModificationReason/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Maintenance/ModificationReason/Edit")]
        public async Task<IActionResult> Edit(ModificationReasonVM obj)
        {
            obj.ModifiedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            obj.ModifiedOn = Convert.ToDateTime(DateFunctions.getDatetypefrom(DateTime.Now.ToString("dd/MM/yyyy")));
            bool CheckDuplicate = _repository.DuplicateCheckOnUpdate(obj.ModificationReason, obj.ModificationReasonId);//checks duplicate user name
            if (CheckDuplicate)
            {
                TempData["msg"] = "Duplicate data found, please find a different Modification Reason Name.";
                return View(obj);
            }
            var Data = await _repository.Details(obj.ModificationReasonId);
            if (Data.ModificationReasonId != obj.ModificationReasonId)


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
                    if (!MstModificationReasonExists(obj.ModificationReasonId))
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

        // GET: Maintenance/ModificationReason/Delete/5
        [Route("Maintenance/ModificationReason/Delete")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var MstModificationReason = await _context.MstModificationReason
                .FirstOrDefaultAsync(m => m.ModificationReasonId == id);
            if (MstModificationReason == null)
            {
                return NotFound();
            }

            return View(MstModificationReason);
        }

        // POST: Maintenance/ModificationReason/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Route("Maintenance/ModificationReason/Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var MstModificationReason = await _context.MstModificationReason.FindAsync(id);
            _context.MstModificationReason.Remove(MstModificationReason);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MstModificationReasonExists(int id)
        {
            return _context.MstModificationReason.Any(e => e.ModificationReasonId == id);
        }
    }
}
