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
            var model = new StatisticsViewModel();
            model.Info = new List<JobTypePercent>();
            var submissions = repo.GetSubmissions();
            float total = submissions.Select(q => q.Interests).Count();
            foreach (var interest in submissions.Select(q => q.Interests).Distinct())
            {
                var obj = new JobTypePercent();
                obj.Source = interest;
                obj.Percentage = (submissions.Count(q => q.Interests.Equals(interest))/total) * 100 ;
                model.Info.Add(obj);
            }

            return View(model.Info);
        }

        [Authorize(Roles = "Standard, Admin")]
        public ActionResult Logout()
        {
            return RedirectToAction("Logout", "Account");
        }
    }
}
