using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DunxPay.Admin.Controllers
{
    public class AppTypeController : Controller
    {
        // GET: AppType
        public ActionResult List()
        {
            return View();
        }

        public ActionResult CreateorEdit()
        {
            return View();
        }
    }
}