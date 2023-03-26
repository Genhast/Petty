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
        public IActionResult Edit()
        {
            var model = new BooksModel();
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
            return View(model);
        }
        public IActionResult Delete([FromRoute] int id)
        {
            var model = new Models.BooksModel();
            model.Book_Id = id;

            if (ModelState.IsValid)
            {
                var Books = _dbContext.BooksList.Single(b => b.Book_Id == model.Book_Id);

                Books.Book_Title = model.Book_Title;
                Books.Book_Description = model.Book_Description;
                Books.Book_Author = model.Book_Author;
                Books.Book_Amount = model.Book_Amount;
                Books.Book_Price = model.Book_Price;

                return View("~/Views/BookList/AdminEditor/Delete.cshtml", Books);
            }
            return View("Index");
        }
        [HttpPost]
        public IActionResult DeleteRecord(Models.BooksModel model)
        {
            if (model.Book_Id != null)
            {
                // Получаем объект из базы данных по Book_Id
                var book = _dbContext.BooksList.Single(b => b.Book_Id == model.Book_Id);

                _dbContext.BooksList.Remove(book);
                _dbContext.SaveChanges();

                // Перенаправляем пользователя на страницу со списком книг
                return RedirectToAction("AdminList");
            }
            return Content("Invalid id"); 
        }
        public IActionResult Create()
        {
            var Books = new Models.BooksModel();
            return View("~/Views/BookList/AdminEditor/Create.cshtml", Books);
        }
        [HttpPost]
        public IActionResult CreateRecord(Models.BooksModel model)
        {
            _dbContext.BooksList.Add(model);
            _dbContext.SaveChanges();

            return RedirectToAction("AdminList");
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
