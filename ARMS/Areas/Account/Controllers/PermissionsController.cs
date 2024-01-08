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
using System.Transactions;
using CORE_BOL;
using Microsoft.AspNetCore.Authorization;

namespace ARMS.Areas.Account.Controllers
{
    [Area("Account")]
    [Authorize]
    public class PermissionsController : Controller
    {
        private readonly tt_dbContext _context;
        ICommonFunction _CommonRepo = new CommonFunctionBLL();
        PermissionBLL _obj = new PermissionBLL();

        private int _createdBy;
        private DateTime _createdOn = DateTime.Now;

        public PermissionsController(tt_dbContext context)
        {
            _context = context;
        }

        // GET: Account/Permissions
        [Route("Account/Permissions")]
        public async Task<IActionResult> Index()
        {
            PopulateDropDowns();
            return View();
        }

        private void PopulateDropDowns()
        {
            // listing menus
            List<TblMenu> menuLst = null;
            menuLst = (from m in _context.TblMenu
                       select m).ToList();
            ViewBag.MenuList = new SelectList(menuLst);
            //---------END------------

            ViewData["RoleId"] = _CommonRepo.SelectListRole();

        }

        [Route("Account/Permissions/Details")]
        public async Task<IActionResult> Details(int? id)
        {
            PopulateDropDowns();

            if (id == null)
            {
                return NotFound();
            }

            var tblRole = await _context.TblRole
                .FirstOrDefaultAsync(m => m.RoleId == id);
            if (tblRole == null)
            {
                return NotFound();
            }

            return View(tblRole);
        }

        private bool TblRoleExists(int id)
        {
            return _context.TblRole.Any(e => e.RoleId == id);
        }

        [HttpPost]
        [Route("Account/Permissions/GetMenuMap")]
        public List<MenuMapModel> GetMenuMap(int role_id) //, int p_roleid)
        {
            using (tt_dbContext entities = new tt_dbContext())
            {
                List<MenuMapModel> _dataList = null;
                return _dataList = _obj.fetchMappedMenusByRoleID(role_id);
            }
        }

        [Route("Account/Permissions/InsertMenuPermission")]
        public JsonResult InsertMenuPermission([FromBody] List<TblMenumap> json_array) //, int p_roleid)
        {
            using (tt_dbContext entities = new tt_dbContext())
            {
                //query to delete all old records with the given roleid
                //entities.Database.ExecuteSqlCommand("TRUNCATE TABLE [Customers]");

                //Check for NULL.  
                if (json_array == null)
                {
                    json_array = new List<TblMenumap>();
                }

                int role_id = 0;

                //Loop and insert records. 
                foreach (TblMenumap menu in json_array)
                {
                    role_id = Convert.ToInt32(menu.RoleId);

                    entities.TblMenumap.Add(menu);

                    //entities.Entry<TblMenumap>(menu).State = EntityState.Detached;
                }

                try
                {
                    var result = _context.TblMenumap.FromSqlRaw($"sp_deletemappedmenus {role_id}").ToList();
                }
                catch (Exception ex)
                { }

                int insertedRecords = 0;
                using (TransactionScope s = new TransactionScope())
                {
                    insertedRecords = entities.SaveChanges();
                    s.Complete();
                }
                return Json(insertedRecords);
            }
        }

    }
}
