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
using System.IO;

namespace ARMS.Areas.LetterHeadUpload.Controllers
{
    [Area("LetterHeadUpload")]
    public class LogoUploadsController : Controller
    {
        private readonly tt_dbContext _context;
        readonly ILogoUpload _repository = new LogoUploadBLL();

        public LogoUploadsController(tt_dbContext context)
        {
            _context = context;
        }

        // GET: LetterHeadUpload/LogoUploads
        [Route("LetterHeadUpload/LogoUploads")]
        public async Task<IActionResult> Index()
        {
            _ = new List<LogoUploadModel>();
            IList<LogoUploadModel> obj = _repository.GetAll();
            return View(obj);
        }

        // GET: LetterHeadUpload/LogoUploads/Details/5
        [Route("LetterHeadUpload/LogoUploads/Details")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mstLogoUpload = await _context.MstLogoUpload
                .FirstOrDefaultAsync(m => m.LogoId == id);
            if (mstLogoUpload == null)
            {
                return NotFound();
            }

            return View(mstLogoUpload);
        }

        // GET: LetterHeadUpload/LogoUploads/Create
        [Route("LetterHeadUpload/LogoUploads/Create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("LetterHeadUpload/LogoUploads/Create")]
        public async Task<IActionResult> Create(LogoUploadModel obj, [FromForm(Name = "LogoPath")] IFormFile SourceFile)
        {
            obj.CreatedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            obj.CreatedOn = DateTime.Now;
            //if (SourceFile == null || SourceFile.Length == 0)
            //{
            //    TempData["msg"] = "You have not selected any file";
            //    return View(obj);
            //}
            bool CreateCheckDuplicate = _repository.DuplicateCheckOnSave(obj.LogoName);
            if (CreateCheckDuplicate)
            {
                TempData["msg"] = "Duplicate data found, please enter a different value";
                return View(obj);
            }

            if (ModelState.IsValid)
            {
                int returnvalue = _repository.Save(obj, SourceFile);
                //obj.LogoPath = (obj + Path.GetExtension(SourceFile.FileName));

                if (returnvalue > 0)
                {
                    TempData["msg"] = "New record created successfully.";
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

        // GET: LetterHeadUpload/LogoUploads/Edit/5
        [HttpGet]
        [Route("LetterHeadUpload/LogoUploads/Edit")]
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

        // POST: LetterHeadUpload/LogoUploads/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("LetterHeadUpload/LogoUploads/Edit")]
        public async Task<IActionResult> Edit(LogoUploadModel obj, [FromForm(Name = "LogoPath")] IFormFile SourceFile)
        {
            obj.ModifiedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            obj.ModifiedOn = DateTime.Now;
            //if (SourceFile == null || SourceFile.Length == 0)
            //{
            //    TempData["msg"] = "You have not selected any file";
            //    return View(obj);
            //}
            bool CheckDuplicate = _repository.DuplicateCheckOnUpdate(obj.LogoId, obj.LogoName);
            if (CheckDuplicate)
            {
                TempData["msg"] = "Duplicate data found, please enter a different value";
                return View(obj);
            }
            //obj.LogoPath = Convert.ToString(obj.UserId + Path.GetExtension(SourceFile.FileName));

            var Data = await _repository.Details(obj.LogoId);
            if (Data.LogoId != obj.LogoId)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    int returnvalue = _repository.Update(obj, SourceFile);
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
                    if (!MstLogoUploadExists(obj.LogoId))
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
        // GET: LetterHeadUpload/LogoUploads/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mstLogoUpload = await _context.MstLogoUpload
                .FirstOrDefaultAsync(m => m.LogoId == id);
            if (mstLogoUpload == null)
            {
                return NotFound();
            }

            return View(mstLogoUpload);
        }

        // POST: LetterHeadUpload/LogoUploads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mstLogoUpload = await _context.MstLogoUpload.FindAsync(id);
            _context.MstLogoUpload.Remove(mstLogoUpload);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MstLogoUploadExists(int id)
        {
            return _context.MstLogoUpload.Any(e => e.LogoId == id);
        }
    }
}
