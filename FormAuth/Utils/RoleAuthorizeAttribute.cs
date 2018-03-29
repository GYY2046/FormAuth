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
            var isAuth = false;
            if (!filterContext.RequestContext.HttpContext.Request.IsAuthenticated)
            {
                isAuth = false;
            }
            else
            {
                if (filterContext.RequestContext.HttpContext.User.Identity != null)
                {
                    var roleService = new UserServer("DefaultConnection");
                    var actionDescriptor = filterContext.ActionDescriptor;
                    var controllerDescriptor = actionDescriptor.ControllerDescriptor;
                    var controller = controllerDescriptor.ControllerName;
                    var action = actionDescriptor.ActionName;
                    var ticket = (filterContext.RequestContext.HttpContext.User.Identity as FormsIdentity).Ticket;
                    var userData = (new JavaScriptSerializer()).Deserialize<Role>(ticket.UserData);
                    var role = roleService.GetRoleById(userData.Id);
                    if (role != null)
                    {
                        isAuth = role.PList.Any(x => x.CName.ToLower() == controller.ToLower() && x.AName.ToLower() == action.ToLower());
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