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
                var list = _ctx.AspNetRoles.Where(item => item.State != 0);

                if (!string.IsNullOrEmpty(model.Name))
                    list = list.Where(item => item.Name.Contains(model.Name));

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
                model.State = 1;
                _ctx.AspNetRoles.Add(model);
                return _ctx.SaveChanges();
            }
        }


        /// <summary>
        /// 设置角色状态
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="state"> 0 删除 1 可使用 2 禁用</param>
        /// <returns></returns>
        public int SetState(string Id, int state)
        {
            using (DefaultConnection _ctx = new DefaultConnection())
            {
                var model = _ctx.AspNetRoles.FirstOrDefault(item => item.Id == Id);
                if (model == null)
                    return -1;

                model.State = state;
                _ctx.Entry<AspNetRoles>(model).State = System.Data.Entity.EntityState.Modified;
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
                if (string.IsNullOrEmpty(model.Id))
                    return -1;
                var datamodel = _ctx.AspNetRoles.Where(item => item.Id == model.Id).FirstOrDefault();
                if (datamodel == null)
                    return -1;
                datamodel.Name = model.Name;
                datamodel.Discriminator = model.Discriminator;
                datamodel.State = model.State;
                _ctx.Entry<AspNetRoles>(datamodel).State = System.Data.Entity.EntityState.Modified;
                return _ctx.SaveChanges();
            }
        }
    }
}
