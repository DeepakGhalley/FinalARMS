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

namespace ARMS.Areas.ParentAttribute.Controllers
{
    [Area("Attribute")]
    public class ParentAttributesController : Controller
    {
        private readonly tt_dbContext _context;
        readonly IParentAttribute _repository = new ParentAttributeBLL();
        ICommonFunction _CommonRepo = new CommonFunctionBLL();
        public ParentAttributesController(tt_dbContext context)
        {
            _context = context;
        }

        // GET: ParentAttribute/ParentAttributes
        [Route("Attribute/ParentAttributes")]
        public async Task<IActionResult> Index()
        {
            _ = new List<ParentAttributeModel>();
            IList<ParentAttributeModel> obj = _repository.GetAll();
            return View(obj);
        }

        // GET: ParentAttribute/ParentAttributes/Details/5
        [Route("Attribute/ParentAttributes/Details")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mstParentAttribute = await _context.MstTechnicalAttribute
                .Include(m => m.ParentAttribute)
                .FirstOrDefaultAsync(m => m.TechnicalAttributeId == id);
            if (mstParentAttribute == null)
            {
                return NotFound();
            }

            return View(mstParentAttribute);
        }

        // GET: ParentAttribute/ParentAttributes/Create
        [Route("Attribute/ParentAttributes/Create")]
        public IActionResult Create()
        {
            ViewData["TertiaryAccountHeadId"] = _CommonRepo.SelectListTertiaryHead();
            return View();
        }

        // POST: ParentAttribute/ParentAttributes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Attribute/ParentAttributes/Create")]
        public async Task<IActionResult> Create(ParentAttributeModel obj)
        {
            obj.CreatedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            obj.CreatedOn = Convert.ToDateTime(DateFunctions.getDatetypefrom(DateTime.Now.ToString("dd/MM/yyyy")));
            bool CreateCheckDuplicate = _repository.DuplicateCheckOnSave(obj.ParentAttribute);
            if (CreateCheckDuplicate)
            {
                TempData["msg"] = "Duplicate data found, please find a different code";
                ViewData["TertiaryAccountHeadId"] = _CommonRepo.SelectListParentAttribute();
                return View(obj);
            }
            if (ModelState.IsValid)
            {
                int returnvalue = _repository.SaveParentArribute(obj);

                if (returnvalue > 0)
                {
                    TempData["msg"] = "New Parent Attribute created successfully.";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    TempData["msg"] = "New Parent Attribute creation failed.";
                    return RedirectToAction(nameof(Create));
                }
            }
            return View(obj);
        }

        // GET: ParentAttribute/ParentAttributes/Edit/5
        [Route("Attribute/ParentAttributes/Edit")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var mstParentAttribute = await _context.MstParentAttribute.FindAsync(id);
            var Data = await _repository.Details(id);
            if (Data == null)
            {
                return NotFound();
            }
            ViewData["TertiaryAccountHeadId"] = _CommonRepo.SelectListTertiaryHead();
            return View(Data);
        }

        // POST: ParentAttribute/ParentAttributes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Attribute/ParentAttributes/Edit")]
        public async Task<IActionResult> Edit(ParentAttributeModel obj)
        {
            obj.ModifiedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            obj.ModifiedOn = Convert.ToDateTime(DateFunctions.getDatetypefrom(DateTime.Now.ToString("dd/MM/yyyy")));
            bool CheckDuplicate = _repository.DuplicateCheckOnUpdate(obj.ParentAttribute, obj.TertiaryAccountHeadId, obj.ParentAttributeId);//checks duplicate user name
            if (CheckDuplicate)
            {
                TempData["msg"] = "Duplicate data found, please find a different name.";
                ViewData["TertiaryAccountHeadId"] = _CommonRepo.SelectListParentAttribute();
                return View(obj);
            }
            var Data = await _repository.Details(obj.ParentAttributeId);
            if (Data.ParentAttributeId != obj.ParentAttributeId)

            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    int returnvalue = _repository.UpdateParentArribute(obj);
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
                    if (!MstParentAttributeExists(obj.ParentAttributeId))
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
            ViewData["TertiaryAccountHeadId"] = _CommonRepo.SelectListTertiaryHead();
            return View(obj);
        }

        // GET: ParentAttribute/ParentAttributes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mstParentAttribute = await _context.MstParentAttribute
                .Include(m => m.TertiaryAccountHead)
                .FirstOrDefaultAsync(m => m.ParentAttributeId == id);
            if (mstParentAttribute == null)
            {
                return NotFound();
            }

            return View(mstParentAttribute);
        }

        // POST: ParentAttribute/ParentAttributes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mstParentAttribute = await _context.MstTechnicalAttribute.FindAsync(id);
            _context.MstTechnicalAttribute.Remove(mstParentAttribute);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MstParentAttributeExists(int id)
        {
            return _context.MstTechnicalAttribute.Any(e => e.TechnicalAttributeId == id);
        }
    }
}
