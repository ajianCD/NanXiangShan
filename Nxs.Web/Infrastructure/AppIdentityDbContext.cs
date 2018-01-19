using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Nxs.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Nxs.Web.Infrastructure
{
    /// <summary>
    /// 创建Identity用户数据库上下文
    /// </summary>
    public class AppIdentityDbContext : IdentityDbContext<TUser>
    {
        public AppIdentityDbContext() : base("DefaultConnection")
        {
        }
        /// <summary>
        /// Database.SetInitializer方法指定了一个种植数据库的类
        /// 种植数据库的含义是往数据库中植入数据
        /// 用一些数据对数据库进行初始化
        /// 通过Entity Framework的Code First特性第一次创建数据库架构时，会用到这个类
        /// </summary>
        static AppIdentityDbContext()
        {
            Database.SetInitializer<AppIdentityDbContext>(new IdentityDbInit());
        }

        public static AppIdentityDbContext Create()
        {
            return new AppIdentityDbContext();
        }
    }

    /// <summary>
    /// 种植类,Entity Framework已经链接到数据库，并发现此时尚未定义数据库架构才会执行。
    /// </summary>
    public class IdentityDbInit : DropCreateDatabaseIfModelChanges<AppIdentityDbContext>
    {
        protected override void Seed(AppIdentityDbContext context)
        {
            PerformInitialSetup(context);
            base.Seed(context);
        }
        /// <summary>
        /// 用一些数据对数据库进行初始化
        /// </summary>
        /// <param name="context"></param>
        public void PerformInitialSetup(AppIdentityDbContext context)
        {
            //初始化
            AppUserManager userMgr = new AppUserManager(new UserStore<TUser>(context));
            AppRoleManager roleMgr = new AppRoleManager(new RoleStore<TRole>(context));
            string roleName = "Administrators";
            string userName = "admin@nxs.com";
            string password = "123456Aa.";
            string email = "admin@nxs.com";
            if (!roleMgr.RoleExists(roleName))
            {
                roleMgr.Create(new TRole(roleName));
            }
            TUser user = userMgr.FindByName(userName);
            if (user == null)
            {
                userMgr.Create(new TUser { UserName = userName, Email = email, RegisterTime = DateTime.Now }, password);
                user = userMgr.FindByName(userName);
            }
            if (!userMgr.IsInRole(user.Id, roleName)) { userMgr.AddToRole(user.Id, roleName); }
        }

    }
}