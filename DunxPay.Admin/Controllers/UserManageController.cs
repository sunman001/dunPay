using System.Web.Mvc;

namespace DunxPay.Admin.Controllers
{
    public class UserManageController : Controller
    {
        /// <summary>
        /// 运营管理
        /// </summary>
        /// <returns></returns>
        public ActionResult OperateList()
        {
            return View();
        }

        /// <summary>
        /// 运营添加or编辑
        /// </summary>
        /// <returns></returns>
        public ActionResult CreateorEdit()
        {
            return View();
        }

        /// <summary>
        /// 商务管理
        /// </summary>
        /// <returns></returns>
        public ActionResult BusinessAffairsList()
        {
            return View();
        }


        /// <summary>
        /// 开发者管理
        /// </summary>
        /// <returns></returns>
        public ActionResult DeveloperList()
        {
            return View();
        }

        /// <summary>
        /// 开发者添加or编辑
        /// </summary>
        /// <returns></returns>
        public ActionResult DCreateorEdit()
        {
            return View();
        }
    }
}