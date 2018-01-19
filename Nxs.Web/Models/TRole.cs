using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nxs.Web.Models
{
    public class TRole: IdentityRole
    {
        public TRole() : base() { }
        public TRole(string name) : base(name) { }



    }
}