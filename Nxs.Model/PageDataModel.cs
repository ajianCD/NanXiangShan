using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nxs.Model
{
    /// <summary>
    /// 分页实体
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PageDataModel<T> where T : class
    {

        private List<T> _dataList;


        public List<T> DataList
        {
            get
            {
                if (_dataList == null)
                {
                    return new List<T>();
                }
                else
                {
                    return _dataList;
                }
            }
            set
            {
                _dataList = value;
            }
        }
        /// <summary>
        /// 当前页
        /// </summary>
        public int PageNum { get; set; }
        /// <summary>
        /// 每页显示条数
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// 总记录数
        /// </summary>
        public int RecordCount { get; set; }


        /// <summary>
        /// 获得总页数
        /// </summary>
        public int PageCount
        {
            get
            {
                if (this.PageSize == 0)
                {
                    return RecordCount == 0 ? 0 : 1;
                }
                return (int)System.Math.Ceiling(((double)RecordCount) / this.PageSize);
            }
        }
    }
}
