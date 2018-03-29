using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FormAuth.Models
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<Permission> PList { get; set; }

    }
}