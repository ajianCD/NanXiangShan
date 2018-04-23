using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nxs.Web.Areas.System.Controllers
{
    /// <summary>
    /// 菜单管理
    /// </summary>
    public class MenuManageController : Controller
    {
        // GET: System/MenuManage
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult Add()
        {
            return Json(new { });
        }
    }
}