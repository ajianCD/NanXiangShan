using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nxs.Model.Family
{
    /// <summary>
    /// 家务完成情况实体
    /// </summary>
    public class HouseWorkSituationModel
    {
        /// <summary>
        /// 家务ID
        /// </summary>
        public string HouseWorkId { get; set; }

        /// <summary>
        /// 次数
        /// </summary>
        public int Times { get; set; }
    }
}
