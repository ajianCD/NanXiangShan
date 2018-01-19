using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Nxs.Model.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.Models;

namespace Web.Infrastructure
{
    public class TUserManager : UserManager<TUser>
    {
        public TUserManager(IUserStore<TUser> store)
        : base(store)
        {
        }

        public static TUserManager Create(
               IdentityFactoryOptions<TUserManager> options,
               IOwinContext context)
        {

            ApplicationDbContext db = context.Get<ApplicationDbContext>();
            //UserStore<T> 是 包含在 Microsoft.AspNet.Identity.EntityFramework 中，它实现了 UserManger 类中与用户操作相关的方法。
            //也就是说UserStore<T>类中的方法（诸如：FindById、FindByNameAsync...）通过EntityFramework检索和持久化UserInfo到数据库中
            TUserManager manager = new TUserManager(new UserStore<TUser>(db));

            return manager;
        }
    }
}