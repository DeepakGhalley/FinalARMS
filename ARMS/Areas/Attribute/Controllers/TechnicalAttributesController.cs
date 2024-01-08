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
    public class TechnicalAttributesController : Controller
    {
        private readonly tt_dbContext _context;
        private readonly IMapper _mapper;
        ICommonFunction _CommonRepo = new CommonFunctionBLL();
        readonly ITechnicalAttribute _repository = new TechnicalAttributeBLL();

        public TechnicalAttributesController(tt_dbContext context)
        {
            _context = context;
        }

        // GET: Attribute/TechnicalAttributes
        [Route("Attribute/TechnicalAttributes")]
        public async Task<IActionResult> Index()
        {
            _ = new List<TechnicalAttributeModel>();
            IList<TechnicalAttributeModel> obj = _repository.GetAll();
            return View(obj);
        }

        // GET: Attribute/TechnicalAttributes/Details/5
        [Route("Attribute/TechnicalAttributes/Details")]
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

        // GET: Attribute/TechnicalAttributes/Create
        [Route("Attribute/TechnicalAttributes/Create")]
        public IActionResult Create()
        {
            ViewData["ParentAttribute"] = _CommonRepo.SelectListParentAttribute();
            return View();
        }

        // POST: Attribute/TechnicalAttributes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Attribute/TechnicalAttributes/Create")]
        public async Task<IActionResult> Create(TechnicalAttributeModel obj)
        {
            obj.CreatedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            obj.CreatedOn = Convert.ToDateTime(DateFunctions.getDatetypefrom(DateTime.Now.ToString("dd/MM/yyyy")));
            bool CreateCheckDuplicate = _repository.DuplicateCheckOnSave(obj.TechnicalAttribute);
            if (CreateCheckDuplicate)
            {
                TempData["msg"] = "Duplicate data found, please find a different code";
                ViewData["ParentAttribute"] = _CommonRepo.SelectListParentAttribute();
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
            ViewData["ParentAttribute"] = _CommonRepo.SelectListParentAttribute();
            return View(obj);
        }

        // GET: Attribute/TechnicalAttributes/Edit/5
        [Route("Attribute/TechnicalAttributes/Edit")]
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
            ViewData["ParentAttribute"] = _CommonRepo.SelectListParentAttribute();
            return View(Data);
        }

        // POST: Attribute/TechnicalAttributes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Attribute/TechnicalAttributes/Edit")]
        public async Task<IActionResult> Edit(TechnicalAttributeModel obj)
        {
            obj.ModifiedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            obj.ModifiedOn = Convert.ToDateTime(DateFunctions.getDatetypefrom(DateTime.Now.ToString("dd/MM/yyyy")));
            bool CheckDuplicate = _repository.DuplicateCheckOnUpdate(obj.TechnicalAttribute, obj.TechnicalAttributeId, obj.ParentAttributeId);//checks duplicate user name
            if (CheckDuplicate)
            {
                TempData["msg"] = "Duplicate data found, please find a different name.";
                ViewData["ParentAttribute"] = _CommonRepo.SelectListParentAttribute();
                return View(obj);
            }
            var Data = await _repository.Details(obj.TechnicalAttributeId);
            if (Data.TechnicalAttributeId != obj.TechnicalAttributeId)
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
                    if (!MstTechnicalAttributeExists(obj.TechnicalAttributeId))
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
            ViewData["ParentAttribute"] = _CommonRepo.SelectListParentAttribute();
            return View(obj);
        }

        // GET: Attribute/TechnicalAttributes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mstTechnicalAttribute = await _context.MstTechnicalAttribute
                .Include(m => m.ParentAttribute)
                .FirstOrDefaultAsync(m => m.TechnicalAttributeId == id);
            if (mstTechnicalAttribute == null)
            {
                return NotFound();
            }

            return View(mstTechnicalAttribute);
        }

        // POST: Attribute/TechnicalAttributes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mstTechnicalAttribute = await _context.MstTechnicalAttribute.FindAsync(id);
            _context.MstTechnicalAttribute.Remove(mstTechnicalAttribute);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MstTechnicalAttributeExists(int id)
        {
            return _context.MstTechnicalAttribute.Any(e => e.TechnicalAttributeId == id);
        }
    }
}
