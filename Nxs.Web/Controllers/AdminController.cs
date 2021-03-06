﻿using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Nxs.Web.Infrastructure;
using Nxs.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nxs.Web.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 登录页面
        /// </summary>
        /// <returns></returns>
        public ActionResult Login()
        {
            return View();
        }

        /// <summary>
        /// 登录验证 
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { result = false, message = "数据异常！" });
            }

            //if (model.Code.ToLower() != Session["CheckCode"].ToString().ToLower())
            //{
            //    return Json(new { result = false, message = "验证码错误！" });
            //}

            TUser userInfo = UserManager.Find(model.Name, model.Password);
            if (userInfo == null)
            {
                return Json(new { result = false, message = "无效的登录尝试" });
            }
            else
            {
                var claimsIdentity = UserManager.CreateIdentity(userInfo, DefaultAuthenticationTypes.ApplicationCookie);
                //claimsIdentity.AddClaims(LocationClaimsProvider.GetClaims(claimsIdentity));
                //claimsIdentity.AddClaims(ClaimsRoles.CreateRolesFromClaims(claimsIdentity));
                AuthManager.SignOut();
                AuthManager.SignIn(new AuthenticationProperties { IsPersistent = false }, claimsIdentity);

                return Json(new { result = true });
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Main()
        {
            string userId = User.Identity.GetUserId();
            if (string.IsNullOrEmpty(userId))
            {
                return RedirectToAction("Login");
            }
            return View();
        }

        public ActionResult Family()
        {
            string userId = User.Identity.GetUserId();
            ViewBag.Name = User.Identity.GetUserName();
            if (string.IsNullOrEmpty(userId))
            {
                return RedirectToAction("Login");
            }
            return View();
        }

        /// <summary>
        /// 推出登陆
        /// </summary>
        /// <returns></returns>
        public ActionResult LogOff()
        {
            AuthManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Login", "Admin");
        }


        private AppUserManager UserManager
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<AppUserManager>();
            }
        }

        private IAuthenticationManager AuthManager
        {
            get { return HttpContext.GetOwinContext().Authentication; }
        }
    }
}