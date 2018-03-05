using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nxs.Data.Family
{
    public class HouseWork
    {
        /// <summary>
        /// 获取所有有效的家务
        /// </summary>
        /// <returns></returns>
        public List<HouseWorkScore> Get()
        {
            using (DefaultConnection _ctx = new DefaultConnection())
            {
                return _ctx.HouseWorkScore.Where(item => item.hwState != 0).ToList();
            }
        }

        /// <summary>
        /// 保存家务信息
        /// </summary>
        /// <param name="hw"></param>
        /// <returns></returns>
        public int Add(HouseWorkScore hw)
        {
            using (DefaultConnection _ctx = new DefaultConnection())
            {
                hw.hwState = 1;
                if (!string.IsNullOrWhiteSpace(hw.Id))
                {
                    var hwItem = _ctx.HouseWorkScore.Where(item => item.Id == hw.Id).FirstOrDefault();
                    if (hwItem == null)
                    {
                        throw new Exception("修改的信息不存在");
                    }
                    hwItem.hwName = hw.hwName;
                    hwItem.hwScore = hw.hwScore;
                    hwItem.hwState = hw.hwState;
                    _ctx.SaveChanges();
                }
                else
                {
                    hw.Id = Guid.NewGuid().ToString();
                    _ctx.HouseWorkScore.Add(hw);
                }
                return _ctx.SaveChanges();
            }
        }

    }
}
