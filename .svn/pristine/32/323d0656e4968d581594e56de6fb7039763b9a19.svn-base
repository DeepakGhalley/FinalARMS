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
using System.Data;
using System.Data.SqlClient;
using Dapper;
using Microsoft.Extensions.Options;
//using static ARMS.Helpers.AppConfig.AppConfiguration;
using Microsoft.Extensions.Configuration;
using ARMS.Helpers.AppConfig;
using Microsoft.AspNetCore.Authorization;

namespace ARMS.Areas.Account.Controllers
{
    [Area("Account")]
    public class UsersController : Controller
    {
        //IConfiguration _Configure;
        private readonly string _connectionString;
        private readonly tt_dbContext _context;
        private readonly IMapper _mapper;
        ICommonFunction _CommonRepo = new CommonFunctionBLL();
        readonly IUser _repository = new UserBLL();
        public UsersController(tt_dbContext context, IMapper mapper, IOptions<AppConfiguration> config)
        {
            _context = context; _mapper = mapper; _connectionString = config.Value.ConnectionString;
        }

        [Authorize]
        // GET: Account/Users
        [Route("Account/Users")]
        public async Task<IActionResult> Index()
        {

            _ = new List<UserDTO>();
            IList<UserDTO> obj = _repository.GetAll();

            return View(obj);
        }

        [Authorize]
        [Route("Account/Users/Login")]
        public async Task<IActionResult> Login()
        {
            return View();
        }

        //// GET: Account/Users/Details/5
        //[Route("Account/Users/Details")]
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }
        //    ////UserViewModel objs = new UserViewModel();
        //    ////working list
        //    //var data = await _repository.Details(id);
        //    //var objs = _mapper.Map<List<UserDTO>>(data);
        //    ////working end


        //    var data = await  _repository.Details(id);
        //    // IList<UserDTO> objs = null;
        //    var objs = _mapper.Map<List<UserDTO>>(data);

        //    //objs.UserId = data.FirstOrDefault().UserId;
        //    //objs.UserName = data.FirstOrDefault().UserName;
        //    //objs.Password = data.FirstOrDefault().Password;
        //    //objs.IsActive = data.FirstOrDefault().IsActive;
        //    //objs.CreatedBy = data.FirstOrDefault().CreatedBy;
        //    //objs.CreatedOn = data.FirstOrDefault().CreatedOn;
        //    //objs.ModifiedBy = data.FirstOrDefault().ModifiedBy;
        //    //objs.ModifiedOn = data.FirstOrDefault().ModifiedOn;
        //    //objs.RoleId = data.FirstOrDefault().RoleId;



        //    //var config = new MapperConfiguration(mc => mc.CreateMap<Model, UserViewModel>());
        //    //var mapper = new Mapper(config);
        //    //var mr=mapper.Map<IEnumerable<Model>,IEnumerable<UserViewModel>> (objs);


        //    //var data = await _repository.Details(id);
        //    //obj.UserId = data.FirstOrDefault().UserId;
        //    //obj.UserName = data.FirstOrDefault().UserName;
        //    //obj.Password = data.FirstOrDefault().Password;
        //    //obj.IsActive = data.FirstOrDefault().IsActive;
        //    //obj.CreatedBy = data.FirstOrDefault().CreatedBy;
        //    //obj.CreatedOn = data.FirstOrDefault().CreatedOn;
        //    //obj.ModifiedBy = data.FirstOrDefault().ModifiedBy;
        //    //obj.ModifiedOn = data.FirstOrDefault().ModifiedOn;

        //    //var obj = _mapper.Map<UserViewModel>(data);
        //    //try
        //    //{
        //    //    UserDTO obj = _mapper.Map<UserDTO>(data);


        //    //obj.UserVM = data;
        //    //var obj = _mapper.Map<UserViewModel>(data);

        //    //var obj = _mapper.Map<UsersViewModel, TblMstUser>(data);

