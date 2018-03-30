using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FormAuth.Models
{
    public class Permission
    {
        public int Id { get; set; }
        public int CId { get; set; }
        public string CName { get; set; }
        public int AId { get; set; }
        public string AName { get; set; }
        public string ConCnName { get; set; }
        public string ActCnName { get; set; }
    }
}