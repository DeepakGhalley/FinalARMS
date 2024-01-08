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
using Microsoft.AspNetCore.Authorization;

namespace ARMS.Areas.Location.Controllers
{

    [Area("LetterHeadUpload")]
    [Authorize]
    public class LogoSignMapsController : Controller
    {
        private readonly tt_dbContext _context;
        private readonly IMapper _mapper;
        ICommonFunction _CommonRepo = new CommonFunctionBLL();
        readonly ILogoSignMap _repository = new LogoSignMapBLL();
        public LogoSignMapsController(tt_dbContext context)
        {
            _context = context;
        }

        [Route("LetterHeadUpload/LogoSignMaps")]
        public async Task<IActionResult> Index()
        {
            _ = new List<LogoSignMapModel>();
            IList<LogoSignMapModel> obj = _repository.GetAll();
            PopulateDropDowns();
            return View(obj);
        }
        [Route("LetterHeadUpload/LogoSignMaps/Details")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var data = await _repository.Details(id);

            var objs = _mapper.Map<LogoSignMapModel>(data);
            if (objs == null)
            {
                return NotFound();
            }

            return View(objs);
        }

        [Route("LetterHeadUpload/LogoSignMaps/Create")]
        public IActionResult Create()
        {
            PopulateDropDowns();
            return View();
        }
        private void PopulateDropDowns()
        {

            ViewData["LogoUploadId"] = _CommonRepo.SelectListLogoUpload();
            ViewData["EsSignUploadId"] = _CommonRepo.SelectListEsSignUpload();
            ViewData["DcdSignUploadId"] = _CommonRepo.SelectListDcdSignUpload();

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("LetterHeadUpload/LogoSignMaps/Create")]
        public async Task<IActionResult> Create(LogoSignMapModel obj)
        {
            obj.CreatedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            obj.CreatedOn = DateTime.Now;
            PopulateDropDowns();

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
            PopulateDropDowns();

            return View(obj);
        }

        [HttpGet]
        [Route("LetterHeadUpload/LogoSignMaps/Edit")]
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
            PopulateDropDowns();
            return View(Data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("LetterHeadUpload/LogoSignMaps/Edit")]
        public async Task<IActionResult> Edit(LogoSignMapModel obj)
        {
            obj.ModifiedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            obj.ModifiedOn = DateTime.Now;

            var Data = await _repository.Details(obj.LogoSignMapId);
            if (Data.LogoSignMapId != obj.LogoSignMapId)
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
                    if (!MstLogoSignMap(obj.LogoSignMapId))
                    {
                        TempData["msg"] = "No record found.";
                        return RedirectToAction(nameof(Edit));
                    }
                    else
                    {
                        throw;
                    }
                }

            }
            PopulateDropDowns();
            return View(obj);
        }

        [Route("LetterHeadUpload/LogoSignMaps/Delete")]

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mstLogoSignMap = await _repository.Details(id);
            if (mstLogoSignMap == null)
            {
                return NotFound();
            }

            return View(mstLogoSignMap);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Route("LetterHeadUpload/LogoSignMaps/Delete")]

        public async Task<IActionResult> DeleteConfirmed(LogoSignMapModel obj)
        {
            await _repository.DeleteConfirmed(obj.LogoSignMapId);
            return RedirectToAction(nameof(Index));
        }

        private bool MstLogoSignMap(int id)
        {
            return _context.MstLogoSignMap.Any(e => e.LogoSignMapId == id);
        }
    }
}
