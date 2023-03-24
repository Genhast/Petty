using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace Petty.Models.ContextData
{
    public class BookStoreDbContext : DbContext
    {
        public DbSet<BooksModel> BooksList { get; set; } = null!;
        public DbSet<UsersModel> Users { get; set; }
        public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
