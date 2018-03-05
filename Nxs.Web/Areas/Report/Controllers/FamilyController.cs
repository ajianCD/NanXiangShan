using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nxs.Web.Areas.Report.Controllers
{
    public class FamilyController : Controller
    {
        // GET: Report/Family
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 家务得分标准
        /// </summary>
        /// <returns></returns>
        public ActionResult Score()
        {
            return View();
        }
    }
}