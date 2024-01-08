using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CORE_BOL.Entities;
using CORE_BLL;
using CORE_DLL;
using CORE_BOL;
using AutoMapper;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.AspNetCore.Http;
using ARMS.Functions;

namespace ARMS.Areas.TaxMaster.Controllers
{
    [Area("TaxMaster")]
    public class TaxMastersController : Controller
    {
        private readonly tt_dbContext _context;

        private readonly IMapper _mapper;
        ICommonFunction _CommonRepo = new CommonFunctionBLL();
        readonly ITaxMaster _repository = new TaxMasterBLL();


        public TaxMastersController(tt_dbContext context)
        {
            _context = context;
        }

        // GET: TaxMaster/TaxMasters
        [Route("TaxMaster/TaxMasters")]
        public async Task<IActionResult> Index()
        {
            _ = new List<TaxMasterVM>();
            IList<TaxMasterVM> obj = _repository.GetAll();
            return View(obj);
        }

        // GET: TaxMaster/TaxMasters/Details/5
        [Route("Organization/Designations/Details")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mstTaxMaster = await _context.MstTaxMaster
                .Include(m => m.DetailHead)
                .FirstOrDefaultAsync(m => m.TaxId == id);
            if (mstTaxMaster == null)
            {
                return NotFound();
            }

            return View(mstTaxMaster);
        }

        // GET: TaxMaster/TaxMasters/Create
        [Route("TaxMaster/TaxMasters/Create")]
        public IActionResult Create()
        {
            TaxMasterDropDown();
             return View();
        }
        public void TaxMasterDropDown()
        {
            ViewData["DetailHeadId"] = _CommonRepo.SelectListDetailHead();
            //ViewData["TaxTypeClassificationId"] = _CommonRepo.SelectListTaxTypeClassification();
        }

        // POST: TaxMaster/TaxMasters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("TaxMaster/TaxMasters/Create")]
        public async Task<IActionResult> Create(TaxMasterVM obj)
        {
            obj.CreatedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            obj.CreatedOn = Convert.ToDateTime(DateFunctions.getDatetypefrom(DateTime.Now.ToString("dd/MM/yyyy")));

            bool CreateCheckDuplicate = _repository.DuplicateCheckOnSave(obj.TaxName);
            if (CreateCheckDuplicate)
            {
                TempData["msg"] = "Duplicate data found, please enter a different value";
                TaxMasterDropDown();
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
            TaxMasterDropDown();
            return View(obj);
        }

        // GET: TaxMaster/TaxMasters/Edit/5
        [Route("TaxMaster/TaxMasters/Edit")]
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
            TaxMasterDropDown();
            return View(Data);
        }

        // POST: TaxMaster/TaxMasters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("TaxMaster/TaxMasters/Edit")]
        public async Task<IActionResult> Edit(TaxMasterVM obj)
        {
            obj.ModifiedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            obj.ModifiedOn = Convert.ToDateTime(DateFunctions.getDatetypefrom(DateTime.Now.ToString("dd/MM/yyyy")));
            var Data = await _repository.Details(obj.TaxId);
            bool CheckDuplicate = _repository.DuplicateCheckOnUpdate(obj.TaxName,obj.DetailHeadId, obj.TaxId);
            if (CheckDuplicate)
            {
                TempData["msg"] = "Duplicate data found, please enter a different value";
                TaxMasterDropDown();
                return View(obj);
            }

            if (Data.TaxId != obj.TaxId)
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
                    if (!MstTaxMasterExists(obj.TaxId))
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
            TaxMasterDropDown();
            return View(obj);
        }

        // GET: TaxMaster/TaxMasters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mstTaxMaster = await _context.MstTaxMaster
                .Include(m => m.DetailHead)
                .FirstOrDefaultAsync(m => m.TaxId == id);
            if (mstTaxMaster == null)
            {
                return NotFound();
            }

            return View(mstTaxMaster);
        }

        // POST: TaxMaster/TaxMasters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mstTaxMaster = await _context.MstTaxMaster.FindAsync(id);
            _context.MstTaxMaster.Remove(mstTaxMaster);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MstTaxMasterExists(int id)
        {
            return _context.MstTaxMaster.Any(e => e.TaxId == id);
        }
    }
}
