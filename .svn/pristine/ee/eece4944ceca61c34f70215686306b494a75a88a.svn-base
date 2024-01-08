using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ARMS.Models;
using Microsoft.AspNetCore.Http;
using CORE_BOL.Entities;
using CORE_DLL;
using CORE_BLL;
using CORE_BOL;
using ARMS.ViewModel;
using ARMS.ViewModels;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;
using AutoMapper;
using EmailService;
using Message = EmailService.Message;
using Microsoft.EntityFrameworkCore;

namespace ARMS.Controllers
{
    public class AccountController : Controller
    {

        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        //private readonly tt_dbContext _context;
        readonly IUser _repo = new UserBLL();
        private readonly IEmailSender _emailSender;
        private readonly IMapper _mapper;
        readonly tt_dbContext _context = new tt_dbContext();
        public AccountController(IMapper mapper, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, IEmailSender emailSender)
        {
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
        }
        //public AccountController(UserManager<IdentityUser> userManager,
        //                      SignInManager<IdentityUser> signInManager)
        //{
        //    _userManager = userManager;
        //    _signInManager = signInManager;
        //}
        //[Authorize]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser
                {
                    UserName = model.Email,
                    Email = model.Email,
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true,
                    NormalizedEmail=model.Email,
                    NormalizedUserName=model.Email,
                  
                };

                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);

                    return RedirectToAction("index", "Home");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");

            }
            return View(model);
        }


        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {

            //var branch = new Branch
            //{
            //    branchName = "Regie",
            //    address = "Naval"

            //};
            //branchContext.Branch.Add(branch);
            //branchContext.SaveChanges();

            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel user)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(user.Email, user.Password, user.RememberMe, false);
                
                if (result.Succeeded)
                {
                 var obj= await _repo.DetailsByUserId(user.Email);
                    if (obj.Cid == null)
                    {
                        ModelState.AddModelError(string.Empty, "Please update your information before you login for the first time.");

                        return View(user);

                    }
                    if (obj.IsActive == false)
                    {
                        ModelState.AddModelError(string.Empty, "User account is deactivated, please contact system admin.");

                        return View(user);
                    }

                    HttpContext.Session.SetInt32("UserId",obj.UserId);
                    HttpContext.Session.SetInt32("RoleId", obj.RoleId) ;
                    HttpContext.Session.SetString("UserCid", obj.Cid);
                    HttpContext.Session.SetString("UserFName", obj.FirstName);
                  //  string mn = obj.MiddleName;
                    if(obj.MiddleName != "")
                    {
                        HttpContext.Session.SetString("UserMName", obj.MiddleName);
                    }
                    else {
                        HttpContext.Session.SetString("UserMName", "");
                    }
                    if (obj.LastName != "")
                    {
                        HttpContext.Session.SetString("UserLName", obj.LastName);
                    }
                    else
                    {
                        HttpContext.Session.SetString("UserLName", "");
                    }


                    //HttpContext.Session.SetString("UserLName", obj.LastName);
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");

            }
            return View(user);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Logout()
        {
            HttpContext.Session.Clear();
            await _signInManager.SignOutAsync();

            return RedirectToAction("Login");
        }
        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordModel forgotPasswordModel)
        {
            TempData["msg"] = null;
            if (!ModelState.IsValid)
                //
                return View(forgotPasswordModel);
            try
            {
                //var chkEmail = _context.AspNetUsers.Where(x => x.Email == forgotPasswordModel.Email);
                var user = await _userManager.FindByEmailAsync(forgotPasswordModel.Email);
                if (user == null)
                {
                    TempData["msg"] = "Email ID did not match.!";
                    return View();
                }

                //if (user != null)
                //    return RedirectToAction(nameof(ForgotPasswordConfirmation));

                var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                var callback = Url.Action(nameof(ResetPassword), "Account", new { token, email = user.Email }, Request.Scheme);

                var message = new Message(new string[] { forgotPasswordModel.Email }, "Reset password token", callback, null);
                await _emailSender.SendEmailAsync(message);
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return RedirectToAction(nameof(ForgotPasswordConfirmation));
        }
        public IActionResult ForgotPasswordConfirmation()
        {
            return View();
        }
        [HttpGet]
        public IActionResult ResetPassword(string token, string email)
        {
            var model = new ResetPasswordModel { Token = token, Email = email };
            return View(model);
        }
       

        [HttpGet]
        public IActionResult ResetPasswordConfirmation()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword(ResetPasswordModel resetPasswordModel)
        {
            if (!ModelState.IsValid)
                return View(resetPasswordModel);
            var user = await _userManager.FindByEmailAsync(resetPasswordModel.Email);
            if (user == null)
                RedirectToAction(nameof(ResetPasswordConfirmation));
            var resetPassResult = await _userManager.ResetPasswordAsync(user, resetPasswordModel.Token, resetPasswordModel.Password);
            if (!resetPassResult.Succeeded)
            {
                foreach (var error in resetPassResult.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }
                return View();
            }
            return RedirectToAction(nameof(ResetPasswordConfirmation));
        }

        //Update Personal Info

        [HttpGet]
        public IActionResult ManageProfile()
        {
         int  UserId= Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            _ = new List<UserProfileVM>();
            IList<UserProfileVM> obj = _repo.GetUserInfo(UserId);
            return View(obj);
        }

        [HttpPost]
        [Route("Account/Account/UpdatePersonalInfo")]
        public JsonResult UpdatePersonalInfo([FromBody] List<UserProfileVM> json_data)
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
                        obj.FirstName = item.FirstName;
                        obj.MiddleName = item.MiddleName;
                        obj.LastName = item.LastName;
                        obj.Cid = item.Cid;
                        obj.Eid = item.Eid;
                        obj.Dob = item.Dob;
                        obj.UserName = item.Email;
                        obj.NormalizedEmail = item.Email;
                        obj.NormalizedUserName = item.Email;
                        obj.PhoneNo = item.PhoneNo;
                  
                        bool chkduplicate = _repo.GetPersonalEmails(email, userid);
                        if (chkduplicate )
                        {
                            TempData["msg"] = "Duplicate email found!";
                            return Json(TempData["msg"]);

                        }
                        else
                        {
                            returnvalue = _repo.UpdatePersonalInfo(obj);
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
            return Json(TempData["msg"]);

        }
        private bool AspNetUserExists(int id)
        {
            return _context.AspNetUsers.Any(e => e.UserId == id);
        }

        [Route("Account/Account/GetPersonalDetails")]
        public List<UserProfileVM> GetPersonalDetails(int UserId)
        {
            return _repo.GetPersonalDetails(UserId).ToList();

        }





    }
}
