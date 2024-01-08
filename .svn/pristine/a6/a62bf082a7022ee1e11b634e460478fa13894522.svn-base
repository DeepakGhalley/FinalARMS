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
    public class LapsController : Controller
    {
        private readonly tt_dbContext _context;

        private readonly IMapper _mapper;
        ICommonFunction _CommonRepo = new CommonFunctionBLL();

        readonly ILap _repository = new LapBLL();
        public LapsController(tt_dbContext context, IMapper mapper)
        {
            _context = context; _mapper = mapper;

        }

        [Route("Location/Laps")]
        public async Task<IActionResult> Index()
        {
            _ = new List<LapModel>();
            IList<LapModel> obj = _repository.GetAll();

            return View(obj);
        }

        [Route("Location/Laps/Details")]
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
        [Route("Location/Laps/Create")]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [Route("Location/Laps/Create")]
        public async Task<IActionResult> Create(LapModel obj)
        {
            obj.CreatedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            obj.CreatedOn = DateTime.Now;

            bool CreateCheckDuplicate = _repository.DuplicateCheckOnSave(obj.LapName);
            if (CreateCheckDuplicate)
            {
                TempData["msg"] = "Duplicate data found, please enter a different  Lap name.";

                return View(obj);
            }

            if (ModelState.IsValid)
            {
                int returnvalue = _repository.SaveLap(obj);

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
            return View(obj);
        }

        [HttpGet]
        [Route("Location/Laps/Edit")]
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
        [Route("Location/Laps/Edit")]
        public async Task<IActionResult> Edit(LapModel obj)
        {
            obj.ModifiedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            obj.ModifiedOn = Convert.ToDateTime(DateFunctions.getDatetypefrom(DateTime.Now.ToString("dd/MM/yyyy")));

            bool CheckDuplicate = _repository.DuplicateCheckOnUpdate(obj.LapName, obj.LapId);

            if (CheckDuplicate)
            {
                TempData["msg"] = "Duplicate data found, please enter a different Lap name.";

                return View(obj);
            }
            var Data = await _repository.Details(obj.LapId);
            if (Data.LapId != obj.LapId)

            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    int returnvalue = _repository.UpdateLap(obj);
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
                    if (!MstLapExists(obj.LapId))
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

        [Route("Location/Laps/Delete")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var MstLap = await _repository.Details(id);

            if (MstLap == null)
            {
                return NotFound();
            }

            return View(MstLap);
        }

        [HttpPost, ActionName("Delete")]
        [Route("Location/Laps/Delete")]
        public async Task<IActionResult> DeleteConfirmed(LapModel obj)
        {
            await _repository.DeleteConfirmed(obj.LapId);
            return RedirectToAction(nameof(Index));
        }

        private bool MstLapExists(int id)
        {
            return _context.MstLap.Any(e => e.LapId == id);
        }
    }
}
