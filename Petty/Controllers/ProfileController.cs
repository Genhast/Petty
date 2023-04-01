using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Petty.Models.ContextData;

namespace Petty.Controllers
{
    public class ProfileController : Controller
    {
        private readonly BookStoreDbContext _dbContext;

        public ProfileController(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult UserProfile()
        {
            string userName = HttpContext.User.Identity.Name;
            var UserInfo = _dbContext.Users.Single(u => u.User_Name == userName);
            return View(UserInfo);
        }
    }
}
