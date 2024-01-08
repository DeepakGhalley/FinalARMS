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

namespace ARMS.Areas.Attribute.Controllers
{
    [Area("Attribute")]
    public class AssetAttributesController : Controller
    {
        private readonly tt_dbContext _context;

        private readonly IMapper _mapper;
        ICommonFunction _CommonRepo = new CommonFunctionBLL();
        readonly IAssetAttribute _repository = new AssetAttributeBLL();

        public AssetAttributesController(tt_dbContext context)
        {
            _context = context;
        }

        // GET: Attribute/AssetAttributes
        [Route("Attribute/AssetAttributes")]
        public async Task<IActionResult> Index()
        {
            _ = new List<AssetAttributeVM>();
            IList<AssetAttributeVM> obj = _repository.GetAll();
            return View(obj);
        }

        // GET: Attribute/AssetAttributes/Details/5
        [Route("Attribute/AssetAttributes/Details")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mstAssetAttribute = await _context.MstAssetAttribute
                .Include(m => m.ParentAttribute)
                .FirstOrDefaultAsync(m => m.AssetAttributeId == id);
            if (mstAssetAttribute == null)
            {
                return NotFound();
            }

            return View(mstAssetAttribute);
        }

        // GET: Attribute/AssetAttributes/Create
        [Route("Attribute/AssetAttributes/Create")]
        public IActionResult Create()
        {
            ParentAttributeDropDown();
            return View();
        }
        private void ParentAttributeDropDown()
        {
            ViewData["ParentAttributeId"] = _CommonRepo.SelectListParentAttribute();
        }

        // POST: Attribute/AssetAttributes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Attribute/AssetAttributes/Create")]
        public async Task<IActionResult> Create(AssetAttributeVM obj)
        {
            obj.CreatedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            obj.CreatedOn = Convert.ToDateTime(DateFunctions.getDatetypefrom(DateTime.Now.ToString("dd/MM/yyyy")));
            bool CreateCheckDuplicate = _repository.DuplicateCheckOnSave(obj.AttributeName);
            if (CreateCheckDuplicate)
            {
                TempData["msg"] = "Duplicate data found, please enter a different value";
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
            ParentAttributeDropDown();
            return View(obj);
        }

        // GET: Attribute/AssetAttributes/Edit/5
        [Route("Attribute/AssetAttributes/Edit")]
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
            ParentAttributeDropDown();
            return View(Data);
        }

        // POST: Attribute/AssetAttributes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Attribute/AssetAttributes/Edit")]
        public async Task<IActionResult> Edit(AssetAttributeVM obj)
        {
            obj.ModifiedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            obj.ModifiedOn = Convert.ToDateTime(DateFunctions.getDatetypefrom(DateTime.Now.ToString("dd/MM/yyyy")));
            bool CheckDuplicate = _repository.DuplicateCheckOnUpdate(obj.AttributeName, obj.ParentAttributeId, obj.AssetAttributeId);
            if (CheckDuplicate)
            {
                TempData["msg"] = "Duplicate data found, please find a different name.";
                ParentAttributeDropDown();
                return View(obj);
            }

            var Data = await _repository.Details(obj.AssetAttributeId);
            if (Data.AssetAttributeId != obj.AssetAttributeId)
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
                    if (!MstAssetAttributeExists(obj.AssetAttributeId))
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
            ParentAttributeDropDown();
            return View(obj);
        }

        // GET: Attribute/AssetAttributes/Delete/5
        [Route("Attribute/AssetAttributes/Delete")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mstAssetAttribute = await _context.MstAssetAttribute
                .Include(m => m.ParentAttribute)
                .FirstOrDefaultAsync(m => m.AssetAttributeId == id);
            if (mstAssetAttribute == null)
            {
                return NotFound();
            }

            return View(mstAssetAttribute);
        }

        // POST: Attribute/AssetAttributes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Route("Attribute/AssetAttributes/DeleteConfirmed")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mstAssetAttribute = await _context.MstAssetAttribute.FindAsync(id);
            _context.MstAssetAttribute.Remove(mstAssetAttribute);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MstAssetAttributeExists(int id)
        {
            return _context.MstAssetAttribute.Any(e => e.AssetAttributeId == id);
        }
    }
}
