using Nxs.Data;
using Nxs.Data.Family;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Family
{
    public class HouseWorkBusiness
    {
        HouseWork hwDal;
        public HouseWorkBusiness()
        {
            hwDal = new HouseWork();
        }

        /// <summary>
        /// 获取
        /// </summary>
        /// <param name="score"></param>
        /// <returns></returns>
        public List<HouseWorkScore> Get(int score)
        {
            return hwDal.Get(score);
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="hw"></param>
        /// <returns></returns>
        public int Add(HouseWorkScore hw)
        {
            return hwDal.Add(hw);
        }

        /// <summary>
        /// 编辑 状态为0，逻辑删除
        /// </summary>
        /// <param name="hw"></param>
        /// <returns></returns>
        public int Edit(HouseWorkScore hw)
        {
            return hwDal.Edit(hw);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int Delete(string id)
        {
            HouseWorkScore hw = new HouseWorkScore();
            hw.Id = id;
            hw.hwState = 0;
            return hwDal.Edit(hw);
        }

    }
}
