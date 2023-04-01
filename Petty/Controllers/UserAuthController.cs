using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Petty.Models.ContextData;
using System.Security.Claims;
using System;

namespace Petty.Controllers
{
    public class UserAuthController : Controller
    {
        private readonly BookStoreDbContext _dbContext;

        public UserAuthController(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet]
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

            return RedirectToAction("UserAuth");
        }
        [HttpGet]
        public IActionResult UserAuth(Models.UsersModel users)
        {
            return View(users);
        }
        [HttpPost]
        public async Task<IActionResult> CheckUser(Models.UsersModel users)
        {   
            var user = _dbContext.Users.FirstOrDefault(u => u.User_Name == users.User_Name && u.User_Password == users.User_Password);
            if (user is null) return Unauthorized();
            if (user == null)
            {
                TempData["ErrorMessage"] = "Пользователь не найден";
                return RedirectToAction("UserAuth");
            }
            else
            {
                var claims = new List<Claim> { new Claim(ClaimTypes.Name, user.User_Name) };
                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Cookies");
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
                return RedirectToAction("Index", "Home");
            }
        }
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }

    }
}
