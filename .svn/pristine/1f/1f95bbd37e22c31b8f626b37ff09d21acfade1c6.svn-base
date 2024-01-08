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
namespace ARMS.Areas.Location.Controllers
{
    [Area("Location")]
    public class ZonesController : Controller
    {
        private readonly tt_dbContext _context;

        private readonly IMapper _mapper;
        ICommonFunction _CommonRepo = new CommonFunctionBLL();

        readonly IZone _repository = new ZoneBLL();
        public ZonesController(tt_dbContext context, IMapper mapper)
        {
            _context = context; _mapper = mapper;

        }

        [Route("Location/Zones")]
        public async Task<IActionResult> Index()
        {
            _ = new List<ZoneModel>();
            IList<ZoneModel> obj = _repository.GetAll();

            return View(obj);
        }

        [Route("Location/Zones/Details")]
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
        [Route("Location/Zones/Create")]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [Route("Location/Zones/Create")]
        public async Task<IActionResult> Create(ZoneModel obj)
        {
            obj.CreatedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            obj.CreatedOn = DateTime.Now;

            bool CreateCheckDuplicate = _repository.DuplicateCheckOnSave(obj.ZoneName);
            if (CreateCheckDuplicate)
            {
                TempData["msg"] = "Duplicate data found, please enter a different Zone name.";

                return View(obj);
            }

            if (ModelState.IsValid)
            {
                int returnvalue = _repository.SaveZone(obj);

                if (returnvalue > 0)
                {
                    TempData["msg"] = "New record created successfully.";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    TempData["msg"] = "New record creation failed.";
                    return RedirectToAction(nameof(Create));
                }

            }
            return View(obj);
        }

        [HttpGet]
        [Route("Location/Zones/Edit")]
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
        [Route("Location/Zones/Edit")]
        public async Task<IActionResult> Edit(ZoneModel obj)
        {
            obj.ModifiedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            obj.ModifiedOn = Convert.ToDateTime(DateFunctions.getDatetypefrom(DateTime.Now.ToString("dd/MM/yyyy")));

            bool CheckDuplicate = _repository.DuplicateCheckOnUpdate(obj.ZoneName, obj.ZoneId);
            if (CheckDuplicate)
            {
                TempData["msg"] = "Duplicate data found, please enter a different Demkhong name.";

                return View(obj);
            }
            var Data = await _repository.Details(obj.ZoneId);
            if (Data.ZoneId != obj.ZoneId)

            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    int returnvalue = _repository.UpdateZone(obj);
                    if (returnvalue > 0)
                    {
                        TempData["msg"] = "Record updated successfully.";
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        TempData["msg"] = "Error while updating.";
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MstZoneExists(obj.ZoneId))
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
            return View(obj);
        }

        [Route("Location/Zones/Delete")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var MstZone = await _repository.Details(id);

            if (MstZone == null)
            {
                return NotFound();
            }

            return View(MstZone);
        }

        [HttpPost, ActionName("Delete")]
        [Route("Location/Zones/Delete")]
        public async Task<IActionResult> DeleteConfirmed(ZoneModel obj)
        {
            await _repository.DeleteConfirmed(obj.ZoneId);
            return RedirectToAction(nameof(Index));
        }

        private bool MstZoneExists(int id)
        {
            return _context.MstZone.Any(e => e.ZoneId == id);
        }
    }
}
