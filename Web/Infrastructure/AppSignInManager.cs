using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Nxs.Model.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace Web.Infrastructure
{
    public class AppSignInManager : SignInManager<TUser, string>
    {
        public AppSignInManager(TUserManager userManager, IAuthenticationManager authenticationManager)
            : base(userManager, authenticationManager)
        {

        }

        public override Task<ClaimsIdentity> CreateUserIdentityAsync(TUser user)
        {
            var userIdentity = this.UserManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
            // 在此处添加自定义用户声明
            userIdentity.Result.AddClaim(new Claim("Id", user.Id));

            foreach (var claim in user.Claims)
            {
                userIdentity.Result.AddClaim(new Claim(claim.ClaimType, claim.ClaimValue));
            }
            return userIdentity;
        }
    }
}