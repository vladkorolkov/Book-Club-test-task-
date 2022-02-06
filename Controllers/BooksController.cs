using BookClub.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookClub.Controllers
{
    [Authorize]
    public class BooksController : Controller
    {
        //для доступа к переменной сесси во вьюшке
        private readonly ISession session;
        public Book readedBook { get; private set; }

        BooksContext Db;
        public BooksController(BooksContext db, IHttpContextAccessor httpContextAccessor)
        {
            Db = db;
            this.session = httpContextAccessor.HttpContext.Session;
        }
        public IActionResult AllBooks()
        {
            var allbooks = Db.Books.ToList();
            return View(allbooks);
        }

        [HttpPost]
        public IActionResult MarkAsRead(int id)
        {
            try
            {
                var query = Db.Books.Where(i => i.BookId == id).Select(n => n.Name).First();
                session.SetString(query, query);
                return RedirectToAction("MyReadBooks");
            }

            catch (Exception)
            {
                ViewBag.ErrorMessage = "Такого id не существует.";
                return View("MyReadBooks");
            }
        }
        [HttpPost]
        public IActionResult RemoveBook(string bookName)
        {
            try
            {
                var query = Db.Books.Where(i => i.Name == bookName).Select(n => n.Name).First();
                session.Remove(query);
                return RedirectToAction("MyReadBooks");
            }

            catch (Exception)
            {
                ViewBag.ErrorMessage = "Такого id не существует.";
                return RedirectToAction("MyReadBooks");
            }
        }
        [HttpGet]
        public IActionResult MyReadBooks()
        {
            return View();
        }

    }
}
