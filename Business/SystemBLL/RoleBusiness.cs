using Nxs.Data;
using Nxs.Data.SystemDal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.SystemBLL
{
    public class RoleBusiness
    {
        RoleManage _roleManage;
        public RoleBusiness()
        {
            _roleManage = new RoleManage();
        }

        /// <summary>
        /// 获取角色信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<AspNetRoles> GetRoles(AspNetRoles model)
        {
            return _roleManage.Get(model);
        }


        public int Add(AspNetRoles model)
        {
            return _roleManage.Add(model);
        }

        public int Delete(string id)
        {
            return _roleManage.SetState(id, 0);
        }

        public int Forbidden(string id)
        {
            return _roleManage.SetState(id, 2);
        }

        public int Used(string id)
        {
            return _roleManage.SetState(id, 1);
        }
        public int Edit(AspNetRoles model)
        {
            return _roleManage.Edit(model);
        }


    }
}
