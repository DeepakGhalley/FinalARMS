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
    public class TransactionTypeTaxMapsController : Controller
    {
        private readonly tt_dbContext _context;

        private readonly IMapper _mapper;
        ICommonFunction _CommonRepo = new CommonFunctionBLL();
        readonly ITransactionTypeTaxMap _repository = new TransactionTypeTaxMapBLL();

        public TransactionTypeTaxMapsController(tt_dbContext context)
        {
            _context = context;
        }

        // GET: TaxMaster/TransactionTypeTaxMaps
        [Route("TaxMaster/TransactionTypeTaxMaps")]
        public async Task<IActionResult> Index()
        {
            _ = new List<TransactionTypeTaxMapVM>();
            IList<TransactionTypeTaxMapVM> obj = _repository.GetAll();
            return View(obj);
        }

        // GET: TaxMaster/TransactionTypeTaxMaps/Details/5
        [Route("TaxMaster/TransactionTypeTaxMaps/Details")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mstTransactionTypeTaxMap = await _context.MstTransactionTypeTaxMap
                .Include(m => m.Tax)
                .Include(m => m.TransactionType)
                .FirstOrDefaultAsync(m => m.TransactionTypeTaxMapId == id);
            if (mstTransactionTypeTaxMap == null)
            {
                return NotFound();
            }

            return View(mstTransactionTypeTaxMap);
        }

        // GET: TaxMaster/TransactionTypeTaxMaps/Create
        [Route("TaxMaster/TransactionTypeTaxMaps/Create")]
        public IActionResult Create()
        {
            TransactionTypeTaxMapDropDown();
            return View();
        }
        public void TransactionTypeTaxMapDropDown()
        {
            ViewData["TaxId"] = _CommonRepo.SelectListTaxMaster();
            ViewData["TransactionTypeId"] = _CommonRepo.SelectListTransactionType();
        }

        // POST: TaxMaster/TransactionTypeTaxMaps/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("TaxMaster/TransactionTypeTaxMaps/Create")]
        public async Task<IActionResult> Create(TransactionTypeTaxMapVM obj)
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
            TransactionTypeTaxMapDropDown();
            return View(obj);
        }

        // GET: TaxMaster/TransactionTypeTaxMaps/Edit/5
        [Route("TaxMaster/TransactionTypeTaxMaps/Edit")]
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
            TransactionTypeTaxMapDropDown();
            return View(Data);
        }

        // POST: TaxMaster/TransactionTypeTaxMaps/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("TaxMaster/TransactionTypeTaxMaps/Edit")]
        public async Task<IActionResult> Edit(TransactionTypeTaxMapVM obj)
        {
            obj.ModifiedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            obj.ModifiedOn = Convert.ToDateTime(DateFunctions.getDatetypefrom(DateTime.Now.ToString("dd/MM/yyyy")));

            var Data = await _repository.Details(obj.TransactionTypeTaxMapId);

            if (Data.TransactionTypeTaxMapId != obj.TransactionTypeTaxMapId)
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
                    if (!MstTransactionTypeTaxMapExists(obj.TransactionTypeTaxMapId))
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
            TransactionTypeTaxMapDropDown();
            return View(obj);
        }

        // GET: TaxMaster/TransactionTypeTaxMaps/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mstTransactionTypeTaxMap = await _context.MstTransactionTypeTaxMap
                .Include(m => m.Tax)
                .Include(m => m.TransactionType)
                .FirstOrDefaultAsync(m => m.TransactionTypeTaxMapId == id);
            if (mstTransactionTypeTaxMap == null)
            {
                return NotFound();
            }

            return View(mstTransactionTypeTaxMap);
        }

        // POST: TaxMaster/TransactionTypeTaxMaps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mstTransactionTypeTaxMap = await _context.MstTransactionTypeTaxMap.FindAsync(id);
            _context.MstTransactionTypeTaxMap.Remove(mstTransactionTypeTaxMap);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MstTransactionTypeTaxMapExists(int id)
        {
            return _context.MstTransactionTypeTaxMap.Any(e => e.TransactionTypeTaxMapId == id);
        }

        // sample cascade
        [Route("TaxMaster/TransactionTypeTaxMaps/PopulateTaxByTransactionType")]
        [HttpPost]
        public IEnumerable<CommonFunctionModel> PopulateTaxByTransactionType(int id)
        {

            return _CommonRepo.SelectListTaxByTransactionType(id).ToList();

        }
    }
}
