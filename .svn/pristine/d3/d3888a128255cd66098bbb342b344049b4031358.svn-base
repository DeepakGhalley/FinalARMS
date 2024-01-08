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

namespace ARMS.Areas.AssetStatus.Controllers
{
    [Area("AssetStatus")]
    public class AssetStatusController : Controller
    {
        const string UserId = "_UserId";
        const string UserName = "_UserName";

        /// <summary>
        /// context new
        /// </summary>
        private readonly tt_dbContext _context;
        //
        private readonly IMapper _mapper;
        ICommonFunction _CommonRepo = new CommonFunctionBLL();

        readonly IAssetStatus _repository = new AssetStatusBLL();
        public AssetStatusController(tt_dbContext context, IMapper mapper)
        {
            _context = context; _mapper = mapper;

        }

        // GET: Account/Users
        [Route("AssetStatus/AssetStatus")]
        public async Task<IActionResult> Index()
        {
            

            AssetStatusModel obj = new AssetStatusModel();
            var data = await _repository.GetAll();
            obj.AssetStatusVM = data;
            return View(obj);
        }

     
      

        // GET: Account/Users/Create
        [Route("AssetStatus/AssetStatus/Create")]
        public IActionResult Create()
        {
            //ViewData["RoleId"] = _CommonRepo.SelectListRole();
            return View();
        }

        // POST: Account/Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("AssetStatus/AssetStatus/Create")]
        public async Task<IActionResult> Create(AssetStatusModel obj)
        {
            obj.CreatedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            obj.CreatedOn = Convert.ToDateTime(DateFunctions.getDatetypefrom(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")));


            bool CreateCheckDuplicate = _repository.DuplicateCheckOnSave(obj.AssetStatus);
            if (CreateCheckDuplicate)
            {
                TempData["msg"] = "Duplicate data found, please find a different Asset Status Name.";               
                return View(obj);
            }

            if (ModelState.IsValid)
            {

                int returnvalue = _repository.SaveAssetStatus(obj);

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

        // GET: Account/Users/Edit/5
        [HttpGet]
        [Route("AssetStatus/AssetStatus/Edit")]
        public async Task<IActionResult> Edit(int? id)
        //public async Task<IActionResult> Edit(UserDTO obj)
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
           // ViewData["RoleId"] = _CommonRepo.SelectListRole();
            return View(Data);
        }

        // POST: Account/Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("AssetStatus/AssetStatus/Edit")]
        public async Task<IActionResult> Edit(AssetStatusModel obj)
        {
           
            obj.ModifiedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            obj.ModifiedOn = Convert.ToDateTime(DateFunctions.getDatetypefrom(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")));
            bool CheckDuplicate = _repository.DuplicateCheckOnUpdate(obj.AssetStatus, obj.AssetStatusId);//checks duplicate user name
            if (CheckDuplicate)
            {
                TempData["msg"] = "Duplicate data found, please find a different Asset Status Name.";               
                return View(obj);
            }
            //obj.RoleId = 90;
            var Data = await _repository.Details(obj.AssetStatusId);
            if (Data.AssetStatusId != obj.AssetStatusId)

            //if (id != tblMstUser.UserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    int returnvalue = _repository.UpdateAssetStatus(obj);
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
                    if (!MstAssetStatusExists(obj.AssetStatusId))
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
         
            return View(obj);
        }

        // GET: Account/Users/Delete/5
        [Route("AssetStatus/AssetStatus/Delete")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var MstAssetStatus = await _repository.Details(id);

            if (MstAssetStatus == null)
            {
                return NotFound();
            }

            return View(MstAssetStatus);
        }

        // POST: Account/Users/Delete/5

        [HttpPost, ActionName("Delete")]
        [Route("AssetStatus/AssetStatus/Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(AssetStatusModel obj)
        {
            await _repository.DeleteConfirmed(obj.AssetStatusId);          
            return RedirectToAction(nameof(Index));
        }

        private bool MstAssetStatusExists(int id)
        {
            //_repository.CheckExists(id);
            return _context.MstAssetStatus.Any(e => e.AssetStatusId == id);
        }
    }
}
