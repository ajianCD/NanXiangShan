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
    public class AppRoleManager : RoleManager<TRole>
    {
        public AppRoleManager(RoleStore<TRole> store) : base(store)
        {
        }

        public static AppRoleManager Create(IdentityFactoryOptions<AppRoleManager> options, IOwinContext context)
        {
            return new AppRoleManager(new RoleStore<TRole>(context.Get<AppIdentityDbContext>()));
        }
    }
}