using FormAuth.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FormAuth.Controllers
{
    [Description(2, "World","Wrold", 0)]
    [RoleAuthorize]
    public class WorldController : BaseController
    {
        [Description(1, "Index","首页", 2)]
        // GET: World
        public ActionResult Index()
        {
            return View();
        }
        [Description(2, "Index","新增", 2)]
        public ActionResult Add()
        {
            return View();
        }
        [Description(3, "Edit", "编辑", 2)]
        public ActionResult Edit()
        {
            return View();
        }
        [Description(4, "Delete", "删除", 2)]
        public ActionResult Delete()
        {
            return View();
        }
    }
}
