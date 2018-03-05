using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nxs.Web.Models
{
    /// <summary>
    /// 操作结果反馈
    /// </summary>
    public class OperateResult
    {
        /// <summary>
        /// true 请求操作成功
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// 操作说明
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 相关数据
        /// </summary>
        public dynamic Data { get; set; }
    }
}