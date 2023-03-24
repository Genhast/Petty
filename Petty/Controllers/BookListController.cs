using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Petty.Models;
using Petty.Models.ContextData;

namespace Petty.Controllers
{
    public class BookListController : Controller
    {
        private readonly BookStoreDbContext _dbContext;

        public BookListController(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult AdminList()
        {
            var Books = _dbContext.BooksList.ToList();
            return View(Books);
        }

        public IActionResult ClientList() 
        {
            var Books = _dbContext.BooksList.ToList();
            return View(Books);
        }
        [HttpGet]
        public IActionResult Edit(Models.BooksModel book)
        {
            
            // Создание объекта модели представления
            var model = new BooksModel
                {

                    Book_Id = book.Book_Id,
                    Book_Title = book.Book_Title,
                    Book_Description = book.Book_Description,
                    Book_Author = book.Book_Author,
                    Book_Amount = book.Book_Amount,
                    Book_Price = book.Book_Price
                };

                // Передача объекта модели представления в представление
                return View("~/Views/BookList/AdminEditor/Edit.cshtml", model);
        }

        [HttpPost]
        public IActionResult SaveChanges(Models.BooksModel model)
        {
            if (ModelState.IsValid)
            {
                // Получаем объект из базы данных по Book_Id
                var book = _dbContext.BooksList.Single(b => b.Book_Id == model.Book_Id);

                // Обновляем свойства объекта
                book.Book_Title = model.Book_Title;
                book.Book_Description = model.Book_Description;
                book.Book_Author = model.Book_Author;
                book.Book_Amount = model.Book_Amount;
                book.Book_Price = model.Book_Price;

                // Сохраняем изменения в базе данных
                _dbContext.SaveChanges();

                // Перенаправляем пользователя на страницу со списком книг
                return RedirectToAction("AdminList");
            }

            // Если модель не прошла валидацию, возвращаем представление с ошибками валидации
            return View(model);
            //return View("~/Views/BookList/AdminEditor/Edit.cshtml");
        }
        public IActionResult Delete()
        {
            var Books = _dbContext.BooksList.ToList();
            return View();
        }
        public IActionResult Create()
        {
            var Books = _dbContext.BooksList.ToList();
            return View();
        }
        public IActionResult Details() 
        {
            var Books = _dbContext.BooksList.ToList();
            return View();
        }
        public IActionResult AddToCart()
        {
            var Books = _dbContext.BooksList.ToList();
            return View();
        }
    }
}
