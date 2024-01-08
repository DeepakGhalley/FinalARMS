using System;
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
using ARMS.Functions;
using Microsoft.AspNetCore.Http;

namespace ARMS.Areas.Suppliers.Controllers
{
    [Area("Suppliers")]
    public class SuppliersController : Controller
    {
       
        private readonly tt_dbContext _context;

        private readonly IMapper _mapper;
        ICommonFunction _CommonRepo = new CommonFunctionBLL();

        readonly ISuppliers _repository = new SuppliersBLL();
        public SuppliersController(tt_dbContext context, IMapper mapper)
        {
            _context = context; _mapper = mapper;

        }
        // GET: Suppliers/Suppliers
        [Route("Suppliers/Suppliers")]
        public async Task<IActionResult> Index()
        {
            _ = new List<SuppliersVM>();
            IList<SuppliersVM> obj = _repository.GetAll();
            return View(obj);
        }

        // GET: Suppliers/Suppliers/Details/5
        [Route("Suppliers/Suppliers/Details")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mstSuppliers = await _context.MstSuppliers
                .FirstOrDefaultAsync(m => m.SupplierId == id);
            if (mstSuppliers == null)
            {
                return NotFound();
            }

            return View(mstSuppliers);
        }

        // GET: Suppliers/Suppliers/Create
        [Route("Suppliers/Suppliers/Create")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Suppliers/Suppliers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Suppliers/Suppliers/Create")]
        public async Task<IActionResult> Create(SuppliersVM obj)
        {
            obj.CreatedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            obj.CreatedOn = Convert.ToDateTime(DateFunctions.getDatetypefrom(DateTime.Now.ToString()));
            bool CreateCheckDuplicate = _repository.DuplicateCheckOnSave(obj.LicenseNo);
            if (CreateCheckDuplicate)
            {
                TempData["msg"] = "Duplicate data found, please find a different License No.";
                return View(obj);
            }
            if (ModelState.IsValid)
            {

                int returnvalue = _repository.Save(obj);

                if (returnvalue > 0)
                {
                    TempData["msg"] = "New Record created successfully.";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    TempData["msg"] = "New Record creation failed.";
                    return RedirectToAction(nameof(Create));
                }

            }
            //  ViewData["RoleId"] = _CommonRepo.SelectListRole();
            return View(obj);
        }

        // GET: Suppliers/Suppliers/Edit/5
        [HttpGet]
        [Route("Suppliers/Suppliers/Edit")]
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

        // POST: Suppliers/Suppliers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Suppliers/Suppliers/Edit")]
        public async Task<IActionResult> Edit(SuppliersVM obj)
        {
            obj.ModifiedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            obj.ModifiedOn = Convert.ToDateTime(DateFunctions.getDatetypefrom(DateTime.Now.ToString("dd/MM/yyyy")));
            bool CheckDuplicate = _repository.DuplicateCheckOnUpdate(obj.LicenseNo, obj.SupplierId);//checks duplicate user name
            if (CheckDuplicate)
            {
                TempData["msg"] = "Duplicate data found, please find a different License Number.";
                return View(obj);
            }
            var Data = await _repository.Details(obj.SupplierId);
            if (Data.SupplierId != obj.SupplierId)

           
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
                        TempData["msg"] = "Record updated successfully.";
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        TempData["msg"] = "Error on updation.";
                        // return RedirectToAction(nameof(Index));
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MstSuppliersExists(obj.SupplierId))
                    {
                        TempData["msg"] = "No detail found.";
                        return RedirectToAction(nameof(Edit));
                        //return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

            }
            ViewData["RoleId"] = _CommonRepo.SelectListRole();// new SelectList(_context.TblMstRole, "RoleId", "RoleName", tblMstUser.RoleId);
            return View(obj);
        }

        // GET: Suppliers/Suppliers/Delete/5
        [Route("Account/Users/Delete")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mstSuppliers = await _context.MstSuppliers
                .FirstOrDefaultAsync(m => m.SupplierId == id);
            if (mstSuppliers == null)
            {
                return NotFound();
            }

            return View(mstSuppliers);
        }

        // POST: Suppliers/Suppliers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Route("Account/Users/Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mstSuppliers = await _context.MstSuppliers.FindAsync(id);
            _context.MstSuppliers.Remove(mstSuppliers);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MstSuppliersExists(int id)
        {
            return _context.MstSuppliers.Any(e => e.SupplierId == id);
        }
    }
}
