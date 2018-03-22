using Microsoft.AspNet.Identity.EntityFramework;
using System;

namespace Nxs.Web.Models
{
    /// <summary>
    /// Identity用户，必须继承IdentityUser
    /// </summary>
    public class TUser : IdentityUser
    {
        /// <summary>
        /// 真实姓名，个人用户可填
        /// </summary>
        public string RealName { get; set; }

        /// <summary>
        /// QQ号
        /// </summary>
        public string QQ { get; set; }


        /// <summary>
        /// 微信账号
        /// </summary>
        public string Wxin { get; set; }


        /// <summary>
        /// 性别：男/女
        /// </summary>
        public string Sex { get; set; }


        /// <summary>
        /// 注册时间
        /// </summary>
        public Nullable<DateTime> RegisterTime { get; set; }

        /// <summary>
        /// 用户状态
        /// </summary>
        public int State { get; set; }
    }
}