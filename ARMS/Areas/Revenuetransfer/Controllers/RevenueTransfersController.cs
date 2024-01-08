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

namespace ARMS.Areas.Revenuetransfer.Controllers
{
    [Area("Revenuetransfer")]
    public class RevenuetransfersController : Controller
    {
        private readonly tt_dbContext _context;
        readonly IRevenueTransfer _repository = new RevenueTransferBLL();

        public RevenuetransfersController(tt_dbContext context)
        {
            _context = context;
        }

       
        [Route("Revenuetransfer/RevenueTransfers")]
        public async Task<IActionResult> Index()
        {
            _ = new List<RevenueTransferVM>();
            IList<RevenueTransferVM> obj = _repository.GetAll();
            return View(obj);
        }
        [Route("Revenuetransfer/RevenueTransfers/Revenue")]
        public IActionResult Revenue()
        {
          
            return View();
        }

        [Route("Revenuetransfer/RevenueTransfers/Details")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var TblRevenueTransfer = await _context.TblRevenueTransfer
                .FirstOrDefaultAsync(m => m.RevenueTransferId == id);
            if (TblRevenueTransfer == null)
            {
                return NotFound();
            }

            return View(TblRevenueTransfer);
        }

       
        [Route("Revenuetransfer/RevenueTransfers/Create")]
        public IActionResult Create()
        {
            return View();
        }

    
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Revenuetransfer/RevenueTransfers/Create")]
        public async Task<IActionResult> Create(RevenueTransferVM obj)
        {
            obj.CreatedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            obj.CreatedOn = Convert.ToDateTime(DateFunctions.getDatetypefrom(DateTime.Now.ToString("dd/MM/yyyy")));
          
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
                    TempData["msg"] = "New record creation failed";
                    return RedirectToAction(nameof(Create));
                }
            }
            return View(obj);
        }

        [Route("Revenuetransfer/RevenueTransfers/Edit")]
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

        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Revenuetransfer/RevenueTransfers/Edit")]
        public async Task<IActionResult> Edit(RevenueTransferVM obj)
        {
            obj.ModifiedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            obj.ModifiedOn = Convert.ToDateTime(DateFunctions.getDatetypefrom(DateTime.Now.ToString("dd/MM/yyyy")));
            
            var Data = await _repository.Details(obj.RevenueTransferId);
            if (Data.RevenueTransferId != obj.RevenueTransferId)
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
                        TempData["msg"] = "Error while updating.";
                        // return RedirectToAction(nameof(Index));
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblRevenueTransfer(obj.RevenueTransferId))
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

      

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var TblRevenueTransfer = await _context.TblRevenueTransfer
                .FirstOrDefaultAsync(m => m.RevenueTransferId == id);
            if (TblRevenueTransfer == null)
            {
                return NotFound();
            }

            return View(TblRevenueTransfer);
        }

       

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var TblRevenueTransfer = await _context.TblRevenueTransfer.FindAsync(id);
            _context.TblRevenueTransfer.Remove(TblRevenueTransfer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblRevenueTransfer(int id)
        {
            return _context.TblRevenueTransfer.Any(e => e.RevenueTransferId == id);
        }

        //Real cal

        [Route("Revenuetransfer/RevenueTransfers/Online")]
        public IList<RevenueIOVM> Online(string StartDate, string EndDate)
        {

            IList<RevenueIOVM> _dList = null;

            return _dList = _repository.ROnline(StartDate, EndDate);

        }

        [Route("Revenuetransfer/RevenueTransfers/transfer")]
        public IEnumerable<RevenueIOVM> transfer(string StartDate, string EndDate)
        {

            IEnumerable<RevenueIOVM> _dList = null;

            return _dList = _repository.Rtransfer(StartDate, EndDate);

        }

        [Route("Revenuetransfer/RevenueTransfers/openingbalance")]
        public IEnumerable<RevenueIOVM> openingbalance(string StartDate, string EndDate)
        {

            IEnumerable<RevenueIOVM> _dList = null;

            return _dList = _repository.Ropeniingbalance(StartDate, EndDate);

        }

        [Route("Revenuetransfer/RevenueTransfers/mannual")]
        public IEnumerable<RevenueIOVM> mannual(string StartDate,string EndDate)
        {

            IEnumerable<RevenueIOVM> _dList = null;

            return _dList = _repository.Rmannual(StartDate, EndDate);

        }
    }
}
