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

namespace ARMS.Areas.TaxPayer.Controllers
{
    [Area("TaxPayer")]
    public class TaxPayerProfilesController : Controller
    {
        private readonly tt_dbContext _context;
        private readonly IMapper _mapper;
        ICommonFunction _CommonRepo = new CommonFunctionBLL();
        readonly ITaxPayerProfile _repository = new TaxPayerProfileBLL();

        public TaxPayerProfilesController(tt_dbContext context)
        {
            _context = context;
        }

        [Route("TaxPayer/TaxPayerProfiles")]
        public async Task<IActionResult> Index(int id = 1)
        {
            _ = new List<TaxPayerProfileModel>();
            IList<TaxPayerProfileModel> obj = _repository.GetAll(id);
            return View(obj);
        }

        [Route("TaxPayer/TaxPayerProfiles/Details")]
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

        //Create for Organisation
        [Route("TaxPayer/TaxPayerProfiles/CreateOrganisation")]
        public IActionResult CreateOrganisation()
        {
            PopulateDropDowns();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("TaxPayer/TaxPayerProfiles/CreateOrganisation")]
        public async Task<IActionResult> CreateOrganisation(TaxPayerProfileModel obj)
        {
            obj.CreatedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            obj.CreatedOn = DateTime.Now;
            //obj.GenderId = 3;
            //obj.TitleId = 13;
            //obj.OccupationId = 9;
            //obj.PVillageId = 4701;
            //obj.GewogId = 251;
            //obj.DzongkhagId = 99;
            obj.Cid = "-";

            //bool CreateCheckDuplicate = _repository.DuplicateCheckOnSave(obj.Cid);
            //if (CreateCheckDuplicate)
            //{
            //    TempData["msg"] = "Duplicate data found, please find a different Tax Payer Id";
            //    PopulateDropDowns();
            //    return View(obj);
            //}

            if (ModelState.IsValid)
            {
                obj.Dob = DateTime.Now;

                int returnvalue = _repository.Save(obj);

                if (returnvalue > 0)
                {
                    TempData["msg"] = "New record created successfully";
                    return RedirectToAction(nameof(Organisation));
                }
                else
                {
                    TempData["msg"] = "New record creation failed";
                    return RedirectToAction(nameof(CreateOrganisation));
                }

            }
            PopulateDropDowns();
            return View(obj);
        }

        //Create for Vendor
        [Route("TaxPayer/TaxPayerProfiles/CreateVendor")]
        public IActionResult CreateVendor()
        {
            PopulateDropDowns();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("TaxPayer/TaxPayerProfiles/CreateVendor")]
        public async Task<IActionResult> CreateVendor(TaxPayerProfileModel obj)
        {
            obj.CreatedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            obj.CreatedOn = DateTime.Now;

            bool CreateCheckDuplicate = _repository.DuplicateCheckOnSave(obj.Cid);
            if (CreateCheckDuplicate)
            {
                TempData["msg"] = "Duplicate data found, please find a different Tax Payer Id";
                PopulateDropDowns();
                return View(obj);
            }

            if (ModelState.IsValid)
            {
                //Removed Feilds
                obj.Dob = DateTime.Now;


                int returnvalue = _repository.Save(obj);
                
                
                if (returnvalue > 0)
                {
                    TempData["msg"] = "New record created successfully ";
                    return RedirectToAction(nameof(Vendor));
                }
                else
                {
                    TempData["msg"] = "New record creation failed";
                    return RedirectToAction(nameof(CreateVendor));
                }

            }
            PopulateDropDowns();
            return View(obj);
        }

        //Create for Individual

