using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DunxPay.Admin.Controllers
{
    public class ModuleController : Controller
    {
        /// <summary>
        /// 模块列表
        /// </summary>
        /// <returns></returns>
        
        public ActionResult List()
        {
            return View();
        }
        /// <summary>
        /// 新增模块
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Edit()
        {
            return View();
        }
        public ActionResult TreeList()
        {
            return View();
        }

    }
}