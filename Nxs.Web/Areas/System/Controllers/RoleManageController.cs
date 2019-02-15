using Business.SystemBLL;
using Nxs.Data;
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
        private RoleBusiness _rolebusiness;
        public RoleManageController()
        {
            _rolebusiness = new RoleBusiness();
        }
        // GET: System/RoleManage
        public ActionResult Index()
        {
            //var list = _rolebusiness.GetRoles(new Data.AspNetRoles());
            return View();
        }

        /// <summary>
        /// 列表加载
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult List(AspNetRoles model)
        {
            var list = _rolebusiness.GetRoles(model);
            return View(list);
        }

        public JsonResult Add(AspNetRoles model)
        {
            if (string.IsNullOrEmpty(model.Name))
                return Json(new { result = 0, message = "角色名不能为空" });
            var rst = _rolebusiness.Add(model);
            return Json(new { result = 1, message = "" });
        }


        public JsonResult Delete(string id)
        {
            if (string.IsNullOrEmpty(id))
                return Json(new { result = 0, message = "传参错误" });
            var rst = _rolebusiness.Edit(new AspNetRoles() { Id = id });
            return Json(new { result = rst, message = "" });
        }

        public JsonResult Edit(string id)
        {
            if (string.IsNullOrEmpty(id))
                return Json(new { result = 0, message = "传参错误" });
            var rst = _rolebusiness.Edit(new AspNetRoles() { Id = id });
            return Json(new { result = rst, message = "" });
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