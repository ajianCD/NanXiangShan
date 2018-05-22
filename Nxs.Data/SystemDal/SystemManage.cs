using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nxs.Data.SystemDal
{
    public class RoleManage
    {
        /// <summary>
        /// 获取角色
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<AspNetRoles> Get(AspNetRoles model)
        {
            using (DefaultConnection _ctx = new DefaultConnection())
            {
                var list = _ctx.AspNetRoles.AsQueryable<AspNetRoles>();

                return list.ToList();
            }
        }

        /// <summary>
        /// 新增角色
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(AspNetRoles model)
        {
            using (DefaultConnection _ctx = new DefaultConnection())
            {
                model.Id = Guid.NewGuid().ToString();
                _ctx.AspNetRoles.Add(model);
                return _ctx.SaveChanges();
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public int Delect(string Id)
        {
            using (DefaultConnection _ctx = new DefaultConnection())
            {

                #region 修改方法1
                var model = _ctx.AspNetRoles.FirstOrDefault(item => item.Id == Id);
                //model.State = 2;
                #endregion

                #region 修改方法2
                //model.State = 2;
                //_ctx.Entry<AspNetRoles>(model).State = System.Data.Entity.EntityState.Modified;
                #endregion

                return _ctx.SaveChanges();

            }
        }

        /// <summary>
        /// 修改角色
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Edit(AspNetRoles model)
        {
            using (DefaultConnection _ctx = new DefaultConnection())
            {
                _ctx.Entry<AspNetRoles>(model).State = System.Data.Entity.EntityState.Modified;
                return _ctx.SaveChanges();
            }
        }
    }
}
