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

        public List<HouseWorkScore> Get(int score)
        {
            return hwDal.Get(score);
        }

        public int Add(HouseWorkScore hw)
        {
            return hwDal.Add(hw);
        }

    }
}
