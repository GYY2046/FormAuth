using FormAuth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FormAuth.ViewsModel
{
    public class RolePermissionIndex
    {
        public IList<Role> RoleList { get; set; }
        public IList<Permission> PerList { get; set; }
    }
}