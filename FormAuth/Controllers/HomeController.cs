using FormAuth.DBServer;
using FormAuth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.Security;

namespace FormAuth.Controllers
{
    public class HomeController : Controller
    {
        private UserServer db = null;
        public HomeController()
        {
            db = new UserServer("DefaultConnection");
        }
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(User user)
        {
            if (!ModelState.IsValid)
                return View(user);
            if (string.IsNullOrEmpty(user.Name))
            {
                ModelState.AddModelError("Name", "用户名不能为空");
                return View(user);
            }
            if (string.IsNullOrEmpty(user.Pwd))
            {
                ModelState.AddModelError("Pwd", "密码不能为空");
                return View(user);
            }
            if (db.CheckUser(user.Name, user.Pwd, out User userModel))
            {
                var role = db.GetRoleById(userModel.RoleId);
                
                var userData = (new JavaScriptSerializer()).Serialize(role);
                //生成Ticket
                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(2,
                    user.Name,
                    DateTime.Now,
                    DateTime.Now.AddDays(1),
                    true,
                    userData);
                //加密
                string cookieValue = FormsAuthentication.Encrypt(ticket);
                //设置Cookie
                HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, cookieValue);
                HttpContext context = System.Web.HttpContext.Current;
                context.Response.Cookies.Remove(cookie.Name);
                context.Response.Cookies.Add(cookie);
                return RedirectToAction("About");
            }
            else
            {
                ModelState.AddModelError("Error", "用户名或者密码错误");
                return View(user);
            }
        }
        public ActionResult Welcome()
        {
            return View();
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}