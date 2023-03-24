using Microsoft.EntityFrameworkCore;
using Petty.Models.ContextData;

namespace Petty
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();

            // �������� ������ ����������� �� ����� ������������
            string connection = builder.Configuration.GetConnectionString("DefaultConnection");

            // ��������� �������� ApplicationContext � �������� ������� � ����������
            builder.Services.AddDbContext<BookStoreDbContext>(options => options.UseSqlServer(connection));

            // ��������� ������� � ���������
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapControllerRoute(name: "AList", pattern: "{controller=BookListController}/{action=AdminList}");
            app.MapControllerRoute(name: "CList", pattern: "{controller=BookListController}/{action=ClientList}");
            app.MapControllerRoute(name: "AEdit", pattern: "{controller=BookListController}/{action=Edit}");
            app.MapControllerRoute(name: "ADelete", pattern: "{controller=BookListController}/{action=Delete}");
            app.MapControllerRoute(name: "ADetails", pattern: "{controller=BookListController}/{action=Details}");
            app.MapControllerRoute(name: "ACreate", pattern: "{controller=BookListController}/{action=Create}");
            app.MapControllerRoute(name: "CAddToCart", pattern: "{controller=BookListController}/{action=AddToCart}");
            app.MapControllerRoute(name: "SaveChanges", pattern: "{controller=BookListController}/{action=SaveChanges}");

            app.Run();
        }
    }
}