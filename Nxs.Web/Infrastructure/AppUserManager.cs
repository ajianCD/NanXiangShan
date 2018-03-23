using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Nxs.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nxs.Web.Infrastructure
{
    /// <summary>
    /// 用户管理器类 （必须派生于UserManager<T>，其中T是用户类）
    /// </summary>
    public class AppUserManager : UserManager<TUser>
    {
        public AppUserManager(IUserStore<TUser> store)
            : base(store)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public static AppUserManager Create(
                IdentityFactoryOptions<AppUserManager> options,
                IOwinContext context)
        {
            ///为了创建UserStore<TUser>，需要AppIdentityDbContext类的一个实例
            AppIdentityDbContext db = context.Get<AppIdentityDbContext>();
            //UserStore<T> 是 包含在 Microsoft.AspNet.Identity.EntityFramework 中，它实现了 UserManger 类中与用户操作相关的方法。
            //也就是说UserStore<T>类中的方法（诸如：FindById、FindByNameAsync...）通过EntityFramework检索和持久化UserInfo到数据库中
            AppUserManager manager = new AppUserManager(new UserStore<TUser>(db));

            //设置口令策略
            manager.PasswordValidator = new CustomPasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = false,
                RequireDigit = true,
                RequireLowercase = true,
                RequireUppercase = true
            };
            //验证用户细节
            manager.UserValidator = new UserValidator<TUser>(manager)
            {
                AllowOnlyAlphanumericUserNames = true,
                RequireUniqueEmail = true
            };

            return manager;
        }
    }
}