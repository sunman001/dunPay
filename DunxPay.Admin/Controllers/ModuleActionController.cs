using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DunxPay.Admin.Controllers
{
    public class ModuleActionController : Controller
    {
        // GET: ModuleAction

        /// <summary>
        /// 新增操作码
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
    }
}