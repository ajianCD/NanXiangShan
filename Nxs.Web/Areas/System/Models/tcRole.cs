using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nxs.Web.Areas.System.Models
{
    /// <summary>
    /// 用户角色所有相关对象
    /// </summary>
    public class tcRole
    {
    }
    /// <summary>
    /// 新建（修改）角色对象
    /// </summary>
    public class RegistRole
    {
        /// <summary>
        /// 角色名
        /// </summary>
        public string RoleName { get; set; }

        /// <summary>
        /// 角色描述
        /// </summary>
        public string RoleDesc { get; set; }

        /// <summary>
        /// 角色状态
        /// </summary>
        public int RoleState { get; set; }
    }
}