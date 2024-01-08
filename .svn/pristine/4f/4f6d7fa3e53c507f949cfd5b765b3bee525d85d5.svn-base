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
    public class DzongkhagsController : Controller
    {
        private readonly tt_dbContext _context;

        private readonly IMapper _mapper;
        ICommonFunction _CommonRepo = new CommonFunctionBLL();

        readonly IDzongkhag _repository = new DzongkhagBLL();
        public DzongkhagsController(tt_dbContext context, IMapper mapper)
        {
            _context = context; _mapper = mapper;

        }

        [Route("Location/Dzongkhags")]
        public async Task<IActionResult> Index()
        {
            _ = new List<DzongkhagModel>();
            IList<DzongkhagModel> obj = _repository.GetAll();

            return View(obj);
        }

        [Route("Location/Dzongkhags/Details")]
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
        [Route("Location/Dzongkhags/Create")]
        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        [Route("Location/Dzongkhags/Create")]
        public async Task<IActionResult> Create(DzongkhagModel obj)
        {
            obj.CreatedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            obj.CreatedOn = DateTime.Now;

            bool CreateCheckDuplicate = _repository.DuplicateCheckOnSave(obj.DzongkhagName);
            if (CreateCheckDuplicate)
            {
                TempData["msg"] = "Duplicate data found, please enter a different  Dzongkhag name.";

                return View(obj);
            }
            if (ModelState.IsValid)
            {
                int returnvalue = _repository.SaveDzongkhag(obj);

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
        [Route("Location/Dzongkhags/Edit")]
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
        [Route("Location/Dzongkhags/Edit")]
        public async Task<IActionResult> Edit(DzongkhagModel obj)
        {
            obj.ModifiedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            obj.ModifiedOn = Convert.ToDateTime(DateFunctions.getDatetypefrom(DateTime.Now.ToString("dd/MM/yyyy")));
            bool CheckDuplicate = _repository.DuplicateCheckOnUpdate(obj.DzongkhagName, obj.DzongkhagId);

            if (CheckDuplicate)
            {
                TempData["msg"] = "Duplicate data found, please enter a different Dzongkhag name.";

                return View(obj);
            }
            var Data = await _repository.Details(obj.DzongkhagId);
            if (Data.DzongkhagId != obj.DzongkhagId)

            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    int returnvalue = _repository.UpdateDzongkhag(obj);
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
                    if (!MstDzongkhagExists(obj.DzongkhagId))
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

        [Route("Location/Dzongkhags/Delete")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            

            var MstDzongkhag = await _repository.Details(id);

            if (MstDzongkhag == null)
            {
                return NotFound();
            }

            return View(MstDzongkhag);
        }


        [HttpPost, ActionName("Delete")]
        [Route("Location/Dzongkhags/Delete")]
        public async Task<IActionResult> DeleteConfirmed(DzongkhagModel obj)
        {
            await _repository.DeleteConfirmed(obj.DzongkhagId);
            return RedirectToAction(nameof(Index));
        }

        private bool MstDzongkhagExists(int id)
        {
            return _context.MstDzongkhag.Any(e => e.DzongkhagId == id);
        }
    }
}
