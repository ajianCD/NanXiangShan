using Business.Family;
using Nxs.Data;
using Nxs.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nxs.Web.Areas.Report.Controllers
{
    public class FamilyController : Controller
    {
        HouseWorkBusiness _hwBusiness;
        public FamilyController()
        {
            _hwBusiness = new HouseWorkBusiness();
        }
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

        /// <summary>
        /// 新增家务得分标准操作
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult AddScore(HouseWorkScore hw)
        {
            var rst = _hwBusiness.Add(hw);
            if (rst > 0)
            {
                return Json(new OperateResult { Success=true, Message="请求成功" });
            }
            return Json(new OperateResult { Success=false,Message="请求操作失败，请联系管理员！"});
        }
    }
}