        //    //UserViewModel obj = _mapper.Map<UserViewModel>(data);
        //    //CreateMap<User, UserViewModel>();
        //    //UsersViewModel empmodel = new UsersViewModel();
        //    //UserViewModel obj = _mapper.Map<UserViewModel>(data);

        //    // obj=_mapper.Map<Student>(studentDTO);
        //    //var obj = await _context.TblMstUser
        //    //    .Include(t => t.Role)
        //    //    .FirstOrDefaultAsync(m => m.UserId == id);

        //    if (objs == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(objs);
        //    //}
        //    //catch (Exception EX) { return View(); }
        //}
        // GET: Account/Users/Details/5
        [Route("Account/Users/Details")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            ////UserViewModel objs = new UserViewModel();
            ////working list
            //var data = await _repository.Details(id);
            //var objs = _mapper.Map<List<UserDTO>>(data);
            ////working end

            var data = await _repository.Details(id);


            if (data == null)
            {
                return NotFound();
            }

            return View(data);
        }

        // GET: Account/Users/Create
        [Route("Account/Users/Create")]
        public IActionResult Create()
        {
            PopulateDropDowns();
            return View();
        }
        private void PopulateDropDowns()
        {
            ViewData["Role"] = _CommonRepo.SelectListRole();
            ViewData["TitleId"] = _CommonRepo.SelectListTitle();
            ViewData["Section"] = _CommonRepo.SelectListSection();
            //ViewData["Year"] = _CommonRepo.SelectListCalYear();
        }
        // POST: Account/Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Account/Users/Create")]
        public async Task<IActionResult> Create(UserDTO obj)
        {
            obj.CreatedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            obj.CreatedOn = DateTime.Now;

            bool CreateCheckDuplicate = _repository.DuplicateCheckOnSave(obj.UserName);
            if (CreateCheckDuplicate)
            {
                TempData["msg"] = "Duplicate data found, please find a different username.";
                PopulateDropDowns();
                return View(obj);
            }
            if (ModelState.IsValid)
            {
                Guid myobj = Guid.NewGuid();
                obj.Id = myobj.ToString();

                int returnvalue = _repository.SaveUser(obj);

                if (returnvalue > 0)
                {
                    TempData["msg"] = "New user created successfully.";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    TempData["msg"] = "New user creation failed.";
                    return RedirectToAction(nameof(Create));
                }

            }
            PopulateDropDowns();
            return View(obj);
        }

        // GET: Account/Users/Edit/5

        [Route("Account/Users/Edit")]
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

