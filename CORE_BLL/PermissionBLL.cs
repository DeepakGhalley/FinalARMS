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
    public class PermissionBLL
    {
        readonly tt_dbContext ctx = new tt_dbContext();

        public List<MenuMapModel> fetchMappedMenusByRoleID(int role_id)
        {

            List<MenuMapModel> mylist = new List<MenuMapModel>();

            var data = ctx.MenuMapModel.FromSqlRaw($"sp_populatemenusByRoleID {role_id}").ToList();

            if (data.Count() > 0)
            {
                foreach (var item in data)
                {
                    MenuMapModel mm = new MenuMapModel();

                    mm.menu_id = item.menu_id;
                    mm.menu_name = item.menu_name;
                    mm.is_add = item.is_add;
                    mm.is_edit = item.is_edit;
                    mm.is_view = item.is_view;

                    mylist.Add(mm);
                }
            }
            return mylist;

        }

    }
}
