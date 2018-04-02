using FormAuth.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FormAuth.Controllers
{
    [Description(3, "Good", "Good", 0)]

    [RoleAuthorize]
    public class GoodController : BaseController
    {
        // GET: Good
        [Description(1, "Index", "首页", 3)]
        public ActionResult Index()
        {
            return View();
        }
        [Description(2, "Add", "新增", 3)]
        public ActionResult Add()
        {
            return View();
        }
        [Description(3, "Edit", "编辑", 3)]
        public ActionResult Edit()
        {
            return View();
        }
        [Description(4, "Delete", "删除", 3)]
        public ActionResult Delete()
        {
            return View();
        }
    }
}