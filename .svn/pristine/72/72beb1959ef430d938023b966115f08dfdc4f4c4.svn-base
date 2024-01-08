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
using Microsoft.AspNetCore.Http;
using ARMS.Functions;

namespace ARMS.Areas.Attribute.Controllers
{
    [Area("Attribute")]
    public class AttributeUnitMapsController : Controller
    {
        private readonly tt_dbContext _context;
        private readonly IMapper _mapper;
        ICommonFunction _CommonRepo = new CommonFunctionBLL();
        readonly IAttributeUnitMap _repository = new AttributeUnitMapBLL();

        public AttributeUnitMapsController(tt_dbContext context)
        {
            _context = context;
        }

        // GET: Attribute/AttributeUnitMaps
        [Route("Attribute/AttributeUnitMaps")]
        public async Task<IActionResult> Index()
        {
            _ = new List<AttributeUnitMapModel>();
            IList<AttributeUnitMapModel> obj = _repository.GetAll();
            return View(obj);
        }

        // GET: Attribute/AttributeUnitMaps/Details/5
        [Route("Attribute/AttributeUnitMaps/Details")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var data = await _repository.Details(id);

            if (data == null)
            {
                return NotFound();
            }

            return View(data);
        }

        // GET: Attribute/AttributeUnitMaps/Create
        [Route("Attribute/AttributeUnitMaps/Create")]
        public IActionResult Create()
        {
            PopulateDropDown();
            return View();
        }

        private void PopulateDropDown()
        {
            ViewData["AssetAttribute"] = _CommonRepo.SelectListAssetAttribute();
            ViewData["MeasurementUnitId"] = _CommonRepo.SelectListMeasurementUnit();

        }

        // POST: Attribute/AttributeUnitMaps/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Attribute/AttributeUnitMaps/Create")]
        public async Task<IActionResult> Create(AttributeUnitMapModel obj)
        {
            obj.CreatedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            obj.CreatedOn = Convert.ToDateTime(DateFunctions.getDatetypefrom(DateTime.Now.ToString("dd/MM/yyyy")));
            bool CreateCheckDuplicate = _repository.DuplicateCheckOnSave(obj.AttributeUnitMapName);
            if (CreateCheckDuplicate)
            {
                TempData["msg"] = "Duplicate data found, please find a different code";
                PopulateDropDown();
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
            PopulateDropDown();
            return View(obj);
        }

        // GET: Attribute/AttributeUnitMaps/Edit/5
        [Route("Attribute/AttributeUnitMaps/Edit")]
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
            PopulateDropDown();
            return View(Data);
        }

        // POST: Attribute/AttributeUnitMaps/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Attribute/AttributeUnitMaps/Edit")]
        public async Task<IActionResult> Edit(AttributeUnitMapModel obj)
        {
            obj.ModifiedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            obj.ModifiedOn = Convert.ToDateTime(DateFunctions.getDatetypefrom(DateTime.Now.ToString("dd/MM/yyyy")));
            bool CheckDuplicate = _repository.DuplicateCheckOnUpdate(obj.AttributeUnitMapName, obj.AttributeUnitMapId, obj.AssetAttributeId, obj.MeasurementUnitId);//checks duplicate user name
            if (CheckDuplicate)
            {
                TempData["msg"] = "Duplicate data found, please find a different name.";
                PopulateDropDown();
                return View(obj);
            }
            var Data = await _repository.Details(obj.AttributeUnitMapId);
            if (Data.AttributeUnitMapId != obj.AttributeUnitMapId)
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
                    if (!MstAttributeUnitMapExists(obj.AttributeUnitMapId))
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
            PopulateDropDown();
            return View(obj);
        }

        // GET: Attribute/AttributeUnitMaps/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mstAttributeUnitMap = await _context.MstAttributeUnitMap
                .Include(m => m.AssetAttribute)
                .Include(m => m.MeasurementUnit)
                .FirstOrDefaultAsync(m => m.AttributeUnitMapId == id);
            if (mstAttributeUnitMap == null)
            {
                return NotFound();
            }

            return View(mstAttributeUnitMap);
        }

        // POST: Attribute/AttributeUnitMaps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mstAttributeUnitMap = await _context.MstAttributeUnitMap.FindAsync(id);
            _context.MstAttributeUnitMap.Remove(mstAttributeUnitMap);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MstAttributeUnitMapExists(int id)
        {
            return _context.MstAttributeUnitMap.Any(e => e.AttributeUnitMapId == id);
        }
    }
}
