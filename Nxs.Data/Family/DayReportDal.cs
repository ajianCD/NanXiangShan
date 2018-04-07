using Nxs.Model;
using Nxs.Model.DayReport;
using Nxs.Model.Family;
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
        /// <param name="list">家务实体</param>
        /// <returns></returns>
        public int Add(DayReport dayModel, string userId, List<HouseWorkSituationModel> list)
        {
            using (DefaultConnection _ctx = new DefaultConnection())
            {
                //新增日报
                dayModel.Id = Guid.NewGuid().ToString();
                dayModel.CreateTime = DateTime.Now;
                dayModel.UserId = userId;
                _ctx.DayReport.Add(dayModel);
                //新增家务
                foreach (var item in list)
                {
                    DayReportUser dru = new DayReportUser();
                    dru.Id = Guid.NewGuid().ToString();
                    dru.DayReportId = dayModel.Id;
                    dru.HouseWorkScoreId = item.HouseWorkId;
                    dru.Times = item.Times;
                    _ctx.DayReportUser.Add(dru);
                }
                return _ctx.SaveChanges();
            }
        }

        /// <summary>
        /// 获取who 的某天的数据
        /// </summary>
        /// <param name="dd"></param>
        /// <returns></returns>
        public DayReport Get(DateTime dd, string userId)
        {
            using (DefaultConnection _ctx = new DefaultConnection())
            {
                return _ctx.DayReport.Where(item => item.DayReportTime.Equals(dd) && item.UserId == userId).FirstOrDefault();
            }
        }

        /// <summary>
        /// 获取用户所有日报信息
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<DayReport> Get(string userId)
        {
            using (DefaultConnection _ctx = new DefaultConnection())
            {
                return _ctx.DayReport.Where(item => item.UserId == userId).ToList();
            }
        }


        /// <summary>
        /// 根据条件获取报表日志
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public PageDataModel<DayReport> Get(DayDetailSearch model)
        {
            using (DefaultConnection _ctx = new DefaultConnection())
            {
                var list = _ctx.DayReport.AsQueryable<DayReport>();

                if (!string.IsNullOrEmpty(model.UserId))
                    list = list.Where(item => item.UserId == model.UserId);

                DateTime dt = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
                if (model.DateStart.HasValue)
                    list = list.Where(item => item.DayReportTime >= model.DateStart.Value);

                if (model.DateEnd.HasValue)
                    list = list.Where(item => item.DayReportTime <= model.DateEnd.Value);

                list = list.OrderByDescending(item => item.DayReportTime);

                PageDataModel<DayReport> pModel = new PageDataModel<DayReport>();

                pModel.PageNum = model.PageNum;
                pModel.PageSize = model.PageSize;
                pModel.RecordCount = list.Count();
                pModel.DataList = list.Skip(((model.PageNum - 1) * model.PageSize)).Take(model.PageSize).ToList();

                return pModel;
            }
        }
    }
}
