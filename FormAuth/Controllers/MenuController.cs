using FormAuth.Utils;
using System.Reflection;
using System.Web.Mvc;

namespace FormAuth.Controllers
{
    public class MenuController : Controller
    {
        // GET: Menu
        public ActionResult Index()
        {
            var menuList = SystemMenuInfo.GetMenuByAssembly(Assembly.GetExecutingAssembly().GetName().Name);//获取所有加自定义权限控制的Action 信息
            return View(menuList);
        }
    }
}