        [Route("TaxPayer/TaxPayerProfiles/Create")]
        public IActionResult Create()
        {
            PopulateDropDowns();
            return View();
        }
        private void PopulateDropDowns()
        {
            ViewData["TaxPayerTypeId"] = _CommonRepo.SelectListTaxPayerType();
            ViewData["PVillageId"] = _CommonRepo.SelectListVillage();
            ViewData["Dzongkhag"] = _CommonRepo.SelectListDzongkhag();
            ViewData["OccupationId"] = _CommonRepo.SelectListOccupation();
            ViewData["GenderId"] = _CommonRepo.SelectListGender();
            ViewData["Bank"] = _CommonRepo.SelectListBank();
            ViewData["TitleId"] = _CommonRepo.SelectListTitle();
            ViewData["VendorTypeId"] = _CommonRepo.SelectListVendorType();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("TaxPayer/TaxPayerProfiles/Create")]
        public async Task<IActionResult> Create(TaxPayerProfileModel obj)
        {
            obj.CreatedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            obj.CreatedOn = DateTime.Now;
            
            bool CreateCheckDuplicate = _repository.DuplicateCheckOnSave(obj.Cid);
            if (CreateCheckDuplicate)
            {
                TempData["msg"] = "Duplicate data found, please find a different Tax Payer Id";
                PopulateDropDowns();
                return View(obj);
            }
            
            if (ModelState.IsValid)
            {
                obj.Dob = DateTime.Now;

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
            PopulateDropDowns();
            return View(obj);
        }

        //Index Organisation
        [Route("TaxPayer/TaxPayerProfiles/fetchOrganisation")]
        public List<TaxPayerProfileModel> fetchOrganisation(string ttin, string name)
        {

            List<TaxPayerProfileModel> _dList = null;
            return _dList = _repository.fetchOrganisation(ttin, name);
        }


        [Route("TaxPayer/TaxPayerProfiles/fetchOrganisationAll")]
        public List<TaxPayerProfileModel> fetchOrganisationAll()
        {

            List<TaxPayerProfileModel> _dList = null;
            return _dList = _repository.fetchOrganisationAll();
        }

        //Edit for Organisation
        [Route("TaxPayer/TaxPayerProfiles/Edit")]
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
            PopulateDropDowns();
            return View(Data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("TaxPayer/TaxPayerProfiles/Edit")]
        public async Task<IActionResult> Edit(TaxPayerProfileModel obj)
        {
            obj.ModifiedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            obj.ModifiedDate = DateTime.Now;
            bool CheckDuplicate = _repository.DuplicateCheckOnUpdate(obj.Cid, obj.TaxPayerId);//checks duplicate user name
            if (CheckDuplicate)
            {
                TempData["msg"] = "Duplicate data found, please find a different Tax Payer Profile.";
                PopulateDropDowns();
                return View(obj);
            }
            var Data = await _repository.Details(obj.TaxPayerId);
            if (Data.TaxPayerId != obj.TaxPayerId)
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
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!mstTaxPayerProfileExists(obj.TaxPayerId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            PopulateDropDowns();
            return View(obj);
        }

        //Index Individual
        [Route("TaxPayer/TaxPayerProfiles/fetchIndividual")]
        public List<TaxPayerProfileModel> fetchIndividual(string cid, string ttin)
        {

            List<TaxPayerProfileModel> _dList = null;
            return _dList = _repository.fetchIndividual(cid, ttin);
        }

        [Route("TaxPayer/TaxPayerProfiles/fetchIndividualAll")]
        public List<TaxPayerProfileModel> fetchIndividualAll()
        {

            List<TaxPayerProfileModel> _dList = null;
            return _dList = _repository.fetchIndividualAll();
        }

        //Edit for Individual
        [Route("TaxPayer/TaxPayerProfiles/IndividualEdit")]
        public async Task<IActionResult> IndividualEdit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Data = await _repository.Details(id);
            if (Data == null)
            {
                return View(Data);
            }
            PopulateDropDowns();
            return View(Data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("TaxPayer/TaxPayerProfiles/IndividualEdit")]
        public async Task<IActionResult> IndividualEdit(TaxPayerProfileModel obj)
        {
            obj.ModifiedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            obj.ModifiedDate = DateTime.Now;
            bool CheckDuplicate = _repository.DuplicateCheckOnUpdate(obj.Cid, obj.TaxPayerId);//checks duplicate user name
            if (CheckDuplicate)
            {
                TempData["msg"] = "Duplicate data found, please find a different Tax Payer Profile.";
                PopulateDropDowns();
                return View(obj);
            }
            var Data = await _repository.Details(obj.TaxPayerId);
            if (Data.TaxPayerId != obj.TaxPayerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    int returnvalue = _repository.IndividualUpdate(obj);
                    if (returnvalue > 0)
                    {
                        TempData["msg"] = "Record updated successfully";
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        TempData["msg"] = "Error while updating";
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!mstTaxPayerProfileExists(obj.TaxPayerId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            PopulateDropDowns();
            return View(obj);
        }


        //Index Individual
        [Route("TaxPayer/TaxPayerProfiles/fetchVendor")]
        public List<TaxPayerProfileModel> fetchVendor(/*string cid, */string ttin, string name)
        {

            List<TaxPayerProfileModel> _dList = null;
            return _dList = _repository.fetchVendor(ttin, name);
        }


        [Route("TaxPayer/TaxPayerProfiles/fetchVendorAll")]
        public List<TaxPayerProfileModel> fetchVendorAll()
        {

            List<TaxPayerProfileModel> _dList = null;
            return _dList = _repository.fetchVendorAll();
        }

        //Edit for Vendor
        [Route("TaxPayer/TaxPayerProfiles/VendorEdit")]
        public async Task<IActionResult> VendorEdit(int? id)
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
            PopulateDropDowns();
            return View(Data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("TaxPayer/TaxPayerProfiles/VendorEdit")]
        public async Task<IActionResult> VendorEdit(TaxPayerProfileModel obj)
        {
            obj.ModifiedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            obj.ModifiedDate = DateTime.Now;
            bool CheckDuplicate = _repository.DuplicateCheckOnUpdate(obj.Cid, obj.TaxPayerId);//checks duplicate user name
            if (CheckDuplicate)
            {
                TempData["msg"] = "Duplicate data found, please find a different Tax Payer Profile.";
                PopulateDropDowns();
                return View(obj);
            }
            var Data = await _repository.Details(obj.TaxPayerId);
            var ttin = obj.Ttin;
            if (Data.TaxPayerId != obj.TaxPayerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    int returnvalue = _repository.VendorUpdate(obj);
                    if (returnvalue > 0)
                    {
                        TempData["msg"] = "Record updated successfully";
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        TempData["msg"] = "Error while updating";
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!mstTaxPayerProfileExists(obj.TaxPayerId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            PopulateDropDowns();
            return View(obj);
        }


        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mstTaxPayerProfile = await _context.MstTaxPayerProfile
                .Include(t => t.TaxPayerType)
                .Include(t => t.PVillage)
                .Include(t => t.CDzongkhag)
                .Include(t => t.Occupation)
                .Include(t => t.Gender)
                .Include(t => t.BankBranch)
                .Include(t => t.Title)
               
                .FirstOrDefaultAsync(m => m.TaxPayerId == id);
            if (mstTaxPayerProfile == null)
            {
                return NotFound();
            }

            return View(mstTaxPayerProfile);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mstTaxPayerProfile = await _context.MstTaxPayerProfile.FindAsync(id);
            _context.MstTaxPayerProfile.Remove(mstTaxPayerProfile);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool mstTaxPayerProfileExists(int id)
        {
            return _context.MstTaxPayerProfile.Any(e => e.TaxPayerId == id);
        }

        [Route("TaxPayer/TaxPayerProfiles/PopulatePV")]
        public List<MstVillage> PopulatePV(int id)
        {
            List<MstVillage> _dataList = null;

            return _dataList = _repository.fetchPV(id);

        }
        [HttpPost]
        [Route("TaxPayer/TaxPayerProfiles/PopulatePG")]
        public List<MstGewog> PopulatePG(int id)
        {
            List<MstGewog> _dataList = null;
            return _dataList = _repository.fetchPG(id);
        }
        [HttpPost]
        [Route("TaxPayer/TaxPayerProfiles/PopulateBB")]
        public List<MstBankBranch> PopulateBB(int id)
        {
            List<MstBankBranch> _dataList = null;
            return _dataList = _repository.fetchBB(id);
        }

        [Route("TaxPayer/TaxPayerProfiles/Organisation")]
        public async Task<IActionResult> Organisation(int id = 2)
        {
            _ = new List<TaxPayerProfileModel>();
            IList<TaxPayerProfileModel> obj = _repository.GetAll(id);
            return View(obj);
        }

        [Route("TaxPayer/TaxPayerProfiles/Vendor")]
        public async Task<IActionResult> Vendor(int id = 3)
        {
            _ = new List<TaxPayerProfileModel>();
            IList<TaxPayerProfileModel> obj = _repository.GetAll(id);
            return View(obj);
        }

    }
}


