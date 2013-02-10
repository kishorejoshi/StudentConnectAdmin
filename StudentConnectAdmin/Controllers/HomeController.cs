using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudentConnectAdmin.Data;
using StudentConnectAdmin.Utils;

namespace StudentConnectAdmin.Controllers
{
    using StudentConnectAdmin.Utils;
    using System.IO;
    using System.Threading.Tasks;
    public class HomeController : Controller
    {
        IContentRepository repo;

        public HomeController()
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
