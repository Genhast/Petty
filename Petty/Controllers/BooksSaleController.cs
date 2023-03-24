using Microsoft.AspNetCore.Mvc;

namespace Petty.Controllers
{
    public class BooksSaleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
