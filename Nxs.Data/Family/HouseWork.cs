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
        public List<HouseWorkScore> Get(int score)
        {
            using (DefaultConnection _ctx = new DefaultConnection())
            {
                List<HouseWorkScore> list = new List<HouseWorkScore>();
                if (score != -1)
                    list = _ctx.HouseWorkScore.Where(item => item.hwState != 0 && item.hwScore == score).ToList();
                else
                    list = _ctx.HouseWorkScore.Where(item => item.hwState != 0).ToList();
                return list;
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
                }
                else
                {
                    hw.Id = Guid.NewGuid().ToString();
                    _ctx.HouseWorkScore.Add(hw);
                }
                return _ctx.SaveChanges();
            }
        }

        /// <summary>
        /// 编辑 状态为0，逻辑删除
        /// </summary>
        /// <param name="hw"></param>
        /// <returns></returns>
        public int Edit(HouseWorkScore hw)
        {
            using (DefaultConnection _ctx = new DefaultConnection())
            {
                if (!string.IsNullOrWhiteSpace(hw.Id))
                {
                    var hwItem = _ctx.HouseWorkScore.Where(item => item.Id == hw.Id).FirstOrDefault();
                    if (hwItem == null)
                    {
                        throw new Exception("修改的信息不存在");
                    }
                    if (hw.hwState != 0)
                    {
                        hwItem.hwName = hw.hwName;
                        hwItem.hwScore = hw.hwScore;
                    }
                    hwItem.hwState = hw.hwState;
                    return _ctx.SaveChanges();
                }
                return -1;
            }
        }


    }
}
