using CORE_BOL;
using CORE_BOL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;

namespace CORE_BLL
{
   public class MenuBLL
    {

        readonly tt_dbContext ctx = new tt_dbContext();

        public void SaveRoles(TblRole obj)
        {
            using (TransactionScope s = new TransactionScope())
            {
                var entity = new TblRole
                {
                    RoleName = obj.RoleName,
                    Description = obj.Description,
                    IsActive = obj.IsActive,
                    CreatedBy = obj.CreatedBy,
                    CreatedOn = obj.CreatedOn
                };

                ctx.TblRole.Add(entity);
                ctx.SaveChanges();

                s.Complete();

            }
        }

        public List<MenuViewModel> GetMenus(int p_roleid)
        {
            List<MenuViewModel> MenuLst = new List<MenuViewModel>();

            int role_id = p_roleid;
            var result = ctx.TblMenu.FromSqlRaw($"sp_populatemenu {role_id}").AsNoTracking().ToList();

            if (result.Count() > 0)
            {
                foreach (var item in result)
                {
                    MenuViewModel mvm = new MenuViewModel();
                    mvm.MenuId = item.MenuId;
                    mvm.MenuName = item.MenuName;
                    mvm.MenuParentId = item.MenuParentId;
                    mvm.ControllerName = item.ControllerName;
                    mvm.ActionName = item.ActionName;
                    mvm.AreaName = item.AreaName;

                    MenuLst.Add(mvm);
                }
            }

            return MenuLst;
        }


        //public List<MenuMapModel> fetchMappedMenusByRoleID(int role_id)
        //{

        //    List<MenuMapModel> mylist = new List<MenuMapModel>();

        //    var data = ctx.MenuMapModel.FromSqlRaw($"sp_populatemenusByRoleID {role_id}").ToList();

        //    if (data.Count() > 0)
        //    {
        //        foreach (var item in data)
        //        {
        //            MenuMapModel mm = new MenuMapModel();

        //            mm.menu_id = item.menu_id;
        //            mm.menu_name = item.menu_name;
        //            mm.is_add = item.is_add;
        //            mm.is_edit = item.is_edit;
        //            mm.is_view = item.is_view;

        //            mylist.Add(mm);
        //        }
        //    }
        //    return mylist;

        //}





    }
}
