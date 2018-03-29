using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FormAuth.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Pwd { get; set; }
        public int RoleId { get; set; }
    }
}