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
    public class DetailTechnicalAttributesController : Controller
    {
        private readonly tt_dbContext _context;
        private readonly IMapper _mapper;
        ICommonFunction _CommonRepo = new CommonFunctionBLL();
        readonly IDetailTechnicalAttribute _repository = new DetailTechnicalAttributeBLL();
        public DetailTechnicalAttributesController(tt_dbContext context)
        {
            _context = context;
        }

        // GET: Attribute/DetailTechnicalAttributes
        [Route("Attribute/DetailTechnicalAttributes")]
        public async Task<IActionResult> Index()
        {
            _ = new List<DetailTechnicalAttributeModel>();
            IList<DetailTechnicalAttributeModel> obj = _repository.GetAll();
            return View(obj);
        }

        // GET: Attribute/DetailTechnicalAttributes/Details/5
        [Route("Attribute/DetailTechnicalAttributes/Details")]
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

        // GET: Attribute/DetailTechnicalAttributes/Create
        [Route("Attribute/DetailTechnicalAttributes/Create")]
        public IActionResult Create()
        {
            ViewData["TechnicalAttributeId"] = _CommonRepo.SelectListTechnicalAttribute();
            return View();
        }

        // POST: Attribute/DetailTechnicalAttributes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Attribute/DetailTechnicalAttributes/Create")]
        public async Task<IActionResult> Create(DetailTechnicalAttributeModel obj)
        {
            obj.CreatedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            obj.CreatedOn = Convert.ToDateTime(DateFunctions.getDatetypefrom(DateTime.Now.ToString("dd/MM/yyyy")));
            bool CreateCheckDuplicate = _repository.DuplicateCheckOnSave(obj.DetailTechnicalAttribute);
            if (CreateCheckDuplicate)
            {
                TempData["msg"] = "Duplicate data found, please find a different code";
                ViewData["TechnicalAttributeId"] = _CommonRepo.SelectListTechnicalAttribute();
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
            ViewData["TechnicalAttributeId"] = _CommonRepo.SelectListTechnicalAttribute();
            return View(obj);
        }

        // GET: Attribute/DetailTechnicalAttributes/Edit/5
        [Route("Attribute/DetailTechnicalAttributes/Edit")]
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
            ViewData["TechnicalAttributeId"] = _CommonRepo.SelectListTechnicalAttribute();
            return View(Data);
        }

        // POST: Attribute/DetailTechnicalAttributes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Attribute/DetailTechnicalAttributes/Edit")]
        public async Task<IActionResult> Edit(DetailTechnicalAttributeModel obj)
        {
            obj.ModifiedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            obj.ModifiedOn = Convert.ToDateTime(DateFunctions.getDatetypefrom(DateTime.Now.ToString("dd/MM/yyyy")));
            bool CheckDuplicate = _repository.DuplicateCheckOnUpdate(obj.DetailTechnicalAttribute, obj.DetailTechnicalAttributeId, obj.TechnicalAttributeId);//checks duplicate user name
            if (CheckDuplicate)
            {
                TempData["msg"] = "Duplicate data found, please find a different name.";
                ViewData["TechnicalAttributeId"] = _CommonRepo.SelectListTechnicalAttribute();
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
                    if (!MstDetailTechnicalAttributeExists(obj.DetailTechnicalAttributeId))
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
            ViewData["TechnicalAttributeId"] = _CommonRepo.SelectListTechnicalAttribute();
            return View(obj);
        }

        // GET: Attribute/DetailTechnicalAttributes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mstDetailTechnicalAttribute = await _context.MstDetailTechnicalAttribute
                .Include(m => m.TechnicalAttribute)
                .FirstOrDefaultAsync(m => m.DetailTechnicalAttributeId == id);
            if (mstDetailTechnicalAttribute == null)
            {
                return NotFound();
            }

            return View(mstDetailTechnicalAttribute);
        }

        // POST: Attribute/DetailTechnicalAttributes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mstDetailTechnicalAttribute = await _context.MstDetailTechnicalAttribute.FindAsync(id);
            _context.MstDetailTechnicalAttribute.Remove(mstDetailTechnicalAttribute);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MstDetailTechnicalAttributeExists(int id)
        {
            return _context.MstDetailTechnicalAttribute.Any(e => e.DetailTechnicalAttributeId == id);
        }
    }
}
