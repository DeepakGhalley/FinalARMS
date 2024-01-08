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
namespace ARMS.Areas.VendorMaster.Controllers
{
    [Area("VendorMaster")]
    public class StallLocationsController : Controller
    {
        private readonly tt_dbContext _context;

        private readonly IMapper _mapper;
        ICommonFunction _CommonRepo = new CommonFunctionBLL();

        readonly IStallLocation _repository = new StallLocationBLL();
        public StallLocationsController(tt_dbContext context, IMapper mapper)
        {
            _context = context; _mapper = mapper;

        }

        [Route("VendorMaster/StallLocations")]
        public async Task<IActionResult> Index()
        {
            _ = new List<StallLocationVM>();
            IList<StallLocationVM> obj = _repository.GetAll();

            return View(obj);
        }

        [Route("VendorMaster/StallLocations/Details")]
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
        [Route("VendorMaster/StallLocations/Create")]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [Route("VendorMaster/StallLocations/Create")]
        public async Task<IActionResult> Create(StallLocationVM obj)
        {
            obj.CreatedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            obj.CreatedOn = DateTime.Now;

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
        [Route("VendorMaster/StallLocations/Edit")]
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
        [Route("VendorMaster/StallLocations/Edit")]
        public async Task<IActionResult> Edit(StallLocationVM obj)
        {
            obj.ModifiedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            obj.ModifiedOn = Convert.ToDateTime(DateFunctions.getDatetypefrom(DateTime.Now.ToString("dd/MM/yyyy")));

            var Data = await _repository.Details(obj.StallLocationId);
            if (Data.StallLocationId != obj.StallLocationId)

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
                    if (!MstStallLocationExists(obj.StallLocationId))
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

        [Route("VendorMaster/StallLocations/Delete")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var MstStallLocation = await _repository.Details(id);

            if (MstStallLocation == null)
            {
                return NotFound();
            }

            return View(MstStallLocation);
        }

        [HttpPost, ActionName("Delete")]
        [Route("VendorMaster/StallLocations/Delete")]
        public async Task<IActionResult> DeleteConfirmed(StallLocationVM obj)
        {
            await _repository.DeleteConfirmed(obj.StallLocationId);

            return RedirectToAction(nameof(Index));
        }

        private bool MstStallLocationExists(int id)
        {
            return _context.MstStallLocation.Any(e => e.StallLocationId == id);
        }

    }
}
