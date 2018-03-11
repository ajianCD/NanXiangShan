using Business.Family;
using Microsoft.AspNet.Identity;
using Nxs.Data;
using Nxs.Web.Models;
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
        private DayReportBusiness _dayReportBusiness;
        public DayTotalController()
        {
            _dayReportBusiness = new DayReportBusiness();
        }
        // GET: Report/DayTotal
        public ActionResult Index()
        {
            return View();
        }


        public JsonResult AddDayReportInfo(DayReport dayRepot)
        {
            string userId = User.Identity.GetUserId();
            if (string.IsNullOrEmpty(userId))
            {
                return Json(new OperateResult { Success = true, Message = "用户验证失败，请先登录!" });
            }



            if (_dayReportBusiness.Add(dayRepot, userId) > 0)
                return Json(new OperateResult { Success = true, Message = "添加数据成功!" });
            return Json(new OperateResult { Success = true, Message = "添加数据失败!" });
        }
    }
}