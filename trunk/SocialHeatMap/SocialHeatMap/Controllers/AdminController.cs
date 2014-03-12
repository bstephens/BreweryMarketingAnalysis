using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SocialHeatMap.Models;
using SocialHeatMap.DataServices;

namespace SocialHeatMap.Controllers
{
    [Authorize(Roles="Admin")]
    public class AdminController : Controller
    {
        //
        // GET: /Admin/

        public ActionResult Home()
        {
            AdminModel model = new AdminModel();
            model.Load();

            return View(model);
        }

        public ActionResult ClearSearches()
        {
            AdminDataService.ClearSearches();

            return RedirectToAction("Home", "Admin");
        }

        public ActionResult ClearCredentials()
        {
            AdminDataService.ClearUserCredentials();

            return RedirectToAction("Home", "Admin");
        }

        public ActionResult MakeAdmin(int id)
        {
            AdminDataService.UpdateAdminStatus(id, true);

            return RedirectToAction("Home", "Admin");
        }

        public ActionResult RemoveAdmin(int id)
        {
            AdminDataService.UpdateAdminStatus(id, false);

            return RedirectToAction("Home", "Admin");
        }
    }
}
