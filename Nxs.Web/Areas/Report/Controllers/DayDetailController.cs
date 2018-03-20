using Business.Family;
using Microsoft.AspNet.Identity;
using Nxs.Model.DayReport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nxs.Web.Areas.Report.Controllers
{
    /// <summary>
    /// 日报详细
    /// </summary>
    public class DayDetailController : Controller
    {
        DayReportBusiness _dayReportBusiness;
        public DayDetailController()
        {
            _dayReportBusiness = new DayReportBusiness();
        }
        // GET: Report/DayDetail
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List(DayDetailSearch search)
        {
            search.UserId = User.Identity.GetUserId();

            List<DayDetailModel> list = new List<DayDetailModel>();
            try
            {
                list = _dayReportBusiness.Get(search);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return PartialView(list);
        }
    }
}