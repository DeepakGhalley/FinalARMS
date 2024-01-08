//Dik Raj
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using Microsoft.EntityFrameworkCore;
//using CORE_BOL.Entities;
//using CORE_DLL;
//using CORE_BLL;
//using System.Transactions;
//using CORE_BOL;
//using Microsoft.AspNetCore.Authorization;

//namespace ARMS.Areas.Account.Controllers
//{
//    [Area("Account")]
//    [Authorize]
//    public class RolesController : Controller
//    {
//        private readonly tt_dbContext _context;
//        ICommonFunction _CommonRepo = new CommonFunctionBLL();
//        MenuBLL _obj = new MenuBLL();

//        private int _createdBy;
//        private DateTime _createdOn = DateTime.Now;

//        public RolesController(tt_dbContext context)
//        {
//            _context = context;
//        }

//        // GET: Account/Roles
//        [Route("Account/Roles")]
//        public async Task<IActionResult> Index()
//        {
//            PopulateDropDowns();


//            return View();
//        }

//        private void PopulateDropDowns()
//        {
//            // listing menus
//            List<TblMenu> menuLst = null;
//            menuLst = (from m in _context.TblMenu
//                       select m).ToList();
//            ViewBag.MenuList = new SelectList(menuLst);
//            //---------END------------

//            ViewData["RoleId"] = _CommonRepo.SelectListRole();

//        }

//        // GET: Account/Roles/Details/5
//        [Route("Account/Roles/Details")]
//        public async Task<IActionResult> Details(int? id)
//        {
//            PopulateDropDowns();

//            if (id == null)
//            {
//                return NotFound();
//            }

//            var tblRole = await _context.TblRole
//                .FirstOrDefaultAsync(m => m.RoleId == id);
//            if (tblRole == null)
//            {
//                return NotFound();
//            }

//            return View(tblRole);
//        }

//        // GET: Account/Roles/Create
//        [Route("Account/Roles/Create")]
//        public IActionResult Create()
//        {
//            return View();
//        }

//        // POST: Account/Roles/Create
//        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
//        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        [Route("Account/Roles/Create")]
//        public IActionResult Create(TblRole obj)
//        {
//            if (ModelState.IsValid)
//            {
//                _createdBy = 1; //Convert.ToInt32(HttpContext.Session.GetInt32("user_id"));

//                obj.IsActive = true;
//                obj.CreatedBy = _createdBy;
//                obj.CreatedOn = _createdOn;

//                _obj.SaveRoles(obj);

//                TempData["msg"] = "Role Saved Successfully!";

//                return RedirectToAction(nameof(Create));
//            }
//            return View();
//        }

//        // GET: Account/Roles/Edit/5
//        [Route("Account/Roles/Edit")]
//        public async Task<IActionResult> Edit(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var tblRole = await _context.TblRole.FindAsync(id);
//            if (tblRole == null)
//            {
//                return NotFound();
//            }
//            return View(tblRole);
//        }

//        // POST: Account/Roles/Edit/5
//        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
//        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        [Route("Account/Roles/Edit")]
//        public async Task<IActionResult> Edit(int id, [Bind("RoleId,RoleName,Description,IsActive,CreatedBy,CreatedOn,ModifiedOn,ModifiedBy")] TblRole tblRole)
//        {
//            if (id != tblRole.RoleId)
//            {
//                return NotFound();
//            }

//            if (ModelState.IsValid)
//            {
//                try
//                {
//                    _context.Update(tblRole);
//                    await _context.SaveChangesAsync();
//                }
//                catch (DbUpdateConcurrencyException)
//                {
//                    if (!TblRoleExists(tblRole.RoleId))
//                    {
//                        return NotFound();
//                    }
//                    else
//                    {
//                        throw;
//                    }
//                }
//                return RedirectToAction(nameof(Index));
//            }
//            return View(tblRole);
//        }

//        // GET: Account/Roles/Delete/5
//        [Route("Account/Roles/Delete")]
//        public async Task<IActionResult> Delete(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var tblRole = await _context.TblRole
//                .FirstOrDefaultAsync(m => m.RoleId == id);
//            if (tblRole == null)
//            {
//                return NotFound();
//            }

//            return View(tblRole);
//        }

