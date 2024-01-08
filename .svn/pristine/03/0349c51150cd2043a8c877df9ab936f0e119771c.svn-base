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
using Microsoft.AspNetCore.Authorization;

namespace ARMS.Areas.LetterHeadUpload.Controllers
{
    [Area("LetterHeadUpload")]
    [Authorize]
    public class EsSignUploadsController : Controller
    {
        private readonly tt_dbContext _context;
        readonly IEsSignUpload _repository = new EsSignUploadsBLL();
        public EsSignUploadsController(tt_dbContext context)
        {
            _context = context;
        }

        // GET: LetterHeadUpload/EsSignUploads
        [Route("LetterHeadUpload/EsSignUploads")]
        public async Task<IActionResult> Index()
        {
            _ = new List<EsSignUploadsModel>();
            IList<EsSignUploadsModel> obj = _repository.GetAll();
            return View(obj);
        }

        // GET: LetterHeadUpload/EsSignUploads/Details/5
        [Route("LetterHeadUpload/EsSignUploads/Details")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mstEsSignUploads = await _context.MstEsSignUpload
                .FirstOrDefaultAsync(m => m.EsSignId == id);
            if (mstEsSignUploads == null)
            {
                return NotFound();
            }

            return View(mstEsSignUploads);
        }

        // GET: LetterHeadUpload/EsSignUploads/Create
        [Route("LetterHeadUpload/EsSignUploads/Create")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: LetterHeadUpload/DcdsignUploads/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("LetterHeadUpload/EsSignUploads/Create")]
        public async Task<IActionResult> Create(EsSignUploadsModel obj, [FromForm(Name = "SignPath")] IFormFile SourceFile)
        {
            obj.CreatedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            obj.CreatedDate = DateTime.Now;

            bool CreateCheckDuplicate = _repository.DuplicateCheckOnSave(obj.userId);
            if (CreateCheckDuplicate)
            {
                TempData["msg"] = "Duplicate data found, please enter a different value";
                return View(obj);
            }
            obj.SignPath = Convert.ToString(obj.userId + Path.GetExtension(SourceFile.FileName));
            if (ModelState.IsValid)
            {
               int returnvalue = _repository.Save(obj,  SourceFile);

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

        // GET: LetterHeadUpload/DcdsignUploads/Edit/5
        [HttpGet]
        [Route("LetterHeadUpload/EsSignUploads/Edit")]
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

        // POST: LetterHeadUpload/DcdsignUploads/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("LetterHeadUpload/EsSignUploads/Edit")]
        public async Task<IActionResult> Edit(EsSignUploadsModel obj, [FromForm(Name = "SignPath")] IFormFile SourceFile)
        {
            obj.ModifiedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            obj.ModifiedDate = DateTime.Now;

            bool CheckDuplicate = _repository.DuplicateCheckOnUpdate(obj.userId, obj.esSignId);
            if (CheckDuplicate)
            {
                TempData["msg"] = "Duplicate data found, please enter a different value";
                return View(obj);
            }

            var Data = await _repository.Details(obj.esSignId);
            if (Data.esSignId != obj.esSignId)
            {
                return NotFound();
            }
           obj.SignPath = Convert.ToString(obj.userId + Path.GetExtension(SourceFile.FileName));


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
                    if (!MstDcdsignUploadExists(obj.esSignId))
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

        // GET: LetterHeadUpload/DcdsignUploads/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mstEsSignUploads = await _context.MstEsSignUpload
                .FirstOrDefaultAsync(m => m.EsSignId == id);
            if (mstEsSignUploads == null)
            {
                return NotFound();
            }

            return View(mstEsSignUploads);
        }

        // POST: LetterHeadUpload/DcdsignUploads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mstEsSignUploads = await _context.MstEsSignUpload.FindAsync(id);
            _context.MstEsSignUpload.Remove(mstEsSignUploads);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MstDcdsignUploadExists(int id)
        {
            return _context.MstEsSignUpload.Any(e => e.EsSignId == id);
        }
    }
}
