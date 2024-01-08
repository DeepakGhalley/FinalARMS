using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CORE_BOL.Entities;
using CORE_BOL;
using AutoMapper;
using CORE_DLL;
using CORE_BLL;
using Microsoft.AspNetCore.Http;
using ARMS.Functions;
using Microsoft.AspNetCore.Builder;

namespace ARMS.Areas.Organization.Controllers
{
    [Area("Organization")]
    public class DivisionsController : Controller
    {
        private readonly tt_dbContext _context;

        private readonly IMapper _mapper;
        ICommonFunction _CommonRepo = new CommonFunctionBLL();

        readonly IDivision _repository = new DivisionBLL();
        public DivisionsController(tt_dbContext context, IMapper mapper)
        {
            _context = context; _mapper = mapper;

        }

        // GET: Account/MstDivisions
        [Route("Organization/Divisions")]
        public async Task<IActionResult> Index()
        {
            _ = new List<DivisionModel>();
            IList<DivisionModel> obj = _repository.GetAll();
            return View(obj);
        }

        // GET: Account/MstDivisions/Details/5
        [Route("Organization/Divisions/Details")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mstDivision = await _context.MstDivision
                .FirstOrDefaultAsync(m => m.DivisionId == id);
            if (mstDivision == null)
            {
                return NotFound();
            }

            return View(mstDivision);
        }

        // GET: Account/MstDivisions/Create
        [Route("Organization/Divisions/Create")]

        public IActionResult Create()
        {
            return View();
        }

        // POST: Account/MstDivisions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Organization/Divisions/Create")]

        public async Task<IActionResult> Create(DivisionModel obj)
        {
 
                obj.CreatedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
                obj.CreatedOn = Convert.ToDateTime(DateFunctions.getDatetypefrom(DateTime.Now.ToString("dd/MM/yyyy")));
                 bool CreateCheckDuplicate = _repository.DuplicateCheckOnSave(obj.DivisionName);
                if (CreateCheckDuplicate)
                {
                TempData["msg"] = "Duplicate data found, please find a different name";
                return View(obj);
                }
            if (ModelState.IsValid)
                {
                    int returnvalue = _repository.SaveDivision(obj);

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


        // GET: Account/MstDivisions/Edit/5
        [Route("Organization/Divisions/Edit")]

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

        // POST: Account/MstDivisions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Organization/Divisions/Edit")]
        public async Task<IActionResult> Edit(DivisionModel obj)
        {
            obj.ModifiedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            obj.ModifiedOn = Convert.ToDateTime(DateFunctions.getDatetypefrom(DateTime.Now.ToString("dd/MM/yyyy")));
            bool CheckDuplicate = _repository.DuplicateCheckOnUpdate(obj.DivisionName, obj.DivisionId);//checks duplicate user name
            if (CheckDuplicate)
            {
                TempData["msg"] = "Duplicate data found, please find a different name";
                return View(obj);
            }
            var Data = await _repository.Details(obj.DivisionId);
            if (Data.DivisionId != obj.DivisionId)

            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    int returnvalue = _repository.UpdateDivision(obj);
                    if (returnvalue > 0)
                    {
                        TempData["msg"] = "Record updated successfully";
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        TempData["msg"] = "Error while updationg";
                        // return RedirectToAction(nameof(Index));
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblMstDivisionExists(obj.DivisionId))
                    {
                        TempData["msg"] = "No user detail found.";
                        return RedirectToAction(nameof(Edit));
                        //return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

            }
            return View(obj);
        }

        private bool TblMstDivisionExists(int divisionId)
        {
            throw new NotImplementedException();
        }

        // POST: Account/MstDivisions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Route("Organization/Divisions/Delete")]

        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mstDivision = await _context.MstDivision.FindAsync(id);
            _context.MstDivision.Remove(mstDivision);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MstDivisionExists(int id)
        {
            return _context.MstDivision.Any(e => e.DivisionId == id);
        }
    }
}
