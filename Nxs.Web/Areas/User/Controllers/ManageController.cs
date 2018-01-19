using Microsoft.AspNet.Identity.Owin;
using Nxs.Model;
using Nxs.Web.Infrastructure;
using Nxs.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nxs.Web.Areas.User.Controllers
{
    public class ManageController : Controller
    {
        // GET: User/Manage
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="currentPage"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public ActionResult UserList(int currentPage, int pageSize)
        {
            var users = UserManager.Users.Skip(currentPage).Take(pageSize).ToList();
            PageDataModel<TUser> dataList = new PageDataModel<TUser>();
            dataList.DataList = users;
            dataList.PageNum = currentPage;
            dataList.PageSize = pageSize;
            dataList.RecordCount = UserManager.Users.Count();
            return View(dataList);
        }


        private AppUserManager UserManager
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<AppUserManager>();
            }
        }
    }
}