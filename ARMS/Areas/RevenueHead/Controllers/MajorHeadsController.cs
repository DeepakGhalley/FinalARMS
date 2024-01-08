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
using Microsoft.AspNetCore.Authorization;

namespace ARMS.Areas.RevenueHead.Controllers

{
    [Area("RevenueHead")]
    [Authorize]
    public class MajorHeadsController : Controller
    {
        private readonly tt_dbContext _context;

        private readonly IMapper _mapper;
        ICommonFunction _CommonRepo = new CommonFunctionBLL();

        readonly IMajorHead _repository = new MajorHeadBLL();
        public MajorHeadsController(tt_dbContext context, IMapper mapper)
        {
            _context = context; _mapper = mapper;

        }

        [Route("RevenueHead/MajorHeads")]
        public async Task<IActionResult> Index()
        {
            _ = new List<MajorHeadModel>();
            IList<MajorHeadModel> obj = _repository.GetAll();

            return View(obj);
        }

        [Route("RevenueHead/MajorHeads/Details")]
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
        [Route("RevenueHead/MajorHeads/Create")]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [Route("RevenueHead/MajorHeads/Create")]
        public async Task<IActionResult> Create(MajorHeadModel obj)
        {
            obj.CreatedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            obj.CreatedOn = DateTime.Now;

            bool CreateCheckDuplicate = _repository.DuplicateCheckOnSave(obj.MajorHeadName);
            if (CreateCheckDuplicate)
            {
                TempData["msg"] = "Duplicate data found, please enter a different Major Head name";

                return View(obj);
            }
            if (ModelState.IsValid)
            {
                int returnvalue = _repository.SaveMajorHead(obj);

                if (returnvalue > 0)
                {
                    TempData["msg"] = "New record created successfully";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    TempData["msg"] = " New record creation failed";
                    return RedirectToAction(nameof(Create));
                }

            }
            return View(obj);
        }

        [HttpGet]
        [Route("RevenueHead/MajorHeads/Edit")]
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
        [Route("RevenueHead/MajorHeads/Edit")]
        public async Task<IActionResult> Edit(MajorHeadModel obj)
        {
            obj.ModifiedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            obj.ModifiedOn = DateTime.Now;

            bool CheckDuplicate = _repository.DuplicateCheckOnUpdate(obj.MajorHeadName, obj.MajorHeadId);
            if (CheckDuplicate)
            {
                TempData["msg"] = "Duplicate data found, please enter a different Major Head name";

                return View(obj);
            }
            var Data = await _repository.Details(obj.MajorHeadId);
            if (Data.MajorHeadId != obj.MajorHeadId)

            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    int returnvalue = _repository.UpdateMajorHead(obj);
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
                    if (!MstMajorHeadExists(obj.MajorHeadId))
                    {
                        TempData["msg"] = "No record found";
                        return RedirectToAction(nameof(Edit));
                    }
                    else
                    {
                        throw;
                    }
                }

            }
            return View(obj);
        }

        [Route("RevenueHead/MajorHeads/Delete")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var MstMajorHead = await _repository.Details(id);

            if (MstMajorHead == null)
            {
                return NotFound();
            }

            return View(MstMajorHead);
        }

        [HttpPost, ActionName("Delete")]
        [Route("RevenueHead/MajorHeads/Delete")]
        public async Task<IActionResult> DeleteConfirmed(MajorHeadModel obj)
        {
            await _repository.DeleteConfirmed(obj.MajorHeadId);

            return RedirectToAction(nameof(Index));
        }

        private bool MstMajorHeadExists(int id)
        {
            return _context.MstMajorHead.Any(e => e.MajorHeadId == id);
        }
       
    }
}
