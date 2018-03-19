using Nxs.Web.Areas.Report.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nxs.Web.Areas.Report.Controllers
{
    /// <summary>
    /// 日报详细
    /// </summary>
    public class DayDetailController : Controller
    {
        // GET: Report/DayDetail
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List(DayDetailSearch search)
        {
            return PartialView();
        }
    }
}