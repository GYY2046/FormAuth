using FormAuth.DBServer;
using FormAuth.Models;
using FormAuth.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
                var userInfo = new UserInfo();
                //userInfo.PList = role.PList;
                userInfo.UserId = role.Id;
                userInfo.RoleId = role.Id;
                userInfo.UserName = role.Name;
                userInfo.PList = role.PList;
                string perListKey = string.Format("userPermission_{0}", role.Id);
                if (HttpRuntime.Cache.Get(perListKey) == null)
                {
                    HttpRuntime.Cache.Insert(perListKey, role.PList);
                }                                               
                var cookie = UserFormsPrincipal<UserInfo>.SingIn(user.Name, userInfo, 100);
                //Request.Cookies.Add(cookie);
                //Response.Cookies.Add(cookie);                
                return View("Welcome");
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