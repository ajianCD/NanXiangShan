using Nxs.Data;
using Nxs.Data.Family;
using Nxs.Model.DayReport;
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


        /// <summary>
        /// 获取用户所有日报信息
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<DayReport> Get(string userId)
        {
            return _dayReportDal.Get(userId);
        }


        /// <summary>
        /// 根据条件获取报表日志
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<DayDetailModel> Get(DayDetailSearch model)
        {
            if (model.DateStart.HasValue && model.DateEnd.HasValue
                && model.DateStart > model.DateEnd)
                throw new Exception("开始时间不能小于结束时间！");

            List<DayDetailModel> list = new List<DayDetailModel>();
            var source = _dayReportDal.Get(model);
            foreach (var item in source)
            {
                DayDetailModel ddm = new DayDetailModel();
                ddm.DayReportTime = item.DayReportTime;
                ddm.Chanllenge = item.Chanllenge;
                ddm.HouseScores = item.HouseScores;
                ddm.PersonalQuestion = item.PersonalQuestion;
                ddm.PersonalResult = item.PersonalResult;
                ddm.WorkRemark = item.WorkRemark;
                list.Add(ddm);
            }
            return list;
        }
    }
}
