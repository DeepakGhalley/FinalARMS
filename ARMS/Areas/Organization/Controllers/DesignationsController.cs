using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CORE_BOL.Entities;
using CORE_DLL;
using AutoMapper;
using CORE_BLL;
using CORE_BOL;
using Microsoft.AspNetCore.Http;
using ARMS.Functions;

namespace ARMS.Areas.Organization.Controllers
{
    [Area("Organization")]
    public class DesignationsController : Controller
    {
        private readonly tt_dbContext _context;
        private readonly IMapper _mapper;
        ICommonFunction _CommonRepo = new CommonFunctionBLL();

        readonly IDesignation _repository = new DesignationBLL();

        public DesignationsController(tt_dbContext context)
        {
            _context = context;
        }

        // GET: Organization/Designations
        [Route("Organization/Designations")]

        public async Task<IActionResult> Index()
        {
            _ = new List<DesignationModel>();
            IList<DesignationModel> obj = _repository.GetAll();
            return View(obj);
        }

        // GET: Organization/Designations/Details/5
        [Route("Organization/Designations/Details")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var data = await _repository.Details(id);
            var objs = _mapper.Map<SectionModel>(data);
            if (data == null)
            {
                return NotFound();
            }

            return View(objs);
        }

        // GET: Organization/Designations/Create
        [Route("Organization/Designations/Create")]
        public IActionResult Create()
        {
            DesignationDropDown();
            return View();
        }

        private void DesignationDropDown()
        {
            ViewData["SectionId"] = _CommonRepo.SelectListSection();

        }

        // POST: Organization/Designations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Organization/Designations/Create")]
        public async Task<IActionResult> Create(DesignationModel obj)
        {
            obj.CreatedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            obj.CreatedOn = Convert.ToDateTime(DateFunctions.getDatetypefrom(DateTime.Now.ToString("dd/MM/yyyy")));
            bool CreateCheckDuplicate = _repository.DuplicateCheckOnSave(obj.Designation);
            if (CreateCheckDuplicate)
            {
                TempData["msg"] = "Duplicate data found, please find a different value";
                DesignationDropDown();
                return View(obj);
            }
            if (ModelState.IsValid)
            {
                int returnvalue = _repository.SaveDesignation(obj);

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
            DesignationDropDown();
            return View(obj);
        }

        // GET: Organization/Designations/Edit/5
        [Route("Organization/Designations/Edit")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var mstDesignation = await _context.MstDesignation.FindAsync(id);
            var Data = await _repository.Details(id);
            if (Data == null)
            {
                return NotFound();
            }
            DesignationDropDown();
            return View(Data);
        }

        // POST: Organization/Designations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Organization/Designations/Edit")]
        public async Task<IActionResult> Edit(DesignationModel obj)
        {
            obj.ModifiedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            obj.ModifiedOn = Convert.ToDateTime(DateFunctions.getDatetypefrom(DateTime.Now.ToString("dd/MM/yyyy")));
            bool CheckDuplicate = _repository.DuplicateCheckOnUpdate(obj.Designation, obj.DesignationId, obj.SectionId);//checks duplicate user name
            if (CheckDuplicate)
            {
                TempData["msg"] = "Duplicate data found, please find a different value";
                DesignationDropDown();
                return View(obj);
            }
            var Data = await _repository.Details(obj.DesignationId);
            if (Data.DesignationId != obj.DesignationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    int returnvalue = _repository.UpdateDesignation(obj);
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
                    if (!MstDesignationExists(obj.DesignationId))
                    {
                        TempData["msg"] = "No Rercord found";
                        return RedirectToAction(nameof(Edit));
                        //return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

            }
            DesignationDropDown();
            return View(obj);
        }

        // GET: Organization/Designations/Delete/5
        [Route("Organization/Designations/Delete")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var mstDesignation = await _context.MstDesignation
            //    .Include(m => m.Section)
            //    .FirstOrDefaultAsync(m => m.DesignationId == id);
            var mstDesignation = await _repository.Details(id);
            if (mstDesignation == null)
            {
                return NotFound();
            }

            return View(mstDesignation);
        }

        // POST: Organization/Designations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Route("Organization/Designations/Delete")]
        public async Task<IActionResult> DeleteConfirmed(DesignationModel obj)
        {
            await _repository.DeleteConfirmed(obj.SectionId);
            //var mstDesignation = await _context.MstDesignation.FindAsync(id);
            //_context.MstDesignation.Remove(mstDesignation);
            //await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MstDesignationExists(int id)
        {
            return _context.MstDesignation.Any(e => e.DesignationId == id);
        }
    }
}
