using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nxs.Data.Family
{
    public class DayReportDal
    {
        /// <summary>
        /// 保存日报信息
        /// </summary>
        /// <param name="dayModel">日报实体</param>
        /// <param name="userId">who</param>
        /// <returns></returns>
        public int Add(DayReport dayModel, string userId)
        {
            using (DefaultConnection _ctx = new DefaultConnection())
            {

                dayModel.Id = Guid.NewGuid().ToString();
                dayModel.CreateTime = DateTime.Now;
                dayModel.UserId = userId;
                _ctx.DayReport.Add(dayModel);


                DayReportUser dru = new DayReportUser();
                dru.Id = Guid.NewGuid().ToString();
                dru.DayReportId = dayModel.Id;
                dru.UserId = userId;
                _ctx.DayReportUser.Add(dru);

                return _ctx.SaveChanges();
            }
        }
    }
}
