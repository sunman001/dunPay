using System.Web.Mvc;

namespace DunxPay.ApiServer.Controllers
{
    public class HomeController : Controller
    {
        [PermissionFilter(CheckPermission = false, ActionCode = "VIEW")]
        public ActionResult Index()
        {
            ////操作日志调用列子
           // int UserId = 1;
          //  ILogger logger = AdministratorFactory.CreateLogger(UserId);

           // logger.OperateLog("111", "test");
            ////错误日志调用例子
          //  AdminGlobalErrorLogger.ErrorLogger("",1);


            return View();
        }

        [PermissionFilter]
        public ActionResult Contact()
        {
            var hello = "";
            return View();
        }
    }
}