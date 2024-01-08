using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CORE_BOL.Entities;
using CORE_BOL;
using AutoMapper;
using CORE_DLL;
using CORE_BLL;
using Microsoft.AspNetCore.Http;
using ARMS.Functions;

namespace ARMS.Areas.DepreciationType.Controllers
{
    [Area("DepreciationType")]
    public class DepreciationTypesController : Controller
    {
        private readonly tt_dbContext _context;

        private readonly IMapper _mapper;
        ICommonFunction _CommonRepo = new CommonFunctionBLL();

        readonly IDepreciationType _repository = new DepreciationTypeBLL();
        public DepreciationTypesController(tt_dbContext context, IMapper mapper)
        {
            _context = context; _mapper = mapper;

        }

        [Route("DepreciationType/DepreciationTypes")]
        public async Task<IActionResult> Index()
        {
            _ = new List<DepreciationTypeModel>();
            IList<DepreciationTypeModel> obj = _repository.GetAll();
            return View(obj);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mstDepreciationType = await _context.MstDepreciationType
                .FirstOrDefaultAsync(m => m.DepreciationTypeId == id);
            if (mstDepreciationType == null)
            {
                return NotFound();
            }

            return View(mstDepreciationType);
        }

        [Route("DepreciationType/DepreciationTypes/Create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("DepreciationType/DepreciationTypes/Create")]
        public async Task<IActionResult> Create(DepreciationTypeModel obj)
        {
            obj.CreatedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            obj.CreatedOn = DateTime.Now;

            bool CreateCheckDuplicate = _repository.DuplicateCheckOnSave(obj.DepreciationType);
            if (CreateCheckDuplicate)
            {
                TempData["msg"] = "Duplicate data found, please find a different Depreciation Type.";
                return View(obj);
            }
            if (ModelState.IsValid)
            {

                int returnvalue = _repository.Save(obj);

                if (returnvalue > 0)
                {
                    TempData["msg"] = "New Record created successfully.";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    TempData["msg"] = "New Record creation failed.";
                    return RedirectToAction(nameof(Create));
                }

            }
            return View(obj);
        }

        [HttpGet]
        [Route("DepreciationType/DepreciationTypes/Edit")]
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

            return View(Data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("DepreciationType/DepreciationTypes/Edit")]
        public async Task<IActionResult> Edit(DepreciationTypeModel obj)
        {
            obj.ModifiedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            obj.ModifiedOn = DateTime.Now;
            bool CheckDuplicate = _repository.DuplicateCheckOnUpdate(obj.DepreciationType, obj.DepreciationTypeId);//checks duplicate user name
            if (CheckDuplicate)
            {
                TempData["msg"] = "Duplicate data found, please find a different Depreciation Type.";
                return View(obj);
            }
            var Data = await _repository.Details(obj.DepreciationTypeId);
            if (Data.DepreciationTypeId != obj.DepreciationTypeId)


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
                        TempData["msg"] = "Record updated successfully.";
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        TempData["msg"] = "Error on updation.";
                        // return RedirectToAction(nameof(Index));
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MstDepreciationTypeExists(obj.DepreciationTypeId))
                    {
                        TempData["msg"] = "No detail found.";
                        return RedirectToAction(nameof(Edit));
                        //return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

            }
            return View(obj);
        }

        [Route("DepreciationType/DepreciationTypes/Delete")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var MstDepreciationType = await _context.MstDepreciationType
                .FirstOrDefaultAsync(m => m.DepreciationTypeId == id);
            if (MstDepreciationType == null)
            {
                return NotFound();
            }

            return View(MstDepreciationType);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Route("DepreciationType/DepreciationTypes/Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var MstDepreciationType = await _context.MstDepreciationType.FindAsync(id);
            _context.MstDepreciationType.Remove(MstDepreciationType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MstDepreciationTypeExists(int id)
        {
            return _context.MstDepreciationType.Any(e => e.DepreciationTypeId == id);
        }
    }
}
