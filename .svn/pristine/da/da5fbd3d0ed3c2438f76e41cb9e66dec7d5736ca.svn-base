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
    public class DemkhongsController : Controller
    {
        private readonly tt_dbContext _context;

        private readonly IMapper _mapper;
        ICommonFunction _CommonRepo = new CommonFunctionBLL();

        readonly IDemkhong _repository = new DemkhongBLL();
        public DemkhongsController(tt_dbContext context, IMapper mapper)
        {
            _context = context; _mapper = mapper;

        }

        [Route("Location/Demkhongs")]
        public async Task<IActionResult> Index()
        {
            _ = new List<DemkhongModel>();
            IList<DemkhongModel> obj = _repository.GetAll();

            return View(obj);
        }

        [Route("Location/Demkhongs/Details")]
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
        [Route("Location/Demkhongs/Create")]
        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        [Route("Location/Demkhongs/Create")]
        public async Task<IActionResult> Create(DemkhongModel obj)
        {
            obj.CreatedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            obj.CreatedOn = DateTime.Now;

            bool CreateCheckDuplicate = _repository.DuplicateCheckOnSave(obj.DemkhongName);
            if (CreateCheckDuplicate)
            {
                TempData["msg"] = "Duplicate data found, please enter a different Demkhong name.";

                return View(obj);
            }
            if (ModelState.IsValid)
            {
                int returnvalue = _repository.SaveDemkhong(obj);

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
        [Route("Location/Demkhongs/Edit")]
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
        [Route("Location/Demkhongs/Edit")]
        public async Task<IActionResult> Edit(DemkhongModel obj)
        {
            obj.ModifiedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            obj.ModifiedOn = Convert.ToDateTime(DateFunctions.getDatetypefrom(DateTime.Now.ToString("dd/MM/yyyy")));
            bool CheckDuplicate = _repository.DuplicateCheckOnUpdate(obj.DemkhongName, obj.DemkhongId);
            if (CheckDuplicate)
            {
                TempData["msg"] = "Duplicate data found, please enter a different Demkhong name.";

                return View(obj);
            }
            var Data = await _repository.Details(obj.DemkhongId);
            if (Data.DemkhongId != obj.DemkhongId)

            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    int returnvalue = _repository.UpdateDemkhong(obj);
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
                    if (!MstDemkhongExists(obj.DemkhongId))
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

        [Route("Location/Demkhongs/Delete")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var MstDemkhong = await _repository.Details(id);

            if (MstDemkhong == null)
            {
                return NotFound();
            }

            return View(MstDemkhong);
        }

        [HttpPost, ActionName("Delete")]
        [Route("Location/Demkhongs/Delete")]
        public async Task<IActionResult> DeleteConfirmed(DemkhongModel obj)
        {
            await _repository.DeleteConfirmed(obj.DemkhongId);
            return RedirectToAction(nameof(Index));
        }

        private bool MstDemkhongExists(int id)
        {
            return _context.MstDemkhong.Any(e => e.DemkhongId == id);
        }
    }
}
