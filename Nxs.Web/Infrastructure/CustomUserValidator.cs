using Microsoft.AspNet.Identity;
using Nxs.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Nxs.Web.Infrastructure
{
    /// <summary>
    /// 自定义用户基本信息验证策略
    /// (密码加密，在此处不能验证，需在CustomPasswordValidator中进行验证)
    /// </summary>
    public class CustomUserValidator : UserValidator<TUser>
    {
        public CustomUserValidator(AppUserManager mgr) : base(mgr) { }

        public override async Task<IdentityResult> ValidateAsync(TUser user)
        {
            IdentityResult result = await base.ValidateAsync(user);
            if (!(user.Email.ToLower().EndsWith("@163.com") || user.Email.ToLower().EndsWith("@qq.com")))
            {
                var errors = result.Errors.ToList();
                errors.Add("Only 163.com email addresses are allowed");
                result = new IdentityResult(errors);
            }
            return result;
        }
    }
}