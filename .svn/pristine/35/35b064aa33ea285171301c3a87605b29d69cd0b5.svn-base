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
namespace ARMS.Areas.AssetAccountHead.Controllers
{
    [Area("AssetAccountHead")]
    public class PrimaryAccountHeadsController : Controller
    {
        private readonly tt_dbContext _context;

        private readonly IMapper _mapper;
        ICommonFunction _CommonRepo = new CommonFunctionBLL();

        readonly IPrimaryAccountHead _repository = new PrimaryAccountHeadBLL();
        public PrimaryAccountHeadsController(tt_dbContext context, IMapper mapper)
        {
            _context = context; _mapper = mapper;

        }

        [Route("AssetAccountHead/PrimaryAccountHeads")]
        public async Task<IActionResult> Index()
        {
            _ = new List<PrimaryAccountHeadModel>();
            IList<PrimaryAccountHeadModel> obj = _repository.GetAll();

            return View(obj);
        }

        [Route("AssetAccountHead/PrimaryAccountHeads/Details")]
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
        [Route("AssetAccountHead/PrimaryAccountHeads/Create")]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [Route("AssetAccountHead/PrimaryAccountHeads/Create")]
        public async Task<IActionResult> Create(PrimaryAccountHeadModel obj)
        {
            obj.CreatedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            obj.CreatedOn = DateTime.Now;
            bool CreateCheckDuplicate = _repository.DuplicateCheckOnSave(obj.PrimaryAccountHeadName);
            if (CreateCheckDuplicate)
            {
                TempData["msg"] = "Duplicate data found, please enter a different Primary Head name";

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
        [Route("AssetAccountHead/PrimaryAccountHeads/Edit")]
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
        [Route("AssetAccountHead/PrimaryAccountHeads/Edit")]
        public async Task<IActionResult> Edit(PrimaryAccountHeadModel obj)
        {
            obj.ModifiedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            obj.ModifiedOn = Convert.ToDateTime(DateFunctions.getDatetypefrom(DateTime.Now.ToString("dd/MM/yyyy")));

            bool CheckDuplicate = _repository.DuplicateCheckOnUpdate(obj.PrimaryAccountHeadName, obj.PrimaryAccountHeadId);
            if (CheckDuplicate)
            {
                TempData["msg"] = "Duplicate data found, please enter a different Primary Head name";

                return View(obj);
            }
            var Data = await _repository.Details(obj.PrimaryAccountHeadId);
            if (Data.PrimaryAccountHeadId != obj.PrimaryAccountHeadId)

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
                    if (!MstAccountExists(obj.PrimaryAccountHeadId))
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

        [Route("AssetAccountHead/PrimaryAccountHeads/Delete")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var MstAccount = await _repository.Details(id);

            if (MstAccount == null)
            {
                return NotFound();
            }

            return View(MstAccount);
        }

        [HttpPost, ActionName("Delete")]
        [Route("AssetAccountHead/PrimaryAccountHeads/Delete")]
        public async Task<IActionResult> DeleteConfirmed(PrimaryAccountHeadModel obj)
        {
            await _repository.DeleteConfirmed(obj.PrimaryAccountHeadId);

            return RedirectToAction(nameof(Index));
        }

        private bool MstAccountExists(int id)
        {
            return _context.MstPrimaryAccountHead.Any(e => e.PrimaryAccountHeadId == id);
        }
    }
}