//        // POST: Account/Roles/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        [Route("Account/Roles/Delete")]
//        public async Task<IActionResult> DeleteConfirmed(int id)
//        {
//            var tblRole = await _context.TblRole.FindAsync(id);
//            _context.TblRole.Remove(tblRole);
//            await _context.SaveChangesAsync();
//            return RedirectToAction(nameof(Index));
//        }

//        private bool TblRoleExists(int id)
//        {
//            return _context.TblRole.Any(e => e.RoleId == id);
//        }


//        [HttpPost]
//        [Route("Role/Roles/GetMenuMap")]
//        public List<MenuMapModel> GetMenuMap(int role_id) //, int p_roleid)
//        {
//            using (tt_dbContext entities = new tt_dbContext())
//            {
//                List<MenuMapModel> _dataList = null;
//                return _dataList = _obj.fetchMappedMenusByRoleID(role_id);
//            }
//        }

//        [Route("Account/Roles/InsertMenuPermission")]
//        public JsonResult InsertMenuPermission([FromBody] List<TblMenumap> json_array) //, int p_roleid)
//        {
//            using (tt_dbContext entities = new tt_dbContext())
//            {
//                //query to delete all old records with the given roleid
//                //entities.Database.ExecuteSqlCommand("TRUNCATE TABLE [Customers]");

//                //Check for NULL.  
//                if (json_array == null)
//                {
//                    json_array = new List<TblMenumap>();
//                }

//                int role_id = 0;

//                //Loop and insert records. 
//                foreach (TblMenumap menu in json_array)
//                {
//                    role_id = Convert.ToInt32(menu.RoleId);

//                    entities.TblMenumap.Add(menu);

//                    //entities.Entry<TblMenumap>(menu).State = EntityState.Detached;
//                }

//                try
//                {
//                    var result = _context.TblMenumap.FromSqlRaw($"sp_deletemappedmenus {role_id}").ToList();
//                }
//                catch (Exception ex)
//                { }

//                int insertedRecords = 0;
//                using (TransactionScope s = new TransactionScope())
//                {
//                    insertedRecords = entities.SaveChanges();
//                    s.Complete();
//                }
//                return Json(insertedRecords);
//            }
//        }
//    }
//}


//Lefty
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

namespace ARMS.Areas.Account.Controllers
{

    [Area("Account")]

    public class RolesController : Controller
    {
        private readonly tt_dbContext _context;

        readonly IRole _repository = new RoleBLL();

        public RolesController(tt_dbContext context)
        {
            _context = context;
        }

        // GET: Account/Roles
        [Route("Account/Roles")]
        public async Task<IActionResult> Index()
        {
            _ = new List<RoleVM>();
            IList<RoleVM> obj = _repository.GetAll();
            return View(obj);
        }

        [Route("Account/Roles/Details")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblrole = await _context.TblRole
                .FirstOrDefaultAsync(m => m.RoleId == id);
            if (tblrole == null)
            {
                return NotFound();
            }

            return View(tblrole);
        }

        [Route("Account/Roles/Create")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: ConditionRating/ConditionRatings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Account/Roles/Create")]
        public async Task<IActionResult> Create(RoleVM obj)
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

        [Route("Account/Roles/Edit")]
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

        // POST: ConditionRating/ConditionRatings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Account/Roles/Edit")]
        public async Task<IActionResult> Edit(RoleVM obj)
        {
            obj.ModifiedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            obj.ModifiedOn = Convert.ToDateTime(DateFunctions.getDatetypefrom(DateTime.Now.ToString("dd/MM/yyyy")));

            var Data = await _repository.Details(obj.RoleId);
            if (Data.RoleId != obj.RoleId)
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
                    if (!TblRoleExists(obj.RoleId))
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

        [Route("Account/Roles/Delete")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblrole = await _context.TblRole
                .FirstOrDefaultAsync(m => m.RoleId == id);
            if (tblrole == null)
            {
                return NotFound();
            }

            return View(tblrole);
        }

        // POST: ConditionRating/ConditionRatings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblrole = await _context.TblRole.FindAsync(id);
            _context.TblRole.Remove(tblrole);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblRoleExists(int id)
        {
            return _context.TblRole.Any(e => e.RoleId == id);
        }
    }

}
