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
using System.Threading.Tasks.Dataflow;

namespace ARMS.Areas.TaxMaster.Controllers
{
    [Area("TaxMaster")]
    public class SlabsController : Controller
    {
        private readonly tt_dbContext _context;

        private readonly IMapper _mapper;
        ICommonFunction _CommonRepo = new CommonFunctionBLL();
        readonly ISlab _repository = new SlabBLL();

        public SlabsController(tt_dbContext context)
        {
            _context = context;
        }

        // GET: TaxMaster/Slabs
        [Route("TaxMaster/Slabs")]
        public async Task<IActionResult> Index()
        {
            _ = new List<SlabVM>();
            IList<SlabVM> obj = _repository.GetAll();
            return View(obj);
        }

        // GET: TaxMaster/Slabs/Details/5
        [Route("TaxMaster/Slabs/Details")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mstSlab = await _context.MstSlab
                .Include(m => m.BuildingUnitClass)
                .Include(m => m.BuildingUnitUseType)
                .Include(m => m.Tax)
                .FirstOrDefaultAsync(m => m.SlabId == id);
            if (mstSlab == null)
            {
                return NotFound();
            }

            return View(mstSlab);
        }

        // GET: TaxMaster/Slabs/Create
        [Route("TaxMaster/Slabs/Create")]
        public IActionResult Create()
        {
            SlabDropdown();
            ViewData["TaxId"] = _CommonRepo.SelectListTaxByTransactionType(0);

            return View();
        }
        private void SlabDropdown()
        {
            ViewData["LandUseSubCategory"] = _CommonRepo.SelectListLandUseSubCategory();
            ViewData["BuildingUnitClassId"] = _CommonRepo.SelectListBuildingUnitClass();
            ViewData["BuildingUnitUseTypeId"] = _CommonRepo.SelectListBuildingUnitUseType();
            ViewData["TransactionTypeID"] = _CommonRepo.SelectListTransactionType();
            ViewData["ConstructionType"] = _CommonRepo.SelectListConstructionType();
            ViewData["TaxName"] = _CommonRepo.SelectListTaxMaster();


        }

        // POST: TaxMaster/Slabs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("TaxMaster/Slabs/Create")]
        public async Task<IActionResult> Create(SlabVM obj)
        {
            obj.CreatedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            obj.CreatedOn = DateTime.Now;

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
            SlabDropdown();
            ViewData["TaxId"] = _CommonRepo.SelectListTaxByTransactionType(0);

            return View(obj);
        }


        [Route("TaxMaster/Slabs/Edit")]
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
            SlabDropdown();
            ViewData["TaxId"] = _CommonRepo.SelectListTaxByTransactionType(Data.TransactionTypeID);

            return View(Data);

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("TaxMaster/Slabs/Edit")]
        public async Task<IActionResult> Edit(SlabVM obj)
        {
            obj.ModifiedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            obj.ModifiedOn = Convert.ToDateTime(DateFunctions.getDatetypefrom(DateTime.Now.ToString("dd/MM/yyyy")));
            var Data = await _repository.Details(obj.SlabId);
            if (Data.SlabId != obj.SlabId)

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
                    if (!MstSlabExists(obj.SlabId))
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
            SlabDropdown();
            ViewData["TaxId"] = _CommonRepo.SelectListTaxByTransactionType(0);

            return View(obj);
        }

        // GET: TaxMaster/Slabs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mstSlab = await _context.MstSlab
                .Include(m => m.BuildingUnitClass)
                .Include(m => m.BuildingUnitUseType)
                .Include(m => m.Tax)
                .FirstOrDefaultAsync(m => m.SlabId == id);
            if (mstSlab == null)
            {
                return NotFound();
            }

            return View(mstSlab);
        }

        // POST: TaxMaster/Slabs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mstSlab = await _context.MstSlab.FindAsync(id);
            _context.MstSlab.Remove(mstSlab);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MstSlabExists(int id)
        {
            return _context.MstSlab.Any(e => e.SlabId == id);
        }
        [Route("TaxMaster/Slabs/PopulateTAX")]
        public List<CommonFunctionModel> PopulateTAX(int? id)
        {
            //List<MstTransactionTypeTaxMap> _dataList = null;

            return  _CommonRepo.SelectListTaxByTransactionType(id).ToList();

        }
    }
}
