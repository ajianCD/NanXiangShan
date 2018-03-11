using Nxs.Data;
using Nxs.Data.Family;
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
        public int Add(DayReport dr, string userId)
        {
            return _dayReportDal.Add(dr, userId);
        }
    }
}