        // POST: Account/Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Account/Users/Edit")]
        public async Task<IActionResult> Edit(UserDTO obj)
        {
            obj.ModifiedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            obj.ModifiedOn = DateTime.Now;
            bool CheckDuplicate = _repository.DuplicateCheckOnUpdate(obj.UserName, obj.UserId);//checks duplicate user name
            if (CheckDuplicate)
            {
                TempData["msg"] = "Duplicate data found, please find a different username.";
                PopulateDropDowns();
                return View(obj);
            }
            var Data = await _repository.Details(obj.UserId);
            if (Data.UserId != obj.UserId)

            //if (id != tblMstUser.UserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    int returnvalue = _repository.UpdateUser(obj);
                    if (returnvalue > 0)
                    {
                        TempData["msg"] = "User detail updated successfully.";
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
                    if (!TblMstUserExists(obj.UserId))
                    {
                        TempData["msg"] = "No user detail found.";
                        return RedirectToAction(nameof(Edit));
                        //return NotFound();
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

        // GET: Account/Users/Delete/5
        [Route("Account/Users/Delete")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var tblMstUser = await _context.TblMstUser
            //    .Include(t => t.Role)
            //    .FirstOrDefaultAsync(m => m.UserId == id);

            var tblMstUser = await _repository.Details(id);

            if (tblMstUser == null)
            {
                return NotFound();
            }

            return View(tblMstUser);
        }

        // POST: Account/Users/Delete/5

        [HttpPost, ActionName("Delete")]
        [Route("Account/Users/Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(UserDTO obj)
        {
            await _repository.DeleteConfirmed(obj.UserId);
            //var tblMstUser = await _context.TblMstUser.FindAsync(id);
            //_context.TblMstUser.Remove(tblMstUser);
            //await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblMstUserExists(int id)
        {
            //_repository.CheckExists(id);
            return _context.MstUser.Any(e => e.UserId == id);
        }

        //USER UPDATION BY ADMIN

        [Route("Account/Users/UserDetails")]
        public IActionResult UserDetails()
        {
            PopulateDropDowns();
            return View();
        }
        [HttpGet]
        //[ValidateAntiForgeryToken]
        [Route("Account/Users/GetUserDetails")]
        public List<UserProfileVM> GetUserDetails(string email)
        {
            PopulateDropDowns();
            return _repository.GetUserDetails(email).ToList();
        }

        [HttpPost]
        [Route("Account/Users/UpdateUserInfoByAdmin")]
        public JsonResult UpdateUserInfoByAdmin([FromBody] List<UserProfileVM> json_data)
        {
            string email = "";
            int userid = 0;
            long returnvalue = 0;

            if (json_data == null)
            {
                json_data = new List<UserProfileVM>();
            }
            UserProfileVM obj = new UserProfileVM();

            if (ModelState.IsValid)
            {
                try
                {
                    foreach (UserProfileVM item in json_data)
                    {
                        email = item.Email;
                        userid = item.UserId;
                        obj.UserId = item.UserId;
                        obj.Title = item.Title;
                        obj.FirstName = item.FirstName;
                        obj.MiddleName = item.MiddleName;
                        obj.LastName = item.LastName;
                        obj.Cid = item.Cid;
                        obj.Eid = item.Eid;
                        obj.Dob = item.Dob;
                        obj.Email = item.Email;
                        obj.PhoneNo = item.PhoneNo;
                        obj.RoleId = item.RoleId;
                        obj.SectionId = item.SectionId;
                        obj.UserName = item.Email;
                      
                        //obj.NormalizedUserName = item.Email;
                        //obj.NormalizedEmail = item.Email;


                        bool chkduplicate = _repository.GetEmails(email, userid);
                        if (chkduplicate)
                        {
                            TempData["msg"] = "Duplicate email found!";
                            return Json(TempData["msg"]);


                        }
                        else
                        {
                            returnvalue = _repository.UpdateInfoByAmin(obj);
                        }


                        if (returnvalue > 0)
                        {
                            TempData["msg"] = "Record updated successfully";
                        }
                        else
                        {
                            TempData["msg"] = "Error while updating";
                            // return RedirectToAction(nameof(Index));
                        }
                    }

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AspNetUserExists(obj.UserId))
                    {
                        return null;
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            PopulateDropDowns();
            return Json(TempData["msg"]);

        }


        [HttpPost]
        [Route("Account/Users/Deactivate")]
        public JsonResult Deactivate([FromBody] List<UserProfileVM> json_data)
        {
            string email = "";
            int userid = 0;
            long returnvalue = 0;

            if (json_data == null)
            {
                json_data = new List<UserProfileVM>();
            }
            UserProfileVM obj = new UserProfileVM();

            if (ModelState.IsValid)
            {
                try
                {
                    foreach (UserProfileVM item in json_data)
                    {
                        email = item.Email;
                        userid = item.UserId;
                        obj.UserId = item.UserId;
                        obj.Title = item.Title;
                        obj.FirstName = item.FirstName;
                        obj.MiddleName = item.MiddleName;
                        obj.LastName = item.LastName;
                        obj.Cid = item.Cid;
                        obj.Eid = item.Eid;
                        obj.Dob = item.Dob;
                        obj.Email = item.Email;
                        obj.PhoneNo = item.PhoneNo;
                        obj.RoleId = item.RoleId;
                        obj.SectionId = item.SectionId;
                        obj.UserName = item.Email;

                        //obj.NormalizedUserName = item.Email;
                        //obj.NormalizedEmail = item.Email;


                        bool chkduplicate = _repository.GetEmails(email, userid);
                        if (chkduplicate)
                        {
                            TempData["msg"] = "Duplicate email found!";
                            return Json(TempData["msg"]);


                        }
                        else
                        {
                            returnvalue = _repository.Deactivate(obj);
                        }


                        if (returnvalue > 0)
                        {
                            TempData["msg"] = "Record updated successfully";
                        }
                        else
                        {
                            TempData["msg"] = "Error while updating";
                            // return RedirectToAction(nameof(Index));
                        }
                    }

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AspNetUserExists(obj.UserId))
                    {
                        return null;
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            PopulateDropDowns();
            return Json(TempData["msg"]);

        }

        [HttpPost]
        [Route("Account/Users/Activate")]
        public JsonResult Activate([FromBody] List<UserProfileVM> json_data)
        {
            string email = "";
            int userid = 0;
            long returnvalue = 0;

            if (json_data == null)
            {
                json_data = new List<UserProfileVM>();
            }
            UserProfileVM obj = new UserProfileVM();

            if (ModelState.IsValid)
            {
                try
                {
                    foreach (UserProfileVM item in json_data)
                    {
                        email = item.Email;
                        userid = item.UserId;
                        obj.UserId = item.UserId;
                        obj.Title = item.Title;
                        obj.FirstName = item.FirstName;
                        obj.MiddleName = item.MiddleName;
                        obj.LastName = item.LastName;
                        obj.Cid = item.Cid;
                        obj.Eid = item.Eid;
                        obj.Dob = item.Dob;
                        obj.Email = item.Email;
                        obj.PhoneNo = item.PhoneNo;
                        obj.RoleId = item.RoleId;
                        obj.SectionId = item.SectionId;
                        obj.UserName = item.Email;

                        //obj.NormalizedUserName = item.Email;
                        //obj.NormalizedEmail = item.Email;


                        bool chkduplicate = _repository.GetEmails(email, userid);
                        if (chkduplicate)
                        {
                            TempData["msg"] = "Duplicate email found!";
                            return Json(TempData["msg"]);


                        }
                        else
                        {
                            returnvalue = _repository.Activate(obj);
                        }


                        if (returnvalue > 0)
                        {
                            TempData["msg"] = "Record updated successfully";
                        }
                        else
                        {
                            TempData["msg"] = "Error while updating";
                            // return RedirectToAction(nameof(Index));
                        }
                    }

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AspNetUserExists(obj.UserId))
                    {
                        return null;
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            PopulateDropDowns();
            return Json(TempData["msg"]);

        }


        private bool AspNetUserExists(long id)
        {
            return _context.AspNetUsers.Any(e => e.UserId == id);
        }

        [Route("Account/Users/GetDetails")]
        public List<UserProfileVM> GetDetails(int UserId)
        {
            PopulateDropDowns();
            return _repository.GetDetails(UserId).ToList();

        }

        [Route("Account/Users/GetTaxRates")]
        public async Task<IEnumerable<UsersModel>> GetTaxRates(int TransactionTypeId)// without context
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                try
                {
                    return await db.QueryAsync<UsersModel>("[dbo].[rptGetTaxRates]", new { @TransactionTypeId = TransactionTypeId }, commandType: CommandType.StoredProcedure);
                }
                catch (Exception ex) { return null; }
            }
        }

        [Route("Account/Users/GetAllUserDetails")]
        public List<UserProfileVM> GetAllUserDetails()
        {
            return _repository.GetAllUserDetails().ToList();

        }

    }
}

