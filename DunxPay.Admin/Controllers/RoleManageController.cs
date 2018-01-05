using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DunxPay.Admin.Controllers
{
    public class RoleManageController : Controller
    {
        /// <summary>
        /// 运营角色管理
        /// </summary>
        /// <returns></returns>
        public ActionResult OperateList()
        {
            return View();
        }

        /// <summary>
        /// 开发者角色管理
        /// </summary>
        /// <returns></returns>
        public ActionResult DeveloperList()
        {
            return View();
        }

        /// <summary>
        /// 商务角色管理
        /// </summary>
        /// <returns></returns>
        public ActionResult BusinessAffairsList()
        {
            return View();
        }

        /// <summary>
        /// 代理商角色管理
        /// </summary>
        /// <returns></returns>
        public ActionResult AgentList()
        {
            return View();
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <returns></returns>
        public ActionResult CreateorEdit()
        {
            return View();
        }




        /// <summary>
        /// 权限设置
        /// </summary>
        /// <returns></returns>
        public ActionResult Permissionset()
        {
            return View();
        }
    }
}