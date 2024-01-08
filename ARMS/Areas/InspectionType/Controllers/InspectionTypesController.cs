﻿using System;
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
namespace ARMS.Areas.InspectionType.Controllers
{
    [Area("InspectionType")]
    public class InspectionTypesController : Controller
    {
        private readonly tt_dbContext _context;

        private readonly IMapper _mapper;
        ICommonFunction _CommonRepo = new CommonFunctionBLL();

        readonly IInspectionType _repository = new InspectionTypeBLL();
        public InspectionTypesController(tt_dbContext context, IMapper mapper)
        {
            _context = context; _mapper = mapper;

        }

        [Route("InspectionType/InspectionTypes")]
        public async Task<IActionResult> Index()
        {
            _ = new List<InspectionTypeMode>();
            IList<InspectionTypeMode> obj = _repository.GetAll();

            return View(obj);
        }

        [Route("InspectionType/InspectionTypes/Details")]
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
        [Route("InspectionType/InspectionTypes/Create")]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [Route("InspectionType/InspectionTypes/Create")]
        public async Task<IActionResult> Create(InspectionTypeMode obj)
        {
            obj.CreatedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            obj.CreatedOn = DateTime.Now;
            bool CreateCheckDuplicate = _repository.DuplicateCheckOnSave(obj.InspectionType);
            if (CreateCheckDuplicate)
            {
                TempData["msg"] = "Duplicate data found, please enter a different Inspection Type name";

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
                    TempData["msg"] = " New record creation failed";
                    return RedirectToAction(nameof(Create));
                }

            }
            return View(obj);
        }

        [HttpGet]
        [Route("InspectionType/InspectionTypes/Edit")]
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
        [Route("InspectionType/InspectionTypes/Edit")]
        public async Task<IActionResult> Edit(InspectionTypeMode obj)
        {
            obj.ModifiedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            obj.ModifiedOn = Convert.ToDateTime(DateFunctions.getDatetypefrom(DateTime.Now.ToString("dd/MM/yyyy")));

            bool CheckDuplicate = _repository.DuplicateCheckOnUpdate(obj.InspectionType, obj.InspectionTypeId);
            if (CheckDuplicate)
            {
                TempData["msg"] = "Duplicate data found, please enter a different Inspection Type name";

                return View(obj);
            }
            var Data = await _repository.Details(obj.InspectionTypeId);
            if (Data.InspectionTypeId != obj.InspectionTypeId)

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
                    if (!MstInspectionTypeExists(obj.InspectionTypeId))
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

        [Route("InspectionType/InspectionTypes/Delete")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var MstInspectionType = await _repository.Details(id);

            if (MstInspectionType == null)
            {
                return NotFound();
            }

            return View(MstInspectionType);
        }

        [HttpPost, ActionName("Delete")]
        [Route("InspectionType/InspectionTypes/Delete")]
        public async Task<IActionResult> DeleteConfirmed(InspectionTypeMode obj)
        {
            await _repository.DeleteConfirmed(obj.InspectionTypeId);

            return RedirectToAction(nameof(Index));
        }

        private bool MstInspectionTypeExists(int id)
        {
            return _context.MstInspectionType.Any(e => e.InspectionTypeId == id);
        }
    }
}