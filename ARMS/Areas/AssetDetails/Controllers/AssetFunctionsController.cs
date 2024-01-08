using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CORE_BOL.Entities;
using CORE_BOL;
using CORE_DLL;
using CORE_BLL;
using Microsoft.AspNetCore.Http;
using ARMS.Functions;

namespace ARMS.Areas.AssetDetails.Controllers
{
    [Area("AssetDetails")]
    public class AssetFunctionsController : Controller
    {
        private readonly tt_dbContext _context;
        readonly IAssetFunction _repository = new AssetFunctionBLL();
        public AssetFunctionsController(tt_dbContext context)
        {
            _context = context;
        }

        // GET: AssetDetails/AssetFunctions
        [Route("AssetDetails/ AssetFunctions")]
        public async Task<IActionResult> Index()
        {
            _ = new List<AssetFunctionModel>();
            IList<AssetFunctionModel> obj = _repository.GetAll();
            return View(obj);
        }

        // GET: AssetDetails/AssetFunctions/Details/5
        [Route("AssetDetails/AssetFunctions/Details")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mstAssetFunction = await _context.MstAssetFunction
                .FirstOrDefaultAsync(m => m.AssetFunctionId == id);
            if (mstAssetFunction == null)
            {
                return NotFound();
            }

            return View(mstAssetFunction);
        }

        // GET: AssetDetails/AssetFunctions/Create
        [Route("AssetDetails/ AssetFunctions/Create")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: AssetDetails/AssetFunctions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("AssetDetails/ AssetFunctions/Create")]
        public async Task<IActionResult> Create(AssetFunctionModel obj)
        {
            obj.CreatedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            obj.CreatedOn = Convert.ToDateTime(DateFunctions.getDatetypefrom(DateTime.Now.ToString("dd/MM/yyyy")));
            bool CreateCheckDuplicate = _repository.DuplicateCheckOnSave(obj.AssetFunctionName);
            if (CreateCheckDuplicate)
            {
                TempData["msg"] = "Duplicate data found, please enter a different function name";
                return View(obj);
            }
            if (ModelState.IsValid)
            {
                int returnvalue = _repository.SaveAssetFunction(obj);

                if (returnvalue > 0)
                {
                    TempData["msg"] = "New new created successfully";
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

        // GET: AssetDetails/AssetFunctions/Edit/5
        [Route("AssetDetails/ AssetFunctions/Edit")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var mstAssetFunction = await _context.MstAssetFunction.FindAsync(id);
            var Data = await _repository.Details(id);

            if (Data == null)
            {
                return NotFound();
            }
            return View(Data);
        }

        // POST: AssetDetails/AssetFunctions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("AssetDetails/ AssetFunctions/Edit")]
        public async Task<IActionResult> Edit(AssetFunctionModel obj)
        {
            obj.ModifiedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            obj.ModifiedOn = Convert.ToDateTime(DateFunctions.getDatetypefrom(DateTime.Now.ToString("dd/MM/yyyy")));
            bool CheckDuplicate = _repository.DuplicateCheckOnUpdate(obj.AssetFunctionName, obj.AssetFunctionId);//checks duplicate user name
            if (CheckDuplicate)
            {
                TempData["msg"] = "Duplicate data found, please enter a different function name";
                return View(obj);
            }
            var Data = await _repository.Details(obj.AssetFunctionId);
            if (Data.AssetFunctionId != obj.AssetFunctionId)

            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    int returnvalue = _repository.UpdateAssetFunction(obj);
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
                    if (!MstAssetFunctionExists(obj.AssetFunctionId))
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

        private bool MstAssetFunctionExists(object assetFunctionId)
        {
            throw new NotImplementedException();
        }

        // GET: AssetDetails/AssetFunctions/Delete/5
        [Route("AssetDetails/ AssetFunctions/Delete")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mstAssetFunction = await _context.MstAssetFunction
                .FirstOrDefaultAsync(m => m.AssetFunctionId == id);
            if (mstAssetFunction == null)
            {
                return NotFound();
            }

            return View(mstAssetFunction);
        }

        // POST: AssetDetails/AssetFunctions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Route("AssetDetails/ AssetFunctions/Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mstAssetFunction = await _context.MstAssetFunction.FindAsync(id);
            _context.MstAssetFunction.Remove(mstAssetFunction);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MstAssetFunctionExists(int id)
        {
            return _context.MstAssetFunction.Any(e => e.AssetFunctionId == id);
        }
    }
}
