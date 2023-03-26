using Microsoft.AspNetCore.Mvc;
using Petty.Models.ContextData;

namespace Petty.Controllers
{
    public class UserAuthController : Controller
    {
        private readonly BookStoreDbContext _dbContext;

        public UserAuthController(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult UserReg(Models.UsersModel users)
        {
            return View(users);
        }
        [HttpPost]
        public IActionResult CreateUser(Models.UsersModel users)
        {
            users.User_IsAdmin = "No";

            _dbContext.Users.Add(users);
            _dbContext.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}
