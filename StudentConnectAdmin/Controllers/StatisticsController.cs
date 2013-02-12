using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudentConnectAdmin.Data;
using StudentConnectAdmin.Utils;

namespace StudentConnectAdmin.Controllers
{
    public class StatisticsController : Controller
    {
        //
        // GET: /Statistics/
        IContentRepository repo;


        public StatisticsController()
        {
            repo = ServiceProvider.Resolve<IContentRepository>();
        }

        [Authorize(Roles = "Standard, Admin")]
        public ActionResult Index()
        {
            var model = repo.GetSubmissions();
            return View(model);
        }

        [Authorize(Roles = "Standard, Admin")]
        public ActionResult Logout()
        {
            return RedirectToAction("Logout", "Account");
        }
    }
}
