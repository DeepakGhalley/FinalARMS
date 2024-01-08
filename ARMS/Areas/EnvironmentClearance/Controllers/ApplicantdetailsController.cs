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
using Microsoft.AspNetCore.Http;
using ARMS.Functions;

namespace ARMS.Areas.EnvironmentClearance.Controllers
{
    [Area("EnvironmentClearance")]
    public class ApplicantdetailsController : Controller
    {
        private readonly tt_dbContext _context;
        private readonly IMapper _mapper;
        ICommonFunction _CommonRepo = new CommonFunctionBLL();
        readonly IApplicantDetails _repository = new ApplicantDetailBLL();
        public ApplicantdetailsController(tt_dbContext context)
        {
            _context = context;
        }

        // GET: EnvironmentClearance/Applicantdetails
        [Route("EnvironmentClearance/Applicantdetails")]
        public async Task<IActionResult> Index()
        {
            _ = new List<ApplicantdetailModel>();
            IList<ApplicantdetailModel> obj = _repository.GetAll();
            return View(obj);
        }

        // GET: EnvironmentClearance/Applicantdetails/Details/5
        [Route("EnvironmentClearance/Applicantdetails/Details")]
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

        // GET: EnvironmentClearance/Applicantdetails/Create
        [Route("EnvironmentClearance/Applicantdetails/Create")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: EnvironmentClearance/Applicantdetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("EnvironmentClearance/Applicantdetails/Create")]
        public async Task<IActionResult> Create(ApplicantdetailModel obj)
        {
            obj.CreatedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            obj.CreatedOn = Convert.ToDateTime(DateFunctions.getDatetypefrom(DateTime.Now.ToString("dd/MM/yyyy")));
            bool CreateCheckDuplicate = _repository.DuplicateCheckOnSave(obj.Cid);
            if (CreateCheckDuplicate)
            {
                TempData["msg"] = "Duplicate data found, please find a different code";
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
                    TempData["msg"] = "New record creation failed";
                    return RedirectToAction(nameof(Create));
                }

            }
            return View(obj);
        }

        // GET: EnvironmentClearance/Applicantdetails/Edit/5
        [Route("EnvironmentClearance/Applicantdetails/Edit")]
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

        // POST: EnvironmentClearance/Applicantdetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("EnvironmentClearance/Applicantdetails/Edit")]
        public async Task<IActionResult> Edit(ApplicantdetailModel obj)
        {
            obj.ModifiedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            obj.ModifiedOn = Convert.ToDateTime(DateFunctions.getDatetypefrom(DateTime.Now.ToString("dd/MM/yyyy")));
            bool CheckDuplicate = _repository.DuplicateCheckOnUpdate(obj.Cid, obj.ApplicantId);//checks duplicate user name
            if (CheckDuplicate)
            {
                TempData["msg"] = "Duplicate data found, please find a different name.";
                return View(obj);
            }
            var Data = await _repository.Details(obj.ApplicantId);
            if (Data.ApplicantId != obj.ApplicantId)
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
                    if (!MstEcapplicantdetailExists(obj.ApplicantId))
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

        // GET: EnvironmentClearance/Applicantdetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mstEcapplicantdetail = await _context.MstEcapplicantdetail
                .FirstOrDefaultAsync(m => m.ApplicantId == id);
            if (mstEcapplicantdetail == null)
            {
                return NotFound();
            }

            return View(mstEcapplicantdetail);
        }

        // POST: EnvironmentClearance/Applicantdetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mstEcapplicantdetail = await _context.MstEcapplicantdetail.FindAsync(id);
            _context.MstEcapplicantdetail.Remove(mstEcapplicantdetail);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MstEcapplicantdetailExists(int id)
        {
            return _context.MstEcapplicantdetail.Any(e => e.ApplicantId == id);
        }
    }
}
