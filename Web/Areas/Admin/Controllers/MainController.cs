using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Areas.Admin.Controllers
{
    /// <summary>
    /// 登录后主页
    /// </summary>
    public class MainController : Controller
    {
        // GET: Admin/Main
        public ActionResult Index()
        {
            return View();
        }



    }
}