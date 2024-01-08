﻿using System;
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

namespace ARMS.Areas.AssetAccountHead.Controllers
{
    [Area("AssetAccountHead")]
    public class SecondaryAccountHeadsController : Controller
    {
        private readonly tt_dbContext _context;
        private readonly IMapper _mapper;
        ICommonFunction _CommonRepo = new CommonFunctionBLL();

        readonly ISecondaryAccountHead _repository = new SecondaryAccountHeadBLL();
        public SecondaryAccountHeadsController(tt_dbContext context)
        {
            _context = context;
        }

        [Route("AssetAccountHead/SecondaryAccountHeads")]
        public async Task<IActionResult> Index()
        {
            _ = new List<SecondaryAccountHeadModel>();
            IList<SecondaryAccountHeadModel> obj = _repository.GetAll();
            return View(obj);
        }
        [Route("AssetAccountHead/SecondaryAccountHeads/Details")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var data = await _repository.Details(id);

            var objs = _mapper.Map<SecondaryAccountHeadModel>(data);
            if (objs == null)
            {
                return NotFound();
            }

            return View(objs);
        }

        [Route("AssetAccountHead/SecondaryAccountHeads/Create")]
        public IActionResult Create()
        {
            PopulateDropDowns();
            return View();
        }
        private void PopulateDropDowns()
        {

            ViewData["PrimaryAccountHeadId"] = _CommonRepo.SelectListPrimaryHead();

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("AssetAccountHead/SecondaryAccountHeads/Create")]
        public async Task<IActionResult> Create(SecondaryAccountHeadModel obj)
        {
            obj.CreatedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            obj.CreatedOn = DateTime.Now;

            bool CreateCheckDuplicate = _repository.DuplicateCheckOnSave(obj.SecondaryAccountHeadName);
            if (CreateCheckDuplicate)
            {
                TempData["msg"] = "Duplicate data found, please enter a different Secondary Account name.";
                PopulateDropDowns();
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
            PopulateDropDowns();

            return View(obj);
        }

        [HttpGet]
        [Route("AssetAccountHead/SecondaryAccountHeads/Edit")]
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
            ViewData["PrimaryAccountHeadId"] = _CommonRepo.SelectListPrimaryHead();
            return View(Data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("AssetAccountHead/SecondaryAccountHeads/Edit")]
        public async Task<IActionResult> Edit(SecondaryAccountHeadModel obj)
        {
            obj.ModifiedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            obj.ModifiedOn = Convert.ToDateTime(DateFunctions.getDatetypefrom(DateTime.Now.ToString("dd/MM/yyyy")));

            bool CheckDuplicate = _repository.DuplicateCheckOnUpdate(obj.SecondaryAccountHeadName, obj.PrimaryAccountHeadId, obj.SecondaryAccountHeadId);
            if (CheckDuplicate)
            {
                TempData["msg"] = "Duplicate data found, please enter a different Secondary Account name.";
                PopulateDropDowns();
                return View(obj);
            }
            var Data = await _repository.Details(obj.SecondaryAccountHeadId);
            if (Data.SecondaryAccountHeadId != obj.SecondaryAccountHeadId)
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
                    if (!MstSecondaryAccountHeadExists(obj.SecondaryAccountHeadId))
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
            ViewData["PrimaryAccountHeadId"] = _CommonRepo.SelectListPrimaryHead();
            return View(obj);
        }

        [Route("AssetAccountHead/SecondaryAccountHeads/Delete")]

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mstSeconadry = await _repository.Details(id);
            if (mstSeconadry == null)
            {
                return NotFound();
            }

            return View(mstSeconadry);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Route("AssetAccountHead/SecondaryAccountHeads/Delete")]

        public async Task<IActionResult> DeleteConfirmed(SecondaryAccountHeadModel obj)
        {
            await _repository.DeleteConfirmed(obj.SecondaryAccountHeadId);
            return RedirectToAction(nameof(Index));
        }

        private bool MstSecondaryAccountHeadExists(int id)
        {
            return _context.MstSecondaryAccountHead.Any(e => e.SecondaryAccountHeadId == id);
        }
    }
}
