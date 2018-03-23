using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Nxs.Web.Infrastructure;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nxs.Web.App_Start
{
    /// <summary>
    /// Identity 启动类
    /// </summary>
    public class IdentityConfig
    {
        public void Configuration(IAppBuilder app)
        {
            //1.使用app.Use方法将IdentityFactoryMiddleware和参数callback回掉函数注册到Owin Pipeline中
            //app.Use(typeof(IdentityFactoryMiddleware<T, IdentityFactoryOptions<T>>), args);
            //2.当IdentityFactoryMiddleware中间件被Invoke执行时，执行callback回掉函数，返回具体实例Instance
            //TResult instance = ((IdentityFactoryMiddleware<TResult, TOptions>) this).Options.Provider.Create(((IdentityFactoryMiddleware<TResult, TOptions>) this).Options, context);
            //3.将返回的实例存储在Owin Context中
            //context.Set<TResult>(instance);

            //向 Owin Context中注册对象实例
            app.CreatePerOwinContext<AppIdentityDbContext>(AppIdentityDbContext.Create);
            app.CreatePerOwinContext<AppUserManager>(AppUserManager.Create);

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Home/Index"),
            });
        }
    }
}