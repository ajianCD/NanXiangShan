using Nxs.Web.Areas.System.Models;
using Nxs.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nxs.Web.Areas.System.Controllers
{
    /// <summary>
    /// 角色管理
    /// </summary>
    public class RoleManageController : Controller
    {
        // GET: System/RoleManage
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 注册角色
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult Role(RegistRole model)
        {
            if (!string.IsNullOrEmpty(model.RoleName))
                return Json(new OperateResult { Success = true });
            else
                return Json(new OperateResult { Success = false });
        }
    }
}