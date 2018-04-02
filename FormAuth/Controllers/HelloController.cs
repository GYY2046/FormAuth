using FormAuth.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FormAuth.Controllers
{
    [Description(1, "Hello","Hello",0)]
    [RoleAuthorize]
    public class HelloController : Controller
    {
        // GET: Hello
        [Description(1, "Index","首页",1)]
        public ActionResult Index()
        {
            return View();
        }
        [Description(2, "Add", "新增",1)]
        public ActionResult Add()
        {
            return View();
        }
        [Description(3, "Edit","编辑", 1)]
        public ActionResult Edit()
        {
            return View();
        }
        [Description(4, "Delete","删除", 1)]
        public ActionResult Delete()
        {
            return View();
        }
    }
}