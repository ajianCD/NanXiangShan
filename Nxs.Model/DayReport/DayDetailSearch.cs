using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nxs.Model.DayReport
{
    /// <summary>
    /// 日报详细查询实体
    /// </summary>
    public class DayDetailSearch
    {
        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime? DateStart { get; set; }

        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime? DateEnd { get; set; }


        /// <summary>
        /// 当前用户
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// 当前页
        /// </summary>
        public int PageNum { get; set; }


        /// <summary>
        /// 每页显示条数
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// 总记录数
        /// </summary>
        public int RecordCount { get; set; }
    }
}
