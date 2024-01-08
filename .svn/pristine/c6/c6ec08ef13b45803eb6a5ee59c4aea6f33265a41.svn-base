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

namespace ARMS.Areas.Organization.Controllers
{
    [Area("Organization")]
    public class SectionsController : Controller
    {
        private readonly tt_dbContext _context;
        private readonly IMapper _mapper;
        ICommonFunction _CommonRepo = new CommonFunctionBLL();

        readonly ISection _repository = new SectionBLL();
        public SectionsController(tt_dbContext context)
        {
            _context = context;
        }

        // GET: Organization/Sections
        [Route("Organization/Sections")]
        public async Task<IActionResult> Index()
        {
            _ = new List<SectionModel>();
            IList<SectionModel> obj = _repository.GetAll();
            return View(obj);
        }

        // GET: Organization/Sections/Details/5
        [Route("Organization/Sections/Details")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var mstSection = await _context.MstSection
            //    .Include(m => m.Division)
            //    .FirstOrDefaultAsync(m => m.SectionId == id);
            var data = await _repository.Details(id);

            var objs = _mapper.Map<SectionModel>(data);
            if (objs == null)
            {
                return NotFound();
            }

            return View(objs);
        }

        // GET: Organization/Sections/Create
        [Route("Organization/Sections/Create")]
        public IActionResult Create()
        {
            SectionDropDown();
            return View();
        }
        private void SectionDropDown()
        {
            ViewData["DivisionId"] = _CommonRepo.SelectListDivision();

        }

        // POST: Organization/Sections/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Organization/Sections/Create")]
        public async Task<IActionResult> Create(SectionModel obj)
        {
            obj.CreatedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            obj.CreatedOn = Convert.ToDateTime(DateFunctions.getDatetypefrom(DateTime.Now.ToString("dd/MM/yyyy")));
            bool CreateCheckDuplicate = _repository.DuplicateCheckOnSave(obj.SectionName);
            if (CreateCheckDuplicate)
            {
                TempData["msg"] = "Duplicate data found, please find a different code";
                SectionDropDown();
                return View(obj);
            }

            if (ModelState.IsValid)
                {
                    int returnvalue = _repository.SaveSection(obj);

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
            SectionDropDown();
            return View(obj);
        }

        // GET: Organization/Sections/Edit/5
        [HttpGet]
        [Route("Organization/Sections/Edit")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var mstSection = await _context.MstSection.FindAsync(id);
            var Data = await _repository.Details(id);
            if (Data == null)
            {
                return NotFound();
            }
            SectionDropDown();
            return View(Data);
        }

        // POST: Organization/Sections/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Organization/Sections/Edit")]
        public async Task<IActionResult> Edit(SectionModel obj)
        {
            obj.ModifiedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            obj.ModifiedOn = Convert.ToDateTime(DateFunctions.getDatetypefrom(DateTime.Now.ToString("dd/MM/yyyy")));
            bool CheckDuplicate = _repository.DuplicateCheckOnUpdate(obj.SectionName, obj.SectionId, obj.DivisionId);//checks duplicate user name
            if (CheckDuplicate)
            {
                TempData["msg"] = "Duplicate data found, please find a different name.";
                SectionDropDown();
                return View(obj);
            }
            var Data = await _repository.Details(obj.SectionId);
            if (Data.SectionId != obj.SectionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    int returnvalue = _repository.UpdateSection(obj);
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
                    if (!MstSectionExists(obj.SectionId))
                    {
                        TempData["msg"] = "No record found";
                        return RedirectToAction(nameof(Edit));
                        //return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

            }
            SectionDropDown();
            return View(obj);
        }

        // GET: Organization/Sections/Delete/5
        [Route("Organization/Sections/Delete")]

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var mstSection = await _context.MstSection
            //    .Include(m => m.Division)
            //    .FirstOrDefaultAsync(m => m.SectionId == id);
            var mstSection = await _repository.Details(id);
            if (mstSection == null)
            {
                return NotFound();
            }

            return View(mstSection);
        }

        // POST: Organization/Sections/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Route("Organization/Sections/Delete")]

        public async Task<IActionResult> DeleteConfirmed(SectionModel obj)
        {
            await _repository.DeleteConfirmed(obj.SectionId);
            //var mstSection = await _context.MstSection.FindAsync(id);
            //_context.MstSection.Remove(mstSection);
            //await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MstSectionExists(int id)
        {
            return _context.MstSection.Any(e => e.SectionId == id);
        }
    }
}
