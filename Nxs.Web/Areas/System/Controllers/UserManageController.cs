using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nxs.Web.Areas.System.Controllers
{
    /// <summary>
    /// 用户管理模块
    /// </summary>
    public class UserManageController : Controller
    {
        // GET: System/UserManage
        public ActionResult Index()
        {
            return View();
        }
    }
}