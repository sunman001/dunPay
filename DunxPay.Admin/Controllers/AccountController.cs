using System.Web.Mvc;

namespace DunxPay.Admin.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Callback()
        {
            return View();
        }

        public ActionResult Grant()
        {
            return View();
        }

        public ActionResult Logout()
        {
            return View();
        }

       
    }
}