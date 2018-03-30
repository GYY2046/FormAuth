using FormAuth.DBServer;
using FormAuth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Script.Serialization;
using System.Web.Security;

namespace FormAuth.Utils
{
    public class RoleAuthorizeAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            //UserFormsPrincipal<UserInfo>.TrySetUserInfo(filterContext.RequestContext.HttpContext)
            //var dd = (filterContext.RequestContext.HttpContext.User.Identity as FormsIdentity).Ticket; 
            var userData1 = filterContext.RequestContext.HttpContext.User as UserInfo;
            var isAuth = false;
            if (!filterContext.RequestContext.HttpContext.Request.IsAuthenticated)
            {
                isAuth = false;
            }
            else
            {
                if (filterContext.RequestContext.HttpContext.User.Identity != null)
                {
                    IList<Permission> pList = null;
                    var roleService = new UserServer("DefaultConnection");
                    var actionDescriptor = filterContext.ActionDescriptor;
                    var controllerDescriptor = actionDescriptor.ControllerDescriptor;
                    var controller = controllerDescriptor.ControllerName;
                    var action = actionDescriptor.ActionName;
                    var ticket = (filterContext.RequestContext.HttpContext.User.Identity as FormsIdentity).Ticket;
                    var userData = (filterContext.RequestContext.HttpContext.User as UserFormsPrincipal<UserInfo>).UserData;
                    string perListKey = string.Format("userPermission_{0}", userData.RoleId);
                    var cache = HttpRuntime.Cache.Get(perListKey) as List<Permission>;
                    if (cache != null)
                    {
                        pList = cache;
                    }
                    
                    if (pList != null)
                    {
                        isAuth = pList.Any(x => x.CName.ToLower() == controller.ToLower() && x.AName.ToLower() == action.ToLower());
                    }
                }
            }
            if (!isAuth)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Home", action = "Index", returnUrl = filterContext.HttpContext.Request.Url, returnMessage = "您无权查看." }));
                return;
            }
            else
            {
                base.OnAuthorization(filterContext);
            }
        }
    }
}