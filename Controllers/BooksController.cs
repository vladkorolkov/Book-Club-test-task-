using BookClub.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
namespace BookClub.Controllers
{
    public class BooksController : Controller
    {
        private const string sessionKey = "userbooks";
        BooksContext Db;
        public BooksController(BooksContext db)
        {
            Db = db;
           
        }
        public IActionResult AllBooks()
        {
            var allbooks = Db.Books.ToList();
            return View(allbooks);
        }

        [HttpPost]
        public IActionResult MarkAsRead(int id)
        {
            var query = Db.Books.Where(i => i.BookId == id).Select(n=>n.Name).First();
            HttpContext.Session.SetString(sessionKey, query);
            return View();
        }

        [HttpGet]
        public IActionResult MyReadBooks()
        {
            var mybooks = HttpContext.Session.GetString(sessionKey);
            ViewData["MyBook"] = mybooks;
            return View();
        }

    }
}
