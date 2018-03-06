using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nxs.Web.Areas.Report.Controllers
{
    /// <summary>
    /// 日报统计
    /// </summary>
    public class DayTotalController : Controller
    {
        // GET: Report/DayTotal
        public ActionResult Index()
        {
            return View();
        }
    }
}