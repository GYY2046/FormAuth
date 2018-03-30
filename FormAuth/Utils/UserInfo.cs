using FormAuth.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Script.Serialization;

namespace FormAuth.Utils
{
    public class UserInfo :IPrincipal
    {
        public int UserId;
        public int RoleId;
        public string UserName;
        [JsonIgnoreAttribute]
        public IList<Permission> PList;
        //public override string ToString()
        //{
        //    return string.Format("UserId: {0}, UserName: {1}, IsAdmin: {2},PList:{3}",
        //        UserId, UserName, IsInRole("Admin"), new JavaScriptSerializer().Serialize(PList));
        //}
        [JsonIgnoreAttribute]
        public IIdentity Identity
        {
            get { throw new NotImplementedException(); }
        }

        public bool IsInRole(string role)
        {
            return true;
        }
    }
}