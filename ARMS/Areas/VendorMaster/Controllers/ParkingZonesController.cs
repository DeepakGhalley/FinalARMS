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
    public class ParkingZonesController : Controller
    {
        private readonly tt_dbContext _context;

        private readonly IMapper _mapper;
        ICommonFunction _CommonRepo = new CommonFunctionBLL();

        readonly IParkingZone _repository = new ParkingZoneBLL();

        public ParkingZonesController(tt_dbContext context, IMapper mapper)
        {
            _context = context; _mapper = mapper;

        }

        // GET: VendorMaster/ParkingZones
        [Route("VendorMaster/ParkingZones")]
        public async Task<IActionResult> Index()
        {
            _ = new List<ParkingZoneVM>();
            IList<ParkingZoneVM> obj = _repository.GetAll();

            return View(obj);
        }

        // GET: VendorMaster/ParkingZones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mstParkingZone = await _context.MstParkingZone
                .FirstOrDefaultAsync(m => m.ParkingZoneId == id);
            if (mstParkingZone == null)
            {
                return NotFound();
            }

            return View(mstParkingZone);
        }

        // GET: VendorMaster/ParkingZones/Create
        [Route("VendorMaster/ParkingZones/Create")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: VendorMaster/ParkingZones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Route("VendorMaster/ParkingZones/Create")]
        public async Task<IActionResult> Create(ParkingZoneVM obj)
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

        // GET: VendorMaster/ParkingZones/Edit/5
        [HttpGet]
        [Route("VendorMaster/ParkingZones/Edit")]
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
        [Route("VendorMaster/ParkingZones/Edit")]
        public async Task<IActionResult> Edit(ParkingZoneVM obj)
        {
            obj.ModifiedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            obj.ModifiedOn = Convert.ToDateTime(DateFunctions.getDatetypefrom(DateTime.Now.ToString("dd/MM/yyyy")));

            var Data = await _repository.Details(obj.ParkingZoneId);
            if (Data.ParkingZoneId != obj.ParkingZoneId)

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
                    if (!MstParkingZoneExists(obj.ParkingZoneId))
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

        // GET: VendorMaster/ParkingZones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mstParkingZone = await _context.MstParkingZone
                .FirstOrDefaultAsync(m => m.ParkingZoneId == id);
            if (mstParkingZone == null)
            {
                return NotFound();
            }

            return View(mstParkingZone);
        }

        // POST: VendorMaster/ParkingZones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mstParkingZone = await _context.MstParkingZone.FindAsync(id);
            _context.MstParkingZone.Remove(mstParkingZone);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MstParkingZoneExists(int id)
        {
            return _context.MstParkingZone.Any(e => e.ParkingZoneId == id);
        }
    }
}
