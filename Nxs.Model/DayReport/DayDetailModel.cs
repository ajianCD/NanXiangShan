using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nxs.Model.DayReport
{
    /// <summary>
    /// 日报实体
    /// </summary>
    public class DayDetailModel
    {
        /// <summary>
        /// 日期
        /// </summary>
        public DateTime DayReportTime { get; set; }

        /// <summary>
        /// 工作备注
        /// </summary>
        public string WorkRemark { get; set; }

        /// <summary>
        /// 个人收获
        /// </summary>
        public string PersonalResult { get; set; }

        /// <summary>
        /// 个人问题
        /// </summary>
        public string PersonalQuestion { get; set; }

        /// <summary>
        /// 挑战
        /// </summary>
        public string Chanllenge { get; set; }

        /// <summary>
        /// 家务得分
        /// </summary>
        public int HouseScores { get; set; }
    }


    
}
