using Nxs.Data;
using Nxs.Data.Family;
using Nxs.Model.Family;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Family
{
    public class DayReportBusiness
    {
        DayReportDal _dayReportDal;
        public DayReportBusiness()
        {
            _dayReportDal = new DayReportDal();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hw">日报实体</param>
        /// <param name="userId">who</param>
        /// <returns></returns>
        public int Add(DayReport dr, string userId, List<HouseWorkSituationModel> list)
        {
            return _dayReportDal.Add(dr, userId, list);
        }

        /// <summary>
        /// 获取who 的某天的数据
        /// </summary>
        /// <param name="dd"></param>
        /// <returns></returns>
        public DayReport Get(DateTime dd, string userId)
        {
            return _dayReportDal.Get(dd, userId);
        }
    }
}
