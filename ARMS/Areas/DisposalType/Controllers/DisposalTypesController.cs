using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CORE_BOL.Entities;
using CORE_DLL;
using CORE_BLL;
using CORE_BOL;
using Microsoft.AspNetCore.Http;
using ARMS.Functions;

namespace ARMS.Areas.DisposalType.Controllers
{
    [Area("DisposalType")]
    public class DisposalTypesController : Controller
    {
        private readonly tt_dbContext _context;
        readonly IDisposalType _repository = new DisposalTypeBLL();
        public DisposalTypesController(tt_dbContext context)
        {
            _context = context;
        }

        // GET: DisposalType/DisposalTypes
        [Route(" DisposalType/DisposalTypes")]
        public async Task<IActionResult> Index()
        {
            _ = new List<DisposalTypeModel>();
            IList<DisposalTypeModel> obj = _repository.GetAll();
            return View(obj);
        }

        // GET: DisposalType/DisposalTypes/Details/5
        [Route(" DisposalType/DisposalTypes/Details")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mstDisposalType = await _context.MstDisposalType
                .FirstOrDefaultAsync(m => m.DisposalTypeId == id);
            if (mstDisposalType == null)
            {
                return NotFound();
            }

            return View(mstDisposalType);
        }

        // GET: DisposalType/DisposalTypes/Create
        [Route(" DisposalType/DisposalTypes/Create")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: DisposalType/DisposalTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route(" DisposalType/DisposalTypes/Create")]
        public async Task<IActionResult> Create(DisposalTypeModel obj)
        {
            obj.CreatedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            obj.CreatedOn = Convert.ToDateTime(DateFunctions.getDatetypefrom(DateTime.Now.ToString("dd/MM/yyyy")));
            bool CreateCheckDuplicate = _repository.DuplicateCheckOnSave(obj.DisposalType);
            if (CreateCheckDuplicate)
            {
                TempData["msg"] = "Duplicate data found, please enter a different value";
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
                    TempData["msg"] = "New record creation failed.";
                    return RedirectToAction(nameof(Create));
                }
            }
            return View(obj);
        }

        // GET: DisposalType/DisposalTypes/Edit/5
        [Route(" DisposalType/DisposalTypes/Edit")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Data = await _repository.Details(id);
            //var mstDisposalType = await _context.MstDisposalType.FindAsync(id);
            if (Data == null)
            {
                return NotFound();
            }
            return View(Data);
        }

        // POST: DisposalType/DisposalTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route(" DisposalType/DisposalTypes/Edit")]
        public async Task<IActionResult> Edit(DisposalTypeModel obj)
        {
            obj.ModifiedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            obj.ModifiedOn = Convert.ToDateTime(DateFunctions.getDatetypefrom(DateTime.Now.ToString("dd/MM/yyyy")));
            bool CheckDuplicate = _repository.DuplicateCheckOnUpdate(obj.DisposalType, obj.DisposalTypeId);//checks duplicate user name
            if (CheckDuplicate)
            {
                TempData["msg"] = "Duplicate data found, please enter a different value";
                return View(obj);
            }
            var Data = await _repository.Details(obj.DisposalTypeId);
            if (Data.DisposalTypeId != obj.DisposalTypeId)

            //if (id != tblMstUser.UserId)
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
                        // return RedirectToAction(nameof(Index));
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MstDisposalTypeExists(obj.DisposalTypeId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(obj);
        }

        // GET: DisposalType/DisposalTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mstDisposalType = await _context.MstDisposalType
                .FirstOrDefaultAsync(m => m.DisposalTypeId == id);
            if (mstDisposalType == null)
            {
                return NotFound();
            }

            return View(mstDisposalType);
        }

        // POST: DisposalType/DisposalTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mstDisposalType = await _context.MstDisposalType.FindAsync(id);
            _context.MstDisposalType.Remove(mstDisposalType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MstDisposalTypeExists(int id)
        {
            return _context.MstDisposalType.Any(e => e.DisposalTypeId == id);
        }
    }
}
