using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ARMS.Areas.Account.Controllers
{
    [AllowAnonymous]
    [Area("Account")]
    public class DashboardController : Controller
    {
        [Route("Account/Dashboard")]
        public IActionResult Index()
        {
            return View();
        }
    }
}