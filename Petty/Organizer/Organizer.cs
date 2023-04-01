using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Petty.Models;
using Petty.Models.ContextData;

namespace Petty.Organizer
{
    public class Organizer
    {
        private readonly BookStoreDbContext _dbContext;

        public Organizer(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool IsAdminCheck(HttpContext context)
        {
            bool status;
            string userName = context.User.Identity.Name;
            var isAdmin = _dbContext.Users.FirstOrDefault(u => u.User_Name == userName && u.User_IsAdmin == "Yes");

            status = isAdmin == null ? false : true;
            return status;
        }
    }
}
