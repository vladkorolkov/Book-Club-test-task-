using BookClub.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
namespace BookClub.Controllers
{
    public class BooksController : Controller
    {
        private static List<Book> ReadBooks;
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
            
            var query = Db.Books.Where(i => i.BookId == id).First();
            ReadBooks.Add(query);
            return View("ReadBooks", ReadBooks);
        }

    }
}
