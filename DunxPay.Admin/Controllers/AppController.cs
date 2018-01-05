using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DunxPay.Admin.Controllers
{
    public class AppController : Controller
    {
        // GET: App
        public ActionResult List()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Edit()
        {
            return View();
        }

        public ActionResult AppAuditing()
        {
            return View();
        }
        public ActionResult AppRate()
        {
            return View();
        }
    }
}