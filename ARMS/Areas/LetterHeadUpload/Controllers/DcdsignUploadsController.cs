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
    public class DcdsignUploadsController : Controller
    {
        private readonly tt_dbContext _context;
        readonly IDcdSignUpload _repository = new DcdsignUploadBLL();
        public DcdsignUploadsController(tt_dbContext context)
        {
            _context = context;
        }

        // GET: LetterHeadUpload/DcdsignUploads
        [Route("LetterHeadUpload/DcdsignUploads")]
        public async Task<IActionResult> Index()
        {
            _ = new List<DcdsignUploadModel>();
            IList<DcdsignUploadModel> obj = _repository.GetAll();
            return View(obj);
        }

        // GET: LetterHeadUpload/DcdsignUploads/Details/5
        [Route("LetterHeadUpload/DcdsignUploads/Details")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mstDcdsignUpload = await _context.MstDcdsignUpload
                .FirstOrDefaultAsync(m => m.DcdSignId == id);
            if (mstDcdsignUpload == null)
            {
                return NotFound();
            }

            return View(mstDcdsignUpload);
        }

        // GET: LetterHeadUpload/DcdsignUploads/Create
        [Route("LetterHeadUpload/DcdsignUploads/Create")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: LetterHeadUpload/DcdsignUploads/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("LetterHeadUpload/DcdsignUploads/Create")]
        public async Task<IActionResult> Create(DcdsignUploadModel obj, [FromForm(Name = "SignPath")] IFormFile SourceFile)
        {
            obj.CreatedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            obj.CreatedDate = Convert.ToDateTime(String.Format("{0:MM/dd/yyyy}", DateTime.Now));
            if (SourceFile == null || SourceFile.Length == 0)
            {
                TempData["msg"] = "You have not selected any file";
                return View(obj);
            }
            bool CreateCheckDuplicate = _repository.DuplicateCheckOnSave(obj.UserId);            
            if (CreateCheckDuplicate)
            {
                TempData["msg"] = "Duplicate data found, please enter a different value";
                return View(obj);
            }           
            obj.SignPath = Convert.ToString(obj.UserId + Path.GetExtension(SourceFile.FileName));

            if (ModelState.IsValid)
            {
                int returnvalue = _repository.Save(obj, SourceFile);

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
        [Route("LetterHeadUpload/DcdsignUploads/Edit")]
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
        [Route("LetterHeadUpload/DcdsignUploads/Edit")]
        public async Task<IActionResult> Edit(DcdsignUploadModel obj, [FromForm(Name = "SignPath")] IFormFile SourceFile)
        {
            obj.ModifiedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            obj.ModifiedDate = Convert.ToDateTime(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
            if (SourceFile == null || SourceFile.Length == 0)
            {
                TempData["msg"] = "You have not selected any file";
                return View(obj);
            }
            bool CheckDuplicate = _repository.DuplicateCheckOnUpdate(obj.UserId, obj.UserId);
            if (CheckDuplicate)
            {
                TempData["msg"] = "Duplicate data found, please enter a different value";
                return View(obj);
            }
            obj.SignPath = Convert.ToString(obj.UserId + Path.GetExtension(SourceFile.FileName));

            var Data = await _repository.Details(obj.DcdSignId);
            if (Data.DcdSignId != obj.DcdSignId)
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
                    if (!MstDcdsignUploadExists(obj.DcdSignId))
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

            var mstDcdsignUpload = await _context.MstDcdsignUpload
                .FirstOrDefaultAsync(m => m.DcdSignId == id);
            if (mstDcdsignUpload == null)
            {
                return NotFound();
            }

            return View(mstDcdsignUpload);
        }

        // POST: LetterHeadUpload/DcdsignUploads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mstDcdsignUpload = await _context.MstDcdsignUpload.FindAsync(id);
            _context.MstDcdsignUpload.Remove(mstDcdsignUpload);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MstDcdsignUploadExists(int id)
        {
            return _context.MstDcdsignUpload.Any(e => e.DcdSignId == id);
        }
    }
}
