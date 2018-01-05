using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DunxPay.Admin.Controllers
{
    public class LoggerController : Controller
    {
        // GET: Logger
        public ActionResult DxAdminOperationLog()
        {
            return View();
        }
    }
}