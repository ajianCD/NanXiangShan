using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nxs.Web.Controllers
{
    public class ComponentController : Controller
    {
        // GET: Component
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 优良中差组件
        /// </summary>
        /// <returns></returns>
        public ActionResult Radio_YLZC()
        {
            return PartialView();
        }
    }
}