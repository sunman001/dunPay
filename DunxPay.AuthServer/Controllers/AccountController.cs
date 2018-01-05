using System.Web.Mvc;

namespace DunxPay.AuthServer.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult SignIn()
        {
            return View();
        }
    }
}