//------------------------------------------------------------------------------
// <auto-generated>
//    此代码是根据模板生成的。
//
//    手动更改此文件可能会导致应用程序中发生异常行为。
//    如果重新生成代码，则将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Nxs.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class AspNetRoles
    {
        public AspNetRoles()
        {
            this.AspNetUsers = new HashSet<AspNetUsers>();
        }
    
        public string Id { get; set; }
        public string Name { get; set; }
        public string Discriminator { get; set; }
        /// <summary>
        /// 0 删除 1 可使用 2 禁用
        /// </summary>
        public int State { get; set; }
    
        public virtual ICollection<AspNetUsers> AspNetUsers { get; set; }
    }
}
