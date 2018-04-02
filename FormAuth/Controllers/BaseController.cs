using FormAuth.Models;
using FormAuth.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace FormAuth.Controllers
{
    public class BaseController : Controller
    {
        public BaseController()
        {
            var pList = new List<Permission>();
            if (System.Web.HttpContext.Current != null)
            {
                var ticket = (System.Web.HttpContext.Current.User.Identity as FormsIdentity).Ticket;
                var userData = (System.Web.HttpContext.Current.User as UserFormsPrincipal<UserInfo>).UserData;
                string perListKey = string.Format("userPermission_{0}", userData.RoleId);
                pList = HttpRuntime.Cache.Get(perListKey) as List<Permission>;
            }
            ViewBag.PerList = pList;

        }
    }
}