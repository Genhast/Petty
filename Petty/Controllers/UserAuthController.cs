using Microsoft.AspNetCore.Mvc;

namespace Petty.Controllers
{
    public class UserAuthController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
