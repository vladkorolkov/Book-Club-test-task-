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
        private const string sessionKey = "userbooks";
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
            var query = Db.Books.Where(i => i.BookId == id).Select(n=>n.Name).First();
            this.session.SetString(sessionKey, query);                    
            return RedirectToAction("MyReadBooks");
        }

        [HttpGet]
        public IActionResult MyReadBooks()
        {
            //var mybooks = HttpContext.Session.GetString(sessionKey);
            //ViewData["MyBook"] = mybooks;
            return View();
        }

    }
}
