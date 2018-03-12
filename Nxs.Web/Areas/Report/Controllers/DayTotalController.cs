using Business.Family;
using Microsoft.AspNet.Identity;
using Nxs.Data;
using Nxs.Model.Family;
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


        public JsonResult AddDayReportInfo(DayReport dayRepot, string houseWorkIds)
        {
            string userId = User.Identity.GetUserId();

            var dd = _dayReportBusiness.Get(DateTime.Now.Date, userId);
            if (dd != null)
            {
                return Json(new OperateResult { Success = false, Message = "老大，你填过了，不用填了。项目还需完善，以后不会有这样的提示!" });
            }
            if (string.IsNullOrEmpty(userId))
            {
                return Json(new OperateResult { Success = false, Message = "用户验证失败，请先登录!" });
            }

            string[] hList = houseWorkIds.Split(',');
            List<HouseWorkSituationModel> list = new List<HouseWorkSituationModel>();
            foreach (var item in hList)
            {
                HouseWorkSituationModel model = new HouseWorkSituationModel();
                model.HouseWorkId = item.Split('|')[0];
                model.Times = Convert.ToInt32(item.Split('|')[1]);
                list.Add(model);
            }
            if (_dayReportBusiness.Add(dayRepot, userId, list) > 0)
                return Json(new OperateResult { Success = true, Message = "添加数据成功!" });
            return Json(new OperateResult { Success = true, Message = "添加数据失败!" });
        }
    }
}