using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nxs.Web.Controllers
{
    public class FamilyReportController : Controller
    {
        // GET: FamilyReport
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 家庭日报
        /// </summary>
        /// <returns></returns>
        public ActionResult Day()
        {
            return View();
        }
    }
}