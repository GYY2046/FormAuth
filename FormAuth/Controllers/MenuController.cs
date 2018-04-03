using FormAuth.DBServer;
using FormAuth.Utils;
using FormAuth.ViewsModel;
using System.Reflection;
using System.Web.Mvc;

namespace FormAuth.Controllers
{
    public class MenuController : BaseController
    {
        private UserServer db = null;
        public MenuController()
        {
            db = new UserServer("DefaultConnection");
        }
        // GET: Menu
        public ActionResult Index()
        {
            //var menuList = SystemMenuInfo.GetMenuByAssembly(Assembly.GetExecutingAssembly().GetName().Name);//获取所有加自定义权限控制的Action 信息

            RolePermissionIndex rpIndex = new RolePermissionIndex();
            rpIndex.RoleList = db.GetAllRole();
            rpIndex.PerList = db.GetAllPermission();
            return View(rpIndex);
        }
         
    }
}